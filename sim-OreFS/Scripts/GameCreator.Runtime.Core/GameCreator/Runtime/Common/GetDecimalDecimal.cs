using System;
using System.Globalization;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Decimal")]
	[Category("Decimal")]
	[Image(typeof(IconNumber), ColorTheme.Type.TextNormal)]
	[Description("A constant decimal number")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	[HideLabelsInEditor(true)]
	public class GetDecimalDecimal : PropertyTypeGetDecimal
	{
		private const string STRING_FMT = "0.##";

		[SerializeField]
		protected double m_Value;

		public override double EditorValue => m_Value;

		public override string String => m_Value.ToString("0.##", CultureInfo.InvariantCulture);

		public override double Get(Args args)
		{
			return m_Value;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetDecimalDecimal()
		{
		}

		public GetDecimalDecimal(double value)
			: this()
		{
			m_Value = value;
		}

		public GetDecimalDecimal(float value)
			: this()
		{
			m_Value = value;
		}

		public static PropertyGetDecimal Create(float value = 0f)
		{
			return new PropertyGetDecimal(new GetDecimalDecimal(value));
		}

		public static PropertyGetDecimal Create(double value = 0.0)
		{
			return new PropertyGetDecimal(new GetDecimalDecimal(value));
		}
	}
}
