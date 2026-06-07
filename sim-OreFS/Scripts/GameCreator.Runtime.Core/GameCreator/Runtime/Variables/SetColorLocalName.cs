using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Color value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetColorLocalName : PropertyTypeSetColor
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueColor.TYPE_ID);

		public static PropertySetColor Create => new PropertySetColor(new SetColorLocalName());

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
