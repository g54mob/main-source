using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandMapLoad : ConsoleCommand, ISubCommand<CommandMap>, ISubCommand
	{
		public override string Command => "Load";

		public override bool CanHaveNoArguments => false;

		public override bool EnableHelpCommand => true;

		public override object[] ArgumentTypes { get; } = new object[5]
		{
			EArgType.String,
			EArgType.String,
			EArgType.String,
			EArgType.String,
			EArgType.String
		};

		public override string GetCommandDescription()
		{
			return "Load a saved map file by his name, use Command /Map List for get all files by names";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count < 1)
			{
				throw ConsoleCommand.ErrorBadNumberOfArguments();
			}
			string text = "";
			for (int i = 0; i < args.Count; i++)
			{
				if (!(args[i] is string))
				{
					throw ConsoleCommand.ErrorBadArgument(rawArgs[i], "[String]");
				}
				text = text + ((i != 0) ? " " : "") + (string)args[i];
			}
			if (new List<string>(MapLoader.GetFilesNames()).Contains(text))
			{
				MapLoader.LoadMap(text);
				DeveloperConsole.Log("Load : " + text);
			}
			else
			{
				DeveloperConsole.Log("Fail to found file : " + text);
			}
		}
	}
}
