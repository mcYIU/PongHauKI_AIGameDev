using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler

{
    Vector2 pressToPivotDifference;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 pressPos = eventData.position;
        pressToPivotDifference = (Vector2)transform.position - pressPos;
        print("1");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + pressToPivotDifference;
        print("2");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("3");
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("4");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("5");
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
