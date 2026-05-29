using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Rotation Motor")]
	[IKDescription("Rotates a bones over time.")]
	public class RotationMotor : BoneControllerMotor
	{
		[Serializable]
		public class RotationBone
		{
			public int RotationAxis;

			public Vector3 RotationSpeed;

			public Quaternion BaseRotation;

			public Vector3 Euler;

			public float Weight;

			public float RotationLerp;

			public Quaternion Rotation;

			public Quaternion RotationTarget;
		}

		public List<RotationBone> _BoneInfo;

		protected bool mIsInitialized;

		public RotationMotor()
		{
		}

		public RotationMotor(BoneController rSkeleton)
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
