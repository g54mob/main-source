using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Joint")]
	[Category("Character Joint")]
	[Image(typeof(IconJoint), ColorTheme.Type.Green)]
	[Description("Use a Character Joint component to attach to")]
	public class JointCharacter : IJoint
	{
		[SerializeField]
		private Bone m_Parent;

		[SerializeField]
		private Vector3 m_TwistAxis = Vector3.forward;

		[SerializeField]
		private Vector3 m_SwingAxis = Vector3.up;

		[SerializeField]
		private float m_LowTwistLimit;

		[SerializeField]
		private float m_HighTwistLimit;

		[SerializeField]
		private float m_LowSwingLimit;

		[SerializeField]
		private float m_HighSwingLimit;

		public JointCharacter()
		{
		}

		public JointCharacter(HumanBodyBones parent, Vector3 twist, Vector3 swing, Vector2 twistLimit, Vector2 swingLimit)
			: this()
		{
			m_Parent = new Bone(parent);
			m_TwistAxis = twist;
			m_SwingAxis = swing;
			m_LowTwistLimit = twistLimit.x;
			m_HighTwistLimit = twistLimit.y;
			m_LowSwingLimit = swingLimit.x;
			m_HighSwingLimit = swingLimit.y;
		}

		public Joint Setup(GameObject gameObject, Skeleton skeleton, Animator animator)
		{
			Transform transform = m_Parent.GetTransform(animator);
			if (transform == null)
			{
				return null;
			}
			CharacterJoint characterJoint = gameObject.Get<CharacterJoint>();
			if (characterJoint == null)
			{
				characterJoint = gameObject.Add<CharacterJoint>();
			}
			characterJoint.enableProjection = true;
			characterJoint.connectedBody = transform.gameObject.Get<Rigidbody>();
			Vector3 point = gameObject.transform.InverseTransformDirection(m_TwistAxis);
			Vector3 point2 = gameObject.transform.InverseTransformDirection(m_SwingAxis);
			characterJoint.axis = CalculateDirectionAxis(point);
			characterJoint.swingAxis = CalculateDirectionAxis(point2);
			characterJoint.lowTwistLimit = new SoftJointLimit
			{
				limit = m_LowTwistLimit
			};
			characterJoint.highTwistLimit = new SoftJointLimit
			{
				limit = m_HighTwistLimit
			};
			characterJoint.swing1Limit = new SoftJointLimit
			{
				limit = m_LowSwingLimit
			};
			characterJoint.swing2Limit = new SoftJointLimit
			{
				limit = m_HighSwingLimit
			};
			return characterJoint;
		}

		public override string ToString()
		{
			return "Character Joint";
		}

		private Vector3 CalculateDirectionAxis(Vector3 point)
		{
			CalculateDirection(point, out var direction, out var distance);
			Vector3 zero = Vector3.zero;
			if (distance > 0f)
			{
				zero[direction] = 1f;
			}
			else
			{
				zero[direction] = -1f;
			}
			return zero;
		}

		private void CalculateDirection(Vector3 point, out int direction, out float distance)
		{
			direction = 0;
			if (Mathf.Abs(point[1]) > Mathf.Abs(point[0]))
			{
				direction = 1;
			}
			if (Mathf.Abs(point[2]) > Mathf.Abs(point[direction]))
			{
				direction = 2;
			}
			distance = point[direction];
		}
	}
}
