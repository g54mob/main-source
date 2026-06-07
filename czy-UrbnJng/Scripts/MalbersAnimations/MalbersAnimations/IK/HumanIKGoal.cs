using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Goal", 0)]
	public class HumanIKGoal : IKProcessor
	{
		[Tooltip("Target to to lock any of the limbs ")]
		public AvatarIKGoal goal;

		public bool position = true;

		public bool rotation = true;

		[Tooltip("Min and Max Distance to the Goal to modify the weight. Id the distance is lower than the Min the weight is 1. If is greater than the max then the weight is zero")]
		public RangedFloat Distance;

		public bool gizmos = true;

		private Transform bone;

		public override bool RequireTargets => true;

		public override void Start(IKSet set, Animator animator, int index)
		{
			switch (goal)
			{
			case AvatarIKGoal.LeftFoot:
				bone = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
				break;
			case AvatarIKGoal.RightFoot:
				bone = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
				break;
			case AvatarIKGoal.LeftHand:
				bone = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				break;
			case AvatarIKGoal.RightHand:
				bone = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
				break;
			}
		}

		public override void OnAnimatorIK(IKSet set, Animator animator, int index, float weight)
		{
			TransformReference transformReference = set.Targets[TargetIndex];
			if (transformReference == null)
			{
				return;
			}
			if (Distance.Min != 0f && Distance.Max != 0f)
			{
				float value = Vector3.Distance(bone.position, transformReference.position);
				weight *= value.CalculateRangeWeight(Distance.Min, Distance.Max);
				if (gizmos)
				{
					Vector3 normalized = (transformReference.position - bone.position).normalized;
					MDebug.DrawRay(bone.position, normalized * Distance.Max, Color.gray);
					MDebug.DrawRay(bone.position, normalized * Distance.Min, Color.green);
				}
			}
			if (position)
			{
				animator.SetIKPositionWeight(goal, weight);
				animator.SetIKPosition(goal, transformReference.position);
			}
			if (rotation)
			{
				animator.SetIKRotationWeight(goal, weight);
				animator.SetIKRotation(goal, transformReference.rotation);
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
				Debug.Log("<B>[IK Processor: " + name + "][HumanIK Goal]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
