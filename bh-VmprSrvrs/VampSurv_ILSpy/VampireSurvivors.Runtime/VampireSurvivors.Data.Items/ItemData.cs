using System;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;

namespace VampireSurvivors.Data.Items;

[Serializable]
public class ItemData
{
	private string _003Cname_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private string _003CachievementTips_003Ek__BackingField;

	private string _003Ctips_003Ek__BackingField;

	private string _003Ctexture_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private int _003CpickedupAmount_003Ek__BackingField;

	private float _003Crarity_003Ek__BackingField;

	private int _003CunlocksAt_003Ek__BackingField;

	private float _003Cvalue_003Ek__BackingField;

	private bool _003CinTreasures_003Ek__BackingField;

	private bool _003Cseen_003Ek__BackingField;

	private bool _003CisRare_003Ek__BackingField;

	private bool _003CisRelic_003Ek__BackingField;

	private bool _003CisUnlocked_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private int _003CfeverMS_003Ek__BackingField;

	private bool _003CisSpecialOption_003Ek__BackingField;

	private bool _003Csealable_003Ek__BackingField;

	private DlcType? _003CrequiresDLC_003Ek__BackingField;

	private ItemType? _003CrequiresItem_003Ek__BackingField;

	private ArcanaType? _003CrequiresArcana_003Ek__BackingField;

	private string _003CcollectionFrame_003Ek__BackingField;

	private bool _003CshowAboveAll_003Ek__BackingField;

	private bool _003CexcludeFromDefaultLootTable_003Ek__BackingField;

	private bool _003CignoreForcedMovement_003Ek__BackingField;

	private ContentGroupType _003CcontentGroup_003Ek__BackingField;

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

	public string achievementTips
	{
		get
		{
			return _003CachievementTips_003Ek__BackingField;
		}
		set
		{
			_003CachievementTips_003Ek__BackingField = value;
		}
	}

	public string tips
	{
		get
		{
			return _003Ctips_003Ek__BackingField;
		}
		set
		{
			_003Ctips_003Ek__BackingField = value;
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

	public int pickedupAmount
	{
		get
		{
			return _003CpickedupAmount_003Ek__BackingField;
		}
		set
		{
			_003CpickedupAmount_003Ek__BackingField = value;
		}
	}

	public float rarity
	{
		get
		{
			return _003Crarity_003Ek__BackingField;
		}
		set
		{
			_003Crarity_003Ek__BackingField = value;
		}
	}

	public int unlocksAt
	{
		get
		{
			return _003CunlocksAt_003Ek__BackingField;
		}
		set
		{
			_003CunlocksAt_003Ek__BackingField = value;
		}
	}

	public float value
	{
		get
		{
			return _003Cvalue_003Ek__BackingField;
		}
		set
		{
			_003Cvalue_003Ek__BackingField = value;
		}
	}

	public bool inTreasures
	{
		get
		{
			return _003CinTreasures_003Ek__BackingField;
		}
		set
		{
			_003CinTreasures_003Ek__BackingField = value;
		}
	}

	public bool seen
	{
		get
		{
			return _003Cseen_003Ek__BackingField;
		}
		set
		{
			_003Cseen_003Ek__BackingField = value;
		}
	}

	public bool isRare
	{
		get
		{
			return _003CisRare_003Ek__BackingField;
		}
		set
		{
			_003CisRare_003Ek__BackingField = value;
		}
	}

	public bool isRelic
	{
		get
		{
			return _003CisRelic_003Ek__BackingField;
		}
		set
		{
			_003CisRelic_003Ek__BackingField = value;
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

	public int feverMS
	{
		get
		{
			return _003CfeverMS_003Ek__BackingField;
		}
		set
		{
			_003CfeverMS_003Ek__BackingField = value;
		}
	}

	public bool isSpecialOption
	{
		get
		{
			return _003CisSpecialOption_003Ek__BackingField;
		}
		set
		{
			_003CisSpecialOption_003Ek__BackingField = value;
		}
	}

	public bool sealable
	{
		get
		{
			return _003Csealable_003Ek__BackingField;
		}
		set
		{
			_003Csealable_003Ek__BackingField = value;
		}
	}

	public DlcType? requiresDLC
	{
		get
		{
			return _003CrequiresDLC_003Ek__BackingField;
		}
		set
		{
			_003CrequiresDLC_003Ek__BackingField = value;
		}
	}

	public ItemType? requiresItem
	{
		get
		{
			return _003CrequiresItem_003Ek__BackingField;
		}
		set
		{
			_003CrequiresItem_003Ek__BackingField = value;
		}
	}

	public ArcanaType? requiresArcana
	{
		get
		{
			return _003CrequiresArcana_003Ek__BackingField;
		}
		set
		{
			_003CrequiresArcana_003Ek__BackingField = value;
		}
	}

	public string collectionFrame
	{
		get
		{
			return _003CcollectionFrame_003Ek__BackingField;
		}
		set
		{
			_003CcollectionFrame_003Ek__BackingField = value;
		}
	}

	public bool showAboveAll
	{
		get
		{
			return _003CshowAboveAll_003Ek__BackingField;
		}
		set
		{
			_003CshowAboveAll_003Ek__BackingField = value;
		}
	}

	public bool excludeFromDefaultLootTable
	{
		get
		{
			return _003CexcludeFromDefaultLootTable_003Ek__BackingField;
		}
		set
		{
			_003CexcludeFromDefaultLootTable_003Ek__BackingField = value;
		}
	}

	public bool ignoreForcedMovement
	{
		get
		{
			return _003CignoreForcedMovement_003Ek__BackingField;
		}
		set
		{
			_003CignoreForcedMovement_003Ek__BackingField = value;
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

	public unsafe string GetLocalizedDescription(ItemType type)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Ref, but got Unknown
		//IL_012f: Expected I8, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Ref, but got Unknown
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "description";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string result;
		if (translation != null)
		{
			string text = translation.Replace("\\n", "<br>");
			object obj = "";
			if ((object)text == "")
			{
				goto IL_0174;
			}
			bool flag = text == null;
			result = text;
			if (!flag)
			{
				bool flag2 = "" == null;
				result = text;
				if (!flag2)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v5+10]");
					bool flag3 = (nint)stringLength != 0;
					result = text;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						result = text;
						if (!flag5)
						{
							goto IL_0174;
						}
					}
				}
			}
			goto IL_01b6;
		}
		return (string)(object)new NullReferenceException();
		IL_01b6:
		return result;
		IL_0174:
		result = _003Cdescription_003Ek__BackingField;
		goto IL_01b6;
	}

	public unsafe string GetLocalizedTips(ItemType type)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Ref, but got Unknown
		//IL_012f: Expected I8, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Ref, but got Unknown
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "tips";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string result;
		if (translation != null)
		{
			string text = translation.Replace("\\n", "<br>");
			object obj = "";
			if ((object)text == "")
			{
				goto IL_0174;
			}
			bool flag = text == null;
			result = text;
			if (!flag)
			{
				bool flag2 = "" == null;
				result = text;
				if (!flag2)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v5+10]");
					bool flag3 = (nint)stringLength != 0;
					result = text;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						result = text;
						if (!flag5)
						{
							goto IL_0174;
						}
					}
				}
			}
			goto IL_01b6;
		}
		return (string)(object)new NullReferenceException();
		IL_01b6:
		return result;
		IL_0174:
		result = _003Ctips_003Ek__BackingField;
		goto IL_01b6;
	}

	public unsafe string GetLocalizedName(ItemType type)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Ref, but got Unknown
		//IL_012f: Expected I8, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Ref, but got Unknown
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string result;
		if (translation != null)
		{
			string text = translation.Replace("\\n", "<br>");
			object obj = "";
			if ((object)text == "")
			{
				goto IL_0174;
			}
			bool flag = text == null;
			result = text;
			if (!flag)
			{
				bool flag2 = "" == null;
				result = text;
				if (!flag2)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v5+10]");
					bool flag3 = (nint)stringLength != 0;
					result = text;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						result = text;
						if (!flag5)
						{
							goto IL_0174;
						}
					}
				}
			}
			goto IL_01b6;
		}
		return (string)(object)new NullReferenceException();
		IL_01b6:
		return result;
		IL_0174:
		result = _003Cname_003Ek__BackingField;
		goto IL_01b6;
	}

	public unsafe string GetLocalizedAchievementTips(ItemType type)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Ref, but got Unknown
		//IL_012f: Expected I8, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Ref, but got Unknown
		string localPrefix = GetLocalPrefix(type);
		string term = localPrefix + "achievementTips";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string result;
		if (translation != null)
		{
			string text = translation.Replace("\\n", "<br>");
			object obj = "";
			if ((object)text == "")
			{
				goto IL_0174;
			}
			bool flag = text == null;
			result = text;
			if (!flag)
			{
				bool flag2 = "" == null;
				result = text;
				if (!flag2)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v5+10]");
					bool flag3 = (nint)stringLength != 0;
					result = text;
					if (!flag3)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
						bool flag5 = !flag4;
						result = text;
						if (!flag5)
						{
							goto IL_0174;
						}
					}
				}
			}
			goto IL_01b6;
		}
		return (string)(object)new NullReferenceException();
		IL_01b6:
		return result;
		IL_0174:
		result = _003CachievementTips_003Ek__BackingField;
		goto IL_01b6;
	}

	public unsafe string GetLocalPrefix(ItemType t)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "itemLang/{" + text + "}";
	}
}
