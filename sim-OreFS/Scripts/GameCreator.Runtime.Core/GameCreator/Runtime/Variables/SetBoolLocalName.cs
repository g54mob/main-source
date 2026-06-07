using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the boolean value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetBoolLocalName : PropertyTypeSetBool
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueBool.TYPE_ID);

		public static PropertySetBool Create => new PropertySetBool(new SetBoolLocalName());

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
