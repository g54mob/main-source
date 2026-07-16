using System;

[Serializable]
public class WorkerTaskTarget
{
	public int targetId;

	public bool unlocked;

	public WorkerTaskTarget(int targetId)
	{
		this.targetId = targetId;
		unlocked = false;
	}
}
