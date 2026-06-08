using System;
using System.Collections.Concurrent;
using System.Linq;

namespace NSubstitute.Core
{
	public class ReturnMultipleValues<T> : IReturn, ICallIndependentReturn
	{
		private readonly ConcurrentQueue<T?> _valuesToReturn;

		private readonly T? _lastValue;

		public ReturnMultipleValues(T?[] values)
		{
			_valuesToReturn = new ConcurrentQueue<T>(values);
			_lastValue = values.Last();
		}

		public object? GetReturnValue()
		{
			return GetNext();
		}

		public object? ReturnFor(CallInfo info)
		{
			return GetReturnValue();
		}

		public Type TypeOrNull()
		{
			return typeof(T);
		}

		public bool CanBeAssignedTo(Type t)
		{
			return typeof(T).IsAssignableFrom(t);
		}

		private T? GetNext()
		{
			if (!_valuesToReturn.TryDequeue(out T result))
			{
				return _lastValue;
			}
			return result;
		}
	}
}
