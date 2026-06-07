using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the string value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetStringLocalList : PropertyTypeSetString
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueString.TYPE_ID);

		public static PropertySetString Create => new PropertySetString(new SetStringLocalList());

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
