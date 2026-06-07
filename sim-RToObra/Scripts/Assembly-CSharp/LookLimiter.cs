using UnityEngine;

public class LookLimiter : MonoBehaviour
{
	public float rotMin;

	public float rotMax;

	private void LateUpdate()
	{
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		if (localEulerAngles.y > 360f)
		{
			localEulerAngles.y %= 360f;
		}
		else if (localEulerAngles.y < -360f)
		{
			localEulerAngles.y = 0f - (0f - localEulerAngles.y) % 360f;
		}
		if (localEulerAngles.y > 180f)
		{
			localEulerAngles.y -= 360f;
		}
		localEulerAngles.y = Mathf.Clamp(localEulerAngles.y, rotMin, rotMax);
		base.transform.localEulerAngles = localEulerAngles;
	}
}
