using System;
using System.Linq;
using System.Reflection;

namespace Moq
{
	internal static class HandleEventSubscription
	{
		public static bool Handle(Invocation invocation, Mock mock)
		{
			string name = invocation.Method.Name;
			if (name.Length > 4)
			{
				if (name[0] == 'a' && name[3] == '_' && invocation.Method.IsEventAddAccessor())
				{
					MethodInfo implementingMethod = invocation.Method.GetImplementingMethod(invocation.ProxyType);
					EventInfo eventInfo = implementingMethod.DeclaringType.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((EventInfo e) => e.GetAddMethod(nonPublic: true) == implementingMethod);
					if (eventInfo != null)
					{
						if (mock.CallBase && !invocation.Method.IsAbstract)
						{
							invocation.ReturnValue = invocation.CallBase();
							return true;
						}
						if (invocation.Arguments.Length != 0 && invocation.Arguments[0] is Delegate eventHandler)
						{
							mock.EventHandlers.Add(eventInfo, eventHandler);
							return true;
						}
					}
				}
				else if (name[0] == 'r' && name.Length > 7 && name[6] == '_' && invocation.Method.IsEventRemoveAccessor())
				{
					MethodInfo implementingMethod2 = invocation.Method.GetImplementingMethod(invocation.ProxyType);
					EventInfo eventInfo2 = implementingMethod2.DeclaringType.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((EventInfo e) => e.GetRemoveMethod(nonPublic: true) == implementingMethod2);
					if (eventInfo2 != null)
					{
						if (mock.CallBase && !invocation.Method.IsAbstract)
						{
							invocation.ReturnValue = invocation.CallBase();
							return true;
						}
						if (invocation.Arguments.Length != 0 && invocation.Arguments[0] is Delegate eventHandler2)
						{
							mock.EventHandlers.Remove(eventInfo2, eventHandler2);
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
