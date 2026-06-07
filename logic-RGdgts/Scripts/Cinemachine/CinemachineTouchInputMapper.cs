using UnityEngine;

public class CinemachineTouchInputMapper : MonoBehaviour
{
	public float TouchSensitivityX;

	public float TouchSensitivityY;

	public string TouchXInputMapTo;

	public string TouchYInputMapTo;

	private void Start()
	{
	}

	private float GetInputAxis(string axisName)
	{
		return 0f;
	}
}
