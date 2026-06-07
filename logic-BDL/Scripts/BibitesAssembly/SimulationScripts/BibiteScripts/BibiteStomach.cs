using System;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteStomach : BibiteSpatialOrgan, ISaveable
	{
		[NonSerialized]
		public readonly UnityEvent<MatterMaterial, float> onMatterEnter = new UnityEvent<MatterMaterial, float>();

		[NonSerialized]
		public readonly UnityEvent<StomachContent> onNewMaterialEntered = new UnityEvent<StomachContent>();

		[NonSerialized]
		public readonly UnityEvent<MatterMaterial> onMaterialFinished = new UnityEvent<MatterMaterial>();

		[NonSerialized]
		public readonly UnityEvent<MatterMaterial, float> onMatterLeft = new UnityEvent<MatterMaterial, float>();

		public StomachContent[] stomachContents;

		public int nContent;

		private float diet;

		public float totalContent;

		public float acidLevel;

		public float acidRatio;

		private float d2Size;

		[FormerlySerializedAs("digestionPotential")]
		public float digestionEffectiveness;

		public float digestionPotentialBonus;

		public float efficiencyMalus;

		private static readonly FloatSetting StomachContentContribution = ScenarioSettings.Instance.stomachContentContribution;

		private static readonly FloatSetting MeatPower = ScenarioSettings.Instance.meatAffinityPowerFactor;

		private static readonly FloatSetting PlantPower = ScenarioSettings.Instance.plantAffinityPowerFactor;

		private static readonly FloatSetting MinPelletSize = ScenarioSettings.Instance.minPelletSize;

		private static float minPelletSize = MinPelletSize.SubscribeTo<FloatSetting, float>(UpdateMinPelletSize);

		private static float meatPower = MeatPower.SubscribeTo<FloatSetting, float>(UpdateMeatPower);

		private static float plantPower = PlantPower.SubscribeTo<FloatSetting, float>(UpdatePlantPower);

		private static float stomachContentContribution = StomachContentContribution.SubscribeTo<FloatSetting, float>(UpdateStomachContentContribution);

		public override float mass
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < nContent; i++)
				{
					num += stomachContents[i].mass;
				}
				return num * stomachContentContribution;
			}
		}

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.StomachWAG;

		public float fullness
		{
			get
			{
				if (!(area > 0f))
				{
					return 0f;
				}
				return totalAmount / area;
			}
		}

		public bool isEmpty => nContent < 1;

		public float digestOutput => brain.Output(NEATBrain.Outputs.Digestion);

		public float totalAmount
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < nContent; i++)
				{
					num += stomachContents[i].amount;
				}
				return num;
			}
		}

		public float availableSpace => Mathf.Max(area - totalAmount, 0f);

		public float EnergyGainRate
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < nContent; i++)
				{
					num += stomachContents[i].energyGainRate;
				}
				return num;
			}
		}

		private static void UpdateStomachContentContribution(float val)
		{
			stomachContentContribution = val;
		}

		private static void UpdateMeatPower(float val)
		{
			meatPower = val;
		}

		private static void UpdatePlantPower(float val)
		{
			plantPower = val;
		}

		private static void UpdateMinPelletSize(float val)
		{
			minPelletSize = val;
		}

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			diet = genes.Gene(BibiteGenes.Genes.Diet);
			if (stomachContents == null)
			{
				stomachContents = new StomachContent[MatterMaterialManager.PhysicalMaterials.Count];
			}
			for (int i = 0; i < nContent; i++)
			{
				stomachContents[i].affinity = AffinityToMaterial(stomachContents[i].material);
			}
			foreach (MatterMaterial physicalMaterial in MatterMaterialManager.PhysicalMaterials)
			{
				MatterMaterialManager.SettingsOfMaterial(physicalMaterial).maxEfficiency.Subscribe(UpdateAffinityOfMaterials);
				MatterMaterialManager.SettingsOfMaterial(physicalMaterial).minEfficiency.Subscribe(UpdateAffinityOfMaterials);
			}
		}

		public override void UpdateOrgan()
		{
			if (isEmpty)
			{
				return;
			}
			bool flag = false;
			totalContent = totalAmount;
			acidLevel = digestOutput;
			float num = fullness;
			acidRatio = ((num > 0f) ? (acidLevel / num) : 0f);
			float num2 = acidLevel - num;
			digestionPotentialBonus = ((acidLevel < num) ? 0f : num2);
			efficiencyMalus = ((acidLevel < num) ? 0f : (num2 / 2f));
			digestionEffectiveness = Mathf.Min(acidRatio, 1f) * metabolicRate * (1f + digestionPotentialBonus);
			for (int i = 0; i < nContent; i++)
			{
				StomachContent stomachContent = stomachContents[i];
				float efficiency = stomachContent.efficiency;
				float num3 = ((efficiency > 0f) ? (efficiency * (1f - efficiencyMalus)) : (efficiency - efficiencyMalus));
				float x = stomachContent.material.Reactivity * digestionEffectiveness * Time.fixedDeltaTime;
				float num4 = Mathf.Sqrt(stomachContent.averageChunkAmount / MathF.PI);
				x = MathF.Min(x, num4);
				float num5 = x * (2f * num4 - x) * MathF.PI;
				float num6 = stomachContent.approximateN * num5;
				if (x >= num4)
				{
					num6 = stomachContent.amount;
					flag = true;
					stomachContent.amount = -0.0001f;
					stomachContent.averageChunkAmount = 0f;
				}
				else
				{
					stomachContent.averageChunkAmount -= num5;
					stomachContent.averageChunkAmount = Mathf.Max(0f, stomachContent.averageChunkAmount);
					stomachContent.amount -= num6;
				}
				stomachContent.digestionRate = num6 / Time.fixedDeltaTime;
				stomachContent.lastConversionEfficiency = num3;
				body.GainEnergy(stomachContent.material.EnergyOfAmount(num6) * num3);
				stomachContents[i] = stomachContent;
			}
			if (!flag)
			{
				return;
			}
			for (int j = 0; j < nContent; j++)
			{
				if (!(stomachContents[j].amount > 0f))
				{
					onMaterialFinished.Invoke(stomachContents[j].material);
					stomachContents[j] = stomachContents[nContent - 1];
					nContent--;
					j--;
				}
			}
		}

		protected override void OnGrowth(float val = 1f)
		{
			base.OnGrowth(val);
			d2Size = body.d2Size;
		}

		public override void OnDeath()
		{
			base.OnDeath();
			foreach (MatterMaterial physicalMaterial in MatterMaterialManager.PhysicalMaterials)
			{
				MatterMaterialManager.SettingsOfMaterial(physicalMaterial).maxEfficiency.UnSubscribe(UpdateAffinityOfMaterials);
				MatterMaterialManager.SettingsOfMaterial(physicalMaterial).minEfficiency.UnSubscribe(UpdateAffinityOfMaterials);
			}
			if (isEmpty)
			{
				return;
			}
			Vector3 position = base.transform.position;
			for (int i = 0; i < nContent; i++)
			{
				StomachContent stomachContent = stomachContents[i];
				if (!(stomachContent.amount <= minPelletSize))
				{
					WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
					MatterMaterial material = stomachContent.material;
					Vector3? pos = position;
					float? amount = stomachContent.amount;
					instance.SpawnPelletOfMatter(material, pos, null, amount);
				}
			}
		}

		public void AddMatter(MatterMaterial material, float amount)
		{
			if (Mathf.Approximately(amount, 0f))
			{
				return;
			}
			int num = nContent;
			for (int num2 = nContent - 1; num2 >= 0; num2--)
			{
				if (!(stomachContents[num2].material != material))
				{
					num = num2;
					break;
				}
			}
			StomachContent stomachContent = stomachContents[num];
			amount = Mathf.Min(amount, availableSpace);
			if (num == nContent)
			{
				stomachContent.material = material;
				stomachContent.amount = amount;
				stomachContent.averageChunkAmount = Mathf.Max(0f, amount);
				stomachContent.affinity = AffinityToMaterial(stomachContent.material);
				onNewMaterialEntered.Invoke(stomachContent);
				nContent++;
			}
			else
			{
				float amount2 = stomachContent.amount;
				float averageChunkAmount = stomachContent.averageChunkAmount;
				stomachContent.averageChunkAmount = Mathf.Max(0f, averageChunkAmount / (1f + amount / amount2) + amount / (1f + amount2 / amount));
				stomachContent.amount += amount;
			}
			stomachContents[num] = stomachContent;
			onMatterEnter.Invoke(material, amount);
		}

		public float RemoveMatter(MatterMaterial material, float amount)
		{
			int num = nContent;
			for (int num2 = nContent - 1; num2 >= 0; num2--)
			{
				if (!(stomachContents[num2].material != material))
				{
					num = num2;
					break;
				}
			}
			StomachContent stomachContent = stomachContents[num];
			amount = Mathf.Min(amount, stomachContent.amount);
			if (amount > stomachContent.amount)
			{
				amount = stomachContent.amount;
				onMaterialFinished.Invoke(stomachContent.material);
				stomachContents[num] = stomachContents[nContent - 1];
				nContent--;
			}
			else
			{
				stomachContent.amount -= amount;
				stomachContents[num] = stomachContent;
			}
			onMatterLeft.Invoke(stomachContent.material, amount);
			return amount;
		}

		private float AffinityToMaterial(MatterMaterial mat)
		{
			if (mat == MatterMaterialManager.Meat)
			{
				return MathF.Pow(diet, meatPower);
			}
			if (mat == MatterMaterialManager.Plant)
			{
				return MathF.Pow(1f - diet, plantPower);
			}
			return 0f;
		}

		private void UpdateAffinityOfMaterials(float val)
		{
			for (int i = 0; i < stomachContents.Length; i++)
			{
				StomachContent stomachContent = stomachContents[i];
				if (!(stomachContent.material == null))
				{
					stomachContent.affinity = AffinityToMaterial(stomachContent.material);
					stomachContents[i] = stomachContent;
				}
			}
		}

		public JObject SaveState()
		{
			return new JObject { ["content"] = SerializationHelper.SerializeObject(stomachContents.Take(nContent).ToList()) };
		}

		public void LoadState(JObject state)
		{
			if (stomachContents == null)
			{
				stomachContents = new StomachContent[MatterMaterialManager.PhysicalMaterials.Count];
			}
			nContent = 0;
			if (state["content"] is JArray jArray)
			{
				for (int i = 0; i < jArray.Count; i++)
				{
					stomachContents[i].LoadState((JObject)jArray[i]);
					nContent++;
				}
			}
		}
	}
}
