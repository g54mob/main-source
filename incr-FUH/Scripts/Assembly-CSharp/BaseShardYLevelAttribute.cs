using System;

public class BaseShardYLevelAttribute : BaseSavableAttribute
{
	protected Func<int, int> _getLevelCostAction;

	public BaseShardYLevelAttribute(string name, int maxLevel, Func<int, int> getCost, Func<bool> canHave)
	{
		_name = name;
		_maxLevel = maxLevel;
		_getLevelCostAction = getCost;
		_canHaveAction = canHave;
	}

	public int GetCost()
	{
		return _getLevelCostAction(base.Level);
	}

	public bool CanDisplay()
	{
		if (!_canHaveAction())
		{
			return false;
		}
		return true;
	}

	public bool CanLevel()
	{
		if (base.Level >= _maxLevel)
		{
			return false;
		}
		if (!_canHaveAction())
		{
			return false;
		}
		if (GetCost() <= GameController.Instance.YellowPoint.Amount)
		{
			return true;
		}
		return false;
	}

	public bool TryToEnable()
	{
		if (!CanLevel())
		{
			return false;
		}
		GameController.Instance.GainYellowPoint(-GetCost());
		_level++;
		return true;
	}

	public override bool TryLevelUp()
	{
		return TryToEnable();
	}
}
