using Unity.Entities;

namespace Kitchen
{
	public struct CShowApplianceInfo : IComponentData
	{
		public int Appliance;

		public int Price;

		public bool ShowPrice;
	}
}
