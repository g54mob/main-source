using System;
using ConvNetSharp;
using ConvNetSharp.Training;
using UnityEngine;

namespace ReinforcementLearning
{
	internal class DeepQLearningAgent : BaseQLearningAgent<Volume, int>
	{
		private readonly Net network;

		private readonly Net targetNet;

		private readonly TrainerBase trainer;

		private int targetNetworkUpdateCount;

		private int targetNetworkUpdateBound;

		public int TargetNetworkUpdateBound
		{
			get
			{
				return targetNetworkUpdateBound;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("TargetNetworkUpdateCount must be positive");
				}
				targetNetworkUpdateCount *= value / targetNetworkUpdateBound;
				targetNetworkUpdateBound = value;
			}
		}

		public DeepQLearningAgent(IReplayBuffer<Episode<Volume, int>> replayBuffer, int updateBatchSize, Func<Volume, int[]> getLegalActions, Net net, Net targetNet, TrainerBase trainer, double epsilon = 0.9, double discount = 0.99, double learningRate = 0.1, int targetNetworkUpdateBound = 50)
			: base(replayBuffer, updateBatchSize, getLegalActions, epsilon, discount, learningRate)
		{
			network = net;
			this.targetNet = targetNet;
			this.trainer = trainer;
			if (targetNetworkUpdateBound <= 0)
			{
				throw new ArgumentOutOfRangeException("TargetNetworkUpdateCount must be positive");
			}
			this.targetNetworkUpdateBound = targetNetworkUpdateBound;
		}

		public override int GetAction(Volume state, System.Random random)
		{
			if ((double)UnityEngine.Random.value < base.Epsilon)
			{
				return GetRandomAction(state);
			}
			return GetPolicy(state, network);
		}

		public int GetAction(Volume state, Net network, System.Random random)
		{
			if ((double)UnityEngine.Random.value < base.Epsilon)
			{
				return GetRandomAction(state);
			}
			return GetPolicy(state, network);
		}

		protected int GetPolicy(Volume state, Net network)
		{
			Volume volume = network.Forward(state);
			float num = float.MinValue;
			int result = 0;
			for (int i = 0; i < volume.Depth; i++)
			{
				double num2 = volume.Get(0, 0, i);
				if (num2 > (double)num)
				{
					num = (float)num2;
					result = i;
				}
			}
			return result;
		}

		public override void Update()
		{
			Array.ForEach(replayBuffer.GetSamples(base.UpdateBatchSize), Update);
		}

		protected void Update(Episode<Volume, int> episode)
		{
			Volume volume = network.Forward(episode.state);
			double[] array = new double[getLegalActions(episode.state).Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (float)volume.Get(0, 0, i);
			}
			array[episode.action] = (float)episode.reward;
			if (!episode.isDone)
			{
				Volume volume2 = network.Forward(episode.nextState);
				float num = float.MinValue;
				int d = 0;
				for (int j = 0; j < volume2.Depth; j++)
				{
					if (volume2.Get(0, 0, j) > (double)num)
					{
						num = (float)volume2.Get(0, 0, j);
						d = j;
					}
				}
				double num2 = targetNet.Forward(episode.nextState).Get(0, 0, d);
				array[episode.action] += (float)(base.Discount * num2);
			}
			trainer.Train(episode.state, array);
			targetNetworkUpdateCount++;
			if (targetNetworkUpdateCount == TargetNetworkUpdateBound)
			{
				network.CopyWeights(targetNet);
			}
		}
	}
}
