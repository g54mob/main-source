using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class GameModeLibrary : ScriptableObject
	{
		[SerializeField]
		private List<GameMode> allGameModes;

		private Dictionary<GameModeId, GameMode> gameModeById;

		public GameMode GetGameModeById(GameModeId gameModeId)
		{
			if (gameModeById == null || !gameModeById.ContainsKey(gameModeId))
			{
				SetupGameModeDictionary();
			}
			return gameModeById[gameModeId];
		}

		private void SetupGameModeDictionary()
		{
			gameModeById = new Dictionary<GameModeId, GameMode>();
			foreach (GameMode allGameMode in allGameModes)
			{
				gameModeById.Add(allGameMode.id, allGameMode);
			}
		}
	}
}
