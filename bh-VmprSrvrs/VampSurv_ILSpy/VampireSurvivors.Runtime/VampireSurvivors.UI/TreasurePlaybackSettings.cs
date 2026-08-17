using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.UI;

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
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public void StopCoins()
	{
		//IL_0061->IL0061: Incompatible stack heights: 1 vs 0
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbx_v5 (System.Object)+10]");
			ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public TreasurePlaybackSettings()
	{
		List<ParticleSystem> coins = new List<ParticleSystem>();
		Coins = coins;
		List<UISplineFollower> paths = new List<UISplineFollower>();
		Paths = paths;
		List<TreasureReelUI> reels = new List<TreasureReelUI>();
		Reels = reels;
	}
}
