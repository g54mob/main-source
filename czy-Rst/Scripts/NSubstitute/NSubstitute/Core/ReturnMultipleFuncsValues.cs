using System;
using System.Collections.Concurrent;
using System.Linq;

namespace NSubstitute.Core
{
	public class ReturnMultipleFuncsValues<T> : IReturn
	{
		private readonly ConcurrentQueue<Func<CallInfo, T?>> _funcsToReturn;

		private readonly Func<CallInfo, T?> _lastFunc;

		public ReturnMultipleFuncsValues(Func<CallInfo, T?>[] funcs)
		{
			_funcsToReturn = new ConcurrentQueue<Func<CallInfo, T>>(funcs);
			_lastFunc = funcs.Last();
			base._002Ector();
		}

		public object? ReturnFor(CallInfo info)
		{
			return GetNext(info);
		}

		public Type TypeOrNull()
		{
			return typeof(T);
		}

		public bool CanBeAssignedTo(Type t)
		{
			return typeof(T).IsAssignableFrom(t);
		}

		private T? GetNext(CallInfo info)
		{
			if (!_funcsToReturn.TryDequeue(out Func<CallInfo, T> result))
			{
				return _lastFunc(info);
			}
			return result(info);
		}
	}
}
