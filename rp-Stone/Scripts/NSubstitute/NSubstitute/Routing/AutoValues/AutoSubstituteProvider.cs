using System;
using System.Linq;
using System.Reflection;
using NSubstitute.Core;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoSubstituteProvider : IAutoValueProvider
	{
		private readonly ISubstituteFactory _substituteFactory;

		public AutoSubstituteProvider(ISubstituteFactory substituteFactory)
		{
			_substituteFactory = substituteFactory;
		}

		public bool CanProvideValueFor(Type type)
		{
			if (!type.GetTypeInfo().IsInterface && !type.IsDelegate())
			{
				return IsPureVirtualClassWithParameterlessConstructor(type);
			}
			return true;
		}

		public object GetValue(Type type)
		{
			return _substituteFactory.Create(new Type[1] { type }, new object[0]);
		}

		private bool IsPureVirtualClassWithParameterlessConstructor(Type type)
		{
			if (type == typeof(object))
			{
				return false;
			}
			if (!type.GetTypeInfo().IsClass)
			{
				return false;
			}
			if (!IsPureVirtualType(type))
			{
				return false;
			}
			if (!HasParameterlessConstructor(type))
			{
				return false;
			}
			return true;
		}

		private bool HasParameterlessConstructor(Type type)
		{
			if (!(from x in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where IsCallableFromProxy(x) && x.GetParameters().Length == 0
				select x).Any())
			{
				return false;
			}
			return true;
		}

		private bool IsPureVirtualType(Type type)
		{
			if (type.GetTypeInfo().IsSealed)
			{
				return false;
			}
			return type.GetMethods().Where(NotMethodFromObject).Where(NotStaticMethod)
				.All(IsOverridable);
		}

		private bool IsCallableFromProxy(MethodBase constructor)
		{
			if (!constructor.IsPublic && !constructor.IsFamily)
			{
				return constructor.IsFamilyOrAssembly;
			}
			return true;
		}

		private bool IsOverridable(MethodInfo methodInfo)
		{
			if (methodInfo.IsVirtual)
			{
				return !methodInfo.IsFinal;
			}
			return false;
		}

		private bool NotMethodFromObject(MethodInfo methodInfo)
		{
			return methodInfo.DeclaringType != typeof(object);
		}

		private bool NotStaticMethod(MethodInfo methodInfo)
		{
			return !methodInfo.IsStatic;
		}
	}
}
