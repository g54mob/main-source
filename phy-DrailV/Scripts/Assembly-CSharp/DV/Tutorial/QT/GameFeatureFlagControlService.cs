using DV.Common;

namespace DV.Tutorial.QT
{
	public class GameFeatureFlagControlService : ATutorialService
	{
		private readonly GameFeatureFlags.Flag flag;

		private readonly bool enabled;

		private bool previousState;

		public GameFeatureFlagControlService(GameFeatureFlags.Flag flag, bool enabled)
		{
			this.flag = flag;
			this.enabled = enabled;
		}

		public override void StartService(QuickTutorialHost host, QuickTutorialPhase phase)
		{
			previousState = GameFeatureFlags.IsAllowed(flag);
			if (enabled)
			{
				GameFeatureFlags.Allow(flag);
			}
			else
			{
				GameFeatureFlags.Deny(flag);
			}
		}

		public override void StopService(bool fullyCompleted)
		{
			if (previousState)
			{
				GameFeatureFlags.Allow(flag);
			}
			else
			{
				GameFeatureFlags.Deny(flag);
			}
		}

		public override void UpdateService()
		{
		}
	}
}
