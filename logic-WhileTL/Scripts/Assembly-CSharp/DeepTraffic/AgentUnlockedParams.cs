using System;
using App.Data;

namespace DeepTraffic
{
	public class AgentUnlockedParams : BaseKeyData, ICloneable
	{
		public bool populationSize;

		public bool parentsNumber;

		public bool chromosomeMutationProbability;

		public bool geneMutationProbability;

		public bool useCrossover;

		public bool mutationRate;

		public bool killParents;

		public bool maxBufferSize;

		public bool percentile;

		public bool learningRate;

		public AgentUnlockedParams(bool populationSize, bool parentsNumber, bool chromosomeMutationProbability, bool geneMutationProbability, bool useCrossover, bool mutationRate, bool killParents, bool maxBufferSize, bool percentile, bool learningRate)
		{
			this.populationSize = populationSize;
			this.parentsNumber = parentsNumber;
			this.chromosomeMutationProbability = chromosomeMutationProbability;
			this.geneMutationProbability = geneMutationProbability;
			this.useCrossover = useCrossover;
			this.mutationRate = mutationRate;
			this.killParents = killParents;
			this.maxBufferSize = maxBufferSize;
			this.percentile = percentile;
			this.learningRate = learningRate;
		}

		public object Clone()
		{
			return new AgentUnlockedParams(populationSize, parentsNumber, chromosomeMutationProbability, geneMutationProbability, useCrossover, mutationRate, killParents, maxBufferSize, percentile, learningRate)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
