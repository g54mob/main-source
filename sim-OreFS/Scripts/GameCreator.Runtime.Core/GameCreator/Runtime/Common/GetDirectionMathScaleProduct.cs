using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale Product")]
	[Category("Math/Scale Product")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	[Description("Multiplies two directions component-wise")]
	public class GetDirectionMathScaleProduct : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathScaleProduct());

		public override string String => $"({m_Direction1} * {m_Direction2})";

		public override Vector3 Get(Args args)
		{
			Vector3 a = m_Direction1.Get(args);
			Vector3 b = m_Direction2.Get(args);
			return Vector3.Scale(a, b);
		}
	}
}
