namespace TH20
{
	public class MetagameStateBase : MetagameState
	{
		public MetagameStateBase(MetagameMap map)
			: base(map)
		{
		}

		public override void Enter()
		{
			MetagameMap.MapUI.DeactivateUI();
		}

		public override void Update()
		{
			if (MetagameMap.IsReadyToStart)
			{
				MetagameStateData stateMachineData = base.Owner.GetStateMachineData<MetagameStateData>();
				if (stateMachineData.LoadLevel != null)
				{
					PushState(new MetagameStateInHospital(MetagameMap, stateMachineData.LoadLevel, stateMachineData.OnLoadRestartLevel, stateMachineData.OnLoadSaveOldLevel));
					stateMachineData.LoadLevel = null;
				}
				else if (stateMachineData.CheckForCutscenes)
				{
					PushState(new MetagameStateCutscenePlayer(MetagameMap));
					stateMachineData.CheckForCutscenes = false;
				}
				else if (stateMachineData.CheckForPostCutscene)
				{
					PushState(new MetagameStatePostCutscenePlayer(MetagameMap));
					stateMachineData.CheckForPostCutscene = false;
				}
				else if (stateMachineData.CheckForSuperBugMessages && MetagameMap.App.UserProfile.IsCollaborativeProjectsUnlocked)
				{
					PushState(new MetagameStateSuperBugLetter(MetagameMap));
					stateMachineData.CheckForSuperBugMessages = false;
				}
				else
				{
					PushState(new MetagameStatePlayer(MetagameMap));
				}
			}
		}

		public override void Exit()
		{
		}
	}
}
