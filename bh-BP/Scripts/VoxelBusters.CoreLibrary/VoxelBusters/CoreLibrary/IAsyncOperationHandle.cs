using System.Collections;

namespace VoxelBusters.CoreLibrary
{
	public interface IAsyncOperationHandle : IEnumerator
	{
		AsyncOperationStatus Status { get; }

		bool IsDone { get; }

		object Result { get; }

		Error Error { get; }

		float Progress { get; }

		event Callback<IAsyncOperationHandle> OnProgress;

		event Callback<IAsyncOperationHandle> OnComplete;
	}
	public interface IAsyncOperationHandle<T> : IAsyncOperationHandle, IEnumerator
	{
		new T Result { get; }

		new event Callback<IAsyncOperationHandle<T>> OnProgress;

		new event Callback<IAsyncOperationHandle<T>> OnComplete;
	}
}
