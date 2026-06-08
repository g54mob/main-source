using System;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public class InstanceCreator : IInstanceCreator
	{
		private readonly IConstructorRetriever _constructorRetriever;

		private readonly IParameterProvider _parameterProvider;

		public InstanceCreator(IParameterProvider parameterProvider, IConstructorRetriever constructorRetriever)
		{
			_parameterProvider = parameterProvider;
			_constructorRetriever = constructorRetriever;
		}

		public object CreateInstance(Type type)
		{
			return CreateUsingEligibleConstructor(type);
		}

		private object CreateUsingEligibleConstructor(Type type)
		{
			ConstructorInfo eligibleConstructor = _constructorRetriever.GetEligibleConstructor(type);
			if (eligibleConstructor == null)
			{
				throw new BinditoException("No eligible constructor found for type " + TypeFormatting.Format(type) + ".");
			}
			object[] parameters = _parameterProvider.GetParameters(eligibleConstructor);
			return eligibleConstructor.Invoke(parameters);
		}
	}
}
