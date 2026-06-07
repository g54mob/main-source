using System;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteFatOrgan : BibiteSpatialOrgan
	{
		[NonSerialized]
		public Matter fatReserves = new Matter();

		[NonSerialized]
		public float threshold;

		[NonSerialized]
		public float deadband;

		[NonSerialized]
		public float lastActivation;

		[NonSerialized]
		public float lastAmountDelta;

		[NonSerialized]
		public float lastAmountRate;

		[NonSerialized]
		public float lastAffinity;

		[NonSerialized]
		public float lastEnergyGain;

		[NonSerialized]
		public float lastEnergyGainRate;

		[NonSerialized]
		public float lastEnergySustainRate;

		[NonSerialized]
		public float inflateFactor;

		[NonSerialized]
		public float lastInflateFactor;

		[NonSerialized]
		public float maxInflateAmount;

		[NonSerialized]
		public float baseCapacity;

		public const float InflationAtMaxFactor = 0.35f;

		private static readonly FloatSetting FatSustain = ScenarioSettings.Instance.fatSustain;

		private static float fatSustain = FatSustain.SubscribeTo<FloatSetting, float>(UpdateFatSustain);

		public override float mass => fatReserves.mass;

		public float lastEfficiency => fatReserves.Material.ConversionEfficiency(lastAffinity);

		public float fullness => fatReserves.Amount / fatReserves.MaxAmount;

		public float overflowAmount => Mathf.Max(fatReserves.Amount - baseCapacity, 0f);

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.FatWAG;

		private static void UpdateFatSustain(float val)
		{
			fatSustain = val;
		}

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			fatReserves.Material = MatterMaterialManager.Fat;
			threshold = genes.Gene(BibiteGenes.Genes.FatStorageThreshold);
			deadband = genes.Gene(BibiteGenes.Genes.FatStorageDeadband);
			CheckInflateFactor(check: false);
		}

		protected override void OnGrowth(float val = 1f)
		{
			baseCapacity = body.baseBodyArea * organAreaPortion;
			maxInflateAmount = body.baseBodyArea * 0.35f;
			area = baseCapacity * Mathf.Min(2f, 1f + 0.35f / organAreaPortion);
			fatReserves.MaxAmount = area;
		}

		public override void UpdateOrgan()
		{
			float energyRatio = body.energyRatio;
			if (Mathf.Abs(energyRatio - threshold) < deadband || (energyRatio > threshold && fatReserves.isFull) || (energyRatio < threshold && fatReserves.isEmpty))
			{
				lastActivation = (lastAmountDelta = (lastAmountRate = (lastEnergyGain = (lastEnergyGainRate = 0f))));
				lastAffinity = 1f;
				lastEnergySustainRate = fatReserves.energy * fatSustain;
				body.UseEnergy(lastEnergySustainRate * Time.fixedDeltaTime);
				return;
			}
			lastActivation = ((energyRatio > threshold) ? Mathf.InverseLerp(Mathf.Min(threshold + deadband, 0.99f), 1f, energyRatio) : (0f - Mathf.InverseLerp(threshold - deadband, 0f, energyRatio)));
			if (lastActivation > 0f)
			{
				lastActivation *= 1f - Mathf.Pow(fatReserves.fullness, 10f);
			}
			lastAmountDelta = lastActivation * body.d2Size * metabolicRate * Mathf.Pow(fatReserves.Material.Reactivity * Time.fixedDeltaTime, 2f) * MathF.PI;
			lastAmountDelta = ((lastAmountDelta > 0f) ? Mathf.Min(lastAmountDelta, fatReserves.available) : Mathf.Max(lastAmountDelta, 0f - fatReserves.Amount));
			lastAmountRate = lastAmountDelta / Time.fixedDeltaTime;
			lastAffinity = 1f - Mathf.Sqrt(Mathf.Abs(lastActivation));
			lastEnergyGain = fatReserves.ConvertToFromEnergy(lastAmountDelta, lastAffinity);
			lastEnergyGainRate = lastEnergyGain / Time.fixedDeltaTime;
			body.GainEnergy(lastEnergyGain);
			lastEnergySustainRate = fatReserves.energy * fatSustain;
			body.UseEnergy(lastEnergySustainRate * Time.fixedDeltaTime);
			CheckInflateFactor();
		}

		public void CheckInflateFactor(bool check = true)
		{
			inflateFactor = Mathf.InverseLerp(0f, maxInflateAmount, overflowAmount);
			if (!check || !(Mathf.Abs(inflateFactor - lastInflateFactor) < 0.025f))
			{
				lastInflateFactor = inflateFactor;
				body.UpdateInflateFactor(inflateFactor);
			}
		}
	}
}
