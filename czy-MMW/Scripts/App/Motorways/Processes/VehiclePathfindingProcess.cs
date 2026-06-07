using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class VehiclePathfindingProcess : IProcess, IReusable
	{
		[Dependency]
		private Pathfinder _pathfinder;

		[Dependency]
		private Clock _clock;

		[Serialize(false, null)]
		private List<VehicleModel> _vehiclesToPathfind = new List<VehicleModel>();

		private static readonly List<LaneModel> newPath = new List<LaneModel>();

		private static readonly List<LaneModel> newReturnPath = new List<LaneModel>();

		private static IEnumerable<LaneModel> enumerablePathHolder;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("VehiclePathfindingProcess");

		public void Reset()
		{
			_vehiclesToPathfind.Clear();
			newPath.Clear();
			newReturnPath.Clear();
			enumerablePathHolder = null;
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			int latestLaneChangeFrame = simulation.GetModel<CityModel>().latestLaneChangeFrame;
			ModelListEnumerator<VehicleModel> enumerator = simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				if (current.repathUrgency == VehicleModel.PathfindUrgency.NotRequired && current.returnRepathUrgency == VehicleModel.PathfindUrgency.NotRequired)
				{
					continue;
				}
				if (current.behaviorState == VehicleModel.BehaviorState.DrivingHome)
				{
					current.returnRepathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					if (current.LastCommittedLane.roadChunk == current.house.DrivewayLane.roadChunk)
					{
						current.repathUrgency = VehicleModel.PathfindUrgency.NotRequired;
						continue;
					}
				}
				if (current.behaviorState == VehicleModel.BehaviorState.ParkingAtDestination || current.behaviorState == VehicleModel.BehaviorState.ParkedAtDestination)
				{
					current.repathUrgency = VehicleModel.PathfindUrgency.NotRequired;
				}
				if (current.behaviorState == VehicleModel.BehaviorState.RealigningDriveway)
				{
					current.repathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					current.returnRepathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					continue;
				}
				VehicleModel.PathfindUrgency pathfindUrgency = ((current.repathUrgency > current.returnRepathUrgency) ? current.repathUrgency : current.returnRepathUrgency);
				if (pathfindUrgency == VehicleModel.PathfindUrgency.NotRequired || current.latestAttemptedPathfindFrame >= latestLaneChangeFrame)
				{
					continue;
				}
				bool num = pathfindUrgency == VehicleModel.PathfindUrgency.AsSoonAsPossible;
				int i = 0;
				if (!num)
				{
					for (; i < _vehiclesToPathfind.Count && _vehiclesToPathfind[i].latestAttemptedPathfindFrame <= current.latestAttemptedPathfindFrame; i++)
					{
					}
				}
				_vehiclesToPathfind.Insert(i, current);
			}
			foreach (VehicleModel item in _vehiclesToPathfind)
			{
				item.latestAttemptedPathfindFrame = _clock.FrameCount;
				bool flag = false;
				bool flag2 = false;
				newPath.Clear();
				newReturnPath.Clear();
				Fix64 newTargetDistanceAlongLastLane = -Fix64.One;
				if (item.behaviorState == VehicleModel.BehaviorState.DrivingToDestination)
				{
					bool flag3 = item.returnRepathUrgency != VehicleModel.PathfindUrgency.NotRequired;
					if (item.repathUrgency != VehicleModel.PathfindUrgency.NotRequired)
					{
						enumerablePathHolder = _pathfinder.CreatePath(item.LastCommittedLane, item.destination.Carpark.entranceLanes, allowMothballedLaneUse: true);
						if (Diagnostics.Verify(enumerablePathHolder != null, "Vehicle {0} could not find a path to the destination it is already driving towards on simulation frame {1}.", item.id, _clock.FrameCount))
						{
							flag = true;
							newPath.AddRange(enumerablePathHolder);
						}
						else
						{
							flag3 = false;
						}
					}
					if (flag3)
					{
						enumerablePathHolder = _pathfinder.CreatePath(item.destination.Carpark.entranceLanes[0], item.house.DrivewayLane, allowMothballedLaneUse: true);
						if (enumerablePathHolder == null)
						{
							TileDirectionBitfield.Enumerator enumerator3 = item.house.tileModel.Tile.GetTwoLaneRoads(RoadState.Mothballed).GetEnumerator();
							while (enumerator3.MoveNext())
							{
								TileDirection current3 = enumerator3.Current;
								LaneModel endLane = item.house.tileModel.roadChunk.GetLanesEnteringFromDirection(current3)[0];
								enumerablePathHolder = _pathfinder.CreatePath(item.destination.Carpark.entranceLanes[0], endLane, allowMothballedLaneUse: true);
								if (enumerablePathHolder != null)
								{
									break;
								}
							}
						}
						if (Diagnostics.Verify(enumerablePathHolder != null, "Vehicle {0} could not find a return path back to its house on simulation frame {1}.", item.id, _clock.FrameCount))
						{
							flag2 = true;
							newReturnPath.AddRange(enumerablePathHolder);
						}
					}
				}
				else if (item.behaviorState == VehicleModel.BehaviorState.DrivingHome)
				{
					enumerablePathHolder = _pathfinder.CreatePath(item.LastCommittedLane, item.house.DrivewayLane.roadChunk.lanes, allowMothballedLaneUse: true);
					if (Diagnostics.Verify(enumerablePathHolder != null, "Vehicle {0} could not find a path home on simulation frame {1}.", item.id, _clock.FrameCount))
					{
						flag = true;
						newPath.AddRange(enumerablePathHolder);
						if (newPath.Count > 0)
						{
							LaneModel drivewayLane = newPath[newPath.Count - 1];
							newTargetDistanceAlongLastLane = item.house.GetLaneDistanceAtFrontOfDriveway(drivewayLane);
						}
					}
				}
				else if (item.behaviorState == VehicleModel.BehaviorState.ParkedAtDestination || item.behaviorState == VehicleModel.BehaviorState.ParkingAtDestination)
				{
					LaneModel startLane = ((item?.destination?.Carpark != null) ? item.destination.Carpark.entranceLanes[0] : item.LastCommittedLane);
					enumerablePathHolder = _pathfinder.CreatePath(startLane, item.house.DrivewayLane, allowMothballedLaneUse: true);
					if (enumerablePathHolder == null)
					{
						TileDirectionBitfield.Enumerator enumerator3 = item.house.tileModel.Tile.GetTwoLaneRoads(RoadState.Mothballed).GetEnumerator();
						while (enumerator3.MoveNext())
						{
							TileDirection current4 = enumerator3.Current;
							List<LaneModel> lanesEnteringFromDirection = item.house.tileModel.roadChunk.GetLanesEnteringFromDirection(current4);
							if (Diagnostics.Verify(lanesEnteringFromDirection.Count > 0, "A house tile has no mothballed lanes in a direction that it says it does. Lies!"))
							{
								LaneModel endLane2 = lanesEnteringFromDirection[0];
								enumerablePathHolder = _pathfinder.CreatePath(startLane, endLane2, allowMothballedLaneUse: true);
								if (enumerablePathHolder != null)
								{
									break;
								}
							}
						}
					}
					if (Diagnostics.Verify(enumerablePathHolder != null, "Vehicle {0} could not find a path back to the house from the destination on simulation frame {1}.", item.id, _clock.FrameCount))
					{
						flag2 = true;
						newReturnPath.AddRange(enumerablePathHolder);
					}
				}
				else
				{
					Diagnostics.FailAssert("Vehicle {0} with behavior state {1} is requesting a pathfind.", item.id, item.behaviorState);
					item.repathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					item.returnRepathUrgency = VehicleModel.PathfindUrgency.NotRequired;
				}
				if (flag)
				{
					item.latestAttemptedPathfindFrame = 0;
					item.repathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					if (newPath.Count > 0)
					{
						item.AssignPath(newPath, newTargetDistanceAlongLastLane);
					}
				}
				if (flag2)
				{
					item.latestAttemptedPathfindFrame = 0;
					item.returnRepathUrgency = VehicleModel.PathfindUrgency.NotRequired;
					if (newReturnPath.Count > 0)
					{
						item.AssignReturnPath(newReturnPath);
					}
				}
				newPath.Clear();
				newReturnPath.Clear();
				enumerablePathHolder = null;
			}
			_vehiclesToPathfind.Clear();
		}
	}
}
