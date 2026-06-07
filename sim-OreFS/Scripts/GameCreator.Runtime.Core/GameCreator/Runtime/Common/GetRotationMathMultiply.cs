using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Multiply Rotations")]
	[Category("Math/Multiply Rotations")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Blue)]
	[Description("Multiplies two Quaternions, which results in the sum of both rotations")]
	public class GetRotationMathMultiply : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetRotation m_Rotation1 = GetRotationIdentity.Create;

		[SerializeField]
		protected PropertyGetRotation m_Rotation2 = GetRotationEuler.Create();

		public override string String => $"{m_Rotation1} * {m_Rotation2}";

		public override Quaternion Get(Args args)
		{
			Quaternion quaternion = m_Rotation1.Get(args);
			Quaternion quaternion2 = m_Rotation2.Get(args);
			return quaternion * quaternion2;
		}

		public GetRotationMathMultiply()
		{
		}

		public GetRotationMathMultiply(PropertyGetRotation a, PropertyGetRotation b)
		{
			m_Rotation1 = a;
			m_Rotation2 = b;
		}

		public static PropertyGetRotation Create()
		{
			return new PropertyGetRotation(new GetRotationMathMultiply());
		}
	}
}
