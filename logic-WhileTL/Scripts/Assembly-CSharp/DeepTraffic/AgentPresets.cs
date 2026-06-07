using System;
using System.Collections.Generic;
using App.Data;
using ReinforcementLearning;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public class AgentPresets : BaseKeyData, ICloneable
	{
		public string layerSizesList;

		private int[] layerSizes;

		public int populationSize;

		public int parentsNumber;

		public double chromosomeMutationProbability;

		public double geneMutationProbability;

		public bool useCrossover;

		public float mutationRate;

		public bool killParents;

		public int maxBufferSize;

		public double percentile;

		public double learningRate;

		public double epsilon;

		public double discount;

		public int updateBatchSize;

		public int targetNetworkUpdateBound;

		public double[][] weights;

		public List<Episode<CellObjects[], DeepTrafficAction>> history;

		public int[] LayerSizes
		{
			get
			{
				if (layerSizes != null)
				{
					return layerSizes;
				}
				if (layerSizesList == null)
				{
					return layerSizes = new int[0];
				}
				string[] array = layerSizesList.Split(';');
				layerSizes = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					layerSizes[i] = Convert.ToInt32(array[i]);
				}
				return layerSizes;
			}
		}

		public AgentPresets()
		{
		}

		private AgentPresets(int[] layerSizes, int populationSize, int parentsNumber, double chromosomeMutationProbability, double geneMutationProbability, bool useCrossover, float mutationRate, bool killParents, int maxBufferSize, double percentile, double learningRate, double[][] weights, List<Episode<CellObjects[], DeepTrafficAction>> history, double epsilon, double discount, int updateBatchSize, int targetNetworkUpdateBound)
		{
			this.layerSizes = layerSizes;
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
			this.weights = weights;
			this.history = history;
			this.epsilon = epsilon;
			this.discount = discount;
			this.updateBatchSize = updateBatchSize;
			this.targetNetworkUpdateBound = targetNetworkUpdateBound;
		}

		public object Clone()
		{
			return new AgentPresets((layerSizes != null) ? ((int[])layerSizes.Clone()) : null, populationSize, parentsNumber, chromosomeMutationProbability, geneMutationProbability, useCrossover, mutationRate, killParents, maxBufferSize, percentile, learningRate, (weights != null) ? ((double[][])weights.Clone()) : null, (history != null) ? ((List<Episode<CellObjects[], DeepTrafficAction>>)history.Clone()) : null, epsilon, discount, updateBatchSize, targetNetworkUpdateBound)
			{
				KeyName = (string)KeyName.Clone(),
				layerSizesList = ((layerSizesList == null) ? null : ((string)layerSizesList.Clone()))
			};
		}
	}
}
