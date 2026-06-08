using Unity.Entities;

namespace Kitchen
{
	public struct CUpgrade : IComponentData
	{
		public int ID;

		public bool IsFromLevel;
	}
}
