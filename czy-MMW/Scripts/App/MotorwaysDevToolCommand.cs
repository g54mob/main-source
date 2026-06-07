using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways;
using Motorways.Models;
using Server;
using UnityEngine;

public class MotorwaysDevToolCommand : BaseInGameDevToolCommand<MotorwaysDevToolCommand>
{
	[Dependency]
	protected CityPlanModel _cityPlanModel;

	[Dependency]
	protected CityModel _cityModel;

	[Dependency]
	protected ClockModel _clock;

	[Dependency]
	protected ISimulation _simulation;

	[Dependency]
	public IScope Scope { get; protected set; }

	public void SpawnHouse(TileDirection drivewayDirection, int groupIndex)
	{
		SpawnHouse(drivewayDirection, groupIndex, _clock.ExpansionTime);
	}

	private void SpawnHouse(TileDirection drivewayDirection, int groupIndex, Fix64 spawnTime)
	{
		if (groupIndex < 0)
		{
			List<int> list = new List<int>();
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (!list.Contains(current.GroupIndex))
				{
					list.Add(current.GroupIndex);
				}
			}
			groupIndex = ((list.Count > 0) ? list[_cityModel.pseudorandomGenerator.Int(list.Count)] : 0);
		}
		if (drivewayDirection == TileDirection.None)
		{
			drivewayDirection = TileUtilities.NonDiagonalDirections[_cityModel.pseudorandomGenerator.Int(TileUtilities.NonDiagonalDirections.Length)];
		}
		CityPlanModel.ScheduledBuilding scheduledBuilding = Scope.Get<CityPlanModel.ScheduledBuilding>();
		scheduledBuilding.type = CityTileType.Supply;
		scheduledBuilding.groupIndex = groupIndex;
		scheduledBuilding.useFixedParameters = true;
		scheduledBuilding.positionOverride = cursorTilePosition;
		scheduledBuilding.drivewayDirectionOverride = drivewayDirection;
		scheduledBuilding.time = spawnTime;
		_cityPlanModel.ScheduleBuilding(scheduledBuilding);
	}

	public void SpawnDestinationAtCursorPosition(CarparkEntrance carparkEntrance, CarparkPreference carparkPreference, TileDirection drivewayDirection, TileDirection carparkSide, int groupIndex, bool upgrade, int secondGroupIndex = -1, bool secondUpgrade = false)
	{
		SpawnDestination(cursorTilePosition, carparkEntrance, carparkPreference, drivewayDirection, groupIndex, _clock.ExpansionTime, upgrade, secondGroupIndex, secondUpgrade, carparkSide);
	}

	private void SpawnDestination(Vector2Int coordinate, CarparkEntrance carparkEntrance, CarparkPreference carparkPreference, TileDirection drivewayDirection, int groupIndex, Fix64 spawnTime, bool upgrade, int secondGroupIndex, bool secondUpgrade)
	{
		TileAlignment tileAlignment;
		switch (drivewayDirection)
		{
		case TileDirection.East:
		case TileDirection.West:
			tileAlignment = TileAlignment.Horizontal;
			break;
		case TileDirection.North:
		case TileDirection.South:
			tileAlignment = TileAlignment.Vertical;
			break;
		default:
			tileAlignment = TileAlignment.None;
			break;
		}
		SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, groupIndex, spawnTime, upgrade, secondGroupIndex, secondUpgrade, tileAlignment switch
		{
			TileAlignment.None => TileDirection.None, 
			TileAlignment.Horizontal => TileDirection.South, 
			_ => TileDirection.West, 
		});
	}

	private void SpawnDestination(Vector2Int coordinate, CarparkEntrance carparkEntrance, CarparkPreference carparkPreference, TileDirection drivewayDirection, int groupIndex, Fix64 spawnTime, bool upgrade, int secondGroupIndex, bool secondUpgrade, TileDirection carparkSide)
	{
		CityPlanModel.ScheduledBuilding scheduledBuilding = Scope.Get<CityPlanModel.ScheduledBuilding>();
		scheduledBuilding.type = CityTileType.Demand;
		scheduledBuilding.groupIndex = groupIndex;
		scheduledBuilding.initialUpgradeLevel = (upgrade ? 1 : 0);
		scheduledBuilding.carparkPreference = carparkPreference;
		scheduledBuilding.useFixedParameters = true;
		scheduledBuilding.positionOverride = coordinate;
		scheduledBuilding.drivewayDirectionOverride = drivewayDirection;
		scheduledBuilding.entranceOverride = carparkEntrance;
		scheduledBuilding.time = spawnTime;
		scheduledBuilding.demandMultiplier = Fix64.One;
		scheduledBuilding.carparkSideOverride = carparkSide;
		_cityPlanModel.ScheduleBuilding(scheduledBuilding);
		if (secondGroupIndex != -1)
		{
			Vector2Int vector2Int = ((drivewayDirection == TileDirection.East) ? CarparkModel.GenerateDestinationPositions(2, TileDirection.South)[1] : CarparkModel.GenerateDestinationPositions(2, TileDirection.West)[1]);
			CityPlanModel.ScheduledBuilding scheduledBuilding2 = Scope.Get<CityPlanModel.ScheduledBuilding>();
			scheduledBuilding2.type = CityTileType.Demand;
			scheduledBuilding2.groupIndex = secondGroupIndex;
			scheduledBuilding2.initialUpgradeLevel = (secondUpgrade ? 1 : 0);
			scheduledBuilding2.carparkPreference = ((carparkPreference == CarparkPreference.Station || carparkPreference == CarparkPreference.JoinStation || carparkPreference == CarparkPreference.ForceNewStation) ? carparkPreference : CarparkPreference.Double);
			scheduledBuilding2.useFixedParameters = true;
			scheduledBuilding2.positionOverride = coordinate + vector2Int;
			scheduledBuilding2.drivewayDirectionOverride = drivewayDirection;
			scheduledBuilding2.entranceOverride = carparkEntrance;
			scheduledBuilding2.time = spawnTime;
			scheduledBuilding2.demandMultiplier = Fix64.One;
			scheduledBuilding2.carparkSideOverride = carparkSide;
			_cityPlanModel.ScheduleBuilding(scheduledBuilding2);
		}
	}

	public void RemoveAnyBuilding()
	{
		RemoveAnyBuildingAtTileCoordinate(cursorTilePosition);
	}

	public void RemoveAnyBuildingAtTileCoordinate(Vector2Int tileCoordinate)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(tileCoordinate);
		RemoveSpecificBuildingOnTile(tile, TileContentType.House);
		RemoveSpecificBuildingOnTile(tile, TileContentType.Destination);
		RemoveSpecificBuildingOnTile(tile, TileContentType.Carpark);
	}

	public void RemoveSpecificBuildingAtTileCoordinate(Vector2Int tileCoordinate, TileContentType explicitType)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(tileCoordinate);
		RemoveSpecificBuildingOnTile(tile, explicitType);
	}

	public void RemoveSpecificBuildingOnTile(Tile tile, TileContentType explicitType)
	{
		if (tile != null)
		{
			if (explicitType == TileContentType.House && tile.ContentType == TileContentType.House)
			{
				(tile.ContentModel as HouseModel).Remove();
			}
			else if (explicitType == TileContentType.Destination && tile.ContentType == TileContentType.Destination)
			{
				(tile.ContentModel as DestinationModel)?.Carpark.Remove();
			}
			else if (explicitType == TileContentType.Carpark && tile.ContentType == TileContentType.Carpark)
			{
				(tile.ContentModel as CarparkModel)?.Remove();
			}
		}
	}

	public void ChangeGroupIndex(int groupIndex)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null)
		{
			return;
		}
		if (tile.ContentType == TileContentType.House)
		{
			Fix64 expansionTime = _clock.ExpansionTime;
			TileDirection direction = (tile.ContentModel as HouseModel).DrivewayLane.connection.output.direction;
			RemoveSpecificBuildingOnTile(tile, TileContentType.House);
			SpawnHouse(direction, groupIndex, expansionTime);
		}
		else if (tile.ContentType == TileContentType.Destination)
		{
			Fix64 expansionTime2 = _clock.ExpansionTime;
			DestinationModel destinationModel = tile.ContentModel as DestinationModel;
			Vector2Int coordinate = ((destinationModel.Carpark.Alignment != TileAlignment.Vertical) ? destinationModel.Carpark.destinations[0].TileModels[0].Coordinates : (destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(1, 0)));
			CarparkEntrance carparkEntrance = ((destinationModel.Carpark.entranceAtTopLeft && destinationModel.Carpark.entranceAtBottomRight) ? CarparkEntrance.TopLeftAndBottomRight : (destinationModel.Carpark.entranceAtTopLeft ? CarparkEntrance.TopLeft : CarparkEntrance.BottomRight));
			CarparkPreference carparkPreference = ((!destinationModel.Carpark.SupportsTwoDestinations) ? CarparkPreference.Solo : CarparkPreference.Double);
			int num = -1;
			bool flag = false;
			bool flag2 = destinationModel.Carpark.destinations[0] == destinationModel;
			if (destinationModel.Carpark.SupportsTwoDestinations && destinationModel.Carpark.destinations.Count == 2)
			{
				DestinationModel destinationModel2 = destinationModel.Carpark.destinations[flag2 ? 1 : 0];
				num = destinationModel2.GroupIndex;
				flag = destinationModel2.IsUpgraded;
			}
			RemoveSpecificBuildingOnTile(tile, TileContentType.Destination);
			TileDirection drivewayDirection = ((destinationModel.Carpark.Alignment == TileAlignment.Horizontal) ? TileDirection.East : TileDirection.South);
			if (flag2)
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, groupIndex, expansionTime2, destinationModel.IsUpgraded, num, flag);
			}
			else
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, num, expansionTime2, flag, groupIndex, destinationModel.IsUpgraded);
			}
		}
	}

	public void RotateBuilding()
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null)
		{
			return;
		}
		if (tile.ContentType == TileContentType.House)
		{
			Fix64 expansionTime = _clock.ExpansionTime;
			HouseModel houseModel = tile.ContentModel as HouseModel;
			TileDirection direction = houseModel.DrivewayLane.connection.output.direction;
			houseModel.Remove();
			TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(direction, RoadTileRotation.QuarterTurn);
			SpawnHouse(rotatedDirection, houseModel.GroupIndex, expansionTime);
		}
		else if (tile.ContentType == TileContentType.Destination || tile.ContentType == TileContentType.Carpark)
		{
			Fix64 expansionTime2 = _clock.ExpansionTime;
			DestinationModel destinationModel = ((tile.ContentType != TileContentType.Carpark) ? (tile.ContentModel as DestinationModel) : (tile.ContentModel as CarparkModel).destinations[0]);
			TileDirection drivewayDirection;
			Vector2Int coordinate;
			if (destinationModel.Carpark.Alignment == TileAlignment.Vertical)
			{
				drivewayDirection = TileDirection.East;
				coordinate = destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(0, 1);
			}
			else
			{
				drivewayDirection = TileDirection.South;
				coordinate = destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(1, 0);
			}
			CarparkEntrance carparkEntrance = ((destinationModel.Carpark.entranceAtTopLeft && destinationModel.Carpark.entranceAtBottomRight) ? CarparkEntrance.TopLeftAndBottomRight : (destinationModel.Carpark.entranceAtTopLeft ? CarparkEntrance.TopLeft : CarparkEntrance.BottomRight));
			CarparkPreference carparkPreference = ((!destinationModel.Carpark.SupportsTwoDestinations) ? CarparkPreference.Solo : CarparkPreference.Double);
			int num = -1;
			bool flag = false;
			bool flag2 = destinationModel.Carpark.destinations[0] == destinationModel;
			if (destinationModel.Carpark.SupportsTwoDestinations && destinationModel.Carpark.destinations.Count == 2)
			{
				DestinationModel destinationModel2 = destinationModel.Carpark.destinations[flag2 ? 1 : 0];
				num = destinationModel2.GroupIndex;
				flag = destinationModel2.IsUpgraded;
			}
			RemoveAnyBuilding();
			if (flag2)
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, destinationModel.GroupIndex, expansionTime2, destinationModel.IsUpgraded, num, flag);
			}
			else
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, num, expansionTime2, flag, destinationModel.GroupIndex, destinationModel.IsUpgraded);
			}
		}
	}

	public void FlipDestination()
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null || (tile.ContentType != TileContentType.Destination && tile.ContentType != TileContentType.Carpark))
		{
			return;
		}
		DestinationModel destinationModel = ((tile.ContentType != TileContentType.Carpark) ? (tile.ContentModel as DestinationModel) : (tile.ContentModel as CarparkModel).destinations[0]);
		Vector2Int coordinate = ((destinationModel.Carpark.Alignment != TileAlignment.Vertical) ? (destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(0, 1)) : (destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(1, 0)));
		if (destinationModel.Carpark.entranceAtTopLeft ^ destinationModel.Carpark.entranceAtBottomRight)
		{
			CarparkEntrance carparkEntrance = ((!destinationModel.Carpark.entranceAtTopLeft) ? CarparkEntrance.TopLeft : CarparkEntrance.BottomRight);
			_ = destinationModel.GroupIndex;
			CarparkPreference carparkPreference = ((!destinationModel.Carpark.SupportsTwoDestinations) ? CarparkPreference.Solo : CarparkPreference.Double);
			int num = -1;
			bool flag = false;
			bool flag2 = destinationModel.Carpark.destinations[0] == destinationModel;
			if (destinationModel.Carpark.SupportsTwoDestinations && destinationModel.Carpark.destinations.Count == 2)
			{
				DestinationModel destinationModel2 = destinationModel.Carpark.destinations[flag2 ? 1 : 0];
				num = destinationModel2.GroupIndex;
				flag = destinationModel2.IsUpgraded;
			}
			RemoveAnyBuilding();
			Fix64 expansionTime = _clock.ExpansionTime;
			TileDirection drivewayDirection = ((destinationModel.Carpark.Alignment == TileAlignment.Horizontal) ? TileDirection.East : TileDirection.South);
			if (flag2)
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, destinationModel.GroupIndex, expansionTime, destinationModel.IsUpgraded, num, flag);
			}
			else
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, num, expansionTime, flag, destinationModel.GroupIndex, destinationModel.IsUpgraded);
			}
		}
	}

	public void UpgradeDestination()
	{
		SetDestinationUpgraded(isUpgraded: true);
	}

	public void DowngradeDestinations()
	{
		SetDestinationUpgraded(isUpgraded: false);
	}

	private void SetDestinationUpgraded(bool isUpgraded)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null || tile.ContentType != TileContentType.Destination)
		{
			return;
		}
		DestinationModel destinationModel = tile.ContentModel as DestinationModel;
		if (destinationModel.IsUpgraded == isUpgraded)
		{
			return;
		}
		if (!isUpgraded)
		{
			Vector2Int coordinate = ((destinationModel.Carpark.Alignment != TileAlignment.Vertical) ? destinationModel.Carpark.destinations[0].TileModels[0].Coordinates : (destinationModel.Carpark.destinations[0].TileModels[0].Coordinates - new Vector2Int(1, 0)));
			CarparkEntrance carparkEntrance = ((destinationModel.Carpark.entranceAtTopLeft && destinationModel.Carpark.entranceAtBottomRight) ? CarparkEntrance.TopLeftAndBottomRight : (destinationModel.Carpark.entranceAtTopLeft ? CarparkEntrance.TopLeft : CarparkEntrance.BottomRight));
			CarparkPreference carparkPreference = ((!destinationModel.Carpark.SupportsTwoDestinations) ? CarparkPreference.Solo : CarparkPreference.Double);
			int num = -1;
			bool flag = false;
			bool flag2 = destinationModel.Carpark.destinations[0] == destinationModel;
			if (destinationModel.Carpark.SupportsTwoDestinations && destinationModel.Carpark.destinations.Count == 2)
			{
				DestinationModel destinationModel2 = destinationModel.Carpark.destinations[flag2 ? 1 : 0];
				num = destinationModel2.GroupIndex;
				flag = destinationModel2.IsUpgraded;
			}
			RemoveAnyBuilding();
			Fix64 expansionTime = _clock.ExpansionTime;
			TileDirection drivewayDirection = ((destinationModel.Carpark.Alignment == TileAlignment.Horizontal) ? TileDirection.East : TileDirection.South);
			if (flag2)
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, destinationModel.GroupIndex, expansionTime, upgrade: false, num, flag);
			}
			else
			{
				SpawnDestination(coordinate, carparkEntrance, carparkPreference, drivewayDirection, num, expansionTime, flag, destinationModel.GroupIndex, secondUpgrade: false);
			}
		}
		else
		{
			destinationModel.demandLevelUpTime = _clock.ExpansionTime;
		}
	}

	public void SetSpawningMode(CityPlanModel.BuildingSpawningMode mode)
	{
		_cityPlanModel.SpawningMode = mode;
	}

	public CityPlanModel.BuildingSpawningMode GetSpawningMode()
	{
		return _cityPlanModel.SpawningMode;
	}

	public void SetClockPaused(bool paused)
	{
		_clock.isPaused = paused;
	}

	public void ChangePeepCount(int deltaPeepCount, DestinationModel destination)
	{
		if (deltaPeepCount > 0)
		{
			int num = Mathf.Min(destination.TotalDemand + deltaPeepCount, Scope.Get<City>().Rules.GetMaximumDemandForDestination(destination));
			while (num > destination.TotalDemand)
			{
				destination.unassignedDemand.Add(destination.GroupIndex);
			}
		}
		else
		{
			int num2 = Mathf.Max(destination.unassignedDemand.Count + deltaPeepCount, 0);
			while (num2 < destination.unassignedDemand.Count)
			{
				destination.unassignedDemand.RemoveAt(destination.unassignedDemand.Count - 1);
			}
		}
	}

	public void ChangePeepCount(int deltaPeepCount, int targetGroupIndex = -1)
	{
		ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
		while (enumerator.MoveNext())
		{
			DestinationModel current = enumerator.Current;
			if (current.isActive && (current.GroupIndex == targetGroupIndex || targetGroupIndex == -1))
			{
				ChangePeepCount(deltaPeepCount, current);
			}
		}
	}

	public void SetPinCountOnDestination(int pinCount)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null)
		{
			return;
		}
		IModel contentModel = tile.ContentModel;
		DestinationModel destinationModel2;
		if (!(contentModel is CarparkModel carparkModel))
		{
			if (!(contentModel is DestinationModel destinationModel))
			{
				Diagnostics.FailAssert("Can't find destination from {0}.", tile.ContentModel);
				return;
			}
			destinationModel2 = destinationModel;
		}
		else
		{
			destinationModel2 = carparkModel.destinations[0];
		}
		int deltaPeepCount = pinCount - destinationModel2.unassignedDemand.Count;
		ChangePeepCount(deltaPeepCount, destinationModel2);
	}

	public void SetGroupIndex(int groupIndex)
	{
		Tile tile = _simulation.GetModel<TilemapModel>().GetTile(cursorTilePosition);
		if (tile == null)
		{
			return;
		}
		IModel contentModel = tile.ContentModel;
		if (!(contentModel is HouseModel houseModel))
		{
			if (contentModel is DestinationModel destinationModel)
			{
				destinationModel.GroupIndex = groupIndex;
				return;
			}
			Diagnostics.FailAssert("Can't set group index on {0}.", tile.ContentModel);
		}
		else
		{
			houseModel.GroupIndex = groupIndex;
		}
	}
}
