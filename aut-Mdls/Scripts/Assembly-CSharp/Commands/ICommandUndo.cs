namespace Commands
{
	public interface ICommandUndo : ICommand
	{
		bool TryReDo();

		bool TryUnDo();
	}
}
