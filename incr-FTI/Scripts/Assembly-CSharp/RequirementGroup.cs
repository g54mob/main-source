using System.Collections.Generic;

public class RequirementGroup : Requirement
{
	public readonly List<Requirement> requirements = new List<Requirement>();

	public void AddRequirement(Requirement r)
	{
		requirements.Add(r);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		foreach (Requirement requirement in requirements)
		{
			requirement.StoreItemStateCache(town);
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		foreach (Requirement requirement in requirements)
		{
			requirement.StoreItemStateCacheGlobal();
		}
	}

	public override bool IsMet()
	{
		if (GameManager.everythingUnlocked)
		{
			return true;
		}
		if (requirements.Count == 0)
		{
			return true;
		}
		foreach (Requirement requirement in requirements)
		{
			if (!requirement.IsMet())
			{
				return false;
			}
		}
		return true;
	}

	public override void Reset()
	{
		if (requirements == null)
		{
			return;
		}
		foreach (Requirement requirement in requirements)
		{
			requirement.Reset();
		}
	}
}
