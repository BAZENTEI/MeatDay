using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Tree : MonoBehaviour {


    void OnCollisionStay(Collision collision)
    {
        DragonBones.AnimationState animationState = collision.gameObject.GetComponent<Character>().animationState;

        if (collision.collider.name.Equals("axe")&& animationState.name=="chop"&& animationState.currentTime>=animationState.totalTime*2/3)
        {
            Destroy(gameObject);
        }
    }
}
