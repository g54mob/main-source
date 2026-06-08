using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core
{
	public class EventCallFormatter : IMethodInfoFormatter
	{
		public static readonly Func<MethodInfo, Predicate<EventInfo>> IsSubscription = (MethodInfo call) => (EventInfo eventInfo) => eventInfo.GetAddMethod() == call;

		public static readonly Func<MethodInfo, Predicate<EventInfo>> IsUnsubscription = (MethodInfo call) => (EventInfo eventInfo) => eventInfo.GetRemoveMethod() == call;

		private readonly Func<MethodInfo, Predicate<EventInfo>> _eventsToFormat;

		private readonly string _eventOperator;

		public EventCallFormatter(Func<MethodInfo, Predicate<EventInfo>> eventsToFormat)
		{
			_eventsToFormat = eventsToFormat;
			_eventOperator = ((eventsToFormat == IsSubscription) ? "+=" : "-=");
		}

		public bool CanFormat(MethodInfo methodInfo)
		{
			return methodInfo.DeclaringType.GetEvents().Any((EventInfo x) => _eventsToFormat(methodInfo)(x));
		}

		public string Format(MethodInfo methodInfo, IEnumerable<string> arguments)
		{
			EventInfo eventInfo = methodInfo.DeclaringType.GetEvents().First((EventInfo x) => _eventsToFormat(methodInfo)(x));
			return Format(eventInfo, _eventOperator, arguments);
		}

		private string Format(EventInfo eventInfo, string eventOperator, IEnumerable<string> arguments)
		{
			return eventInfo.Name + " " + eventOperator + " " + arguments.Join(", ");
		}
	}
}
