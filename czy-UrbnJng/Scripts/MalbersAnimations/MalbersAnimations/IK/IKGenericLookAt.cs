using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Generic/LookAt", 0)]
	public class IKGenericLookAt : IKProcessor
	{
		public enum UpVectorType
		{
			VectorUp = 0,
			Local = 1,
			Global = 2
		}

		public Vector3 Offset;

		public UpVectorType upVector;

		[Hide("upVector", new int[] { 1 })]
		public Vector3 LocalUp = Vector3.up;

		[Hide("upVector", new int[] { 2 })]
		public Vector3Var WorldUp;

		public override bool RequireTargets => true;

		public Vector3 UpVector(Animator anim)
		{
			return upVector switch
			{
				UpVectorType.Local => anim.transform.TransformDirection(LocalUp), 
				UpVectorType.Global => WorldUp, 
				_ => Vector3.up, 
			};
		}

		public override void Start(IKSet IKSet, Animator anim, int index)
		{
			if (index >= IKSet.Targets.Length)
			{
				Debug.LogWarning("Target index  is out of range for this processor [" + name + "] -> [" + IKSet.Owner.name + "]. Disabling Processor!");
				Active = false;
			}
			else if (IKSet.aimer == null)
			{
				Debug.LogWarning("There's no Aimer on the IK Set. Generic IK needs an Aimer");
				Active = false;
			}
		}

		public override void LateUpdate(IKSet IKSet, Animator anim, int index, float weight)
		{
			if (weight != 0f && !(IKSet.aimer.AimDirection == Vector3.zero))
			{
				Transform transform = IKSet.Targets[index];
				if (!(transform == null))
				{
					Quaternion b = Quaternion.LookRotation(IKSet.aimer.AimDirection, UpVector(anim)) * Quaternion.Euler(Offset);
					transform.rotation = Quaternion.Lerp(transform.rotation, b, weight);
				}
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (set.Targets.Length == 0)
			{
				Debug.LogWarning($"There's no Targets on the IK Set. Generic IK needs a Target on on Index [{TargetIndex}]");
			}
			if (set.Targets.Length <= TargetIndex)
			{
				Debug.LogWarning($"The Target Index [{TargetIndex}] is out of range on the IK Set. The IK Set has only {set.Targets.Length} targets");
			}
			if (set.Targets[TargetIndex].Value == null)
			{
				Debug.LogWarning($"The Target in Index [{TargetIndex}] is Empty. Make sure you set a proper value. in the Editor, or at Runtime");
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "][IK Generic Look At]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
