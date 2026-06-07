using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Items
{
	public class PickupMerchantAdventure : PickupCustomMerchant
	{
		protected override MerchantInventoryType GetInventoryType()
		{
			return default(MerchantInventoryType);
		}

		public override bool IsMerchantSoldOut()
		{
			return false;
		}
	}
}
