using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Vector3")]
	[Category("Reflection/Property Vector3")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Vector3' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetScaleReflectionPropertyVector3 : PropertyTypeGetScale
	{
		[SerializeField]
		private ReflectionPropertyVector3 m_Property = new ReflectionPropertyVector3();

		public override string String => m_Property.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
