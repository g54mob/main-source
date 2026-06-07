using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Scripting;

namespace CTS.Core
{
	[CustomInjector(typeof(SoftReference<>))]
	[Preserve]
	public class SoftReferenceInjector<T> : IInjector
	{
		private readonly Type _genericType = typeof(T);

		private readonly Type _iGiveType = typeof(IGive<T>);

		private readonly bool _isComponent = typeof(Component).IsAssignableFrom(typeof(T)) || typeof(T).IsInterface;

		void IInjector.InjectSingle(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
			SoftReference<T> softReference = (SoftReference<T>)field.GetValue(sceneTarget);
			if (!forceReplace && softReference.HasValue)
			{
				return;
			}
			object component;
			if (_isComponent)
			{
				component = ComponentGetter.GetComponent(sceneTarget, scope, _genericType, isArray: false);
				if (component != null)
				{
					field.SetValue(sceneTarget, new SoftReference<T>(component));
					return;
				}
			}
			component = ComponentGetter.GetComponent(sceneTarget, scope, _iGiveType, isArray: false);
			if (component != null)
			{
				field.SetValue(sceneTarget, new SoftReference<T>((IGive<object>)component));
			}
		}

		void IInjector.InjectArray(MonoBehaviour sceneTarget, object fieldTarget, FieldInfo field, EGetScope scope, bool forceReplace)
		{
		}
	}
}
