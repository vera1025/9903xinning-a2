using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;

    public void An_1()
    {
        animator.SetFloat("Speed", 0f);
    }
    public void An_2()
    {
        animator.SetTrigger("fall");
    }
}
