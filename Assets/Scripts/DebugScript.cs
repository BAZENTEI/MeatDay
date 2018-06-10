using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min));
    }
}
