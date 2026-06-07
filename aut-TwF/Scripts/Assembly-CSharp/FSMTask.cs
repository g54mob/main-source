using UnityEngine;

public abstract class FSMTask : ScriptableObject
{
	public bool instanceTask;

	public abstract void ExecuteTask(FSMComponent ownerFSMComponent);

	public virtual void StartTask(FSMComponent ownerFSMComponent)
	{
	}

	public virtual void EndTask(FSMComponent ownerFSMComponent)
	{
	}
}
