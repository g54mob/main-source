using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property GameObject")]
	[Category("Reflection/Property GameObject")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'GameObject' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetGameObjectReflectionPropertyObject : PropertyTypeGetGameObject
	{
		[SerializeField]
		private ReflectionPropertyGameObject m_Property = new ReflectionPropertyGameObject();

		public override string String => m_Property.ToString();

		public override GameObject Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
