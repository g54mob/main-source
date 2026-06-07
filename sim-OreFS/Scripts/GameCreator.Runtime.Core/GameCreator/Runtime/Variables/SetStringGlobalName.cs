using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the string value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetStringGlobalName : PropertyTypeSetString
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueString.TYPE_ID);

		public static PropertySetString Create => new PropertySetString(new SetStringGlobalName());

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
