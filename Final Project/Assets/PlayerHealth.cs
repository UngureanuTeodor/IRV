using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Slider charismaSlider;
    public Text coinsText;
    public Text sticksText;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public int startingCharisma = 100;
    public int currentCharisma;
    public int coins;
    public int sticks;
    public int chests;
    public GameObject firePrefab;

    AudioSource playerAudio;

    bool isDead;
    bool damaged;
    bool isRemovingHealth = false;


    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();

        currentHealth = GameData.Instance.health;
        currentCharisma = GameData.Instance.charisma;
        coins = GameData.Instance.coins;
        sticks = GameData.Instance.sticks;
        chests = GameData.Instance.chests;

        healthSlider.value = currentHealth;
        charismaSlider.value = currentCharisma;
        coinsText.text = "" + coins;
        sticksText.text = "" + sticks;
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (sticks >= 3)
            {
                Instantiate(firePrefab, transform.position + new Vector3(-1, 0, 0), transform.rotation);
                sticks -= 3;
                sticksText.text = "" + sticks;
                if (currentHealth <= 90)
                {
                    currentHealth += 10;
                    healthSlider.value = currentHealth;
                }
            }
        }

        if (!isRemovingHealth)
        {
            StartCoroutine(RemoveHealth());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameData.SaveData(currentHealth, currentCharisma, sticks, coins);
        }
    }

    IEnumerator RemoveHealth()
    {
        isRemovingHealth = true;
        yield return new WaitForSeconds(5f);

        if (currentHealth > 20)
        {
            currentHealth -= 10;
            healthSlider.value = currentHealth;
        }

        isRemovingHealth = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerAudio.clip = deathClip;
        playerAudio.Play();
    }

    public void collectStick()
    {
        sticks++;
        sticksText.text = "" + sticks;
    }
}