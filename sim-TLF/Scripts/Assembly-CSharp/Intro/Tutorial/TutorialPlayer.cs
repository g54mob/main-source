using System.Collections.Generic;
using Loxodon.Framework.Contexts;
using Services.Missions;
using Services.Save;
using Services.Save.Missions;
using Services.Save.Player;
using UI.HUD.Assistant;
using UnityEngine;
using Zenject;

namespace Intro.Tutorial
{
	public class TutorialPlayer : MonoBehaviour
	{
		private int _uiStepIndex = -1;

		private List<MissionDefinition> _steps;

		[Inject]
		private IMissionService _missionService;

		[Inject]
		private MissionFactory _missionFactory;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private MissionSaveService _missionSaveService;

		[Inject]
		private PlayerSaveService _playerSaveService;

		private AssistantPopupViewModel _assistantPopupViewModel;

		private void Start()
		{
			if (!_playerSaveService.PlayerData.GameData.TutorialDone)
			{
				_assistantPopupViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
				_missionService.OnMissionCompleted += OnStepCompleted;
			}
		}

		public void StartTutorial()
		{
			_steps = TutorialStepsBuilder.Build(_missionFactory);
			foreach (MissionDefinition step in _steps)
			{
				if (!_missionService.IsActive(step.MissionId) && !_missionService.IsCompleted(step.MissionId))
				{
					_missionService.StartMission(step, ignorePrerequisites: true);
				}
			}
			ShowNextIncompleteStep();
		}

		private void ShowNextIncompleteStep()
		{
			for (int i = _uiStepIndex + 1; i < _steps.Count; i++)
			{
				MissionDefinition missionDefinition = _steps[i];
				if (_missionService.IsCompleted(missionDefinition.MissionId))
				{
					Debug.Log("[Tutorial] Skipping already completed step '" + missionDefinition.MissionId + "'.");
					continue;
				}
				_uiStepIndex = i;
				MissionInstance active = _missionService.GetActive(missionDefinition.MissionId);
				if (active != null)
				{
					UpdateUI(active);
				}
				return;
			}
			OnTutorialCompleted();
		}

		private void OnStepCompleted(MissionInstance mission)
		{
			if (_steps != null)
			{
				int num = _steps.FindIndex((MissionDefinition s) => s.MissionId == mission.MissionId);
				if (num != -1 && num == _uiStepIndex)
				{
					_assistantPopupViewModel.RemoveMission(mission.MissionId);
					_missionSaveService.CompleteMission(mission);
					ShowNextIncompleteStep();
				}
			}
		}

		private void UpdateUI(MissionInstance instance)
		{
			_assistantPopupViewModel.Appear();
			AssistantMissionViewModel missionVM = new AssistantMissionViewModel(instance.MissionId)
			{
				Description = instance.Title
			};
			_assistantPopupViewModel.AddMission(missionVM);
			_assistantPopupViewModel.Folded.Value = false;
			_assistantPopupViewModel.SetSpeechBubbleText(instance.Description);
		}

		private void OnTutorialCompleted()
		{
			_missionService.OnMissionCompleted -= OnStepCompleted;
			Debug.Log("[Tutorial] Tutorial complete!");
			_playerSaveService.PlayerData.GameData.TutorialDone = true;
			foreach (MissionInstance item in _missionService.GetAllActive())
			{
				_missionService.FailMission(item.MissionId);
			}
			_playerSaveService.OnSave();
			_saveService.Save(_missionSaveService.SaveKey);
			_assistantPopupViewModel.Missions.Clear();
		}

		private void OnDestroy()
		{
			if (_missionService != null)
			{
				_missionService.OnMissionCompleted -= OnStepCompleted;
			}
		}
	}
}
