using System;
using System.Reflection;
using NSubstitute.Core;
using NSubstitute.Core.Events;

namespace NSubstitute
{
	public static class Raise
	{
		public static EventHandlerWrapper<TEventArgs> EventWith<TEventArgs>(object sender, TEventArgs eventArgs) where TEventArgs : EventArgs
		{
			return new EventHandlerWrapper<TEventArgs>(sender, eventArgs);
		}

		public static EventHandlerWrapper<TEventArgs> EventWith<TEventArgs>(TEventArgs eventArgs) where TEventArgs : EventArgs
		{
			return new EventHandlerWrapper<TEventArgs>(eventArgs);
		}

		public static EventHandlerWrapper<TEventArgs> EventWith<TEventArgs>() where TEventArgs : EventArgs
		{
			return new EventHandlerWrapper<TEventArgs>();
		}

		public static EventHandlerWrapper<EventArgs> Event()
		{
			return new EventHandlerWrapper<EventArgs>();
		}

		public static DelegateEventWrapper<THandler> Event<THandler>(params object[] arguments)
		{
			return new DelegateEventWrapper<THandler>(FixParamsArrayAmbiguity(arguments, typeof(THandler)));
		}

		private static object[] FixParamsArrayAmbiguity(object[] arguments, Type delegateType)
		{
			ParameterInfo[] parameters = delegateType.GetInvokeMethod().GetParameters();
			if (parameters.Length != 1)
			{
				return arguments;
			}
			Type parameterType = parameters[0].ParameterType;
			if (!parameterType.IsArray)
			{
				return arguments;
			}
			if (arguments.Length == 1 && parameterType.IsInstanceOfType(arguments[0]))
			{
				return arguments;
			}
			if (parameterType.IsInstanceOfType(arguments))
			{
				return new object[1] { arguments };
			}
			return arguments;
		}
	}
}
