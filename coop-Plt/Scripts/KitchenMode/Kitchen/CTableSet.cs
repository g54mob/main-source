using Unity.Entities;

namespace Kitchen
{
	public struct CTableSet : IComponentData
	{
		public bool IsWaitingTable;

		public int ChairCount;
	}
}
