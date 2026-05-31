using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKName("Bone Chain Drag Motor")]
	[IKDescription("This motor uses a chain of bones to drag and move each bone (similiar to a tail, pony tail, or clothing).")]
	public class BoneChainDragMotor : BoneControllerMotor
	{
		[Serializable]
		public class BoneChainDragBone
		{
			public Vector3 Position;

			public Vector3 PrevPosition;

			public Vector3 Velocity;

			public bool Collision;

			public bool UseBindPosition;

			public Quaternion Rotation;

			public Quaternion RotationTarget;

			public float RotationLerp;

			public float UntwistLerp;

			public float Length;
		}

		public bool _IsGravityEnabled;

		public Vector3 _Gravity;

		public AnimationCurve _GravityImpact;

		public AnimationCurve _Stiffness;

		public bool _IsCollisionEnabled;

		public int _CollisionLayers;

		public List<BoneChainDragBone> _BoneInfo;

		private List<Transform> mBoneTransforms;

		public bool IsGravityEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 Gravity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public AnimationCurve GravityImpact
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationCurve Stiffness
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsCollisionEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int CollisionLayers
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public BoneChainDragMotor()
		{
		}

		public BoneChainDragMotor(BoneController rSkeleton)
		{
		}

		public override void ClearBones()
		{
		}

		protected override void Update(float rDeltaTime, bool rUpdate)
		{
		}

		public float GetStiffness(int rIndex)
		{
			return 0f;
		}

		public float GetGravity(int rIndex)
		{
			return 0f;
		}

		public float GetBoneChainSpan(int rIndex)
		{
			return 0f;
		}

		private bool ProcessBoneCollisions(int rIndex)
		{
			return false;
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

		private void AddBoneInfo(int rIndex, BoneControllerBone rBone)
		{
		}

		protected override void RemoveBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}
	}
}
