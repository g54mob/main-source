using System.Runtime.CompilerServices;
using Unity.Entities;

public static class TrackedCombatantsHelpers
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValidTarget(Entity target, ComponentLookup<DisablePhysicsCD> disablePhysicsLookup, ComponentLookup<HealthCD> healthLookup, ComponentLookup<EntityPartCD> entityPartLookup, ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup)
	{
		Entity entity = target;
		if (entityPartLookup.TryGetComponent(target, out var componentData))
		{
			entity = componentData.mainEntity;
		}
		if ((!disablePhysicsLookup.HasComponent(target) || !disablePhysicsLookup.IsComponentEnabled(target)) && healthLookup.HasComponent(entity) && healthLookup[entity].health > 0)
		{
			if (immuneToDamageLookup.TryGetComponent(target, out var componentData2))
			{
				return componentData2.Value == ImmuneToDamageState.Vulnerable;
			}
			return true;
		}
		return false;
	}
}
