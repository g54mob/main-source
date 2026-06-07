using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_ShopExtension : ScriptedConsoleCommand
	{
		public SCC_ShopExtension()
			: base(new ConsoleCommandPiece(optional: false, "/shop extension"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			ShopExtensionSystem.SetShopExtensionLevel((int)validCommand.parameters[1], triggerCallback: true);
		}
	}
}
