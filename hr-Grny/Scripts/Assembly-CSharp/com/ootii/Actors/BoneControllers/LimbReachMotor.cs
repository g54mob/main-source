using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Limb Reach Motor")]
	public class LimbReachMotor : BoneControllerMotor
	{
		[Serializable]
		public class LimbReachMotorBone
		{
			public Vector3 BendAxis;

			public float Twist;

			public Quaternion Rotation;

			public Quaternion RotationTarget;

			public float RotationLerp;

			public float Weight;
		}

		public Transform _TargetTransform;

		public string _TargetTransformName;

		public Vector3 _TargetPosition;

		public bool _UseBindRotation;

		public bool _UsePlaneNormal;

		public float _Bone2Extension;

		public List<LimbReachMotorBone> _BoneInfo;

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

		public bool UseBindRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UsePlaneNormal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Bone2Extension
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public LimbReachMotor()
		{
		}

		public LimbReachMotor(BoneController rSkeleton)
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

		public override void OnAfterSkeletonDeserialized(BoneController rSkeleton)
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
