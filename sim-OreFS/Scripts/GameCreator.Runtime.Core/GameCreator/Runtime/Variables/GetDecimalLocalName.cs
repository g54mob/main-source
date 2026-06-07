using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the decimal value of a Local Name Variable")]
	public class GetDecimalLocalName : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueNumber.TYPE_ID);

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalLocalName());

		public override string String => m_Variable.ToString();

		public override double Get(Args args)
		{
			return m_Variable.Get<double>(args);
		}
	}
}
