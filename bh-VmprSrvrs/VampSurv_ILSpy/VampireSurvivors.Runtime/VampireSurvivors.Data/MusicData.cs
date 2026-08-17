using System;
using I2.Loc;
using UnityEngine;

namespace VampireSurvivors.Data;

[Serializable]
public class MusicData
{
	private string _003Ctitle_003Ek__BackingField;

	private string _003Cauthor_003Ek__BackingField;

	private string _003Csource_003Ek__BackingField;

	private StageType? _003CunlockedByStage_003Ek__BackingField;

	private CharacterType? _003CunlockedByCharacter_003Ek__BackingField;

	private ItemType? _003CunlockedByItem_003Ek__BackingField;

	private bool _003CisUnlocked_003Ek__BackingField;

	private string _003Cicon_003Ek__BackingField;

	private HyperMod _003ChyperMod_003Ek__BackingField;

	private ForsakenMod _003CforsakenMod_003Ek__BackingField;

	public string title
	{
		get
		{
			return _003Ctitle_003Ek__BackingField;
		}
		set
		{
			_003Ctitle_003Ek__BackingField = value;
		}
	}

	public string author
	{
		get
		{
			return _003Cauthor_003Ek__BackingField;
		}
		set
		{
			_003Cauthor_003Ek__BackingField = value;
		}
	}

	public string source
	{
		get
		{
			return _003Csource_003Ek__BackingField;
		}
		set
		{
			_003Csource_003Ek__BackingField = value;
		}
	}

	public StageType? unlockedByStage
	{
		get
		{
			return _003CunlockedByStage_003Ek__BackingField;
		}
		set
		{
			_003CunlockedByStage_003Ek__BackingField = value;
		}
	}

	public CharacterType? unlockedByCharacter
	{
		get
		{
			return _003CunlockedByCharacter_003Ek__BackingField;
		}
		set
		{
			_003CunlockedByCharacter_003Ek__BackingField = value;
		}
	}

	public ItemType? unlockedByItem
	{
		get
		{
			return _003CunlockedByItem_003Ek__BackingField;
		}
		set
		{
			_003CunlockedByItem_003Ek__BackingField = value;
		}
	}

	public bool isUnlocked
	{
		get
		{
			return _003CisUnlocked_003Ek__BackingField;
		}
		set
		{
			_003CisUnlocked_003Ek__BackingField = value;
		}
	}

	public string icon
	{
		get
		{
			return _003Cicon_003Ek__BackingField;
		}
		set
		{
			_003Cicon_003Ek__BackingField = value;
		}
	}

	public HyperMod hyperMod
	{
		get
		{
			return _003ChyperMod_003Ek__BackingField;
		}
		set
		{
			_003ChyperMod_003Ek__BackingField = value;
		}
	}

	public ForsakenMod forsakenMod
	{
		get
		{
			return _003CforsakenMod_003Ek__BackingField;
		}
		set
		{
			_003CforsakenMod_003Ek__BackingField = value;
		}
	}

	public unsafe string GetLocalizedTitle(BgmType t)
	{
		//IL_003f: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "musicLang/{" + text + "}title";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}
}
