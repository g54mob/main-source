using System;
using I2.Loc;

namespace TH20
{
	public class ResearchProjectObjective : MetagameObjective
	{
		public readonly Guid ProjectID;

		public readonly int NodeID;

		[NonSerialized]
		public bool IsKicked;

		public ResearchProjectObjective(Metagame metagame, ObjectiveDefinition definition, bool isReplayable, Guid projectID, int nodeID)
			: base(metagame, definition, isVisible: true, isDiscovered: true, isReplayable, startImmediately: false)
		{
			ProjectID = projectID;
			NodeID = nodeID;
			CollaborativePortfolio collaborativePortfolio = base.Metagame.CollaborativePortfolio;
			collaborativePortfolio.OnLatestDataGathered = (Action)Delegate.Combine(collaborativePortfolio.OnLatestDataGathered, new Action(OnLatestData));
		}

		private void OnLatestData()
		{
			CollaborativeProject project = base.Metagame.CollaborativePortfolio.GetProject(ProjectID);
			if (project == null)
			{
				return;
			}
			bool flag = project.HasPlayerBeenKicked();
			if (IsKicked != flag)
			{
				IsKicked = flag;
				base.Metagame.ObjectiveEvents.OnObjectiveKickStateChanged.InvokeSafe(this);
				if (base.State == ObjectiveState.Active && IsKicked)
				{
					ForceFail();
				}
			}
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			GiveRewards(completionType);
			if (completionType != CompletionType.Failed)
			{
				base.Metagame.CollaborativePortfolio.OnActiveObjectiveCompleted(this, completionType);
			}
			if (completionType != CompletionType.Successful)
			{
				return;
			}
			CollaborativeProject project = base.Metagame.CollaborativePortfolio.GetProject(ProjectID);
			if (project != null)
			{
				if (project.IsProjectCompleted())
				{
					string message = string.Format(LocalizationManager.GetTranslation("Collaborative/Advisor_ProjectCompleted"), project.LocalPlayerData.Definition.Name.Translation);
					base.Metagame.CurrentLevel.Advisor.PushMessage(new AdvisorMessageDefinition
					{
						Message = message,
						Icon = base.Metagame.App.CollaborativeProjectList.SuperBugIcon,
						Duration = 10f,
						UserCanDismiss = true,
						StartCollaborativeMenuOnClick = true
					}, interrupt: true, Advisor.PriorityLevel.VeryHigh);
				}
				else
				{
					string advisorMessage_CompletedNode_CS = ScriptLocalization.Collaborative_HUD.AdvisorMessage_CompletedNode_CS;
					LocalisedString nameLocalised = base.Definition.NameLocalised;
					string rewardsString = base.Definition.GetRewardsString(this, base.Definition.CompletionRewards);
					base.Metagame.CurrentLevel.Advisor.PushMessage(new AdvisorMessageDefinition
					{
						Message = string.Format(advisorMessage_CompletedNode_CS, nameLocalised.Translation, rewardsString),
						Icon = base.Metagame.App.CollaborativeProjectList.SuperBugIcon,
						Duration = 10f,
						UserCanDismiss = true,
						StartCollaborativeMenuOnClick = true
					}, interrupt: true, Advisor.PriorityLevel.VeryHigh);
				}
			}
		}

		public override bool ShowGUIOnDiscover()
		{
			return true;
		}

		public override bool CanDismiss()
		{
			return true;
		}

		public override bool ReadyToDestroyOnComplete()
		{
			return false;
		}
	}
}
