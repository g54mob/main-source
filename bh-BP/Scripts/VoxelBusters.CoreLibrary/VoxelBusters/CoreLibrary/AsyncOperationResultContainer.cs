namespace VoxelBusters.CoreLibrary
{
	public class AsyncOperationResultContainer<TData, TError> : IAsyncOperationResultContainer, IAsyncOperationResultContainer<TData, TError> where TError : Error
	{
		private TData m_data;

		private TError m_error;

		protected void SetDataInternal(TData data)
		{
		}

		protected void SetErrorInternal(TError error)
		{
		}

		public bool IsError()
		{
			return false;
		}

		public string GetErrorDescription()
		{
			return null;
		}

		Error IAsyncOperationResultContainer.GetError()
		{
			return null;
		}

		object IAsyncOperationResultContainer.GetData()
		{
			return null;
		}

		public string GetDataAsText()
		{
			return null;
		}

		public TError GetError()
		{
			return null;
		}

		public TData GetData()
		{
			return default(TData);
		}
	}
}
