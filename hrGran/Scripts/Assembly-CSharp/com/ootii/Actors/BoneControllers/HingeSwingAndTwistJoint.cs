using System;
using UnityEngine;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	[IKBoneJointName("Hinge Swing and Twist")]
	public class HingeSwingAndTwistJoint : BoneControllerJoint
	{
		public Vector3 _SwingAxis;

		public bool _PreventSwingTwisting;

		public bool _LimitSwing;

		public float _MinSwingAngle;

		public float _MaxSwingAngle;

		public bool _AllowTwist;

		public bool _LimitTwist;

		public float _MinTwistAngle;

		public float _MaxTwistAngle;

		public Vector3 SwingAxis
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

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

		public bool LimitSwing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MinSwingAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxSwingAngle
		{
			get
			{
				return 0f;
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

		public HingeSwingAndTwistJoint()
		{
		}

		public HingeSwingAndTwistJoint(BoneControllerBone rBone)
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
