using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Unity/Rigidbody/Properties", 0)]
	public class RigidBodyReaction : Reaction
	{
		public enum RB_Reaction
		{
			IsKinematic = 0,
			UseGravity = 1,
			Drag = 2,
			AngularDrag = 3,
			Constraints = 4,
			Collisions = 5
		}

		public RB_Reaction action;

		[Hide("action", new int[] { 0, 1 })]
		public bool m_value = true;

		[Hide("action", new int[] { 2, 3 })]
		public float value;

		[Hide("action", new int[] { 4 })]
		public RigidbodyConstraints _value;

		[Hide("action", new int[] { 5, 0 })]
		public CollisionDetectionMode CollisionDetection;

		public override Type ReactionType => typeof(Rigidbody);

		protected override bool _TryReact(Component component)
		{
			Rigidbody rigidbody = component as Rigidbody;
			switch (action)
			{
			case RB_Reaction.IsKinematic:
				rigidbody.isKinematic = m_value;
				rigidbody.collisionDetectionMode = CollisionDetection;
				break;
			case RB_Reaction.UseGravity:
				rigidbody.useGravity = m_value;
				break;
			case RB_Reaction.Drag:
				rigidbody.drag = value;
				break;
			case RB_Reaction.AngularDrag:
				rigidbody.angularDrag = value;
				break;
			case RB_Reaction.Constraints:
				rigidbody.constraints = _value;
				break;
			case RB_Reaction.Collisions:
				rigidbody.collisionDetectionMode = CollisionDetection;
				break;
			}
			return true;
		}
	}
}
