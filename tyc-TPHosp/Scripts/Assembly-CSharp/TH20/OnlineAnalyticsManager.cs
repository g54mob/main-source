using System;
using TH20.Analytics;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class OnlineAnalyticsManager : MustCallDestroy
	{
		public enum OnlineFeature
		{
			Leaderboard = 0,
			Collaborative = 1,
			MultiplayerChallenge = 2,
			Max = 3
		}

		private readonly AnalyticsManager _analyticsManager;

		private readonly bool[] _usedFeatures = new bool[3];

		public static Action<OnlineFeature> OnOnlineFeatureUsed;

		public OnlineAnalyticsManager(AnalyticsManager analyticsManager)
		{
			_analyticsManager = analyticsManager;
			OnOnlineFeatureUsed = (Action<OnlineFeature>)Delegate.Combine(OnOnlineFeatureUsed, new Action<OnlineFeature>(OnlineFeatureUsed));
		}

		public override void Destroy()
		{
			OnOnlineFeatureUsed = (Action<OnlineFeature>)Delegate.Remove(OnOnlineFeatureUsed, new Action<OnlineFeature>(OnlineFeatureUsed));
			base.Destroy();
		}

		private void OnlineFeatureUsed(OnlineFeature feature)
		{
			if (!_usedFeatures[(int)feature])
			{
				_usedFeatures[(int)feature] = true;
				GameEvent gameEvent = new GameEvent(_analyticsManager.Config.OnlineFeatureUsedInfo).AddParam("timeTointeract", Time.realtimeSinceStartup).AddParam("feature", feature.ToString());
				_analyticsManager.RecordEvent(gameEvent);
			}
		}
	}
}
