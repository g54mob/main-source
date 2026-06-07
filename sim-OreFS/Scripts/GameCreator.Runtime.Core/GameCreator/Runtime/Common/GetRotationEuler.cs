using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Euler Angles")]
	[Category("Values/Euler Angles")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Description("Rotation from the euler angle of each individual axis in world space")]
	public class GetRotationEuler : PropertyTypeGetRotation
	{
		[SerializeField]
		private PropertyGetDecimal m_X = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Y = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Z = GetDecimalConstantZero.Create;

		public override string String => $"Euler ({m_X}, {m_Y}, {m_Z})";

		public override Quaternion Get(Args args)
		{
			float x = (float)m_X.Get(args);
			float y = (float)m_Y.Get(args);
			float z = (float)m_Z.Get(args);
			return Quaternion.Euler(new Vector3(x, y, z));
		}

		public GetRotationEuler()
		{
		}

		public GetRotationEuler(Vector3 angles)
		{
			m_X = GetDecimalDecimal.Create(angles.x);
			m_Y = GetDecimalDecimal.Create(angles.y);
			m_Z = GetDecimalDecimal.Create(angles.z);
		}

		public GetRotationEuler(float x, float y, float z)
		{
			m_X = GetDecimalDecimal.Create(x);
			m_Y = GetDecimalDecimal.Create(y);
			m_Z = GetDecimalDecimal.Create(z);
		}

		public GetRotationEuler(Transform transform)
			: this((transform != null) ? transform.rotation.eulerAngles : Vector3.zero)
		{
		}

		public static PropertyGetRotation Create()
		{
			return new PropertyGetRotation(new GetRotationEuler());
		}

		public static PropertyGetRotation Create(Vector3 euler)
		{
			return new PropertyGetRotation(new GetRotationEuler(euler));
		}
	}
}
