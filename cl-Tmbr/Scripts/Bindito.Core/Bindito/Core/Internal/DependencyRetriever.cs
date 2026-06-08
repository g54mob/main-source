using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class DependencyRetriever : IDependencyRetriever
	{
		private readonly IConstructorRetriever _constructorRetriever;

		private readonly IMethodRetriever _methodRetriever;

		public DependencyRetriever(IConstructorRetriever constructorRetriever, IMethodRetriever methodRetriever)
		{
			_constructorRetriever = constructorRetriever;
			_methodRetriever = methodRetriever;
		}

		public IEnumerable<Type> GetDependencies(ProvisionBinding provisionBinding)
		{
			Type type = provisionBinding.Type;
			if (type != null)
			{
				return GetParametersOfEligibleConstructor(type).Concat(GetParametersOfInjectedMethods(type));
			}
			object instance = provisionBinding.Instance;
			if (instance != null)
			{
				return GetParametersOfInjectedMethods(instance.GetType());
			}
			Type providerType = provisionBinding.ProviderType;
			if (providerType != null)
			{
				return GetParametersOfEligibleConstructor(providerType).Concat(GetParametersOfInjectedMethods(providerType));
			}
			Type existingType = provisionBinding.ExistingType;
			if (existingType != null)
			{
				return Enumerable.Repeat(existingType, 1);
			}
			return Enumerable.Empty<Type>();
		}

		private IEnumerable<Type> GetParametersOfInjectedMethods(Type type)
		{
			return _methodRetriever.GetInjectedMethods(type).SelectMany(GetParameterTypes);
		}

		private IEnumerable<Type> GetParametersOfEligibleConstructor(Type type)
		{
			ConstructorInfo eligibleConstructor = _constructorRetriever.GetEligibleConstructor(type);
			if (!(eligibleConstructor != null))
			{
				return Enumerable.Empty<Type>();
			}
			return GetParameterTypes(eligibleConstructor);
		}

		private static IEnumerable<Type> GetParameterTypes(MethodBase methodBase)
		{
			return from parameter in methodBase.GetParameters()
				select parameter.ParameterType;
		}
	}
}
