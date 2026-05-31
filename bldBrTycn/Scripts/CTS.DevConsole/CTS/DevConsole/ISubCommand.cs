namespace CTS.DevConsole
{
	public interface ISubCommand
	{
	}
	public interface ISubCommand<T> : ISubCommand where T : ConsoleCommand
	{
	}
}
