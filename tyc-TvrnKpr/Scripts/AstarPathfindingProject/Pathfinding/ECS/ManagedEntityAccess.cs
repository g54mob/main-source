using System.Runtime.CompilerServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct ManagedEntityAccess<T> where T : class, IComponentData
	{
		private EntityManager entityManager;

		private ComponentTypeHandle<T> handle;

		private bool readOnly;

		public T this[EntityStorageInfo storage]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		public ManagedEntityAccess(bool readOnly)
		{
			entityManager = default(EntityManager);
			handle = default(ComponentTypeHandle<T>);
			this.readOnly = false;
		}

		public ManagedEntityAccess(EntityManager entityManager, bool readOnly)
		{
			this.entityManager = default(EntityManager);
			handle = default(ComponentTypeHandle<T>);
			this.readOnly = false;
		}

		public void Update(EntityManager entityManager)
		{
		}
	}
}
