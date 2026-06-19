using Unity.Entities;

namespace Interaction
{
	public struct ToggleInteractionOnVariationCD : IComponentData, IQueryTypeParameter
	{
		public ToggleInteractionByVariationType toggleType;

		public int variation;
	}
}
