using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Spaceship Controller")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-spaceshipcontroller.html")]
	[DisallowMultipleComponent]
	public sealed class SpaceshipController : RpyController
	{
		private Vector3 upVector = Vector3.up;

		public Vector3 UpVector
		{
			get
			{
				return upVector;
			}
			set
			{
				upVector = value;
			}
		}

		protected override void CalculatePitch()
		{
			pitch = Mathf.Atan2(base.Context.LocalDecidedDirection.y, base.Context.LocalDecidedDirection.z) * 57.29578f;
		}

		protected override void CalculateRoll()
		{
			Vector3 vector = Quaternion.AngleAxis(SignedAngle(base.transform.up, upVector, base.transform.forward), base.transform.forward) * base.transform.right;
			Vector3 rhs = Quaternion.AngleAxis(90f, base.transform.forward) * vector;
			roll = Vector3.Angle(vector, base.transform.right);
			if (Vector3.Dot(base.transform.right, rhs) < 0f)
			{
				roll = 360f - roll;
			}
			if (roll > 180f)
			{
				roll = 360f - roll;
			}
			else if (roll < 180f)
			{
				roll = 0f - roll;
			}
		}

		protected override void CalculateYaw()
		{
			yaw = Mathf.Atan2(base.Context.LocalDecidedDirection.x, base.Context.LocalDecidedDirection.z) * 57.29578f;
		}

		protected override void CalculateForce()
		{
			force = new Vector3(0f, 0f, base.Context.DecidedMagnitude);
		}
	}
}
