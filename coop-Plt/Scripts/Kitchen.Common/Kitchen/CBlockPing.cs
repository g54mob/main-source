using Unity.Entities;

namespace Kitchen
{
	public struct CBlockPing : IComponentData
	{
		public bool IsEnablingCraneMode;

		public bool PreventPing => IsEnablingCraneMode;
	}
}
