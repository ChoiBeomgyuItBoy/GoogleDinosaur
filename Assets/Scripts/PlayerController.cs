using CombatSystem.Core;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float jumpForce = 3;
    [SerializeField] UnityEvent onDead;
    ForceReceiver forceReceiver;

    public void Kill()
    {
        onDead?.Invoke();
    }

    void Awake()
    {
        forceReceiver = GetComponent<ForceReceiver>();
    }

    void Update()
    {
        if(Input.GetKey(jumpKey))
        {
            forceReceiver.Jump(jumpForce);
        }
    }
}
