using UnityEngine;

public static class TrackGenerator
{
	public static TrackTypes[] GenerateLevelTracksAndEvents(Level level, bool noTurns = false, bool noResources = false)
	{
		TrackTypes[] array = InitializeTrackArray(level.TrackCount);
		GenerateTurnEvents(level, array, noTurns);
		GenerateResourceEvents(level, array, noResources);
		FinalizeTrackArray(array);
		return array;
	}

	public static TrackTypes[] GenerateLevelTracks(Level level)
	{
		TrackTypes[] array = InitializeTrackArray(level.TrackCount);
		FinalizeTrackArray(array);
		return array;
	}

	public static void GenerateLevelEvents(Level level, bool noTurns = false, bool noResources = false)
	{
		GenerateTurnEvents(level, level.TrackTypes, noTurns);
		GenerateResourceEvents(level, level.TrackTypes, noResources);
	}

	private static TrackTypes[] InitializeTrackArray(int trackCount)
	{
		return new TrackTypes[trackCount + 3];
	}

	private static void GenerateTurnEvents(Level level, TrackTypes[] trackTypes, bool noTruns = false)
	{
		if (ZoneManager.Instance.CurrentZone == null)
		{
			return;
		}
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && level.Index == 2 && !noTruns)
		{
			int t = 7;
			int tracksSinceTurn = 0;
			AddTurnEvent(level, trackTypes, ref t, ref tracksSinceTurn);
			return;
		}
		ParticleSystem.MinMaxCurve eventCadenceTurn = LevelManager.Instance.Config.EventCadenceTurn;
		float num = GetCurveMax(eventCadenceTurn, level.Column) * GameManager.Instance.GameSpeedModifier;
		float num2 = GetCurveMin(eventCadenceTurn, level.Column) * GameManager.Instance.GameSpeedModifier;
		int t2 = 0;
		int tracksSinceTurn2 = 0;
		while (t2 < trackTypes.Length - 3)
		{
			if (noTruns || !CanPlaceTurn(t2, level, tracksSinceTurn2, num2))
			{
				trackTypes[t2] = TrackTypes.SS;
				t2++;
				tracksSinceTurn2++;
			}
			else if (ShouldPlaceEvent(num - num2))
			{
				AddTurnEvent(level, trackTypes, ref t2, ref tracksSinceTurn2);
			}
			else
			{
				tracksSinceTurn2++;
			}
		}
	}

	private static void GenerateResourceEvents(Level level, TrackTypes[] trackTypes, bool noResources = false)
	{
		if (ZoneManager.Instance.CurrentZone == null)
		{
			return;
		}
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && level.Index == 3 && !noResources)
		{
			int t = 7;
			int tracksSinceResource = 0;
			AddResourceEvent(level, trackTypes, ref t, ref tracksSinceResource);
			return;
		}
		ParticleSystem.MinMaxCurve eventCadenceResource = LevelManager.Instance.Config.EventCadenceResource;
		float num = ((!(ZoneManager.Instance.CurrentZone.Definition.ZoneName == "W4_Snow")) ? (GetCurveMax(eventCadenceResource, level.Column) * GameManager.Instance.GameSpeedModifier) : (GetCurveMax(eventCadenceResource, level.Column) * GameManager.Instance.GameSpeedModifier * (1f + LevelManager.Instance.Config.ResourceSpawnIncrease)));
		float num2 = ((!(ZoneManager.Instance.CurrentZone.Definition.ZoneName == "W4_Snow")) ? (GetCurveMin(eventCadenceResource, level.Column) * GameManager.Instance.GameSpeedModifier) : (GetCurveMin(eventCadenceResource, level.Column) * GameManager.Instance.GameSpeedModifier * (1f + LevelManager.Instance.Config.ResourceSpawnIncrease)));
		int t2 = 0;
		int tracksSinceResource2 = 0;
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && level.Index == 2)
		{
			tracksSinceResource2 = 5;
		}
		while (t2 < trackTypes.Length - 3)
		{
			if (noResources || !CanPlaceResource(t2, level, tracksSinceResource2, num2))
			{
				t2++;
				tracksSinceResource2++;
			}
			else if (ShouldPlaceEvent(num - num2))
			{
				AddResourceEvent(level, trackTypes, ref t2, ref tracksSinceResource2);
			}
			else
			{
				tracksSinceResource2++;
			}
		}
	}

	private static bool CanPlaceTurn(int t, Level level, int tracksSinceTurn, float turnMin)
	{
		if (t > LevelManager.Instance.Config.Margins && t + LevelManager.Instance.Config.Margins < level.TrackCount)
		{
			return (float)tracksSinceTurn >= turnMin;
		}
		return false;
	}

	private static bool CanPlaceResource(int t, Level level, int tracksSinceResource, float resourceMin)
	{
		if (t > LevelManager.Instance.Config.Margins && t + LevelManager.Instance.Config.Margins < level.TrackCount)
		{
			return (float)tracksSinceResource >= resourceMin;
		}
		return false;
	}

	private static bool ShouldPlaceEvent(float range)
	{
		return Random.Range(0f, range) <= 1f;
	}

	private static void AddTurnEvent(Level level, TrackTypes[] trackTypes, ref int t, ref int tracksSinceTurn)
	{
		if (Random.Range(0, 2) == 0)
		{
			SetLeftTurnTrackTypes(trackTypes, t);
			level.Switches.Add(new TrackEventSwitch((float)t * 4.8f + 2.4f, TrainDirections.Left));
		}
		else
		{
			SetRightTurnTrackTypes(trackTypes, t);
			level.Switches.Add(new TrackEventSwitch((float)t * 4.8f + 2.4f, TrainDirections.Right));
		}
		t += 4;
		tracksSinceTurn = 0;
	}

	private static void AddResourceEvent(Level level, TrackTypes[] trackTypes, ref int t, ref int tracksSinceResource)
	{
		ResourceTypes resourceType = ((LootUtils.GetWeightedIndex(new float[2]
		{
			LevelManager.Instance.Config.ResourceWeightAmmo,
			LevelManager.Instance.Config.ResourceWeightScrap
		}) == 1) ? ResourceTypes.Scrap : ResourceTypes.Ammo);
		if (ProbUtils.CheckWithReverseLuck(TrackManager.Instance.ChanceForFakeResources) && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z4_Snow")
		{
			resourceType = ResourceTypes.Rerolls;
		}
		level.Resources.Add(new TrackEventResource((float)t * 4.8f, resourceType));
		tracksSinceResource = 0;
		t++;
	}

	private static void SetLeftTurnTrackTypes(TrackTypes[] trackTypes, int t)
	{
		trackTypes[t] = TrackTypes.SDL;
		trackTypes[t + 1] = TrackTypes.DLDL;
		trackTypes[t + 2] = TrackTypes.DLODL;
		trackTypes[t + 3] = TrackTypes.DLS;
	}

	private static void SetRightTurnTrackTypes(TrackTypes[] trackTypes, int t)
	{
		trackTypes[t] = TrackTypes.SDR;
		trackTypes[t + 1] = TrackTypes.DRDR;
		trackTypes[t + 2] = TrackTypes.DRODR;
		trackTypes[t + 3] = TrackTypes.DRS;
	}

	private static void FinalizeTrackArray(TrackTypes[] trackTypes)
	{
		int num = trackTypes.Length;
		trackTypes[num - 3] = TrackTypes.YardBefore;
		trackTypes[num - 2] = TrackTypes.Yard;
		trackTypes[num - 1] = TrackTypes.YardAfter;
	}

	private static float GetCurveMax(ParticleSystem.MinMaxCurve curve, int column)
	{
		return curve.curveMax.Evaluate(column);
	}

	private static float GetCurveMin(ParticleSystem.MinMaxCurve curve, int column)
	{
		return curve.curveMin.Evaluate(column);
	}
}
