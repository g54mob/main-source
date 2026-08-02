using System;
using System.Collections.Generic;

[Serializable]
public class TutorialSaveData
{
	public int currentGroupIndex;

	public List<TaskGroupSaveData> taskGroupsProgress;

	public Dictionary<string, bool> commonTasksCompletion = new Dictionary<string, bool>();

	public Dictionary<string, int> commonTasksProgress = new Dictionary<string, int>();
}
