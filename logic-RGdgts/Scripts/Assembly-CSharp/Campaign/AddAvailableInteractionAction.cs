using System;

namespace Campaign
{
	[Serializable]
	public class AddAvailableInteractionAction : CampaignAction
	{
		public GameplayInteraction interaction;

		public override string GetName()
		{
			return null;
		}

		public override void Execute(bool isSavegameLoad)
		{
		}

		public override bool IsFinished()
		{
			return false;
		}
	}
}
