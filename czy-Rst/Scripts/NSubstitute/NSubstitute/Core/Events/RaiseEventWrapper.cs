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
			return (EventArgs)((GetPublicDefaultConstructor(type) ?? GetInternalDefaultConstructor(type)) ?? throw new CannotCreateEventArgsException(string.Format("Cannot create {0} for this event as it has no default constructor. Provide arguments for this event by calling {1}({0}).", type.Name, RaiseMethodName))).Invoke(Array.Empty<object>());
		}

		private static ConstructorInfo? GetInternalDefaultConstructor(Type type)
		{
			ConstructorInfo nonPublicDefaultConstructor = GetNonPublicDefaultConstructor(type);
			if ((object)nonPublicDefaultConstructor == null || !nonPublicDefaultConstructor.IsAssembly)
			{
				return null;
			}
			return nonPublicDefaultConstructor;
		}

		private static ConstructorInfo? GetPublicDefaultConstructor(Type type)
		{
			return GetDefaultConstructor(type, BindingFlags.Public);
		}

		private static ConstructorInfo? GetNonPublicDefaultConstructor(Type type)
		{
			return GetDefaultConstructor(type, BindingFlags.NonPublic);
		}

		private static ConstructorInfo? GetDefaultConstructor(Type type, BindingFlags bindingFlags)
		{
			return type.GetConstructor(BindingFlags.Instance | BindingFlags.ExactBinding | bindingFlags, null, Type.EmptyTypes, null);
		}

		protected static void RaiseEvent(RaiseEventWrapper wrapper)
		{
			SubstitutionContext.Current.ThreadContext.SetPendingRaisingEventArgumentsFactory((ICall call) => wrapper.WorkOutRequiredArguments(call));
		}
	}
}
