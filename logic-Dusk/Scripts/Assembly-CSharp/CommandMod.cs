public class CommandMod
{
	public string ModType { get; set; }

	public string Description { get; set; }

	public string Example { get; set; }

	public string Symbol { get; set; }

	public CommandMod(string modTypeValue, string description, string example, string symbol)
	{
		ModType = modTypeValue;
		Description = description;
		Example = example;
		Symbol = symbol;
	}
}
