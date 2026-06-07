using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Multiply Decimal")]
	[Category("Math/Multiply Decimal")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	[Description("Calculates the product of a value to all axis of a position")]
	public class GetPositionMathProductUniform : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionSelf.Create();

		[SerializeField]
		private PropertyGetDecimal m_Scale = GetDecimalDecimal.Create(2f);

		public override string String => $"({m_Position} * {m_Scale})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Position.Get(args);
			float num = (float)m_Scale.Get(args);
			return vector * num;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionMathProductUniform());
		}
	}
}
