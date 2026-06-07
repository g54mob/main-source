using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/In Zone")]
	public class InZoneTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		public override string DisplayName => "Animal/In Zone";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			DoTask(brain, index);
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			DoTask(brain, index);
		}

		private void DoTask(MAnimalBrain brain, int index)
		{
			bool flag = false;
			switch (affect)
			{
			case Affected.Self:
				flag = InZone(brain.Animal);
				break;
			case Affected.Target:
				flag = InZone(brain.TargetAnimal);
				break;
			}
			if (flag)
			{
				brain.TaskDone(index);
			}
		}

		public bool InZone(MAnimal animal)
		{
			if ((bool)animal && animal.InZone)
			{
				animal.Zone.ActivateZone(animal);
				return true;
			}
			return false;
		}

		private void Reset()
		{
			Description = "Activate the Zone the animal is inside";
		}
	}
}
