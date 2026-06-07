using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_Delivery : ScriptedConsoleCommand
	{
		public SCC_Delivery()
			: base(new ConsoleCommandPiece(optional: false, "/deliver"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			World.DeliverySystem.Deliver((int)validCommand.parameters[1]);
		}
	}
}
