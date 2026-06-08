using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class LeaderboardManager : ScriptableObject
	{
		[SerializeField]
		public List<LeaderboardType> allLeaderboards;

		[SerializeField]
		private List<GameMode> allGameModes;

		private Dictionary<GameModeId, GameMode> gameModeById;

		public event Action<LeaderboardType> OnRequestShowLeaderboardOverlay;

		public LeaderboardType GetCurrentLeaderboard(bool initial = false)
		{
			if (gameModeById == null)
			{
				gameModeById = new Dictionary<GameModeId, GameMode>();
				foreach (GameMode allGameMode in allGameModes)
				{
					gameModeById.Add(allGameMode.id, allGameMode);
				}
			}
			return (((bool)OverwritingSingleton<GameSession>.Instance && !initial) ? OverwritingSingleton<GameSession>.Instance.GameMode : gameModeById[(GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 0)]).GetLeaderboard();
		}

		public void RequestShowLeaderboard()
		{
			this.OnRequestShowLeaderboardOverlay?.Invoke(GetCurrentLeaderboard());
		}
	}
}
