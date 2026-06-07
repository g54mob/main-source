using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("Returns the decimal value of a Global Name Variable")]
	public class GetDecimalGlobalName : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected FieldGetGlobalName m_Variable = new FieldGetGlobalName(ValueNumber.TYPE_ID);

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalGlobalName());

		public override string String => m_Variable.ToString();

		public override double Get(Args args)
		{
			return m_Variable.Get<double>(args);
		}
	}
}
