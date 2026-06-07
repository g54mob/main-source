using System;

namespace Cysharp.Threading.Tasks
{
	public readonly struct WhenEachResult<T>
	{
		public T Result { get; }

		public Exception Exception { get; }

		public bool IsCompletedSuccessfully => false;

		public bool IsFaulted => false;

		public WhenEachResult(T result)
		{
			Result = default(T);
			Exception = null;
		}

		public WhenEachResult(Exception exception)
		{
			Result = default(T);
			Exception = null;
		}

		public void TryThrow()
		{
		}

		public T GetResult()
		{
			return default(T);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
