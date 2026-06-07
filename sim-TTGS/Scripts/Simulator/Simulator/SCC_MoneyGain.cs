using Dhs5.Utility.Console;
using Simulator.GameWorld;

namespace Simulator
{
	public class SCC_MoneyGain : ScriptedConsoleCommand
	{
		public SCC_MoneyGain()
			: base(new ConsoleCommandPiece(optional: false, "/money"), new ConsoleCommandPiece(ParamType.FLOAT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			float num = (float)validCommand.parameters[1];
			if (num >= 0f)
			{
				World.GameState.GainMoney(num);
			}
			else
			{
				World.GameState.ConsumeMoney(0f - num);
			}
		}
	}
}
