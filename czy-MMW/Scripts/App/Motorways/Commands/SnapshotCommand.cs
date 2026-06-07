using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Commands
{
	public class SnapshotCommand : Command, IReleasedFromScopeHandler
	{
		private ulong _prngSeed;

		private int _scheduledBuildingCount;

		private readonly List<Fix64> _vehicleLaneDistances = new List<Fix64>();

		private readonly List<VehicleDispatchRecord> _vehicleDispatches = new List<VehicleDispatchRecord>();

		private readonly List<Vector2Int> _houseCoordinates = new List<Vector2Int>();

		private readonly List<Vector2Int> _destinationCoordinates = new List<Vector2Int>();

		private readonly List<Fix64> _destinationDemandTimers = new List<Fix64>();

		[Dependency]
		private Clock _clock;

		public override void Execute(ISimulation simulation)
		{
			ulong seed = simulation.GetModel<CityModel>().pseudorandomGenerator.Seed;
			int count = simulation.GetModel<CityPlanModel>().scheduledBuildings.Count;
			List<Vector2Int> list = new List<Vector2Int>();
			ModelListEnumerator<HouseModel> enumerator = simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				list.Add(current.tileModel.Coordinates);
			}
			List<Vector2Int> list2 = new List<Vector2Int>();
			List<Fix64> list3 = new List<Fix64>();
			ModelListEnumerator<DestinationModel> enumerator2 = simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DestinationModel current2 = enumerator2.Current;
				list2.Add(current2.TileModels[0].Coordinates);
				list3.Add(current2.demandTimer);
			}
			List<Fix64> list4 = new List<Fix64>();
			ModelListEnumerator<VehicleModel> enumerator3 = simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator3.MoveNext())
			{
				VehicleModel current3 = enumerator3.Current;
				list4.Add(current3.CurrentFrame.distanceAlongLane);
			}
			SnapshotModel model = simulation.GetModel<SnapshotModel>();
			List<VehicleDispatchRecord> list5 = null;
			if (model != null)
			{
				list5 = model.vehicleDispatches;
			}
			if (_prngSeed == 0L)
			{
				_prngSeed = seed;
				_scheduledBuildingCount = count;
				_vehicleLaneDistances.AddRange(list4);
				_destinationCoordinates.AddRange(list2);
				_destinationDemandTimers.AddRange(list3);
				_houseCoordinates.AddRange(list);
				if (list5 != null)
				{
					_vehicleDispatches.AddRange(list5);
					model.vehicleDispatches.Clear();
				}
				return;
			}
			if (Diagnostics.Verify(_vehicleLaneDistances.Count == list4.Count, "Detected divergence in vehicle count on frame {0}.", _clock.FrameCount))
			{
				for (int i = 0; i < _vehicleLaneDistances.Count; i++)
				{
				}
			}
			if (Diagnostics.Verify(_houseCoordinates.Count == list.Count, "Detected divergence in house count on frame {0}.", _clock.FrameCount))
			{
				for (int j = 0; j < _houseCoordinates.Count; j++)
				{
				}
			}
			if (Diagnostics.Verify(_destinationCoordinates.Count == list2.Count, "Detected divergence in destination count on frame {0}.", _clock.FrameCount))
			{
				for (int k = 0; k < _destinationCoordinates.Count; k++)
				{
				}
			}
			if (list5 == null)
			{
				return;
			}
			if (Diagnostics.Verify(_vehicleDispatches.Count == list5.Count, "Detected divergence in vehicle dispatches on frame {0}.", _clock.FrameCount))
			{
				for (int l = 0; l < _vehicleDispatches.Count; l++)
				{
				}
			}
			foreach (VehicleDispatchRecord vehicleDispatch in model.vehicleDispatches)
			{
				simulation.Scope.Release(vehicleDispatch);
			}
			model.vehicleDispatches.Clear();
		}

		public override void Reset()
		{
			base.Reset();
			_prngSeed = 0uL;
			_scheduledBuildingCount = 0;
			_vehicleLaneDistances.Clear();
			_vehicleDispatches.Clear();
			_houseCoordinates.Clear();
			_destinationCoordinates.Clear();
			_destinationDemandTimers.Clear();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (VehicleDispatchRecord vehicleDispatch in _vehicleDispatches)
			{
				scope.Release(vehicleDispatch);
			}
			_vehicleDispatches.Clear();
		}
	}
}
