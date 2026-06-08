using Unity.Entities;

namespace Kitchen
{
	public struct CSubUpgrade : IComponentData
	{
		public int ID;

		public Entity Parent;
	}
}
