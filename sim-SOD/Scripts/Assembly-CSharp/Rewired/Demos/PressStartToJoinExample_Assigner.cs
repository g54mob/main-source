using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class PressStartToJoinExample_Assigner : MonoBehaviour
	{
		private class PlayerMap
		{
			public int rewiredPlayerId;

			public int gamePlayerId;

			public PlayerMap(int rewiredPlayerId, int gamePlayerId)
			{
			}
		}

		private static PressStartToJoinExample_Assigner instance;

		public int maxPlayers;

		private List<PlayerMap> playerMap;

		private int gamePlayerIdCounter;

		public static Player GetRewiredPlayer(int gamePlayerId)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void AssignNextPlayer(int rewiredPlayerId)
		{
		}

		private int GetNextGamePlayerId()
		{
			return 0;
		}
	}
}
