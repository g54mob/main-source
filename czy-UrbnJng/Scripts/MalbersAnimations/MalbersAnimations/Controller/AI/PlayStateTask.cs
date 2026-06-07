using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Play Animal State")]
	public class PlayStateTask : MTask
	{
		[Space]
		[Tooltip("State to play")]
		public StateID StateID;

		[Tooltip("Play the State only when the animal has arrived to the target")]
		public bool PlayNearTarget;

		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		[Tooltip("What to do with the State")]
		public StateAction action;

		public ExecuteTask Play;

		public override string DisplayName => "Animal/Set State";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			if (Play == ExecuteTask.OnStart)
			{
				StateActivate(brain);
				brain.TaskDone(index);
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if (Play == ExecuteTask.OnUpdate)
			{
				StateActivate(brain);
			}
		}

		private void StateActivate(MAnimalBrain brain)
		{
			if (PlayNearTarget && !brain.AIControl.HasArrived)
			{
				return;
			}
			switch (affect)
			{
			case Affected.Self:
				PlayState(brain.Animal);
				break;
			case Affected.Target:
				if ((bool)brain.TargetAnimal)
				{
					PlayState(brain.TargetAnimal);
				}
				break;
			}
		}

		public void PlayState(MAnimal CurrentAnimal)
		{
			switch (action)
			{
			case StateAction.Activate:
				CurrentAnimal.State_Activate(StateID);
				break;
			case StateAction.AllowExit:
				if (CurrentAnimal.ActiveStateID == StateID)
				{
					CurrentAnimal.ActiveState.AllowExit();
				}
				break;
			case StateAction.ForceActivate:
				CurrentAnimal.State_Force(StateID);
				break;
			case StateAction.Enable:
				CurrentAnimal.State_Enable(StateID);
				break;
			case StateAction.Disable:
				CurrentAnimal.State_Disable(StateID);
				break;
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			if (Play == ExecuteTask.OnExit)
			{
				StateActivate(brain);
			}
			brain.TaskDone(index);
		}

		private void Reset()
		{
			Description = "Plays a State on the Animal(Self or the Target)";
		}
	}
}
