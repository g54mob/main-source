using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Vector2")]
	[Category("Reflection/Field Vector2")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Vector2' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetScaleReflectionFieldVector2 : PropertyTypeGetScale
	{
		[SerializeField]
		private ReflectionFieldVector2 m_Field = new ReflectionFieldVector2();

		public override string String => m_Field.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
