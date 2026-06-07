using System;

namespace UniRx.InternalUtil
{
	internal interface ICancellableTaskCompletionSource
	{
		bool TrySetException(Exception exception);

		bool TrySetCanceled();
	}
}
