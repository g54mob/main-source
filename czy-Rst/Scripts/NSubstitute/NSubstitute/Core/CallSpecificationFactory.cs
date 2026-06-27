using System.Collections.Generic;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
	public class CallSpecificationFactory : ICallSpecificationFactory
	{
		public CallSpecificationFactory(IArgumentSpecificationsFactory argumentSpecificationsFactory)
		{
			_003CargumentSpecificationsFactory_003EP = argumentSpecificationsFactory;
			base._002Ector();
		}

		public ICallSpecification CreateFrom(ICall call, MatchArgs matchArgs)
		{
			MethodInfo methodInfo = call.GetMethodInfo();
			IList<IArgumentSpecification> argumentSpecifications = call.GetArgumentSpecifications();
			object[] originalArguments = call.GetOriginalArguments();
			IParameterInfo[] parameterInfos = call.GetParameterInfos();
			IEnumerable<IArgumentSpecification> argumentSpecifications2 = _003CargumentSpecificationsFactory_003EP.Create(argumentSpecifications, originalArguments, parameterInfos, methodInfo, matchArgs);
			return new CallSpecification(methodInfo, argumentSpecifications2);
		}
	}
}
