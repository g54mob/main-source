using System;
using System.Collections.Generic;
using System.Reflection;

namespace RoslynCSharp
{
	public class ScriptEventHandlerProxy : IScriptEventProxy
	{
		private class ScriptEventHandlerDummy : ScriptEventHandler
		{
			public ScriptEventHandlerDummy()
				: base(null, null)
			{
			}

			public override void AddListener(Delegate methodDelegate)
			{
			}

			public override void RemoveListener(Delegate methodDelegate)
			{
			}
		}

		private static readonly ScriptEventHandlerDummy dummyEventHandler = new ScriptEventHandlerDummy();

		private ScriptType scriptType;

		private ScriptProxy scriptProxy;

		private bool isStatic;

		private bool throwOnError = true;

		private Dictionary<EventInfo, ScriptEventHandler> eventHandlers;

		public ScriptEventHandler this[string name] => GetEvent(name);

		public ScriptEventHandlerProxy(ScriptType type, ScriptProxy proxy, bool isStatic, bool throwOnError)
		{
			scriptType = type;
			scriptProxy = proxy;
			this.isStatic = isStatic;
			this.throwOnError = throwOnError;
		}

		public ScriptEventHandler GetEvent(string name)
		{
			try
			{
				EventInfo eventInfo = scriptType.FindCachedEvent(name, isStatic);
				if (eventInfo == null)
				{
					throw new TargetException($"Type '{scriptType}' does not define an event called '{name}'");
				}
				object instance = ((scriptProxy != null) ? scriptProxy.Instance : null);
				if (eventHandlers == null)
				{
					eventHandlers = new Dictionary<EventInfo, ScriptEventHandler>();
				}
				if (!eventHandlers.TryGetValue(eventInfo, out var value))
				{
					value = new ScriptEventHandler(eventInfo, instance);
					eventHandlers.Add(eventInfo, value);
				}
				return value;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
			}
			return dummyEventHandler;
		}
	}
}
