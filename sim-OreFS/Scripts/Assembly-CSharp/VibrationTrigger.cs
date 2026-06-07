using UnityEngine;

public class VibrationTrigger : MonoBehaviour
{
	[Header("Vibration Settings")]
	[Range(0f, 1f)]
	public float lowFrequency = 0.5f;

	[Range(0f, 1f)]
	public float highFrequency = 0.8f;

	public float duration = 0.2f;

	public void TriggerVibration()
	{
		if (VibrationManager.Instance != null)
		{
			VibrationManager.Instance.Vibrate(lowFrequency, highFrequency, duration);
		}
	}
}
