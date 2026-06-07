using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the decimal value of a Local List Variable")]
	public class GetDecimalLocalList : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected FieldGetLocalList m_Variable = new FieldGetLocalList(ValueNumber.TYPE_ID);

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalLocalList());

		public override string String => m_Variable.ToString();

		public override double Get(Args args)
		{
			return m_Variable.Get<double>(args);
		}
	}
}
