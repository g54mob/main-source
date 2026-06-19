using System;

[Serializable]
public class SaveableGoals
{
	public int goalsVersion;

	public SerializableDictionary<GoalCondition, int> goalConditions;

	public SerializableDictionary<string, GoalStatus> goalStatusDict;
}
