using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Aircraft Physics")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-aircraftcontroller.html")]
	[RequireComponent(typeof(AircraftController))]
	public sealed class AircraftPhysics : MonoBehaviour
	{
		[Tooltip("Affects how strong and, thus, how fast rotations are applied to the aircraft.")]
		[SerializeField]
		private float torque = 1f;

		[Tooltip("Defines how strong a translation force is applied to the aircraft.")]
		[SerializeField]
		private float speed = 50f;

		[Tooltip("Minimum velocity that is required for staying airborne. Lower than this, lift cannot compensate gravity.")]
		[SerializeField]
		private float minAirborneVelocity = 15f;

		[Tooltip("The 'Aircraft Controller' component that is used to calculate force and rotation values.")]
		[SerializeField]
		private AircraftController aircraftController;

		private Vector3 force;

		private Vector3 radialForce;

		private Rigidbody body;

		private Vector3 eulerAngleVelocity;

		private Vector3 translation;

		private float liftForAirborne;

		public float Torque
		{
			get
			{
				return torque;
			}
			set
			{
				torque = value;
			}
		}

		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		public float MinAirborneVelocity
		{
			get
			{
				return minAirborneVelocity;
			}
			set
			{
				minAirborneVelocity = value;
			}
		}

		public AircraftController AircraftController
		{
			get
			{
				return aircraftController;
			}
			set
			{
				aircraftController = value;
			}
		}

		private void Start()
		{
			AircraftController = GetComponent<AircraftController>();
			body = AircraftController.Body;
			body.maxAngularVelocity = 4f;
			liftForAirborne = body.mass * (0f - Physics.gravity.y);
		}

		private void FixedUpdate()
		{
			if (MinAirborneVelocity <= 0f)
			{
				MinAirborneVelocity = 0.01f;
			}
			eulerAngleVelocity = new Vector3(0f - AircraftController.Pitch, AircraftController.Yaw, AircraftController.Roll);
			eulerAngleVelocity *= Mathf.Clamp(body.velocity.magnitude / MinAirborneVelocity, 0f, 1f);
			translation = base.transform.forward * AircraftController.Force.z;
			float num = CalculateLift(new Vector2(body.velocity.x, body.velocity.z).magnitude);
			radialForce = eulerAngleVelocity * Torque * body.mass;
			force = translation * Speed * body.mass + num * base.transform.up;
			body.AddRelativeTorque(radialForce);
			body.AddForce(force);
		}

		private float CalculateLift(float velocity)
		{
			float value = velocity / MinAirborneVelocity;
			value = Mathf.Clamp(value, 0f, 1.1f);
			return liftForAirborne * value;
		}
	}
}
