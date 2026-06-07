using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Color value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetColorGlobalList : PropertyTypeSetColor
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueColor.TYPE_ID);

		public static PropertySetColor Create => new PropertySetColor(new SetColorGlobalList());

		public override string String => m_Variable.ToString();

		public override void Set(Color value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override Color Get(Args args)
		{
			return (Color)m_Variable.Get(args);
		}
	}
}
