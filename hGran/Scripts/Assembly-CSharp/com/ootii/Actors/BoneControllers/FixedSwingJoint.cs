using System;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKBoneJointName("Fixed Swing and Twist")]
	public class FixedSwingJoint : BoneControllerJoint
	{
		public Quaternion _Swing;

		public Quaternion _Twist;

		public Quaternion Swing
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Quaternion Twist
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public FixedSwingJoint()
		{
		}

		public FixedSwingJoint(BoneControllerBone rBone)
		{
		}

		public override bool ApplyLimits(ref Quaternion rSwing, ref Quaternion rTwist)
		{
			return false;
		}

		public override bool OnInspectorConstraintGUI(bool rIsSelected)
		{
			return false;
		}

		public override bool OnSceneConstraintGUI(bool rIsSelected)
		{
			return false;
		}
	}
}
