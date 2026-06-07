using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Vector3")]
	[Category("Reflection/Property Vector3")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Vector3' value of a property of a component")]
	public class SetVector3ReflectionPropertyVector3 : PropertyTypeSetVector3
	{
		[SerializeField]
		private ReflectionPropertyVector3 m_Property = new ReflectionPropertyVector3();

		public override string String => m_Property.ToString();

		public override void Set(Vector3 value, Args args)
		{
			m_Property.Value = value;
		}

		public override Vector3 Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
