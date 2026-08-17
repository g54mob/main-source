using System;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class PoolsMapping
{
	private int _003Ckey_003Ek__BackingField;

	private EnemyType _003Ctype_003Ek__BackingField;

	public int key
	{
		get
		{
			return _003Ckey_003Ek__BackingField;
		}
		set
		{
			_003Ckey_003Ek__BackingField = value;
		}
	}

	public EnemyType type
	{
		get
		{
			return _003Ctype_003Ek__BackingField;
		}
		set
		{
			_003Ctype_003Ek__BackingField = value;
		}
	}
}
