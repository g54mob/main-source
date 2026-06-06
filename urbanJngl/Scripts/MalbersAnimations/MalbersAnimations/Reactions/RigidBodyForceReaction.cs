using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Unity/Rigidbody/AddForce", 0)]
	public class RigidBodyForceReaction : Reaction
	{
		public enum RB_ReactionForce
		{
			AddForce = 0,
			AddForceAtPosition = 1,
			AddExplosion = 2,
			AddTorque = 3,
			AddRelativeForce = 4,
			AddRelativeTorque = 5
		}

		public RB_ReactionForce action;

		public ForceMode mode;

		public bool useGravity = true;

		[Tooltip("Direction and Position to apply to the force")]
		public TransformReference direction = new TransformReference();

		[Tooltip("Intensity of the force to apply to the Reaction")]
		public float force = 100f;

		[Hide("action", new int[] { 2 })]
		public float radius = 10f;

		[Hide("action", new int[] { 2 })]
		public float upModifier = 5f;

		public override Type ReactionType => typeof(Rigidbody);

		protected override bool _TryReact(Component component)
		{
			Rigidbody rigidbody = component as Rigidbody;
			rigidbody.isKinematic = false;
			rigidbody.useGravity = useGravity;
			rigidbody.constraints = RigidbodyConstraints.None;
			switch (action)
			{
			case RB_ReactionForce.AddForce:
				rigidbody.AddForce(direction.Value.forward * force, mode);
				break;
			case RB_ReactionForce.AddForceAtPosition:
				rigidbody.AddForceAtPosition(direction.Value.forward * force, direction.Value.position, mode);
				break;
			case RB_ReactionForce.AddExplosion:
				rigidbody.AddExplosionForce(force, direction.Value.position, radius, upModifier, mode);
				break;
			case RB_ReactionForce.AddTorque:
				rigidbody.AddTorque(direction.Value.forward * force, mode);
				break;
			case RB_ReactionForce.AddRelativeForce:
				rigidbody.AddRelativeForce(direction.Value.forward * force, mode);
				break;
			case RB_ReactionForce.AddRelativeTorque:
				rigidbody.AddRelativeTorque(direction.Value.forward * force, mode);
				break;
			}
			return true;
		}
	}
}
