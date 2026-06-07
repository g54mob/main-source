using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReinforcementLearning
{
	public abstract class BaseGeneticAgent<StateType, ActionType, GeneType> : IAgent<StateType, ActionType> where GeneType : new()
	{
		protected System.Random random;

		protected List<RankedChromosome<GeneType[]>> population;

		protected int trainChromosome;

		private bool train;

		protected double totalReward;

		protected int sessionLength;

		protected int parentsNumber;

		protected double geneMutationProbability;

		protected double chromosomeMutationProbability;

		protected int populationSize;

		public float MutationRate { get; protected set; }

		public bool Train
		{
			get
			{
				return train;
			}
			set
			{
				train = value;
				if (!train)
				{
					PopulationSize = 1;
					population[0].chromosome = EvalSpecies;
				}
			}
		}

		public bool KillParents { get; set; }

		public int ChromosomeSize { get; protected set; }

		public bool ReadyForUpdate { get; protected set; }

		public bool UseCrossover { get; set; }

		public GeneType[] EvalSpecies { get; protected set; }

		public GeneType[] BestSpecies { get; protected set; }

		public int ParentsNumber
		{
			get
			{
				return parentsNumber;
			}
			set
			{
				if (value < 1 || value > PopulationSize)
				{
					throw new ArgumentOutOfRangeException("ParentsNumber must be from 1 to PopulationSize");
				}
				parentsNumber = value;
			}
		}

		public double GeneMutationProbability
		{
			get
			{
				return geneMutationProbability;
			}
			set
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("geneMutationProbability must be in range [0, 1]");
				}
				geneMutationProbability = value;
			}
		}

		public double ChromosomeMutationProbability
		{
			get
			{
				return chromosomeMutationProbability;
			}
			set
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("ChromosomeMutationProbability must be in range [0, 1]");
				}
				chromosomeMutationProbability = value;
			}
		}

		public int PopulationSize
		{
			get
			{
				return populationSize;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("PopulationSize must be greater than zero");
				}
				if (populationSize > value)
				{
					population.Sort();
					population.RemoveRange(value, value - populationSize);
					populationSize = value;
					for (int i = 0; i < population.Count; i++)
					{
						population[i].fitness = double.MinValue;
					}
					trainChromosome = 0;
					sessionLength = 0;
				}
				else
				{
					while (populationSize < value)
					{
						GeneType[] chromosome = GetChromosome();
						population.Add(new RankedChromosome<GeneType[]>(chromosome, double.MinValue));
						populationSize++;
					}
				}
			}
		}

		public int CurrentChromosome
		{
			get
			{
				if (Train)
				{
					return trainChromosome;
				}
				return 0;
			}
		}

		public float? MeanFitness { get; protected set; }

		public float? StdFitness { get; protected set; }

		public float? MaxFitness { get; protected set; }

		public int? ChromosomeMutated { get; protected set; }

		public int? MeanGenesMutated { get; protected set; }

		protected abstract GeneType GetGene();

		protected BaseGeneticAgent()
		{
		}

		public BaseGeneticAgent(int chromosomeSize, int populationSize, int parentsNumber, double chromosomeMutationProbability, double geneMutationProbability, bool useCrossover, float mutationRate, bool killParents, System.Random random, GeneType[][] weights = null)
		{
			this.random = random;
			MutationRate = mutationRate;
			Train = true;
			KillParents = killParents;
			if (chromosomeSize < 1)
			{
				throw new ArgumentOutOfRangeException("chromosomeSize must be positive");
			}
			ChromosomeSize = chromosomeSize;
			ChromosomeMutationProbability = chromosomeMutationProbability;
			GeneMutationProbability = geneMutationProbability;
			population = new List<RankedChromosome<GeneType[]>>(populationSize);
			if (weights == null)
			{
				PopulationSize = populationSize;
			}
			else
			{
				this.populationSize = populationSize;
				SetGenes(weights);
			}
			ParentsNumber = parentsNumber;
			UseCrossover = useCrossover;
			EvalSpecies = (GeneType[])population[0].chromosome.Clone();
			BestSpecies = (GeneType[])population[0].chromosome.Clone();
			MeanFitness = null;
			StdFitness = null;
			MaxFitness = null;
			ChromosomeMutated = null;
			MeanGenesMutated = null;
		}

		public void SetChromosomeFitness(int chromosomeNumber, double fitness)
		{
			population[chromosomeNumber].fitness = fitness;
		}

		public void SetGenes(GeneType[][] genes)
		{
			for (int i = 0; i < Mathf.Min(genes.Length, populationSize); i++)
			{
				if (genes[i] == null)
				{
					genes[i] = GetChromosome();
				}
				if (i < population.Count)
				{
					population[i].chromosome = (GeneType[])genes[i].Clone();
				}
				else
				{
					population.Add(new RankedChromosome<GeneType[]>(genes[i], double.MinValue));
				}
			}
			while (population.Count < populationSize)
			{
				population.Add(new RankedChromosome<GeneType[]>(GetChromosome(), double.MinValue));
			}
			EvalSpecies = (GeneType[])population[0].chromosome.Clone();
			BestSpecies = (GeneType[])population[0].chromosome.Clone();
		}

		protected GeneType[] GetChromosome()
		{
			GeneType[] array = new GeneType[ChromosomeSize];
			for (int i = 0; i < ChromosomeSize; i++)
			{
				array[i] = GetGene();
			}
			return array;
		}

		public void AddEpisode(Episode<StateType, ActionType> episode)
		{
			if (!Train)
			{
				return;
			}
			totalReward += episode.reward;
			sessionLength++;
			if (episode.isDone)
			{
				totalReward /= sessionLength;
				population[trainChromosome].fitness = totalReward;
				UpdateMeanFitnesses(trainChromosome);
				UpdateStdFitness(trainChromosome);
				UpdateMaxFitness(trainChromosome);
				totalReward = 0.0;
				sessionLength = 0;
				trainChromosome = (trainChromosome + 1) % PopulationSize;
				if (trainChromosome == 0)
				{
					ReadyForUpdate = true;
				}
			}
		}

		protected GeneType[] Crossover(GeneType[] chromosome1, GeneType[] chromosome2)
		{
			GeneType[] array = new GeneType[ChromosomeSize];
			for (int i = 0; i < chromosome1.Length; i++)
			{
				if (random.NextDouble() < 0.5)
				{
					array[i] = chromosome1[i];
				}
				else
				{
					array[i] = chromosome2[i];
				}
			}
			return array;
		}

		public void UpdateEvalSpecies()
		{
			EvalSpecies = (GeneType[])BestSpecies.Clone();
		}

		private void UpdateMeanFitnesses(int? chromosomeNumber = null)
		{
			if (!chromosomeNumber.HasValue)
			{
				MeanFitness = 0f;
				foreach (RankedChromosome<GeneType[]> item in population)
				{
					MeanFitness += (float)item.fitness;
				}
				MeanFitness /= PopulationSize;
			}
			else
			{
				MeanFitness = (float)((double?)(MeanFitness.GetValueOrDefault() * (float?)chromosomeNumber) + population[chromosomeNumber.GetValueOrDefault()].fitness).Value / (float?)(chromosomeNumber + 1);
			}
		}

		private void UpdateStdFitness(int? chromosomeNumber = null)
		{
			StdFitness = 0f;
			if (!chromosomeNumber.HasValue)
			{
				foreach (RankedChromosome<GeneType[]> item in population)
				{
					StdFitness += (float)((item.fitness - (double?)MeanFitness) * (item.fitness - (double?)MeanFitness)).Value;
				}
				StdFitness /= PopulationSize;
			}
			else
			{
				for (int i = 0; i < chromosomeNumber.GetValueOrDefault(); i++)
				{
					double fitness = population[0].fitness;
					StdFitness += (float)((fitness - (double?)MeanFitness) * (fitness - (double?)MeanFitness)).Value;
				}
				StdFitness /= chromosomeNumber + 1;
			}
			StdFitness = Mathf.Sqrt(StdFitness.GetValueOrDefault());
		}

		private void UpdateMaxFitness(int? chromosomeNumber = null)
		{
			MaxFitness = (float)Math.Max(((double?)MaxFitness).GetValueOrDefault(), population[chromosomeNumber.GetValueOrDefault()].fitness);
		}

		public void Update(GeneType[][] weights)
		{
			population.Sort();
			if (weights != null)
			{
				for (int i = 0; i < population.Count; i++)
				{
					weights[i] = (GeneType[])population[i].chromosome.Clone();
				}
			}
			Update();
		}

		public void Update()
		{
			population.Sort();
			BestSpecies = (GeneType[])population[0].chromosome.Clone();
			UpdateMeanFitnesses();
			UpdateStdFitness();
			UpdateMaxFitness();
			List<RankedChromosome<GeneType[]>> list;
			if (UseCrossover)
			{
				list = ((!KillParents) ? population : new List<RankedChromosome<GeneType[]>>(PopulationSize));
				while (list.Count < PopulationSize)
				{
					for (int i = 1; i < ParentsNumber; i++)
					{
						if (list.Count >= PopulationSize)
						{
							break;
						}
						for (int j = 0; j < i; j++)
						{
							if (list.Count >= PopulationSize)
							{
								break;
							}
							list.Add(new RankedChromosome<GeneType[]>(Crossover(population[i].chromosome, population[j].chromosome), double.MinValue));
						}
					}
				}
				while (list.Count < PopulationSize)
				{
					GeneType[] chromosome = GetChromosome();
					list.Add(new RankedChromosome<GeneType[]>(chromosome, double.MinValue));
				}
			}
			else
			{
				list = new List<RankedChromosome<GeneType[]>>(PopulationSize);
				for (int k = 0; k < PopulationSize; k++)
				{
					list.Add(population[k % ParentsNumber]);
				}
			}
			ChromosomeMutated = 0;
			MeanGenesMutated = 0;
			for (int l = 0; l < list.Count; l++)
			{
				if (!(random.NextDouble() < ChromosomeMutationProbability))
				{
					continue;
				}
				int? chromosomeMutated = ChromosomeMutated + 1;
				ChromosomeMutated = chromosomeMutated;
				for (int m = 0; m < list[l].chromosome.Length; m++)
				{
					if (random.NextDouble() < GeneMutationProbability)
					{
						list[l].chromosome[m] = GetGene();
						chromosomeMutated = MeanGenesMutated + 1;
						MeanGenesMutated = chromosomeMutated;
					}
				}
				list[l].fitness = double.MinValue;
			}
			if (ChromosomeMutated > 0)
			{
				MeanGenesMutated /= ChromosomeMutated;
			}
			population = list;
			populationSize = list.Count;
			ReadyForUpdate = false;
		}

		public GeneType[] GetChromosome(int id)
		{
			return population[id].chromosome;
		}

		public abstract ActionType GetAction(StateType state);
	}
}
