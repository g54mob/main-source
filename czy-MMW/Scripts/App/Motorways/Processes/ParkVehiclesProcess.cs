using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class ParkVehiclesProcess : IProcess, IReusable
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ParkVehiclesProcess");

		[Serialize(false, null)]
		private List<CarparkModel.ParkingSpace> _freeParkingSpaces = new List<CarparkModel.ParkingSpace>();

		[Dependency]
		private CityModel _cityModel;

		private static Fix64 VehicleParkingTime = (Fix64)3L;

		public void Reset()
		{
			_freeParkingSpaces.Clear();
		}

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			ModelListEnumerator<CarparkModel> enumerator = simulation.GetModels<CarparkModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				CarparkModel current = enumerator.Current;
				CarparkModel.ParkingSpace parkingSpace = null;
				foreach (CarparkModel.ParkingSpace space in current.spaces)
				{
					if (space.vehicle == null)
					{
						_freeParkingSpaces.Add(space);
					}
					else if (space.timeVehicleParked >= Fix64.Zero)
					{
						if (space.vehicle.behaviorState == VehicleModel.BehaviorState.DrivingHome)
						{
							if (space.vehicle.CurrentFrame.lane.roadChunk != space.parkRoadChunk)
							{
								space.vehicle.OnDepartedDestination();
								space.vehicle = null;
								space.timeVehicleParked = -Fix64.One;
								_freeParkingSpaces.Add(space);
							}
							continue;
						}
						space.timeVehicleParked += deltaTime;
						if (space.timeVehicleParked > VehicleParkingTime)
						{
							space.vehicle.behaviorState = VehicleModel.BehaviorState.DrivingHome;
							space.vehicle.RequestPathfind();
						}
						else if (parkingSpace == null || parkingSpace.timeVehicleParked < space.timeVehicleParked)
						{
							parkingSpace = space;
						}
					}
					else if (space.vehicle.CurrentFrame.lane.roadChunk == space.parkRoadChunk)
					{
						space.timeVehicleParked = Fix64.Zero;
						space.vehicle.behaviorState = VehicleModel.BehaviorState.ParkedAtDestination;
						space.vehicle.OnArrivedAtDestination();
					}
					else if (!Diagnostics.Verify(space.vehicle.path.Count > 0 || space.vehicle.NextFrame.lane.roadChunk == space.parkRoadChunk, "A parking vehicle does not have a path! It will be directed into its parking space again, or dispatched home immediately."))
					{
						VehicleModel vehicle = space.vehicle;
						if (vehicle.LastCommittedLane.OutboundLanes.Count == 1 && vehicle.LastCommittedLane.OutboundLanes[0].roadChunk == space.parkRoadChunk)
						{
							LaneModel laneModel = vehicle.LastCommittedLane.OutboundLanes[0];
							vehicle.AssignPath(new List<LaneModel> { laneModel }, laneModel.Length / Fix64Consts.Two);
							continue;
						}
						vehicle.behaviorState = VehicleModel.BehaviorState.DrivingHome;
						vehicle.RequestPathfind();
						vehicle.OnArrivedAtDestination();
						vehicle.OnDepartedDestination();
						space.vehicle = null;
						space.timeVehicleParked = -Fix64.One;
						_freeParkingSpaces.Add(space);
					}
				}
				if (_freeParkingSpaces.Count == 0 && parkingSpace != null)
				{
					bool flag = false;
					foreach (DestinationModel destination in current.destinations)
					{
						if (destination.waitingDemand.Count > 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						parkingSpace.vehicle.behaviorState = VehicleModel.BehaviorState.DrivingHome;
						parkingSpace.vehicle.RequestPathfind();
					}
				}
				int num = 0;
				while (num < current.vehiclesDrivingThrough.Count)
				{
					VehicleModel vehicleModel = current.vehiclesDrivingThrough[num];
					if (vehicleModel.CurrentFrame.lane.connection.input.type == RoadType.Carpark)
					{
						vehicleModel.OnArrivedAtDestination();
						vehicleModel.OnDepartedDestination();
						current.vehiclesDrivingThrough.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
				foreach (VehicleModel item in current.vehiclesEntering)
				{
					Log.Info("Attempting to park vehicle {0}.", item.id);
					bool flag2 = false;
					if (_freeParkingSpaces.Count > 0)
					{
						int num2 = ((_freeParkingSpaces.Count != 1) ? _cityModel.pseudorandomGenerator.Int(_freeParkingSpaces.Count) : 0);
						CarparkModel.ParkingSpace parkingSpace2 = _freeParkingSpaces[num2];
						List<LaneModel> list = new List<LaneModel>();
						LaneModel laneModel2 = item.LastCommittedLane;
						if (!Diagnostics.Verify(current.entranceLanes.Contains(laneModel2), "Somehow the carpark {0} was asked to park {1}, which has not committed to drive to the carpark's entrance lane. It is being dispatched home instead.", current, item))
						{
							laneModel2 = null;
						}
						while (laneModel2 != null)
						{
							LaneModel laneModel3 = null;
							LaneModel laneModel4 = null;
							foreach (LaneModel outboundLane in laneModel2.OutboundLanes)
							{
								if (outboundLane.connection.output.type == RoadType.Carpark)
								{
									laneModel4 = outboundLane;
								}
								else if (outboundLane.connection.output.type == RoadType.ParkingSpace && (outboundLane.roadChunk == parkingSpace2.innerRoadChunk || outboundLane.roadChunk == parkingSpace2.outerRoadChunk))
								{
									laneModel3 = outboundLane;
								}
							}
							if (laneModel3 != null)
							{
								if (Diagnostics.Verify(laneModel3.OutboundLanes.Count == 1 && laneModel3.OutboundLanes[0].connection.output.type == RoadType.ParkingSpace, "Vehicle {0} thought it found a path to a parking space within {1}, but the final lane {2} did not lead to a parking space. It will be dispatched home instead.", item, current, laneModel3))
								{
									flag2 = true;
									list.Add(laneModel3);
									list.Add(laneModel3.OutboundLanes[0]);
								}
								break;
							}
							if (!Diagnostics.Verify(laneModel4 != null, "Failed to find a route to a parking space in {0} for vehicle {1}. It will be dispatched home.", current, item))
							{
								break;
							}
							list.Add(laneModel4);
							laneModel2 = laneModel4;
						}
						if (flag2)
						{
							Log.Info("Vehicle {0} is parking at space {1}.", item.id, num2);
							_freeParkingSpaces.RemoveAt(num2);
							parkingSpace2.vehicle = item;
							parkingSpace2.timeVehicleParked = -Fix64.One;
							item.AssignPath(list, list[list.Count - 1].Length / Fix64Consts.Two);
						}
					}
					if (!flag2)
					{
						Log.Info("Vehicle {0} cannot find a free space so is driving through the carpark.", item.id);
						current.vehiclesDrivingThrough.Add(item);
						item.behaviorState = VehicleModel.BehaviorState.DrivingHome;
						item.RequestPathfind();
					}
					item.OnEnteredCarpark();
				}
				current.vehiclesEntering.Clear();
				_freeParkingSpaces.Clear();
			}
		}
	}
}
