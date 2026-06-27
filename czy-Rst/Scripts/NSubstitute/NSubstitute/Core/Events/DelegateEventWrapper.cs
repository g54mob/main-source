using System;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core.Events
{
	public class DelegateEventWrapper<T> : RaiseEventWrapper
	{
		protected override string RaiseMethodName => "Raise.Event";

		public DelegateEventWrapper(params object?[] arguments)
		{
			_003Carguments_003EP = arguments;
			base._002Ector();
		}

		public static implicit operator T(DelegateEventWrapper<T> wrapper)
		{
			RaiseEventWrapper.RaiseEvent(wrapper);
			return default(T);
		}

		protected override object?[] WorkOutRequiredArguments(ICall call)
		{
			ParameterInfo[] parameters = typeof(T).GetInvokeMethod().GetParameters();
			if (_003Carguments_003EP.Length < 2 && LooksLikeAnEventStyleCall(parameters))
			{
				return WorkOutSenderAndEventArgs(parameters[1].ParameterType, call);
			}
			if (!RequiredArgsHaveBeenProvided(_003Carguments_003EP, parameters))
			{
				ThrowBecauseRequiredArgsNotProvided(parameters);
			}
			return _003Carguments_003EP;
		}

		private bool LooksLikeAnEventStyleCall(ParameterInfo[] parameters)
		{
			if (parameters.Length == 2 && parameters[0].ParameterType == typeof(object))
			{
				return typeof(EventArgs).IsAssignableFrom(parameters[1].ParameterType);
			}
			return false;
		}

		private object?[] WorkOutSenderAndEventArgs(Type eventArgsType, ICall call)
		{
			object obj;
			object obj2;
			if (_003Carguments_003EP.Length == 0)
			{
				obj = call.Target();
				obj2 = GetDefaultForEventArgType(eventArgsType);
			}
			else if (_003Carguments_003EP[0].IsCompatibleWith(eventArgsType))
			{
				obj = call.Target();
				obj2 = _003Carguments_003EP[0];
			}
			else
			{
				obj = _003Carguments_003EP[0];
				obj2 = GetDefaultForEventArgType(eventArgsType);
			}
			return new object[2] { obj, obj2 };
		}

		private static bool RequiredArgsHaveBeenProvided(object?[] providedArgs, ParameterInfo[] requiredArgs)
		{
			if (providedArgs.Length != requiredArgs.Length)
			{
				return false;
			}
			for (int i = 0; i < providedArgs.Length; i++)
			{
				Type parameterType = requiredArgs[i].ParameterType;
				if (!providedArgs[i].IsCompatibleWith(parameterType))
				{
					return false;
				}
			}
			return true;
		}

		private static void ThrowBecauseRequiredArgsNotProvided(ParameterInfo[] requiredArgs)
		{
			throw new ArgumentException(string.Format("Cannot raise event with the provided arguments. Use Raise.Event<{0}>({1}) to raise this event.", typeof(T).Name, string.Join(", ", requiredArgs.Select((ParameterInfo x) => x.ParameterType.Name).ToArray())));
		}
	}
}
