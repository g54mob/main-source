using Unity.Entities;

namespace Kitchen
{
	public struct CToolUser : IComponentData
	{
		public Entity CurrentTool;
	}
}
