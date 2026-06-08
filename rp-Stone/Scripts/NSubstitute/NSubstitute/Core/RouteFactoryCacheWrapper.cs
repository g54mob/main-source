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

		private readonly IRouteFactory _factory;

		private CachedRoute _recordReplayCache;

		private CachedRoute _recordCallSpecificationCache;

		public RouteFactoryCacheWrapper(IRouteFactory factory)
		{
			_factory = factory;
		}

		public IRoute RecordReplay(ISubstituteState state)
		{
			if (_recordReplayCache.State != state)
			{
				_recordReplayCache = new CachedRoute(_factory.RecordReplay(state), state);
			}
			return _recordReplayCache.Route;
		}

		public IRoute RecordCallSpecification(ISubstituteState state)
		{
			if (_recordCallSpecificationCache.State != state)
			{
				_recordCallSpecificationCache = new CachedRoute(_factory.RecordCallSpecification(state), state);
			}
			return _recordCallSpecificationCache.Route;
		}

		public IRoute CallQuery(ISubstituteState state)
		{
			return _factory.CallQuery(state);
		}

		public IRoute CheckReceivedCalls(ISubstituteState state, MatchArgs matchArgs, Quantity requiredQuantity)
		{
			return _factory.CheckReceivedCalls(state, matchArgs, requiredQuantity);
		}

		public IRoute DoWhenCalled(ISubstituteState state, Action<CallInfo> doAction, MatchArgs matchArgs)
		{
			return _factory.DoWhenCalled(state, doAction, matchArgs);
		}

		public IRoute DoNotCallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return _factory.DoNotCallBase(state, matchArgs);
		}

		public IRoute CallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return _factory.CallBase(state, matchArgs);
		}

		public IRoute RaiseEvent(ISubstituteState state, Func<ICall, object?[]> getEventArguments)
		{
			return _factory.RaiseEvent(state, getEventArguments);
		}
	}
}
