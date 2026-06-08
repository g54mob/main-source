namespace KitchenEditor
{
	public interface IProcessResultNode : IGameDataReference
	{
		ProcessConnection SourceProcesses { get; }
	}
}
