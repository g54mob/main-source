using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Compare Stats", order = 4)]
	public class CompareStatsDecision : MAIDecision
	{
		[Tooltip("Stats you want to find on the AI Animal")]
		public StatID OwnStat;

		[Tooltip("Compare values of the Stat")]
		public ComparerInt compare = ComparerInt.Less;

		[Tooltip("Stats you want to find on the Target")]
		public StatID TargetStat;

		public override string DisplayName => "General/Compare Stats";

		public override bool Decide(MAnimalBrain brain, int index)
		{
			bool result = false;
			Dictionary<int, Stat> animalStats = brain.AnimalStats;
			Dictionary<int, Stat> targetStats = brain.TargetStats;
			if (animalStats != null && targetStats != null && animalStats.TryGetValue(OwnStat, out var value) && targetStats.TryGetValue(TargetStat, out var value2))
			{
				return value.Value.CompareFloat(value2.value, compare);
			}
			return result;
		}

		private void Reset()
		{
			Description = "Checks for a Stat value in the AI Animal and the Current Target, Compares the values using the condition";
		}
	}
}
