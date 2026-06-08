using Unity.Entities;

namespace Kitchen
{
	public struct CPlayersReadyToStart : IComponentData
	{
		public bool Ready;
	}
}
