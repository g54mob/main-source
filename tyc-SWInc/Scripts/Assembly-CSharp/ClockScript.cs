using UnityEngine;

public class ClockScript : MonoBehaviour
{
	public Transform Finger;

	private void Update()
	{
		if (TimeOfDay.Instance != null)
		{
			float num = (float)TimeOfDay.Instance.Hour + TimeOfDay.Instance.Minute / 60f;
			num = num % 12f / 12f;
			Finger.localRotation = Quaternion.Euler(0f, num * 360f, 0f);
		}
	}
}
