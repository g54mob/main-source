using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TNRD
{
	public static class Extensions
	{
		public static bool IsDefined<TInterface>(this SerializableInterface<TInterface> serializableInterface, out TInterface value) where TInterface : class
		{
			if (serializableInterface == null)
			{
				value = null;
				return false;
			}
			if (EqualityComparer<TInterface>.Default.Equals(serializableInterface.Value, null))
			{
				value = null;
				return false;
			}
			value = serializableInterface.Value;
			return true;
		}

		public static bool TryGetValue<TInterface>(this SerializableInterface<TInterface> serializableInterface, out TInterface value) where TInterface : class
		{
			return serializableInterface.IsDefined(out value);
		}

		public static List<SerializableInterface<T>> ToSerializableInterfaceList<T>(this IEnumerable<T> list) where T : class
		{
			return list.Select((T e) => new SerializableInterface<T>(e)).ToList();
		}

		public static SerializableInterface<T>[] ToSerializableInterfaceArray<T>(this IEnumerable<T> list) where T : class
		{
			return list.Select((T e) => new SerializableInterface<T>(e)).ToArray();
		}

		public static TInterface Instantiate<TInterface>(this SerializableInterface<TInterface> serializableInterface) where TInterface : class
		{
			if (!serializableInterface.TryGetObject(out var unityObject))
			{
				throw new Exception($"Cannot instantiate {serializableInterface} because it's has no reference of type UnityEngine.Object");
			}
			return GetInterfaceReference<TInterface>(UnityEngine.Object.Instantiate(unityObject));
		}

		public static TInterface Instantiate<TInterface>(this SerializableInterface<TInterface> serializableInterface, Transform parent) where TInterface : class
		{
			if (!serializableInterface.TryGetObject(out var unityObject))
			{
				throw new Exception($"Cannot instantiate {serializableInterface} because it's has no reference of type UnityEngine.Object");
			}
			return GetInterfaceReference<TInterface>(UnityEngine.Object.Instantiate(unityObject, parent));
		}

		public static TInterface Instantiate<TInterface>(this SerializableInterface<TInterface> serializableInterface, Vector3 position, Quaternion rotation) where TInterface : class
		{
			if (!serializableInterface.TryGetObject(out var unityObject))
			{
				throw new Exception($"Cannot instantiate {serializableInterface} because it's has no reference of type UnityEngine.Object");
			}
			return GetInterfaceReference<TInterface>(UnityEngine.Object.Instantiate(unityObject, position, rotation));
		}

		public static TInterface Instantiate<TInterface>(this SerializableInterface<TInterface> serializableInterface, Vector3 position, Quaternion rotation, Transform parent) where TInterface : class
		{
			if (!serializableInterface.TryGetObject(out var unityObject))
			{
				throw new Exception($"Cannot instantiate {serializableInterface} because it's has no reference of type UnityEngine.Object");
			}
			return GetInterfaceReference<TInterface>(UnityEngine.Object.Instantiate(unityObject, position, rotation, parent));
		}

		private static TInterface GetInterfaceReference<TInterface>(UnityEngine.Object instantiatedObject) where TInterface : class
		{
			if (instantiatedObject is GameObject gameObject)
			{
				if (!gameObject.TryGetComponent<TInterface>(out var component))
				{
					return null;
				}
				return component;
			}
			return instantiatedObject as TInterface;
		}
	}
}
