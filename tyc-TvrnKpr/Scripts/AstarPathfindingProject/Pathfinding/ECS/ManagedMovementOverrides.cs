using System;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct ManagedMovementOverrides
	{
		private Entity entity;

		private World world;

		public ManagedMovementOverrides(Entity entity, World world)
		{
			this.entity = default(Entity);
			this.world = null;
		}

		public void AddBeforeControlCallback(BeforeControlDelegate value)
		{
		}

		public void RemoveBeforeControlCallback(BeforeControlDelegate value)
		{
		}

		public void AddAfterControlCallback(AfterControlDelegate value)
		{
		}

		public void RemoveAfterControlCallback(AfterControlDelegate value)
		{
		}

		public void AddBeforeMovementCallback(BeforeMovementDelegate value)
		{
		}

		public void RemoveBeforeMovementCallback(BeforeMovementDelegate value)
		{
		}

		private void AddCallback<C, T>(T callback) where C : ManagedMovementOverride<T>, IComponentData, new() where T : Delegate
		{
		}

		private void RemoveCallback<C, T>(T callback) where C : ManagedMovementOverride<T>, IComponentData, new() where T : Delegate
		{
		}
	}
}
