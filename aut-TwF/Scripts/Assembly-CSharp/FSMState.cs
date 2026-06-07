using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State", fileName = "Empty State")]
public class FSMState : ScriptableObject
{
	public List<FSMTransition> transitions;

	public List<FSMTask> tasks;

	public List<FSMTask> onEnterTasks;

	public List<FSMTask> onExitTasks;

	public FSMState EvaluateTransitions(FSMComponent ownerFSMComponent)
	{
		foreach (FSMTransition transition in transitions)
		{
			if (transition.EvaluateConditions(ownerFSMComponent))
			{
				return transition.state;
			}
		}
		return null;
	}
}
