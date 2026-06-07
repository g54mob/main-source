using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Human Bone Offset <Rotation>", 0)]
	public class HumanIKBoneRotation : IKProcessor
	{
		public enum RotationOffsetType
		{
			[InspectorName("Local Rotation Additive")]
			LocalAdditive = 0,
			[InspectorName("Local Rotation Override")]
			LocalOverride = 1,
			[InspectorName("Root Relative Local Rotation Additive")]
			RootRelativeRotationAdditive = 2,
			[InspectorName("Root Relative Local Rotation Override")]
			RootRelativeRotationOverride = 3,
			[InspectorName("Rotation Relative to [Target]")]
			WorldRotation = 4
		}

		public RotationOffsetType rotationType;

		[SearcheableEnum]
		public HumanBodyBones humanBone;

		[Tooltip("Rotation Offset applied to the bone")]
		public Vector3 offset;

		public bool gizmos = true;

		public override bool RequireTargets => false;

		public override void Start(IKSet IKSet, Animator anim, int index)
		{
			IKSet.Var[index].rotations.TryAdd((int)humanBone, Quaternion.identity);
		}

		public override void OnAnimatorIK(IKSet set, Animator anim, int index, float weight)
		{
			Transform transform = anim.transform;
			Transform boneTransform = anim.GetBoneTransform(humanBone);
			set.Var[index].rotations[(int)humanBone] = boneTransform.rotation;
			Quaternion quaternion = Quaternion.Euler(offset);
			Quaternion quaternion2 = Quaternion.Inverse(boneTransform.parent.rotation);
			Quaternion b = Quaternion.identity;
			switch (rotationType)
			{
			case RotationOffsetType.LocalAdditive:
				b = boneTransform.localRotation * quaternion;
				break;
			case RotationOffsetType.LocalOverride:
				b = quaternion;
				break;
			case RotationOffsetType.WorldRotation:
			{
				if (set.Targets == null || set.Targets.Length < TargetIndex || set.Targets[TargetIndex] == null)
				{
					Debug.LogWarning($"<B>[IK Processor: {name}].</B>  Target failed in {TargetIndex}");
					Active = false;
					return;
				}
				Quaternion quaternion3 = Quaternion.identity;
				TransformReference transformReference = set.Targets[TargetIndex];
				if (transformReference.Value != null)
				{
					quaternion3 = transformReference.rotation;
				}
				b = quaternion2 * quaternion3 * quaternion;
				break;
			}
			case RotationOffsetType.RootRelativeRotationOverride:
				b = quaternion2 * transform.rotation * quaternion;
				break;
			case RotationOffsetType.RootRelativeRotationAdditive:
				b = boneTransform.localRotation * transform.rotation * quaternion;
				break;
			}
			if (!float.IsNaN(b.x) && !float.IsNaN(b.y) && !float.IsNaN(b.z))
			{
				Quaternion rotation = Quaternion.Slerp(boneTransform.localRotation, b, weight);
				anim.SetBoneLocalRotation(humanBone, rotation);
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (animator.GetBoneTransform(humanBone) == null)
			{
				Debug.LogWarning($"<B>[IK Processor: {name}].</B> The Bone [{humanBone}] is not valid on the Avatar");
				return;
			}
			if (rotationType == RotationOffsetType.WorldRotation)
			{
				if (TargetIndex == -1)
				{
					Debug.LogWarning("<B>[IK Processor: " + name + "].</B>  The Target Index is -1 . Please a valid Index that can be used on the Target List");
					return;
				}
				if (set.Targets.Length <= TargetIndex)
				{
					Debug.LogWarning($"<B>[IK Processor: {name}].</B>  The Index [{TargetIndex}]  is gratere than the Target List. " + $"Please Add a Target to the Target List on the Index [{TargetIndex}]");
					return;
				}
				if (set.Targets[TargetIndex].Value == null)
				{
					Debug.LogWarning($"<B>[IK Processor: {name}].</B>  The Target Index [{TargetIndex}] is null. Please Add a valid Target to the Target List on the Index [{TargetIndex}]");
					return;
				}
			}
			Debug.Log("<B>[IK Processor: " + name + "][HumanIK Bone Rotation]</B>  <color=yellow>[OK]</color>");
		}
	}
}
