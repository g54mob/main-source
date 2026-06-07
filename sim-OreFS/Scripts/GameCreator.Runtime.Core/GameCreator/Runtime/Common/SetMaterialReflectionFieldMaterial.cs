using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Material")]
	[Category("Reflection/Field Material")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Material' value of a public or private field of a component")]
	public class SetMaterialReflectionFieldMaterial : PropertyTypeSetMaterial
	{
		[SerializeField]
		private ReflectionFieldMaterial m_Field = new ReflectionFieldMaterial();

		public override string String => m_Field.ToString();

		public override void Set(Material value, Args args)
		{
			m_Field.Value = value;
		}

		public override Material Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
