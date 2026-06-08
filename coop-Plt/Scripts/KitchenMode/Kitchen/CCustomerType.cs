using Unity.Entities;

namespace Kitchen
{
	public struct CCustomerType : IComponentData
	{
		public int Type;

		public CCustomerType(int t)
		{
			Type = t;
		}
	}
}
