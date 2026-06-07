using System.Collections.Generic;
using CTS.Furnitures;

namespace CTS.DevConsole.Commands
{
	public class CommandPlaceAnywhere : ConsoleCommand
	{
		public override string Command { get; } = "PlaceAnywhere";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count == 0)
			{
				DeveloperConsole.Log($"PlaceAnywhere: {FurniturePlacer.PlaceAnywhere}");
				return;
			}
			if (!(args[0] is bool placeAnywhere))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[True/False]");
			}
			FurniturePlacer.PlaceAnywhere = placeAnywhere;
			DeveloperConsole.Log($"PlaceAnywhere: {FurniturePlacer.PlaceAnywhere}");
		}

		public override string GetCommandDescription()
		{
			return "Sets free placement";
		}
	}
}
