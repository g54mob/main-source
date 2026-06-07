using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Hint", 0)]
	public class HumanIKHint : IKProcessor
	{
		public AvatarIKHint hint;

		public override bool RequireTargets => false;

		public override void OnAnimatorIK(IKSet set, Animator animator, int index, float weight)
		{
			TransformReference transformReference = set.Targets[TargetIndex];
			if (transformReference != null && transformReference != null)
			{
				animator.SetIKHintPositionWeight(hint, weight);
				animator.SetIKHintPosition(hint, transformReference.position);
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (set.Targets.Length < TargetIndex)
			{
				Debug.LogError($"The IK Set <B>[{set.name}]</B> has no Transform set on the [Targets] array - Index {TargetIndex}." + $" <B>[IK Processor: {name}]</B> Needs an a value in Index [{TargetIndex}]." + " Please add a reference for that index in the [Targets] array", animator);
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "][IKHuman Hint]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
