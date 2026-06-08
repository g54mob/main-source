using Unity.Entities;

namespace Kitchen
{
	public struct CExpGrant : IComponentData
	{
		public int Amount;

		public int ExpIdentifier;

		public bool IsGranted;
	}
}
