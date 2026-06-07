namespace VoxelBusters.CoreLibrary
{
	public interface ICommand
	{
		bool IsDone { get; }

		Error Error { get; }

		void Execute();
	}
}
