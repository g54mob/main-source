using System.Collections.Generic;
using UMA.Dynamics;
using UnityEngine;

namespace UMA
{
	public class UMAPhysicsSlotDefinition : MonoBehaviour
	{
		[HideInInspector]
		public int ragdollLayer;

		[HideInInspector]
		public int playerLayer;

		[Tooltip("Set this to true if you know the player will use a capsule collider and rigidbody")]
		public bool simplePlayerCollider;

		[Tooltip("Set this to have your body collider act as triggers when not ragdolled")]
		public bool enableColliderTriggers;

		[Tooltip("Set this to snap the Avatar to the position of it's hip after ragdoll is finished")]
		public bool UpdateTransformAfterRagdoll;

		[Tooltip("List of Physics Elements, see UMAPhysicsElement class")]
		public List<UMAPhysicsElement> PhysicsElements;

		public void OnSkeletonAvailable(UMAData umaData)
		{
		}
	}
}
