using System.Collections;

namespace VoxelBusters.CoreLibrary
{
	public interface IAsyncOperation : IEnumerator
	{
		AsyncOperationStatus Status { get; }

		bool IsDone { get; }

		object Result { get; }

		Error Error { get; }

		float Progress { get; }

		event Callback<IAsyncOperation> OnProgress;

		event Callback<IAsyncOperation> OnComplete;

		void Start();

		void Abort();
	}
	public interface IAsyncOperation<T> : IAsyncOperation, IEnumerator
	{
		new T Result { get; }

		new event Callback<IAsyncOperation<T>> OnProgress;

		new event Callback<IAsyncOperation<T>> OnComplete;
	}
}
