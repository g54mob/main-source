namespace VoxelBusters.CoreLibrary
{
	public class ChainedOperation : AsyncOperation<object>
	{
		private int m_operationCount;

		private bool m_abortOnError;

		private IAsyncOperation m_activeOperation;

		private int m_activeOperationIndex;

		public IAsyncOperation[] Operations { get; private set; }

		public ChainedOperation(bool abortOnError = false, params IAsyncOperation[] operations)
		{
		}

		public override void Reset()
		{
		}

		protected override void OnStart()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void SetIsCompleted(object result)
		{
		}

		protected override void SetIsCompleted(Error error)
		{
		}

		private bool StartOperation(int index)
		{
			return false;
		}

		private void UpdateProgress()
		{
		}
	}
}
