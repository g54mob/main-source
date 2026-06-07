using UnityEngine;

public class FreeFlyCamera : MonoBehaviour
{
	public Transform OrientationBase;

	public bool FollowMainCameraOrientation = true;

	private float _keySensitivityX = 0.5f;

	private float _keySensitivityY = 0.5f;

	private float _mHdg;

	private float _mPitch;

	private void Start()
	{
		if (OrientationBase == null)
		{
			if (FollowMainCameraOrientation)
			{
				OrientationBase = Camera.main.transform;
			}
			else
			{
				OrientationBase = base.transform;
			}
		}
		_mPitch = OrientationBase.localEulerAngles.x;
		_mHdg = OrientationBase.localEulerAngles.y;
	}

	private void Update()
	{
		if (Input.GetMouseButton(1))
		{
			base.transform.position += OrientationBase.right * Input.GetAxis("Horizontal") * _keySensitivityX;
			base.transform.position += OrientationBase.forward * Input.GetAxis("Vertical") * _keySensitivityY;
		}
	}

	private void MoveForwards(float aVal)
	{
		Vector3 forward = OrientationBase.forward;
		forward.y = 0f;
		forward.Normalize();
		base.transform.position += aVal * forward;
	}

	private void Strafe(float aVal)
	{
		base.transform.position += aVal * OrientationBase.right;
	}

	private void ChangeHeight(float aVal)
	{
		base.transform.position += aVal * Vector3.up;
	}

	private void ChangeHeading(float aVal)
	{
		_mHdg += aVal;
		WrapAngle(ref _mHdg);
		base.transform.localEulerAngles = new Vector3(_mPitch, _mHdg, 0f);
	}

	private void ChangePitch(float aVal)
	{
		_mPitch += aVal;
		WrapAngle(ref _mPitch);
		base.transform.localEulerAngles = new Vector3(_mPitch, _mHdg, 0f);
	}

	public static void WrapAngle(ref float angle)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
	}
}
