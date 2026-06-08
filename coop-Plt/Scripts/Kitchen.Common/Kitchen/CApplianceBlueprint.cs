using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceBlueprint : IComponentData
	{
		public int Appliance;

		public bool IsCopy;
	}
}
