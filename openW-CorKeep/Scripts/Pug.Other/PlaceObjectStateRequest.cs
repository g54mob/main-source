using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct PlaceObjectStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._placeObjectStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity) && c._objectDataGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.PlaceObject))
		{
			return;
		}
		PlaceObjectStateCD value = c._placeObjectStateGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		ObjectDataCD objectDataCD = c._objectDataGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		if (objectDataCD.amount - 1 >= value.maxObjectsToPlace)
		{
			return;
		}
		if (value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			c._placeObjectStateGroup[entity] = value;
			return;
		}
		c._placeObjectStateGroup[entity] = value;
		bool flag = false;
		if (value.onlyPlaceWhenInCombatWithPlayer)
		{
			if (!isInCombatCD.isInCombat)
			{
				return;
			}
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				if (c._playerGhostGroup.HasComponent(dynamicBuffer[i].entity))
				{
					flag = true;
					break;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		int2 worldPosition = localTransform.Position.RoundToInt2();
		TileCD top = d.tileLookup.GetTop(worldPosition);
		if (top.tileType != value.placeOnTileType || (!value.placeOnAnyTileset && top.tileset != (int)value.placeOnTileset))
		{
			return;
		}
		bool flag2 = false;
		float3 position = math.round(localTransform.Position);
		NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
		if (d.collisionWorld.OverlapSphere(position, 0.45f, ref outHits, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 131935u
		}))
		{
			for (int j = 0; j < outHits.Length; j++)
			{
				if (outHits[j].Entity != entity)
				{
					flag2 = true;
					break;
				}
			}
		}
		outHits.Dispose();
		if (!flag2)
		{
			value.internalState = 0;
			stateInfo.EnterState(StateID.PlaceObject);
			c._placeObjectStateGroup[entity] = value;
		}
	}
}
