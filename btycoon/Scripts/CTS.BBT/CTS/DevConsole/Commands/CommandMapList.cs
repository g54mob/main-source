using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandMapList : ConsoleCommand, ISubCommand<CommandMap>, ISubCommand
	{
		public override string Command => "List";

		public override bool CanHaveNoArguments => true;

		public override bool EnableHelpCommand => true;

		public override object[] ArgumentTypes => null;

		public override string GetCommandDescription()
		{
			return "Get all saved map file list";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			List<string> list = new List<string>(MapLoader.GetFilesNames());
			DeveloperConsole.Log($"Files count : {list.Count}");
			for (int i = 0; i < list.Count; i++)
			{
				DeveloperConsole.Log(" - File name : " + list[i]);
			}
		}
	}
}
