using System;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public abstract class BibiteSpatialOrgan : BibiteOrgan
	{
		protected BibiteGrowth growth;

		[NonSerialized]
		public float organAreaPortion;

		[NonSerialized]
		public float area;

		public abstract float mass { get; }

		protected abstract BibiteGenes.Genes apportionmentGene { get; }

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			growth = body.growth;
			organAreaPortion = Mathf.Max(genes.Gene(apportionmentGene), 0f) / genes.totalOrganWAG;
			if (organAreaPortion > 0f)
			{
				growth.onGrowth.AddListener(OnGrowth);
			}
			OnGrowth();
		}

		protected virtual void OnGrowth(float val = 1f)
		{
			area = Mathf.Max(body.baseBodyArea * organAreaPortion, 0f);
		}

		public override void OnDeath()
		{
			if (organAreaPortion > 0f)
			{
				growth.onGrowth.RemoveListener(OnGrowth);
			}
		}
	}
}
