using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the String value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetStringGlobalList : PropertyTypeSetString
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueString.TYPE_ID);

		public static PropertySetString Create => new PropertySetString(new SetStringGlobalList());

		public override string String => m_Variable.ToString();

		public override void Set(string value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override string Get(Args args)
		{
			return m_Variable.Get(args).ToString();
		}
	}
}
