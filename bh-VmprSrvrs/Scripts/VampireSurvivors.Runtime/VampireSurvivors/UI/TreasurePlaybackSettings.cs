using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.UI
{
	[Serializable]
	public class TreasurePlaybackSettings
	{
		public List<ParticleSystem> Coins;

		public List<UISplineFollower> Paths;

		public List<TreasureReelUI> Reels;

		public int RibbonAmount;

		public int RibbonLoopAmount;

		public float CoinTweenDuration;

		public float MultiplayerRandomCycleDuration;

		public float SkipTime;

		public float AnimationLength;

		public void StartCoins()
		{
		}

		public void StopCoins()
		{
		}
	}
}
