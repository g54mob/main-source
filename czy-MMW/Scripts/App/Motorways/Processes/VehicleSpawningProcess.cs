using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class VehicleSpawningProcess : IProcess, IReusable
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("VehicleSpawningProcess");

		private static readonly Fix64 VehicleDistanceToTargetThreshold = Fix64.FromRaw(214748368L);

		private static readonly Fix64 VehicleDistanceToHouseThreshold = Fix64.FromRaw(429496736L);

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			ModelListEnumerator<HouseModel> enumerator = simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				if (current.ownedVehicles.Count == 0)
				{
					LaneModel drivewayLane = current.DrivewayLane;
					if (drivewayLane != null)
					{
						for (int i = 0; i < 2; i++)
						{
							VehicleModel vehicleModel = simulation.Scope.Get<VehicleModel>();
							vehicleModel.MoveToLane(drivewayLane, (i == 0) ? current.GetLaneDistanceAtFrontOfDriveway(drivewayLane) : current.GetLaneDistanceAtBackOfDriveway(drivewayLane));
							vehicleModel.house = current;
							vehicleModel.behaviorState = VehicleModel.BehaviorState.WaitingForDestination;
							vehicleModel.lastNotifiedBehaviorState = VehicleModel.BehaviorState.WaitingForDestination;
							current.ownedVehicles.Add(vehicleModel);
							current.waitingVehicles.Add(vehicleModel);
							simulation.AddModel(vehicleModel);
						}
					}
				}
				else if (current.waitingVehicles.Count > 0)
				{
					int num = 0;
					while (num < current.waitingVehicles.Count)
					{
						VehicleModel vehicleModel2 = current.waitingVehicles[num];
						if (vehicleModel2.CurrentFrame.lane.state != RoadState.Mothballed)
						{
							num++;
						}
						else if (Fix64.Abs(vehicleModel2.targetDistanceAlongLastLane - vehicleModel2.CurrentFrame.distanceAlongLane) < VehicleDistanceToTargetThreshold)
						{
							bool num2 = vehicleModel2.targetDistanceAlongLastLane > current.GetLaneDistanceAtCenterOfDriveway(vehicleModel2.CurrentFrame.lane);
							LaneModel drivewayLane2 = current.DrivewayLane;
							Fix64 distanceAlongNewLane = (num2 ? current.GetLaneDistanceAtFrontOfDriveway(drivewayLane2) : current.GetLaneDistanceAtBackOfDriveway(drivewayLane2));
							vehicleModel2.MoveToLane(drivewayLane2, distanceAlongNewLane);
							num++;
						}
						else
						{
							vehicleModel2.behaviorState = VehicleModel.BehaviorState.RealigningDriveway;
							vehicleModel2.targetDistanceAlongLastLane = current.GetLaneDistanceAtCenterOfDriveway(vehicleModel2.CurrentFrame.lane);
							current.waitingVehicles.RemoveAt(num);
							current.realigningVehicles.Add(vehicleModel2);
						}
					}
				}
				if (current.realigningVehicles.Count <= 0)
				{
					continue;
				}
				int num3 = 0;
				while (num3 < current.realigningVehicles.Count)
				{
					VehicleModel vehicleModel3 = current.realigningVehicles[num3];
					bool flag = false;
					if (vehicleModel3.CurrentFrame.lane.state == RoadState.Mothballed)
					{
						if (Fix64.Abs(vehicleModel3.targetDistanceAlongLastLane - vehicleModel3.CurrentFrame.distanceAlongLane) < VehicleDistanceToHouseThreshold)
						{
							vehicleModel3.MoveToLane(current.DrivewayLane, current.GetLaneDistanceAtCenterOfDriveway(current.DrivewayLane));
							if (current.HasWaitingVehicle)
							{
								vehicleModel3.targetDistanceAlongLastLane = current.GetLaneDistanceAtBackOfDriveway(current.DrivewayLane);
							}
							else
							{
								vehicleModel3.targetDistanceAlongLastLane = current.GetLaneDistanceAtFrontOfDriveway(current.DrivewayLane);
								flag = true;
							}
						}
					}
					else
					{
						VehicleModel vehicleModel4 = current.DrivewayLane.FirstVehicleFromHouse(current);
						if (!current.HasWaitingVehicle && (vehicleModel4 == vehicleModel3 || vehicleModel4.behaviorState != VehicleModel.BehaviorState.RealigningDriveway))
						{
							vehicleModel3.targetDistanceAlongLastLane = current.GetLaneDistanceAtFrontOfDriveway(current.DrivewayLane);
							flag = true;
						}
						else
						{
							vehicleModel3.targetDistanceAlongLastLane = current.GetLaneDistanceAtBackOfDriveway(current.DrivewayLane);
							if (Fix64.Abs(vehicleModel3.targetDistanceAlongLastLane - vehicleModel3.CurrentFrame.distanceAlongLane) < VehicleDistanceToTargetThreshold)
							{
								vehicleModel3.targetDistanceAlongLastLane = vehicleModel3.CurrentFrame.distanceAlongLane;
								flag = true;
							}
						}
					}
					if (flag)
					{
						vehicleModel3.behaviorState = VehicleModel.BehaviorState.WaitingForDestination;
						current.waitingVehicles.Add(vehicleModel3);
						current.realigningVehicles.RemoveAt(num3);
					}
					else
					{
						num3++;
					}
				}
			}
		}
	}
}
