using System.Collections.Generic;
using Assets.Scripts.Design.Staging;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;

namespace Assets.Scripts.Craft.FlightData
{
	public class CraftPerformanceData : LazyData, ICraftPerformanceData
	{
		private ICraftScript _craftScript;

		private ICraftFlightData _flightData;

		public double CurrentIsp { get; private set; }

		public double DeltaVStage { get; private set; }

		public float FuelAllStagesPercentage { get; private set; }

		public double RemainingBurnTime { get; private set; }

		public float ThrustToWeightRatio { get; private set; }

		public CraftPerformanceData(ICraftFlightData flightData, ICraftScript craftScript)
		{
			_flightData = flightData;
			_craftScript = craftScript;
			base.UpdatePeriod = 10;
		}

		protected override void UpdateData()
		{
			base.UpdateData();
			double num = 0.0;
			double num2 = 0.0;
			foreach (IFuelSource fuelSource in _craftScript.FuelSources.FuelSources)
			{
				if (fuelSource.FuelType != FuelType.Battery && fuelSource.FuelType != FuelType.Monopropellant)
				{
					double totalFuel = fuelSource.TotalFuel;
					if (totalFuel > 9.999999747378752E-05)
					{
						num += totalFuel;
					}
					num2 += fuelSource.TotalCapacity;
				}
			}
			if (num2 > 0.0)
			{
				FuelAllStagesPercentage = (float)(num / num2);
			}
			else
			{
				FuelAllStagesPercentage = 0f;
			}
			float num3 = _flightData.CurrentMass * _flightData.GravityMagnitude;
			if (num3 > 0f)
			{
				ThrustToWeightRatio = _flightData.CurrentEngineThrust / num3;
			}
			else
			{
				ThrustToWeightRatio = 0f;
			}
			RemainingBurnTime = 0.0;
			CurrentIsp = 0.0;
			DeltaVStage = 0.0;
			if (_flightData.ActiveEngines.Count <= 0)
			{
				return;
			}
			List<StageAnalyzer.StageEngine> list = new List<StageAnalyzer.StageEngine>();
			foreach (IReactionEngine activeEngine in _flightData.ActiveEngines)
			{
				list.Add(new StageAnalyzer.StageEngine(activeEngine));
			}
			StageAnalysis.Stage stage = StageAnalyzer.AnalyzeStage(list, _craftScript.Data.Assembly.Parts, _flightData.GravityMagnitude);
			RemainingBurnTime = stage.BurnTime;
			CurrentIsp = stage.AverageEngineIsp;
			DeltaVStage = stage.DeltaV;
		}
	}
}
