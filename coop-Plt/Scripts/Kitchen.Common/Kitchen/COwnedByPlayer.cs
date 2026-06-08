using Unity.Entities;

namespace Kitchen
{
	public struct COwnedByPlayer : IComponentData
	{
		public Entity Player;
	}
}
