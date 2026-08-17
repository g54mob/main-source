using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Data.PowerUp;

[Serializable]
public class PowerUpData
{
	private int _003Clevel_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private string _003CbulletType_003Ek__BackingField;

	private string _003Cname_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private string _003Ctexture_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private bool _003CisPowerUp_003Ek__BackingField;

	private bool _003CisAnUnlockable_003Ek__BackingField;

	private int _003Cprice_003Ek__BackingField;

	private int _003CunlockedRank_003Ek__BackingField;

	private bool _003CisSpecial_003Ek__BackingField;

	private bool _003CspecialBG_003Ek__BackingField;

	public int level
	{
		get
		{
			return _003Clevel_003Ek__BackingField;
		}
		set
		{
			_003Clevel_003Ek__BackingField = value;
		}
	}

	public bool hidden
	{
		get
		{
			return _003Chidden_003Ek__BackingField;
		}
		set
		{
			_003Chidden_003Ek__BackingField = value;
		}
	}

	public string bulletType
	{
		get
		{
			return _003CbulletType_003Ek__BackingField;
		}
		set
		{
			_003CbulletType_003Ek__BackingField = value;
		}
	}

	public string name
	{
		get
		{
			return _003Cname_003Ek__BackingField;
		}
		set
		{
			_003Cname_003Ek__BackingField = value;
		}
	}

	public string description
	{
		get
		{
			return _003Cdescription_003Ek__BackingField;
		}
		set
		{
			_003Cdescription_003Ek__BackingField = value;
		}
	}

	public string texture
	{
		get
		{
			return _003Ctexture_003Ek__BackingField;
		}
		set
		{
			_003Ctexture_003Ek__BackingField = value;
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

	public bool isPowerUp
	{
		get
		{
			return _003CisPowerUp_003Ek__BackingField;
		}
		set
		{
			_003CisPowerUp_003Ek__BackingField = value;
		}
	}

	public bool isAnUnlockable
	{
		get
		{
			return _003CisAnUnlockable_003Ek__BackingField;
		}
		set
		{
			_003CisAnUnlockable_003Ek__BackingField = value;
		}
	}

	public int price
	{
		get
		{
			return _003Cprice_003Ek__BackingField;
		}
		set
		{
			_003Cprice_003Ek__BackingField = value;
		}
	}

	public int unlockedRank
	{
		get
		{
			return _003CunlockedRank_003Ek__BackingField;
		}
		set
		{
			_003CunlockedRank_003Ek__BackingField = value;
		}
	}

	public bool isSpecial
	{
		get
		{
			return _003CisSpecial_003Ek__BackingField;
		}
		set
		{
			_003CisSpecial_003Ek__BackingField = value;
		}
	}

	public bool specialBG
	{
		get
		{
			return _003CspecialBG_003Ek__BackingField;
		}
		set
		{
			_003CspecialBG_003Ek__BackingField = value;
		}
	}

	private unsafe string GetPrefix(PowerUpType type)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "powerUpLang/{" + text + "}";
	}

	public string GetLocalizedName(PowerUpType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(type);
		return prefix + "name";
	}

	public string GetLocalizedDescription(PowerUpType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(type);
		return prefix + "description";
	}
}
