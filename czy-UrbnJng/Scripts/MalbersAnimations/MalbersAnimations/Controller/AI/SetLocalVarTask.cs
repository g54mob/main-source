using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Local Var")]
	public class SetLocalVarTask : MTask
	{
		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target), or on an object with a tag")]
		public Affected checkOn;

		public List<LocalVar> variables;

		public override string DisplayName => "Variables/Set Local Var";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			if (checkOn == Affected.Self && brain.LocalVars != null)
			{
				foreach (LocalVar variable in variables)
				{
					brain.LocalVars.SetVar(variable);
				}
			}
			else if (checkOn == Affected.Target && brain.TargetVars != null)
			{
				foreach (LocalVar variable2 in variables)
				{
					brain.TargetVars.SetVar(variable2);
				}
			}
			brain.TaskDone(index);
		}
	}
}
