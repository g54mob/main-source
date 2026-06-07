using Dhs5.Utility.Console;
using Simulator.GameWorld;
using Tabletop.GameWorld;

namespace Tabletop
{
	public class SCC_UnpackMiniatures : ScriptedConsoleCommand
	{
		public SCC_UnpackMiniatures()
			: base(new ConsoleCommandPiece(optional: false, "/unpack"), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			if (ProductDatabase.Get(38) is MiniatureBoxProductData miniatureProductData)
			{
				for (int i = 0; i < (int)validCommand.parameters[1]; i++)
				{
					Collection.Unpack(miniatureProductData);
				}
			}
		}
	}
}
