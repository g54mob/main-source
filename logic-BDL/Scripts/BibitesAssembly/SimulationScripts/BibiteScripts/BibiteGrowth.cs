using System;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteGrowth : MonoBehaviour
	{
		private BibiteGenes gene;

		private NEATBrain brain;

		private BibiteEggLayingOrgan eggLayer;

		private BibiteBody body;

		[NonSerialized]
		public readonly UnityEvent<float> onGrowth = new UnityEvent<float>();

		[SerializeField]
		public float growth;

		public float growthAtMature;

		private float appliedGrowth;

		private bool mature;

		private float sizeRatio;

		private float growthScale;

		private float growthMaturityFactor;

		private float growthMaturityExponent;

		private float metabolicRate;

		public float growthCost;

		[SerializeField]
		private float progress;

		private float growthUpdatePeriod = 0.2f;

		private bool growing;

		public float growthCostRate;

		private const float sizeUpdateThreshold = 0.005f;

		public float maturity => growth / growthAtMature;

		private void Awake()
		{
			gene = GetComponent<BibiteGenes>();
			brain = GetComponent<NEATBrain>();
			eggLayer = GetComponent<BibiteEggLayingOrgan>();
			body = GetComponent<BibiteBody>();
		}

		internal void StartGrowth()
		{
			growth = gene.BibiteGrowthAtBirth;
			ResumeGrowth();
		}

		internal void ResumeGrowth()
		{
			metabolicRate = gene.metabolicRate;
			growthAtMature = gene.GrowthAtBigEnoughEggOrgan;
			mature = growth >= growthAtMature;
			if (mature)
			{
				StartSystemsRequiringMaturity();
			}
			appliedGrowth = growth;
			sizeRatio = gene.Gene(BibiteGenes.Genes.SizeRatio);
			growthScale = gene.Gene(BibiteGenes.Genes.GrowthScale);
			growthMaturityFactor = gene.Gene(BibiteGenes.Genes.GrowthMaturityFactor);
			growthMaturityExponent = gene.Gene(BibiteGenes.Genes.GrowthMaturityExponent);
			growing = true;
		}

		private void FixedUpdate()
		{
			if (growing && Time.timeScale > 0f)
			{
				progress += Time.fixedDeltaTime;
				if (!(progress < Mathf.Max(growthUpdatePeriod, Time.fixedDeltaTime)))
				{
					growthUpdatePeriod = Mathf.Max(growthUpdatePeriod, Time.fixedDeltaTime);
					progress -= growthUpdatePeriod;
					float num = GrowthRate();
					float num2 = brain.Output(NEATBrain.Outputs.Want2Grow) * num * growthUpdatePeriod * growthScale / 100f;
					onGrowth.Invoke(growth + num2);
					SetMaturity(growth + num2);
					growthUpdatePeriod = 0.2f / num;
				}
			}
		}

		private float GrowthRate()
		{
			return GrowthRateFunction(maturity);
		}

		public float GrowthRateFunction(float value)
		{
			return metabolicRate / (1f + growthMaturityFactor * Mathf.Pow(value, growthMaturityExponent));
		}

		public static float GrowthFunction(float x, float scale, float factor, float exp)
		{
			return scale / (1f + factor * Mathf.Pow(x, exp));
		}

		private void SetMaturity(float newMaturity)
		{
			growth = newMaturity;
			bool flag = (growth - appliedGrowth) / appliedGrowth > 0.005f;
			growthCost = body.Set2DSize(growth * sizeRatio * sizeRatio, initialSet: false, flag);
			body.UseEnergy(growthCost);
			growthCostRate = growthCost / growthUpdatePeriod;
			if (flag)
			{
				appliedGrowth = growth;
			}
			if (!mature && growth >= growthAtMature)
			{
				mature = true;
				StartSystemsRequiringMaturity();
			}
			if (mature && growth < growthAtMature)
			{
				mature = false;
			}
		}

		private void StartSystemsRequiringMaturity()
		{
			eggLayer.isMature = true;
		}
	}
}
