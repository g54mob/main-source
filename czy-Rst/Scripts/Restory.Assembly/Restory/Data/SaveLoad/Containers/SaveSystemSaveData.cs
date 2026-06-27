using FullSerializer;
using Restory.Data.Locations;

namespace Restory.Data.SaveLoad.Containers
{
	[fsObject(VersionString = "SaveSystemSaveDataV01")]
	public class SaveSystemSaveData
	{
		public long CreationDate;

		public string GameVersion;

		public int Iteration;

		public GameMode GameMode;

		public GameplayProgressSaveData GameplayState = new GameplayProgressSaveData();

		public long TotalPlayTime;

		public bool HasData;
	}
}
