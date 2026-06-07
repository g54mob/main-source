using System;

namespace ReinforcementLearning
{
	public abstract class BaseOnePolicyAgent<StateType, ActionType> : IAgent<StateType, ActionType>
	{
		private double learningRate;

		public double LearningRate
		{
			get
			{
				return learningRate;
			}
			set
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("LearningRate must be positive.");
				}
				learningRate = value;
			}
		}

		public BaseOnePolicyAgent(double learningRate = 0.1)
		{
			LearningRate = learningRate;
		}

		public abstract ActionType GetAction(StateType state, Random random);

		public virtual ActionType GetAction(StateType state)
		{
			return GetAction(state, new Random());
		}

		public abstract void Update();

		public abstract void AddEpisode(Episode<StateType, ActionType> episode);
	}
}
