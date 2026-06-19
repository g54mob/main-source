using Unity.Entities;

namespace PlayerState
{
	public static class ControllingStateCommon
	{
		public static bool TryStartControllingControllableElseLeaveState<T>(Entity entity, RefRW<ControllingOtherEntityCD> controllingOtherEntityCD, RefRW<PlayerStateCD> playerStateCD, ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup, ComponentLookup<Simulate> simulateLookup, ComponentLookup<T> validateComponentLookup, bool isPartialTick) where T : unmanaged, IComponentData
		{
			Entity requestToBeControlledEntity = controllingOtherEntityCD.ValueRO.requestToBeControlledEntity;
			controllingOtherEntityCD.ValueRW.requestToBeControlledEntity = Entity.Null;
			if (!validateComponentLookup.HasComponent(requestToBeControlledEntity))
			{
				playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return false;
			}
			controllingOtherEntityCD.ValueRW.controlledEntity = requestToBeControlledEntity;
			if (simulateLookup.HasComponent(requestToBeControlledEntity) && !simulateLookup.IsComponentEnabled(requestToBeControlledEntity))
			{
				return true;
			}
			if (controlledByOtherEntityLookup.TryGetComponent(requestToBeControlledEntity, out var componentData) && componentData.controlledByEntity == Entity.Null)
			{
				if (!isPartialTick)
				{
					controlledByOtherEntityLookup.GetRefRW(requestToBeControlledEntity).ValueRW.controlledByEntity = entity;
				}
			}
			else if (componentData.controlledByEntity != entity)
			{
				playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return false;
			}
			return true;
		}

		public static void TryChangeToRequestedControllable<T>(Entity entity, RefRW<ControllingOtherEntityCD> controllingOtherEntityCD, RefRW<PlayerStateCD> playerStateCD, ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup, ComponentLookup<Simulate> simulateLookup, ComponentLookup<T> validateComponentLookup, bool isPartialTick) where T : unmanaged, IComponentData
		{
			Entity requestToBeControlledEntity = controllingOtherEntityCD.ValueRO.requestToBeControlledEntity;
			controllingOtherEntityCD.ValueRW.requestToBeControlledEntity = Entity.Null;
			if (!validateComponentLookup.HasComponent(requestToBeControlledEntity))
			{
				return;
			}
			ReleaseControlledEntity(entity, controllingOtherEntityCD, controlledByOtherEntityLookup, simulateLookup);
			controllingOtherEntityCD.ValueRW.controlledEntity = requestToBeControlledEntity;
			if (simulateLookup.HasComponent(requestToBeControlledEntity) && !simulateLookup.IsComponentEnabled(requestToBeControlledEntity))
			{
				return;
			}
			if (controlledByOtherEntityLookup.TryGetComponent(requestToBeControlledEntity, out var componentData) && componentData.controlledByEntity == Entity.Null)
			{
				if (!isPartialTick)
				{
					controlledByOtherEntityLookup.GetRefRW(requestToBeControlledEntity).ValueRW.controlledByEntity = entity;
				}
			}
			else if (componentData.controlledByEntity != entity)
			{
				playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
		}

		public static void ReleaseControlledEntity(Entity entity, RefRW<ControllingOtherEntityCD> controllingOtherEntityCD, ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup, ComponentLookup<Simulate> simulateLookup)
		{
			Entity controlledEntity = controllingOtherEntityCD.ValueRO.controlledEntity;
			controllingOtherEntityCD.ValueRW.controlledEntity = Entity.Null;
			if (controlledByOtherEntityLookup.TryGetComponent(controlledEntity, out var _) && simulateLookup.HasAndIsComponentEnabled(controlledEntity))
			{
				controlledByOtherEntityLookup.GetRefRW(controlledEntity).ValueRW.controlledByEntity = Entity.Null;
			}
		}
	}
}
