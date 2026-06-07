namespace VoxelBusters.CoreLibrary
{
	public delegate void CompletionCallback(bool success, Error error);
	public delegate void CompletionCallback<TResult>(TResult result, Error error);
}
