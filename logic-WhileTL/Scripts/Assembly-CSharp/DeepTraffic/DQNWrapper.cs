using System;
using ConvNetSharp;
using ConvNetSharp.Layers;
using ConvNetSharp.Training;
using ReinforcementLearning;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public class DQNWrapper : IAgentWrapper
	{
		private DeepQLearningAgent dqn;

		private Net net;

		private Net targetNet;

		private Net renderNet;

		private DeepTrafficEnvPresets envPresets;

		private AgentPresets agentPresets;

		private Func<int, CellObjects, Random, int> encoder;

		private int behindLidarBound;

		private int frontLidarBound;

		public Random TrainRandom { get; set; }

		public Random RenderRandom { get; set; }

		private Net CreateNet()
		{
			Net net = new Net();
			net.AddLayer(new InputLayer(1, DeepTrafficStatic.cellObjectSize, envPresets.enabledCount));
			int[] layerSizes = agentPresets.LayerSizes;
			foreach (int neuronCount in layerSizes)
			{
				net.AddLayer(new FullyConnLayer(neuronCount, Activation.Relu));
			}
			net.AddLayer(new DuelingDQNLayer(5));
			return net;
		}

		public DQNWrapper(DeepTrafficEnvPresets envPresets, AgentPresets agentPresets, Random trainRandom, Random renderRandom, Func<int, CellObjects, Random, int> encoder)
		{
			this.envPresets = envPresets;
			this.agentPresets = agentPresets;
			TrainRandom = trainRandom;
			RenderRandom = renderRandom;
			this.encoder = encoder;
			behindLidarBound = DeepTrafficStatic.BehindLidarBound(envPresets);
			frontLidarBound = DeepTrafficStatic.FrontLidarBound(envPresets);
			net = CreateNet();
			targetNet = CreateNet();
			renderNet = CreateNet();
			net.CopyWeights(targetNet);
			net.CopyWeights(renderNet);
			dqn = new DeepQLearningAgent(new ListReplayBuffer<Episode<Volume, int>>(agentPresets.maxBufferSize), agentPresets.updateBatchSize, DeepTrafficStatic.GetIntPossibleActions, net, targetNet, new AdamTrainer(net), agentPresets.epsilon, agentPresets.discount, agentPresets.learningRate, agentPresets.targetNetworkUpdateBound);
		}

		private void SetEncoded(int ledarId, int i, CellObjects cell, Random random, Volume nnState)
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

		public Volume StateToVolume(CellObjects[] state, Random random)
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
			return volume;
		}

		public void AddEpisode(Episode<CellObjects[], DeepTrafficAction> episode)
		{
			Episode<Volume, int> episode2 = new Episode<Volume, int>(StateToVolume(episode.state, TrainRandom), (int)episode.action, episode.reward, StateToVolume(episode.nextState, TrainRandom), episode.isDone);
			dqn.AddEpisode(episode2);
		}

		public DeepTrafficAction GetAction(CellObjects[] state)
		{
			return (DeepTrafficAction)dqn.GetAction(StateToVolume(state, TrainRandom), TrainRandom);
		}

		public DeepTrafficAction GetBestAction(CellObjects[] state)
		{
			return GetAction(state);
		}

		public DeepTrafficAction GetEvalAction(CellObjects[] state)
		{
			return (DeepTrafficAction)dqn.GetAction(StateToVolume(state, RenderRandom), renderNet, RenderRandom);
		}

		public void Update()
		{
			dqn.Update();
			agentPresets.weights = net.GetWeights();
		}

		public void UpdateEvalAgent()
		{
			net.CopyWeights(renderNet);
		}
	}
}
