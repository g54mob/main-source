using System;
using System.Collections.Generic;

namespace Player.Customization.Sidekick
{
	[Serializable]
	public class SidekickSaveData
	{
		[Serializable]
		public class PartEntry
		{
			public int partType;

			public string partName;

			public PartEntry()
			{
			}

			public PartEntry(int partType, string partName)
			{
			}
		}

		[Serializable]
		public class ColorEntry
		{
			public int colorPropertyId;

			public string mainColor;

			public string metallic;

			public string smoothness;

			public string reflection;

			public string emission;

			public string opacity;
		}

		public string characterName;

		public int speciesId;

		public float bodyType;

		public float bodySize;

		public float muscles;

		public List<PartEntry> parts;

		public List<ColorEntry> colors;

		public int colorPresetIndex;

		public static SidekickSaveData CreateDefault()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}

		public static SidekickSaveData FromJson(string json)
		{
			return null;
		}

		public string GetPart(int partType)
		{
			return null;
		}

		public void SetPart(int partType, string partName)
		{
		}
	}
}
