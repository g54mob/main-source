using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace VampireSurvivors.Data;

[Serializable]
public class ArcanaData
{
	private int _003CarcanaType_003Ek__BackingField;

	private string _003Cname_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private List<object> _003Cweapons_003Ek__BackingField;

	private List<object> _003Citems_003Ek__BackingField;

	private string _003Ctexture_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private bool _003Cenabled_003Ek__BackingField;

	private bool _003Cunlocked_003Ek__BackingField;

	private bool _003Cmajor_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private int _003Cstars_003Ek__BackingField;

	private ContentGroupType _003CcontentGroup_003Ek__BackingField;

	public int arcanaType
	{
		get
		{
			return _003CarcanaType_003Ek__BackingField;
		}
		set
		{
			_003CarcanaType_003Ek__BackingField = value;
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

	public List<object> weapons
	{
		get
		{
			return _003Cweapons_003Ek__BackingField;
		}
		set
		{
			_003Cweapons_003Ek__BackingField = value;
		}
	}

	public List<object> items
	{
		get
		{
			return _003Citems_003Ek__BackingField;
		}
		set
		{
			_003Citems_003Ek__BackingField = value;
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

	public bool enabled
	{
		get
		{
			return _003Cenabled_003Ek__BackingField;
		}
		set
		{
			_003Cenabled_003Ek__BackingField = value;
		}
	}

	public bool unlocked
	{
		get
		{
			return _003Cunlocked_003Ek__BackingField;
		}
		set
		{
			_003Cunlocked_003Ek__BackingField = value;
		}
	}

	public bool major
	{
		get
		{
			return _003Cmajor_003Ek__BackingField;
		}
		set
		{
			_003Cmajor_003Ek__BackingField = value;
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

	public bool alwaysHidden
	{
		get
		{
			return _003CalwaysHidden_003Ek__BackingField;
		}
		set
		{
			_003CalwaysHidden_003Ek__BackingField = value;
		}
	}

	public int stars
	{
		get
		{
			return _003Cstars_003Ek__BackingField;
		}
		set
		{
			_003Cstars_003Ek__BackingField = value;
		}
	}

	public ContentGroupType contentGroup
	{
		get
		{
			return _003CcontentGroup_003Ek__BackingField;
		}
		set
		{
			_003CcontentGroup_003Ek__BackingField = value;
		}
	}

	public string GetLocalizedNameTerm(ArcanaType t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C17]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(t);
		return localPrefix + "name";
	}

	public string GetLocalizedDescriptionTerm(ArcanaType t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C18]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = GetLocalPrefix(t);
		return localPrefix + "description";
	}

	public unsafe string GetLocalPrefix(ArcanaType t)
	{
		//IL_0046: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C19]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		string text = System.Number.FormatInt32((int)t, (ReadOnlySpan<char>)(&obj), null);
		return "arcanaLang/{" + text + "}";
	}
}
