using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In metres per second")] [SerializeField]  float controlSpeed = 4f;

    [Tooltip("In metres")] [SerializeField]  float xRange = 6.7f;
    [Tooltip("In metres")] [SerializeField]  float yRange = 5f;

    [Header("Screen-Position based")]
    [SerializeField]  float positionPitchFactor = -5f;

    [SerializeField]  float positionYawFactor = 5f;

    [Header("Control-Throw based")]
    [SerializeField]  float controlRollFactor = -20f;

    [SerializeField]  float controlPitchFactor = -5f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    
    [SerializeField] GameObject deathSFX;

    private void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;

        float xClampPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float yClampPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClampPos, yClampPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrowControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToThrowControl;

        float roll = xThrow * controlRollFactor;

        float yaw = transform.localPosition.x * positionYawFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnPlayerDeath()
    {
        deathSFX.SetActive(true);
        isControlEnabled = false;
    }

    
}