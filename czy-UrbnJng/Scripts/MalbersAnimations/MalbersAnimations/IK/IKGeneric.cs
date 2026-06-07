using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Generic/IK Offset Rotation", 0)]
	public class IKGeneric : IKProcessor
	{
		public enum IKRotationType
		{
			[InspectorName("Local Rotation Additive")]
			RotationAdditive = 0,
			[InspectorName("Local Rotation Override")]
			RotationOverride = 1
		}

		public IKRotationType IK;

		public Vector3 Offset;

		[Tooltip("Restore the Child bone's rotations after the IK is applied to the bone")]
		public bool KeepChildrenRotation;

		[Tooltip("Restore these extra bones rotations using target index")]
		public int[] KeepBonesInitialRotation;

		[Tooltip("Show Gizmos")]
		public bool Gizmos;

		public override bool RequireTargets => true;

		public override void LateUpdate(IKSet IKSet, Animator anim, int index, float FinalWeight)
		{
			Transform value = IKSet.Targets[index].Value;
			Quaternion b = IK switch
			{
				IKRotationType.RotationAdditive => value.rotation * Quaternion.Euler(Offset), 
				IKRotationType.RotationOverride => anim.transform.rotation * Quaternion.Euler(Offset), 
				_ => Quaternion.identity, 
			};
			value.rotation = Quaternion.Lerp(value.rotation, b, FinalWeight);
			RestoreChildRotation(IKSet);
		}

		private void RestoreChildRotation(IKSet iKSet)
		{
			for (int i = 0; i < KeepBonesInitialRotation.Length; i++)
			{
				int num = KeepBonesInitialRotation[i];
				iKSet.Targets[num].Value.rotation = iKSet.CacheTargets[num].rotation;
			}
		}

		public override void Validate(IKSet set, Animator animator, int BoneIndex)
		{
			bool flag = true;
			if (set.aimer == null)
			{
				Debug.LogWarning("There's no Aimer on the IK Set. <B>[IK Processor: " + name + "]</B> needs an Aimer to get the Aim Direction", animator);
				flag = false;
			}
			else if (set.Targets.Length < BoneIndex || set.Targets[BoneIndex] == null)
			{
				Debug.LogWarning($"The IK Set <B>[{set.name}]</B> has no Transform set on the [Targets] array - Index [{BoneIndex}]." + $" <B>[IK Processor: {name}]</B> Needs an a value in Index {BoneIndex}." + "Please add a reference for that index in the [Targets] array.", animator);
				flag = false;
			}
			if (flag)
			{
				Debug.Log("<B>[IK Processor: " + name + "][IKGeneric]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
