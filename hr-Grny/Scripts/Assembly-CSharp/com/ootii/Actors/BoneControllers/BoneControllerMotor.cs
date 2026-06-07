using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	public class BoneControllerMotor : IKMotor
	{
		[NonSerialized]
		protected BoneController mSkeleton;

		public bool _ApplyLimits;

		protected List<BoneControllerBone> mBones;

		protected bool mIsValid;

		protected bool mIsFirstUpdate;

		protected float mPhysicsElapsedTime;

		public List<int> SerializationBoneIndexes;

		public BoneController Skeleton
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool IsEditorEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool ApplyLimits
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<BoneControllerBone> Bones
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BoneControllerMotor()
		{
		}

		public BoneControllerMotor(BoneController rSkeleton)
		{
		}

		public virtual void InvalidateBones()
		{
		}

		public virtual void ClearBones()
		{
		}

		public virtual void LoadBones()
		{
		}

		public virtual void RefreshBones()
		{
		}

		public BoneControllerBone GetBone(HumanBodyBones rBoneID)
		{
			return null;
		}

		public int GetBoneIndex(HumanBodyBones rBoneID)
		{
			return 0;
		}

		public virtual void ResetBoneRotations(bool rAllBones)
		{
		}

		public void UpdateMotor()
		{
		}

		protected virtual void Update(float rDeltaTime, bool rUpdate)
		{
		}

		public void OnBeforeSkeletonSerialized(BoneController rSkeleton)
		{
		}

		public virtual void OnAfterSkeletonDeserialized(BoneController rSkeleton)
		{
		}

		public virtual bool OnInspectorGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		public virtual bool OnSceneGUI(List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		protected bool RenderBoneList(List<BoneControllerBone> rBones, List<BoneControllerBone> rSelectedBones)
		{
			return false;
		}

		protected bool RenderBoneList(List<BoneControllerBone> rBones, List<BoneControllerBone> rSelectedBones, bool rIncludeChildren)
		{
			return false;
		}

		protected bool RenderBoneList(List<BoneControllerBone> rBones, List<BoneControllerBone> rSelectedBones, int rMaxBones)
		{
			return false;
		}

		protected bool RenderBoneList(List<BoneControllerBone> rBones, List<BoneControllerBone> rSelectedBones, bool rIncludeChildren, int rMaxBones)
		{
			return false;
		}

		protected bool RenderBoneList(List<BoneControllerBone> rBones, ref int rSelectedBoneIndex, ref BoneControllerBone rSceneSelectedBone, bool rIncludeChildren, int rMaxBones)
		{
			return false;
		}

		protected virtual bool RenderBone(int rIndex, BoneControllerBone rBone)
		{
			return false;
		}

		public virtual void AddBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}

		protected virtual void RemoveBone(int rBoneIndex, bool rIncludeChildren)
		{
		}

		protected virtual void RemoveBone(BoneControllerBone rBone, bool rIncludeChildren)
		{
		}
	}
}
