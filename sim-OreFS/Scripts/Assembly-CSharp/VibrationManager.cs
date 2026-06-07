using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationManager : MonoBehaviour
{
	public static VibrationManager Instance;

	public InputDetection inputDetection;

	public bool enableVibrations = true;

	public float vibrationMultiplier = 1f;

	private float adjustedLowFrequency;

	private float adjustHighFrequency;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Vibrate(float lowFrequency, float highFrequency, float duration)
	{
		Gamepad current = Gamepad.current;
		if (current != null && inputDetection.GamepadEnabled && enableVibrations)
		{
			adjustedLowFrequency = lowFrequency * vibrationMultiplier;
			adjustHighFrequency = highFrequency * vibrationMultiplier;
			current.SetMotorSpeeds(adjustedLowFrequency, adjustHighFrequency);
			CancelInvoke("StopVibration");
			Invoke("StopVibration", duration);
		}
	}

	private void StopVibration()
	{
		Gamepad.current?.SetMotorSpeeds(0f, 0f);
	}
}
