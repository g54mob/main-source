using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field GameObject")]
	[Category("Reflection/Field GameObject")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'GameObject' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetGameObjectReflectionFieldObject : PropertyTypeGetGameObject
	{
		[SerializeField]
		private ReflectionFieldGameObject m_Field = new ReflectionFieldGameObject();

		public override string String => m_Field.ToString();

		public override GameObject Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
