using UnityEngine;
using Photon.Pun;

namespace com.compA.gameA
{
    public class PlayerAnimatorManager : MonoBehaviourPun
    {
        [SerializeField]
        float directionDampTime = 0.25f;
        Animator animator;
        
        void Start()
        {
            animator = GetComponent<Animator>();
            if(!animator) Debug.LogError("PAM missing Animator comp");
        }

        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                Debug.Log("photonview.IsMine == false, IsConnected == true");
            }

            AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // Check if running
            if(animStateInfo.IsName("BaseLayer.Run"))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("Jump");
                }
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            if (v < 0) v = 0;

            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
        }



    }
}
