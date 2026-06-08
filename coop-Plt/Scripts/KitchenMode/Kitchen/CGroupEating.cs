using Unity.Entities;

namespace Kitchen
{
	public struct CGroupEating : IGroupStatus, IComponentData
	{
		public float RemainingTime;
	}
}
