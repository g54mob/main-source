using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Cross Product")]
	[Category("Math/Cross Product")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	[Description("Calculates the cross product between two directions")]
	public class GetDirectionMathCrossProduct : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathCrossProduct());

		public override string String => $"({m_Direction1} * {m_Direction2})";

		public override Vector3 Get(Args args)
		{
			Vector3 lhs = m_Direction1.Get(args);
			Vector3 rhs = m_Direction2.Get(args);
			return Vector3.Cross(lhs, rhs);
		}
	}
}
