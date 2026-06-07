using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Math;

namespace Assets.Scripts.Design.Staging
{
	public class StageAnalyzer
	{
		public class StageEngine
		{
			public IReactionEngine Engine { get; private set; }

			public PartData Part { get; private set; }

			public float Thrust { get; set; }

			public StageEngine(IReactionEngine engine)
			{
				Part = engine.Part;
				Thrust = engine.MaximumThrust;
				Engine = engine;
			}
		}

		public class TankEngineSet
		{
			private float _fuelDensity;

			public List<StageEngine> Engines { get; set; }

			public IFuelSource FuelSource { get; set; }

			public float RemainingFuel { get; set; }

			public float TotalFlowRate
			{
				get
				{
					float num = 0f;
					foreach (StageEngine engine in Engines)
					{
						num += engine.Engine.MaximumMassFlowRate;
					}
					return num;
				}
			}

			public float TotalThrust
			{
				get
				{
					float num = 0f;
					foreach (StageEngine engine in Engines)
					{
						num += engine.Thrust;
					}
					return num * 100f;
				}
			}

			public TankEngineSet(IFuelSource fuelSource)
			{
				FuelSource = fuelSource;
				Engines = new List<StageEngine>();
				_fuelDensity = FuelSource.FuelType.Density;
				RemainingFuel = (float)(FuelSource.TotalFuel * (double)_fuelDensity);
			}

			public float CalculateBurnTime()
			{
				float totalFlowRate = TotalFlowRate;
				if (totalFlowRate > 0f)
				{
					return RemainingFuel / totalFlowRate;
				}
				return 0f;
			}
		}

		private class SubStage
		{
			public float BurnTime { get; internal set; }

			public float FuelMassBurned { get; set; }

			public float TotalFlowRate { get; internal set; }

			public float TotalThrust { get; internal set; }
		}

		public static StageAnalysis Analyze(ICraftScript craftScript, StagingData stagingData, float gravity, int startStageIndex = 0, int endStageIndex = 0)
		{
			StageAnalysis stageAnalysis = new StageAnalysis();
			List<PartConnection> list = new List<PartConnection>();
			if (endStageIndex == 0)
			{
				endStageIndex = stagingData.Stages.Count;
			}
			for (int i = startStageIndex; i < endStageIndex; i++)
			{
				ActivationStage activationStage = stagingData.Stages[i];
				List<StageEngine> list2 = new List<StageEngine>();
				foreach (PartData part in activationStage.Parts)
				{
					if (part.Config.StageActivationType == StageActivationType.Engine)
					{
						IReactionEngine modifierWithInterface = part.PartScript.GetModifierWithInterface<IReactionEngine>();
						if (modifierWithInterface != null)
						{
							list2.Add(new StageEngine(modifierWithInterface));
						}
					}
					else if (part.Config.StageActivationType == StageActivationType.Detacher)
					{
						foreach (PartConnection partConnection in part.PartConnections)
						{
							list.Add(partConnection);
						}
					}
					else
					{
						if (part.Config.StageActivationType != StageActivationType.Fairing)
						{
							continue;
						}
						foreach (PartConnection partConnection2 in part.PartConnections)
						{
							list.Add(partConnection2);
						}
					}
				}
				if (list2.Count > 0)
				{
					PartGraph partGraph = new PartGraph(craftScript.RootPart.Data, list);
					for (int num = list2.Count - 1; num >= 0; num--)
					{
						if (!partGraph.Parts.Contains(list2[num].Part))
						{
							list2.RemoveAt(num);
						}
					}
					StageAnalysis.Stage stage = AnalyzeStage(list2, partGraph.Parts, gravity);
					stage.StageNumber = i + 1;
					stageAnalysis.Stages.Add(stage);
					stageAnalysis.TotalDeltaV += stage.DeltaV;
					stageAnalysis.TotalThrust += stage.TotalThrust;
					stageAnalysis.TotalBurnTime += stage.BurnTime;
					stageAnalysis.NumEngines += stage.NumEngines;
				}
				if (stageAnalysis.Stages.Count > 0)
				{
					stageAnalysis.StartingThrustToWeightRatio = stageAnalysis.Stages[0].StartingThrustToWeightRatio;
					stageAnalysis.EndingThrustToWeightRatio = stageAnalysis.Stages[stageAnalysis.Stages.Count - 1].EndingThrustToWeightRatio;
				}
			}
			return stageAnalysis;
		}

		public static StageAnalysis.Stage AnalyzeStage(List<StageEngine> stageEngines, IReadOnlyList<PartData> parts, float gravity)
		{
			StageAnalysis.Stage stage = new StageAnalysis.Stage();
			float num = 0f;
			int num2 = 0;
			foreach (PartData part in parts)
			{
				if (!part.PartScript.Disconnected)
				{
					num += part.Mass * 100f;
					num2++;
				}
			}
			stage.StartingMass = num;
			stage.NumParts = num2;
			stage.NumEngines = stageEngines.Count;
			stage.Gravity = gravity;
			foreach (StageEngine stageEngine in stageEngines)
			{
				stage.TotalThrust += stageEngine.Thrust * 100f;
			}
			List<SubStage> list = FindSubStages(stageEngines);
			float num3 = 0f;
			float num4 = 0f;
			foreach (SubStage item in list)
			{
				float num5 = MathUtils.CalculateIsp(item.TotalThrust, item.TotalFlowRate);
				float startingMass = num;
				num -= item.FuelMassBurned;
				float num6 = MathUtils.CalculateDeltaV(startingMass, num, num5);
				stage.DeltaV += num6;
				stage.BurnTime += item.BurnTime;
				num3 += num5 * stage.DeltaV;
				num4 += stage.DeltaV;
			}
			if (num4 > 0f)
			{
				stage.AverageEngineIsp = num3 / num4;
			}
			stage.EndingMass = num;
			return stage;
		}

		private static List<SubStage> FindSubStages(List<StageEngine> stageEngines)
		{
			List<SubStage> list = new List<SubStage>();
			Dictionary<IFuelSource, TankEngineSet> dictionary = new Dictionary<IFuelSource, TankEngineSet>();
			int num = 0;
			while (num++ < 500)
			{
				SubStage subStage = new SubStage();
				foreach (TankEngineSet value in dictionary.Values)
				{
					value.Engines.Clear();
				}
				foreach (StageEngine stageEngine in stageEngines)
				{
					GetTankEngineSet(stageEngine, dictionary)?.Engines.Add(stageEngine);
				}
				int num2 = 0;
				float num3 = float.MaxValue;
				foreach (TankEngineSet value2 in dictionary.Values)
				{
					if (value2.Engines.Count <= 0)
					{
						continue;
					}
					float num4 = value2.CalculateBurnTime();
					if (num4 > 0f)
					{
						num2++;
						if (num3 > num4)
						{
							num3 = num4;
						}
					}
				}
				if (num2 <= 0)
				{
					break;
				}
				subStage.BurnTime = num3;
				foreach (TankEngineSet value3 in dictionary.Values)
				{
					if (value3.Engines.Count > 0)
					{
						float totalFlowRate = value3.TotalFlowRate;
						float num5 = totalFlowRate * subStage.BurnTime;
						if (num5 > value3.RemainingFuel)
						{
							num5 = value3.RemainingFuel;
						}
						subStage.TotalFlowRate += totalFlowRate;
						subStage.FuelMassBurned += num5;
						value3.RemainingFuel -= num5;
						subStage.TotalThrust += value3.TotalThrust;
					}
				}
				list.Add(subStage);
			}
			return list;
		}

		private static TankEngineSet GetTankEngineSet(StageEngine engine, Dictionary<IFuelSource, TankEngineSet> tankEngineSets)
		{
			IFuelSource fuelSource = engine.Engine.FuelSource;
			if (fuelSource == null || fuelSource.IsEmpty)
			{
				return null;
			}
			if (!tankEngineSets.ContainsKey(fuelSource))
			{
				tankEngineSets[fuelSource] = new TankEngineSet(fuelSource);
			}
			TankEngineSet tankEngineSet = tankEngineSets[fuelSource];
			if (tankEngineSet.RemainingFuel <= 0.001f)
			{
				return null;
			}
			return tankEngineSet;
		}
	}
}
