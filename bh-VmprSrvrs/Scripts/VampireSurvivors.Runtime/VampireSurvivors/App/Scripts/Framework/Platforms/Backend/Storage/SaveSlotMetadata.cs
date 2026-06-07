using System;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage
{
	[Serializable]
	public class SaveSlotMetadata
	{
		public int slot;

		public string platformSavedOn;

		public SaveSlotMetadata(int slot, string platformSavedOn)
		{
		}

		public static string ToJSON(SaveSlotMetadata instance)
		{
			return null;
		}

		public static SaveSlotMetadata FromJSON(string json)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
