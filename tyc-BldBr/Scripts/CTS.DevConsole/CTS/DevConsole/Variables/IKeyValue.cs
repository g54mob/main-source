namespace CTS.DevConsole.Variables
{
	internal interface IKeyValue<T>
	{
		T Key { get; set; }

		ConsoleVarValue Value { get; set; }
	}
}
