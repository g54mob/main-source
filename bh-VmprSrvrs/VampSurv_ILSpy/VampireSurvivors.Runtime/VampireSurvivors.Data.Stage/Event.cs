using System;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class Event
{
	private string _003CeventType_003Ek__BackingField;

	private float _003Cdelay_003Ek__BackingField;

	private int _003Crepeat_003Ek__BackingField;

	private float? _003Cchance_003Ek__BackingField;

	private float? _003Cduration_003Ek__BackingField;

	private int _003CmoreX_003Ek__BackingField;

	private object _003CmoreY_003Ek__BackingField;

	private float _003CmoreZ_003Ek__BackingField;

	private int _003CminPlayersNeeded_003Ek__BackingField;

	public string eventType
	{
		get
		{
			return _003CeventType_003Ek__BackingField;
		}
		set
		{
			_003CeventType_003Ek__BackingField = value;
		}
	}

	public float delay
	{
		get
		{
			return _003Cdelay_003Ek__BackingField;
		}
		set
		{
			_003Cdelay_003Ek__BackingField = value;
		}
	}

	public int repeat
	{
		get
		{
			return _003Crepeat_003Ek__BackingField;
		}
		set
		{
			_003Crepeat_003Ek__BackingField = value;
		}
	}

	public float? chance
	{
		get
		{
			return _003Cchance_003Ek__BackingField;
		}
		set
		{
			_003Cchance_003Ek__BackingField = value;
		}
	}

	public float? duration
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

	public int moreX
	{
		get
		{
			return _003CmoreX_003Ek__BackingField;
		}
		set
		{
			_003CmoreX_003Ek__BackingField = value;
		}
	}

	public object moreY
	{
		get
		{
			return _003CmoreY_003Ek__BackingField;
		}
		set
		{
			_003CmoreY_003Ek__BackingField = value;
		}
	}

	public float moreZ
	{
		get
		{
			return _003CmoreZ_003Ek__BackingField;
		}
		set
		{
			_003CmoreZ_003Ek__BackingField = value;
		}
	}

	public int minPlayersNeeded
	{
		get
		{
			return _003CminPlayersNeeded_003Ek__BackingField;
		}
		set
		{
			_003CminPlayersNeeded_003Ek__BackingField = value;
		}
	}
}
