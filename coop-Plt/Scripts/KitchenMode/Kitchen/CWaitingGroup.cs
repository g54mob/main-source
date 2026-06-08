using Unity.Entities;

namespace Kitchen
{
	public struct CWaitingGroup : IComponentData
	{
		public Entity Group;

		public int MemberCount;

		public GroupState State;

		public float PatienceRemaining;

		public bool IsUrgent;

		public Entity ForceLocation;

		public SystemReference System;

		public bool WillMoveTo(CAvailableAssignment location)
		{
			if (State < location.State)
			{
				if (!(ForceLocation == default(Entity)))
				{
					return ForceLocation == location.Entity;
				}
				return true;
			}
			return false;
		}

		public static implicit operator Entity(CWaitingGroup wg)
		{
			return wg.Group;
		}
	}
}
