using System;

namespace ReinforcementLearning
{
	public class DoubleGeneticAgent<StateType, ActionType> : BaseGeneticAgent<StateType, ActionType, double>
	{
		private Func<StateType, double[], ActionType> GetActionByChromosome { get; set; }

		public override ActionType GetAction(StateType state)
		{
			return GetActionByChromosome(state, population[base.CurrentChromosome].chromosome);
		}

		public DoubleGeneticAgent(int chromosomeSize, int populationSize, int parentsNumber, double chromosomeMutationProbability, double geneMutationProbability, bool useCrossover, Func<StateType, double[], ActionType> getActionByChromosome, float mutationRate, bool killParents, Random random, double[][] weights)
			: base(chromosomeSize, populationSize, parentsNumber, chromosomeMutationProbability, geneMutationProbability, useCrossover, mutationRate, killParents, random, weights)
		{
			GetActionByChromosome = getActionByChromosome;
			if (mutationRate <= 0f)
			{
				throw new ArgumentOutOfRangeException("mutationRate must be positive");
			}
			base.MutationRate = mutationRate;
		}

		protected override double GetGene()
		{
			return random.NextDouble() * (double)base.MutationRate * (double)((!(random.NextDouble() < 0.5)) ? 1 : (-1));
		}
	}
}
