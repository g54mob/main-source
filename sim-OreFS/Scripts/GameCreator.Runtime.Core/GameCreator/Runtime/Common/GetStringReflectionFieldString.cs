using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field String")]
	[Category("Reflection/Field String")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'string' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetStringReflectionFieldString : PropertyTypeGetString
	{
		[SerializeField]
		private ReflectionFieldString m_Field = new ReflectionFieldString();

		public override string String => m_Field.ToString();

		public override string Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
