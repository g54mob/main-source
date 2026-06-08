using System.Collections.Generic;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
	public class CallSpecificationFactory : ICallSpecificationFactory
	{
		private readonly IArgumentSpecificationsFactory _argumentSpecificationsFactory;

		public CallSpecificationFactory(IArgumentSpecificationsFactory argumentSpecificationsFactory)
		{
			_argumentSpecificationsFactory = argumentSpecificationsFactory;
		}

		public ICallSpecification CreateFrom(ICall call, MatchArgs matchArgs)
		{
			MethodInfo methodInfo = call.GetMethodInfo();
			IList<IArgumentSpecification> argumentSpecifications = call.GetArgumentSpecifications();
			object[] originalArguments = call.GetOriginalArguments();
			IParameterInfo[] parameterInfos = call.GetParameterInfos();
			IEnumerable<IArgumentSpecification> argumentSpecifications2 = _argumentSpecificationsFactory.Create(argumentSpecifications, originalArguments, parameterInfos, methodInfo, matchArgs);
			return new CallSpecification(methodInfo, argumentSpecifications2);
		}
	}
}
