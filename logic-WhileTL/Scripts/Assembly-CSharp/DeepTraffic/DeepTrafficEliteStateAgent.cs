using System;
using ReinforcementLearning;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public class DeepTrafficEliteStateAgent : EliteStatesAgent<CellObjects[], DeepTrafficAction>, IAgentWrapper
	{
		public DeepTrafficEnvPresets EnvPresets { get; set; }

		public Random TrainRandom { get; set; }

		public Random RenderRandom { get; set; }

		public Func<int, CellObjects, Random, int> Encoder { get; set; }

		public DeepTrafficEliteStateAgent(int maxBufferSize, float percentile = 70f, double learningRate = 0.1)
			: base((IReplayBuffer<Session<CellObjects[], DeepTrafficAction>>)new ListReplayBuffer<Session<CellObjects[], DeepTrafficAction>>(maxBufferSize), (Func<CellObjects[], DeepTrafficAction[]>)DeepTrafficStatic.GetPossibleActions, (double)percentile, learningRate)
		{
		}

		public DeepTrafficEliteStateAgent(DeepTrafficEnvPresets envPresets, AgentPresets agentPresets, Random trainRandom, Random renderRanom, Func<int, CellObjects, Random, int> encoder)
			: this(agentPresets.maxBufferSize, (float)agentPresets.percentile, (float)agentPresets.learningRate)
		{
			EnvPresets = envPresets;
			TrainRandom = trainRandom;
			RenderRandom = renderRanom;
			Encoder = encoder;
		}

		public new DeepTrafficAction GetAction(CellObjects[] state)
		{
			return GetAction(state, TrainRandom);
		}

		public DeepTrafficAction GetBestAction(CellObjects[] state)
		{
			return GetAction(state);
		}

		public DeepTrafficAction GetEvalAction(CellObjects[] state)
		{
			return GetAction(state, RenderRandom);
		}

		public void UpdateEvalAgent()
		{
			Update();
		}
	}
}
