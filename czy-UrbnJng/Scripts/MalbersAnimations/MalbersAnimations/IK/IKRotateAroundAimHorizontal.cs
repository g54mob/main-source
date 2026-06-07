using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Generic/Rotate Around Aim Horizontal", 0)]
	public class IKRotateAroundAimHorizontal : IKProcessor
	{
		public enum RotateAroundType
		{
			[InspectorName("Horizontal Aim (Green)")]
			Horizontal = 0,
			[InspectorName("Vertical Aim (Red)")]
			Vertical = 1
		}

		public RotateAroundType RotateAround;

		public float multiplier = 1f;

		public Vector3 Offset;

		[Tooltip("Restore the Child bone's rotations after the IK is applied to the bone")]
		public bool KeepChildRot;

		[Hide("KeepChildRot")]
		public int[] childs;

		[Tooltip("Show Gizmos")]
		public bool Gizmos;

		public override bool RequireTargets => true;

		public override void LateUpdate(IKSet IKSet, Animator anim, int index, float FinalWeight)
		{
			Transform value = IKSet.Targets[index].Value;
			if (!(value == null))
			{
				Vector3 up = anim.transform.up;
				Vector3 aimDirection = IKSet.aimer.AimDirection;
				Vector3 normalized = Vector3.Cross(up, aimDirection).normalized;
				switch (RotateAround)
				{
				case RotateAroundType.Horizontal:
					value.RotateAround(value.position, normalized, IKSet.aimer.VerticalAngle * (0f - FinalWeight));
					break;
				case RotateAroundType.Vertical:
					value.RotateAround(value.position, up, IKSet.aimer.HorizontalAngle * FinalWeight);
					break;
				}
				value.rotation *= Quaternion.Euler(Offset * FinalWeight);
				RestoreChildRotation(IKSet);
				if (Gizmos)
				{
					MDebug.Draw_Arrow(value.position, normalized * 2f, Color.red);
					MDebug.Draw_Arrow(value.position, aimDirection * 2f, Color.blue);
					MDebug.Draw_Arrow(value.position, up * 2f, Color.green);
				}
			}
		}

		private void RestoreChildRotation(IKSet iKSet)
		{
			if (KeepChildRot)
			{
				for (int i = 0; i < childs.Length; i++)
				{
					int num = childs[i];
					iKSet.Targets[num].Value.rotation = iKSet.CacheTargets[num].rotation;
				}
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

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
		}
	}
}
