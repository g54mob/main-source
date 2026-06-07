using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Directions Angle Absolute")]
	[Category("Math/Geometry/Directions Angle Absolute")]
	[Image(typeof(IconAlpha), ColorTheme.Type.TextNormal)]
	[Description("The absolute angle (without sign) between two directions")]
	[Keywords(new string[] { "Degrees", "Radians" })]
	public class GetDecimalMathAngle : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction1 = GetDirectionSelf.Create;

		[SerializeField]
		protected PropertyGetDirection m_Direction2 = GetDirectionTarget.Create;

		public override string String => $"Angle [{m_Direction1}, {m_Direction2}]";

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
				return Vector3.Angle(editorValue, editorValue2);
			}
		}

		public override double Get(Args args)
		{
			Vector3 vector = m_Direction1.Get(args);
			Vector3 to = m_Direction2.Get(args);
			return Vector3.Angle(vector, to);
		}
	}
}
