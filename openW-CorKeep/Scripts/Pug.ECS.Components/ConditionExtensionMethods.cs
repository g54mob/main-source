using Unity.NetCode;

public static class ConditionExtensionMethods
{
	public static Condition ToCondition(this ConditionSerialized c, NetworkTick currentTick, uint tickRate)
	{
		return new Condition
		{
			conditionData = new ConditionData
			{
				conditionID = (ConditionID)c.Id,
				duration = c.Duration,
				value = c.Value
			},
			removeTick = NetworkTimeUtilities.SecondsToTick(c.Timer, currentTick, tickRate)
		};
	}

	public static ConditionSerialized ToConditionSerialized(this Condition c, NetworkTick currentTick, uint tickRate)
	{
		return new ConditionSerialized
		{
			Id = (int)c.conditionData.conditionID,
			Value = c.conditionData.value,
			Duration = c.conditionData.duration,
			Timer = NetworkTimeUtilities.TimeBetweenTicksInSeconds(currentTick, c.removeTick, tickRate)
		};
	}
}
