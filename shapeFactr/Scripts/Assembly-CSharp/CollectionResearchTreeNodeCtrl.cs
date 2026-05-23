public class CollectionResearchTreeNodeCtrl : ResearchTreeNodeCtrl
{
	protected override bool isOkPurchase(ResearchTreeDataUnit data)
	{
		return false;
	}

	protected override string GetPriceText()
	{
		return null;
	}

	protected override (MstResearchTreeDataEntities, ResearchTreeDataUnit) GetActiveResearchData()
	{
		return default((MstResearchTreeDataEntities, ResearchTreeDataUnit));
	}
}
