using Unity.Entities;

public struct ClaimedByCharacterGuidCD : IComponentData, IQueryTypeParameter
{
	public Hash128 characterGuid;

	public bool isClaimed => characterGuid != default(Hash128);
}
