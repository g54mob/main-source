using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Integer")]
	[Category("Integer")]
	[Image(typeof(IconNumber), ColorTheme.Type.TextNormal)]
	[Description("A constant integer number")]
	[HideLabelsInEditor(true)]
	public class GetDecimalInteger : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected int m_Value;

		public override string String => m_Value.ToString();

		public override double EditorValue => m_Value;

		public override double Get(Args args)
		{
			return m_Value;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetDecimalInteger()
		{
		}

		public GetDecimalInteger(int value)
			: this()
		{
			m_Value = value;
		}

		public static PropertyGetInteger Create(int value)
		{
			return new PropertyGetInteger(new GetDecimalInteger(value));
		}
	}
}
