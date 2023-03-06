using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private GameObject cinemachineTargetObject;
    private float cinemachineTargetX;
    private float cinemachineTargetY;

    public PlayerInputs playerInputs;
    [SerializeField] private float minY = -30.0f;
    [SerializeField] private float maxY = 70.0f;
    [SerializeField] private float lookSpeed = 100.0f;


    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }


    private void Update()
    {
        CameraRotation();
    }


    private void CameraRotation()
    {
        cinemachineTargetX += playerInputs.PlayerControls.Look.ReadValue<Vector2>().x * Time.deltaTime * lookSpeed;
        cinemachineTargetY += (playerInputs.PlayerControls.Look.ReadValue<Vector2>().y * Time.deltaTime * lookSpeed) * -1;

        cinemachineTargetX = CameraClampAngle(cinemachineTargetX, float.MinValue, float.MaxValue);
        cinemachineTargetY = CameraClampAngle(cinemachineTargetY, minY, maxY);

        cinemachineTargetObject.transform.rotation = Quaternion.Euler(cinemachineTargetY + 0.0f, cinemachineTargetX, 0.0f);
    }

    private float CameraClampAngle(float angle, float angleMin, float angleMax)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;

        return Mathf.Clamp(angle, angleMin, angleMax);
    }

}
