using Unity.Entities;

namespace Kitchen
{
	public struct CAttachedEffect : IComponentData
	{
		public Entity Parent;

		public int Source;
	}
}
