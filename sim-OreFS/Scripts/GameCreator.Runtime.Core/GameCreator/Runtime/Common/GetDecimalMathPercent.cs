using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Percentage")]
	[Category("Math/Arithmetic/Percentage")]
	[Image(typeof(IconPercent), ColorTheme.Type.TextNormal)]
	[Description("The constant percentage of a value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Ratio", "Part", "Percent" })]
	public class GetDecimalMathPercent : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetDecimal m_Number = new PropertyGetDecimal();

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Ratio = 0.75f;

		public override string String
		{
			get
			{
				float num = m_Ratio * 100f;
				return $"({num:#0}% of {m_Number})";
			}
		}

		public override double Get(Args args)
		{
			return m_Number.Get(args) * (double)m_Ratio;
		}

		public static PropertyGetDecimal Create(float percent)
		{
			return new PropertyGetDecimal(new GetDecimalMathPercent
			{
				m_Number = GetDecimalConstantOne.Create,
				m_Ratio = percent
			});
		}
	}
}
