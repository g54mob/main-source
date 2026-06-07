using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Bool")]
	[Category("Reflection/Property Bool")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'boolean' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	[HideLabelsInEditor(true)]
	public class GetBoolReflectionPropertyBool : PropertyTypeGetBool
	{
		[SerializeField]
		private ReflectionPropertyBool m_Property = new ReflectionPropertyBool();

		public override string String => m_Property.ToString();

		public override bool Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
