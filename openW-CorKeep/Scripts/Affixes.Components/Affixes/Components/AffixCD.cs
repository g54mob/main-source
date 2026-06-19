using Unity.Entities;
using Unity.NetCode;

namespace Affixes.Components
{
	public struct AffixCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public bool dispalyConnectionToOwner;
	}
}
