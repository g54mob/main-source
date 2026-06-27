using Helpers.Extensions;
using Restory.Data.GameConfigs;
using UnityEngine;
using Zenject;

namespace Restory.Data.SaveLoad
{
	public class SaveFileCompatibilityChecker : IInitializable
	{
		private readonly GameConfig gameConfig;

		private readonly SaveFileVersionReader saveFileVersionReader;

		private int currentGameVersionNumber;

		private int minimalSupportedGameVersionNumber;

		[Inject]
		public SaveFileCompatibilityChecker(GameConfig gameConfig, SaveFileVersionReader saveFileVersionReader)
		{
			this.gameConfig = gameConfig;
			this.saveFileVersionReader = saveFileVersionReader;
		}

		public void Initialize()
		{
			currentGameVersionNumber = Application.version.GameVersionNumber();
			minimalSupportedGameVersionNumber = gameConfig.MinimalSupportedSaveFileVersion.GameVersionNumber();
			if (minimalSupportedGameVersionNumber <= 0)
			{
				Debug.LogError("Not valid minimal supported save file version " + gameConfig.MinimalSupportedSaveFileVersion + ". It is number presentation should be greater than zero," + $" but it is {minimalSupportedGameVersionNumber}.");
			}
			else if (minimalSupportedGameVersionNumber > currentGameVersionNumber)
			{
				Debug.LogError("Not valid minimal supported save file version " + gameConfig.MinimalSupportedSaveFileVersion + ". It is greater than current application version " + Application.version + ".");
			}
		}

		public bool CheckSaveFileCompatibility(string filePath)
		{
			int num = saveFileVersionReader.ReadSaveFileVersion(filePath);
			if (num == 0)
			{
				Debug.LogWarning("Save file [" + filePath + "] is damaged or not compatible.");
				return false;
			}
			if (num < minimalSupportedGameVersionNumber)
			{
				Debug.LogWarning($"Save file [{filePath}] version number is {num}," + $" but minimal supported save file version number is {minimalSupportedGameVersionNumber}");
				return false;
			}
			if (num > currentGameVersionNumber)
			{
				Debug.LogWarning($"Save file [{filePath}] version number is {num}," + $" it is greater than current game version number {currentGameVersionNumber}");
				return false;
			}
			return true;
		}
	}
}
