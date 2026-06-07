using UnityEngine;

namespace FIMSpace.Basics
{
	[DefaultExecutionOrder(10000)]
	public class Fimp_JoyCamera : MonoBehaviour
	{
		public enum EControl
		{
			None = 0,
			LockCursor = 1,
			OnRMBHold = 2
		}

		public Transform FollowObject;

		public float HeightOffset = 2f;

		public float DistanceOffset = 7f;

		public float SideOffset;

		[Space(5f)]
		public Fimp_JoystickInput joystickInput;

		public Vector2 VerticalClamp = new Vector2(-40f, 40f);

		[Space(5f)]
		[Range(0f, 1f)]
		public float FollowSpeed = 0.9f;

		[Range(0f, 1f)]
		public float RotationSpeed = 0.9f;

		[Space(5f)]
		public EControl MouseControl;

		public float MouseControlSensitivity = 1f;

		private Vector3 _sd_camPos = Vector3.zero;

		private Vector2 sphericalRotation = Vector2.zero;

		private Vector2 targetSphericalRot = Vector2.zero;

		private Vector2 _sd_sphRot = Vector2.zero;

		private Vector3 followPosition = Vector3.zero;

		private bool lockCursor;

		public Vector2 SetTargetSphericalRot
		{
			get
			{
				return targetSphericalRot;
			}
			set
			{
				targetSphericalRot = value;
			}
		}

		private void Start()
		{
			if (!(FollowObject == null))
			{
				sphericalRotation = base.transform.eulerAngles;
				targetSphericalRot = sphericalRotation;
				followPosition = FollowObject.position;
			}
		}

		private void LateUpdate()
		{
			if (FollowObject == null)
			{
				return;
			}
			float num = (float)(Screen.width + Screen.height) / 2f * 0.001f;
			num = MouseControlSensitivity / num * 0.25f;
			if (MouseControl == EControl.LockCursor)
			{
				if (Cursor.visible || Cursor.lockState == CursorLockMode.None)
				{
					SwitchLockCursor(lck: false);
				}
				if (Input.GetMouseButtonDown(1))
				{
					SwitchLockCursor(lck: true);
				}
				if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Tab))
				{
					SwitchLockCursor(lck: false);
				}
				if (Cursor.lockState == CursorLockMode.Locked)
				{
					float num2 = (float)(Screen.width + Screen.height) / 2f * 0.02f * num;
					float num3 = 1f;
					float num4 = 1f;
					if ((bool)joystickInput)
					{
						num3 = joystickInput.ValuePower * joystickInput.ScaleOutput.x;
						num4 = joystickInput.ValuePower * joystickInput.ScaleOutput.y;
					}
					targetSphericalRot.x -= Input.GetAxis("Mouse Y") * num2 * num3;
					targetSphericalRot.y += Input.GetAxis("Mouse X") * num2 * num4;
				}
			}
			else if (MouseControl == EControl.OnRMBHold && (Input.GetMouseButton(1) || Input.GetMouseButton(2)))
			{
				float num5 = (float)(Screen.width + Screen.height) / 2f * 0.02f * num;
				targetSphericalRot.x -= Input.GetAxis("Mouse Y") * num5;
				targetSphericalRot.y += Input.GetAxis("Mouse X") * num5;
			}
			if ((bool)joystickInput)
			{
				targetSphericalRot.x -= joystickInput.OutputValue.y;
				targetSphericalRot.y += joystickInput.OutputValue.x;
			}
			targetSphericalRot.x = Mathf.Clamp(targetSphericalRot.x, VerticalClamp.x, VerticalClamp.y);
			if (RotationSpeed > 0.999f)
			{
				sphericalRotation = targetSphericalRot;
			}
			else
			{
				float smoothTime = Mathf.Lerp(0.2f, 0.005f, RotationSpeed);
				sphericalRotation.x = Mathf.SmoothDampAngle(sphericalRotation.x, targetSphericalRot.x, ref _sd_sphRot.x, smoothTime, 1000f, Time.unscaledDeltaTime);
				sphericalRotation.y = Mathf.SmoothDampAngle(sphericalRotation.y, targetSphericalRot.y, ref _sd_sphRot.y, smoothTime, 1000f, Time.unscaledDeltaTime);
			}
			base.transform.rotation = Quaternion.Euler(sphericalRotation.x, sphericalRotation.y, 0f);
			if (FollowSpeed > 0.999f)
			{
				followPosition = FollowObject.position;
			}
			else
			{
				followPosition = Vector3.SmoothDamp(followPosition, FollowObject.position, ref _sd_camPos, Mathf.Lerp(0.5f, 0.02f, FollowSpeed), 1000f, Time.unscaledDeltaTime);
			}
			Vector3 position = followPosition;
			position += Vector3.up * HeightOffset;
			position += base.transform.right * SideOffset;
			position -= base.transform.forward * DistanceOffset;
			base.transform.position = position;
		}

		private void SwitchLockCursor(bool lck)
		{
			if (lck != lockCursor)
			{
				lockCursor = lck;
				if (lck)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			}
		}
	}
}
