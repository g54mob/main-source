using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Clamp Number")]
	[Category("Math/Arithmetic/Clamp Number")]
	[Image(typeof(IconAbsolute), ColorTheme.Type.TextNormal)]
	[Description("The numeric value clamped between two numbers")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Between", "Clamp", "Range" })]
	public class GetDecimalMathClamp : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number = new PropertyGetDecimal();

		[SerializeField]
		protected PropertyGetDecimal m_Min = new PropertyGetDecimal(0f);

		[SerializeField]
		protected PropertyGetDecimal m_Max = new PropertyGetDecimal(1f);

		public override string String => $"{m_Number} in [{m_Min}, {m_Max}]";

		public override double Get(Args args)
		{
			double value = m_Number.Get(args);
			double min = m_Min.Get(args);
			double max = m_Max.Get(args);
			return Math.Clamp(value, min, max);
		}
	}
}
