using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using Utility;
using Utility.DataLogging;

namespace ManagementScripts
{
	public class GlobalLineageManager : MonoBehaviour, ISaveable, ISaveableBin
	{
		public static GlobalLineageManager Instance;

		[SerializeField]
		public List<Species> recordedSpecies = new List<Species>();

		[NonSerialized]
		public readonly List<Species> activeSpecies = new List<Species>();

		[SerializeField]
		public float maxEnergy;

		[SerializeField]
		public float maxCount;

		[SerializeField]
		public int logCounter;

		[SerializeField]
		public int nRecords;

		private static readonly FloatSetting SpeciesGeneticSpan = ScenarioIndependentSettings.Instance.speciesGeneticSpan;

		private static readonly FloatSetting SpeciesSpanScalingFactor = ScenarioIndependentSettings.Instance.speciesSpanScalingFactor;

		private static readonly IntSetting SpeciesPrunePointLimit = ScenarioIndependentSettings.Instance.speciesPrunePointLimit;

		public static float usedSpeciesSpan;

		[SerializeField]
		private FloatValueTextHandle usedSpanText;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
			SpeciesGeneticSpan.OnChange.AddListener(UpdateEffectiveSpeciesSpan);
			SpeciesSpanScalingFactor.OnChange.AddListener(UpdateEffectiveSpeciesSpan);
		}

		private void Start()
		{
			activeSpecies.RemoveAll((Species s) => s.count < 1);
			UpdateEffectiveSpeciesSpan();
		}

		public void UpdateEffectiveSpeciesSpan()
		{
			float val = SpeciesGeneticSpan.val;
			float val2 = SpeciesSpanScalingFactor.val;
			usedSpeciesSpan = val + (float)Mathf.Max((activeSpecies?.Count ?? 0) - 20, 0) * val2;
			usedSpanText.UpdateValue(usedSpeciesSpan);
		}

		public void LogSpeciesInfo()
		{
			logCounter++;
			if (recordedSpecies.Count > 0 && nRecords < 10000)
			{
				nRecords++;
			}
			recordedSpecies.ForEach(delegate(Species s)
			{
				s.LogSpeciesData();
			});
			maxEnergy = Mathf.Max(maxEnergy, activeSpecies.Sum((Species s) => s.energy));
			maxCount = Mathf.Max(maxCount, activeSpecies.Sum((Species s) => s.count));
			SpeciesTreeCleanup();
			activeSpecies.RemoveAll((Species s) => s.count < 1);
		}

		private void SpeciesTreeCleanup()
		{
			List<Species> list = new List<Species>();
			List<Species> list2 = new List<Species>();
			foreach (Species item in recordedSpecies.Except(activeSpecies))
			{
				if (item.speciesData.nPointsPresent <= SpeciesPrunePointLimit.val)
				{
					if (item.absoluteKeep)
					{
						list2.Add(item);
					}
					else
					{
						list.Add(item);
					}
				}
			}
			foreach (Species item2 in list2.OrderByDescending((Species s) => s.speciesData.totalIndexOfApparition))
			{
				List<Species> list3 = new List<Species>();
				list3.AddRange(item2.children);
				if (item2.parentSpecies != null)
				{
					list3.AddRange(item2.parentSpecies.children);
					if (item2.parentSpecies.children.Count < 1)
					{
						list3.Add(item2.parentSpecies);
					}
				}
				int startIndex = item2.speciesData.totalIndexOfApparition;
				list3 = (from s in list3
					where !s.absoluteKeep
					orderby (s.children.Count + 1) * s.speciesData.nPointsPresent * (Mathf.Abs(startIndex - s.speciesData.totalIndexOfApparition) + 1)
					select s).ToList();
				while (item2.speciesData.nPointsPresent <= SpeciesPrunePointLimit.val && list3.Count > 0)
				{
					Species species = list3.First();
					list3.Remove(species);
					PruneSpeciesFromTree(species, forcePruning: true, item2);
					if (list.Contains(species))
					{
						list.Remove(species);
					}
				}
				if (item2.speciesData.nPointsPresent < 1)
				{
					list.Add(item2);
				}
			}
			foreach (Species item3 in list)
			{
				PruneSpeciesFromTree(item3);
			}
		}

		public Species PruneSpeciesFromTree(Species speciesToPrune, bool forcePruning = false, Species speciesToMergeInto = null)
		{
			if (!forcePruning && speciesToPrune.speciesData.nPointsPresent > SpeciesPrunePointLimit.val)
			{
				return speciesToPrune;
			}
			Species parentSpecies = speciesToPrune.parentSpecies;
			parentSpecies?.children.Remove(speciesToPrune);
			foreach (Species child in speciesToPrune.children)
			{
				child.parentSpecies = parentSpecies;
				parentSpecies?.children.Add(child);
			}
			recordedSpecies.Remove(speciesToPrune);
			if (speciesToMergeInto == null)
			{
				speciesToMergeInto = parentSpecies ?? speciesToPrune.children.OrderByDescending((Species s) => s.speciesData.nPointsPresent).FirstOrDefault();
			}
			if (speciesToMergeInto == null)
			{
				return null;
			}
			speciesToMergeInto.speciesData.IncorporateSpeciesData(speciesToPrune.speciesData);
			foreach (BibiteBody bibite in speciesToPrune.bibites)
			{
				bibite.gene.species = speciesToMergeInto;
				speciesToMergeInto.bibites.Add(bibite);
			}
			foreach (EggHatching egg in speciesToPrune.eggs)
			{
				egg.eggGene.species = speciesToMergeInto;
				speciesToMergeInto.eggs.Add(egg);
			}
			speciesToPrune.parentSpecies = null;
			speciesToPrune.children.Clear();
			speciesToPrune.bibites.Clear();
			speciesToPrune.eggs.Clear();
			return speciesToMergeInto;
		}

		public void CheckNewSpecies(BibiteBody bibite)
		{
			Species species = bibite.gene.species;
			if (species == null)
			{
				foreach (Species activeSpecy in activeSpecies)
				{
					if (!(activeSpecy.GeneticDistanceToIndividual(bibite.gene.genes, bibite.brain.Nodes, bibite.brain.Synapses) > usedSpeciesSpan))
					{
						bibite.gene.species = activeSpecy;
						return;
					}
				}
				bibite.gene.species = CreateNewSpecies(bibite);
			}
			else
			{
				if (species.GeneticDistanceToIndividual(bibite.gene.genes, bibite.brain.Nodes, bibite.brain.Synapses) < usedSpeciesSpan)
				{
					return;
				}
				float num = usedSpeciesSpan * 0.5f;
				Species species2 = null;
				foreach (Species child in species.children)
				{
					if (child.count >= 1 && !(child.GeneticDistanceToIndividual(bibite.gene.genes, bibite.brain.Nodes, bibite.brain.Synapses) > num))
					{
						species2 = child;
					}
				}
				if (species2 != null)
				{
					bibite.gene.species = species2;
					return;
				}
				if (!bibite.gene.isMutant)
				{
					bibite.gene.isMutant = true;
					return;
				}
				bibite.gene.isMutant = false;
				BibiteBody bibiteBody = ((bibite.gene.parent1 == null) ? bibite : bibite.gene.parent1.GetComponent<BibiteBody>());
				species.RemoveFromSpecies(bibiteBody);
				Species species3 = CreateNewSpecies(bibiteBody, species);
				bibiteBody.gene.species = species3;
				if (!bibite.dying)
				{
					bibite.gene.species = species3;
					if (!bibiteBody.dying)
					{
						species3.AddToSpecies(bibiteBody);
					}
					bibiteBody.gene.isMutant = false;
				}
			}
		}

		public void CheckSpeciesOfEgg(EggHatching egg)
		{
			float num = float.MaxValue;
			Species species = null;
			foreach (Species activeSpecy in activeSpecies)
			{
				float num2 = activeSpecy.GeneticDistanceToIndividual(egg.eggGene.genes, egg.eggBrain.Nodes, egg.eggBrain.Synapses);
				if (num2 < num)
				{
					num = num2;
					species = activeSpecy;
				}
				if (!(num2 > usedSpeciesSpan))
				{
					egg.eggGene.species = activeSpecy;
					return;
				}
			}
			egg.eggGene.species = species;
		}

		public Species FindSpeciesFromTemplate(BibiteTemplate template, bool onlyLookUp = false)
		{
			if (string.IsNullOrEmpty(template.speciesName))
			{
				return CreateNewSpecies(template);
			}
			Species species = recordedSpecies.FirstOrDefault((Species s) => s.name == template.speciesName);
			if (species == null)
			{
				return CreateNewSpecies(template);
			}
			if (onlyLookUp || activeSpecies.Contains(species))
			{
				return species;
			}
			int num = recordedSpecies.IndexOf(species);
			for (int num2 = 0; num2 < activeSpecies.Count; num2++)
			{
				if (recordedSpecies.IndexOf(activeSpecies[num2]) > num)
				{
					activeSpecies.Insert(num2, species);
					break;
				}
			}
			if (!activeSpecies.Contains(species))
			{
				activeSpecies.Add(species);
			}
			UpdateEffectiveSpeciesSpan();
			return species;
		}

		public bool TemplateAlreadyHasSpecies(BibiteTemplate template)
		{
			if (!string.IsNullOrEmpty(template.speciesName))
			{
				return recordedSpecies.Any((Species s) => s.name == template.speciesName);
			}
			return false;
		}

		public Species CreateNewSpecies(BibiteTemplate template)
		{
			Species species = new Species(template);
			recordedSpecies.Add(species);
			activeSpecies.Add(species);
			UpdateEffectiveSpeciesSpan();
			return species;
		}

		public Species CreateNewSpecies(BibiteBody bibite, Species parentSpecies = null)
		{
			Species species = new Species(bibite, parentSpecies);
			if (parentSpecies != null)
			{
				int num = recordedSpecies.IndexOf(parentSpecies) + 1;
				recordedSpecies.Insert(num, species);
				for (int i = 0; i < activeSpecies.Count; i++)
				{
					if (recordedSpecies.IndexOf(activeSpecies[i]) > num)
					{
						activeSpecies.Insert(i, species);
						break;
					}
				}
				if (!activeSpecies.Contains(species))
				{
					activeSpecies.Add(species);
				}
			}
			else
			{
				recordedSpecies.Add(species);
				activeSpecies.Add(species);
			}
			UpdateEffectiveSpeciesSpan();
			return species;
		}

		private void OnDestroy()
		{
			SpeciesGeneticSpan.OnChange.RemoveListener(UpdateEffectiveSpeciesSpan);
			SpeciesSpanScalingFactor.OnChange.RemoveListener(UpdateEffectiveSpeciesSpan);
		}

		public JObject SaveState()
		{
			JObject jObject = SerializationHelper.SerializeGeneralObject(this);
			JArray jArray = new JArray();
			foreach (Species activeSpecy in activeSpecies)
			{
				if (activeSpecy.count > 0)
				{
					jArray.Add(activeSpecy.speciesID);
				}
			}
			jObject["activeSpeciesList"] = jArray;
			jObject["nodeMaxInnovation"] = NEATBrain.nodeMaxInov;
			jObject["connectionMaxInnovation"] = NEATBrain.connectionMaxInov;
			jObject["nextSpeciesID"] = Species.speciesMaxID;
			return jObject;
		}

		public void LoadState(JObject state)
		{
			if (state["nodeMaxInnovation"] != null)
			{
				NEATBrain.nodeMaxInov = state["nodeMaxInnovation"].ToObject<long>();
			}
			if (state["connectionMaxInnovation"] != null)
			{
				NEATBrain.connectionMaxInov = state["connectionMaxInnovation"].ToObject<long>();
			}
			if (state["nextSpeciesID"] != null)
			{
				Species.speciesMaxID = state["nextSpeciesID"].ToObject<long>();
			}
			SerializationHelper.DeserializeISavableCollection(recordedSpecies, (JArray)state["recordedSpecies"]);
			logCounter = state["logCounter"]?.ToObject<int>() ?? 0;
			nRecords = state["nRecords"]?.ToObject<int>() ?? 0;
			maxCount = state["maxCount"]?.ToObject<int>() ?? 0;
			maxEnergy = state["maxEnergy"]?.ToObject<float>() ?? 0f;
			foreach (JToken item2 in (IEnumerable<JToken>)state["activeSpeciesList"])
			{
				long speciesID = item2.ToObject<long>();
				Species item = recordedSpecies.FirstOrDefault((Species s) => s.speciesID == speciesID);
				activeSpecies.Add(item);
			}
			UpdateEffectiveSpeciesSpan();
			foreach (Species species in recordedSpecies)
			{
				if (species.parentID < 1)
				{
					species.rootSpecies = species;
					continue;
				}
				Species species2 = recordedSpecies.FirstOrDefault((Species s) => s.speciesID == species.parentID);
				if (species2 == null)
				{
					species.rootSpecies = species;
					continue;
				}
				species2.children.Add(species);
				species.parentSpecies = species2;
				species.rootSpecies = species.parentSpecies.rootSpecies ?? species.parentSpecies;
				while (species.rootSpecies.parentSpecies != null)
				{
					species.rootSpecies = species.rootSpecies.parentSpecies;
				}
			}
			if (SaveSystem.fromVersion < LineageVersionUpdater.toSpeciesData)
			{
				try
				{
					LineageVersionUpdater.LoadOlder06a10Data(state["speciesData"]);
					maxEnergy = LineageVersionUpdater.pre06a10MaxEnergy;
					nRecords = LineageVersionUpdater.nRecords;
				}
				catch (Exception exception)
				{
					PopupManager.DisplayError("Species Data Importer", "We tried our best, but there was an error loading the species data from the earlier version.");
					Debug.LogException(exception);
				}
			}
		}

		public int BytesSpace()
		{
			int num = 0;
			foreach (Species recordedSpecy in recordedSpecies)
			{
				num += 12 + recordedSpecy.speciesData.BytesSpace();
			}
			return num;
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			foreach (Species recordedSpecy in recordedSpecies)
			{
				int num = recordedSpecy.speciesData.BytesSpace();
				Buffer.BlockCopy(BitConverter.GetBytes(recordedSpecy.speciesID), 0, bytes, offset, 8);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset + 8, 4);
				recordedSpecy.speciesData.SaveStateBin(bytes, offset + 12);
				offset += 12 + num;
			}
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Utility.Version version, int offset = 0, int nBytes = -1)
		{
			int num = offset + nBytes;
			while (offset < num)
			{
				long id = BitConverter.ToInt64(bytes, offset);
				int num2 = BitConverter.ToInt32(bytes, offset + 8);
				recordedSpecies.FirstOrDefault((Species s) => s.speciesID == id)?.speciesData.LoadStateBin(bytes, version, offset + 12, num2);
				offset += 12 + num2;
			}
		}
	}
}
