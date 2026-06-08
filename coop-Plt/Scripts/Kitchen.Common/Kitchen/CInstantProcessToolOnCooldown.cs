using Unity.Entities;

namespace Kitchen
{
	public struct CInstantProcessToolOnCooldown : IComponentData
	{
		public float ProgressSeconds;
	}
}
