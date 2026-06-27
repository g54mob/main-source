using System;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class ConfigureCall : IConfigureCall
	{
		public ConfigureCall(ICallResults configuredResults, ICallActions callActions, IGetCallSpec getCallSpec)
		{
			_003CconfiguredResults_003EP = configuredResults;
			_003CcallActions_003EP = callActions;
			_003CgetCallSpec_003EP = getCallSpec;
			base._002Ector();
		}

		public ConfiguredCall SetResultForLastCall(IReturn valueToReturn, MatchArgs matchArgs, PendingSpecificationInfo pendingSpecInfo)
		{
			ICallSpecification spec = _003CgetCallSpec_003EP.FromPendingSpecification(matchArgs, pendingSpecInfo);
			CheckResultIsCompatibleWithCall(valueToReturn, spec);
			_003CconfiguredResults_003EP.SetResult(spec, valueToReturn);
			return new ConfiguredCall(delegate(Action<CallInfo> action)
			{
				_003CcallActions_003EP.Add(spec, action);
			});
		}

		public void SetResultForCall(ICall call, IReturn valueToReturn, MatchArgs matchArgs)
		{
			ICallSpecification callSpecification = _003CgetCallSpec_003EP.FromCall(call, matchArgs);
			CheckResultIsCompatibleWithCall(valueToReturn, callSpecification);
			_003CconfiguredResults_003EP.SetResult(callSpecification, valueToReturn);
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
