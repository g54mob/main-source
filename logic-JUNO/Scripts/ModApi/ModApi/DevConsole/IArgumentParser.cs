namespace ModApi.DevConsole
{
	public interface IArgumentParser<T>
	{
		string HelpMessage { get; }

		int Priority { get; }

		bool TryParse(string value, out T result);
	}
}
