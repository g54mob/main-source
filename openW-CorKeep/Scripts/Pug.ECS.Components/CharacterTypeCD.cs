using Unity.Entities;
using Unity.NetCode;

public struct CharacterTypeCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public CharacterType characterType;

	public readonly bool IsHardcore()
	{
		return characterType == CharacterType.Hardcore;
	}

	public readonly bool IsCasual()
	{
		return characterType == CharacterType.Casual;
	}
}
