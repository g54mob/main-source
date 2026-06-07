using System;

public class BaseResearchAttribute : BaseSavableAttribute
{
	public BaseResearchAttribute(string name, Func<int> getCost, Func<bool> canHave)
	{
		_name = name;
		_getCostAction = getCost;
		_canHaveAction = canHave;
	}

	public int GetCost()
	{
		return _getCostAction();
	}

	public bool CanDisplay()
	{
		if (!_canHaveAction())
		{
			return false;
		}
		return true;
	}

	public bool CanEnable()
	{
		if (base.IsEnabled)
		{
			return false;
		}
		if (!_canHaveAction())
		{
			return false;
		}
		if (GetCost() <= GameController.Instance.ResearchPoint.Amount)
		{
			return true;
		}
		return false;
	}

	public bool TryToEnable()
	{
		if (!CanEnable())
		{
			return false;
		}
		GameController.Instance.GainRP(-GetCost());
		_level = 1;
		return true;
	}

	public override bool TryLevelUp()
	{
		return TryToEnable();
	}
}
