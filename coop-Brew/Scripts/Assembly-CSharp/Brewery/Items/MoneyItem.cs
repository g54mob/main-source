using Brewery.Systems;
using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(menuName = "Brewery/Items/Money")]
	public class MoneyItem : BreweryItem
	{
		[Header("Money")]
		public MoneyConfig moneyConfig;

		private void OnEnable()
		{
		}

		public override int GetMaxStackSize(InventoryType inventoryType)
		{
			return 0;
		}
	}
}
