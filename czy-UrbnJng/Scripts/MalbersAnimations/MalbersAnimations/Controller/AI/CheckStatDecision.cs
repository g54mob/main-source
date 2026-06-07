using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Stat", order = 4)]
	public class CheckStatDecision : MAIDecision
	{
		public enum checkStatOption
		{
			Compare = 0,
			CompareNormalized = 1,
			IsInmune = 2,
			Regenerating = 3,
			Degenerating = 4,
			IsEmpty = 5,
			IsFull = 6,
			IsActive = 7,
			ValueChanged = 8,
			ValueReduced = 9,
			ValueIncreased = 10
		}

		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target)")]
		public Affected checkOn;

		[Tooltip("Stat you want to find")]
		public StatID Stat;

		[Tooltip("What do you want to do with the Stat?")]
		public checkStatOption Option;

		[Tooltip("(Option Compare Only) Type of the comparation")]
		public ComparerInt StatIs = ComparerInt.Less;

		public float Value;

		[Tooltip("(Option Compare Only) Value to Compare the Stat")]
		[ContextMenuItem("Recover Value", "RecoverValue")]
		public FloatReference m_Value = new FloatReference();

		[Space]
		[Tooltip("Uses TryGet Value in case you don't know if your target or your animal has the Stat you are looking for. Disabling this Improves performance")]
		public bool TryGetValue = true;

		[HideInInspector]
		public bool hideVars;

		public override string DisplayName => "General/Check Stat";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			switch (checkOn)
			{
			case Affected.Self:
				if (TryGetValue)
				{
					if (brain.AnimalStats.TryGetValue(Stat.ID, out var value2))
					{
						brain.DecisionsVars[Index].floatValue = value2.Value;
					}
				}
				else
				{
					brain.DecisionsVars[Index].floatValue = brain.AnimalStats[Stat.ID].Value;
				}
				break;
			case Affected.Target:
				if (!brain.TargetHasStats)
				{
					break;
				}
				if (TryGetValue)
				{
					if (brain.TargetStats.TryGetValue(Stat.ID, out var value))
					{
						brain.DecisionsVars[Index].floatValue = value.Value;
					}
				}
				else
				{
					brain.DecisionsVars[Index].floatValue = brain.TargetStats[Stat.ID].Value;
				}
				break;
			}
		}

		public override bool Decide(MAnimalBrain brain, int index)
		{
			bool result = false;
			switch (checkOn)
			{
			case Affected.Self:
				if (TryGetValue)
				{
					if (brain.AnimalStats.TryGetValue(Stat.ID, out var value2))
					{
						result = CheckStat(value2, brain, index);
					}
				}
				else
				{
					Stat stat2 = brain.AnimalStats[Stat.ID];
					result = CheckStat(stat2, brain, index);
				}
				break;
			case Affected.Target:
				if (!brain.TargetHasStats)
				{
					break;
				}
				if (TryGetValue)
				{
					if (brain.TargetStats.TryGetValue(Stat.ID, out var value))
					{
						result = CheckStat(value, brain, index);
					}
				}
				else
				{
					Stat stat = brain.TargetStats[Stat.ID];
					result = CheckStat(stat, brain, index);
				}
				break;
			}
			return result;
		}

		private void RecoverValue()
		{
			m_Value.Value = Value;
		}

		private bool CheckStat(Stat stat, MAnimalBrain brain, int Index)
		{
			return Option switch
			{
				checkStatOption.Compare => CompareWithValue(stat.Value), 
				checkStatOption.CompareNormalized => CompareWithValue(stat.NormalizedValue), 
				checkStatOption.IsInmune => stat.IsImmune, 
				checkStatOption.Regenerating => stat.IsRegenerating, 
				checkStatOption.Degenerating => stat.IsDegenerating, 
				checkStatOption.IsEmpty => stat.Value == stat.MinValue, 
				checkStatOption.IsFull => stat.Value == stat.MaxValue, 
				checkStatOption.IsActive => stat.Active, 
				checkStatOption.ValueChanged => (float)stat.value != brain.DecisionsVars[Index].floatValue, 
				checkStatOption.ValueReduced => (float)stat.value < brain.DecisionsVars[Index].floatValue, 
				checkStatOption.ValueIncreased => (float)stat.value > brain.DecisionsVars[Index].floatValue, 
				_ => false, 
			};
		}

		private bool CompareWithValue(float stat)
		{
			return StatIs switch
			{
				ComparerInt.Equal => stat == (float)m_Value, 
				ComparerInt.Greater => stat > (float)m_Value, 
				ComparerInt.Less => stat < (float)m_Value, 
				ComparerInt.NotEqual => stat != (float)m_Value, 
				_ => false, 
			};
		}

		private void OnValidate()
		{
			hideVars = Option != checkStatOption.Compare && Option != checkStatOption.CompareNormalized;
		}

		private void Reset()
		{
			Description = "Checks for a Stat value, Compares or search for a Stat Property and returns the succeded value";
		}
	}
}
