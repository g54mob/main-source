using Unity.Entities;

namespace Kitchen
{
	public struct CAvailableAssignment : IComponentData
	{
		public Entity Entity;

		public GroupState State;

		public int MaxCapacity;

		public float Attractiveness;

		public bool PrioritiseExactSize;

		public SystemReference System;

		public bool CanFit(CWaitingGroup group)
		{
			if (MaxCapacity >= 0)
			{
				return MaxCapacity >= group.MemberCount;
			}
			return true;
		}
	}
}
