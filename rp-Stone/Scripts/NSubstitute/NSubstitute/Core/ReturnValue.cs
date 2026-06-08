using System;

namespace NSubstitute.Core
{
	public class ReturnValue : IReturn, ICallIndependentReturn
	{
		private readonly object? _value;

		public ReturnValue(object? value)
		{
			_value = value;
		}

		public object? GetReturnValue()
		{
			return _value;
		}

		public object? ReturnFor(CallInfo info)
		{
			return GetReturnValue();
		}

		public Type? TypeOrNull()
		{
			return _value?.GetType();
		}

		public bool CanBeAssignedTo(Type t)
		{
			return _value.IsCompatibleWith(t);
		}
	}
}
