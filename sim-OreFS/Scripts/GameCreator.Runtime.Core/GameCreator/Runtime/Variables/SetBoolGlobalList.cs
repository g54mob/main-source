using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the boolean value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetBoolGlobalList : PropertyTypeSetBool
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueBool.TYPE_ID);

		public static PropertySetBool Create => new PropertySetBool(new SetBoolGlobalList());

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
