using System.Runtime.CompilerServices;
using Unity.Entities;

namespace Pathfinding.ECS
{
	public struct EntityAccess<T> where T : struct, IComponentData
	{
		public ComponentTypeHandle<T> handle;

		private uint lastSystemVersion;

		private ulong worldSequenceNumber;

		private bool readOnly;

		public ref T this[EntityStorageInfo storage]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				throw null;
			}
		}

		public EntityAccess(bool readOnly)
		{
			handle = default(ComponentTypeHandle<T>);
			lastSystemVersion = 0u;
			worldSequenceNumber = 0uL;
			this.readOnly = false;
		}

		public void Update(EntityManager entityManager)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasComponent(EntityStorageInfo storage)
		{
			return false;
		}
	}
}
