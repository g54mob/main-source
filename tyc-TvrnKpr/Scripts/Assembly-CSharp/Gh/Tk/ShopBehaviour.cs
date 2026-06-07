using System.Collections.Generic;

namespace Gh.Tk
{
	public class ShopBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		private bool _impromptuChanceRolled;

		private static readonly int[] _impromptuChancesPerShopStarLevel;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<ShopItemTemplate> DesiredTemplates { get; private set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<ShopItemTemplate> HandledTemplates { get; set; }

		protected ShopBehaviour()
		{
		}

		public ShopBehaviour(Patron owner)
		{
		}

		public void MarkItemWasTooExpensive(ShopItemTemplate template)
		{
		}

		public void MarkItemAsFailed(ShopItemTemplate template)
		{
		}

		public void MarkItemAsNotAvailable(ShopItemTemplate template)
		{
		}

		public override void FirstInit()
		{
		}

		public static int GetImpromptuPurchaseChance()
		{
			return 0;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		internal void OnBuyItem(ShopItem item, int price)
		{
		}
	}
}
