using UnityEngine;

namespace DV.Common
{
	[RequireComponent(typeof(CustomFirstPersonController))]
	public class MovementFlagUpdater : AFeatureFlagUpdater
	{
		private CustomFirstPersonController fpController;

		protected override GameFeatureFlags.Flag Flag => GameFeatureFlags.Flag.Movement | GameFeatureFlags.Flag.Look;

		private void Awake()
		{
			fpController = GetComponent<CustomFirstPersonController>();
			fpController.Locomotion.inputEnabled = GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.Movement);
			fpController.FreeLookAllowed = GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.Look);
		}

		protected override void UpdateState(GameFeatureFlags.Flag flag, bool allowed)
		{
			switch (flag)
			{
			case GameFeatureFlags.Flag.Movement:
				fpController.Locomotion.inputEnabled = allowed;
				break;
			case GameFeatureFlags.Flag.Look:
				fpController.FreeLookAllowed = allowed;
				break;
			}
		}
	}
}
