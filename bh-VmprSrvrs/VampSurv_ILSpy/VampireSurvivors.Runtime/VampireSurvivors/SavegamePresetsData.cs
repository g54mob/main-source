using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A491A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Name = "";
			Description = "";
			Savegame = "";
			Name = name;
			Savegame = savegame;
			Description = description;
		}
	}

	public List<SavegamePreset> Presets;
}
