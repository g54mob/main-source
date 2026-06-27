using System;
using System.Collections.Generic;
using NSubstitute.Exceptions;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class CallRouter : ICallRouter
	{
		public bool CallBaseByDefault
		{
			get
			{
				return _003CsubstituteState_003EP.CallBaseConfiguration.CallBaseByDefault;
			}
			set
			{
				if (!_003CcanConfigureBaseCalls_003EP)
				{
					throw CouldNotConfigureCallBaseException.ForAllCalls();
				}
				_003CsubstituteState_003EP.CallBaseConfiguration.CallBaseByDefault = value;
			}
		}

		public CallRouter(ISubstituteState substituteState, IThreadLocalContext threadContext, IRouteFactory routeFactory, bool canConfigureBaseCalls)
		{
			_003CsubstituteState_003EP = substituteState;
			_003CthreadContext_003EP = threadContext;
			_003CrouteFactory_003EP = routeFactory;
			_003CcanConfigureBaseCalls_003EP = canConfigureBaseCalls;
			base._002Ector();
		}

		public void Clear(ClearOptions options)
		{
			if ((options & ClearOptions.CallActions) == ClearOptions.CallActions)
			{
				_003CsubstituteState_003EP.CallActions.Clear();
			}
			if ((options & ClearOptions.ReturnValues) == ClearOptions.ReturnValues)
			{
				_003CsubstituteState_003EP.CallResults.Clear();
				_003CsubstituteState_003EP.ResultsForType.Clear();
			}
			if ((options & ClearOptions.ReceivedCalls) == ClearOptions.ReceivedCalls)
			{
				_003CsubstituteState_003EP.ReceivedCalls.Clear();
			}
		}

		public IEnumerable<ICall> ReceivedCalls()
		{
			return _003CsubstituteState_003EP.ReceivedCalls.AllCalls();
		}

		public void SetRoute(Func<ISubstituteState, IRoute> getRoute)
		{
			_003CthreadContext_003EP.SetNextRoute(this, getRoute);
		}

		public object? Route(ICall call)
		{
			_003CthreadContext_003EP.SetLastCallRouter(this);
			bool isQuerying = _003CthreadContext_003EP.IsQuerying;
			Func<ICall, object[]> pendingRaisingEventArgs = _003CthreadContext_003EP.UsePendingRaisingEventArgumentsFactory();
			Func<ISubstituteState, IRoute> queuedNextRouteFactory = _003CthreadContext_003EP.UseNextRoute(this);
			return ResolveCurrentRoute(call, isQuerying, pendingRaisingEventArgs, queuedNextRouteFactory).Handle(call);
		}

		private IRoute ResolveCurrentRoute(ICall call, bool isQuerying, Func<ICall, object?[]>? pendingRaisingEventArgs, Func<ISubstituteState, IRoute>? queuedNextRouteFactory)
		{
			if (isQuerying)
			{
				return _003CrouteFactory_003EP.CallQuery(_003CsubstituteState_003EP);
			}
			if (pendingRaisingEventArgs != null)
			{
				return _003CrouteFactory_003EP.RaiseEvent(_003CsubstituteState_003EP, pendingRaisingEventArgs);
			}
			if (queuedNextRouteFactory != null)
			{
				return queuedNextRouteFactory(_003CsubstituteState_003EP);
			}
			if (IsSpecifyingACall(call))
			{
				return _003CrouteFactory_003EP.RecordCallSpecification(_003CsubstituteState_003EP);
			}
			return _003CrouteFactory_003EP.RecordReplay(_003CsubstituteState_003EP);
		}

		private static bool IsSpecifyingACall(ICall call)
		{
			if (call.GetOriginalArguments().Length != 0)
			{
				return call.GetArgumentSpecifications().Count != 0;
			}
			return false;
		}

		public ConfiguredCall LastCallShouldReturn(IReturn returnValue, MatchArgs matchArgs, PendingSpecificationInfo pendingSpecInfo)
		{
			return _003CsubstituteState_003EP.ConfigureCall.SetResultForLastCall(returnValue, matchArgs, pendingSpecInfo);
		}

		public void SetReturnForType(Type type, IReturn returnValue)
		{
			_003CsubstituteState_003EP.ResultsForType.SetResult(type, returnValue);
		}

		public void RegisterCustomCallHandlerFactory(CallHandlerFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			_003CsubstituteState_003EP.CustomHandlers.AddCustomHandlerFactory(factory);
		}
	}
}
