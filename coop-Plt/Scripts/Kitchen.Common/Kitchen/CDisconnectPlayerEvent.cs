using Unity.Entities;

namespace Kitchen
{
	public struct CDisconnectPlayerEvent : IComponentData
	{
		public Entity Player;
	}
}
