using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the decimal value of a Global List Variable")]
	public class GetDecimalGlobalList : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueNumber.TYPE_ID);

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalGlobalList());

		public override string String => m_Variable.ToString();

		public override double Get(Args args)
		{
			return m_Variable.Get<double>(args);
		}
	}
}
