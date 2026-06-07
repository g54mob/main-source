namespace VoxelBusters.CoreLibrary
{
	public interface IOperationResultContainer<TData>
	{
		bool IsError();

		Error GetError();

		TData GetResult();

		string GetResultAsText();
	}
}
