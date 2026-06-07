using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReinforcementLearning
{
	public class DiscreteGeneticAgent : BaseGeneticAgent<int, int, int>
	{
		public int ActionNumber { get; protected set; }

		protected override int GetGene()
		{
			return UnityEngine.Random.Range(0, ActionNumber);
		}

		public DiscreteGeneticAgent(int stateNumber, int actionNumber, int populationSize, int parentsNumber, double chromosomeMutationProbability, double geneMutationProbability)
		{
			if (actionNumber < 1)
			{
				throw new ArgumentOutOfRangeException("actionNumber must be positive");
			}
			ActionNumber = actionNumber;
			base.Train = true;
			base.KillParents = true;
			if (stateNumber < 1)
			{
				throw new ArgumentOutOfRangeException("chromosomeSize must be positive");
			}
			base.ChromosomeSize = stateNumber;
			base.ChromosomeMutationProbability = chromosomeMutationProbability;
			base.GeneMutationProbability = geneMutationProbability;
			population = new List<RankedChromosome<int[]>>(populationSize);
			base.PopulationSize = populationSize;
			base.ParentsNumber = parentsNumber;
		}

		public override int GetAction(int state)
		{
			return population[base.CurrentChromosome].chromosome[state];
		}
	}
}
