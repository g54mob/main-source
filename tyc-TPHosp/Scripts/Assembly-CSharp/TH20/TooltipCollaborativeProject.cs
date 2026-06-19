using I2.Loc;
using JetBrains.Annotations;
using TMPro;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipCollaborativeProject : Tooltip
	{
		public TMP_Text ProjectDescription;

		public TMP_Text ProjectRewards;

		public void SetData(CollaborativeProject project)
		{
			if (project?.LocalPlayerData?.Definition?.CompletionRewards != null)
			{
				ProjectDescription.text = project.LocalPlayerData.Definition.Description.Translation;
				string reward_CS = ScriptLocalization.Collaborative_GUI.Reward_CS;
				IReward[] completionRewards = project.LocalPlayerData.Definition.CompletionRewards;
				string arg = string.Format(reward_CS, RewardUtils.GetFullRewardString(null, completionRewards));
				ProjectRewards.text = $"<b>{arg}<b>";
				GameObjectUtils.SetActive(ProjectRewards.gameObject, isActive: true);
			}
		}

		public void SetData(SuperBugDefinition definition)
		{
			ProjectDescription.text = definition.Description.Translation;
			ProjectRewards.text = string.Empty;
			GameObjectUtils.SetActive(ProjectRewards.gameObject, isActive: false);
		}

		public void SetData()
		{
			ProjectDescription.text = ScriptLocalization.Collaborative.Tooltip_StartNewProject_CS;
			GameObjectUtils.SetActive(ProjectRewards.gameObject, isActive: false);
		}
	}
}
