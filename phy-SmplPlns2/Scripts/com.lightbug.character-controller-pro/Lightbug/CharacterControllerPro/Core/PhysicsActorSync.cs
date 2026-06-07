using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[DefaultExecutionOrder(int.MinValue)]
	[RequireComponent(typeof(PhysicsActor))]
	public class PhysicsActorSync : MonoBehaviour
	{
		private PhysicsActor physicsActor;

		private void Awake()
		{
			physicsActor = GetComponent<PhysicsActor>();
		}

		private void FixedUpdate()
		{
			if (physicsActor.enabled)
			{
				physicsActor.SyncBody();
			}
		}
	}
}
