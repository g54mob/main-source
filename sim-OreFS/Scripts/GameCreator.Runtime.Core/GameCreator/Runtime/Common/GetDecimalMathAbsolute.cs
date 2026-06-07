using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Absolute Number")]
	[Category("Math/Arithmetic/Absolute Number")]
	[Image(typeof(IconAbsolute), ColorTheme.Type.TextNormal)]
	[Description("The numeric value without its sign")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Sign", "Module", "Magnitude" })]
	public class GetDecimalMathAbsolute : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string String => $"|{m_Number}|";

		public override double Get(Args args)
		{
			return Math.Abs(m_Number.Get(args));
		}
	}
}
