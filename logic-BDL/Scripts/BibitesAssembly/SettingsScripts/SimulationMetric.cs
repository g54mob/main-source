using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using OneUseScripts;
using SettingScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;

namespace SettingsScripts
{
	public class SimulationMetric
	{
		public float lastVal;

		public readonly ChoiceSetting<SimMetric> metric = new ChoiceSetting<SimMetric>
		{
			Name = "Metric",
			HelperText = "The type of metric that you want to use",
			DefaultValue = SimMetric.Time,
			val = SimMetric.Time,
			choices = metricChoices
		};

		public readonly StringSimulationSetting argument = new StringSimulationSetting
		{
			DefaultValue = "",
			val = ""
		};

		public static SettingChoices<SimMetric> metricChoices = new SettingChoices<SimMetric>
		{
			choices = new List<SettingChoice<SimMetric>>
			{
				new SettingChoice<SimMetric>(SimMetric.TagCount, "Tag Count", "The number of alive bibites with that tag"),
				new SettingChoice<SimMetric>(SimMetric.TagBiomass, "Tag Biomass", "The total biomass (in E) of alive bibites with that tag"),
				new SettingChoice<SimMetric>(SimMetric.MaterialCount, "Material Count", "The number of pellets of that material"),
				new SettingChoice<SimMetric>(SimMetric.MaterialBiomass, "Material Biomass", "The total biomass (in E) of pellets of that material"),
				new SettingChoice<SimMetric>(SimMetric.Time, "Time", "Simulation time in seconds"),
				new SettingChoice<SimMetric>(SimMetric.Constant, "Constant", "Constant value")
			}
		};

		public static SettingChoices<SimMetric> metricChoicesWithoutConstant = new SettingChoices<SimMetric>
		{
			choices = metricChoices.choices.Where((SettingChoice<SimMetric> v) => v.val != SimMetric.Constant).ToList()
		};

		public float Evaluate()
		{
			lastVal = InternEval();
			return lastVal;
		}

		private float InternEval()
		{
			switch (metric.val)
			{
			case SimMetric.SpeciesCount:
			case SimMetric.SpeciesBiomass:
			{
				Species species = GlobalLineageManager.Instance.recordedSpecies.FirstOrDefault((Species s) => s.specificName == argument.val);
				if (species == null)
				{
					return 0f;
				}
				if (metric.val == SimMetric.SpeciesCount)
				{
					return species.count;
				}
				return species.energy;
			}
			case SimMetric.TagCount:
			case SimMetric.TagBiomass:
			{
				BibiteTag bibiteTag = TagsManager.instance.GetBibiteTag(argument.val);
				if (bibiteTag == null)
				{
					return 0f;
				}
				if (metric.val == SimMetric.TagCount)
				{
					return bibiteTag.count;
				}
				return bibiteTag.energy;
			}
			case SimMetric.MaterialCount:
			case SimMetric.MaterialBiomass:
			{
				MatterMaterial matterMaterial = MatterMaterialManager.PhysicalMaterials.FirstOrDefault((MatterMaterial m) => m.Name == argument.val);
				if (matterMaterial == null)
				{
					return 0f;
				}
				if (metric.val == SimMetric.MaterialCount)
				{
					return WorldObjectsSpawner.Instance.pelletsOfMaterial[matterMaterial].Count;
				}
				return WorldObjectsSpawner.Instance.pelletsOfMaterial[matterMaterial].Sum((MatterPellet p) => p.energy);
			}
			case SimMetric.Time:
				return (float)TimeKeeper.simulatedTime;
			case SimMetric.Constant:
				return float.Parse(argument.val);
			default:
				return 0f;
			}
		}

		public SimulationMetric()
		{
		}

		public SimulationMetric(SimMetric metric, string arg)
		{
			this.metric.SetValue(metric);
			argument.SetValue(arg);
		}
	}
}
