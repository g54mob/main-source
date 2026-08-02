using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Vehicle Controller")]
	[RequireComponent(typeof(VehiclePhysics))]
	public class VehicleController : MonoBehaviour
	{
		[Tooltip("The decision of this AI module is passed to VehiclePhysics as general movement (direction, acceleration).")]
		public AIMContext AimContext;

		[Tooltip("An optional AIMContext instance. If set, this vehicle will brake if the decided value is greater than 0.1f.")]
		public AIMContext AimContextForPriority;

		[Tooltip("An optional Animator that is used as state machine. Assuming that is has an int parameter named 'Change', it can be used to limit when the vehicle brakes for priority. Here, the priority brakes are active only if the value of Change is equal to -1.")]
		public Animator StateMachine;

		[Tooltip("The Rigidbody of the car.")]
		public Rigidbody Body;

		private VehiclePhysics vehiclePhysics;

		private void Awake()
		{
			vehiclePhysics = GetComponent<VehiclePhysics>();
			if (Body == null)
			{
				Body = GetComponent<Rigidbody>();
			}
			if (Body == null)
			{
				Debug.LogWarning("VehicleController is deactivated because a reference to the Body (Rigidbody) is missing.");
				base.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			float num = (AimContext.DecidedValues[0] - 0.5f) * 2f;
			float steering = 0f - Vector3.Cross(AimContext.DecidedDirection, base.transform.forward).y;
			if (num < 0f)
			{
				num = -1f;
			}
			if (AimContextForPriority != null)
			{
				bool flag = false;
				if (StateMachine != null && StateMachine.GetInteger("Change") == -1)
				{
					flag = true;
				}
				else if (StateMachine == null)
				{
					flag = true;
				}
				if (flag && AimContextForPriority != null && AimContextForPriority.DecidedValues[0] > 0.1f)
				{
					num = -1f;
				}
			}
			if (Vector3.Angle(Body.velocity, base.transform.forward) > 90f)
			{
				num = 1f;
			}
			vehiclePhysics.Move(steering, num, num);
		}
	}
}
