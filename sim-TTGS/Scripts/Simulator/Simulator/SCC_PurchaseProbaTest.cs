using Dhs5.Utility.Console;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	public class SCC_PurchaseProbaTest : ScriptedConsoleCommand
	{
		public SCC_PurchaseProbaTest()
			: base(new ConsoleCommandPiece(optional: false, "/purchase"), new ConsoleCommandPiece(ParamType.FLOAT), new ConsoleCommandPiece(ParamType.INT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Debug.Log("Purchase proba with market price percentage = " + validCommand.parameters[1]?.ToString() + " and iteration = " + validCommand.parameters[2]?.ToString() + "\n" + (AIClientSettings.GetBuyProductProbability((float)validCommand.parameters[1]) - (float)(int)validCommand.parameters[2] * AIClientSettings.ProbaReducingPerIteration));
		}
	}
}
