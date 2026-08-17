using System;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class MeleeAttack
{
	private string _003CtextureName_003Ek__BackingField;

	private string _003CspriteName_003Ek__BackingField;

	private int _003CframesNumber_003Ek__BackingField;

	private int _003CframeRate_003Ek__BackingField;

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

	public string spriteName
	{
		get
		{
			return _003CspriteName_003Ek__BackingField;
		}
		set
		{
			_003CspriteName_003Ek__BackingField = value;
		}
	}

	public int framesNumber
	{
		get
		{
			return _003CframesNumber_003Ek__BackingField;
		}
		set
		{
			_003CframesNumber_003Ek__BackingField = value;
		}
	}

	public int frameRate
	{
		get
		{
			return _003CframeRate_003Ek__BackingField;
		}
		set
		{
			_003CframeRate_003Ek__BackingField = value;
		}
	}
}
