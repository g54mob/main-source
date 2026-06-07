using UnityEngine;

namespace DV.Common
{
	[RequireComponent(typeof(TeleportPointerController))]
	public class TeleportFlagUpdater : AFeatureFlagUpdater
	{
		private TeleportPointerController pointerController;

		protected override GameFeatureFlags.Flag Flag => GameFeatureFlags.Flag.TeleportGeneral | GameFeatureFlags.Flag.TeleportInLoco;

		private void Awake()
		{
			pointerController = GetComponent<TeleportPointerController>();
		}

		protected override void UpdateState(GameFeatureFlags.Flag flag, bool allowed)
		{
			switch (flag)
			{
			case GameFeatureFlags.Flag.TeleportGeneral:
				pointerController.teleportAllowed = allowed;
				if (!allowed)
				{
					pointerController.pointerLogic.Disable();
				}
				break;
			case GameFeatureFlags.Flag.TeleportInLoco:
				pointerController.cabTeleportAllowed = allowed;
				break;
			}
		}
	}
}
