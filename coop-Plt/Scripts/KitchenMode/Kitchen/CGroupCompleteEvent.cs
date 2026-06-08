using Unity.Entities;

namespace Kitchen
{
	public struct CGroupCompleteEvent : IComponentData
	{
		public Entity Group;

		public bool IsFailure;
	}
}
