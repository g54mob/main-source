using System.Collections;
using System.Collections.Generic;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Dynamic One Way Platform")]
	public class DynamicOneWayPlatform : MonoBehaviour
	{
		public LayerMask characterLayerMask = -1;

		protected Vector3 preSimulationPosition;

		private Coroutine postSimulationUpdateCoroutine;

		protected Dictionary<Transform, CharacterActor> characters = new Dictionary<Transform, CharacterActor>();

		private ColliderComponent colliderComponent;

		private PhysicsComponent physicsComponent;

		private RigidbodyComponent rigidbodyComponent;

		private void Awake()
		{
			colliderComponent = ColliderComponent.CreateInstance(base.gameObject);
			physicsComponent = PhysicsComponent.CreateInstance(base.gameObject);
			rigidbodyComponent = RigidbodyComponent.CreateInstance(base.gameObject);
		}

		private void OnEnable()
		{
			if (postSimulationUpdateCoroutine == null)
			{
				postSimulationUpdateCoroutine = StartCoroutine(PostSimulationUpdate());
			}
		}

		private void OnDisable()
		{
			if (postSimulationUpdateCoroutine != null)
			{
				StopCoroutine(PostSimulationUpdate());
				postSimulationUpdateCoroutine = null;
			}
		}

		protected List<HitInfo> CastPlatformBody(Vector3 castDisplacement)
		{
			float num = 0.1f;
			float num2 = 0f;
			Vector3 normalized = castDisplacement.normalized;
			castDisplacement += num * num2 * normalized;
			Vector3 center = preSimulationPosition + colliderComponent.Offset - normalized * num;
			HitInfoFilter filter = new HitInfoFilter(characterLayerMask, ignoreRigidbodies: false, ignoreTriggers: true);
			return physicsComponent.BoxCast(center, colliderComponent.BoundsSize - Vector3.one * num2, castDisplacement, rigidbodyComponent.Rotation, in filter);
		}

		protected bool ValidateOWPCollision(CharacterActor characterActor, Vector3 contactPoint)
		{
			return characterActor.CheckOneWayPlatformCollision(contactPoint, characterActor.Position);
		}

		private void FixedUpdate()
		{
			preSimulationPosition = rigidbodyComponent.Position;
		}

		private IEnumerator PostSimulationUpdate()
		{
			YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				yield return waitForFixedUpdate;
				UpdatePlatform();
			}
		}

		private void UpdatePlatform()
		{
			Vector3 castDisplacement = rigidbodyComponent.Position - preSimulationPosition;
			List<HitInfo> list = CastPlatformBody(castDisplacement);
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				HitInfo hitInfo = physicsComponent.HitsBuffer[i];
				if (hitInfo.distance == 0f)
				{
					continue;
				}
				CharacterActor orRegisterValue = characters.GetOrRegisterValue(hitInfo.transform);
				if (!(orRegisterValue == null))
				{
					physicsComponent.IgnoreCollision(in hitInfo, ignore: true);
					if (!orRegisterValue.IsGrounded && ValidateOWPCollision(orRegisterValue, hitInfo.point))
					{
						Vector3 vector = castDisplacement.normalized * (castDisplacement.magnitude - hitInfo.distance);
						Vector3 destination = orRegisterValue.Position + vector;
						orRegisterValue.SweepAndTeleport(destination, new HitInfoFilter(orRegisterValue.ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: false, ignoreTriggers: true));
						orRegisterValue.ForceGrounded();
					}
				}
			}
		}
	}
}
