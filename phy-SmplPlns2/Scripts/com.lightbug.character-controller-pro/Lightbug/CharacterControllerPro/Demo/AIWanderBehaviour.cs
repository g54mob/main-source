using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/AI/Wander Behaviour")]
	public class AIWanderBehaviour : CharacterAIBehaviour
	{
		[Min(0f)]
		[SerializeField]
		private float minRandomMagnitude = 1f;

		[Min(0f)]
		[SerializeField]
		private float maxRandomMagnitude = 1f;

		[Min(0f)]
		[SerializeField]
		private float minRandomYawAngle = 100f;

		[Min(0f)]
		[SerializeField]
		private float maxRandomYawAngle = 280f;

		[Min(0f)]
		[SerializeField]
		private float waitSeconds = 3f;

		private float timer;

		private Vector3 initialPosition;

		private Vector3 target;

		private void OnValidate()
		{
			if (minRandomMagnitude > maxRandomMagnitude)
			{
				minRandomMagnitude = maxRandomMagnitude;
			}
			if (maxRandomMagnitude < minRandomMagnitude)
			{
				maxRandomMagnitude = minRandomMagnitude;
			}
			if (minRandomYawAngle > maxRandomYawAngle)
			{
				minRandomYawAngle = maxRandomYawAngle;
			}
			if (maxRandomYawAngle < minRandomYawAngle)
			{
				maxRandomYawAngle = minRandomYawAngle;
			}
		}

		public override void EnterBehaviour(float dt)
		{
			initialPosition = base.transform.position;
			target = initialPosition + base.transform.forward * Random.Range(minRandomMagnitude, maxRandomMagnitude);
			timer = 0f;
		}

		public override void UpdateBehaviour(float dt)
		{
			if (timer >= waitSeconds)
			{
				timer = 0f;
				SetTarget();
			}
			else
			{
				timer += dt;
			}
			if ((target - base.CharacterActor.Position).magnitude > 0.5f)
			{
				SetMovementAction(target - base.CharacterActor.Position);
			}
			else
			{
				characterActions.Reset();
			}
		}

		private void SetTarget()
		{
			Vector3 vector = target - initialPosition;
			vector.Normalize();
			vector = Quaternion.Euler(0f, Random.Range(minRandomYawAngle, maxRandomYawAngle), 0f) * vector;
			target = initialPosition + vector * Random.Range(minRandomMagnitude, maxRandomMagnitude);
		}
	}
}
