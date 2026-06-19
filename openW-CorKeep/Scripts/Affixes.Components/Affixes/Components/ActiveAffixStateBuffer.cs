using Unity.Entities;

namespace Affixes.Components
{
	public struct ActiveAffixStateBuffer : IBufferElementData
	{
		public AffixState state;

		public TickTimer cooldownTimer;
	}
}
