using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Dot Product")]
	[Category("Math/Geometry/Dot Product")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.TextNormal)]
	[Description("The dot product between two directions")]
	[Keywords(new string[] { "Orthogonal", "Perpendicular", "Multiply" })]
	public class GetDecimalMathDotProduct : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		protected PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public override string String => $"Dot [{m_Direction1}, {m_Direction2}]";

		public override double EditorValue
		{
			get
			{
				Vector3 editorValue = m_Direction1.EditorValue;
				Vector3 editorValue2 = m_Direction2.EditorValue;
				if (editorValue == Vector3.zero)
				{
					return 0.0;
				}
				if (editorValue2 == Vector3.zero)
				{
					return 0.0;
				}
				return Vector3.Dot(editorValue, editorValue2);
			}
		}

		public override double Get(Args args)
		{
			Vector3 lhs = m_Direction1.Get(args);
			Vector3 rhs = m_Direction2.Get(args);
			return Vector3.Dot(lhs, rhs);
		}
	}
}
