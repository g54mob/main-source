using Unity.Entities;

namespace Kitchen
{
	public struct CCompletedProcess : IComponentData
	{
		public int Process;

		public int Item;

		public bool IsBad;
	}
}
