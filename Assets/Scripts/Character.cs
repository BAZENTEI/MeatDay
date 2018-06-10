using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Character : MonoBehaviour {
    public float speed = 7;
    private Rigidbody rigidbody;
    public UnityArmatureComponent armatureComp;
    public DragonBones.AnimationState animationState = new DragonBones.AnimationState();
    public bool isChopping = false;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        armatureComp = transform.GetComponentInChildren<UnityArmatureComponent>();
        armatureComp.AddEventListener(EventObject.FADE_IN_COMPLETE, AnimationEventHandler);
        armatureComp.AddEventListener(EventObject.FADE_OUT_COMPLETE, AnimationEventHandler);
        armatureComp.animation.Reset();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Chop(Input.GetMouseButton(0));
    }

    private Vector3 moveDir = Vector3.zero;
    void Move()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(xAxis * speed * Time.deltaTime / 2, 0, zAxis * speed * Time.deltaTime);
        rigidbody.MovePosition(transform.position + moveDir);
        updateAnimation();
    }
    void Chop(bool isChopping)
    {
        this.isChopping = isChopping;
        updateAnimation(); 
    }
    private void updateAnimation()
    {
        if (isChopping)
        {
            isChopping = false;
            animationState = armatureComp.animation.Play("chop",1);
        }
        else if(!animationState.isPlaying)
        {
            animationState = armatureComp.animation.Play("idle");
        }
    }
    private void AnimationEventHandler(string type,EventObject eventObject)
    {
        switch (type)
        {
            case EventObject.FADE_OUT_COMPLETE:
                if (eventObject.animationState.name == "chop")
                {
                    animationState = null;
                }
                break;
        }
    }
}