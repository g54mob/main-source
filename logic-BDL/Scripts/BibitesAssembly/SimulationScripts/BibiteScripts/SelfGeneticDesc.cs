using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class SelfGeneticDesc : BaseGeneticDesc
	{
		[SerializeField]
		public float roleValue;

		public SelfGeneticDesc(BibiteBody bibite)
		{
			BibiteGenes gene = bibite.gene;
			NEATBrain brain = bibite.brain;
			genes = gene.genes;
			roleValue = gene.roleValue;
			nodes = brain.Nodes;
			synapses = brain.Synapses;
		}
	}
}
