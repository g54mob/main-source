using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Core
{
	internal class PrefabReference
	{
		private readonly Dictionary<Type, List<Component>> _components = new Dictionary<Type, List<Component>>();

		internal GameObject RootObject { get; }

		internal PrefabReference(GameObject rootObject)
		{
			RootObject = rootObject;
			Component[] components = RootObject.GetComponents(typeof(Component));
			foreach (Component component in components)
			{
				Type type = component.GetType();
				_components.EnsureKeyExists(type).Add(component);
			}
		}

		internal bool TryGet(Type componentType, int index, out Component outComponent)
		{
			if (!_components.TryGetValue(componentType, out var value))
			{
				outComponent = null;
				return false;
			}
			index = index.ClampIndex(value);
			outComponent = value[index];
			return true;
		}
	}
}
