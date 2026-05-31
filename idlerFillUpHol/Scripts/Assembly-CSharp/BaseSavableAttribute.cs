using System;

public class BaseSavableAttribute
{
	protected int _maxLevel = 1;

	protected string _name = "";

	protected int _level;

	protected Func<int> _getCostAction;

	protected Func<bool> _canHaveAction;

	public string Name => _name;

	public bool IsEnabled => _level > 0;

	public int Level => _level;

	public bool IsMax
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

	public int GetMaxLevel()
	{
		return _maxLevel;
	}

	public void ForceLevel(int newLevel)
	{
		_level = newLevel;
	}

	public void Reset()
	{
		_level = 0;
	}

	public virtual bool TryLevelUp()
	{
		return false;
	}
}
