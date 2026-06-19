using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct DamageObjectStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._damageObjectStateGroup.HasComponent(entity) && c._detectCollisionGroup.HasComponent(entity) && c._objectDataGroup.HasComponent(entity))
		{
			return c._behaviourTagsGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.DamageObject, stateInfo.newState == StateID.Chase && c._propertiesGroup[entity].Has(-1004432830)))
		{
			return;
		}
		DamageObjectStateCD value = c._damageObjectStateGroup[entity];
		DetectCollisionCD detectCollisionCD = c._detectCollisionGroup[entity];
		ObjectDataCD objectDataCD = c._objectDataGroup[entity];
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		if (!DamageObjectStateSystem.IsAllowedToDamageMoreObjects(in objectDataCD, objectPropertiesCD) || c._entityDestroyedGroup.HasAndIsComponentEnabled(detectCollisionCD.hitEntity) || !(detectCollisionCD.hitEntity != Entity.Null) || c._indestructibleGroup.HasAndIsComponentEnabled(detectCollisionCD.hitEntity))
		{
			return;
		}
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		FactionCD targetFaction = (c._factionGroup.HasComponent(detectCollisionCD.hitEntity) ? c._factionGroup[detectCollisionCD.hitEntity] : default(FactionCD));
		if (!factionCD.CanAttack(targetFaction, d.worldInfo))
		{
			return;
		}
		Entity entity2 = detectCollisionCD.hitEntity;
		TileCD targetTile = default(TileCD);
		ObjectDataCD objectDataCD2 = (c._objectDataGroup.HasComponent(entity2) ? c._objectDataGroup[entity2] : default(ObjectDataCD));
		if (objectDataCD2.objectID == ObjectID.None && c._tileGroup.HasComponent(entity2))
		{
			targetTile = c._tileGroup[detectCollisionCD.hitEntity];
			objectDataCD2.objectID = PugDatabase.GetObjectID(targetTile.tileset, targetTile.tileType, d.database);
			entity2 = PugDatabase.GetPrimaryPrefabEntity(objectDataCD2.objectID, d.database);
			if (!targetTile.tileType.IsDamageableTile())
			{
				return;
			}
		}
		if (c._damageReductionGroup.HasComponent(entity2) && c._healthGroup.HasComponent(entity2))
		{
			HealthCD healthCD = c._healthGroup[entity2];
			int damage = objectPropertiesCD.Get<int>(-636725815);
			if (c._tileGroup.HasComponent(entity2))
			{
				damage = objectPropertiesCD.Get<int>(-302465456);
			}
			if (c._localTransformGroup.HasComponent(entity2))
			{
				bool num = c._IgnoreImmuneZoneGroup.HasComponent(entity2);
				int2 worldPosition = c._localTransformGroup[entity2].Position.RoundToInt2();
				if (!num && d.tileLookup.HasType(worldPosition, TileType.immune))
				{
					return;
				}
			}
			if ((float)c._damageReductionGroup[entity2].GetDamageDealt(damage, bypassDamageReduction: false, bypassMaxDamagePerHit: false, isDamagedByDrill: false) < (float)healthCD.health / 5f)
			{
				return;
			}
		}
		if ((((stateInfo.newState == StateID.Chase && objectPropertiesCD.Has(-167409596)) || (c._objectCategoryGroup.HasComponent(entity2) && !BehaviourTagsCD.CantAttack(attackerBehaviourTags, c._objectCategoryGroup[entity2]))) & (targetTile.tileType != TileType.none || c._entityDestroyedGroup.HasComponent(detectCollisionCD.hitEntity))) && c._localTransformGroup.HasComponent(detectCollisionCD.hitEntity))
		{
			value.position = c._localTransformGroup[detectCollisionCD.hitEntity].Position.RoundToInt2();
			value.internalState = DamageObjectStateCD.InternalState.Init;
			value.targetEntity = detectCollisionCD.hitEntity;
			value.targetTile = targetTile;
			stateInfo.EnterState(StateID.DamageObject);
			c._damageObjectStateGroup[entity] = value;
		}
	}
}
