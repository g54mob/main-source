using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReinforcementLearning
{
	public class EliteStatesAgent<StateType, ActionType> : BaseOnePolicyAgent<StateType, ActionType>
	{
		private IReplayBuffer<Session<StateType, ActionType>> replayBuffer;

		private List<StateType> stateBuffer;

		private List<ActionType> actionBuffer;

		private double totalReward;

		protected Dictionary<StateType, Dictionary<ActionType, double>> policy;

		public Func<StateType, ActionType[]> getLegalActions;

		private double percentile;

		public double Percentile
		{
			get
			{
				return percentile;
			}
			set
			{
				if (value < 0.0 || value > 100.0)
				{
					throw new ArgumentOutOfRangeException("Percentile must be in [0; 100]");
				}
				percentile = value;
			}
		}

		public void SetReplayBufferSize(int replayBufferSize)
		{
			replayBuffer.MaxBufferSize = replayBufferSize;
		}

		public override void AddEpisode(Episode<StateType, ActionType> episode)
		{
			stateBuffer.Add(episode.state);
			actionBuffer.Add(episode.action);
			totalReward += episode.reward;
			if (episode.isDone)
			{
				replayBuffer.Add(new Session<StateType, ActionType>(stateBuffer, actionBuffer, totalReward));
				stateBuffer.Clear();
				actionBuffer.Clear();
				totalReward = 0.0;
			}
		}

		public EliteStatesAgent(IReplayBuffer<Session<StateType, ActionType>> replayBuffer, Func<StateType, ActionType[]> getLegalActions, double percentile = 70.0, double learningRate = 0.1)
			: base(learningRate)
		{
			this.replayBuffer = replayBuffer;
			this.getLegalActions = getLegalActions;
			policy = new Dictionary<StateType, Dictionary<ActionType, double>>();
			Percentile = percentile;
		}

		protected double GetPolicy(StateType state, ActionType action)
		{
			if (!policy.ContainsKey(state))
			{
				return 1 / getLegalActions(state).Length;
			}
			if (!policy[state].ContainsKey(action))
			{
				return 0.0;
			}
			return policy[state][action];
		}

		protected void SetPolicy(StateType state, ActionType action, double value)
		{
			if (!policy.ContainsKey(state))
			{
				policy[state] = new Dictionary<ActionType, double> { { action, value } };
			}
			else
			{
				policy[state][action] = value;
			}
		}

		public override ActionType GetAction(StateType state, System.Random random)
		{
			ActionType[] array = getLegalActions(state);
			if (array.Length == 0)
			{
				Debug.LogWarning("LegalAction length is 0. default(ActionType)");
				return default(ActionType);
			}
			double num = random.NextDouble();
			double num2 = 0.0;
			ActionType[] array2 = array;
			foreach (ActionType val in array2)
			{
				double num3 = GetPolicy(state, val);
				if (num < num2 + num3)
				{
					return val;
				}
				num2 += num3;
			}
			string text = "EliteStateAgent.GetAction failed, no action was chosen. x=" + num.ToString("f4") + "\nexps = [";
			for (int j = 0; j < array.Length; j++)
			{
				ActionType action = array[j];
				text = text + GetPolicy(state, action).ToString("f4") + ((j == array.Length - 1) ? "]\n" : ", ");
			}
			Debug.Log(text);
			return default(ActionType);
		}

		public override void Update()
		{
			Dictionary<StateType, Dictionary<ActionType, double>> newPolicy = GetNewPolicy();
			replayBuffer.Clear();
			foreach (StateType item in new List<StateType>(policy.Keys))
			{
				if (newPolicy.ContainsKey(item))
				{
					foreach (ActionType item2 in new List<ActionType>(policy[item].Keys))
					{
						if (newPolicy[item].ContainsKey(item2))
						{
							policy[item][item2] = (1.0 - base.LearningRate) * policy[item][item2] + base.LearningRate * newPolicy[item][item2];
						}
						else
						{
							policy[item][item2] *= 1.0 - base.LearningRate;
						}
					}
					foreach (KeyValuePair<ActionType, double> item3 in newPolicy[item])
					{
						if (!policy[item].ContainsKey(item3.Key))
						{
							policy[item][item3.Key] = base.LearningRate * item3.Value;
						}
					}
					continue;
				}
				foreach (KeyValuePair<ActionType, double> item4 in policy[item])
				{
					policy[item][item4.Key] = (1.0 - base.LearningRate) * item4.Value + base.LearningRate / (double)getLegalActions(item).Length;
				}
			}
			foreach (StateType key in newPolicy.Keys)
			{
				if (policy.ContainsKey(key))
				{
					continue;
				}
				policy[key] = new Dictionary<ActionType, double>();
				foreach (KeyValuePair<ActionType, double> item5 in newPolicy[key])
				{
					policy[key][item5.Key] = (1.0 - base.LearningRate) / (double)getLegalActions(key).Length + base.LearningRate * item5.Value;
				}
			}
		}

		protected Dictionary<StateType, Dictionary<ActionType, double>> GetNewPolicy()
		{
			Session<StateType, ActionType>[] allSamples = replayBuffer.GetAllSamples();
			Array.Sort(allSamples, (Session<StateType, ActionType> x, Session<StateType, ActionType> y) => y.reward.CompareTo(x.reward));
			int num = GetPercentile(allSamples.Length, percentile);
			Dictionary<StateType, Dictionary<ActionType, double>> dictionary = new Dictionary<StateType, Dictionary<ActionType, double>>();
			Dictionary<StateType, int> dictionary2 = new Dictionary<StateType, int>();
			for (int num2 = 0; num2 < num; num2++)
			{
				List<StateType> states = allSamples[num2].states;
				List<ActionType> actions = allSamples[num2].actions;
				for (int num3 = 0; num3 < states.Count; num3++)
				{
					StateType val = states[num3];
					ActionType val2 = actions[num3];
					if (!dictionary.ContainsKey(val))
					{
						dictionary[val] = new Dictionary<ActionType, double>();
						dictionary2[val] = 0;
					}
					if (!dictionary[val].ContainsKey(val2))
					{
						dictionary[val][val2] = 0.0;
					}
					Dictionary<ActionType, double> dictionary3 = dictionary[val];
					ActionType key = val2;
					double value = dictionary3[key] + 1.0;
					dictionary3[key] = value;
					StateType key2 = val;
					int value2 = dictionary2[key2] + 1;
					dictionary2[key2] = value2;
				}
			}
			foreach (StateType item in new List<StateType>(dictionary.Keys))
			{
				foreach (ActionType item2 in new List<ActionType>(dictionary[item].Keys))
				{
					dictionary[item][item2] /= dictionary2[item];
				}
			}
			return dictionary;
		}

		protected static int GetPercentile(int n, double percentile)
		{
			if (percentile == 100.0)
			{
				return n;
			}
			if (percentile == 0.0)
			{
				return 0;
			}
			return Convert.ToInt32((double)n * (percentile / 100.0) + 0.5);
		}

		public void ClearReplay()
		{
			replayBuffer.Clear();
		}
	}
}
