using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Pose Motor")]
	public class PoseMotor : BoneControllerMotor
	{
		[Serializable]
		public class PoseMotorBone : IKBoneModifier
		{
			public bool IsEnabled;

			public Quaternion Rotation;

			public Quaternion ActualSwing;

			public Quaternion ActualTwist;

			public float RotationLerp;
		}

		public List<PoseMotorBone> _BoneInfo;

		public PoseMotor()
		{
		}

		public PoseMotor(BoneController rSkeleton)
		{
		}

		public override void ClearBones()
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		public override bool OnInspectorGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		public override bool OnSceneGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		protected override bool RenderBone(int rIndex, BoneControllerBone rBone)
		{
			return false;
		}

		public override void AddBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}

		protected override void RemoveBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}
	}
}
