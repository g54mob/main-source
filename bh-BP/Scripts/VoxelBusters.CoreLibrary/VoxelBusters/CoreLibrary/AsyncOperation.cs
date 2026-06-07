using System.Collections;
using System.Runtime.CompilerServices;

namespace VoxelBusters.CoreLibrary
{
	[IncludeInDocs]
	public abstract class AsyncOperation<T> : IAsyncOperation, IEnumerator, IAsyncOperation<T>, IAsyncOperationUpdateHandler
	{
		public AsyncOperationStatus Status { get; private set; }

		public bool IsDone { get; private set; }

		object IAsyncOperation.Result => null;

		public Error Error { get; private set; }

		public float Progress { get; protected set; }

		public T Result { get; private set; }

		object IEnumerator.Current => null;

		private event Callback<IAsyncOperation> OnProgressTypeless
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

		private event Callback<IAsyncOperation> OnCompleteTypeless
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

		event Callback<IAsyncOperation> IAsyncOperation.OnProgress
		{
			add
			{
			}
			remove
			{
			}
		}

		event Callback<IAsyncOperation> IAsyncOperation.OnComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Callback<IAsyncOperation<T>> OnProgress
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

		public event Callback<IAsyncOperation<T>> OnComplete
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

		public void Start()
		{
		}

		public void Abort()
		{
		}

		private bool IsCurrentStatus(AsyncOperationStatus status)
		{
			return false;
		}

		private void SetStarted()
		{
		}

		protected virtual void SetIsCompleted(T result = default(T))
		{
		}

		protected virtual void SetIsCompleted(Error error)
		{
		}

		private void SetIsCompletedInternal(T result, Error error, AsyncOperationStatus status)
		{
		}

		private void SendProgressEvent()
		{
		}

		private void SendCompleteEvent()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnEnd()
		{
		}

		protected virtual void OnAbort()
		{
		}

		bool IEnumerator.MoveNext()
		{
			return false;
		}

		public virtual void Reset()
		{
		}

		void IAsyncOperationUpdateHandler.Update()
		{
		}
	}
}
