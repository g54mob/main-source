using System;
using MalbersAnimations.Controller;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalState : MAnimalCondition
	{
		public enum StateCondition
		{
			ActiveState = 0,
			Enabled = 1,
			HasState = 2,
			Pending = 3,
			SleepFromMode = 4,
			SleepFromState = 5,
			SleepFromStance = 6,
			LastState = 7
		}

		public StateCondition Condition;

		public StateID Value;

		private State st;

		public override string DisplayName => "Animal/States";

		public void SetValue(StateID v)
		{
			Value = v;
		}

		private void OnEnable()
		{
			if ((bool)Target)
			{
				st = Target.State_Get(Value);
			}
		}

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				if (st == null)
				{
					st = Target.State_Get(Value);
				}
				switch (Condition)
				{
				case StateCondition.ActiveState:
					return Target.ActiveStateID == Value;
				case StateCondition.HasState:
					return st != null;
				case StateCondition.Enabled:
					return st.Active;
				case StateCondition.Pending:
					return st.IsPending;
				case StateCondition.SleepFromMode:
					return st.IsSleepFromMode;
				case StateCondition.SleepFromState:
					return st.IsSleepFromState;
				case StateCondition.SleepFromStance:
					return st.IsSleepFromStance;
				case StateCondition.LastState:
					return Target.LastState.ID == Value;
				}
			}
			return false;
		}

		private void Reset()
		{
			Name = "New Animal State Condition";
			Target = this.FindComponent<MAnimal>();
		}
	}
}
