using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Console
{
	[CreateAssetMenu(fileName = "CCMD_", menuName = "Dhs5 Utility/Console/Command")]
	public class ConsoleCommandObject : ScriptableObject, IConsoleCommand
	{
		[SerializeField]
		private List<ConsoleCommandPiece> m_commandPieces;

		public int Count => m_commandPieces.Count;

		public ConsoleCommandPiece this[int index] => m_commandPieces[index];

		protected void SetCommandPieces(List<ConsoleCommandPiece> commandPieces)
		{
			if (m_commandPieces == null)
			{
				m_commandPieces = new List<ConsoleCommandPiece>();
			}
			else
			{
				m_commandPieces.Clear();
			}
			m_commandPieces.AddRange(commandPieces);
		}
	}
}
