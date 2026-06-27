using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Routing.Handlers
{
	public class CallBaseForCallHandler : ICallHandler
	{
		public CallBaseForCallHandler(ICallSpecificationFactory callSpecificationFactory, ICallBaseConfiguration callBaseConfig, MatchArgs matchArgs)
		{
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CcallBaseConfig_003EP = callBaseConfig;
			_003CmatchArgs_003EP = matchArgs;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (!call.CanCallBase)
			{
				throw CouldNotConfigureCallBaseException.ForSingleCall();
			}
			ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, _003CmatchArgs_003EP);
			_003CcallBaseConfig_003EP.Include(callSpecification);
			return RouteAction.Continue();
		}
	}
}
