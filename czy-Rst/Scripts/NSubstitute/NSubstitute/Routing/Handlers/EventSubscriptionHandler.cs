using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class EventSubscriptionHandler : ICallHandler
	{
		public EventSubscriptionHandler(IEventHandlerRegistry eventHandlerRegistry)
		{
			_003CeventHandlerRegistry_003EP = eventHandlerRegistry;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (CanBeSubscribeUnsubscribeCall(call))
			{
				If(call, IsEventSubscription, _003CeventHandlerRegistry_003EP.Add);
				If(call, IsEventUnsubscription, _003CeventHandlerRegistry_003EP.Remove);
			}
			return RouteAction.Continue();
		}

		private static bool CanBeSubscribeUnsubscribeCall(ICall call)
		{
			MethodInfo methodInfo = call.GetMethodInfo();
			if (methodInfo.ReturnType == typeof(void))
			{
				if (!methodInfo.Name.StartsWith("add_", StringComparison.Ordinal))
				{
					return methodInfo.Name.StartsWith("remove_", StringComparison.Ordinal);
				}
				return true;
			}
			return false;
		}

		private static void If(ICall call, Func<ICall, Predicate<EventInfo>> meetsThisSpecification, Action<string, object> takeThisAction)
		{
			EventInfo eventInfo = GetEvents(call, meetsThisSpecification).FirstOrDefault();
			if (eventInfo != null)
			{
				takeThisAction(eventInfo.Name, call.GetOriginalArguments()[0]);
			}
		}

		private static Predicate<EventInfo> IsEventSubscription(ICall call)
		{
			return (EventInfo x) => call.GetMethodInfo() == x.GetAddMethod();
		}

		private static Predicate<EventInfo> IsEventUnsubscription(ICall call)
		{
			return (EventInfo x) => call.GetMethodInfo() == x.GetRemoveMethod();
		}

		private static IEnumerable<EventInfo> GetEvents(ICall call, Func<ICall, Predicate<EventInfo>> createPredicate)
		{
			Predicate<EventInfo> predicate = createPredicate(call);
			return from x in call.GetMethodInfo().DeclaringType.GetEvents()
				where predicate(x)
				select x;
		}
	}
}
