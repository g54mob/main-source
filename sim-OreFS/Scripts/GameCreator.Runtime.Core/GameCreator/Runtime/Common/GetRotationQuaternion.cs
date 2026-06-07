using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Quaternion")]
	[Category("Values/Quaternion")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Description("Creates a rotation using the 4D axis of a Quaternion")]
	public class GetRotationQuaternion : PropertyTypeGetRotation
	{
		[SerializeField]
		private PropertyGetDecimal m_X = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Y = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Z = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_W = GetDecimalConstantZero.Create;

		public override string String => $"({m_X}, {m_Y}, {m_Z}, {m_W})";

		public override Quaternion Get(Args args)
		{
			float x = (float)m_X.Get(args);
			float y = (float)m_Y.Get(args);
			float z = (float)m_Z.Get(args);
			float w = (float)m_W.Get(args);
			return new Quaternion(x, y, z, w);
		}

		public GetRotationQuaternion()
		{
		}

		public GetRotationQuaternion(Quaternion quaternion)
		{
			m_X = GetDecimalDecimal.Create(quaternion.x);
			m_Y = GetDecimalDecimal.Create(quaternion.y);
			m_Z = GetDecimalDecimal.Create(quaternion.z);
			m_W = GetDecimalDecimal.Create(quaternion.w);
		}

		public GetRotationQuaternion(Transform transform)
			: this((transform != null) ? transform.rotation : Quaternion.identity)
		{
		}

		public static PropertyGetRotation Create()
		{
			return new PropertyGetRotation(new GetRotationQuaternion());
		}

		public static PropertyGetRotation Create(Quaternion quaternion)
		{
			return new PropertyGetRotation(new GetRotationQuaternion(quaternion));
		}
	}
}
