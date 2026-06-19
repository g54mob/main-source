using Unity.Entities;
using Unity.NetCode;

namespace SiphonMana.Components
{
	[InternalBufferCapacity(1)]
	public struct SiphonManaTargetBufferElement : IBufferElementData
	{
		public const int MaxSiphonTargets = 1;

		[GhostField]
		public Entity siphonManaTarget;
	}
}
