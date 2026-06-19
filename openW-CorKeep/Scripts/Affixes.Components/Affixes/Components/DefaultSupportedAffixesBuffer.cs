using Unity.Entities;

namespace Affixes.Components
{
	public struct DefaultSupportedAffixesBuffer : IBufferElementData
	{
		public AffixID affixID;
	}
}
