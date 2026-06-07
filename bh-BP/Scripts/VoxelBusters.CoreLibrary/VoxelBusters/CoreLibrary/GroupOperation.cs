namespace VoxelBusters.CoreLibrary
{
	public class GroupOperation : AsyncOperation<object>
	{
		private int m_operationCount;

		private bool m_abortOnError;

		public IAsyncOperation[] Operations { get; private set; }

		public GroupOperation(bool abortOnError = false, params IAsyncOperation[] operations)
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

		private void UpdateProgress()
		{
		}

		private void AbortActiveOperations()
		{
		}
	}
}
