using Unity.Entities;

namespace Kitchen
{
	public struct CScheduledCustomer : IComponentData
	{
		public float TimeOfDay;

		public int GroupSize;

		public bool IsCat;
	}
}
