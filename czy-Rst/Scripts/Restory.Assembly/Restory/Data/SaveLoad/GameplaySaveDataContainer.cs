using Restory.Data.SaveLoad.Containers;

namespace Restory.Data.SaveLoad
{
	public class GameplaySaveDataContainer
	{
		public SaveSystemSaveData GameData { get; private set; }

		public byte[] TextureData { get; private set; }

		public GameplaySaveDataContainer(SaveSystemSaveData gameData, byte[] textureData)
		{
			GameData = gameData;
			TextureData = textureData;
		}
	}
}
