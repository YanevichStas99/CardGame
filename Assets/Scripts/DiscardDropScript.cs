using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardDropScript : MonoBehaviour, IDropHandler, IPointerEnterHandler //IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardScript card = eventData.pointerDrag.GetComponent<CardScript>();

        if (card)
        {
            card.defaultParent = transform;
        }
        card.transform.localPosition = new Vector3(-490, 970);
        card.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        card.GetComponent<CardScript>().enabled = false;
        card.tempCardGO.transform.localPosition = new Vector3(2618, 0);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        CardScript card = eventData.pointerDrag.GetComponent<CardScript>();
        if (card)
        {
            card.defaultTempCardParent = transform;
        }
        
    }

    /*public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        CardScript card = eventData.pointerDrag.GetComponent<CardScript>();
        if (card && card.defaultTempCardParent == transform)
        {
            card.defaultTempCardParent = card.defaultParent;
        }
        
        
    }*/
}
