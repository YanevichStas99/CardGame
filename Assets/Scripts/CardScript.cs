using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera camera;
    Vector3 offset;
    public Transform defaultParent, defaultTempCardParent;
    public GameObject tempCardGO;
    void Awake()
    {
        camera = Camera.allCameras[0];
        tempCardGO = GameObject.Find("TempCardGo");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - camera.ScreenToWorldPoint(eventData.position);
        defaultParent = defaultTempCardParent = transform.parent;
        tempCardGO.transform.SetParent(defaultParent);
        tempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(defaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = camera.ScreenToWorldPoint(eventData.position);
        
        transform.position = newPos+offset;
        checkPosition();
        if (tempCardGO.transform.parent != defaultTempCardParent)
        {
            tempCardGO.transform.SetParent(defaultTempCardParent);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(tempCardGO.transform.GetSiblingIndex());
        tempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        tempCardGO.transform.localPosition = new Vector3(2618, 0);
    }

    void checkPosition()
    {
        int newIndex = defaultTempCardParent.childCount;
        for (int i = 0; i < defaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < defaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;
                if (tempCardGO.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }
        tempCardGO.transform.SetSiblingIndex(newIndex);
    }



}
