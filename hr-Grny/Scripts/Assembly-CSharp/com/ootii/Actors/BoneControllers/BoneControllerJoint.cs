using System;
using UnityEngine;
using com.ootii.Base;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	public class BoneControllerJoint : BaseObject
	{
		[NonSerialized]
		protected BoneControllerBone mBone;

		public Vector3 _UpAxis;

		private static GUIStyle sRowStyle;

		private static GUIStyle sSelectedRowStyle;

		private static Texture sItemSelector;

		public BoneControllerBone Bone
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 UpAxis
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public virtual float MinTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float MaxTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static GUIStyle RowStyle => null;

		public static GUIStyle SelectedRowStyle => null;

		public static Texture ItemSelector => null;

		public BoneControllerJoint()
		{
		}

		public BoneControllerJoint(BoneControllerBone rBone)
		{
		}

		public virtual void Initialize(BoneControllerBone rBone)
		{
		}

		public virtual float GetTwistStress()
		{
			return 0f;
		}

		public virtual float GetTwistStress(Quaternion rLocalTwist)
		{
			return 0f;
		}

		public virtual void ApplyLimits(ref Quaternion rRotation)
		{
		}

		public virtual bool ApplyLimits(ref Quaternion rSwing, ref Quaternion rTwist)
		{
			return false;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
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
