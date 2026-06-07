using System;
using App.Data;

namespace DeepTraffic
{
	public class CarSliderParamsBounds : BaseKeyData, ICloneable
	{
		public string populationSize;

		public string selectionPercentile;

		public string chromosomeMutationProbability;

		public string geneMutationProbability;

		public string mutationRate;

		public string trainSteps;

		private int[] populationSizes;

		private float[] selectionPercentiles;

		private float[] chromosomeMutationProbabilities;

		private float[] geneMutationProbabilities;

		private float[] mutationRates;

		private int[] trainStepsBounds;

		private int[] ParseIntFromString(string s)
		{
			string[] array = s.Split(';');
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Convert.ToInt32(array[i]);
			}
			return array2;
		}

		private float[] ParseFloatFromString(string s)
		{
			string[] array = s.Split(';');
			float[] array2 = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (float)Convert.ToDouble(array[i]);
			}
			return array2;
		}

		public int[] GetPopulationSizes()
		{
			if (populationSizes != null)
			{
				return populationSizes;
			}
			return populationSizes = ParseIntFromString(populationSize);
		}

		public float[] GetSelectionPercentiles()
		{
			if (selectionPercentiles != null)
			{
				return selectionPercentiles;
			}
			return selectionPercentiles = ParseFloatFromString(selectionPercentile);
		}

		public float[] GetChromosomeMutationProbabilities()
		{
			if (chromosomeMutationProbabilities != null)
			{
				return chromosomeMutationProbabilities;
			}
			return chromosomeMutationProbabilities = ParseFloatFromString(chromosomeMutationProbability);
		}

		public float[] GetGeneMutationProbabilities()
		{
			if (geneMutationProbabilities != null)
			{
				return geneMutationProbabilities;
			}
			return geneMutationProbabilities = ParseFloatFromString(geneMutationProbability);
		}

		public float[] GetMutationRates()
		{
			if (mutationRates != null)
			{
				return mutationRates;
			}
			return mutationRates = ParseFloatFromString(mutationRate);
		}

		public int[] GetTrainStepsBounds()
		{
			if (trainStepsBounds != null)
			{
				return trainStepsBounds;
			}
			return trainStepsBounds = ParseIntFromString(trainSteps);
		}

		public CarSliderParamsBounds(string populationSize, string selectionPercentile, string chromosomeMutationProbability, string geneMutationProbability, string mutationRate, string trainSteps)
		{
			this.populationSize = populationSize;
			this.selectionPercentile = selectionPercentile;
			this.chromosomeMutationProbability = chromosomeMutationProbability;
			this.geneMutationProbability = geneMutationProbability;
			this.mutationRate = mutationRate;
			this.trainSteps = trainSteps;
		}

		public object Clone()
		{
			return new CarSliderParamsBounds(populationSize, selectionPercentile, chromosomeMutationProbability, geneMutationProbability, mutationRate, trainSteps)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
