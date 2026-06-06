using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Human Bone Rotation <LookAt>", 0)]
	public class IKHumanBoneLookAt : IKProcessor
	{
		public enum IKRotationType
		{
			[InspectorName("Local Look At (Aim)")]
			LookAt = 0,
			LookAtUpDown = 1,
			[InspectorName("Local Rotation Additive")]
			AdditiveOffset = 2,
			[InspectorName("Local Rotation Override")]
			RotationOverride = 3
		}

		public enum UpVectorType
		{
			VectorUp = 0,
			Local = 1,
			Global = 2
		}

		[SearcheableEnum]
		public HumanBodyBones humanBone;

		[Tooltip("Rottation Offset applied to the bone")]
		public Vector3 offset;

		[Tooltip("Use the Aimer Direction to calculate the LookAt Direction")]
		[Hide("IK", new int[] { 0 })]
		public bool UseAimDirection = true;

		[Hide("IK", new int[] { 0 })]
		public UpVectorType upVector;

		[Hide("upVector", new int[] { 1 })]
		public Vector3 LocalUp = new Vector3(0f, 1f, 0f);

		[Hide("upVector", new int[] { 2 })]
		public Vector3Var WorldUp;

		[Tooltip("Show Gizmos")]
		public bool Gizmos;

		public override bool RequireTargets => false;

		public Vector3 UpVector => upVector switch
		{
			UpVectorType.Local => LocalUp, 
			UpVectorType.Global => WorldUp, 
			_ => Vector3.up, 
		};

		public override void OnAnimatorIK(IKSet set, Animator anim, int index, float weight)
		{
			Vector3 aimDirection = set.aimer.AimDirection;
			Transform boneTransform = anim.GetBoneTransform(humanBone);
			Vector3.Angle(anim.transform.forward, aimDirection);
			if (Gizmos)
			{
				MDebug.DrawRay(boneTransform.transform.position, aimDirection.normalized, Color.Lerp(Color.black, Color.green, weight));
			}
			if (weight != 0f)
			{
				Quaternion quaternion = Quaternion.Euler(offset);
				Quaternion quaternion2 = Quaternion.Inverse(boneTransform.parent.rotation);
				Quaternion localRotation = boneTransform.localRotation;
				Quaternion b = quaternion2 * Quaternion.LookRotation(aimDirection, UpVector) * quaternion;
				Quaternion rotation = Quaternion.Slerp(localRotation, b, weight);
				anim.SetBoneLocalRotation(humanBone, rotation);
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (set.aimer == null)
			{
				Debug.LogError("The IK Set <B>[" + set.name + "]</B> has no Aimer set on the [Aimer] field. <B>[IK Processor: " + name + "]</B> Needs an Aimer to work. Please add a reference for that index in the [Aimer] field", animator);
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "][IKHuman - BoneLookAt]</B>  <color=yellow>[OK]</color>");
			}
		}
	}
}
