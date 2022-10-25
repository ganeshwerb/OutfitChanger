using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRegister : MonoBehaviour, PlayerInputMaps.IPlayerActions
{
    [SerializeField]private PlayerInputMaps inputActions;
    [SerializeField] private Vector2 movementVector;
    [SerializeField] private bool isSprinting;
    [SerializeField] private bool isSitting;
    [SerializeField] Vector2 nav;
    private void Awake()
    {
        inputActions = new PlayerInputMaps();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)  isSprinting = true; 
        else isSprinting = false;
    }

    public void OnSit(InputAction.CallbackContext context)
    {
        if (context.performed) isSitting = true;
        else isSitting = false;
    }
    public Vector2 SeeMovementVector()
    {
        return movementVector;
    }

    public bool GetIsSprinting()
    {
        return isSprinting;
    }

    public bool GetIsSitting()
    {
        return isSitting;
    }
    public Vector2 GetNav()
    {
        return nav;
    }
    public void OnChangeShirt(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnChangeJacket(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnChangePants(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnChangeShoes(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNav(InputAction.CallbackContext context)
    {
        nav = context.ReadValue<Vector2>();
        
    }
}
