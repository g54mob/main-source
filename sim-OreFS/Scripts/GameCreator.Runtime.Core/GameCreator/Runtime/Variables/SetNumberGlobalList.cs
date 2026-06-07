using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the numeric value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetNumberGlobalList : PropertyTypeSetNumber
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueNumber.TYPE_ID);

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberGlobalList());

		public override string String => m_Variable.ToString();

		public override void Set(double value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override double Get(Args args)
		{
			return (double)m_Variable.Get(args);
		}
	}
}
