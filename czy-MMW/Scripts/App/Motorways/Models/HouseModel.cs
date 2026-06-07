using System;
using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Processes;
using Server;

namespace Motorways.Models
{
	public class HouseModel : Model<EmptyModelFrame, HouseModel.IObserver>
	{
		public interface IObserver
		{
			void OnHouseChangedGroup(HouseModel house, int oldGroupIndex, int newGroupIndex);

			void OnHouseRemoved(HouseModel house);
		}

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private CityPlanModel _cityPlanModel;

		private static readonly Fix64 LaneDistanceFromDrivewayEnds = Fix64.FromRaw(1288490240L);

		private int _groupIndex;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("HouseModel");

		public List<VehicleModel> waitingVehicles = new List<VehicleModel>();

		public List<VehicleModel> realigningVehicles = new List<VehicleModel>();

		public List<VehicleModel> ownedVehicles = new List<VehicleModel>();

		public int GroupIndex
		{
			get
			{
				return _groupIndex;
			}
			set
			{
				if (_groupIndex != value)
				{
					int groupIndex = _groupIndex;
					_groupIndex = value;
					ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.OnHouseChangedGroup(this, groupIndex, _groupIndex);
					}
					_cityPlanModel.groupHouseCounts[groupIndex]--;
					_cityPlanModel.groupHouseCounts[_groupIndex]++;
					_simulation.GetModel<DemandModel>().doesSupplyNeedRecalculation = true;
				}
			}
		}

		[Serialize(true, null)]
		public TileModel tileModel { get; private set; }

		public TileDirection DrivewayDirection
		{
			get
			{
				LaneModel drivewayLane = DrivewayLane;
				foreach (TileDirection value in Enum.GetValues(typeof(TileDirection)))
				{
					if (drivewayLane.roadChunk.GetLanesConnectedToDirection(RoadState.Active, value).Count > 0)
					{
						return value;
					}
				}
				return TileDirection.None;
			}
		}

		public LaneModel DrivewayLane
		{
			get
			{
				if (tileModel != null && tileModel.roadChunk != null)
				{
					for (int i = 0; i < tileModel.roadChunk.lanes.Count; i++)
					{
						if (tileModel.roadChunk.lanes[i].state == RoadState.Active)
						{
							return tileModel.roadChunk.lanes[i];
						}
					}
					Diagnostics.FailAssert("House at {0} has {1} lanes but no active lane.", tileModel.Coordinates, tileModel.roadChunk.lanes.Count);
				}
				return null;
			}
		}

		public bool HasWaitingVehicle => waitingVehicles.Count > 0;

		public VehicleModel FirstWaitingVehicle
		{
			get
			{
				if (waitingVehicles.Count == 0)
				{
					return null;
				}
				VehicleModel vehicleModel = waitingVehicles[0];
				for (int i = 1; i < waitingVehicles.Count; i++)
				{
					if (waitingVehicles[i].CurrentFrame.distanceAlongLane > vehicleModel.CurrentFrame.distanceAlongLane)
					{
						vehicleModel = waitingVehicles[i];
					}
				}
				return vehicleModel;
			}
		}

		public TutorialIdentifier TutorialIdentifier { get; private set; }

		public void Initialize(int buildingGroupIndex, TileModel hostTile, TutorialIdentifier tutorialIdentifier)
		{
			_groupIndex = buildingGroupIndex;
			tileModel = hostTile;
			TutorialIdentifier = tutorialIdentifier;
			if (Diagnostics.Verify(tileModel.Tile.CanSetContentType(TileContentType.House), "Unable to build a house on {0}.", tileModel.Tile))
			{
				tileModel.Tile.SetContentType(TileContentType.House, this);
			}
		}

		public void Remove()
		{
			_simulation.GetModel<DemandModel>().doesSupplyNeedRecalculation = true;
			foreach (VehicleModel ownedVehicle in ownedVehicles)
			{
				ownedVehicle.Remove();
			}
			TileDirectionBitfield.Enumerator enumerator2 = this.tileModel.Tile.GetTwoLaneRoads(RoadState.Live).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				TileDirection current = enumerator2.Current;
				TileModel tileModel = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(this.tileModel.Coordinates, current));
				this.tileModel.Tile.SetNodeState(new RoadTileNode(current), RoadState.Mothballed);
				tileModel.Tile.SetNodeState(new RoadTileNode(TileUtilities.GetOppositeDirection(current)), RoadState.Mothballed);
				this.tileModel.Tile.SetNodeState(new RoadTileNode(current), RoadState.None);
				tileModel.Tile.SetNodeState(new RoadTileNode(TileUtilities.GetOppositeDirection(current)), RoadState.None);
				List<LaneModel> lanesConnectedToDirection = tileModel.roadChunk.GetLanesConnectedToDirection(RoadState.Live | RoadState.Pending, TileUtilities.GetOppositeDirection(current));
				List<RoadChunkModel.InboundVehicle> inboundVehicles = tileModel.roadChunk.inboundVehicles;
				for (int num = lanesConnectedToDirection.Count - 1; num >= 0; num--)
				{
					LaneModel laneModel = lanesConnectedToDirection[num];
					for (int num2 = laneModel.Vehicles.Count - 1; num2 >= 0; num2--)
					{
						laneModel.Vehicles[num2].ResetToHouse();
					}
					int num3 = 0;
					while (num3 < inboundVehicles.Count)
					{
						RoadChunkModel.InboundVehicle inboundVehicle = inboundVehicles[num3];
						if (inboundVehicle.vehicle.path.Contains(laneModel))
						{
							Log.Info("Resetting car {0} to it's home as it's inbound on deleted house lane.", inboundVehicle);
							inboundVehicle.vehicle.ResetToHouse();
						}
						else
						{
							num3++;
						}
					}
					tileModel.roadChunk.RemoveLane(laneModel);
				}
			}
			foreach (LaneModel lane in this.tileModel.roadChunk.lanes)
			{
				if (lane.Vehicles.Count > 0)
				{
					for (int num4 = lane.Vehicles.Count - 1; num4 >= 0; num4--)
					{
						VehicleModel vehicleModel = lane.Vehicles[num4];
						Log.Info("Resetting car {0} to it's home as it's currently on a deleted house lane {1}.", vehicleModel, lane);
						vehicleModel.ResetToHouse();
					}
				}
			}
			for (int num5 = this.tileModel.roadChunk.inboundVehicles.Count - 1; num5 >= 0; num5--)
			{
				RoadChunkModel.InboundVehicle inboundVehicle2 = this.tileModel.roadChunk.inboundVehicles[num5];
				Log.Info("Resetting car {0} to it's home as it's inbound on deleted house lane.", inboundVehicle2);
				inboundVehicle2.vehicle.ResetToHouse();
			}
			this.tileModel.roadChunk.RemoveAllLanes();
			ObserverList<IObserver>.Enumerator enumerator4 = base.Observers.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				enumerator4.Current.OnHouseRemoved(this);
			}
			this.tileModel.Tile.SetContentType(TileContentType.None, null);
			_simulation.RemoveModel(this);
		}

		public Fix64 GetLaneDistanceAtFrontOfDriveway(LaneModel drivewayLane)
		{
			return drivewayLane.Length - LaneDistanceFromDrivewayEnds;
		}

		public Fix64 GetLaneDistanceAtBackOfDriveway(LaneModel drivewayLane)
		{
			return LaneDistanceFromDrivewayEnds;
		}

		public Fix64 GetLaneDistanceAtCenterOfDriveway(LaneModel drivewayLane)
		{
			return drivewayLane.Length * Fix64Consts.OneHalf;
		}

		public override void Reset()
		{
			base.Reset();
			_groupIndex = 0;
			tileModel = null;
			ownedVehicles.Clear();
			waitingVehicles.Clear();
			realigningVehicles.Clear();
			TutorialIdentifier = TutorialIdentifier.None;
		}

		public HouseModel()
			: base(1)
		{
		}
	}
}
