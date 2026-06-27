using System;
using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class SetActionForCallHandler : ICallHandler
	{
		public SetActionForCallHandler(ICallSpecificationFactory callSpecificationFactory, ICallActions callActions, Action<CallInfo> action, MatchArgs matchArgs)
		{
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CcallActions_003EP = callActions;
			_003Caction_003EP = action;
			_003CmatchArgs_003EP = matchArgs;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, _003CmatchArgs_003EP);
			_003CcallActions_003EP.Add(callSpecification, _003Caction_003EP);
			return RouteAction.Continue();
		}
	}
}
