using I2.Loc;

namespace TH20
{
	public class NotificationResearchComplete : NotificationMessage
	{
		private ResearchProjectDefinition _project;

		public NotificationResearchComplete(NotificationMessages.Definition definition, ResearchProjectDefinition project, Level level)
			: base(definition, level)
		{
			_project = project;
		}

		public override string GetMessageText()
		{
			string fullRewardString = RewardUtils.GetFullRewardString(null, _project.Rewards, ", ");
			if (fullRewardString.IsNullOrEmpty())
			{
				return _project.CompletionMessageLocalised.Translation;
			}
			return string.Format("{0}\n\n{1}", _project.CompletionMessageLocalised.Translation, ScriptLocalization.Notification.Challenge_ChallengeText_CS.Replace("{[REWARDS]}", fullRewardString));
		}

		public override Character GetCharacter()
		{
			return null;
		}
	}
}
