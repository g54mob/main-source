using System;

namespace Campaign
{
	[Serializable]
	public class RemoveAvailableInteractionAction : CampaignAction
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
