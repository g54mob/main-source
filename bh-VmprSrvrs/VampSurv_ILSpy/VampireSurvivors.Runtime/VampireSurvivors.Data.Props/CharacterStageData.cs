using System;

namespace VampireSurvivors.Data.Props;

[Serializable]
public class CharacterStageData
{
	private int _003Ccomplete_003Ek__BackingField;

	private bool _003Chyper_003Ek__BackingField;

	private bool _003Churry_003Ek__BackingField;

	private bool _003Cinverse_003Ek__BackingField;

	private int _003CsurvivedMinutes_003Ek__BackingField;

	private int _003CstartedRun_003Ek__BackingField;

	private StageType _003Ctype_003Ek__BackingField;

	public int complete
	{
		get
		{
			return _003Ccomplete_003Ek__BackingField;
		}
		set
		{
			_003Ccomplete_003Ek__BackingField = value;
		}
	}

	public bool hyper
	{
		get
		{
			return _003Chyper_003Ek__BackingField;
		}
		set
		{
			_003Chyper_003Ek__BackingField = value;
		}
	}

	public bool hurry
	{
		get
		{
			return _003Churry_003Ek__BackingField;
		}
		set
		{
			_003Churry_003Ek__BackingField = value;
		}
	}

	public bool inverse
	{
		get
		{
			return _003Cinverse_003Ek__BackingField;
		}
		set
		{
			_003Cinverse_003Ek__BackingField = value;
		}
	}

	public int survivedMinutes
	{
		get
		{
			return _003CsurvivedMinutes_003Ek__BackingField;
		}
		set
		{
			_003CsurvivedMinutes_003Ek__BackingField = value;
		}
	}

	public int startedRun
	{
		get
		{
			return _003CstartedRun_003Ek__BackingField;
		}
		set
		{
			_003CstartedRun_003Ek__BackingField = value;
		}
	}

	public StageType type
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
