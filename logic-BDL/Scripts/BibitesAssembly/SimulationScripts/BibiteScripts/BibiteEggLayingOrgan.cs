using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SteamIntegrations;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteEggLayingOrgan : BibiteSpatialOrgan, ISaveable
	{
		[NonSerialized]
		public UnityEvent onEggProduced = new UnityEvent();

		private BibiteGenes eggGene;

		private NEATBrain eggBrain;

		private GameObject spawnedEgg;

		[NonSerialized]
		public bool isMature;

		[NonSerialized]
		public float eggProgress;

		[NonSerialized]
		public float layingPeriod;

		[NonSerialized]
		public float eggSize;

		[NonSerialized]
		public int eggCapacity;

		[NonSerialized]
		public float eggEnergy;

		[NonSerialized]
		public float eggProgressRate;

		[NonSerialized]
		public float energyConsumption;

		[NonSerialized]
		public int nEggsLaid;

		private static readonly FloatSetting BibiteMassDensity = ScenarioSettings.Instance.bibiteMassDensity;

		private static float eggMassDensity = BibiteMassDensity.SubscribeTo<FloatSetting, float>(UpdateBibiteMassDensity);

		public const float EggProductionThreshold = 0.15f;

		public const float LayingThreshold = 0.25f;

		public const float EggReabsorptionEfficiency = 0.5f;

		private bool triggered100Children;

		[NonSerialized]
		public List<BibiteID> children = new List<BibiteID>();

		public List<int> childIDs;

		public float eggRadius => Mathf.Sqrt(eggSize / MathF.PI);

		public override float mass => eggMassDensity * eggSize * eggProgress;

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.WombWAG;

		public float nonFullEggEnergy => eggEnergy * eggProgress % 1f;

		public float storedEnergy => eggEnergy * eggProgress;

		public int nEgg => Mathf.FloorToInt(eggProgress);

		public float currentEggProgress
		{
			get
			{
				if (nEgg != eggCapacity || eggCapacity <= 0)
				{
					return eggProgress % 1f;
				}
				return 1f;
			}
		}

		public float eggProductionRemap => eggProduction.ThresholdRemap(0.15f);

		public float eggProduction => brain.Output(NEATBrain.Outputs.EggProduction);

		public float want2Lay => brain.Output(NEATBrain.Outputs.Want2Lay);

		private static void UpdateBibiteMassDensity(float val)
		{
			eggMassDensity = val;
		}

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			eggEnergy = genes.LayBodyEnergy + brain.brainUpkeepCost * genes.Gene(BibiteGenes.Genes.SizeRatio);
			layingPeriod = genes.Gene(BibiteGenes.Genes.LayTime);
			eggSize = genes.areaAtBirth;
			OnGrowth();
		}

		protected override void OnGrowth(float val = 1f)
		{
			base.OnGrowth(val);
			eggCapacity = Mathf.FloorToInt(area / eggSize);
		}

		public override void UpdateOrgan()
		{
			if (!isMature)
			{
				return;
			}
			if (Mathf.Abs(eggProduction) < 0.15f)
			{
				energyConsumption = 0f;
				eggProgressRate = 0f;
				return;
			}
			float num = metabolicRate * eggProductionRemap * Time.fixedDeltaTime / layingPeriod;
			num = ((!(num < 0f)) ? Mathf.Min(num, (float)eggCapacity - eggProgress) : Mathf.Max(num, 0f - eggProgress));
			if (num >= 0f)
			{
				body.UseEnergy(num * eggEnergy);
			}
			else
			{
				body.GainEnergy(Mathf.Abs(num * eggEnergy * 0.5f));
			}
			eggProgress += num;
			eggProgressRate = num / Time.fixedDeltaTime;
			energyConsumption = eggProgressRate * eggEnergy;
			if (eggProgress < 1f || want2Lay < 0.25f)
			{
				return;
			}
			float num2 = (ScenarioIndependentSettings.Instance.limitBibiteBirth.val ? ((float)ScenarioIndependentSettings.Instance.bibiteLimit.val) : float.PositiveInfinity);
			if (!((float)base.transform.parent.childCount >= num2))
			{
				while (eggProgress >= 1f)
				{
					LayEgg();
					eggProgress -= 1f;
				}
			}
		}

		public float LayEgg()
		{
			Transform transform = base.transform;
			Vector3 value = transform.position - transform.up * (8f * body.d1Size);
			spawnedEgg = WorldObjectsSpawner.Instance.GenerateNewEgg(value);
			eggGene = spawnedEgg.GetComponent<BibiteGenes>();
			eggBrain = spawnedEgg.GetComponent<NEATBrain>();
			EggHatching component = spawnedEgg.GetComponent<EggHatching>();
			component.birthOrientation = -transform.up;
			eggGene.CopyGene(genes, increaseGeneration: true, mutate: true);
			eggGene.SetParents(base.gameObject);
			eggBrain.CopyBrain(brain.Nodes, brain.Synapses, mutate: true);
			component.StartHatch(eggEnergy);
			children.Add(component.id);
			component.onHatch.AddListener(OnChildrenEggHatch);
			nEggsLaid++;
			if (!triggered100Children && children.Count >= 100)
			{
				triggered100Children = true;
				AchievementManager.Trigger("ACH_BIBITE_100CHILDREN", base.gameObject);
			}
			return eggEnergy;
		}

		private void OnChildrenEggHatch(EggHatching egg, BibiteBody child)
		{
			children.Remove(egg.id);
			if (child != null && child.born)
			{
				child.onDeath.AddListener(OnChildDeath);
				children.Add(child.id);
			}
		}

		private void OnChildDeath(BibiteBody child)
		{
			children.Remove(child.id);
		}

		public override void OnDeath()
		{
			base.OnDeath();
			float num = (ScenarioIndependentSettings.Instance.limitBibiteBirth.val ? ((float)ScenarioIndependentSettings.Instance.bibiteLimit.val) : float.PositiveInfinity);
			if (!((float)base.transform.parent.childCount >= num))
			{
				while (eggProgress >= 1f)
				{
					LayEgg();
					eggProgress -= 1f;
				}
			}
		}

		private void OnDestroy()
		{
			children.Clear();
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["eggProgress"] = eggProgress;
			jObject["nEggsLaid"] = nEggsLaid;
			if (children.Count > 0)
			{
				jObject["children"] = JToken.FromObject(children.Select((BibiteID c) => c.id).ToList());
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			if (state["eggProgress"] != null)
			{
				eggProgress = state["eggProgress"].ToObject<float>();
			}
			if (state["nEggsLaid"] != null)
			{
				nEggsLaid = state["nEggsLaid"].ToObject<int>();
			}
			if (state["children"] != null)
			{
				childIDs = state["children"].ToObject<List<int>>();
			}
		}
	}
}
