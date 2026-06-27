using System;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class ReturnValueFromFunc<T> : IReturn
	{
		private readonly Func<CallInfo, T?> _funcToReturnValue;

		public ReturnValueFromFunc(Func<CallInfo, T?>? funcToReturnValue)
		{
			_funcToReturnValue = funcToReturnValue ?? ReturnNull();
			base._002Ector();
		}

		public object? ReturnFor(CallInfo info)
		{
			return _funcToReturnValue(info);
		}

		public Type TypeOrNull()
		{
			return typeof(T);
		}

		public bool CanBeAssignedTo(Type t)
		{
			return typeof(T).IsAssignableFrom(t);
		}

		private static Func<CallInfo, T?> ReturnNull()
		{
			if (typeof(T).GetTypeInfo().IsValueType)
			{
				throw new CannotReturnNullForValueType(typeof(T));
			}
			return (CallInfo x) => default(T);
		}
	}
}
