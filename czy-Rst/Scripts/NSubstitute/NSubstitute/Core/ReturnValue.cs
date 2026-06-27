using System;

namespace NSubstitute.Core
{
	public class ReturnValue : IReturn, ICallIndependentReturn
	{
		public ReturnValue(object? value)
		{
			_003Cvalue_003EP = value;
			base._002Ector();
		}

		public object? GetReturnValue()
		{
			return _003Cvalue_003EP;
		}

		public object? ReturnFor(CallInfo info)
		{
			return GetReturnValue();
		}

		public Type? TypeOrNull()
		{
			return _003Cvalue_003EP?.GetType();
		}

		public bool CanBeAssignedTo(Type t)
		{
			return _003Cvalue_003EP.IsCompatibleWith(t);
		}
	}
}
