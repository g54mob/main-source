using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	public class BoneControllerBone : IKBone, ISerializationCallbackReceiver
	{
		[NonSerialized]
		public BoneControllerJoint _Joint;

		[NonSerialized]
		protected BoneController mSkeleton;

		[NonSerialized]
		protected BoneControllerBone mParent;

		public Quaternion _ToBoneForwardInv;

		[NonSerialized]
		protected List<BoneControllerBone> mChildren;

		protected bool mIsInLimits;

		protected bool _ApplyLimits;

		protected bool _ApplyLimitsInFrame;

		public Quaternion _TargetSwing;

		public Quaternion _TargetTwist;

		private List<IKBoneModifier> mModifiers;

		private bool mIsValid;

		public string SerializationJoint;

		public bool _ShowDebug;

		private int mSelectedJointIndex;

		private static GUIContent[] sJointNames;

		private static Type[] sJointTypes;

		public override Transform Transform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BoneControllerJoint Joint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public BoneControllerBone Parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Quaternion ToBoneForward
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Quaternion ToBoneForwardInv => default(Quaternion);

		public List<BoneControllerBone> Children
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool IsInLimits => false;

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

		public virtual bool ApplyLimitsInFrame
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Quaternion TargetSwing => default(Quaternion);

		public Quaternion TargetTwist => default(Quaternion);

		public Quaternion WorldBindRotation => default(Quaternion);

		public Vector3 WorldBindPosition => default(Vector3);

		public Vector3 WorldEndPosition => default(Vector3);

		public bool ShowDebug
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BoneControllerBone()
		{
		}

		public BoneControllerBone(BoneController rSkeleton)
		{
		}

		private void InitializeBoneRotations()
		{
		}

		public override void InvalidateBones()
		{
		}

		public override void LoadBones()
		{
		}

		public BoneControllerBone GetChild(Transform rTransform)
		{
			return null;
		}

		public BoneControllerBone AddChild()
		{
			return null;
		}

		public BoneControllerBone InsertChild()
		{
			return null;
		}

		public BoneControllerBone AddChild(Transform rTransform)
		{
			return null;
		}

		private void AddChild(BoneControllerBone rChild, bool rInsert)
		{
		}

		public void RemoveChild(BoneControllerBone rChild)
		{
		}

		public override void Clear()
		{
		}

		public override void ClearRotation()
		{
		}

		public override Quaternion TransformWorldRotationToLocalRotation(Quaternion rWorldRotation)
		{
			return default(Quaternion);
		}

		public override Vector3 TransformWorldRotationToLocalRotation(Vector3 rWorldDirection)
		{
			return default(Vector3);
		}

		public Quaternion TransformWorldTwistToLocalTwist(Quaternion rWorldTwist)
		{
			return default(Quaternion);
		}

		public override Quaternion TransformLocalRotationToWorldRotation(Quaternion rLocalRotation)
		{
			return default(Quaternion);
		}

		public override Vector3 TransformLocalRotationToWorldRotation(Vector3 rLocalDirection)
		{
			return default(Vector3);
		}

		public override Vector3 TransformLocalPointToWorldPoint(Vector3 rLocalPoint)
		{
			return default(Vector3);
		}

		public override void SetWorldSwing(Quaternion rRotation, float rWeight)
		{
		}

		public override void SetWorldRotation(Vector3 rEuler, float rWeight)
		{
		}

		public override void SetWorldRotation(float rPitch, float rYaw, float rRoll, float rWeight)
		{
		}

		public override void SetWorldRotation(Quaternion rRotation, float rWeight)
		{
		}

		public override void SetWorldRotation(Quaternion rSwing, Quaternion rTwist, float rWeight)
		{
		}

		public override void SetLocalRotation(Vector3 rEuler, float rWeight)
		{
		}

		public override void SetLocalRotation(float rPitch, float rYaw, float rRoll, float rWeight)
		{
		}

		public override void SetLocalRotation(Quaternion rRotation, float rWeight)
		{
		}

		public override void SetLocalRotation(Quaternion rSwing, Quaternion rTwist, float rWeight)
		{
		}

		public override void SetWorldEndPosition(Vector3 rPosition, float rWeight)
		{
		}

		public override void SetWorldEndPosition(Vector3 rPosition, Vector3 rUp, float rWeight)
		{
		}

		public void Update()
		{
		}

		public override bool TestPointCollision(Vector3 rPoint)
		{
			return false;
		}

		public bool TestLocalPointCollision(Vector3 rLocalPoint)
		{
			return false;
		}

		public override bool TestRayCollision(Vector3 rStart, Vector3 rDirection, float rRange, out Vector3 rHitPoint)
		{
			rHitPoint = default(Vector3);
			return false;
		}

		public override Vector3 ClosetPoint(Vector3 rPoint)
		{
			return default(Vector3);
		}

		public void OnBeforeSkeletonSerialized(BoneController rSkeleton)
		{
		}

		public void OnAfterSkeletonDeserialized(BoneController rSkeleton)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual bool OnInspectorGUI(bool rIsSelected)
		{
			return false;
		}

		public bool OnSceneGUI(bool rIsSelected)
		{
			return false;
		}

		public virtual bool OnInspectorConstraintGUI(bool rIsSelected)
		{
			return false;
		}

		public virtual bool OnSceneConstraintGUI(bool rIsSelected)
		{
			return false;
		}

		public virtual bool OnInspectorManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}

		public virtual bool OnSceneManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}
	}
}
