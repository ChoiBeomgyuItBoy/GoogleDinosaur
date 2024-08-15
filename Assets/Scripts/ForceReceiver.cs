using UnityEngine;

namespace CombatSystem.Core
{
    public class ForceReceiver : MonoBehaviour
    {
        [SerializeField] float gravityMultiplier = 2;
        CharacterController controller;
        float verticalVelocity = 0;

        public void Jump(float force)
        {
            if(controller.isGrounded)
            {
                verticalVelocity += force;
            }
        }

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if(controller.isGrounded && verticalVelocity < 0)
            {
                verticalVelocity = Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }
            else
            {
                verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }

            controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        }
    }
}
