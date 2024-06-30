using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAattack : MonoBehaviour
{   
    public GameObject attack2;
    Animator animator;
    private void Awake() 
    {
        animator = GetComponent<Animator>();
        attack2.SetActive(false);
    }
    void Update()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
        {
            if(Input.GetButtonDown("Fire1"))
            {
                PlayerAmove.maxspeed = 2f;
                animator.SetTrigger("Attack2");
                Invoke("HitOn", 0.3f);
            }
            else
                PlayerAmove.maxspeed = 5f;
        }
        
    }
    void HitOn()
    {
        attack2.SetActive(true);
        Invoke("HitEnd", 0.2f);
    }
    void HitEnd()
    {
        attack2.SetActive(false);
    }
}
