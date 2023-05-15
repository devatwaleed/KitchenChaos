using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour{

    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }


    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetComponentMovementNormalized()
    {
        //working in 3d but movements are bound to 2d so initializing Vector2
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // when two keys are pressed values double too to make them uniform normalized is used
        inputVector = inputVector.normalized;
        return inputVector;
    }

}


