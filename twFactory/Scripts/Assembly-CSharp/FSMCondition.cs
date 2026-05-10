using UnityEngine;

public abstract class FSMCondition : ScriptableObject
{
	[SerializeField]
	protected bool invertCondition;

	public bool CheckCondition(FSMComponent ownerFSMComponent)
	{
		if (!invertCondition)
		{
			return CheckCondition_Imp(ownerFSMComponent);
		}
		return !CheckCondition_Imp(ownerFSMComponent);
	}

	public abstract bool CheckCondition_Imp(FSMComponent ownerFSMComponent);
}
