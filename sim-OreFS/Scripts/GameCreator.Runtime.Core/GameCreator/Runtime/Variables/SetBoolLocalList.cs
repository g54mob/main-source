using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the boolean value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetBoolLocalList : PropertyTypeSetBool
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueBool.TYPE_ID);

		public static PropertySetBool Create => new PropertySetBool(new SetBoolLocalList());

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
