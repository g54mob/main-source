using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Subtract Positions")]
	[Category("Math/Subtract Positions")]
	[Image(typeof(IconMinusCircle), ColorTheme.Type.Green)]
	[Description("Calculates the subtraction of two positions")]
	public class GetPositionMathSubtract : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Position1 = GetPositionSelf.Create();

		[SerializeField]
		private PropertyGetPosition m_Position2 = GetPositionTarget.Create();

		public override string String => $"({m_Position1} - {m_Position2})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Position1.Get(args);
			Vector3 vector2 = m_Position2.Get(args);
			return vector - vector2;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionMathSubtract());
		}
	}
}
