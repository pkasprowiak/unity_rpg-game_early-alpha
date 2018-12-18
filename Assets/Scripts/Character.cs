using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private float speed;

    protected Vector2 direction;
    private Animator animator;

    // Use this for initialization
    protected virtual void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        //print("character");
        Move();	
	}

    public void Move()
    {
        if( direction.x != 0 || direction.y != 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            AnimateMovement(direction);
        }
        else animator.SetLayerWeight(1, 0);
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
