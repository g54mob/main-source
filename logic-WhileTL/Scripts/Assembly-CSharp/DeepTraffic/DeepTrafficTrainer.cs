using System;
using System.Collections.Generic;
using ReinforcementLearning;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public class DeepTrafficTrainer
	{
		private class EvalSeed : IComparable<EvalSeed>
		{
			public float score;

			public int seed;

			public EvalSeed(float score, int seed)
			{
				this.score = score;
				this.seed = seed;
			}

			public int CompareTo(EvalSeed other)
			{
				if (score.CompareTo(other.score) != 0)
				{
					return -score.CompareTo(other.score);
				}
				return seed.CompareTo(other.seed);
			}
		}

		private DeepTrafficControllerPresets presets;

		private SuperEpochData superEpochData;

		private int stepsCompleted;

		public bool usePlayerReplay;

		public bool stop;

		public DeepTrafficTrainer(DeepTrafficControllerPresets presets, SuperEpochData superEpochData)
		{
			this.presets = presets;
			this.superEpochData = superEpochData;
		}

		private void FullTrainStep(GeneticAgentWrapper agent, DeepTrafficEnvironment env)
		{
			for (int i = 0; i < agent.PopulationSize; i++)
			{
				env.Reset();
				for (int j = 0; j < presets.trainSteps; j++)
				{
					if (stop)
					{
						return;
					}
					Episode<CellObjects[], DeepTrafficAction> episode = env.Step(agent.GetAction(env.State));
					if (j == presets.trainSteps - 1)
					{
						episode.isDone = true;
					}
					agent.AddEpisode(episode);
					superEpochData.progress += 1f / (float)(agent.PopulationSize * presets.trainSteps);
				}
				superEpochData.MinorUpdate(agent.MeanSpeed, agent.StdSpeed, agent.EstimatedCost);
			}
			agent.Update();
			superEpochData.MajorUpdate(agent.MeanSpeed, agent.StdSpeed, agent.EstimatedCost, agent.ChromosomeMutated, agent.MeanGenesMutated);
		}

		private void FullTrainStep(DeepTrafficEliteStateAgent agent, DeepTrafficEnvironment env)
		{
			env.Reset();
			for (int i = 0; i < presets.trainSteps; i++)
			{
				if (stop)
				{
					return;
				}
				Episode<CellObjects[], DeepTrafficAction> episode = env.Step(agent.GetAction(env.State));
				if (i == presets.trainSteps - 1)
				{
					episode.isDone = true;
				}
				agent.AddEpisode(episode);
				superEpochData.progress += 1f / (float)presets.trainSteps;
			}
			agent.Update();
		}

		private void FullTrainStep(DQNWrapper agent, DeepTrafficEnvironment env)
		{
			env.Reset();
			for (int i = 0; i < presets.trainSteps; i++)
			{
				if (stop)
				{
					return;
				}
				Episode<CellObjects[], DeepTrafficAction> episode = env.Step(agent.GetAction(env.State));
				if (i == presets.trainSteps - 1)
				{
					episode.isDone = true;
				}
				agent.AddEpisode(episode);
				superEpochData.progress += 1f / (float)presets.trainSteps;
			}
			agent.Update();
		}

		private void FullTrainFromReplay(GeneticAgentWrapper agent, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			for (int i = 0; i < agent.PopulationSize; i++)
			{
				float num = 0f;
				foreach (Episode<CellObjects[], DeepTrafficAction> item in replayBuffer)
				{
					if (stop)
					{
						return;
					}
					if (agent.GetAction(item.state, i) == item.action)
					{
						num += 1f;
					}
					superEpochData.progress += 1f / (float)(agent.PopulationSize * replayBuffer.Count);
				}
				agent.SetChromosomeFitness(i, num / (float)replayBuffer.Count);
			}
			agent.Update();
			superEpochData.MutationUpdate(agent.ChromosomeMutated, agent.MeanGenesMutated);
		}

		private void FullTrainFromReplay(DeepTrafficEliteStateAgent agent, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			foreach (Episode<CellObjects[], DeepTrafficAction> item in replayBuffer)
			{
				if (stop)
				{
					return;
				}
				agent.AddEpisode(item);
				superEpochData.progress += 1f / (float)replayBuffer.Count;
			}
			agent.Update();
		}

		private void FullTrainFromReplay(DQNWrapper agent, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			foreach (Episode<CellObjects[], DeepTrafficAction> item in replayBuffer)
			{
				if (stop)
				{
					return;
				}
				agent.AddEpisode(item);
				superEpochData.progress += 1f / (float)replayBuffer.Count;
			}
			agent.Update();
		}

		private void FullEvalStep(IAgentWrapper agent, DeepTrafficEnvironment env)
		{
			EvalSeed[] array = new EvalSeed[presets.evalEpoch];
			for (int i = 0; i < presets.evalEpoch; i++)
			{
				float num = 0f;
				int seed = env.random.Next();
				env.random = new Random(seed);
				agent.TrainRandom = env.random;
				env.Reset();
				for (int j = 0; j < presets.iterationsToEvaluate; j++)
				{
					if (stop)
					{
						return;
					}
					Episode<CellObjects[], DeepTrafficAction> episode = env.Step(agent.GetBestAction(env.State));
					num += (float)episode.reward;
					superEpochData.progress += 1f / (float)(presets.evalEpoch * presets.iterationsToEvaluate);
				}
				array[i] = new EvalSeed(num / (float)presets.iterationsToEvaluate, seed);
			}
			Array.Sort(array);
			int num2 = presets.evalEpoch / 2;
			presets.evalSeed = array[num2].seed;
			superEpochData.EvalEndUpdate(array[num2].score + 50f, DeepTrafficStatic.GetMoneyByScore(array[num2].score));
		}

		public void TrainSuperEpoch(GeneticAgentWrapper agent, DeepTrafficEnvironment env, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			if (replayBuffer == null)
			{
				for (int i = 0; i < presets.superEpochSize; i++)
				{
					if (stop)
					{
						return;
					}
					FullTrainStep(agent, env);
					superEpochData.progress = i + 1;
				}
			}
			else
			{
				for (int j = 0; j < presets.superEpochSize; j++)
				{
					if (stop)
					{
						return;
					}
					if (usePlayerReplay)
					{
						FullTrainFromReplay(agent, replayBuffer);
					}
					else
					{
						FullTrainStep(agent, env);
					}
					superEpochData.progress = j + 1;
				}
			}
			FullEvalStep(agent, env);
			superEpochData.progress = presets.superEpochSize + 1;
		}

		public void TrainSuperEpoch(DeepTrafficEliteStateAgent agent, DeepTrafficEnvironment env, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			if (replayBuffer == null)
			{
				for (int i = 0; i < presets.superEpochSize; i++)
				{
					if (stop)
					{
						return;
					}
					FullTrainStep(agent, env);
					superEpochData.progress = i + 1;
				}
			}
			else
			{
				for (int j = 0; j < presets.superEpochSize; j++)
				{
					if (stop)
					{
						return;
					}
					if (usePlayerReplay)
					{
						FullTrainFromReplay(agent, replayBuffer);
					}
					else
					{
						FullTrainStep(agent, env);
					}
					superEpochData.progress = j + 1;
				}
			}
			FullEvalStep(agent, env);
			superEpochData.progress = presets.superEpochSize + 1;
		}

		public void TrainSuperEpoch(DQNWrapper agent, DeepTrafficEnvironment env, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			if (replayBuffer == null)
			{
				for (int i = 0; i < presets.superEpochSize; i++)
				{
					if (stop)
					{
						return;
					}
					FullTrainStep(agent, env);
					superEpochData.progress = i + 1;
				}
			}
			else
			{
				for (int j = 0; j < presets.superEpochSize; j++)
				{
					if (stop)
					{
						return;
					}
					if (usePlayerReplay)
					{
						FullTrainFromReplay(agent, replayBuffer);
					}
					else
					{
						FullTrainStep(agent, env);
					}
					superEpochData.progress = j + 1;
				}
			}
			FullEvalStep(agent, env);
			superEpochData.progress = presets.superEpochSize + 1;
		}

		public void TrainSuperEpoch(IAgentWrapper agent, DeepTrafficEnvironment env, List<Episode<CellObjects[], DeepTrafficAction>> replayBuffer)
		{
			GeneticAgentWrapper geneticAgentWrapper;
			try
			{
				geneticAgentWrapper = (GeneticAgentWrapper)agent;
			}
			catch (InvalidCastException)
			{
				geneticAgentWrapper = null;
			}
			if (geneticAgentWrapper != null)
			{
				TrainSuperEpoch(geneticAgentWrapper, env, replayBuffer);
				return;
			}
			DQNWrapper dQNWrapper;
			try
			{
				dQNWrapper = (DQNWrapper)agent;
			}
			catch (InvalidCastException)
			{
				dQNWrapper = null;
			}
			if (dQNWrapper != null)
			{
				TrainSuperEpoch(dQNWrapper, env, replayBuffer);
				return;
			}
			DeepTrafficEliteStateAgent deepTrafficEliteStateAgent;
			try
			{
				deepTrafficEliteStateAgent = (DeepTrafficEliteStateAgent)agent;
			}
			catch (InvalidCastException)
			{
				deepTrafficEliteStateAgent = null;
			}
			if (deepTrafficEliteStateAgent != null)
			{
				TrainSuperEpoch(deepTrafficEliteStateAgent, env, replayBuffer);
			}
		}
	}
}
