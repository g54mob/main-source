using System.Runtime.CompilerServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct EntityStorageCache
	{
		private EntityStorageInfo storage;

		private Entity entity;

		private int lastWorldHash;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Update(World world, Entity entity, out EntityManager entityManager, out EntityStorageInfo storage)
		{
			entityManager = default(EntityManager);
			storage = default(EntityStorageInfo);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetComponentData<A>(World world, Entity entity, ref EntityAccess<A> access, out ComponentRef<A> value) where A : struct, IComponentData
		{
			value = default(ComponentRef<A>);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetComponentData<A>(World world, Entity entity, ref ManagedEntityAccess<A> access, out A value) where A : class, IComponentData
		{
			value = null;
			return false;
		}
	}
}
