using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibitePheromoneOrgan : BibiteOrgan, ISaveable
	{
		public float pheromoneCost;

		private static readonly FloatSetting PheromoneProductionStrength = ScenarioSettings.Instance.pheromoneProductionStrength;

		private static readonly FloatSetting PheromoneProductionCost = ScenarioSettings.Instance.pheromoneProductionCost;

		private static float pheromoneProductionStrength = PheromoneProductionStrength.SubscribeTo<FloatSetting, float>(UpdatePheromoneProductionStrength);

		private static float pheromoneProductionCost = PheromoneProductionCost.SubscribeTo<FloatSetting, float>(UpdatePheromoneProductionCost);

		private static readonly BoolSetting PreventRedPheroProduction = ScenarioSettings.Instance.preventRedPheroProduction;

		private static readonly BoolSetting PreventGreenPheroProduction = ScenarioSettings.Instance.preventGreenPheroProduction;

		private static readonly BoolSetting PreventBluePheroProduction = ScenarioSettings.Instance.preventBluePheroProduction;

		private static bool preventRedPheroProduction = PreventRedPheroProduction.SubscribeTo<BoolSetting, bool>(UpdatePreventRedPheroProduction);

		private static bool preventGreenPheroProduction = PreventGreenPheroProduction.SubscribeTo<BoolSetting, bool>(UpdatePreventGreenPheroProduction);

		private static bool preventBluePheroProduction = PreventBluePheroProduction.SubscribeTo<BoolSetting, bool>(UpdatePreventBluePheroProduction);

		private PheromoneSpot spawnedPheromones;

		private float progress;

		private static void UpdatePheromoneProductionStrength(float val)
		{
			pheromoneProductionStrength = val;
		}

		private static void UpdatePheromoneProductionCost(float val)
		{
			pheromoneProductionCost = val;
		}

		private static void UpdatePreventRedPheroProduction(bool val)
		{
			preventRedPheroProduction = val;
		}

		private static void UpdatePreventGreenPheroProduction(bool val)
		{
			preventGreenPheroProduction = val;
		}

		private static void UpdatePreventBluePheroProduction(bool val)
		{
			preventBluePheroProduction = val;
		}

		public override void UpdateOrgan()
		{
			progress += Time.fixedDeltaTime;
			if (!(progress < 1f))
			{
				progress -= 1f;
				float num = (preventRedPheroProduction ? 0f : (brain.Output(NEATBrain.Outputs.PhereOut1) * pheromoneProductionStrength));
				float num2 = (preventGreenPheroProduction ? 0f : (brain.Output(NEATBrain.Outputs.PhereOut2) * pheromoneProductionStrength));
				float num3 = (preventBluePheroProduction ? 0f : (brain.Output(NEATBrain.Outputs.PhereOut3) * pheromoneProductionStrength));
				if (num + num2 + num3 > 0.05f)
				{
					spawnedPheromones = WorldObjectsSpawner.Instance.GenerateNewPheromonesSource(base.transform.position).GetComponent<PheromoneSpot>();
					spawnedPheromones.InitPheromones(num, num2, num3, base.transform.up);
					pheromoneCost = (num + num2 + num3) * pheromoneProductionCost;
					body.UseEnergy(pheromoneCost);
				}
			}
		}

		private void OnDestroy()
		{
			body = null;
			brain = null;
		}

		public JObject SaveState()
		{
			return new JObject { ["progress"] = progress };
		}

		public void LoadState(JObject state)
		{
			if (state["progress"] != null)
			{
				progress = (float)state["progress"];
			}
		}
	}
}
