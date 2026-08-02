using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Spaceship Physics")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-spaceshipcontroller.html")]
	[RequireComponent(typeof(SpaceshipController))]
	public sealed class SpaceshipPhysics : MonoBehaviour
	{
		[Tooltip("Affects how strong and, thus, how fast rotations are applied to the spaceship.")]
		[SerializeField]
		private float torque = 25f;

		[Tooltip("Defines how much a translation force is applied to the spaceship.")]
		[SerializeField]
		private float speed = 1000f;

		[Tooltip("The 'Spaceship Controller' component that is used to calculate force and rotation values.")]
		[SerializeField]
		private SpaceshipController spaceshipController;

		private Vector3 eulerAngleVelocity;

		private Vector3 translation;

		private Rigidbody body;

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

		public SpaceshipController SpaceshipController
		{
			get
			{
				return spaceshipController;
			}
			set
			{
				spaceshipController = value;
			}
		}

		private void Start()
		{
			SpaceshipController = GetComponent<SpaceshipController>();
			body = SpaceshipController.Body;
			body.maxAngularVelocity = 4f;
		}

		private void FixedUpdate()
		{
			eulerAngleVelocity = new Vector3(0f - SpaceshipController.Pitch, SpaceshipController.Yaw, SpaceshipController.Roll);
			translation = base.transform.right * SpaceshipController.Force.x + base.transform.up * SpaceshipController.Force.y + base.transform.forward * SpaceshipController.Force.z;
			SpaceshipController.Body.AddRelativeTorque(eulerAngleVelocity * Torque * body.mass);
			SpaceshipController.Body.AddForce(translation * Speed * body.mass);
		}
	}
}
