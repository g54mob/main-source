using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the numeric value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetNumberGlobalName : PropertyTypeSetNumber
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueNumber.TYPE_ID);

		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberGlobalName());

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
