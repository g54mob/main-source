using System.Collections.Generic;
using Loxodon.Framework.Contexts;
using Services.Missions;
using UI.HUD.Assistant;
using UnityEngine;
using Zenject;

public class TestTutorial : MonoBehaviour
{
	[Inject]
	private IMissionService _missionService;

	[Inject]
	private MissionEventBus _missionEventBus;

	private AssistantPopupViewModel _assistantPopupViewModel;

	private void Start()
	{
		_assistantPopupViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
	}

	private void OnEnable()
	{
		_missionService.OnMissionCompleted += MissionCompleted;
	}

	private void MissionCompleted(MissionInstance instance)
	{
		Debug.Log(instance.MissionId + " Completed.");
		_assistantPopupViewModel.RemoveMission(instance.MissionId);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			StartTestMission();
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			CompleteMission();
		}
	}

	public void CompleteMission()
	{
		_missionEventBus.Emit("collect", "table");
	}

	public void StartTestMission()
	{
		MissionDefinition missionDefinition = new MissionDefinition
		{
			MissionId = "Tutorial_0",
			Description = "Build Table",
			Title = "Tutorial Step One",
			Objectives = new List<ObjectiveDefinition>
			{
				new ObjectiveDefinition
				{
					Type = ObjectiveType.Collect,
					ObjectiveId = "table",
					TargetId = "table",
					RequiredAmount = 1
				}
			}
		};
		AssistantMissionViewModel missionVM = new AssistantMissionViewModel(missionDefinition.MissionId)
		{
			Completed = false,
			ObjectiveCount = 0
		};
		_missionService.StartMission(missionDefinition);
		_assistantPopupViewModel.AddMission(missionVM);
		_assistantPopupViewModel.Closed.Value = false;
		_assistantPopupViewModel.SetSpeechBubbleText("New Missions Available...");
		_assistantPopupViewModel.PlayBubbleText();
		if (_assistantPopupViewModel.Folded.Value)
		{
			_assistantPopupViewModel.Folded.Value = false;
		}
		_assistantPopupViewModel.Hidden.Value = true;
		_assistantPopupViewModel.Hidden.Value = false;
	}
}
