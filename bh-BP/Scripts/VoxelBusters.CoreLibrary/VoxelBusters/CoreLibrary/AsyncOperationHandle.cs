using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace VoxelBusters.CoreLibrary
{
	public class AsyncOperationHandle<T> : IAsyncOperationHandle<T>, IAsyncOperationHandle, IEnumerator, IEquatable<AsyncOperationHandle<T>>
	{
		public IAsyncOperation<T> InternalOp { get; private set; }

		public AsyncOperationStatus Status => default(AsyncOperationStatus);

		public bool IsDone => false;

		public float Progress => 0f;

		object IAsyncOperationHandle.Result => null;

		public Error Error => null;

		public T Result => default(T);

		public object Current => null;

		private event Callback<IAsyncOperationHandle> OnProgressTypeless
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private event Callback<IAsyncOperationHandle> OnCompleteTypeless
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		event Callback<IAsyncOperationHandle> IAsyncOperationHandle.OnProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		event Callback<IAsyncOperationHandle> IAsyncOperationHandle.OnComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Callback<IAsyncOperationHandle<T>> OnProgress
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Callback<IAsyncOperationHandle<T>> OnComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public AsyncOperationHandle(IAsyncOperation<T> op)
		{
		}

		private void RegisterForCallbacks()
		{
		}

		private void UnregisterCallbacks()
		{
		}

		private void HandleOnProgress(IAsyncOperation<T> asyncOperation)
		{
		}

		private void HandleOnComplete(IAsyncOperation<T> asyncOperation)
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}

		public bool Equals(AsyncOperationHandle<T> other)
		{
			return false;
		}
	}
}
