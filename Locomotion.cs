using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Locomotion : MonoBehaviour
{
    [SerializeField] float sitDist;
    [SerializeField]Camera mainCam;
    InputRegister inputRegister;
    CharacterController characterController;
    [SerializeField] Transform chair;
    float walkingSpeed = 2f;
    float sprintingSpeed = 4f;
    [SerializeField]Vector3 camForward;
    [SerializeField]Vector3 camRight;
    [SerializeField]Vector3 modifiedMovement;
    Animator playerAnimator;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputRegister = GetComponent<InputRegister>();
        playerAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        FaceDir();
        modifiedMovement = (inputRegister.SeeMovementVector().x * camRight) + (inputRegister.SeeMovementVector().y * camForward);
        if (modifiedMovement.magnitude > 0.1f && !inputRegister.GetIsSitting())
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(modifiedMovement), 0.25f);
            if (inputRegister.GetIsSprinting())
            {
                playerAnimator.SetFloat("Movement", 1f);
                characterController.Move(Time.deltaTime * sprintingSpeed * modifiedMovement);
            }
            else
            {
                playerAnimator.SetFloat("Movement", 0.5f);
                characterController.Move(Time.deltaTime * walkingSpeed * modifiedMovement);
            }
        }
        else
        {
            
            if (inputRegister.GetIsSitting() && (transform.position - chair.transform.position).magnitude < sitDist)
            {
                
                Debug.Log((transform.position - chair.position).magnitude);
                transform.position =  chair.position;
                 transform.eulerAngles =new Vector3(chair.eulerAngles.x, 90f, chair.eulerAngles.z); 
                modifiedMovement = Vector3.zero;
                playerAnimator.SetBool("Sitting", inputRegister.GetIsSitting());
            }
            else {
                playerAnimator.SetBool("Sitting", false);
                playerAnimator.SetFloat("Movement", 0f);
            }
        }

    }
    void FaceDir()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;
        camForward.y = 0;
        camRight.y = 0;
    }
}
