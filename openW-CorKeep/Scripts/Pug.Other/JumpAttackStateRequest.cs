using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct JumpAttackStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._jumpAttackStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._behaviourTagsGroup.HasComponent(entity))
		{
			return c._attackCooldownGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.JumpAttack))
		{
			return;
		}
		JumpAttackStateCD value = c._jumpAttackStateGroup[entity];
		AttackCooldownTimerCD value2 = c._attackCooldownGroup[entity];
		if (value2.Value.isRunning && !value2.Value.IsTimerElapsed(d._elapsedTime))
		{
			c._jumpAttackStateGroup[entity] = value;
			c._attackCooldownGroup[entity] = value2;
			return;
		}
		LocalTransform localTransform = c._localTransformGroup[entity];
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		Entity entity2 = Entity.Null;
		NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
		DynamicBuffer<NearbyEntitiesBufferCD> bufferData;
		if (c._ownerGroup.HasComponent(entity))
		{
			Entity owner = c._ownerGroup[entity].owner;
			if (c._combatantTrackerBuffer.HasComponent(owner))
			{
				for (int i = 0; i < c._combatantTrackerBuffer[owner].Length; i++)
				{
					CombatantsTrackerBuffer combatantsTrackerBuffer = c._combatantTrackerBuffer[owner][i];
					nativeList.Add(in combatantsTrackerBuffer.Target);
				}
			}
		}
		else if (c._nearbyEntitiesBufferGroup.TryGetBuffer(entity, out bufferData))
		{
			for (int j = 0; j < bufferData.Length; j++)
			{
				Entity value3 = bufferData[j].entity;
				nativeList.Add(in value3);
			}
		}
		if (c._lastAttackerGroup.TryGetComponent(entity, out var componentData))
		{
			Entity value4 = componentData.Value;
			if (value4 != Entity.Null)
			{
				nativeList.Add(in value4);
			}
		}
		for (int k = 0; k < nativeList.Length; k++)
		{
			Entity entity3 = nativeList[k];
			Entity entity4 = entity3;
			if (c._entityPartGroup.TryGetComponent(entity4, out var componentData2))
			{
				entity4 = componentData2.mainEntity;
			}
			if (!c._healthGroup.HasComponent(entity4) || (float)c._healthGroup[entity4].health <= 0f || !c._localTransformGroup.HasComponent(entity3) || !c._objectDataGroup.HasComponent(entity4) || (c._entityDestroyedGroup.HasComponent(entity4) && c._entityDestroyedGroup.IsComponentEnabled(entity4)) || c._physicsExcludeGroup.HasAndIsComponentEnabled(entity3))
			{
				continue;
			}
			float3 position = c._localTransformGroup[entity3].Position;
			float num = (c._combatRadiusGroup.HasComponent(entity3) ? c._combatRadiusGroup[entity3].radius : 0f);
			if (!(math.distance(position, localTransform.Position) < math.sqrt(c._propertiesGroup[entity].Get<float>(-1114162272)) + num))
			{
				continue;
			}
			FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
			FactionCD targetFaction = (c._factionGroup.HasComponent(entity4) ? c._factionGroup[entity4] : default(FactionCD));
			if (!factionCD.CanAttack(targetFaction, d.worldInfo) || (c._petGroup.HasComponent(entity) && c._shieldGroup.HasComponent(entity4) && c._shieldGroup[entity4].active))
			{
				continue;
			}
			ObjectCategoryTagsCD componentData3;
			bool flag = c._objectCategoryTagsGroup.TryGetComponent(entity4, out componentData3) && !BehaviourTagsCD.CantAttack(attackerBehaviourTags, componentData3);
			if (flag)
			{
				int2 int5 = localTransform.Position.RoundToInt2();
				int2 end = position.RoundToInt2();
				int2 pos = int5;
				do
				{
					if (!d.tileLookup.GetTopType(pos).IsWalkableTile())
					{
						flag = false;
						break;
					}
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
			}
			if (flag)
			{
				entity2 = entity3;
				break;
			}
		}
		if (entity2 != Entity.Null && (stateInfo.currentState != StateID.JumpAttack || value.target != entity2 || value.internalState == 3))
		{
			value.target = entity2;
			value.jumpDirection = math.normalizesafe(c._localTransformGroup[entity2].Position - localTransform.Position);
			value.internalState = 0;
			value.stopJumpAttack = false;
			stateInfo.EnterState(StateID.JumpAttack);
		}
		c._jumpAttackStateGroup[entity] = value;
	}
}
