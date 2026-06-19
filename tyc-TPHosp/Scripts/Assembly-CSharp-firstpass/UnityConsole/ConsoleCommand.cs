namespace UnityConsole
{
	public struct ConsoleCommand
	{
		public string Name { get; private set; }

		public string Description { get; private set; }

		public string Usage { get; private set; }

		public ConsoleCommandCallback Callback { get; private set; }

		public ConsoleCommand(string name, string description, string usage, ConsoleCommandCallback callback)
		{
			this = default(ConsoleCommand);
			Name = name;
			Description = (string.IsNullOrEmpty(description.Trim()) ? "No description provided" : description);
			Usage = (string.IsNullOrEmpty(usage.Trim()) ? "No usage information provided" : usage);
			Callback = callback;
		}
	}
}
