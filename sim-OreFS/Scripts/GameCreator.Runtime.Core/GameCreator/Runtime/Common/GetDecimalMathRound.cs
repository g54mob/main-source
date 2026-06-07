using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Round Decimal")]
	[Category("Math/Arithmetic/Round Decimal")]
	[Image(typeof(IconNumber), ColorTheme.Type.TextNormal, typeof(OverlayDot))]
	[Description("The closest integer part of a decimal value")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalMathRound : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string String => $"Round {m_Number}";

		public override double EditorValue => Math.Round(m_Number.EditorValue);

		public override double Get(Args args)
		{
			return Math.Round(m_Number.Get(args));
		}

		public override double Get(GameObject gameObject)
		{
			return Math.Round(m_Number.Get(gameObject));
		}
	}
}
