using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	private enum Mode
	{
		LookAt = 0,
		LookAtInverted = 1,
		CameraForward = 2,
		CameraForwardInverted = 3
	}

	[SerializeField]
	private Mode mode;

	private void LateUpdate()
	{
		switch (mode)
		{
		case Mode.LookAt:
			base.transform.LookAt(Camera.main.transform);
			break;
		case Mode.LookAtInverted:
		{
			Vector3 vector = base.transform.position - Camera.main.transform.position;
			base.transform.LookAt(base.transform.position + vector);
			break;
		}
		case Mode.CameraForward:
			base.transform.forward = Camera.main.transform.forward;
			break;
		case Mode.CameraForwardInverted:
			base.transform.forward = -Camera.main.transform.forward;
			break;
		}
	}
}
