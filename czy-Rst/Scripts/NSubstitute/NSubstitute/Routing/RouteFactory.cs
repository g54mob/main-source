using System;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;
using NSubstitute.Routing.Handlers;

namespace NSubstitute.Routing
{
	public class RouteFactory : IRouteFactory
	{
		public RouteFactory(SequenceNumberGenerator sequenceNumberGenerator, IThreadLocalContext threadLocalContext, ICallSpecificationFactory callSpecificationFactory, IReceivedCallsExceptionThrower receivedCallsExceptionThrower, IPropertyHelper propertyHelper, IDefaultForType defaultForType)
		{
			_003CsequenceNumberGenerator_003EP = sequenceNumberGenerator;
			_003CthreadLocalContext_003EP = threadLocalContext;
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CreceivedCallsExceptionThrower_003EP = receivedCallsExceptionThrower;
			_003CpropertyHelper_003EP = propertyHelper;
			_003CdefaultForType_003EP = defaultForType;
			base._002Ector();
		}

		public IRoute CallQuery(ISubstituteState state)
		{
			return new Route(new ICallHandler[4]
			{
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new AddCallToQueryResultHandler(_003CthreadLocalContext_003EP),
				new ReturnAutoValue(AutoValueBehaviour.UseValueForSubsequentCalls, state.AutoValueProviders, state.AutoValuesCallResults, _003CcallSpecificationFactory_003EP),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute CheckReceivedCalls(ISubstituteState state, MatchArgs matchArgs, Quantity requiredQuantity)
		{
			return new Route(new ICallHandler[5]
			{
				new ClearLastCallRouterHandler(_003CthreadLocalContext_003EP),
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new CheckReceivedCallsHandler(state.ReceivedCalls, _003CcallSpecificationFactory_003EP, _003CreceivedCallsExceptionThrower_003EP, matchArgs, requiredQuantity),
				new ReturnAutoValue(AutoValueBehaviour.ReturnAndForgetValue, state.AutoValueProviders, state.AutoValuesCallResults, _003CcallSpecificationFactory_003EP),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute DoWhenCalled(ISubstituteState state, Action<CallInfo> doAction, MatchArgs matchArgs)
		{
			return new Route(new ICallHandler[4]
			{
				new ClearLastCallRouterHandler(_003CthreadLocalContext_003EP),
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new SetActionForCallHandler(_003CcallSpecificationFactory_003EP, state.CallActions, doAction, matchArgs),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute DoNotCallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return new Route(new ICallHandler[4]
			{
				new ClearLastCallRouterHandler(_003CthreadLocalContext_003EP),
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new DoNotCallBaseForCallHandler(_003CcallSpecificationFactory_003EP, state.CallBaseConfiguration, matchArgs),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute CallBase(ISubstituteState state, MatchArgs matchArgs)
		{
			return new Route(new ICallHandler[4]
			{
				new ClearLastCallRouterHandler(_003CthreadLocalContext_003EP),
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new CallBaseForCallHandler(_003CcallSpecificationFactory_003EP, state.CallBaseConfiguration, matchArgs),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute RaiseEvent(ISubstituteState state, Func<ICall, object?[]> getEventArguments)
		{
			return new Route(new ICallHandler[4]
			{
				new ClearLastCallRouterHandler(_003CthreadLocalContext_003EP),
				new ClearUnusedCallSpecHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new RaiseEventHandler(state.EventHandlerRegistry, getEventArguments),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute RecordCallSpecification(ISubstituteState state)
		{
			return new Route(new ICallHandler[5]
			{
				new RecordCallSpecificationHandler(_003CthreadLocalContext_003EP.PendingSpecification, _003CcallSpecificationFactory_003EP, state.CallActions),
				new PropertySetterHandler(_003CpropertyHelper_003EP, state.ConfigureCall),
				new ReturnAutoValue(AutoValueBehaviour.UseValueForSubsequentCalls, state.AutoValueProviders, state.AutoValuesCallResults, _003CcallSpecificationFactory_003EP),
				new ReturnFromAndConfigureDynamicCall(state.ConfigureCall),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		public IRoute RecordReplay(ISubstituteState state)
		{
			return new Route(new ICallHandler[12]
			{
				new TrackLastCallHandler(_003CthreadLocalContext_003EP.PendingSpecification),
				new RecordCallHandler(state.ReceivedCalls, _003CsequenceNumberGenerator_003EP),
				new EventSubscriptionHandler(state.EventHandlerRegistry),
				new PropertySetterHandler(_003CpropertyHelper_003EP, state.ConfigureCall),
				new DoActionsCallHandler(state.CallActions),
				new ReturnConfiguredResultHandler(state.CallResults),
				new ReturnResultForTypeHandler(state.ResultsForType),
				new ReturnFromBaseIfRequired(state.CallBaseConfiguration),
				new ReturnFromCustomHandlers(state.CustomHandlers),
				new ReturnAutoValue(AutoValueBehaviour.UseValueForSubsequentCalls, state.AutoValueProviders, state.AutoValuesCallResults, _003CcallSpecificationFactory_003EP),
				new ReturnFromAndConfigureDynamicCall(state.ConfigureCall),
				ReturnDefaultForReturnTypeHandler()
			});
		}

		private ReturnDefaultForReturnTypeHandler ReturnDefaultForReturnTypeHandler()
		{
			return new ReturnDefaultForReturnTypeHandler(_003CdefaultForType_003EP);
		}
	}
}
