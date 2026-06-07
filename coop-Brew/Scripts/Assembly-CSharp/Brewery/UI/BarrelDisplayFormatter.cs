using Brewery.Items;
using InventorySystem;

namespace Brewery.UI
{
	public static class BarrelDisplayFormatter
	{
		public static string BuildDisplayName(BarrelMetadata metadata)
		{
			return null;
		}

		public static string BuildDescription(BarrelMetadata metadata, InventorySlot slot)
		{
			return null;
		}

		public static string GetContentLabel(BarrelMetadata metadata)
		{
			return null;
		}

		private static string GetContentLabel(BarrelMetadata metadata, out bool isEmpty)
		{
			isEmpty = default(bool);
			return null;
		}

		private static string FormatTimeRemaining(float seconds)
		{
			return null;
		}
	}
}
