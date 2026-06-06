using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Reaction Task")]
	public class ReactionTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		[Tooltip("Use the Interval value to repeat the reaction")]
		public bool repeat;

		[SerializeReference]
		[SubclassSelector]
		[Tooltip("Reaction when the AI Task begin")]
		public Reaction reaction;

		[SerializeReference]
		[SubclassSelector]
		[Tooltip("Reaction when the AI State ends")]
		public Reaction reactionOnExit;

		public override string DisplayName => "General/Reaction";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.TasksVars[index].Components = new Component[1];
			brain.TasksVars[index].Components[0] = reaction.VerifyComponent((affect == Affected.Self) ? ((Component)brain.Animal) : ((Component)brain.Target));
			React(brain, index, reaction);
			if (!repeat)
			{
				brain.TaskDone(index);
			}
		}

		private void React(MAnimalBrain brain, int index, Reaction reaction)
		{
			reaction?.React(brain.TasksVars[index].Components[0]);
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			React(brain, index, reaction);
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			React(brain, index, reactionOnExit);
		}

		private void Reset()
		{
			Description = "Add a Reaction to the Target or the Animal";
		}
	}
}
