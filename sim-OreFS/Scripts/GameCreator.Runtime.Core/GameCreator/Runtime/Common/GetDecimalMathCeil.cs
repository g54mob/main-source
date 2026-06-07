using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Ceil Decimal")]
	[Category("Math/Arithmetic/Ceil Decimal")]
	[Image(typeof(IconNumber), ColorTheme.Type.TextNormal, typeof(OverlayArrowUp))]
	[Description("The next integer part of a decimal value")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalMathCeil : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string String => $"Ceil {m_Number}";

		public override double EditorValue => Math.Ceiling(m_Number.EditorValue);

		public override double Get(Args args)
		{
			return Math.Ceiling(m_Number.Get(args));
		}

		public override double Get(GameObject gameObject)
		{
			return Math.Ceiling(m_Number.Get(gameObject));
		}
	}
}
