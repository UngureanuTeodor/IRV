using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = new Color(180f / 255f, 50f / 255f, 50f / 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = new Color(50f / 255f, 50f / 255f, 50f / 255f);
    }
}