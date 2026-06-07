using System;
using DV.Utils;
using UnityEngine;

public class WorldTimeBasedEventProviderDV : WorldTimeBasedEventsProvider
{
	public override bool IsWorldMoverReady
	{
		get
		{
			if (!DevSceneUtil.IsDevScene())
			{
				return SingletonBehaviour<WorldMover>.Instance != null;
			}
			return true;
		}
	}

	public override bool IsWorldStreamingInitLoaded
	{
		get
		{
			if (!DevSceneUtil.IsDevScene())
			{
				return WorldStreamingInit.IsLoaded;
			}
			return true;
		}
	}

	public override Camera ActiveCamera => PlayerManager.ActiveCamera;

	public override Vector3 CurrentMove => WorldMover.currentMove;

	public override float GetTime()
	{
		return TOD_Sky.Instance.Cycle.Hour;
	}

	public override void RegisterToLightingQualityPreferenceUpdated(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.LightingQualityIndex, callback);
	}

	public override void UnregisterFromPreferenceUpdated(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.LightingQualityIndex, callback);
	}

	public override int GetLightingQualityLevel()
	{
		return (int)SingletonBehaviour<GraphicsOptions>.Instance.LightingQualityLevel;
	}
}
