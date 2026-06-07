using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Directions Angle Signed")]
	[Category("Math/Geometry/Directions Angle Signed")]
	[Image(typeof(IconAlpha), ColorTheme.Type.TextNormal, typeof(OverlayDot))]
	[Description("The signed angle between two directions")]
	[Keywords(new string[] { "Degrees", "Radians" })]
	public class GetDecimalMathAngleSigned : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		protected PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		[SerializeField]
		private PropertyGetDirection m_Axis = GetDirectionConstantUp.Create;

		public override string String => $"Angle [{m_Direction1}, {m_Direction2}]";

		public override double EditorValue
		{
			get
			{
				Vector3 editorValue = m_Direction1.EditorValue;
				Vector3 editorValue2 = m_Direction2.EditorValue;
				Vector3 editorValue3 = m_Axis.EditorValue;
				if (editorValue == Vector3.zero)
				{
					return 0.0;
				}
				if (editorValue2 == Vector3.zero)
				{
					return 0.0;
				}
				if (editorValue3 == Vector3.zero)
				{
					return 0.0;
				}
				return Vector3.SignedAngle(editorValue, editorValue2, editorValue3);
			}
		}

		public override double Get(Args args)
		{
			Vector3 vector = m_Direction1.Get(args);
			Vector3 to = m_Direction2.Get(args);
			Vector3 axis = m_Axis.Get(args);
			return Vector3.SignedAngle(vector, to, axis);
		}
	}
}
