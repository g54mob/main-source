using System;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Internal
{
	internal static class InvocationHelper
	{
		private struct CacheKey : IEquatable<CacheKey>
		{
			public MethodInfo Method { get; }

			public Type Type { get; }

			public CacheKey(MethodInfo method, Type type)
			{
				Method = method;
				Type = type;
			}

			public bool Equals(CacheKey other)
			{
				if ((object)Method == other.Method)
				{
					return (object)Type == other.Type;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (obj is CacheKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (((Method != null) ? Method.GetHashCode() : 0) * 397) ^ ((Type != null) ? Type.GetHashCode() : 0);
			}
		}

		private static readonly SynchronizedDictionary<CacheKey, MethodInfo> cache = new SynchronizedDictionary<CacheKey, MethodInfo>();

		public static MethodInfo GetMethodOnObject(object target, MethodInfo proxiedMethod)
		{
			if (target == null)
			{
				return null;
			}
			return GetMethodOnType(target.GetType(), proxiedMethod);
		}

		public static MethodInfo GetMethodOnType(Type type, MethodInfo proxiedMethod)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			CacheKey key = new CacheKey(proxiedMethod, type);
			return cache.GetOrAdd(key, (CacheKey ck) => ObtainMethod(proxiedMethod, type));
		}

		private static MethodInfo ObtainMethod(MethodInfo proxiedMethod, Type type)
		{
			Type[] array = null;
			if (proxiedMethod.IsGenericMethod)
			{
				array = proxiedMethod.GetGenericArguments();
				proxiedMethod = proxiedMethod.GetGenericMethodDefinition();
			}
			Type declaringType = proxiedMethod.DeclaringType;
			MethodInfo methodInfo = null;
			if (declaringType.IsInterface)
			{
				InterfaceMapping interfaceMap = type.GetInterfaceMap(declaringType);
				int num = Array.IndexOf(interfaceMap.InterfaceMethods, proxiedMethod);
				methodInfo = interfaceMap.TargetMethods[num];
			}
			else
			{
				MethodInfo[] allInstanceMethods = MethodFinder.GetAllInstanceMethods(type, BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo2 in allInstanceMethods)
				{
					if (MethodSignatureComparer.Instance.Equals(methodInfo2.GetBaseDefinition(), proxiedMethod))
					{
						methodInfo = methodInfo2;
						break;
					}
				}
			}
			if (methodInfo == null)
			{
				throw new ArgumentException($"Could not find method overriding {proxiedMethod} on type {type}. This is most likely a bug. Please report it.");
			}
			if (array == null)
			{
				return methodInfo;
			}
			return methodInfo.MakeGenericMethod(array);
		}
	}
}
