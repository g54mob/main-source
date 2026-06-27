using System;
using System.Linq;
using System.Reflection;
using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Routing.Handlers
{
	public class RaiseEventHandler : ICallHandler
	{
		public RaiseEventHandler(IEventHandlerRegistry eventHandlerRegistry, Func<ICall, object?[]> getEventArguments)
		{
			_003CeventHandlerRegistry_003EP = eventHandlerRegistry;
			_003CgetEventArguments_003EP = getEventArguments;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			EventInfo eventInfo = FindEventInfo(call.GetMethodInfo());
			if (eventInfo == null)
			{
				throw new CouldNotRaiseEventException();
			}
			object[] args = _003CgetEventArguments_003EP(call);
			foreach (Delegate handler in _003CeventHandlerRegistry_003EP.GetHandlers(eventInfo.Name))
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
