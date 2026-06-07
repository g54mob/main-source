using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Invoke Event")]
	public class InvokeEventTask : MTask
	{
		[Space]
		[Tooltip("Send the Animal as the Event Parameter or the Target")]
		public Affected send;

		public GameObjectEvent Raise = new GameObjectEvent();

		public GameObjectEvent OnExitTask = new GameObjectEvent();

		public override string DisplayName => "General/Invoke Event";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.TaskDone(index);
			switch (send)
			{
			case Affected.Self:
				Raise.Invoke(brain.Animal.gameObject);
				break;
			case Affected.Target:
				Raise.Invoke(brain.Target.gameObject);
				break;
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			switch (send)
			{
			case Affected.Self:
				OnExitTask.Invoke(brain.Animal.gameObject);
				break;
			case Affected.Target:
				OnExitTask.Invoke(brain.Target.gameObject);
				break;
			}
		}

		private void Reset()
		{
			Description = "Raise the Event when the Task start. Use this only for Scriptable Assets.";
		}
	}
}
