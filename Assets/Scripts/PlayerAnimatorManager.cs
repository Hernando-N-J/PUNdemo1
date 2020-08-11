using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.compA.gameA
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            if(!animator) Debug.LogError("PAM missing Animator comp");
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0) v = 0;
            animator.SetFloat("Speed", h * h + v * v);
        }



    }
}
