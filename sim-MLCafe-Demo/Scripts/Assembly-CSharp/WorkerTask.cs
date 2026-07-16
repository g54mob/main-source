using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class WorkerTask
{
	public enum TaskType
	{
		None = 0,
		Operate = 1,
		Collect = 2,
		Transport = 3
	}

	public string name;

	public TaskType taskType;

	public List<WorkerTaskTarget> targetId = new List<WorkerTaskTarget>();

	public WorkerTaskTarget GetTargetFromUnlocked(int globalId)
	{
		return GetUnlockedTargets().Find((WorkerTaskTarget x) => x.targetId == globalId);
	}

	public List<WorkerTaskTarget> GetUnlockedTargets()
	{
		return targetId.Where((WorkerTaskTarget x) => x.unlocked).ToList();
	}
}
