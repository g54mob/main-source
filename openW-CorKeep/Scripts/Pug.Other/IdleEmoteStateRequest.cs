using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct IdleEmoteStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._idleEmoteStateGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity))
		{
			return c._localTransformGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.IdleEmoting))
		{
			return;
		}
		IdleEmoteStateCD value = c._idleEmoteStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		if (!value.cooldownTimer.isRunning)
		{
			float min = objectPropertiesCD.Get<float>(-2086939603);
			float max = objectPropertiesCD.Get<float>(1335275298);
			float newLifespan = d._rng.NextFloat(min, max);
			value.cooldownTimer.Start(d._elapsedTime, newLifespan);
		}
		using NativeArray<IdleEmoteAnimationData> nativeArray = objectPropertiesCD.GetList<IdleEmoteAnimationData>(-1528401496, Allocator.Temp);
		if (!isInCombatCD.isInCombat && nativeArray.Length > 0 && value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			value.internalState = 0;
			value.cooldownTimer.Stop();
			value.animationIndexToPlay = d._rng.NextInt(0, nativeArray.Length);
			if (!nativeArray[value.animationIndexToPlay].mustBeOnWalkableGround || d.tileLookup.GetTopType(c._localTransformGroup[entity].Position.RoundToInt2()).IsWalkableTile())
			{
				stateInfo.EnterState(StateID.IdleEmoting);
			}
		}
		c._idleEmoteStateGroup[entity] = value;
	}
}
