using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loot
{
	public class WeightedItem
	{
		private ItemType _itemType;

		private float _weight;

		public ItemType ItemType => default(ItemType);

		public float Weight => 0f;

		public WeightedItem(ItemType itemType, float weight)
		{
		}
	}
}
