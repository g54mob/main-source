using System.Collections.Generic;
using Brewery.Items;
using InventorySystem;

namespace Brewery.Systems
{
	public class MetadataSnapshot
	{
		public Item Item { get; set; }

		public int Quantity { get; set; }

		public BarrelMetadata? BarrelMetadata { get; set; }

		public BeerDataSnapshot? BeverageMetadata { get; set; }

		public CrateMetadata? CrateMetadata { get; set; }

		public Dictionary<int, BeerDataSnapshot> CrateItemBeverageMetadata { get; set; }

		public Dictionary<int, BarrelMetadata> CrateItemBarrelMetadata { get; set; }

		public bool HasMetadata => false;

		public bool HasCrateItemMetadata => false;

		public bool IsEmpty => false;

		public bool IsCrateWithContents => false;

		public static MetadataSnapshot CreateEmpty()
		{
			return null;
		}

		public static MetadataSnapshot ForBarrel(Item item, int quantity, BarrelMetadata metadata)
		{
			return null;
		}

		public static MetadataSnapshot ForBeverage(Item item, int quantity, BeerDataSnapshot metadata)
		{
			return null;
		}

		public static MetadataSnapshot ForCrate(Item item, int quantity, CrateMetadata crateMetadata, Dictionary<int, BeerDataSnapshot> beverageItems = null, Dictionary<int, BarrelMetadata> barrelItems = null)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
