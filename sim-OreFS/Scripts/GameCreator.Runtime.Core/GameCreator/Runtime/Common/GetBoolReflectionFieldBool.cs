using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Bool")]
	[Category("Reflection/Field Bool")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'boolean' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	[HideLabelsInEditor(true)]
	public class GetBoolReflectionFieldBool : PropertyTypeGetBool
	{
		[SerializeField]
		private ReflectionFieldBool m_Field = new ReflectionFieldBool();

		public override string String => m_Field.ToString();

		public override bool Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
