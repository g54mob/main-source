using System;
using MalbersAnimations.Controller;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalMode : MAnimalCondition
	{
		public enum ModeCondition
		{
			PlayingMode = 0,
			PlayingAbility = 1,
			HasMode = 2,
			HasAbility = 3,
			Enabled = 4
		}

		public ModeCondition Condition;

		public ModeID Value;

		[Hide("Condition", new int[] { 1, 3 })]
		public string AbilityName;

		private Mode mode;

		public override string DisplayName => "Animal/Modes";

		private void OnEnable()
		{
			if ((bool)Target)
			{
				mode = Target.Mode_Get(Value);
			}
		}

		public void SetValue(ModeID v)
		{
			Value = v;
		}

		public override bool _Evaluate()
		{
			if (Target != null && mode != null)
			{
				switch (Condition)
				{
				case ModeCondition.PlayingMode:
					if (Target.IsPlayingMode)
					{
						if (!(Value == null))
						{
							return Target.ActiveMode.ID == Value;
						}
						return true;
					}
					return false;
				case ModeCondition.PlayingAbility:
					if (Target.IsPlayingMode)
					{
						if (!string.IsNullOrEmpty(AbilityName))
						{
							return Target.ActiveMode.ActiveAbility.Name == AbilityName;
						}
						return true;
					}
					return false;
				case ModeCondition.HasMode:
					return mode != null;
				case ModeCondition.HasAbility:
					if (mode != null)
					{
						return mode.Abilities.Exists((Ability x) => x.Name == AbilityName);
					}
					return false;
				case ModeCondition.Enabled:
					if (mode != null)
					{
						return mode.Active;
					}
					return false;
				}
			}
			return false;
		}

		private void Reset()
		{
			Name = "New Animal Mode Condition";
		}
	}
}
