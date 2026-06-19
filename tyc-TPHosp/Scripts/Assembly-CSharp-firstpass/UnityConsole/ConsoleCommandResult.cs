namespace UnityConsole
{
	public struct ConsoleCommandResult
	{
		public bool succeeded;

		public string Output;

		public static ConsoleCommandResult Failed(string output = null)
		{
			return new ConsoleCommandResult
			{
				succeeded = false,
				Output = output
			};
		}

		public static ConsoleCommandResult Succeeded(string output = null)
		{
			return new ConsoleCommandResult
			{
				succeeded = true,
				Output = output
			};
		}
	}
}
