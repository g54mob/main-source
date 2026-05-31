using System;

public class BaseMoneyLevelAttribute : BaseSavableAttribute
{
	protected Func<int, int> _getLevelCostAction;

	public BaseMoneyLevelAttribute(string name, int maxLevel, Func<int, int> getCost, Func<bool> canHave)
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
		if (GetCost() <= GameController.Instance.Money.Amount)
		{
			return true;
		}
		return false;
	}

	public bool TryToEnable(BaseBuilding building)
	{
		if (!CanLevel())
		{
			return false;
		}
		int num = GetCost();
		if (building != null)
		{
			num = building.ReduceWithTrainingPeon(num);
		}
		GameController.Instance.GainMoney(-num);
		_level++;
		return true;
	}

	public override bool TryLevelUp()
	{
		return TryToEnable(null);
	}
}
