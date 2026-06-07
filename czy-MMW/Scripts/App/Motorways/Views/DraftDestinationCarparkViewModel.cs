using FixMath;
using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public class DraftDestinationCarparkViewModel
	{
		public bool isDouble;

		public bool hasSecondDestination;

		public TileDirection carparkSide = TileDirection.None;

		public BuildingLayout buildingLayout = BuildingLayout.BuildingToSide;

		public Vector2Int bottomLeft = new Vector2Int(-1, -1);

		public DrivewayDirection singleDestinationAboveDrivewayDirections;

		public DrivewayDirection singleDestinationToSideDrivewayDirections = Motorways.Models.DrivewayDirection.North;

		public readonly DraftDestinationBuildingViewModel building1 = new DraftDestinationBuildingViewModel();

		public readonly DraftDestinationBuildingViewModel building2 = new DraftDestinationBuildingViewModel();

		public DraftDestinationBuildingViewModel activeBuilding;

		public bool isTrainStation;

		public bool isBoatTerminal;

		public Vector2Int maxCoordinates;

		public Vector2Int minCoordinates;

		public Vector2Int carparkCoordinates;

		public Vector2Int drivewayCoordinates;

		public Vector2Int secondDrivewayCoordinates;

		public DrivewayDirection DesiredDirection
		{
			get
			{
				if (isDouble)
				{
					return Motorways.Models.DrivewayDirection.Both;
				}
				if (buildingLayout == BuildingLayout.BuildingAbove)
				{
					return singleDestinationAboveDrivewayDirections;
				}
				return singleDestinationToSideDrivewayDirections;
			}
		}

		public CarparkEntrance CarparkEntrance
		{
			get
			{
				CarparkEntrance result = CarparkEntrance.TopLeft;
				switch (DesiredDirection)
				{
				case Motorways.Models.DrivewayDirection.North:
					result = CarparkEntrance.TopLeft;
					break;
				case Motorways.Models.DrivewayDirection.South:
					result = CarparkEntrance.BottomRight;
					break;
				case Motorways.Models.DrivewayDirection.East:
					result = CarparkEntrance.BottomRight;
					break;
				case Motorways.Models.DrivewayDirection.West:
					result = CarparkEntrance.TopLeft;
					break;
				case Motorways.Models.DrivewayDirection.Both:
					result = CarparkEntrance.TopLeftAndBottomRight;
					break;
				}
				return result;
			}
		}

		public CarparkPreference CarparkPref
		{
			get
			{
				if (!isBoatTerminal)
				{
					if (!isTrainStation)
					{
						if (!isDouble)
						{
							return CarparkPreference.Solo;
						}
						return CarparkPreference.ForceNewDouble;
					}
					return CarparkPreference.ForceNewStation;
				}
				return CarparkPreference.BoatTerminal;
			}
		}

		public TileDirection DrivewayDirection
		{
			get
			{
				if (buildingLayout != BuildingLayout.BuildingAbove)
				{
					return TileDirection.South;
				}
				return TileDirection.East;
			}
		}

		public Vector2Int PositionOverride => bottomLeft + ((!isDouble) ? ((buildingLayout == BuildingLayout.BuildingAbove) ? (Vector2Int.one + 3 * Vector2Int.down) : Vector2Int.down) : ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector2Int.one : Vector2Int.zero));

		public void InitializeNew(bool isDoubleIn, int groupIndex)
		{
			isDouble = isDoubleIn;
			isTrainStation = false;
			activeBuilding = building1;
			building1.groupIndex = groupIndex;
			carparkSide = TileDirection.West;
			buildingLayout = BuildingLayout.BuildingToSide;
		}

		public void InitializeExisting(DestinationModel destinationModel)
		{
			CarparkModel carpark = destinationModel.Carpark;
			if (!Diagnostics.Verify(carpark.destinations.Count > 0, "Carpark should have at least one destination"))
			{
				return;
			}
			isTrainStation = carpark.ActiveDestinationCount > 0 && carpark.destinations[0].IsTrainStation;
			isBoatTerminal = carpark.supportsBoats;
			isDouble = carpark.SupportsTwoDestinations;
			isTrainStation = destinationModel.IsTrainStation;
			carparkSide = carpark.carparkSide;
			buildingLayout = ((carpark.Alignment != TileAlignment.Horizontal) ? BuildingLayout.BuildingToSide : BuildingLayout.BuildingAbove);
			bottomLeft = carpark.origin + ((!isDouble) ? Vector2Int.up : ((buildingLayout == BuildingLayout.BuildingAbove) ? (2 * Vector2Int.down) : Vector2Int.zero));
			if (buildingLayout == BuildingLayout.BuildingAbove)
			{
				bottomLeft += new Vector2Int(-1, 1);
			}
			string errorMessage = "";
			if (!SetCoordinateData(ref errorMessage))
			{
				Diagnostics.Log.Error("DraftDestinationCarparkViewModel", "Error setting coordinate data for view model: {0}", errorMessage);
			}
			if (!isDouble)
			{
				if (carpark.entranceAtBottomRight)
				{
					singleDestinationAboveDrivewayDirections = Motorways.Models.DrivewayDirection.East;
					singleDestinationToSideDrivewayDirections = Motorways.Models.DrivewayDirection.South;
				}
				else
				{
					singleDestinationAboveDrivewayDirections = Motorways.Models.DrivewayDirection.West;
					singleDestinationToSideDrivewayDirections = Motorways.Models.DrivewayDirection.North;
				}
			}
			hasSecondDestination = carpark.ActiveDestinationCount > 1;
			activeBuilding = building1;
			for (int i = 0; i < carpark.destinations.Count; i++)
			{
				DestinationModel destinationModel2 = carpark.destinations[i];
				DraftDestinationBuildingViewModel draftDestinationBuildingViewModel = ((i == 0) ? building1 : building2);
				draftDestinationBuildingViewModel.groupIndex = destinationModel2.GroupIndex;
				draftDestinationBuildingViewModel.upgradeLevel = (destinationModel2.IsUpgraded ? 1 : 0);
				if (destinationModel == destinationModel2)
				{
					activeBuilding = draftDestinationBuildingViewModel;
				}
			}
		}

		public void RemoveBuilding(DraftDestinationBuildingViewModel building)
		{
			building.Reset();
			activeBuilding = null;
			hasSecondDestination = false;
			if (building == building1)
			{
				building1.groupIndex = building2.groupIndex;
				building1.upgradeLevel = building2.upgradeLevel;
				building2.Reset();
				activeBuilding = building1;
			}
		}

		public void Reset()
		{
			isDouble = false;
			isTrainStation = false;
			isBoatTerminal = false;
			carparkSide = TileDirection.None;
			buildingLayout = BuildingLayout.BuildingAbove;
			bottomLeft = new Vector2Int(-1, -1);
			hasSecondDestination = false;
			singleDestinationAboveDrivewayDirections = Motorways.Models.DrivewayDirection.West;
			singleDestinationToSideDrivewayDirections = Motorways.Models.DrivewayDirection.North;
			building1.Reset();
			building2.Reset();
		}

		public Vector3 GetLocalPositionBuilding1()
		{
			return GetLocalPositionBuilding(building1);
		}

		public Vector3 GetLocalPositionBuilding2()
		{
			return GetLocalPositionBuilding(building2);
		}

		private Vector3 GetLocalPositionBuilding(DraftDestinationBuildingViewModel building)
		{
			if (!isDouble || (building == activeBuilding && !isTrainStation))
			{
				return Vector3.zero;
			}
			Vector3 result = Vector3.zero;
			if (building == building1 && activeBuilding == building2)
			{
				result = 4f * ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector3.left : Vector3.up);
			}
			else if (building == building2 && activeBuilding == building1)
			{
				result = 4f * ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector3.right : Vector3.down);
			}
			if (isTrainStation && carparkSide == TileDirection.West)
			{
				result += 1.5f * Vector3.left;
			}
			else if (isTrainStation && carparkSide == TileDirection.North)
			{
				result += 1.5f * Vector3.up;
			}
			return result;
		}

		public Vector3 GetWorldPositionBuilding1()
		{
			Vector2Int vector2Int = bottomLeft + (isDouble ? new Vector2Int(1, 2) : new Vector2Int(1, -1));
			if (isTrainStation && carparkSide == TileDirection.North)
			{
				vector2Int += Vector2Int.down;
			}
			else if (isTrainStation && carparkSide == TileDirection.East)
			{
				vector2Int += Vector2Int.left;
			}
			Vector2Int coordinates = vector2Int + Vector2Int.one;
			return 0.5f * (Vector3)(TilemapModel.GetWorldPositionForCoordinates(vector2Int) + TilemapModel.GetWorldPositionForCoordinates(coordinates));
		}

		public Vector3 GetWorldPositionBuilding2()
		{
			Vector2Int vector2Int = bottomLeft + (isDouble ? new Vector2Int(1, 2) : new Vector2Int(1, -1)) + 2 * ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector2Int.right : Vector2Int.down);
			if (isTrainStation && carparkSide == TileDirection.North)
			{
				vector2Int += Vector2Int.down;
			}
			else if (isTrainStation && carparkSide == TileDirection.East)
			{
				vector2Int += Vector2Int.left;
			}
			Vector2Int coordinates = vector2Int + Vector2Int.one;
			return 0.5f * (Vector3)(TilemapModel.GetWorldPositionForCoordinates(vector2Int) + TilemapModel.GetWorldPositionForCoordinates(coordinates));
		}

		public Vector3 GetWorldPositionForActiveBuilding()
		{
			if (activeBuilding == building1)
			{
				return GetWorldPositionBuilding1();
			}
			return GetWorldPositionBuilding2();
		}

		public bool SetCoordinateData(ref string errorMessage)
		{
			bool result = true;
			minCoordinates = bottomLeft + ((!isDouble) ? ((buildingLayout == BuildingLayout.BuildingAbove) ? (Vector2Int.right + 2 * Vector2Int.down) : Vector2Int.down) : ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector2Int.one : Vector2Int.zero));
			maxCoordinates = minCoordinates + ((!isDouble) ? ((buildingLayout == BuildingLayout.BuildingAbove) ? new Vector2Int(1, 2) : new Vector2Int(2, 1)) : ((buildingLayout == BuildingLayout.BuildingAbove) ? new Vector2Int(3, 2) : new Vector2Int(2, 3)));
			carparkCoordinates = minCoordinates + ((!isDouble) ? ((buildingLayout == BuildingLayout.BuildingAbove) ? Vector2Int.zero : new Vector2Int(0, 1)) : ((buildingLayout == BuildingLayout.BuildingAbove) ? new Vector2Int(-2, 0) : Vector2Int.zero));
			switch (buildingLayout)
			{
			case BuildingLayout.BuildingAbove:
				if (isDouble)
				{
					drivewayCoordinates = minCoordinates + Vector2Int.left;
					secondDrivewayCoordinates = minCoordinates + 4 * Vector2Int.right;
					break;
				}
				switch (singleDestinationAboveDrivewayDirections)
				{
				case Motorways.Models.DrivewayDirection.East:
					drivewayCoordinates = carparkCoordinates + 2 * Vector2Int.right;
					break;
				case Motorways.Models.DrivewayDirection.West:
					drivewayCoordinates = carparkCoordinates + Vector2Int.left;
					break;
				default:
					result = false;
					errorMessage = "Invalid driveway direction " + singleDestinationAboveDrivewayDirections.ToString() + " for building layout " + buildingLayout;
					drivewayCoordinates = carparkCoordinates + new Vector2Int(0, 1);
					break;
				}
				break;
			case BuildingLayout.BuildingToSide:
				if (isDouble)
				{
					drivewayCoordinates = carparkCoordinates + Vector2Int.down;
					secondDrivewayCoordinates = carparkCoordinates + 4 * Vector2Int.up;
					break;
				}
				switch (singleDestinationToSideDrivewayDirections)
				{
				case Motorways.Models.DrivewayDirection.North:
					drivewayCoordinates = carparkCoordinates + Vector2Int.up;
					break;
				case Motorways.Models.DrivewayDirection.South:
					drivewayCoordinates = carparkCoordinates + 2 * Vector2Int.down;
					break;
				default:
					result = false;
					errorMessage = "Invalid driveway direction " + singleDestinationToSideDrivewayDirections.ToString() + " for building layout " + buildingLayout;
					drivewayCoordinates = carparkCoordinates + new Vector2Int(0, 1);
					break;
				}
				break;
			default:
				result = false;
				errorMessage = "Unhandled building layout " + buildingLayout;
				drivewayCoordinates = carparkCoordinates + new Vector2Int(0, 1);
				break;
			}
			return result;
		}

		public void BuildScheduled(DraftDestinationBuildingViewModel building, ref CityPlanModel.ScheduledBuilding scheduled)
		{
			scheduled.type = CityTileType.Demand;
			scheduled.carparkPreference = CarparkPref;
			scheduled.useFixedParameters = true;
			scheduled.positionOverride = PositionOverride;
			scheduled.drivewayDirectionOverride = DrivewayDirection;
			scheduled.entranceOverride = CarparkEntrance;
			scheduled.time = Fix64.Zero;
			scheduled.demandMultiplier = Fix64.One;
			scheduled.carparkSideOverride = carparkSide;
			scheduled.groupIndex = building.groupIndex;
			scheduled.initialUpgradeLevel = ((CarparkPref != CarparkPreference.ForceNewStation) ? building.upgradeLevel : 0);
			if (building == building2)
			{
				Vector2Int positionOverride = PositionOverride + ((buildingLayout == BuildingLayout.BuildingAbove) ? new Vector2Int(0, 2) : new Vector2Int(0, 3));
				scheduled.positionOverride = positionOverride;
				scheduled.carparkPreference = (isBoatTerminal ? CarparkPreference.JoinBoatTerminal : (isTrainStation ? CarparkPreference.Station : CarparkPreference.Double));
			}
		}
	}
}
