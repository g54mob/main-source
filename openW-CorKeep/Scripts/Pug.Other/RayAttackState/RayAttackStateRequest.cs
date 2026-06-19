using System.Runtime.InteropServices;
using Pug.Automation;
using Unity.Entities;

namespace RayAttackState
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RayAttackStateRequest : IStateRequester
	{
		public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
		{
			if (c._rayAttackStateGroup.HasComponent(entity) && c._attackCooldownGroup.HasComponent(entity))
			{
				return c._localTransformGroup.HasComponent(entity);
			}
			return false;
		}

		public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
		{
			if (!stateInfo.HasState(StateID.RayAttack))
			{
				AttackCooldownTimerCD value = c._attackCooldownGroup[entity];
				ElectricityCD componentData;
				if (value.Value.isRunning && !value.Value.IsTimerElapsed(d._elapsedTime))
				{
					c._attackCooldownGroup[entity] = value;
				}
				else if (!c._electricityGroup.TryGetComponent(entity, out componentData) || componentData.hasEnoughElectricityToPowerStuff)
				{
					stateInfo.EnterState(StateID.RayAttack);
					c._attackCooldownGroup[entity] = value;
					RayAttackStateCD rayAttackStateCD = c._rayAttackStateGroup[entity];
					rayAttackStateCD.state = RayAttackStateCD.State.Initializing;
				}
			}
		}
	}
}
