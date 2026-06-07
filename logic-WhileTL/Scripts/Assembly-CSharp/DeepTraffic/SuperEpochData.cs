using System;
using UnityEngine;

namespace DeepTraffic
{
	public class SuperEpochData : ICloneable
	{
		private int maxSuperEpochNumber;

		public int superEpochNumber = 1;

		public int epochNumber;

		public float? meanSpeed;

		public float? stdSpeed;

		public int? estimatedCost;

		public int? mutatedSpecies;

		public int? meanMutatedGenes;

		public float progress;

		private int mutatedSpeciesAcc;

		private int meanMutatedGenesAcc;

		public SuperEpochData(int maxSuperEpochNumber)
		{
			this.maxSuperEpochNumber = maxSuperEpochNumber;
		}

		public void MinorUpdate(float? meanSpeed, float? stdSpeed, int? estimatedCost)
		{
			this.meanSpeed = meanSpeed;
			this.stdSpeed = stdSpeed;
			this.estimatedCost = estimatedCost;
		}

		public void EvalEndUpdate(float? meanSpeed, int? estimatedCost)
		{
			this.meanSpeed = meanSpeed;
			this.estimatedCost = estimatedCost;
			superEpochNumber++;
		}

		public void MutationUpdate(int? chromosomeMutated, int? geneMutated)
		{
			mutatedSpeciesAcc = (mutatedSpeciesAcc + chromosomeMutated).GetValueOrDefault();
			meanMutatedGenesAcc = (meanMutatedGenesAcc + geneMutated).GetValueOrDefault();
			epochNumber++;
			if (epochNumber == maxSuperEpochNumber)
			{
				mutatedSpecies = Mathf.RoundToInt((float)mutatedSpeciesAcc / (float)maxSuperEpochNumber);
				meanMutatedGenes = Mathf.RoundToInt((float)meanMutatedGenesAcc / (float)maxSuperEpochNumber);
				mutatedSpeciesAcc = 0;
				meanMutatedGenesAcc = 0;
				epochNumber = 0;
			}
		}

		public void MajorUpdate(float? meanSpeed, float? stdSpeed, int? estimatedCost, int? chromosomeMutated, int? geneMutated)
		{
			MinorUpdate(meanSpeed, stdSpeed, estimatedCost);
			MutationUpdate(chromosomeMutated, geneMutated);
		}

		public void Reset(bool full = false)
		{
			if (full)
			{
				superEpochNumber = 1;
			}
			progress = 0f;
			epochNumber = 0;
			meanSpeed = null;
			stdSpeed = null;
			estimatedCost = null;
			mutatedSpecies = null;
			meanMutatedGenes = null;
			mutatedSpeciesAcc = 0;
			meanMutatedGenesAcc = 0;
		}

		public object Clone()
		{
			return new SuperEpochData(maxSuperEpochNumber)
			{
				superEpochNumber = superEpochNumber,
				epochNumber = epochNumber,
				meanSpeed = meanSpeed,
				stdSpeed = stdSpeed,
				estimatedCost = estimatedCost,
				mutatedSpecies = mutatedSpecies,
				meanMutatedGenes = meanMutatedGenes,
				mutatedSpeciesAcc = mutatedSpeciesAcc,
				meanMutatedGenesAcc = meanMutatedGenesAcc,
				progress = progress
			};
		}
	}
}
