using Dhs5.Utility.Console;
using UnityEngine;

namespace Simulator
{
	public class SCC_Timescale : ScriptedConsoleCommand
	{
		public SCC_Timescale()
			: base(new ConsoleCommandPiece(optional: false, "/timescale"), new ConsoleCommandPiece(ParamType.FLOAT))
		{
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			Time.timeScale = (float)validCommand.parameters[1];
		}
	}
}
