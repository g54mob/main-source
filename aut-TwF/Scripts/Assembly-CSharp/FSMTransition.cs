using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transition")]
public class FSMTransition : ScriptableObject
{
	public FSMState state;

	public List<FSMCondition> conditions;

	public bool EvaluateConditions(FSMComponent ownerFSMComponent)
	{
		foreach (FSMCondition condition in conditions)
		{
			if (!condition.CheckCondition(ownerFSMComponent))
			{
				return false;
			}
		}
		return true;
	}
}
