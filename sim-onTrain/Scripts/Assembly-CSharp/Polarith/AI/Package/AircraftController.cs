using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Aircraft Controller")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-aircraftcontroller.html")]
	[DisallowMultipleComponent]
	public sealed class AircraftController : RpyController
	{
		private const float rollThreshold = 45f;

		private const float direction2Yaw = 25f;

		private float currentRoll;

		protected override void CalculatePitch()
		{
			pitch = 0f - SignedAngle(base.transform.forward, Vector3.ProjectOnPlane(base.Context.DecidedDirection, base.transform.right), base.transform.right);
		}

		protected override void CalculateRoll()
		{
			currentRoll = SignedAngle(base.transform.right, Vector3.ProjectOnPlane(base.transform.right, Vector3.up), base.transform.forward);
			if (base.transform.up.y < 0f)
			{
				currentRoll += Mathf.Sign(currentRoll) * 90f;
			}
			Vector3 vector = Vector3.ProjectOnPlane(base.Context.LocalDecidedDirection, Vector3.up);
			roll = (0f - Mathf.Atan2(vector.x, vector.z)) * 57.29578f;
			if (Mathf.Abs(roll) < 45f)
			{
				roll = currentRoll;
			}
		}

		protected override void CalculateYaw()
		{
			yaw = base.Context.LocalDecidedDirection.x * 25f;
		}

		protected override void CalculateForce()
		{
			force = new Vector3(0f, 0f, base.Context.DecidedMagnitude);
		}

		protected override void LimitControls()
		{
			if (Mathf.Abs(currentRoll + roll) > rollLimit)
			{
				roll = Mathf.Sign(roll) * rollLimit - currentRoll;
			}
			pitch = Mathf.Clamp(pitch, 0f - pitchLimit, pitchLimit);
			yaw = Mathf.Clamp(yaw, 0f - yawLimit, yawLimit);
		}

		private void Start()
		{
			rollLimit = 90f;
			pitchLimit = 90f;
			yawLimit = 40f;
		}
	}
}
