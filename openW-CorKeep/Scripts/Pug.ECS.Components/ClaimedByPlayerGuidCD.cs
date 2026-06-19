using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ClaimedByPlayerGuidCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Hash128 playerGuid;

	public NetworkTick lastLocalWithinClaimdistanceTick;

	public bool isClaimed => playerGuid != default(Hash128);

	public bool ShouldDisplayClaimEmotes(NetworkTick currentTick)
	{
		if (lastLocalWithinClaimdistanceTick.IsValid)
		{
			return currentTick.TicksSince(lastLocalWithinClaimdistanceTick) > 10;
		}
		return true;
	}
}
