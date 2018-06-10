using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSorting : MonoBehaviour {

    public int backward=0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        spriteRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min).z * -1- backward;
    }
}
