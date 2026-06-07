using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors
{
	public class SavegamePresetsData : ScriptableObject
	{
		[Serializable]
		public class SavegamePreset
		{
			public string Name;

			public string Description;

			public string Savegame;

			public SavegamePreset(string name, string description, string savegame)
			{
			}
		}

		public List<SavegamePreset> Presets;
	}
}
