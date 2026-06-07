using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_ReserveExtension : ScriptedConsoleCommand
	{
		public SCC_ReserveExtension()
			: base(new ConsoleCommandPiece(optional: false, "/reserve extension"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			ShopExtensionSystem.SetReserveExtensionLevel((int)validCommand.parameters[1], triggerCallback: true);
		}
	}
}
