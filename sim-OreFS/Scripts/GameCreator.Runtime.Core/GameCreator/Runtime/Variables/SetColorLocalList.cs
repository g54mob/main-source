using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Color value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetColorLocalList : PropertyTypeSetColor
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueColor.TYPE_ID);

		public static PropertySetColor Create => new PropertySetColor(new SetColorLocalList());

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
