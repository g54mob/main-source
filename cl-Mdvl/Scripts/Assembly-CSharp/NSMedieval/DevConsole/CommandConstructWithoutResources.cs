using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.DevConsole
{
	public class CommandConstructWithoutResources : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandConstructWithoutResources()
		{
			Command = "constructWithoutResources";
			Description = "Allows construction without resources.";
			Help = "Use this command to consturuct without resources.";
		}

		private void CommandMethod()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.ConstructWithoutResource = true;
		}
	}
}
