using System;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class ConfigureCall : IConfigureCall
	{
		private readonly ICallResults _configuredResults;

		private readonly ICallActions _callActions;

		private readonly IGetCallSpec _getCallSpec;

		public ConfigureCall(ICallResults configuredResults, ICallActions callActions, IGetCallSpec getCallSpec)
		{
			_configuredResults = configuredResults;
			_callActions = callActions;
			_getCallSpec = getCallSpec;
		}

		public ConfiguredCall SetResultForLastCall(IReturn valueToReturn, MatchArgs matchArgs, PendingSpecificationInfo pendingSpecInfo)
		{
			ICallSpecification spec = _getCallSpec.FromPendingSpecification(matchArgs, pendingSpecInfo);
			CheckResultIsCompatibleWithCall(valueToReturn, spec);
			_configuredResults.SetResult(spec, valueToReturn);
			return new ConfiguredCall(delegate(Action<CallInfo> action)
			{
				_callActions.Add(spec, action);
			});
		}

		public void SetResultForCall(ICall call, IReturn valueToReturn, MatchArgs matchArgs)
		{
			ICallSpecification callSpecification = _getCallSpec.FromCall(call, matchArgs);
			CheckResultIsCompatibleWithCall(valueToReturn, callSpecification);
			_configuredResults.SetResult(callSpecification, valueToReturn);
		}

		private static void CheckResultIsCompatibleWithCall(IReturn valueToReturn, ICallSpecification spec)
		{
			Type t = spec.ReturnType();
			if (!valueToReturn.CanBeAssignedTo(t))
			{
				throw new CouldNotSetReturnDueToTypeMismatchException(valueToReturn.TypeOrNull(), spec.GetMethodInfo());
			}
		}
	}
}
