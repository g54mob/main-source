using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction Vector3")]
	[Category("Constants/Direction Vector3")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("Rotation from the direction vector towards a certain point in space")]
	[HideLabelsInEditor(true)]
	public class GetRotationConstantDirectionVector : PropertyTypeGetRotation
	{
		[SerializeField]
		private Vector3 m_Direction = Vector3.forward;

		public override string String => $"Direction {m_Direction}";

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Direction);
		}

		public GetRotationConstantDirectionVector()
		{
		}

		public GetRotationConstantDirectionVector(Vector3 direction)
		{
			m_Direction = direction;
		}

		public GetRotationConstantDirectionVector(float x, float y, float z)
		{
			m_Direction = new Vector3(x, y, z);
		}

		public static PropertyGetRotation Create()
		{
			return new PropertyGetRotation(new GetRotationConstantEulerVector());
		}

		public static PropertyGetRotation Create(Vector3 euler)
		{
			return new PropertyGetRotation(new GetRotationConstantEulerVector(euler));
		}
	}
}
