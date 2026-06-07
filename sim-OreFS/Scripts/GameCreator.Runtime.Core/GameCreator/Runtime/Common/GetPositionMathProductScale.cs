using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Multiply Positions")]
	[Category("Math/Multiply Positions")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	[Description("Calculates the product of two positions component by component")]
	public class GetPositionMathProductScale : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Position1 = GetPositionSelf.Create();

		[SerializeField]
		private PropertyGetPosition m_Position2 = GetPositionTarget.Create();

		public override string String => $"({m_Position1} * {m_Position2})";

		public override Vector3 Get(Args args)
		{
			Vector3 a = m_Position1.Get(args);
			Vector3 b = m_Position2.Get(args);
			return Vector3.Scale(a, b);
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionMathProductScale());
		}
	}
}
