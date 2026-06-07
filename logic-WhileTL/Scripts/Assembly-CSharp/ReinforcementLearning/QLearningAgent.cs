using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReinforcementLearning
{
	internal class QLearningAgent<StateType, ActionType> : BaseQLearningAgent<StateType, ActionType>
	{
		private Dictionary<StateType, Dictionary<ActionType, double>> qTable;

		public QLearningAgent(IReplayBuffer<Episode<StateType, ActionType>> replayBuffer, int updateBatchSize, Func<StateType, ActionType[]> getLegalActions, double epsilon = 0.9, double discount = 0.99, double learningRate = 0.1)
			: base(replayBuffer, updateBatchSize, getLegalActions, epsilon, discount, learningRate)
		{
			qTable = new Dictionary<StateType, Dictionary<ActionType, double>>();
		}

		public override ActionType GetAction(StateType state, System.Random random)
		{
			if ((double)UnityEngine.Random.value < base.Epsilon)
			{
				return GetRandomAction(state);
			}
			return GetPolicy(state);
		}

		public override void Update()
		{
			Array.ForEach(replayBuffer.GetSamples(base.UpdateBatchSize), delegate(Episode<StateType, ActionType> x)
			{
				Update(x.state, x.action, x.nextState, x.reward);
			});
		}

		private void Update(StateType state, ActionType action, StateType nextState, double reward)
		{
			SetQvalue(state, action, (1.0 - base.LearningRate) * GetQvalue(state, action) + base.LearningRate * (reward + base.Discount * GetValue(nextState)));
		}

		protected double GetQvalue(StateType state, ActionType action)
		{
			if (!qTable.ContainsKey(state))
			{
				return 0.0;
			}
			if (!qTable[state].ContainsKey(action))
			{
				return 0.0;
			}
			return qTable[state][action];
		}

		protected void SetQvalue(StateType state, ActionType action, double qValue)
		{
			if (!qTable.ContainsKey(state))
			{
				qTable[state] = new Dictionary<ActionType, double> { { action, qValue } };
			}
			else
			{
				qTable[state][action] = qValue;
			}
		}

		protected double GetValue(StateType state)
		{
			ActionType[] array = getLegalActions(state);
			if (array.Length == 0)
			{
				return 0.0;
			}
			double result = double.MinValue;
			Array.ForEach(array, delegate(ActionType x)
			{
				result = Math.Max(result, GetQvalue(state, x));
			});
			return result;
		}

		protected ActionType GetPolicy(StateType state)
		{
			ActionType[] array = getLegalActions(state);
			if (array.Length == 0)
			{
				Debug.LogWarning("LegalAction length is 0. default(ActionType)");
				return default(ActionType);
			}
			double maxQvalue = double.MinValue;
			ActionType result = default(ActionType);
			Array.ForEach(array, delegate(ActionType x)
			{
				double qvalue = GetQvalue(state, x);
				if (qvalue > maxQvalue)
				{
					maxQvalue = qvalue;
					result = x;
				}
			});
			return result;
		}
	}
}
