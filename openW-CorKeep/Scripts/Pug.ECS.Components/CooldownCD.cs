using Unity.Entities;

public struct CooldownCD : IComponentData, IQueryTypeParameter
{
	public SyncedSharedCooldownType syncedSharedCooldownType;

	public float cooldown;

	public bool casualCharacterIgnoresCustomCooldown;
}
