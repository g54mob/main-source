using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Look At Motor")]
	[IKDescription("Use this motor to have bones rotate towards the target. Since most spine, neck, and head bones are oriented with 'bone forward' up... we have the 'bone up' look to the target.")]
	public class LookAtMotor : BoneControllerMotor
	{
		[Serializable]
		public class LookAtMotorBone
		{
			public Vector3 RotationOffset;

			public Quaternion Rotation;

			public Quaternion RotationTarget;

			public float RotationLerp;

			public float Weight;
		}

		public Transform _TargetTransform;

		public bool _UseAsDirection;

		public Vector3 _TargetPosition;

		public bool _InvertRotations;

		public List<LookAtMotorBone> _BoneInfo;

		public Transform TargetTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseAsDirection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 TargetPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool InvertRotations
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LookAtMotor()
		{
		}

		public LookAtMotor(BoneController rSkeleton)
		{
		}

		public override void ClearBones()
		{
		}

		public virtual void AutoLoadBones(string rStyle)
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		public LookAtMotorBone GetLookAtMotor(string rBoneName)
		{
			return null;
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
