using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine.Events;

namespace SettingScripts
{
	public class BibiteSettings : ISaveable
	{
		public bool isExternal;

		public string filePath;

		public string fullPath;

		[NonSerialized]
		public string templateName;

		public UnityEvent<BibiteSettings> onSpawnSettingsChanged = new UnityEvent<BibiteSettings>();

		public readonly TargetZoneSetting spawnZone = new TargetZoneSetting
		{
			Name = "Spawn Zone",
			labelForNoTarget = "All",
			HelperText = "Which Zone will this species spawn in."
		};

		public readonly ChoiceSetting<Tagging> tagging = new ChoiceSetting<Tagging>
		{
			Name = "Tagging",
			val = Tagging.NoTagging,
			DefaultValue = Tagging.NoTagging,
			HelperText = "Tags are use to track bibites as they are inherited, not recommended as they are currently being replace by the species system.",
			choices = taggingChoices
		};

		public readonly StringSimulationSetting customTag = new StringSimulationSetting
		{
			Name = "Tag",
			HelperText = "Define your own custom tag",
			DefaultValue = "",
			val = ""
		};

		public readonly FloatSetting spawnPriority = new FloatSetting
		{
			Name = "Priority",
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.01f,
			maxValue = 100f,
			precision = 2,
			SI = false,
			HelperText = "This is used to determine how much of each default species is spawned. No purpose if only one default species is selected."
		};

		public readonly ChoiceSetting<SpawnType> spawnType = new ChoiceSetting<SpawnType>
		{
			Name = "Spawn Logic",
			DefaultValue = SpawnType.Continuous,
			val = SpawnType.Continuous
		};

		public readonly IntSetting minimumNumber = new IntSetting
		{
			Name = "Target Count",
			val = 10,
			DefaultValue = 10,
			minValue = 0,
			maxValue = 500,
			HelperText = "The number of bibites of that species that will be spawned."
		};

		public readonly ChoiceSetting<RandomizeGenes> randomizeGenes = new ChoiceSetting<RandomizeGenes>
		{
			Name = "Mutate Genes",
			val = RandomizeGenes.NormalMutations,
			DefaultValue = RandomizeGenes.NormalMutations,
			HelperText = "Should this bibite display mutations when spawned?",
			choices = randomizeGenesChoices
		};

		public readonly ChoiceSetting<GrowthAtSpawn> growthAtSpawn = new ChoiceSetting<GrowthAtSpawn>
		{
			Name = "Growth At Spawn",
			val = GrowthAtSpawn.Adult,
			DefaultValue = GrowthAtSpawn.Adult,
			choices = growthAtSpawnChoices
		};

		public static SettingChoices<Tagging> taggingChoices = new SettingChoices<Tagging>
		{
			choices = new List<SettingChoice<Tagging>>
			{
				new SettingChoice<Tagging>(Tagging.NoTagging, "None", "Bibites spawned from this template will not be tagged"),
				new SettingChoice<Tagging>(Tagging.SpeciesTagging, "Species", "Bibites spawned from this template will be tagged with the species name."),
				new SettingChoice<Tagging>(Tagging.CustomTagging, "Custom", "Define your own tag"),
				new SettingChoice<Tagging>(Tagging.RandomTagging, "Random Tag", "Bibites spawned from this template will receive a random alphanumeric tag")
			}
		};

		public static SettingChoices<RandomizeGenes> randomizeGenesChoices = new SettingChoices<RandomizeGenes>
		{
			choices = new List<SettingChoice<RandomizeGenes>>
			{
				new SettingChoice<RandomizeGenes>(RandomizeGenes.No, "No", "Bibites will spawn as exact copy of their template"),
				new SettingChoice<RandomizeGenes>(RandomizeGenes.NormalMutations, "Normal", "Bibites will spawn with mutations present according to their mutation genes as if they were birthed by an actual bibite"),
				new SettingChoice<RandomizeGenes>(RandomizeGenes.Color, "Random Color", "Each bibite spawned will have a random color"),
				new SettingChoice<RandomizeGenes>(RandomizeGenes.AllGenes, "All Genes", "Will randomize all genes of each bibite when spawned, only the brain will be preserved.")
			}
		};

		public static SettingChoices<GrowthAtSpawn> growthAtSpawnChoices = new SettingChoices<GrowthAtSpawn>
		{
			choices = new List<SettingChoice<GrowthAtSpawn>>
			{
				new SettingChoice<GrowthAtSpawn>(GrowthAtSpawn.Egg, "Egg", "Bibites will spawn as eggs."),
				new SettingChoice<GrowthAtSpawn>(GrowthAtSpawn.Baby, "Baby", "Bibites will spawn as they just had came out of their egg."),
				new SettingChoice<GrowthAtSpawn>(GrowthAtSpawn.Adult, "Adult", "Bibites will spawn as adults, already having the capacity to lay eggs."),
				new SettingChoice<GrowthAtSpawn>(GrowthAtSpawn.Elder, "Elder", "Bibites will spawn as elders, twice as developed as adults, which is not necessarily a stage that a bibite would get to on its own.")
			}
		};

		public static SettingChoices<SpawnType> spawnTypeChoices = new SettingChoices<SpawnType>
		{
			choices = new List<SettingChoice<SpawnType>>
			{
				new SettingChoice<SpawnType>(SpawnType.Continuous, "Continuous", "Virgin will keep spawning new virgin bibites when their total lineage count goes bellow the set target."),
				new SettingChoice<SpawnType>(SpawnType.OneTime, "Once", "This template will only spawned once up to the target and never again.")
			}
		};

		public bool hasMinimum => minimumNumber.val > 0;

		public void RebindToTarget()
		{
			spawnZone.RebindToTarget();
			spawnType.OnChange.AddListener(delegate
			{
				onSpawnSettingsChanged.Invoke(this);
			});
			minimumNumber.OnChange.AddListener(delegate
			{
				onSpawnSettingsChanged.Invoke(this);
			});
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["path"] = filePath;
			jObject["spawnPriority"] = spawnPriority.val;
			jObject["minimum"] = minimumNumber.val;
			jObject["randomizeGenes"] = randomizeGenes.val.ToString();
			jObject["growthAtSpawn"] = growthAtSpawn.val.ToString();
			jObject["tagging"] = tagging.val.ToString();
			jObject["spawnType"] = spawnType.val.ToString();
			if (tagging.val == Tagging.CustomTagging)
			{
				jObject["tag"] = customTag.val;
			}
			if (isExternal)
			{
				jObject["isExternal"] = true;
			}
			if (spawnZone.val != null)
			{
				jObject["spawnZone"] = spawnZone.val.zoneID;
			}
			return jObject;
		}

		public JObject SaveForChampion()
		{
			JObject jObject = new JObject();
			jObject["spawnPriority"] = spawnPriority.val;
			jObject["minimum"] = minimumNumber.val;
			jObject["randomizeGenes"] = randomizeGenes.val.ToString();
			jObject["growthAtSpawn"] = growthAtSpawn.val.ToString();
			jObject["spawnType"] = spawnType.val.ToString();
			if (spawnZone.val != null)
			{
				jObject["spawnZone"] = spawnZone.val.zoneID;
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			if (state["isExternal"] != null)
			{
				isExternal = state["isExternal"].ToObject<bool>();
			}
			filePath = state["path"].ToString();
			spawnPriority.SetValue(state["spawnPriority"].ToObject<float>());
			randomizeGenes.SetValue(state["randomizeGenes"].ToObject<RandomizeGenes>());
			if (state["tagging"] != null)
			{
				tagging.SetValue(state["tagging"].ToObject<Tagging>());
				if (tagging.val == Tagging.CustomTagging && state["tag"] != null)
				{
					customTag.SetValue(state["tag"].ToString());
				}
			}
			if (state["spawnZone"] != null)
			{
				spawnZone.targetID = state["spawnZone"].ToObject<int>();
			}
			if (state["spawnType"] != null)
			{
				spawnType.SetValue(state["spawnType"].ToObject<SpawnType>());
			}
			if (state["growthAtSpawn"] != null)
			{
				growthAtSpawn.SetValue(state["growthAtSpawn"].ToObject<GrowthAtSpawn>());
			}
			if (state["minimum"] != null)
			{
				minimumNumber.SetValue(state["minimum"].ToObject<int>());
			}
		}

		public void LoadForChampion(JObject state)
		{
			tagging.SetValue(Tagging.CustomTagging);
			customTag.SetValue("Champion");
			spawnPriority.SetValue(state["spawnPriority"].ToObject<float>());
			randomizeGenes.SetValue(state["randomizeGenes"].ToObject<RandomizeGenes>());
			if (state["spawnZone"] != null)
			{
				spawnZone.targetID = state["spawnZone"].ToObject<int>();
			}
			if (state["spawnType"] != null)
			{
				spawnType.SetValue(state["spawnType"].ToObject<SpawnType>());
			}
			if (state["growthAtSpawn"] != null)
			{
				growthAtSpawn.SetValue(state["growthAtSpawn"].ToObject<GrowthAtSpawn>());
			}
			if (state["minimum"] != null)
			{
				minimumNumber.SetValue(state["minimum"].ToObject<int>());
			}
		}
	}
}
