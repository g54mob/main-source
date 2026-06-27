namespace NSubstitute.Core
{
	public class GetCallSpec : IGetCallSpec
	{
		public GetCallSpec(ICallCollection receivedCalls, ICallSpecificationFactory callSpecificationFactory, ICallActions callActions)
		{
			_003CreceivedCalls_003EP = receivedCalls;
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CcallActions_003EP = callActions;
			base._002Ector();
		}

		public ICallSpecification FromPendingSpecification(MatchArgs matchArgs, PendingSpecificationInfo pendingSpecInfo)
		{
			return pendingSpecInfo.Handle((ICallSpecification callSpec) => FromExistingSpec(callSpec, matchArgs), delegate(ICall lastCall)
			{
				_003CreceivedCalls_003EP.Delete(lastCall);
				return FromCall(lastCall, matchArgs);
			});
		}

		public ICallSpecification FromCall(ICall call, MatchArgs matchArgs)
		{
			return _003CcallSpecificationFactory_003EP.CreateFrom(call, matchArgs);
		}

		public ICallSpecification FromExistingSpec(ICallSpecification spec, MatchArgs matchArgs)
		{
			if (matchArgs != MatchArgs.AsSpecifiedInCall)
			{
				return UpdateCallSpecToMatchAnyArgs(spec);
			}
			return spec;
		}

		private ICallSpecification UpdateCallSpecToMatchAnyArgs(ICallSpecification callSpecification)
		{
			ICallSpecification callSpecification2 = callSpecification.CreateCopyThatMatchesAnyArguments();
			_003CcallActions_003EP.MoveActionsForSpecToNewSpec(callSpecification, callSpecification2);
			return callSpecification2;
		}
	}
}
