using System;
using System.Globalization;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Number Decimal")]
	[Category("Values/Number Decimal")]
	[Image(typeof(IconNumber), ColorTheme.Type.Blue)]
	[Description("A numeric value")]
	[Keywords(new string[] { "String", "Value", "Number", "Decimal", "Float", "Double" })]
	public class GetStringValueDecimal : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetDecimal m_Value = GetDecimalDecimal.Create(0f);

		[SerializeField]
		private string m_Format = string.Empty;

		public static PropertyGetString Create => new PropertyGetString(new GetStringValueDecimal());

		public override string String => m_Value.ToString();

		public override string EditorValue => m_Value.EditorValue.ToString(CultureInfo.InvariantCulture);

		public override string Get(Args args)
		{
			double num = m_Value.Get(args);
			if (!string.IsNullOrEmpty(m_Format))
			{
				return num.ToString(m_Format);
			}
			return num.ToString(CultureInfo.InvariantCulture);
		}
	}
}
