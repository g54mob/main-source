using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the string value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetStringLocalName : PropertyTypeSetString
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueString.TYPE_ID);

		public static PropertySetString Create => new PropertySetString(new SetStringLocalName());

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
