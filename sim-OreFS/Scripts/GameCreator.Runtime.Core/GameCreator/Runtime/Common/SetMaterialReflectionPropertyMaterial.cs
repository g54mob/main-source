using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Material")]
	[Category("Reflection/Property Material")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Material' value of a property of a component")]
	public class SetMaterialReflectionPropertyMaterial : PropertyTypeSetMaterial
	{
		[SerializeField]
		private ReflectionPropertyMaterial m_Property = new ReflectionPropertyMaterial();

		public override string String => m_Property.ToString();

		public override void Set(Material value, Args args)
		{
			m_Property.Value = value;
		}

		public override Material Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
