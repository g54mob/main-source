using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCompass : SceneBehaviour
{
	[SerializeField]
	private WorldMapCompassPoint _north;

	[SerializeField]
	private ChildBehaviourCache<WorldMapCompassBearing> _bearings = new ChildBehaviourCache<WorldMapCompassBearing>();

	[SerializeField]
	private WorldMapTownheart _townheart;

	[SerializeField]
	private AnimationCurve _bearingVisiblityCurve;

	private readonly List<IWorldMapCompassBearingTarget> _targets = new List<IWorldMapCompassBearingTarget>();

	public void Initialize()
	{
		_targets.Clear();
		_bearings.Reset();
		_bearings.Trim();
		GameEventDispatcher.AddListener(GameEventType.CompassBearingTargetUpdate, OnBearingTargetUpdated);
		GameEventDispatcher.AddListener(GameEventType.DeactivateCompassBearingTarget, OnBearingTargetDeactivated);
	}

	public void UpdateBearings()
	{
		_bearings.Reset();
		foreach (IWorldMapCompassBearingTarget target in _targets)
		{
			if (IsBearingFeatureActive(target))
			{
				ActivateBearing(target);
			}
		}
		_bearings.Trim();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CompassBearingTargetUpdate, OnBearingTargetUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.DeactivateCompassBearingTarget, OnBearingTargetDeactivated);
	}

	public void ActivateBearing(IWorldMapCompassBearingTarget target)
	{
		WorldMapCompassBearing worldMapCompassBearing = _bearings.Get();
		if (!worldMapCompassBearing.IsInitialized)
		{
			worldMapCompassBearing.Initialize(_townheart);
		}
		worldMapCompassBearing.Activate(target);
	}

	private void OnBearingTargetUpdated(GameEvent gameEvent)
	{
		if (!(gameEvent is MapEvent { BearingTarget: var bearingTarget }))
		{
			return;
		}
		if (IsBearingFeatureActive(bearingTarget))
		{
			if (bearingTarget.BearingIcon == null)
			{
				Debug.LogException(new ArgumentException($"Bearing target \"{bearingTarget}\" wants to be activated but doesn't have a valid bearing icon!"));
			}
			else if (_targets.AddUnique(bearingTarget))
			{
				ActivateBearing(bearingTarget);
			}
		}
		else if (_targets.Remove(bearingTarget))
		{
			UpdateBearings();
		}
	}

	private void OnBearingTargetDeactivated(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent && _targets.Remove(mapEvent.BearingTarget))
		{
			UpdateBearings();
		}
	}

	public static bool HasBearingTo(WorldMapScoutingId scoutingId)
	{
		if (ReturnInstance(out var instance))
		{
			if (instance._targets.IsNullOrEmpty())
			{
				return false;
			}
			foreach (IWorldMapCompassBearingTarget target in instance._targets)
			{
				if (target.IsBearingTo(scoutingId))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static int ReturnBearingCount(WorldMapScoutingId scoutingId)
	{
		int num = 0;
		if (ReturnInstance(out var instance))
		{
			if (instance._targets.IsNullOrEmpty())
			{
				return num;
			}
			foreach (IWorldMapCompassBearingTarget target in instance._targets)
			{
				if (target.IsBearingTo(scoutingId))
				{
					num++;
				}
			}
		}
		return num;
	}

	public static bool ReturnInstance(out WorldMapCompass instance)
	{
		instance = GameManager.WorldMapManager.WorldMap.Compass;
		return instance;
	}

	private bool IsBearingFeatureActive(IWorldMapCompassBearingTarget bearingTarget)
	{
		if (bearingTarget.IsBearingActive())
		{
			return (bearingTarget.BearingFeatures & BearingFeatures.Compass) != 0;
		}
		return false;
	}
}
