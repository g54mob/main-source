using System;
using UnityEngine;

namespace ReinforcementLearning
{
	public abstract class BaseQLearningAgent<StateType, ActionType> : BaseOnePolicyAgent<StateType, ActionType>
	{
		protected IReplayBuffer<Episode<StateType, ActionType>> replayBuffer;

		private int updateBatchSize;

		private double epsilon;

		private double discount;

		public Func<StateType, ActionType[]> getLegalActions;

		public int UpdateBatchSize
		{
			get
			{
				return updateBatchSize;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("updateBatchSize must be greater than zero");
				}
				updateBatchSize = value;
			}
		}

		public double Epsilon
		{
			get
			{
				return epsilon;
			}
			set
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("Epsilon must be in [0; 1]");
				}
				epsilon = value;
			}
		}

		public double Discount
		{
			get
			{
				return discount;
			}
			set
			{
				if (value < 0.0 || value >= 1.0)
				{
					throw new ArgumentOutOfRangeException("Discount must be positive");
				}
				discount = value;
			}
		}

		public void SetReplayBufferSize(int replayBufferSize)
		{
			replayBuffer.MaxBufferSize = replayBufferSize;
		}

		public override void AddEpisode(Episode<StateType, ActionType> episode)
		{
			replayBuffer.Add(episode);
		}

		public BaseQLearningAgent(IReplayBuffer<Episode<StateType, ActionType>> replayBuffer, int updateBatchSize, Func<StateType, ActionType[]> getLegalActions, double epsilon = 0.9, double discount = 0.99, double learningRate = 0.1)
			: base(learningRate)
		{
			this.replayBuffer = replayBuffer;
			UpdateBatchSize = updateBatchSize;
			this.getLegalActions = getLegalActions;
			Epsilon = epsilon;
			Discount = discount;
		}

		protected ActionType GetRandomAction(StateType state)
		{
			ActionType[] array = getLegalActions(state);
			if (array.Length == 0)
			{
				Debug.LogWarning("LegalAction length is 0. default(ActionType)");
				return default(ActionType);
			}
			return array[UnityEngine.Random.Range(0, array.Length)];
		}
	}
}
