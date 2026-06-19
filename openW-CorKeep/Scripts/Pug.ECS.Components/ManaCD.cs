using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ManaCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int mana;

	[GhostField]
	public int maxMana;

	[GhostField]
	public float accumulatedMana;

	public bool isUnlimited;

	[GhostField]
	public bool delay;

	[GhostField]
	public TickTimer manaRegenTimer;

	public float Normalized => (float)mana / (float)maxMana;

	public bool HasFullMana => mana >= maxMana;
}
