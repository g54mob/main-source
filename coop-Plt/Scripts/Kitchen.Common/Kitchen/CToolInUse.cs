using Unity.Entities;

namespace Kitchen
{
	public struct CToolInUse : IComponentData
	{
		public Entity User;
	}
}
