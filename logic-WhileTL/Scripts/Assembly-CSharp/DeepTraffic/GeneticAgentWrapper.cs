using System;
using ConvNetSharp;
using ConvNetSharp.Layers;
using ReinforcementLearning;
using ReinforcementLearning.Environment;
using UnityEngine;

namespace DeepTraffic
{
	public class GeneticAgentWrapper : IAgentWrapper
	{
		private DoubleGeneticAgent<CellObjects[], DeepTrafficAction> agent;

		private Net[] networks;

		private Net evalNet;

		private Net bestNet;

		private readonly int chromosomeSize;

		private AgentPresets presets;

		private Func<int, CellObjects, System.Random, int> encoder;

		private DeepTrafficEnvPresets envPresets;

		private int behindLidarBound;

		private int frontLidarBound;

		public System.Random TrainRandom { get; set; }

		public System.Random RenderRandom { get; set; }

		public int PopulationSize => networks.Length;

		public bool ReadyForUpdate => agent.ReadyForUpdate;

		public float? MeanSpeed => agent.MeanFitness + 50f;

		public float? StdSpeed => agent.StdFitness;

		public int? EstimatedCost
		{
			get
			{
				if (!agent.MeanFitness.HasValue)
				{
					return null;
				}
				return DeepTrafficStatic.GetMoneyByScore(agent.MeanFitness.GetValueOrDefault());
			}
		}

		public int? ChromosomeMutated => agent.ChromosomeMutated;

		public int? MeanGenesMutated => agent.MeanGenesMutated;

		private Net CreateNetwork(ref int chromosomeSize, int[] layerSizes, int inputSize)
		{
			Net net = new Net();
			net.AddLayer(new InputLayer(1, DeepTrafficStatic.cellObjectSize, inputSize));
			chromosomeSize = 0;
			foreach (int num in layerSizes)
			{
				net.AddLayer(new FullyConnLayer(num));
				chromosomeSize += num * (1 + net.Layers[net.Layers.Count - 1].InputDepth * net.Layers[net.Layers.Count - 1].InputHeight);
			}
			net.AddLayer(new FullyConnLayer(5));
			chromosomeSize += 5 * (1 + net.Layers[net.Layers.Count - 1].InputDepth * net.Layers[net.Layers.Count - 1].InputHeight);
			return net;
		}

		public GeneticAgentWrapper(DeepTrafficEnvPresets envPresets, AgentPresets presets, System.Random trainRandom, System.Random renderRandom, Func<int, CellObjects, System.Random, int> encoder)
		{
			this.presets = presets;
			TrainRandom = trainRandom;
			RenderRandom = renderRandom;
			this.encoder = encoder;
			this.envPresets = envPresets;
			behindLidarBound = DeepTrafficStatic.BehindLidarBound(envPresets);
			frontLidarBound = DeepTrafficStatic.FrontLidarBound(envPresets);
			networks = new Net[presets.populationSize];
			chromosomeSize = 0;
			for (int i = 0; i < presets.populationSize; i++)
			{
				networks[i] = CreateNetwork(ref chromosomeSize, presets.LayerSizes, envPresets.enabledCount);
			}
			evalNet = CreateNetwork(ref chromosomeSize, presets.LayerSizes, envPresets.enabledCount);
			bestNet = CreateNetwork(ref chromosomeSize, presets.LayerSizes, envPresets.enabledCount);
			if (presets.weights == null)
			{
				presets.weights = new double[PopulationSize][];
			}
			else if (presets.weights.Length < PopulationSize)
			{
				double[][] array = (double[][])presets.weights.Clone();
				presets.weights = new double[PopulationSize][];
				for (int j = 0; j < array.Length; j++)
				{
					presets.weights[j] = array[j];
				}
			}
			agent = new DoubleGeneticAgent<CellObjects[], DeepTrafficAction>(chromosomeSize, presets.populationSize, presets.parentsNumber, presets.chromosomeMutationProbability, presets.geneMutationProbability, presets.useCrossover, (CellObjects[] x, double[] y) => DeepTrafficAction.noAction, presets.mutationRate, presets.killParents, trainRandom, presets.weights);
			for (int num = 0; num < networks.Length; num++)
			{
				Net net = networks[num];
				double[] chromosome = agent.GetChromosome(num);
				UpdateNetwork(net, chromosome);
			}
			UpdateNetwork(evalNet, agent.EvalSpecies);
			UpdateNetwork(bestNet, agent.BestSpecies);
		}

		public DeepTrafficAction GetAction(CellObjects[] state)
		{
			return GetAction(state, networks[agent.CurrentChromosome], TrainRandom);
		}

		public DeepTrafficAction GetAction(CellObjects[] state, int chromosomeNumber)
		{
			return GetAction(state, networks[chromosomeNumber], TrainRandom);
		}

		public void AddEpisode(Episode<CellObjects[], DeepTrafficAction> episode)
		{
			agent.AddEpisode(episode);
		}

		public DeepTrafficAction GetEvalAction(CellObjects[] state)
		{
			return GetAction(state, evalNet, RenderRandom);
		}

		public DeepTrafficAction GetBestAction(CellObjects[] state)
		{
			return GetAction(state, bestNet, TrainRandom);
		}

		private void SetEncoded(int ledarId, int i, CellObjects cell, System.Random random, Volume nnState)
		{
			int num = encoder(ledarId, cell, random);
			int num2 = 0;
			while (num2 < DeepTrafficStatic.cellObjectSize)
			{
				nnState.Set(0, num2, i, num & 1);
				num2++;
				num >>= 2;
			}
		}

		private DeepTrafficAction GetAction(CellObjects[] state, Net net, System.Random random)
		{
			Volume volume = new Volume(1, DeepTrafficStatic.cellObjectSize, envPresets.enabledCount, 0.0);
			int num = 0;
			for (int i = 0; i < behindLidarBound; i++)
			{
				if (envPresets.enabledLidarCells[i])
				{
					SetEncoded(2, num, state[i], random, volume);
					num++;
				}
			}
			for (int j = behindLidarBound; j < frontLidarBound; j++)
			{
				if (envPresets.enabledLidarCells[j])
				{
					if (DeepTrafficStatic.IsLeft(j, envPresets))
					{
						SetEncoded(0, num, state[j], random, volume);
					}
					else
					{
						SetEncoded(2 + ((behindLidarBound > 0) ? 1 : 0), num, state[j], random, volume);
					}
					num++;
				}
			}
			for (int k = frontLidarBound; k < state.Length; k++)
			{
				if (envPresets.enabledLidarCells[k])
				{
					if (DeepTrafficStatic.IsLeft(k, envPresets))
					{
						SetEncoded(0, num, state[k], random, volume);
					}
					else if (DeepTrafficStatic.IsFront(k, envPresets))
					{
						SetEncoded((frontLidarBound > 0) ? 1 : 0, num, state[k], random, volume);
					}
					else
					{
						SetEncoded(2 + ((behindLidarBound > 0) ? 1 : 0), num, state[k], random, volume);
					}
					num++;
				}
			}
			Volume volume2 = net.Forward(volume);
			double num2 = double.MinValue;
			double[] weights = volume2.Weights;
			for (int l = 0; l < weights.Length; l++)
			{
				num2 = Math.Max(weights[l], num2);
			}
			for (int m = 0; m < volume2.Weights.Length; m++)
			{
				volume2.Weights[m] -= num2;
			}
			double[] array = new double[volume2.Weights.Length];
			double num3 = 0.0;
			for (int n = 0; n < array.Length; n++)
			{
				array[n] = Math.Exp(volume2.Weights[n]);
				num3 += array[n];
			}
			for (int num4 = 0; num4 < array.Length; num4++)
			{
				array[num4] /= num3;
			}
			double num5 = random.NextDouble();
			double num6 = 0.0;
			for (int num7 = 0; num7 < array.Length; num7++)
			{
				if (num5 < num6 + array[num7])
				{
					return (DeepTrafficAction)num7;
				}
				num6 += array[num7];
			}
			string text = "Softmax fail, no action was chosen. x=" + num5.ToString("f4") + "\nexps = [";
			for (int num8 = 0; num8 < array.Length; num8++)
			{
				text = text + array[num8].ToString("f4") + ((num8 == array.Length - 1) ? "]\n" : ", ");
			}
			Debug.Log(text);
			return DeepTrafficAction.noAction;
		}

		private void UpdateNetwork(Net net, double[] chromosome)
		{
			int shift = 0;
			for (int i = 1; i < net.Layers.Count; i++)
			{
				FullyConnLayer layer = net.Layers[i] as FullyConnLayer;
				if (layer != null)
				{
					layer.Biases.Weights = new ArraySegment<double>(chromosome, shift, layer.OutputDepth).ToArray();
					shift += layer.OutputDepth;
					layer.Filters.ForEach(delegate(Volume x)
					{
						x.Weights = new ArraySegment<double>(chromosome, shift, layer.InputDepth * layer.InputHeight).ToArray();
						shift += layer.InputDepth * layer.InputHeight;
					});
				}
			}
		}

		public void Update()
		{
			agent.Update(presets.weights);
			for (int i = 0; i < networks.Length; i++)
			{
				Net net = networks[i];
				double[] chromosome = (double[])agent.GetChromosome(i).Clone();
				UpdateNetwork(net, chromosome);
			}
			UpdateNetwork(bestNet, agent.BestSpecies);
		}

		public void UpdateEvalAgent()
		{
			agent.UpdateEvalSpecies();
			UpdateNetwork(evalNet, agent.EvalSpecies);
		}

		public void SetChromosomeFitness(int chromosomeNumber, double fitness)
		{
			agent.SetChromosomeFitness(chromosomeNumber, fitness);
		}
	}
}
