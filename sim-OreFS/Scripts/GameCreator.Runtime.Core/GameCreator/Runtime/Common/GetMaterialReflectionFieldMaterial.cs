using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Material")]
	[Category("Reflection/Field Material")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Material' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetMaterialReflectionFieldMaterial : PropertyTypeGetMaterial
	{
		[SerializeField]
		private ReflectionFieldMaterial m_Field = new ReflectionFieldMaterial();

		public override string String => m_Field.ToString();

		public override Material Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
