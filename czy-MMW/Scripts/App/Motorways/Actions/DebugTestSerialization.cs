using System.IO;
using Factory;
using Motorways.Models;
using Server;

namespace Motorways.Actions
{
	public class DebugTestSerialization : MotorwaysPlayerAction
	{
		private new static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DebugTestSerialization");

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter writer = new BinaryWriter(memoryStream))
			{
				base.Scope.Export(_simulation, writer);
			}
			byte[] buffer = memoryStream.ToArray();
			IScope parentScope = base.Scope.ParentScope;
			Scope scope = new Scope(base.Scope.Assembler)
			{
				ParentScope = parentScope
			};
			memoryStream = new MemoryStream(buffer);
			Simulation simulation;
			using (BinaryReader reader = new BinaryReader(memoryStream))
			{
				simulation = scope.Import<Simulation>(reader);
			}
			City city = _simulation.Scope.Get<City>();
			scope.Get<City>().Initialize(city.Definition, city.Rules);
			CompareSimulations((Simulation)_simulation, simulation);
			for (int i = 0; i < 10; i++)
			{
				_simulation.Step();
				simulation.Step();
				CompareSimulations((Simulation)_simulation, simulation);
			}
			scope.Release();
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		private void CompareSimulations(Simulation oldSimulation, Simulation newSimulation)
		{
			oldSimulation.Scope.Get<Clock>();
			newSimulation.Scope.Get<Clock>();
			ModelList<LaneModel> models = oldSimulation.GetModels<LaneModel>();
			newSimulation.GetModels<LaneModel>();
			Log.Info("Matching {0} lanes.", models.Count);
			for (int i = 0; i < models.Count; i++)
			{
			}
			ModelList<RoadChunkModel> models2 = oldSimulation.GetModels<RoadChunkModel>();
			ModelList<RoadChunkModel> models3 = newSimulation.GetModels<RoadChunkModel>();
			Log.Info("Matching {0} road chunks.", models2.Count);
			for (int j = 0; j < models2.Count; j++)
			{
				RoadChunkModel roadChunkModel = models2[j];
				RoadChunkModel roadChunkModel2 = models3[j];
				roadChunkModel.SortInboundVehicles();
				roadChunkModel2.SortInboundVehicles();
				if (Diagnostics.Verify(roadChunkModel.traversingVehicles.Count == roadChunkModel2.traversingVehicles.Count))
				{
					for (int k = 0; k < roadChunkModel.traversingVehicles.Count; k++)
					{
						_ = roadChunkModel.traversingVehicles[k];
						_ = roadChunkModel2.traversingVehicles[k];
					}
				}
			}
			ModelList<VehicleModel> models4 = oldSimulation.GetModels<VehicleModel>();
			ModelList<VehicleModel> models5 = newSimulation.GetModels<VehicleModel>();
			Log.Info("Matching {0} vehicles.", models4.Count);
			for (int l = 0; l < models4.Count; l++)
			{
				VehicleModel vehicleModel = models4[l];
				VehicleModel vehicleModel2 = models5[l];
				Log.Info("Matching path of length {0}.", vehicleModel.path.Count);
				for (int m = 0; m < vehicleModel.path.Count; m++)
				{
				}
				Log.Info("Matching return path of length {0}.", vehicleModel.returnPath.Count);
				for (int n = 0; n < vehicleModel.returnPath.Count; n++)
				{
				}
				for (int num = 0; num < vehicleModel.path.Count; num++)
				{
					foreach (RoadChunkModel.InboundVehicle inboundVehicle in vehicleModel2.path[num].roadChunk.inboundVehicles)
					{
						if (inboundVehicle.vehicle == vehicleModel2)
						{
							_ = inboundVehicle.chosenLane;
							_ = vehicleModel2.path[num];
						}
					}
				}
				for (int num2 = 0; num2 < vehicleModel.returnPath.Count; num2++)
				{
					foreach (RoadChunkModel.InboundVehicle returningInboundVehicle in vehicleModel2.returnPath[num2].roadChunk.returningInboundVehicles)
					{
						if (returningInboundVehicle.vehicle == vehicleModel2)
						{
							_ = returningInboundVehicle.chosenLane;
							_ = vehicleModel2.returnPath[num2];
						}
					}
				}
			}
		}

		public static DebugTestSerialization Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DebugTestSerialization debugTestSerialization = scope.Get<DebugTestSerialization>();
			debugTestSerialization.InitializeAction(owningGroup, timestamp);
			debugTestSerialization.OnActionBegin(timestamp);
			return debugTestSerialization;
		}
	}
}
