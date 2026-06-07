using FIMSpace.Basics;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(9999)]
	public class DEMO_FCameraAutoDirect : MonoBehaviour
	{
		public Fimp_JoyCamera CameraScript;

		public Fimp_JoystickInput OptionalMovementJoy;

		public float StartRotateAtVelocity = 0.1f;

		[Range(0f, 1f)]
		public float AdjustementSpeed = 0.5f;

		private Rigidbody rig;

		private Vector3 velocityOfTarget = Vector3.zero;

		private Vector3 sd_velocity = Vector3.zero;

		private Vector3 prePos = Vector3.zero;

		private Vector2 sd_angleSmooth = Vector2.zero;

		private float rotateBlend;

		private float sd_rotateBlend;

		private void Start()
		{
			if (!(CameraScript == null) && !(CameraScript.FollowObject == null))
			{
				prePos = CameraScript.FollowObject.position;
				rig = CameraScript.FollowObject.GetComponentInChildren<Rigidbody>();
			}
		}

		private void LateUpdate()
		{
			if (CameraScript == null || CameraScript.FollowObject == null)
			{
				return;
			}
			Vector3 target = ((!rig) ? (CameraScript.FollowObject.position - prePos) : rig.velocity);
			prePos = CameraScript.FollowObject.position;
			velocityOfTarget = Vector3.SmoothDamp(velocityOfTarget, target, ref sd_velocity, 1f, 10f, Time.unscaledDeltaTime);
			float target2 = 1f;
			if (OptionalMovementJoy != null && OptionalMovementJoy.OutputValue.sqrMagnitude < 0.1f)
			{
				target2 = 0f;
			}
			if (target.magnitude > StartRotateAtVelocity)
			{
				rotateBlend = Mathf.SmoothDamp(rotateBlend, target2, ref sd_rotateBlend, 0.2f, 100f, Time.unscaledDeltaTime);
			}
			else
			{
				rotateBlend = Mathf.SmoothDamp(rotateBlend, 0f, ref sd_rotateBlend, 0.2f, 100f, Time.unscaledDeltaTime);
			}
			if (rotateBlend > 0.001f)
			{
				Vector3 vector = velocityOfTarget;
				vector.y = 0f;
				if (vector != Vector3.zero)
				{
					Vector3 eulerAngles = Quaternion.LookRotation(vector).eulerAngles;
					Vector2 vector2 = new Vector2(eulerAngles.x, eulerAngles.y);
					float smoothTime = Mathf.Lerp(2f, 0.001f, AdjustementSpeed);
					Vector2 setTargetSphericalRot = CameraScript.SetTargetSphericalRot;
					setTargetSphericalRot.y = Mathf.SmoothDampAngle(setTargetSphericalRot.y, vector2.y, ref sd_angleSmooth.y, smoothTime, 1000f, Time.unscaledDeltaTime);
					setTargetSphericalRot.y = Mathf.Lerp(CameraScript.SetTargetSphericalRot.y, setTargetSphericalRot.y, rotateBlend);
					CameraScript.SetTargetSphericalRot = setTargetSphericalRot;
				}
			}
		}
	}
}
