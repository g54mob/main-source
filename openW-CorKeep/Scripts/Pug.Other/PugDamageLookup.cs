using Pug.UnityExtensions;
using Unity.Entities;

public struct PugDamageLookup
{
	private readonly Entity _damagePrefabEntity;

	private ComponentLookup<PugDamageCD> _pugDamageLookup;

	private ComponentLookup<PugDamageRefCD> _pugDamageRefLookup;

	public PugDamageLookup(ref SystemState state, ComponentLookup<PugDamageCD> pugDamageLookup, ComponentLookup<PugDamageRefCD> pugDamageRefLookup)
	{
		_damagePrefabEntity = state.GetSingleton<PugDamagePrefabsCD>().DamageTakenPrefab;
		_pugDamageLookup = pugDamageLookup;
		_pugDamageRefLookup = pugDamageRefLookup;
	}

	public int GetDamage(Entity entity)
	{
		if (!_pugDamageRefLookup.TryGetComponent(entity, out var componentData) || !_pugDamageLookup.TryGetComponent(componentData.Entity, out var componentData2))
		{
			return 0;
		}
		return componentData2.Damage;
	}

	public void AddDamage(EntityCommandBuffer ecb, Entity entity, int value)
	{
		if (_pugDamageRefLookup.TryGetComponent(entity, out var componentData) && _pugDamageLookup.TryGetComponent(componentData.Entity, out var componentData2))
		{
			componentData2.Damage += value;
			_pugDamageLookup[componentData.Entity] = componentData2;
			return;
		}
		Entity e = ecb.Instantiate(_damagePrefabEntity);
		ecb.SetComponent(e, new PugDamageCD
		{
			Entity = entity,
			Damage = value
		});
	}
}
