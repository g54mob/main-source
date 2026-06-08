using System;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core.Events
{
	public abstract class RaiseEventWrapper
	{
		protected abstract string RaiseMethodName { get; }

		protected abstract object?[] WorkOutRequiredArguments(ICall call);

		protected EventArgs GetDefaultForEventArgType(Type type)
		{
			if (type == typeof(EventArgs))
			{
				return EventArgs.Empty;
			}
			ConstructorInfo? defaultConstructor = GetDefaultConstructor(type);
			if (defaultConstructor == null)
			{
				throw new CannotCreateEventArgsException(string.Format("Cannot create {0} for this event as it has no default constructor. Provide arguments for this event by calling {1}({0}).", type.Name, RaiseMethodName));
			}
			return (EventArgs)defaultConstructor.Invoke(new object[0]);
		}

		private static ConstructorInfo? GetDefaultConstructor(Type type)
		{
			return type.GetConstructor(Type.EmptyTypes);
		}

		protected static void RaiseEvent(RaiseEventWrapper wrapper)
		{
			SubstitutionContext.Current.ThreadContext.SetPendingRaisingEventArgumentsFactory((ICall call) => wrapper.WorkOutRequiredArguments(call));
		}
	}
}
