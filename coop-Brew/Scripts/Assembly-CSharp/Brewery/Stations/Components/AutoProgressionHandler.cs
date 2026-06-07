using System;
using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components
{
	public sealed class AutoProgressionHandler
	{
		private readonly IStationUpgradeProvider upgradeProvider;

		private readonly Func<bool> canAutoProgress;

		private readonly Action triggerProgression;

		private readonly Func<bool> isBusy;

		private readonly float intervalSeconds;

		private float timer;

		public AutoProgressionHandler(IStationUpgradeProvider upgradeProvider, Func<bool> canAutoProgress, Action triggerProgression, Func<bool> isBusy, float intervalSeconds = 0.5f)
		{
		}

		public void Tick(float deltaTime)
		{
		}
	}
}
