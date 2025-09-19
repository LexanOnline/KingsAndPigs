using UnityEngine;
using UnityEngine.InputSystem;


public class GatherImput : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private float _valueX;

    public float ValueX { get => _valueX; }

    private void Awake()
    {
        controls = new Controls();

    }

    private void OnEnable()
    {
        controls.Player.MoveDpadGamepad.performed += StartMove;
        controls.Player.MoveDpadGamepad.canceled += StopMove;
        controls.Player.MoveJoystickGamepad.performed += StartMove;
        controls.Player.MoveJoystickGamepad.canceled += StopMove;
        controls.Player.Enable();
    }

    private void StartMove(InputAction.CallbackContext context)
        {
        _valueX = context.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        _valueX = 0;
    }


    private void OnDisable()
    {
        controls.Player.MoveDpadGamepad.performed -= StartMove;
        controls.Player.MoveDpadGamepad.canceled -= StopMove;
        controls.Player.MoveJoystickGamepad.performed -= StartMove;
        controls.Player.MoveJoystickGamepad.canceled -= StopMove;
        controls.Player.Disable();
    }
}
