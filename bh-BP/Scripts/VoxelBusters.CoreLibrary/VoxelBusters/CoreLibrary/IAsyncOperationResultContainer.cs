namespace VoxelBusters.CoreLibrary
{
	public interface IAsyncOperationResultContainer
	{
		bool IsError();

		string GetErrorDescription();

		Error GetError();

		object GetData();

		string GetDataAsText();
	}
	public interface IAsyncOperationResultContainer<TData, TError> : IAsyncOperationResultContainer where TError : Error
	{
		new TError GetError();

		new TData GetData();
	}
}
