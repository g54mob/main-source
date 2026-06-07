using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Console
{
	[CreateAssetMenu(fileName = "PCC_Timescale", menuName = "Dhs5 Utility/Console/Predefined Commands/Timescale")]
	public class PCC_Timescale : PredefinedConsoleCommand
	{
		protected override List<ConsoleCommandPiece> OnCreateCommand()
		{
			return new List<ConsoleCommandPiece>
			{
				new ConsoleCommandPiece(optional: false, "/timescale"),
				new ConsoleCommandPiece(ParamType.FLOAT)
			};
		}

		protected override void OnCommandValidated(ValidCommand validCommand)
		{
			if (validCommand.parameters.Length == 2 && validCommand.parameters[1] is float b)
			{
				Time.timeScale = Mathf.Max(0f, b);
			}
		}
	}
}
