using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private CharacterController _charController;
    [SerializeField] public Canvas canvasUI;
    [SerializeField] public GameObject gameManager;

    public float moveSpeedInitial = 1f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;

    private float _vertSpeed;
    private float moveSpeed;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }


    void Update()
    {
        moveSpeed = moveSpeedInitial;
        if (!_charController.isGrounded)
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
        }
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement.x = deltaX * moveSpeed;
        movement.z = deltaZ * moveSpeed;

        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        //falling
        if (gameObject.transform.position.y <= 0f)
        {
            canvasUI.GetComponent<CanvasManager>().DrawLosingMessage();
            StartCoroutine(gameManager.GetComponent<LevelManager>().GameEnding());
        }
    }

}
