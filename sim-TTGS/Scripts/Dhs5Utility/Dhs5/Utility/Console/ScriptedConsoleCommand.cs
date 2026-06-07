using System.Collections.Generic;
using System.Linq;

namespace Dhs5.Utility.Console
{
	public class ScriptedConsoleCommand : IConsoleCommand
	{
		private readonly List<ConsoleCommandPiece> m_commandPieces;

		public ConsoleCommandPiece this[int index] => m_commandPieces[index];

		public int Count => m_commandPieces.Count;

		public ValidCommandCallback Callback => OnCommandValidated;

		public ScriptedConsoleCommand(params ConsoleCommandPiece[] commandPieces)
		{
			m_commandPieces = commandPieces.ToList();
		}

		public ScriptedConsoleCommand(string singleInput)
		{
			m_commandPieces = new List<ConsoleCommandPiece>();
			m_commandPieces.Add(new ConsoleCommandPiece(optional: false, singleInput));
		}

		protected virtual void OnCommandValidated(ValidCommand validCommand)
		{
		}
	}
}
