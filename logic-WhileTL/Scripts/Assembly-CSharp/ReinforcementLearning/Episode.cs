using System;

namespace ReinforcementLearning
{
	[Serializable]
	public class Episode<StateType, ActionType> : ICloneable
	{
		public StateType state;

		public ActionType action;

		public double reward;

		public StateType nextState;

		public bool isDone;

		public Episode()
		{
		}

		public Episode(StateType state, ActionType action, double reward, StateType nextState, bool isDone)
		{
			this.state = state;
			this.action = action;
			this.reward = reward;
			this.nextState = nextState;
			this.isDone = isDone;
		}

		public object Clone()
		{
			bool isValueType = typeof(StateType).IsValueType;
			bool isValueType2 = typeof(ActionType).IsValueType;
			return new Episode<StateType, ActionType>(isValueType ? state : ((StateType)(state as ICloneable).Clone()), isValueType2 ? action : ((ActionType)(action as ICloneable).Clone()), reward, isValueType ? nextState : ((StateType)(nextState as ICloneable).Clone()), isDone);
		}
	}
}
