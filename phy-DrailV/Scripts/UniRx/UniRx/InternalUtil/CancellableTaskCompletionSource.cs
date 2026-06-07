using System;
using System.Threading.Tasks;

namespace UniRx.InternalUtil
{
	internal class CancellableTaskCompletionSource<T> : TaskCompletionSource<T>, ICancellableTaskCompletionSource
	{
		bool ICancellableTaskCompletionSource.TrySetException(Exception exception)
		{
			return TrySetException(exception);
		}

		bool ICancellableTaskCompletionSource.TrySetCanceled()
		{
			return TrySetCanceled();
		}
	}
}
