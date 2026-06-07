using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public abstract class BibiteOrgan : MonoBehaviour
	{
		protected BibiteBody body;

		protected BibiteGenes genes;

		protected NEATBrain brain;

		protected float metabolicRate;

		public virtual void InitOrgan(BibiteBody bibite)
		{
			body = bibite;
			genes = body.gene;
			brain = body.brain;
			metabolicRate = genes.metabolicRate;
		}

		public abstract void UpdateOrgan();

		public virtual void OnDeath()
		{
		}
	}
}
