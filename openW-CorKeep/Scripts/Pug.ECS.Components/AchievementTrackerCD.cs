using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AchievementTrackerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool cherryBlossomAchievement;

	public bool hasTriggeredCherryBlossomAchievement;
}
