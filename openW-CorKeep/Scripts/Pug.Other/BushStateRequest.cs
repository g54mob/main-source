using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BushStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._bushStateGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		BushStateCD value = c._bushStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		if (isInCombatCD.isInCombat || stateInfo.HasState(StateID.Bush))
		{
			return;
		}
		if (isInCombatCD.justLeftCombat)
		{
			float num = c._propertiesGroup[entity].Get<float>(-1101092475);
			if (value.cooldownTimer.isRunning)
			{
				num = math.max(num, value.cooldownTimer.GetRemainingTime(d._elapsedTime));
			}
			value.cooldownTimer.Start(d._elapsedTime, num);
			c._bushStateGroup[entity] = value;
		}
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		if (value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			return;
		}
		float3 frompos = c._localTransformGroup[entity].Position + new float3(0f, 0.5f, 0f);
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (c._objectDataGroup.TryGetComponent(dynamicBuffer[i].entity, out var componentData) && componentData.objectID == ObjectID.Player && (!c._entityDestroyedGroup.HasComponent(dynamicBuffer[i].entity) || !c._entityDestroyedGroup.IsComponentEnabled(dynamicBuffer[i].entity)))
			{
				float3 topos = c._localTransformGroup[dynamicBuffer[i].entity].Position + new float3(0f, 0.5f, 0f);
				uint layerMaskCollidesWith = 131329u;
				RaycastInput raycastInput = PhysicsManager.GetRaycastInput(frompos, topos, uint.MaxValue, layerMaskCollidesWith);
				if (!d.collisionWorld.CastRay(raycastInput))
				{
					return;
				}
			}
		}
		if (!c._lastAttackerGroup.TryGetComponent(entity, out var componentData2) || !(componentData2.Value != Entity.Null))
		{
			value.nextInternalStateOnTimerElapse = BushStateCD.InternalState.EnterState;
			value.randomlyLeaveStatetimer.Stop();
			c._bushStateGroup[entity] = value;
			stateInfo.EnterState(StateID.Bush);
		}
	}
}
