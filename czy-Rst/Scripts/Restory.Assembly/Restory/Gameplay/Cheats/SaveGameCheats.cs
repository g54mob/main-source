using System.ComponentModel;
using Restory.Gameplay.SaveLoad.Services;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class SaveGameCheats : SRDebugCheatBase
	{
		private readonly SaveGameExecutor saveGameExecutor;

		private const string COMMON_CATEGORY = "SaveLoad Game Cheats";

		[Category("SaveLoad Game Cheats")]
		[DisplayName("Save")]
		public void SaveGame()
		{
			saveGameExecutor.SaveGame();
		}

		[Inject]
		public SaveGameCheats(SaveGameExecutor saveGameExecutor)
		{
			this.saveGameExecutor = saveGameExecutor;
		}
	}
}
