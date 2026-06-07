using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Vector2")]
	[Category("Reflection/Property Vector2")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Vector2' value of a property of a component")]
	public class SetVector3ReflectionPropertyVector2 : PropertyTypeSetVector3
	{
		[SerializeField]
		private ReflectionPropertyVector2 m_Property = new ReflectionPropertyVector2();

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
