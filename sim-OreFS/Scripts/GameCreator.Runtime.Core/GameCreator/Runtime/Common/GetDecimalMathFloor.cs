using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Floor Decimal")]
	[Category("Math/Arithmetic/Floor Decimal")]
	[Image(typeof(IconNumber), ColorTheme.Type.TextNormal, typeof(OverlayArrowDown))]
	[Description("The current integer part of a decimal value")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalMathFloor : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string String => $"Floor {m_Number}";

		public override double EditorValue => Math.Floor(m_Number.EditorValue);

		public override double Get(Args args)
		{
			return Math.Floor(m_Number.Get(args));
		}

		public override double Get(GameObject gameObject)
		{
			return Math.Floor(m_Number.Get(gameObject));
		}
	}
}
