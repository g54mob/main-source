using System;

public class BaseTrainingAttribute : BaseSavableAttribute
{
	private new int _maxLevel = 1;

	public int Amount;

	protected Func<int, int> _getLevelCostAction;

	public new bool IsMax
	{
		get
		{
			if (_level >= _maxLevel)
			{
				return true;
			}
			return false;
		}
	}

	public BaseTrainingAttribute(string name, int maxLevel, Func<int, int> getCost, Func<bool> canHave)
	{
		_name = name;
		_maxLevel = maxLevel;
		_getLevelCostAction = getCost;
		_canHaveAction = canHave;
	}

	public new int GetMaxLevel()
	{
		return _maxLevel;
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

	public bool CanLevelUp()
	{
		if (base.Level >= _maxLevel)
		{
			return false;
		}
		if (!_canHaveAction())
		{
			return false;
		}
		if (GetCost() <= Amount)
		{
			return true;
		}
		return false;
	}

	public override bool TryLevelUp()
	{
		if (!CanLevelUp())
		{
			return false;
		}
		Amount -= GetCost();
		_level++;
		return true;
	}
}
