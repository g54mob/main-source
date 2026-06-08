using Unity.Entities;

namespace Kitchen
{
	public struct CManualOrder : IComponentData
	{
		public int Index;

		public int Day;
	}
}
