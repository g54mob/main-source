using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property GameObject")]
	[Category("Reflection/Property GameObject")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'GameObject' value of a property of a component")]
	public class SetGameObjectReflectionPropertyGameObject : PropertyTypeSetGameObject
	{
		[SerializeField]
		private ReflectionPropertyGameObject m_Property = new ReflectionPropertyGameObject();

		public override string String => m_Property.ToString();

		public override void Set(GameObject value, Args args)
		{
			m_Property.Value = value;
		}

		public override GameObject Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
