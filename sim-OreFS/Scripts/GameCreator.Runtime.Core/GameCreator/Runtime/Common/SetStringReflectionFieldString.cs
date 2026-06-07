using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field String")]
	[Category("Reflection/Field String")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'string' value of a public or private field of a component")]
	public class SetStringReflectionFieldString : PropertyTypeSetString
	{
		[SerializeField]
		private ReflectionFieldString m_Field = new ReflectionFieldString();

		public override string String => m_Field.ToString();

		public override void Set(string value, Args args)
		{
			m_Field.Value = value;
		}

		public override string Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
