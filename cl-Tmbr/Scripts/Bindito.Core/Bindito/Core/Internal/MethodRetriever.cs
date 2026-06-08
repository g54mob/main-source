using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class MethodRetriever : IMethodRetriever
	{
		private static readonly Type InjectAttributeType = typeof(InjectAttribute);

		private readonly Dictionary<Type, ReadOnlyCollection<MethodInfo>> _injectedMethods = new Dictionary<Type, ReadOnlyCollection<MethodInfo>>();

		public IEnumerable<MethodInfo> GetInjectedMethods(Type type)
		{
			if (!_injectedMethods.TryGetValue(type, out var value))
			{
				value = GetInjectedMethodsUncached(type).ToList().AsReadOnly();
				_injectedMethods[type] = value;
			}
			return value;
		}

		private static IEnumerable<MethodInfo> GetInjectedMethodsUncached(Type type)
		{
			return type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(IsInjectedMethod);
		}

		private static bool IsInjectedMethod(MethodInfo method)
		{
			if (HasInjectAttribute(method))
			{
				return ReturnsVoid(method);
			}
			return false;
		}

		private static bool HasInjectAttribute(MethodInfo method)
		{
			return method.IsDefined(InjectAttributeType, inherit: false);
		}

		private static bool ReturnsVoid(MethodInfo method)
		{
			return method.ReturnParameter?.ParameterType == typeof(void);
		}
	}
}
