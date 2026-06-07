using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Stat")]
	public class SetStatTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		public StatModifier stat;

		public override string DisplayName => "General/Set Stat";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			Stat value2;
			if (affect == Affected.Self)
			{
				if (brain.AnimalStats != null && brain.AnimalStats.TryGetValue(stat.ID, out var value))
				{
					stat.ModifyStat(value);
				}
			}
			else if (brain.TargetStats != null && brain.TargetStats.TryGetValue(stat.ID, out value2))
			{
				stat.ModifyStat(value2);
			}
			brain.TaskDone(index);
		}
	}
}
