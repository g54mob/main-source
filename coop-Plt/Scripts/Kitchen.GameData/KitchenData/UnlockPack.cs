using System.Collections.Generic;

namespace KitchenData
{
	public abstract class UnlockPack : GameDataObject
	{
		public abstract UnlockOptions GetOptions(HashSet<int> current_cards, UnlockRequest request);

		public virtual UnlockLabel GetLabel(HashSet<int> current_cards, UnlockRequest request)
		{
			UnlockOptions options = GetOptions(current_cards, request);
			if (options.Unlock1 == null)
			{
				return UnlockLabel.None;
			}
			current_cards.Add(options.Unlock1.ID);
			if (options.Unlock1.CardType == CardType.FranchiseTier)
			{
				return UnlockLabel.Franchise;
			}
			if (options.Unlock1.CardType == CardType.ThemeUnlock)
			{
				return UnlockLabel.Theme;
			}
			return UnlockLabel.Standard;
		}

		protected override void InitialiseDefaults()
		{
		}
	}
}
