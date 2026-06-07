using System;

namespace ReinforcementLearning
{
	public class RankedChromosome<ChromosomeType> : IComparable
	{
		public ChromosomeType chromosome;

		public double fitness;

		public RankedChromosome()
		{
		}

		public RankedChromosome(ChromosomeType chromosome, double fitness)
		{
			this.chromosome = chromosome;
			this.fitness = fitness;
		}

		public int CompareTo(object obj)
		{
			RankedChromosome<ChromosomeType> rankedChromosome = (RankedChromosome<ChromosomeType>)obj;
			return -fitness.CompareTo(rankedChromosome.fitness);
		}
	}
}
