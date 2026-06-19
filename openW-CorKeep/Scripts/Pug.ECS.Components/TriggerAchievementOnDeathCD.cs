using Unity.Entities;

public struct TriggerAchievementOnDeathCD : IComponentData, IQueryTypeParameter
{
	public AchievementID achievement;
}
