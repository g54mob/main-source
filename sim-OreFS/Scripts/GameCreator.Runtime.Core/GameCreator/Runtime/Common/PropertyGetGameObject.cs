using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetGameObject : TPropertyGet<PropertyTypeGetGameObject, GameObject>
	{
		public PropertyGetGameObject()
			: base((PropertyTypeGetGameObject)new GetGameObjectInstance())
		{
		}

		public PropertyGetGameObject(PropertyTypeGetGameObject defaultType)
			: base(defaultType)
		{
		}

		public T Get<T>(Args args) where T : Component
		{
			return m_Property.Get<T>(args);
		}

		public T Get<T>(GameObject target) where T : Component
		{
			return m_Property.Get<T>(target);
		}

		public T Get<T>(Component component) where T : Component
		{
			return m_Property.Get<T>(component);
		}
	}
}
