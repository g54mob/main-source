using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Configurable Joint")]
	[Category("Configurable Joint")]
	[Image(typeof(IconJoint), ColorTheme.Type.Yellow)]
	[Description("Use a Configurable Joint component to attach to")]
	public class JointConfigurable : IJoint
	{
		private const RotationDriveMode ROTATION = RotationDriveMode.Slerp;

		private const JointProjectionMode PROJECTION = JointProjectionMode.PositionAndRotation;

		private const float PROJECTION_DISTANCE = 0.5f;

		private const float PROJECTION_ANGLE = 10f;

		private const bool COLLISIONS = false;

		private const bool PREPROCESSING = false;

		[SerializeField]
		private Bone m_Parent;

		[SerializeField]
		private ConfigurableJointMotion m_LinearMotion = ConfigurableJointMotion.Free;

		[SerializeField]
		private ConfigurableJointMotion m_AngularMotion = ConfigurableJointMotion.Free;

		[SerializeField]
		private Vector3 m_PrimaryAxis = Vector3.up;

		[SerializeField]
		private Vector3 m_SecondaryAxis = Vector3.right;

		[SerializeField]
		private SpringLimit m_SpringLimitX;

		[SerializeField]
		private SpringLimit m_SpringLimitYZ;

		[SerializeField]
		private TetherLimit m_LimitXLow;

		[SerializeField]
		private TetherLimit m_LimitXHigh;

		[SerializeField]
		private TetherLimit m_LimitY;

		[SerializeField]
		private TetherLimit m_LimitZ;

		public JointConfigurable()
		{
		}

		public JointConfigurable(Bone parent, ConfigurableJointMotion linearMotion, ConfigurableJointMotion angularMotion, Vector3 primaryAxis, Vector3 secondaryAxis, SpringLimit springLimitX, SpringLimit springLimitYZ, TetherLimit limitXLow, TetherLimit limitXHigh, TetherLimit limitY, TetherLimit limitZ)
			: this()
		{
			m_Parent = parent;
			m_LinearMotion = linearMotion;
			m_AngularMotion = angularMotion;
			m_PrimaryAxis = primaryAxis;
			m_SecondaryAxis = secondaryAxis;
			m_SpringLimitX = springLimitX;
			m_SpringLimitYZ = springLimitYZ;
			m_LimitXLow = limitXLow;
			m_LimitXHigh = limitXHigh;
			m_LimitY = limitY;
			m_LimitZ = limitZ;
		}

		public Joint Setup(GameObject gameObject, Skeleton skeleton, Animator animator)
		{
			ConfigurableJoint configurableJoint = gameObject.Get<ConfigurableJoint>();
			if (configurableJoint == null)
			{
				configurableJoint = gameObject.Add<ConfigurableJoint>();
			}
			Transform transform = m_Parent.GetTransform(animator);
			if (transform != null)
			{
				configurableJoint.connectedBody = transform.gameObject.Get<Rigidbody>();
			}
			configurableJoint.autoConfigureConnectedAnchor = true;
			configurableJoint.xMotion = m_LinearMotion;
			configurableJoint.yMotion = m_LinearMotion;
			configurableJoint.zMotion = m_LinearMotion;
			configurableJoint.angularXMotion = m_AngularMotion;
			configurableJoint.angularYMotion = m_AngularMotion;
			configurableJoint.angularZMotion = m_AngularMotion;
			configurableJoint.axis = m_PrimaryAxis;
			configurableJoint.secondaryAxis = m_SecondaryAxis;
			configurableJoint.angularXLimitSpring = m_SpringLimitX.ToJoint();
			configurableJoint.angularYZLimitSpring = m_SpringLimitYZ.ToJoint();
			configurableJoint.lowAngularXLimit = m_LimitXLow.ToJoint();
			configurableJoint.highAngularXLimit = m_LimitXHigh.ToJoint();
			configurableJoint.angularYLimit = m_LimitY.ToJoint();
			configurableJoint.angularZLimit = m_LimitZ.ToJoint();
			configurableJoint.rotationDriveMode = RotationDriveMode.Slerp;
			configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			configurableJoint.projectionDistance = 0.5f;
			configurableJoint.projectionAngle = 10f;
			configurableJoint.enableCollision = false;
			configurableJoint.enablePreprocessing = false;
			return configurableJoint;
		}

		public override string ToString()
		{
			return "Configurable Joint";
		}
	}
}
