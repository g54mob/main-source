using UnityEngine;

namespace DV.Common
{
	public abstract class AFeatureFlagUpdater : MonoBehaviour
	{
		private GameFeatureFlags.Flag lastState;

		protected abstract GameFeatureFlags.Flag Flag { get; }

		protected abstract void UpdateState(GameFeatureFlags.Flag flag, bool allowed);

		private void OnEnable()
		{
			GameFeatureFlags.RegisterListenerFor(Flag, UpdateState);
			GameFeatureFlags.Flag flag = lastState ^ GameFeatureFlags.DeniedFlags;
			flag &= Flag;
			lastState = GameFeatureFlags.DeniedFlags;
			if (flag == GameFeatureFlags.Flag.None)
			{
				return;
			}
			for (int i = 0; i < GameFeatureFlags.AllFlags.Length; i++)
			{
				if ((flag & GameFeatureFlags.AllFlags[i]) != GameFeatureFlags.Flag.None)
				{
					UpdateState(GameFeatureFlags.AllFlags[i], GameFeatureFlags.IsAllowed(GameFeatureFlags.AllFlags[i]));
				}
			}
		}

		private void OnDisable()
		{
			lastState = GameFeatureFlags.DeniedFlags;
			GameFeatureFlags.UnregisterListenerFor(Flag, UpdateState);
		}
	}
}
