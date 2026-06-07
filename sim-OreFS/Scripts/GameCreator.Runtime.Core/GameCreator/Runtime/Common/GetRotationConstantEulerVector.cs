using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Euler Vector3")]
	[Category("Constants/Euler Vector3")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Description("Rotation from the euler angle of each individual axis in world space")]
	[HideLabelsInEditor(true)]
	public class GetRotationConstantEulerVector : PropertyTypeGetRotation
	{
		[SerializeField]
		private Vector3 m_Angles = Vector3.zero;

		public override string String => $"Euler {m_Angles}";

		public override Quaternion Get(Args args)
		{
			return Quaternion.Euler(m_Angles);
		}

		public GetRotationConstantEulerVector()
		{
		}

		public GetRotationConstantEulerVector(Vector3 angles)
		{
			m_Angles = angles;
		}

		public GetRotationConstantEulerVector(float x, float y, float z)
		{
			m_Angles = new Vector3(x, y, z);
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
