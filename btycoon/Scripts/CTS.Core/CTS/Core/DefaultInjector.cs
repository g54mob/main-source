using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	public static class DefaultInjector
	{
		private static readonly Type _injectorType = typeof(DefaultInjector<>);

		private static readonly Dictionary<Type, IInjector> _injectors = new Dictionary<Type, IInjector>();

		public static IInjector GetDefaultInjector(Type type)
		{
			if (!_injectors.TryGetValue(type, out var value))
			{
				if (!TypeIsCorrectGetComponentType(type))
				{
					throw new Exception("Type " + type.Name + " is not a valid injection type. It should inherit from an interface, the Component class or have a custom injector");
				}
				value = (IInjector)Activator.CreateInstance(_injectorType.MakeGenericType(type));
				_injectors[type] = value;
			}
			return value;
		}

		private static bool TypeIsCorrectGetComponentType(Type type)
		{
			if ((object)type == null)
			{
				return false;
			}
			if (type.IsInterface)
			{
				return true;
			}
			return typeof(Component).IsAssignableFrom(type);
		}
	}
	internal class DefaultInjector<T> : IInjector
	{
		private readonly Type _type = typeof(T);

		void IInjector.InjectSingle(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
			if (!forceReplace)
			{
				object value = field.GetValue(fieldTarget);
				if (value != null && !value.Equals(null))
				{
					return;
				}
			}
			field.SetValue(fieldTarget, ComponentGetter.GetComponent(sceneTarget, scope, _type, isArray: false));
		}

		void IInjector.InjectArray(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
			if (forceReplace || !(field.GetValue(fieldTarget) is Array { Length: >0 }))
			{
				field.SetValue(fieldTarget, ComponentGetter.GetComponent(sceneTarget, scope, _type, isArray: true));
			}
		}
	}
}
