using System;
using System.Threading.Tasks;
using Restory.Data.Locations;

namespace Restory.Gameplay.SaveLoad.Services
{
	public interface IGameplaySaveLoadService
	{
		DateTime LastSaveDateTime { get; }

		bool IsSaving { get; }

		bool IsSaveAllowed { get; }

		event Action OnSaveBegin;

		event Action OnSaveCompleted;

		event Action OnLoadBegin;

		event Action OnLoadCompleted;

		event Action OnSaveNotFound;

		void SaveProgressAsync(Action onComplete = null);

		Task SaveProgressAsync(GameMode forGameMode, Action onComplete = null);

		void LoadProgressAsync(GameScenesPreset preset, Action onComplete = null);
	}
}
