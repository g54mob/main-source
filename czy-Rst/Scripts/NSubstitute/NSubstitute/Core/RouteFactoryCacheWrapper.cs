using System;
using NSubstitute.ReceivedExtensions;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class RouteFactoryCacheWrapper : IRouteFactory
	{
		private readonly struct CachedRoute
		{
			public readonly IRoute Route;

			public readonly ISubstituteState State;

			public CachedRoute(IRoute route, ISubstituteState state)
			{
				Route = route;
				State = state;
			}
		}

		private CachedRoute _recordReplayCache;

		private CachedRoute _recordCallSpecificationCache;

		public RouteFactoryCacheWrapper(IRouteFactory factory)
		{
			_003Cfactory_003EP = factory;
			base._002Ector();
		}

		public IRoute RecordReplay(ISubstituteState state)
		{
			if (_recordReplayCache.State != state)
			{
				_recordReplayCache = new CachedRoute(_003Cfactory_003EP.RecordReplay(state), state);
			}
			return _recordReplayCache.Route;
		}

		public IRoute RecordCallSpecification(ISubstituteState state)
		{
			if (_recordCallSpecificationCache.State != state)
			{
				_recordCallSpecificationCache = new CachedRoute(_003Cfactory_003EP.RecordCallSpecification(state), state);
			}
			return _recordCallSpecificationCache.Route;
		}

		public IRoute CallQuery(ISubstituteState state)
		{
			return _003Cfactory_003EP.CallQuery(state);
		}

		public IRoute CheckReceivedCalls(ISubstituteState state, MatchArgs matchArgs, Quantity requiredQuantity)
		{
			return _003Cfactory_003EP.CheckReceivedCalls(state, matchArgs, requiredQuantity);
		}

		public IRoute DoWhenCalled(ISubstituteState state, Action<CallInfo> doAction, MatchArgs matchArgs)
		{
			return _003Cfactory_003EP.DoWhenCalled(state, doAction, matchArgs);
		}

		public IRoute DoNotCallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return _003Cfactory_003EP.DoNotCallBase(state, matchArgs);
		}

		public IRoute CallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return _003Cfactory_003EP.CallBase(state, matchArgs);
		}

		public IRoute RaiseEvent(ISubstituteState state, Func<ICall, object?[]> getEventArguments)
		{
			return _003Cfactory_003EP.RaiseEvent(state, getEventArguments);
		}
	}
}
