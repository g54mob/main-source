using Unity.Entities;

namespace Kitchen
{
	public struct CGroupChoosingOrder : IGroupStatus, IComponentData
	{
		public bool HasSelectedCourse;

		public float RemainingTime;
	}
}
