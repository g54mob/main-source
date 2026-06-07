using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Vector3")]
	[Category("Reflection/Field Vector3")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Vector3' value of a public or private field of a component")]
	public class SetVector3ReflectionFieldVector3 : PropertyTypeSetVector3
	{
		[SerializeField]
		private ReflectionFieldVector3 m_Field = new ReflectionFieldVector3();

		public override string String => m_Field.ToString();

		public override void Set(Vector3 value, Args args)
		{
			m_Field.Value = value;
		}

		public override Vector3 Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
