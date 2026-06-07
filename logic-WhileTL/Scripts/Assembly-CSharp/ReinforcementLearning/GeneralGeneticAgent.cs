using System;
using UnityEngine;

namespace ReinforcementLearning
{
	public class GeneralGeneticAgent<StateType, ActionType> : BaseGeneticAgent<StateType, ActionType, byte>
	{
		private Func<StateType, byte[], ActionType> GetActionByChromosome { get; set; }

		protected override byte GetGene()
		{
			return (byte)UnityEngine.Random.Range(0, 255);
		}

		public GeneralGeneticAgent(int chromosomeSize, int populationSize, int parentsNumber, double chromosomeMutationProbability, double geneMutationProbability, Func<StateType, byte[], ActionType> getActionByChromosome)
		{
			GetActionByChromosome = getActionByChromosome;
		}

		public override ActionType GetAction(StateType state)
		{
			return GetActionByChromosome(state, population[base.CurrentChromosome].chromosome);
		}
	}
}
