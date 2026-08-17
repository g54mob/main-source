using System;

namespace VampireSurvivors.Data;

[Serializable]
public class HitVfxData
{
	private bool _003CisTintFill_003Ek__BackingField;

	private int _003CtargetTint_003Ek__BackingField;

	private string _003ChitFrameName_003Ek__BackingField;

	private string _003CimpactFrameName_003Ek__BackingField;

	private int _003Cduration_003Ek__BackingField;

	public bool isTintFill
	{
		get
		{
			return _003CisTintFill_003Ek__BackingField;
		}
		set
		{
			_003CisTintFill_003Ek__BackingField = value;
		}
	}

	public int targetTint
	{
		get
		{
			return _003CtargetTint_003Ek__BackingField;
		}
		set
		{
			_003CtargetTint_003Ek__BackingField = value;
		}
	}

	public string hitFrameName
	{
		get
		{
			return _003ChitFrameName_003Ek__BackingField;
		}
		set
		{
			_003ChitFrameName_003Ek__BackingField = value;
		}
	}

	public string impactFrameName
	{
		get
		{
			return _003CimpactFrameName_003Ek__BackingField;
		}
		set
		{
			_003CimpactFrameName_003Ek__BackingField = value;
		}
	}

	public int duration
	{
		get
		{
			return _003Cduration_003Ek__BackingField;
		}
		set
		{
			_003Cduration_003Ek__BackingField = value;
		}
	}
}
