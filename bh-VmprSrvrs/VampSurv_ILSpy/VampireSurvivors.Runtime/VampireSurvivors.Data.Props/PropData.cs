using System;

namespace VampireSurvivors.Data.Props;

[Serializable]
public class PropData
{
	private string _003CtextureName_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private int _003CdestroyedAmount_003Ek__BackingField;

	private float _003CmaxHp_003Ek__BackingField;

	private string _003CdestructibleType_003Ek__BackingField;

	public string textureName
	{
		get
		{
			return _003CtextureName_003Ek__BackingField;
		}
		set
		{
			_003CtextureName_003Ek__BackingField = value;
		}
	}

	public string frameName
	{
		get
		{
			return _003CframeName_003Ek__BackingField;
		}
		set
		{
			_003CframeName_003Ek__BackingField = value;
		}
	}

	public int destroyedAmount
	{
		get
		{
			return _003CdestroyedAmount_003Ek__BackingField;
		}
		set
		{
			_003CdestroyedAmount_003Ek__BackingField = value;
		}
	}

	public float maxHp
	{
		get
		{
			return _003CmaxHp_003Ek__BackingField;
		}
		set
		{
			_003CmaxHp_003Ek__BackingField = value;
		}
	}

	public string destructibleType
	{
		get
		{
			return _003CdestructibleType_003Ek__BackingField;
		}
		set
		{
			_003CdestructibleType_003Ek__BackingField = value;
		}
	}
}
