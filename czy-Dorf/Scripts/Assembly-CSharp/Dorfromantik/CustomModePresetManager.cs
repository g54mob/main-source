using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class CustomModePresetManager : ScriptableObject
	{
		[SerializeField]
		private List<GameModePreset> allPresets;

		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		private Dictionary<GameModePresetId, GameModePreset> presetById;

		private Dictionary<int, Dictionary<int, string>> configStringByYearAndMonth = new Dictionary<int, Dictionary<int, string>> { 
		{
			2022,
			new Dictionary<int, string>
			{
				{ 1, "00000" },
				{ 2, "00001" },
				{ 3, "00002" },
				{ 4, "00003" },
				{ 5, "00004" },
				{ 6, "00005" },
				{ 7, "00006" },
				{ 8, "00007" },
				{ 9, "00008" },
				{ 10, "00009" },
				{ 11, "00010" },
				{ 12, "00011" }
			}
		} };

		private GameMode _003CCurrentGameModePreset_003Ek__BackingField;

		public GameMode CurrentGameModePreset
		{
			get
			{
				return _003CCurrentGameModePreset_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentGameModePreset_003Ek__BackingField = value;
			}
		}

		public void SetCurrentPreset(GameMode gameMode)
		{
		}

		public GameModePreset GetPreset(GameModePresetId id)
		{
			if (presetById == null)
			{
				presetById = new Dictionary<GameModePresetId, GameModePreset>();
				foreach (GameModePreset allPreset in allPresets)
				{
					presetById.Add(allPreset.id, allPreset);
				}
			}
			return presetById[id];
		}
	}
}
