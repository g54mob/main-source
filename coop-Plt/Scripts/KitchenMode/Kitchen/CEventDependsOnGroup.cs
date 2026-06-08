using Unity.Entities;

namespace Kitchen
{
	public struct CEventDependsOnGroup : IComponentData
	{
		public Entity Group;
	}
}
