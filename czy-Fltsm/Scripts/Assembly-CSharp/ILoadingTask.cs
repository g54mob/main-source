public interface ILoadingTask
{
	int Weight { get; }

	string DebugId { get; }

	bool YieldReturnNull => false;

	bool Run();
}
