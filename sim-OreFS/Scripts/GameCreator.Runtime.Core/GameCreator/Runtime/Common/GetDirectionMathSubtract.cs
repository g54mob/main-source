using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Subtract Directions")]
	[Category("Math/Subtract Directions")]
	[Image(typeof(IconMinusCircle), ColorTheme.Type.Green)]
	[Description("Subtracts two directions")]
	public class GetDirectionMathSubtract : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathSubtract());

		public override string String => $"({m_Direction1} - {m_Direction2})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Direction1.Get(args);
			Vector3 vector2 = m_Direction2.Get(args);
			return vector - vector2;
		}
	}
}
