using System;
using System.Linq;
using System.Reflection;
using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Routing.Handlers
{
	public class RaiseEventHandler : ICallHandler
	{
		private readonly IEventHandlerRegistry _eventHandlerRegistry;

		private readonly Func<ICall, object?[]> _getEventArguments;

		public RaiseEventHandler(IEventHandlerRegistry eventHandlerRegistry, Func<ICall, object?[]> getEventArguments)
		{
			_eventHandlerRegistry = eventHandlerRegistry;
			_getEventArguments = getEventArguments;
		}

		public RouteAction Handle(ICall call)
		{
			EventInfo eventInfo = FindEventInfo(call.GetMethodInfo());
			if (eventInfo == null)
			{
				throw new CouldNotRaiseEventException();
			}
			object[] args = _getEventArguments(call);
			foreach (Delegate handler in _eventHandlerRegistry.GetHandlers(eventInfo.Name))
			{
				if ((object)handler != null)
				{
					try
					{
						handler.DynamicInvoke(args);
					}
					catch (TargetInvocationException ex)
					{
						throw ex.InnerException;
					}
				}
			}
			return RouteAction.Continue();
			static EventInfo? FindEventInfo(MethodInfo mi)
			{
				return mi.DeclaringType.GetEvents().FirstOrDefault((EventInfo e) => e.GetAddMethod() == mi || e.GetRemoveMethod() == mi);
			}
		}
	}
}
