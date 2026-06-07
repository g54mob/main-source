using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Add Directions")]
	[Category("Math/Add Directions")]
	[Image(typeof(IconPlusCircle), ColorTheme.Type.Green)]
	[Description("Calculates the sum of two directions")]
	public class GetDirectionMathSum : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathSum());

		public override string String => $"({m_Direction1} + {m_Direction2})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Direction1.Get(args);
			Vector3 vector2 = m_Direction2.Get(args);
			return vector + vector2;
		}
	}
}
