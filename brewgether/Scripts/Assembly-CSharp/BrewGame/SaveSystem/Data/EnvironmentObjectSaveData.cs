using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class EnvironmentObjectSaveData
	{
		public string objectId;

		public string objectType;

		public bool isOpen;

		public string additionalData;
	}
}
