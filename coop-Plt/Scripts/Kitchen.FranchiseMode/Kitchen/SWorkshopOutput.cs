using Unity.Entities;

namespace Kitchen
{
	public struct SWorkshopOutput : IComponentData
	{
		public bool IsReady;

		public int OutputAppliance;

		public int Nonce;
	}
}
