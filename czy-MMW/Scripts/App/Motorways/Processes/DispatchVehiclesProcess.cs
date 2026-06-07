using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class DispatchVehiclesProcess : IProcess, IReusable
	{
		private readonly List<DestinationModel> sortedDestinationsWithDemand = new List<DestinationModel>();

		[Dependency]
		private Pathfinder _pathfinder;

		[Dependency]
		private Clock _clock;

		public void Reset()
		{
			sortedDestinationsWithDemand.Clear();
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			if (simulation.IsPaused)
			{
				return;
			}
			ModelListEnumerator<DestinationModel> enumerator = simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.unassignedDemand.Count <= 0)
				{
					continue;
				}
				if (sortedDestinationsWithDemand.Count == 0)
				{
					sortedDestinationsWithDemand.Add(current);
					continue;
				}
				bool flag = false;
				for (int i = 0; i < sortedDestinationsWithDemand.Count; i++)
				{
					if (sortedDestinationsWithDemand[i].unassignedDemand.Count < current.unassignedDemand.Count)
					{
						sortedDestinationsWithDemand.Insert(i, current);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					sortedDestinationsWithDemand.Add(current);
				}
			}
			for (int j = 0; j < sortedDestinationsWithDemand.Count; j++)
			{
				DestinationModel destinationModel = sortedDestinationsWithDemand[j];
				if (j == sortedDestinationsWithDemand.Count - 1)
				{
					for (int k = 0; k < destinationModel.unassignedDemand.Count; k++)
					{
						int num = destinationModel.unassignedDemand[0];
						if (!DispatchVehicleToDestination(simulation, num, destinationModel))
						{
							break;
						}
						destinationModel.unassignedDemand.RemoveAt(0);
						destinationModel.waitingDemand.Add(num);
					}
					continue;
				}
				int num2 = Math.Min(Math.Max(destinationModel.unassignedDemand.Count / 2, 2), destinationModel.unassignedDemand.Count);
				for (int l = 0; l < num2; l++)
				{
					int num3 = destinationModel.unassignedDemand[0];
					if (!DispatchVehicleToDestination(simulation, num3, destinationModel))
					{
						break;
					}
					destinationModel.unassignedDemand.RemoveAt(0);
					destinationModel.waitingDemand.Add(num3);
				}
			}
			sortedDestinationsWithDemand.Clear();
		}

		private bool DispatchVehicleToDestination(ISimulation simulation, int groupIndex, DestinationModel destination)
		{
			int num = int.MaxValue;
			HouseModel houseModel = null;
			ModelListEnumerator<HouseModel> enumerator = simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				if (current.GroupIndex == groupIndex && current.HasWaitingVehicle)
				{
					int minPathCost = _pathfinder.GetMinPathCost(current.FirstWaitingVehicle.CurrentFrame.lane, destination.Carpark.entranceLanes, allowMothballedLaneUse: false);
					if (minPathCost != -1 && minPathCost < num)
					{
						num = minPathCost;
						houseModel = current;
					}
				}
			}
			if (houseModel != null)
			{
				VehicleModel firstWaitingVehicle = houseModel.FirstWaitingVehicle;
				List<LaneModel> list = _pathfinder.CreatePath(firstWaitingVehicle.CurrentFrame.lane, destination.Carpark.entranceLanes, allowMothballedLaneUse: false);
				if (Diagnostics.Verify(list != null && list.Count > 0))
				{
					if (FeatureToggle.IsFeatureEnabled(Feature.ValidateSimulationDeterminism))
					{
						SnapshotModel model = simulation.GetModel<SnapshotModel>();
						if (model != null)
						{
							VehicleDispatchRecord vehicleDispatchRecord = simulation.Scope.Get<VehicleDispatchRecord>();
							vehicleDispatchRecord.HouseCoordinates = firstWaitingVehicle.house.tileModel.Coordinates;
							vehicleDispatchRecord.DestinationCoordinates = destination.TileModels[0].Coordinates;
							vehicleDispatchRecord.SimulationFrame = _clock.FrameCount;
							model.vehicleDispatches.Add(vehicleDispatchRecord);
						}
					}
					firstWaitingVehicle.behaviorState = VehicleModel.BehaviorState.DrivingToDestination;
					firstWaitingVehicle.destination = destination;
					firstWaitingVehicle.AssignPath(list, -Fix64.One);
					firstWaitingVehicle.pathLengthAtStartOfJourney = firstWaitingVehicle.pathLength;
					list = _pathfinder.CreatePath(destination.Carpark.entranceLanes[0], houseModel.DrivewayLane, allowMothballedLaneUse: false);
					if (Diagnostics.Verify(list != null, "House at {0} has a path to a destination, but no path could be found back on simulation frame {1}.", houseModel.tileModel.Coordinates, _clock.FrameCount))
					{
						firstWaitingVehicle.AssignReturnPath(list);
					}
					firstWaitingVehicle.house.waitingVehicles.Remove(firstWaitingVehicle);
					firstWaitingVehicle.OnDepartedHouse();
					if (firstWaitingVehicle.house.HasWaitingVehicle)
					{
						firstWaitingVehicle.house.waitingVehicles[0].targetDistanceAlongLastLane = firstWaitingVehicle.house.GetLaneDistanceAtFrontOfDriveway(firstWaitingVehicle.house.DrivewayLane);
					}
					return true;
				}
			}
			return false;
		}
	}
}
