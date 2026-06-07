using System;
using DV.Common;
using DV.Scenarios.Common;
using DV.UIFramework;

namespace DV.UI.PresetEditors
{
	public class ContinueLoadNewController : AUIController
	{
		private AUserProfileProvider userProfileProvider;

		private AScenarioProvider scenariosProvider;

		[NullCheck]
		public ContinueLoadNewControllerSingle career;

		[NullCheck]
		public ContinueLoadNewControllerSingle freeRoam;

		public event Action<ISaveGame> ContinueCareerRequested;

		public event Action<IGameSession> LoadCareerRequested;

		public event Action<UIStartGameData> StartNewCareerRequested;

		public event Action<ISaveGame> ContinueFreeRoamRequested;

		public event Action<IGameSession> LoadFreeRoamRequested;

		public event Action<UIStartGameData> StartNewFreeRoamRequested;

		public event Action<IScenario, ContinueLoadNewControllerSingle> EditScenarioRequested;

		public event Action<IDifficulty, ContinueLoadNewControllerSingle> EditDifficultyRequested;

		public void SetProvider(AUserProfileProvider userProfileProvider, AScenarioProvider scenariosProvider, bool isVR)
		{
			if (this.userProfileProvider != null || this.scenariosProvider != null)
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.userProfileProvider = userProfileProvider;
			this.scenariosProvider = scenariosProvider;
			career.SetProvider(userProfileProvider, scenariosProvider, "Career", isVR);
			freeRoam.SetProvider(userProfileProvider, scenariosProvider, "FreeRoam", isVR);
			RefreshInterface();
		}

		public void RefreshInterface()
		{
			career.RefreshInterface();
			freeRoam.RefreshInterface();
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				career.ContinueRequested += Career_ContinueRequested;
				career.LoadRequested += Career_LoadRequested;
				career.StartNewRequested += Career_StartRequested;
				career.EditDifficultyRequested += OnEditDifficultyRequested;
				career.EditScenarioRequested += OnEditScenarioRequested;
				freeRoam.ContinueRequested += FreeRoam_ContinueRequested;
				freeRoam.LoadRequested += FreeRoam_LoadRequested;
				freeRoam.StartNewRequested += FreeRoam_StartRequested;
				freeRoam.EditDifficultyRequested += OnEditDifficultyRequested;
				freeRoam.EditScenarioRequested += OnEditScenarioRequested;
			}
			else
			{
				career.ContinueRequested -= Career_ContinueRequested;
				career.LoadRequested -= Career_LoadRequested;
				career.StartNewRequested -= Career_StartRequested;
				career.EditDifficultyRequested -= OnEditDifficultyRequested;
				career.EditScenarioRequested -= OnEditScenarioRequested;
				freeRoam.ContinueRequested -= FreeRoam_ContinueRequested;
				freeRoam.LoadRequested -= FreeRoam_LoadRequested;
				freeRoam.StartNewRequested -= FreeRoam_StartRequested;
				freeRoam.EditDifficultyRequested -= OnEditDifficultyRequested;
				freeRoam.EditScenarioRequested -= OnEditScenarioRequested;
			}
		}

		private void Career_ContinueRequested(ISaveGame saveGame)
		{
			this.ContinueCareerRequested?.Invoke(saveGame);
		}

		private void Career_LoadRequested(IGameSession session)
		{
			this.LoadCareerRequested?.Invoke(session);
		}

		private void Career_StartRequested(UIStartGameData data)
		{
			this.StartNewCareerRequested?.Invoke(data);
		}

		private void FreeRoam_ContinueRequested(ISaveGame saveGame)
		{
			this.ContinueFreeRoamRequested?.Invoke(saveGame);
		}

		private void FreeRoam_LoadRequested(IGameSession session)
		{
			this.LoadFreeRoamRequested?.Invoke(session);
		}

		private void FreeRoam_StartRequested(UIStartGameData data)
		{
			this.StartNewFreeRoamRequested?.Invoke(data);
		}

		private void OnEditScenarioRequested(IScenario s, ContinueLoadNewControllerSingle eventSource)
		{
			this.EditScenarioRequested?.Invoke(s, eventSource);
		}

		private void OnEditDifficultyRequested(IDifficulty d, ContinueLoadNewControllerSingle eventSource)
		{
			this.EditDifficultyRequested?.Invoke(d, eventSource);
		}
	}
}
