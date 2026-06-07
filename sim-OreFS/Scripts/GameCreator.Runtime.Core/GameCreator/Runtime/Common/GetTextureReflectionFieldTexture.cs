using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Texture")]
	[Category("Reflection/Field Texture")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Texture' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	[HideLabelsInEditor(true)]
	public class GetTextureReflectionFieldTexture : PropertyTypeGetTexture
	{
		[SerializeField]
		private ReflectionFieldTexture m_Field = new ReflectionFieldTexture();

		public override string String => m_Field.ToString();

		public override Texture Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
