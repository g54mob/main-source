using System;

namespace Campaign
{
	[Serializable]
	public abstract class CampaignAction
	{
		public abstract string GetName();

		public abstract void Execute(bool isSavegameLoad);

		public abstract bool IsFinished();
	}
}
