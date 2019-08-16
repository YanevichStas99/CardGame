﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardScript card = eventData.pointerDrag.GetComponent<CardScript>();

        if (card)
        {
            card.defaultParent = transform;
        }
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

    public void OnPointerExit(PointerEventData eventData)
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
        

    }
}
