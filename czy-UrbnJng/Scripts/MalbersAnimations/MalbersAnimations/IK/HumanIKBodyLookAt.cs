using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Body Look At", 0)]
	public class HumanIKBodyLookAt : IKProcessor
	{
		[Header("Set LookAt Weights")]
		[Tooltip("(0-1) determines how much the body is involved in the LookAt.")]
		[Range(0f, 1f)]
		public float BodyWeight = 0.5f;

		[Tooltip("(0-1) determines how much the head is involved in the LookAt.")]
		[Range(0f, 1f)]
		public float HeadWeight = 1f;

		[Tooltip("(0-1) determines how much the eyes is involved in the LookAt.")]
		[Range(0f, 1f)]
		public float EyesWeight = 1f;

		[Tooltip("(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).")]
		[Range(0f, 1f)]
		public float ClampWeight = 0.75f;

		[Header("Extras")]
		[Tooltip("(0-1) Distance to Determine the LookAtPosition")]
		public float Distance = 50f;

		[Tooltip("Offset of the BodyLookAt")]
		public Vector2Reference offset = new Vector2Reference();

		public override bool RequireTargets => false;

		public override void Start(IKSet set, Animator anim, int index)
		{
			if (TargetIndex >= set.Targets.Length)
			{
				Array.Resize(ref set.Targets, TargetIndex + 1);
			}
			if (set.Targets[TargetIndex] == null)
			{
				set.Targets[TargetIndex] = set.aimer.AimOrigin;
			}
		}

		public override void OnAnimatorIK(IKSet set, Animator animator, int index, float weight)
		{
			if (TargetIndex < set.Targets.Length)
			{
				TransformReference transformReference = set.Targets[TargetIndex];
				if (transformReference != null)
				{
					Vector3 aimDirection = set.aimer.AimDirection;
					aimDirection = Quaternion.AngleAxis(offset.x, Vector3.up) * aimDirection;
					Vector3 axis = Vector3.Cross(aimDirection, Vector3.up);
					aimDirection = Quaternion.AngleAxis(offset.y, axis) * aimDirection;
					Vector3 point = new Ray(transformReference.position, aimDirection).GetPoint(Distance);
					Debug.DrawRay(transformReference.position, aimDirection * Distance, Color.cyan);
					animator.SetLookAtWeight(weight, BodyWeight, HeadWeight, EyesWeight, ClampWeight);
					animator.SetLookAtPosition(point);
				}
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (set.Targets.Length == 0)
			{
				Debug.LogWarning($"There's no Targets on the IK Set. Human IK needs a Target on on Index [{TargetIndex}]");
			}
			else if (set.Targets.Length <= TargetIndex)
			{
				Debug.LogWarning($"The Target Index [{TargetIndex}] is out of range on the IK Set. The IK Set has only {set.Targets.Length} targets. Target in index [{index}] used for the Aim Origin");
			}
			else if (set.aimer == null)
			{
				Debug.LogWarning("There's no Aimer on the IK Set. Human IK needs an Aimer to get the Aim Direction");
			}
			else if (set.Targets[TargetIndex] == null)
			{
				Debug.LogWarning($"Targets - Element[{TargetIndex}] on the IK Set is Null or Empty. " + "Please add a reference in the editor or at runtime.(IK Processor will be ignored)");
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "][IKHuman - BodyLookAt]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
