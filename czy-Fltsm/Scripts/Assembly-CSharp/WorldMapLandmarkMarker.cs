using System.Collections.Generic;
using PajamaLlama.Generic;
using UnityEngine;

public class WorldMapLandmarkMarker : MonoBehaviour
{
	[SerializeField]
	private GameObject _marker;

	[SerializeField]
	private SpriteRenderer _iconFront;

	[SerializeField]
	private SpriteRenderer _iconBack;

	private WorldMapLandmark _landmark;

	private readonly Queue<IWorldMapCompassBearingTarget> _activeBearingTargets = new Queue<IWorldMapCompassBearingTarget>();

	private RangedFloat _scaleRange;

	private void Update()
	{
		if (0 < _activeBearingTargets.Count && !IsBearingFeatureActive(_activeBearingTargets.Peek()))
		{
			DeactivateBearingTarget(_activeBearingTargets.Peek());
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CompassBearingTargetUpdate, OnCompassBearingTargetUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.DeactivateCompassBearingTarget, OnCompassBearingTargetDeactivated);
	}

	public void Initialize(WorldMapLandmark landmark)
	{
		_landmark = landmark;
		_scaleRange = GameSettings.Instance.LandmarkSettings.MapScaling;
		if (_landmark.Spawner is LandmarkSpawner { ScoutingId: not WorldMapScoutingId.None })
		{
			GameEventDispatcher.AddListener(GameEventType.CompassBearingTargetUpdate, OnCompassBearingTargetUpdate);
			GameEventDispatcher.AddListener(GameEventType.DeactivateCompassBearingTarget, OnCompassBearingTargetDeactivated);
		}
		OnCompassBearingTargetUpdate(_landmark.LandmarkSpawner);
	}

	public void UpdateScale(Vector3 scale)
	{
		Transform obj = base.transform;
		Vector3 position = obj.position;
		position.y = _landmark.MarkerPositionY * scale.y;
		obj.position = position;
		obj.localScale = scale;
	}

	private void OnCompassBearingTargetUpdate(IWorldMapCompassBearingTarget bearingTarget)
	{
		if (IsBearingFeatureActive(bearingTarget))
		{
			if (!_activeBearingTargets.Contains(bearingTarget))
			{
				_activeBearingTargets.Enqueue(bearingTarget);
			}
			if (_activeBearingTargets.Peek() == bearingTarget)
			{
				ActivateBearingTarget(bearingTarget);
			}
		}
		else if (0 < _activeBearingTargets.Count)
		{
			DeactivateBearingTarget(bearingTarget);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnCompassBearingTargetUpdate(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent && mapEvent.BearingTarget.IsBearingTo(_landmark.Spawner))
		{
			OnCompassBearingTargetUpdate(mapEvent.BearingTarget);
		}
	}

	private void OnCompassBearingTargetDeactivated(GameEvent gameEvent)
	{
		if (gameEvent is MapEvent mapEvent && mapEvent.BearingTarget.IsBearingTo(_landmark.Spawner))
		{
			DeactivateBearingTarget(mapEvent.BearingTarget);
		}
	}

	private void ActivateBearingTarget(IWorldMapCompassBearingTarget bearingTarget)
	{
		_iconFront.sprite = bearingTarget.BearingIcon;
		_iconBack.sprite = bearingTarget.BearingIcon;
		base.gameObject.SetActive(value: true);
		UpdateScale(_landmark.Scale);
	}

	private void DeactivateBearingTarget(IWorldMapCompassBearingTarget bearingTarget)
	{
		if (_activeBearingTargets.Peek() != bearingTarget)
		{
			_activeBearingTargets.Remove(bearingTarget);
			return;
		}
		_activeBearingTargets.Dequeue();
		if (_activeBearingTargets.Count > 0)
		{
			ActivateBearingTarget(_activeBearingTargets.Peek());
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private bool IsBearingFeatureActive(IWorldMapCompassBearingTarget bearingTarget)
	{
		if (bearingTarget.IsBearingActive())
		{
			return (bearingTarget.BearingFeatures & BearingFeatures.Marker) != 0;
		}
		return false;
	}
}
