using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Range")]
	[Category("Random/Random Range")]
	[Image(typeof(IconDice), ColorTheme.Type.TextNormal)]
	[Description("A random decimal number between two values (range is inclusive)")]
	[Parameter("Min Value", "The smallest value the random operation returns")]
	[Parameter("Max Value", "The largest value the random operation returns")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalRandomRange : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetDecimal m_MinValue;

		[SerializeField]
		private PropertyGetDecimal m_MaxValue;

		public override string String => $"Random({m_MinValue}, {m_MaxValue})";

		public override double Get(Args args)
		{
			float minInclusive = (float)m_MinValue.Get(args);
			float maxInclusive = (float)m_MaxValue.Get(args);
			return UnityEngine.Random.Range(minInclusive, maxInclusive);
		}

		public GetDecimalRandomRange()
		{
			m_MinValue = GetDecimalConstantZero.Create;
			m_MaxValue = GetDecimalConstantTwo.Create;
		}

		public GetDecimalRandomRange(PropertyGetDecimal min, PropertyGetDecimal max)
		{
			m_MinValue = min;
			m_MaxValue = max;
		}

		public static PropertyGetDecimal Create()
		{
			return new PropertyGetDecimal(new GetDecimalRandomRange());
		}

		public static PropertyGetDecimal Create(PropertyGetDecimal min, PropertyGetDecimal max)
		{
			return new PropertyGetDecimal(new GetDecimalRandomRange(min, max));
		}
	}
}
