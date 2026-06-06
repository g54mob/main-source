using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Stance")]
	public class SetStanceTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		[Tooltip("Stance to Set on Task Enter. Leave empty to ignore it")]
		[FormerlySerializedAs("stance")]
		public StanceID stanceOnEnter;

		[Tooltip("Stance to Set on Task Exit. Leave empty to ignore it")]
		public StanceID stanceOnExit;

		[Hide("stanceOnEnter", true)]
		[Tooltip("Restore the stance to the default value on Enter Task")]
		public bool restoreDefaultOnEnter;

		[Hide("stanceOnExit", true)]
		[Tooltip("Restore the stance to the default value on Exit Task")]
		public bool restoreDefaultOnExit;

		public override string DisplayName => "Animal/Set Stance";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			switch (affect)
			{
			case Affected.Self:
				Stance_Set(brain.Animal, stanceOnEnter, onEnter: true);
				break;
			case Affected.Target:
				Stance_Set(brain.TargetAnimal, stanceOnEnter, onEnter: true);
				break;
			}
			brain.TaskDone(index);
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			switch (affect)
			{
			case Affected.Self:
				Stance_Set(brain.Animal, stanceOnExit, onEnter: false);
				break;
			case Affected.Target:
				Stance_Set(brain.TargetAnimal, stanceOnExit, onEnter: false);
				break;
			}
		}

		public void Stance_Set(MAnimal animal, StanceID stance, bool onEnter)
		{
			if (animal != null)
			{
				if (stance != null)
				{
					animal.Stance_Set(stance);
				}
				else if ((onEnter && restoreDefaultOnEnter) || (!onEnter && restoreDefaultOnExit))
				{
					animal.Stance_RestoreDefault();
				}
			}
		}

		private void Reset()
		{
			Description = "Set a stance on the Animal";
		}
	}
}
