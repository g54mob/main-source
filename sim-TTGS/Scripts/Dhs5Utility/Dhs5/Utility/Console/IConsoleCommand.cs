namespace Dhs5.Utility.Console
{
	public interface IConsoleCommand
	{
		int Count { get; }

		ConsoleCommandPiece this[int index] { get; }

		bool IsValid()
		{
			return Count > 0;
		}
	}
}
