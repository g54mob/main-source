using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the boolean value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetBoolGlobalName : PropertyTypeSetBool
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueBool.TYPE_ID);

		public static PropertySetBool Create => new PropertySetBool(new SetBoolGlobalName());

		public override string String => m_Variable.ToString();

		public override void Set(bool value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override bool Get(Args args)
		{
			return (bool)m_Variable.Get(args);
		}
	}
}
