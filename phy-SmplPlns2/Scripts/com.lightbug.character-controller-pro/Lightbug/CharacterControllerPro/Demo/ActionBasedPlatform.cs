using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Dynamic Platform/Action Based Platform")]
	public class ActionBasedPlatform : Platform
	{
		[SerializeField]
		protected MovementAction movementAction = new MovementAction();

		[SerializeField]
		protected RotationAction rotationAction = new RotationAction();

		private void Start()
		{
			movementAction.Initialize(base.transform);
			rotationAction.Initialize(base.transform);
		}

		private void FixedUpdate()
		{
			float deltaTime = Time.deltaTime;
			Vector3 position = base.RigidbodyComponent.Position;
			Quaternion rotation = base.RigidbodyComponent.Rotation;
			movementAction.Tick(deltaTime, ref position);
			rotationAction.Tick(deltaTime, ref position, ref rotation);
			base.RigidbodyComponent.MoveAndRotate(position, rotation);
		}
	}
}
