using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct LarvaHiveBossHatchStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._larvaHiveBossHatchEggStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.LarvaHiveBossHatchEgg))
		{
			return;
		}
		LarvaHiveBossHatchEggStateCD value = c._larvaHiveBossHatchEggStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		if (!isInCombatCD.isInCombat)
		{
			value.eggCooldownTimer.Stop();
		}
		else if (!value.eggCooldownTimer.isRunning)
		{
			value.eggCooldownTimer.Start(d._elapsedTime, 3f);
		}
		else if (value.eggCooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			d.collisionWorld.OverlapSphere(localTransform.Position, 20f, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 16u
			});
			int length = outHits.Length;
			outHits.Dispose();
			int num = 50;
			if (length > num)
			{
				float t = (float)healthCD.health / (float)healthCD.maxHealth;
				value.eggCooldownTimer.Start(d._elapsedTime, math.lerp(10f, 17f, t));
			}
			else
			{
				stateInfo.EnterState(StateID.LarvaHiveBossHatchEgg);
			}
		}
		c._larvaHiveBossHatchEggStateGroup[entity] = value;
	}
}
