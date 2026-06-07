using System;

[Serializable]
public class ResearchTreeDataUnit
{
	public eResearchTreeId id;

	public bool isHave;

	public bool isUnlock;

	public bool isFreeUnlock;

	public int purchaseCount;

	private MstResearchTreeDataEntities _entity;

	public MstResearchTreeDataEntities Entity => null;

	public bool IsHave()
	{
		return false;
	}

	public ResearchTreeDataUnit(eResearchTreeId id)
	{
	}
}
