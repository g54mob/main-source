using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CTS.Core
{
	public static class CustomInjectors
	{
		private static Dictionary<Type, IInjector> _injectors = new Dictionary<Type, IInjector>();

		private static Dictionary<Type, Type> _genericTypes = new Dictionary<Type, Type>();

		private static bool _initialized;

		private static Dictionary<int, Type[]> _constructorAllocs = new Dictionary<int, Type[]>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			Type typeFromHandle = typeof(IInjector);
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						try
						{
							if (type.IsAbstract || !typeFromHandle.IsAssignableFrom(type))
							{
								continue;
							}
							CustomInjectorAttribute customAttribute = type.GetCustomAttribute<CustomInjectorAttribute>();
							if (customAttribute == null)
							{
								continue;
							}
							if (customAttribute.Type.IsGenericType)
							{
								if (customAttribute.Type.GetGenericArguments().Length == type.GetGenericArguments().Length)
								{
									if (customAttribute.Type.IsConstructedGenericType)
									{
										CreateInjectorForType(type);
									}
									else
									{
										_genericTypes.Add(customAttribute.Type, type);
									}
								}
							}
							else
							{
								CreateInjectorForType(type);
							}
						}
						catch (Exception)
						{
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		private static Type[] GetTypeConstructorAlloc(int typeCount)
		{
			if (!_constructorAllocs.TryGetValue(typeCount, out var value))
			{
				value = new Type[typeCount];
				_constructorAllocs[typeCount] = value;
			}
			return value;
		}

		internal static bool TryGetInjector(Type type, out IInjector outInjector)
		{
			if (_injectors.TryGetValue(type, out var value))
			{
				outInjector = value;
				return true;
			}
			if (!type.IsGenericType)
			{
				outInjector = null;
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition == type || !_genericTypes.TryGetValue(genericTypeDefinition, out var value2))
			{
				outInjector = null;
				return false;
			}
			Type[] genericArguments = type.GetGenericArguments();
			try
			{
				outInjector = CreateInjectorForType(value2.MakeGenericType(genericArguments));
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				outInjector = null;
				return false;
			}
		}

		private static IInjector CreateInjectorForType(Type type)
		{
			IInjector injector = (IInjector)Activator.CreateInstance(type);
			_injectors[type] = injector;
			return injector;
		}
	}
}
