namespace Kitchen
{
	public class SwapOutfit : ItemInteractionSystem
	{
		private COutfitSelector Selector;

		private CPlayerCosmetics Cosmetics;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<COutfitSelector>(data.Target, out Selector))
			{
				return false;
			}
			if (HasComponent<COwnedByPlayer>(data.Target) && GetComponent<COwnedByPlayer>(data.Target).Player != data.Interactor)
			{
				return false;
			}
			if (!Require<CPlayerCosmetics>(data.Interactor, out Cosmetics))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Selector.OutfitID = Selector.Next().OutfitID;
			SetComponent(data.Target, Selector);
			Cosmetics.OutfitID = Selector.OutfitID;
			SetComponent(data.Interactor, Cosmetics);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
