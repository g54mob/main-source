using System.Collections.Generic;

namespace Gh.Tk
{
	public class ShopShelf : Larder_Tile
	{
		public static HashSet<ShopShelf> AllShopShelfs;

		public static bool IsItemCurrentlySold(string templateId)
		{
			return false;
		}

		public override void Start()
		{
		}

		protected override void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnItemAddedOrRemoved(object sender, GameItemEventArgs e)
		{
		}

		private void ChangeTavernMenuIfNeeded(string itemId)
		{
		}

		public override void OnDestroy()
		{
		}

		public bool IsOnDisplay(string itemKey)
		{
			return false;
		}

		public override void SetAcceptedItemAtSlot(GameItemTemplate template, int slot)
		{
		}
	}
}
