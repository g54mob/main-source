using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace R3
{
	internal struct CompleteState
	{
		internal enum ResultStatus
		{
			Done = 0,
			AlreadySuccess = 1,
			AlreadyFailed = 2
		}

		private const int NotCompleted = 0;

		private const int CompletedSuccess = 1;

		private const int CompletedFailure = 2;

		private const int Disposed = 3;

		private int completeState;

		private Exception? error;

		public bool IsCompleted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				switch (completeState)
				{
				case 0:
					return false;
				case 1:
					return true;
				case 2:
					return true;
				case 3:
					ThrowObjectDiposedException();
					break;
				}
				return false;
			}
		}

		public bool IsDisposed => Volatile.Read(ref completeState) == 3;

		public bool IsCompletedOrDisposed
		{
			get
			{
				int num = Volatile.Read(ref completeState);
				if (num != 3 && num != 1)
				{
					return num == 2;
				}
				return true;
			}
		}

		public ResultStatus TrySetResult(Result result)
		{
			int num;
			if (result.IsSuccess)
			{
				num = Interlocked.CompareExchange(ref completeState, 1, 0);
			}
			else
			{
				num = Interlocked.CompareExchange(ref completeState, 2, 0);
				Volatile.Write(ref error, result.Exception);
			}
			switch (num)
			{
			case 0:
				return ResultStatus.Done;
			case 1:
				return ResultStatus.AlreadySuccess;
			case 2:
				return ResultStatus.AlreadyFailed;
			case 3:
				ThrowObjectDiposedException();
				break;
			}
			return ResultStatus.Done;
		}

		public bool TrySetDisposed(out bool alreadyCompleted)
		{
			switch (Interlocked.Exchange(ref completeState, 3))
			{
			case 0:
				alreadyCompleted = false;
				return true;
			case 1:
			case 2:
				alreadyCompleted = true;
				return true;
			default:
				alreadyCompleted = false;
				return false;
			}
		}

		public Result? TryGetResult()
		{
			switch (Volatile.Read(ref completeState))
			{
			case 0:
				return null;
			case 1:
				return Result.Success;
			case 2:
				return Result.Failure(GetException());
			case 3:
				ThrowObjectDiposedException();
				break;
			}
			return null;
		}

		private Exception GetException()
		{
			Exception ex = Volatile.Read(ref error);
			if (ex != null)
			{
				return ex;
			}
			SpinWait spinWait = default(SpinWait);
			do
			{
				spinWait.SpinOnce();
				ex = Volatile.Read(ref error);
			}
			while (ex == null);
			return ex;
		}

		private static void ThrowObjectDiposedException()
		{
			throw new ObjectDisposedException("");
		}
	}
}
