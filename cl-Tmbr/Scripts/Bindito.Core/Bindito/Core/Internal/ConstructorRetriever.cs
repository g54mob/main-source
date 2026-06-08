using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class ConstructorRetriever : IConstructorRetriever
	{
		private readonly Dictionary<Type, ConstructorInfo> _cachedConstructors = new Dictionary<Type, ConstructorInfo>();

		public ConstructorInfo GetEligibleConstructor(Type type)
		{
			if (_cachedConstructors.TryGetValue(type, out var value))
			{
				return value;
			}
			GetConstructors(type, out var parameterlessConstructor, out var singleParameterfulConstructor);
			if (parameterlessConstructor != null && singleParameterfulConstructor != null)
			{
				return null;
			}
			ConstructorInfo constructorInfo = parameterlessConstructor ?? singleParameterfulConstructor;
			_cachedConstructors.Add(type, constructorInfo);
			return constructorInfo;
		}

		private static void GetConstructors(Type type, out ConstructorInfo parameterlessConstructor, out ConstructorInfo singleParameterfulConstructor)
		{
			singleParameterfulConstructor = null;
			parameterlessConstructor = null;
			ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (ConstructorInfo constructorInfo in constructors)
			{
				if (constructorInfo.GetParameters().Length == 0)
				{
					parameterlessConstructor = constructorInfo;
					continue;
				}
				if (singleParameterfulConstructor == null)
				{
					singleParameterfulConstructor = constructorInfo;
					continue;
				}
				throw new BinditoException(TypeFormatting.Format(type) + " has more than one parameterful constructors.");
			}
		}
	}
}
