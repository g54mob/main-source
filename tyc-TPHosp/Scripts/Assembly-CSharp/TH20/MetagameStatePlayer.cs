using System.Collections.Generic;

namespace TH20
{
	public class MetagameStatePlayer : MetagameState
	{
		private Queue<AdvisorMessageDefinition> _advisorMessageQueue = new Queue<AdvisorMessageDefinition>();

		public MetagameStatePlayer(MetagameMap map)
			: base(map)
		{
		}

		public override void Enter()
		{
			MetagameMap.MapUI.ActivateUI();
		}

		public override void Update()
		{
			if (_advisorMessageQueue.Count > 0)
			{
				MetagameMapCareerUI metagameMapCareerUI = MetagameMap.MapUI as MetagameMapCareerUI;
				if (!(metagameMapCareerUI == null) && !metagameMapCareerUI.AdvisorMenu.IsShowingMessage)
				{
					AdvisorMessageDefinition definition = _advisorMessageQueue.Peek();
					metagameMapCareerUI.AdvisorMenu.ShowAdvisorMessage(definition);
				}
			}
		}

		public override void Exit()
		{
			MetagameMap.MapUI.DeactivateUI();
		}

		public void SubmitAdvisorMessage(AdvisorMessageDefinition messageDefinition)
		{
			_advisorMessageQueue.Enqueue(messageDefinition);
		}

		public void LaunchHospital(LevelConfig levelConfig, bool restartLevel = false, bool saveOldLevel = true)
		{
			if (base.Owner.TopState == this)
			{
				MetagameStateData stateMachineData = base.Owner.GetStateMachineData<MetagameStateData>();
				stateMachineData.LoadLevel = levelConfig;
				stateMachineData.OnLoadRestartLevel = restartLevel;
				stateMachineData.OnLoadSaveOldLevel = saveOldLevel;
				PopState();
			}
		}

		public void RunCutscenes()
		{
			if (base.Owner.TopState == this)
			{
				MetagameStateData stateMachineData = base.Owner.GetStateMachineData<MetagameStateData>();
				stateMachineData.CheckForCutscenes = true;
				stateMachineData.CheckForPostCutscene = true;
				stateMachineData.CheckForSuperBugMessages = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.Superbug);
				PopState();
			}
		}

		public override bool CanQuickLoadInThisState()
		{
			return true;
		}
	}
}
