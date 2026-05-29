using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	internal class TypeInjector
	{
		private abstract class FieldInjector
		{
			protected readonly FieldInfo _field;

			protected readonly bool _forceReplace;

			protected readonly EGetScope _scope;

			protected readonly IInjector _injector;

			protected FieldInjector(FieldInfo field, bool forceReplace, EGetScope scope, IInjector injector)
			{
				_field = field;
				_forceReplace = forceReplace;
				_scope = scope;
				_injector = injector;
			}

			public abstract void Inject(MonoBehaviour target);
		}

		private class FieldSimpleInjector : FieldInjector
		{
			public FieldSimpleInjector(FieldInfo field, bool forceReplace, EGetScope scope, IInjector injector)
				: base(field, forceReplace, scope, injector)
			{
			}

			public override void Inject(MonoBehaviour target)
			{
				_injector.InjectSingle(target, target, _field, _scope, _forceReplace);
			}
		}

		private class FieldArrayInjector : FieldInjector
		{
			public FieldArrayInjector(FieldInfo field, bool forceReplace, EGetScope scope, IInjector injector)
				: base(field, forceReplace, scope, injector)
			{
			}

			public override void Inject(MonoBehaviour target)
			{
				_injector.InjectArray(target, target, _field, _scope, _forceReplace);
			}
		}

		private readonly List<Constructor> _constructorQueue = new List<Constructor>();

		private readonly List<TypeInjector> _injectionQueue = new List<TypeInjector>();

		private readonly HashSet<FieldInjector> _fieldInjectors = new HashSet<FieldInjector>();

		private readonly Constructor _constructor;

		public int ExecutionOrder { get; }

		public TypeInjector(Type type)
		{
			ExecutionOrder = type.GetCustomAttribute<DefaultExecutionOrder>()?.order ?? 0;
			_constructor = CreateConstructor(type);
			if (_constructor != null)
			{
				_constructorQueue.Add(_constructor);
			}
			CreateFieldInjectors(type);
			if (_fieldInjectors.Count > 0)
			{
				_injectionQueue.Add(this);
			}
			Type baseType = type.BaseType;
			while ((object)baseType != null && typeof(CTSBehaviour).IsAssignableFrom(baseType))
			{
				TypeInjector orCreateInjector = CTSFactory.GetOrCreateInjector(baseType);
				if (orCreateInjector._fieldInjectors.Count > 0)
				{
					_injectionQueue.Add(orCreateInjector);
				}
				if (orCreateInjector._constructor != null)
				{
					_constructorQueue.Add(orCreateInjector._constructor);
				}
				baseType = baseType.BaseType;
			}
			_injectionQueue.Reverse();
			_constructorQueue.Reverse();
			List<Type> list = new List<Type>();
			for (int i = 0; i < _constructorQueue.Count; i++)
			{
				Type declaringType = _constructorQueue[i].MethodInfo.GetBaseDefinition().DeclaringType;
				if ((object)declaringType == null || list.Contains(declaringType))
				{
					_constructorQueue.RemoveAt(i);
					i--;
				}
				else
				{
					list.Add(declaringType);
				}
			}
		}

		private static Constructor CreateConstructor(Type type)
		{
			ConstructorAttribute customAttribute = type.GetCustomAttribute<ConstructorAttribute>();
			if (customAttribute == null)
			{
				return null;
			}
			MethodInfo method = type.GetMethod(customAttribute.MethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)method == null)
			{
				Debug.LogError("Couldn't find constructor " + customAttribute.MethodName);
				return null;
			}
			EGetScope item = EGetScope.Object;
			List<(EGetScope, Type)> list = new List<(EGetScope, Type)>();
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				Type type2 = (parameterInfo.ParameterType.IsArray ? parameterInfo.ParameterType.GetElementType() : parameterInfo.ParameterType);
				if ((object)type2 == null || (!typeof(Component).IsAssignableFrom(type2) && !type2.IsInterface))
				{
					Debug.LogError(type.Name + ": Constructor invalid. Only Component parameters are valid.");
					return null;
				}
				InjectScopeAttribute customAttribute2 = parameterInfo.GetCustomAttribute<InjectScopeAttribute>();
				if (customAttribute2 != null)
				{
					item = customAttribute2.Scope;
				}
				list.Add((item, parameterInfo.ParameterType));
			}
			return new Constructor(list, method);
		}

		private void CreateFieldInjectors(Type type)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			EGetScope scope = EGetScope.Object;
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				InjectScopeAttribute customAttribute = fieldInfo.GetCustomAttribute<InjectScopeAttribute>();
				if (customAttribute != null)
				{
					scope = customAttribute.Scope;
				}
				InjectAttribute customAttribute2 = fieldInfo.GetCustomAttribute<InjectAttribute>();
				if (customAttribute2 == null)
				{
					continue;
				}
				Type fieldType = fieldInfo.FieldType;
				if (fieldType.IsArray && !fieldType.IsSZArray)
				{
					Debug.LogError("Injection doesn't support multi dimensional arrays");
					continue;
				}
				Type type2 = (fieldType.IsArray ? fieldType.GetElementType() : fieldType);
				if ((object)type2 != null)
				{
					IInjector injector;
					try
					{
						injector = GetInjector(type2);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						continue;
					}
					if (fieldType.IsArray)
					{
						_fieldInjectors.Add(new FieldArrayInjector(fieldInfo, customAttribute2.ForceReplace, scope, injector));
					}
					else
					{
						_fieldInjectors.Add(new FieldSimpleInjector(fieldInfo, customAttribute2.ForceReplace, scope, injector));
					}
				}
			}
		}

		internal static IInjector GetInjector(Type elementType)
		{
			if (CustomInjectors.TryGetInjector(elementType, out var outInjector))
			{
				return outInjector;
			}
			return DefaultInjector.GetDefaultInjector(elementType);
		}

		public void Construct(CTSBehaviour target)
		{
			foreach (Constructor item in _constructorQueue)
			{
				try
				{
					item.Invoke(target);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			target.Constructed = true;
		}

		public void InjectFields(CTSBehaviour target)
		{
			foreach (TypeInjector item in _injectionQueue)
			{
				foreach (FieldInjector fieldInjector in item._fieldInjectors)
				{
					fieldInjector.Inject(target);
				}
			}
		}
	}
}
