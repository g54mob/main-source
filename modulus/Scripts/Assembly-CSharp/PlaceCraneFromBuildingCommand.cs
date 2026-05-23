#define ENABLE_DEBUG_WARNINGS
using Commands;
using Data.FactoryFloor.Buildings;
using Events;
using Presentation.Locators;
using UnityEngine;
using Utils;

public class PlaceCraneFromBuildingCommand : ICommandUndo, ICommand
{
	private readonly bool _delete;

	private readonly BaseEvent _onPlacedCrane;

	private readonly BuildingCranesBehaviour _buildingCranesBehaviour;

	private readonly AudioManagerLocator _audioManagerLocator;

	private Vector3Int _position;

	private Vector3Int _entrancePosition;

	public PlaceCraneFromBuildingCommand(bool delete, BaseEvent onPlacedCrane, BuildingCranesBehaviour buildingCranesBehaviour, AudioManagerLocator audioManagerLocator, Vector3Int position, Vector3Int entrancePosition)
	{
		_delete = delete;
		_onPlacedCrane = onPlacedCrane;
		_buildingCranesBehaviour = buildingCranesBehaviour;
		_audioManagerLocator = audioManagerLocator;
		_position = position;
		_entrancePosition = entrancePosition;
	}

	public bool TryDo()
	{
		return TryDoInternal(_delete);
	}

	public bool TryReDo()
	{
		return TryDoInternal(_delete);
	}

	public bool TryUnDo()
	{
		return TryDoInternal(!_delete);
	}

	private bool TryDoInternal(bool delete)
	{
		if (delete)
		{
			return TryDelete();
		}
		return TryPlace();
	}

	private bool TryDelete()
	{
		if (!_buildingCranesBehaviour.RemoveCrane(_entrancePosition))
		{
			return false;
		}
		_audioManagerLocator.AudioManager.PlayDeleteObject(_position);
		return true;
	}

	private bool TryPlace()
	{
		if (_buildingCranesBehaviour.EnableCraneLimitValidator.IsEnabledFeatureFlag() && _buildingCranesBehaviour.Cranes.Count + 1 > _buildingCranesBehaviour.MaxAmountOfCranes)
		{
			this.LogWarning("Max amount of cranes reached!", "TryPlace", 56);
			return false;
		}
		if (!_buildingCranesBehaviour.AddCrane(_entrancePosition, _position))
		{
			return false;
		}
		_audioManagerLocator.AudioManager.PlayPlaceObject(_position);
		_onPlacedCrane.Fire();
		return true;
	}
}
