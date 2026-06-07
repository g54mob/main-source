using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Quaternion")]
	[Category("Reflection/Property Quaternion")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Quaternion' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetRotationReflectionPropertyQuaternion : PropertyTypeGetRotation
	{
		[SerializeField]
		private ReflectionPropertyQuaternion m_Property = new ReflectionPropertyQuaternion();

		public override string String => m_Property.ToString();

		public override Quaternion Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
