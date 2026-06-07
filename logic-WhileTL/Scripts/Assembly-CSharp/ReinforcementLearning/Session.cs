using System;
using System.Collections.Generic;

namespace ReinforcementLearning
{
	[Serializable]
	public class Session<StateType, ActionType>
	{
		public List<StateType> states;

		public List<ActionType> actions;

		public double reward;

		public Session()
		{
		}

		public Session(List<StateType> states, List<ActionType> actions, double reward)
		{
			if (states.Count != actions.Count)
			{
				throw new ArgumentOutOfRangeException("Number of actions must match number of states");
			}
			this.states = states;
			this.actions = actions;
			this.reward = reward;
		}
	}
}
