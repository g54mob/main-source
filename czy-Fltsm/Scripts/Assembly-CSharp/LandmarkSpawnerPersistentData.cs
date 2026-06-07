using System;
using System.Runtime.Serialization;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class LandmarkSpawnerPersistentData
{
	private int _landmarkBehaviourIndex;

	private LandmarkPersistentData _persistentData;

	private Vector3 _position;

	private Quaternion _rotation;

	[OptionalField(VersionAdded = 2)]
	private ScoutingState _scoutingState;

	[OptionalField(VersionAdded = 4)]
	private BearingFeatures _bearingFeatures;

	[OptionalField(VersionAdded = 4)]
	private BearingIconType _bearingIconOverride;

	[OptionalField(VersionAdded = 3)]
	private bool _isBearingActive;

	[NonSerialized]
	private LandmarkSpawner _instance;

	public LandmarkSpawner Instance => _instance;

	public LandmarkSpawnerPersistentData(LandmarkSpawner landmarkSpawner)
	{
		if ((bool)landmarkSpawner.LandmarkBehaviour)
		{
			_landmarkBehaviourIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(landmarkSpawner.LandmarkBehaviour.Prefab);
			if (!LandmarkPersistentData.TryReturnLandmarkPersistentData(out _persistentData, landmarkSpawner.LandmarkBehaviour))
			{
				_persistentData = landmarkSpawner.PersistentData;
				if (_persistentData != null)
				{
					_persistentData.InitializePersistentReference();
				}
			}
		}
		else
		{
			_landmarkBehaviourIndex = -1;
		}
		_position = landmarkSpawner.TilePosition.Vector3TopDown();
		_rotation = landmarkSpawner.Rotation;
		_scoutingState = landmarkSpawner.ScoutingState;
		_bearingFeatures = landmarkSpawner.BearingFeatures;
		_bearingIconOverride = landmarkSpawner.BearingIconOverride;
		_instance = landmarkSpawner;
	}

	~LandmarkSpawnerPersistentData()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, RestoreBearingFeatures);
	}

	public void PopulateReferences()
	{
		if (_persistentData != null && !(_instance.LandmarkBehaviour.Landmark == null))
		{
			_persistentData.PopulateReferences();
		}
	}

	public void Restore(WorldTile worldTile)
	{
		LandmarkBehaviour reference = null;
		if (_landmarkBehaviourIndex == -1 || GameManager.PersistenceManager.TryReturnPropertiesReference<LandmarkBehaviour>(_landmarkBehaviourIndex, out reference))
		{
			if (_persistentData != null)
			{
				_persistentData.Restore();
			}
			_instance = new LandmarkSpawner(reference, _position, _rotation, _persistentData);
			_instance.SetScoutingState(_scoutingState, _isBearingActive);
			if (_isBearingActive)
			{
				GameEventDispatcher.AddListener(GameEventType.GameStart, RestoreBearingFeatures);
			}
			worldTile.AddLandmarkSpawner(_instance);
		}
	}

	private void RestoreBearingFeatures(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, RestoreBearingFeatures);
		if (_bearingFeatures != BearingFeatures.None)
		{
			_instance.SetBearingFeatures(_bearingFeatures, _bearingIconOverride);
		}
		else if (_isBearingActive)
		{
			_instance.SetScoutingState(_scoutingState, _isBearingActive);
		}
	}

	public void RestoreReferences()
	{
		if (_persistentData != null)
		{
			_persistentData.RestoreReferences();
		}
	}
}
