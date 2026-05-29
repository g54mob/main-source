using System;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKBoneJointName("Free Swing and Twist")]
	public class FreeSwingAndTwistJoint : BoneControllerJoint
	{
		public bool _PreventSwingTwisting;

		public bool _AllowTwist;

		public bool _LimitTwist;

		public float _MinTwistAngle;

		public float _MaxTwistAngle;

		public bool PreventSwingTwisting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowTwist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LimitTwist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override float MinTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override float MaxTwistAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FreeSwingAndTwistJoint()
		{
		}

		public FreeSwingAndTwistJoint(BoneControllerBone rBone)
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

		public override bool OnInspectorManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}

		public override bool OnSceneManipulatorGUI(IKBoneModifier rModifier)
		{
			return false;
		}
	}
}
