using UnityEngine;
using UnityEngine.UI;

namespace com.compA.gameA
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] Text playerNameText;

        [SerializeField] Slider playerHealthSlider;

        [Tooltip("Pixel offset from the player target")]
        [SerializeField] Vector3 screenOffset = new Vector3(0f, 30f, 0f);

        PlayerManager playerManagerTarget;
        
        Vector3 targetPosition;
        Transform targetTransform;
        Renderer targetRenderer;
        CanvasGroup _canvasGroup;

        float characterControllerHeight = 0f;


        void Awake()
        {
            this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);

            _canvasGroup = this.GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (playerHealthSlider != null)
                playerHealthSlider.value = playerManagerTarget.Health;

            if (playerManagerTarget == null) Destroy(this.gameObject);
        }

        void LateUpdate()
        {
            // Do not show the UI if we are not visible to the camera, thus avoid potential bugs with seeing the UI, but not the player itself.
            if (targetRenderer != null) 
                this._canvasGroup.alpha = targetRenderer.isVisible ? 1f : 0f;
            
            // Follow the Target GameObject on screen.
            if (targetTransform != null)
            {
                targetPosition = targetTransform.position;
                targetPosition.y += characterControllerHeight;
                this.transform.position = Camera.main.WorldToScreenPoint(targetPosition) + screenOffset;
            }
        }

        public void SetTarget(PlayerManager _target)
        {
            if(_target == null) Debug.Log("< Color = Red >< a > Missing </ a ></ Color > PlayerManager target for PlayerUI.SetTarget.", this);

            // Cache references for efficiency
            playerManagerTarget = _target;

            if (playerNameText != null) 
                playerNameText.text = playerManagerTarget.photonView.Owner.NickName;

            targetTransform = this.playerManagerTarget.GetComponent<Transform>();
           
            targetRenderer = this.playerManagerTarget.GetComponent<Renderer>();
            
            CharacterController characterController = _target.GetComponent<CharacterController>();

            // Get data from the Player that won't change during the lifetime of this Component
            if (characterController != null)
            {
                characterControllerHeight = characterController.height;
            }
        }


    }
}
