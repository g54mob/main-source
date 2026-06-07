using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Quaternion")]
	[Category("Reflection/Field Quaternion")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Quaternion' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetRotationReflectionFieldQuaternion : PropertyTypeGetRotation
	{
		[SerializeField]
		private ReflectionFieldQuaternion m_Field = new ReflectionFieldQuaternion();

		public override string String => m_Field.ToString();

		public override Quaternion Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
