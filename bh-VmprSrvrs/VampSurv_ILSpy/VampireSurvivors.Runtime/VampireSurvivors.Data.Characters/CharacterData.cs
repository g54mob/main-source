using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class CharacterData
{
	private bool _003CallowCoopOutline_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private bool _003Csecret_003Ek__BackingField;

	private bool _003ChideWeaponIcon_003Ek__BackingField;

	private int _003Clevel_003Ek__BackingField;

	private WeaponType? _003CstartingWeapon_003Ek__BackingField;

	private float _003Ccooldown_003Ek__BackingField;

	private string _003Cprefix_003Ek__BackingField;

	private string _003CcharName_003Ek__BackingField;

	private string _003Csurname_003Ek__BackingField;

	private string _003CtextureName_003Ek__BackingField;

	private string _003CspriteName_003Ek__BackingField;

	private string _003CcharSelTexture_003Ek__BackingField;

	private string _003CcharSelFrame_003Ek__BackingField;

	private string _003CportraitName_003Ek__BackingField;

	private int _003CwalkingFrames_003Ek__BackingField;

	private List<Vector2> _003CheadOffsets_003Ek__BackingField;

	private List<Skin> _003Cskins_003Ek__BackingField;

	private int? _003CwalkFrameRate_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private float _003Cprice_003Ek__BackingField;

	private float _003CmaxHp_003Ek__BackingField;

	private float _003Carmor_003Ek__BackingField;

	private float _003Cregen_003Ek__BackingField;

	private float _003CmoveSpeed_003Ek__BackingField;

	private double _003Cpower_003Ek__BackingField;

	private float _003Carea_003Ek__BackingField;

	private float _003Cspeed_003Ek__BackingField;

	private float _003Cduration_003Ek__BackingField;

	private float _003Camount_003Ek__BackingField;

	private float _003Cluck_003Ek__BackingField;

	private float _003Cgrowth_003Ek__BackingField;

	private float _003Cgreed_003Ek__BackingField;

	private float _003Cmagnet_003Ek__BackingField;

	private float _003Crevivals_003Ek__BackingField;

	private float _003Ccurse_003Ek__BackingField;

	private float _003Cshields_003Ek__BackingField;

	private float _003CreRolls_003Ek__BackingField;

	private float _003Cskips_003Ek__BackingField;

	private float _003Cbanish_003Ek__BackingField;

	private List<WeaponType> _003Cshowcase_003Ek__BackingField;

	private List<Loadout> _003ClevelUpPresets_003Ek__BackingField;

	private float _003CdebugTime_003Ek__BackingField;

	private float _003CdebugEnemies_003Ek__BackingField;

	private string _003Cbgm_003Ek__BackingField;

	private int? _003CstartFrameCount_003Ek__BackingField;

	private int? _003CzeroPad_003Ek__BackingField;

	private string _003Csuffix_003Ek__BackingField;

	private int? _003CframeRate_003Ek__BackingField;

	private SineBonusData _003CsineSpeed_003Ek__BackingField;

	private SineBonusData _003CsineCooldown_003Ek__BackingField;

	private SineBonusData _003CsineArea_003Ek__BackingField;

	private SineBonusData _003CsineDuration_003Ek__BackingField;

	private SineBonusData _003CsineMight_003Ek__BackingField;

	private bool _003CnoHurt_003Ek__BackingField;

	private int _003CexLevels_003Ek__BackingField;

	private List<string> _003CexWeapons_003Ek__BackingField;

	private List<string> _003ChiddenWeapons_003Ek__BackingField;

	private ModifierStats _003ConEveryLevelUp_003Ek__BackingField;

	private Vector2? _003CbodyOffset_003Ek__BackingField;

	private int? _003CnameIndex_003Ek__BackingField;

	private SkinType _003CcurrentSkin_003Ek__BackingField;

	private List<RacingOffsetData> _003CracingOffsets_003Ek__BackingField;

	private ItemType? _003CrequiresRelic_003Ek__BackingField;

	public const string CharacterLangSheet = "characterLang/";

	public const string SkinLangSheet = "skinLang/";

	public bool allowCoopOutline
	{
		get
		{
			return _003CallowCoopOutline_003Ek__BackingField;
		}
		set
		{
			_003CallowCoopOutline_003Ek__BackingField = value;
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

	public bool secret
	{
		get
		{
			return _003Csecret_003Ek__BackingField;
		}
		set
		{
			_003Csecret_003Ek__BackingField = value;
		}
	}

	public bool hideWeaponIcon
	{
		get
		{
			return _003ChideWeaponIcon_003Ek__BackingField;
		}
		set
		{
			_003ChideWeaponIcon_003Ek__BackingField = value;
		}
	}

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

	public WeaponType? startingWeapon
	{
		get
		{
			return _003CstartingWeapon_003Ek__BackingField;
		}
		set
		{
			_003CstartingWeapon_003Ek__BackingField = value;
		}
	}

	public float cooldown
	{
		get
		{
			return _003Ccooldown_003Ek__BackingField;
		}
		set
		{
			_003Ccooldown_003Ek__BackingField = value;
		}
	}

	public string prefix
	{
		get
		{
			return _003Cprefix_003Ek__BackingField;
		}
		set
		{
			_003Cprefix_003Ek__BackingField = value;
		}
	}

	public string charName
	{
		get
		{
			return _003CcharName_003Ek__BackingField;
		}
		set
		{
			_003CcharName_003Ek__BackingField = value;
		}
	}

	public string surname
	{
		get
		{
			return _003Csurname_003Ek__BackingField;
		}
		set
		{
			_003Csurname_003Ek__BackingField = value;
		}
	}

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

	public string charSelTexture
	{
		get
		{
			return _003CcharSelTexture_003Ek__BackingField;
		}
		set
		{
			_003CcharSelTexture_003Ek__BackingField = value;
		}
	}

	public string charSelFrame
	{
		get
		{
			return _003CcharSelFrame_003Ek__BackingField;
		}
		set
		{
			_003CcharSelFrame_003Ek__BackingField = value;
		}
	}

	public string portraitName
	{
		get
		{
			return _003CportraitName_003Ek__BackingField;
		}
		set
		{
			_003CportraitName_003Ek__BackingField = value;
		}
	}

	public int walkingFrames
	{
		get
		{
			return _003CwalkingFrames_003Ek__BackingField;
		}
		set
		{
			_003CwalkingFrames_003Ek__BackingField = value;
		}
	}

	public List<Vector2> headOffsets
	{
		get
		{
			return _003CheadOffsets_003Ek__BackingField;
		}
		set
		{
			_003CheadOffsets_003Ek__BackingField = value;
		}
	}

	public List<Skin> skins
	{
		get
		{
			return _003Cskins_003Ek__BackingField;
		}
		set
		{
			_003Cskins_003Ek__BackingField = value;
		}
	}

	public int? walkFrameRate
	{
		get
		{
			return _003CwalkFrameRate_003Ek__BackingField;
		}
		set
		{
			_003CwalkFrameRate_003Ek__BackingField = value;
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

	public float price
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

	public float armor
	{
		get
		{
			return _003Carmor_003Ek__BackingField;
		}
		set
		{
			_003Carmor_003Ek__BackingField = value;
		}
	}

	public float regen
	{
		get
		{
			return _003Cregen_003Ek__BackingField;
		}
		set
		{
			_003Cregen_003Ek__BackingField = value;
		}
	}

	public float moveSpeed
	{
		get
		{
			return _003CmoveSpeed_003Ek__BackingField;
		}
		set
		{
			_003CmoveSpeed_003Ek__BackingField = value;
		}
	}

	public double power
	{
		get
		{
			return _003Cpower_003Ek__BackingField;
		}
		set
		{
			_003Cpower_003Ek__BackingField = value;
		}
	}

	public float area
	{
		get
		{
			return _003Carea_003Ek__BackingField;
		}
		set
		{
			_003Carea_003Ek__BackingField = value;
		}
	}

	public float speed
	{
		get
		{
			return _003Cspeed_003Ek__BackingField;
		}
		set
		{
			_003Cspeed_003Ek__BackingField = value;
		}
	}

	public float duration
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

	public float amount
	{
		get
		{
			return _003Camount_003Ek__BackingField;
		}
		set
		{
			_003Camount_003Ek__BackingField = value;
		}
	}

	public float luck
	{
		get
		{
			return _003Cluck_003Ek__BackingField;
		}
		set
		{
			_003Cluck_003Ek__BackingField = value;
		}
	}

	public float growth
	{
		get
		{
			return _003Cgrowth_003Ek__BackingField;
		}
		set
		{
			_003Cgrowth_003Ek__BackingField = value;
		}
	}

	public float greed
	{
		get
		{
			return _003Cgreed_003Ek__BackingField;
		}
		set
		{
			_003Cgreed_003Ek__BackingField = value;
		}
	}

	public float magnet
	{
		get
		{
			return _003Cmagnet_003Ek__BackingField;
		}
		set
		{
			_003Cmagnet_003Ek__BackingField = value;
		}
	}

	public float revivals
	{
		get
		{
			return _003Crevivals_003Ek__BackingField;
		}
		set
		{
			_003Crevivals_003Ek__BackingField = value;
		}
	}

	public float curse
	{
		get
		{
			return _003Ccurse_003Ek__BackingField;
		}
		set
		{
			_003Ccurse_003Ek__BackingField = value;
		}
	}

	public float shields
	{
		get
		{
			return _003Cshields_003Ek__BackingField;
		}
		set
		{
			_003Cshields_003Ek__BackingField = value;
		}
	}

	public float reRolls
	{
		get
		{
			return _003CreRolls_003Ek__BackingField;
		}
		set
		{
			_003CreRolls_003Ek__BackingField = value;
		}
	}

	public float skips
	{
		get
		{
			return _003Cskips_003Ek__BackingField;
		}
		set
		{
			_003Cskips_003Ek__BackingField = value;
		}
	}

	public float banish
	{
		get
		{
			return _003Cbanish_003Ek__BackingField;
		}
		set
		{
			_003Cbanish_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> showcase
	{
		get
		{
			return _003Cshowcase_003Ek__BackingField;
		}
		set
		{
			_003Cshowcase_003Ek__BackingField = value;
		}
	}

	public List<Loadout> levelUpPresets
	{
		get
		{
			return _003ClevelUpPresets_003Ek__BackingField;
		}
		set
		{
			_003ClevelUpPresets_003Ek__BackingField = value;
		}
	}

	public float debugTime
	{
		get
		{
			return _003CdebugTime_003Ek__BackingField;
		}
		set
		{
			_003CdebugTime_003Ek__BackingField = value;
		}
	}

	public float debugEnemies
	{
		get
		{
			return _003CdebugEnemies_003Ek__BackingField;
		}
		set
		{
			_003CdebugEnemies_003Ek__BackingField = value;
		}
	}

	public string bgm
	{
		get
		{
			return _003Cbgm_003Ek__BackingField;
		}
		set
		{
			_003Cbgm_003Ek__BackingField = value;
		}
	}

	public int? startFrameCount
	{
		get
		{
			return _003CstartFrameCount_003Ek__BackingField;
		}
		set
		{
			_003CstartFrameCount_003Ek__BackingField = value;
		}
	}

	public int? zeroPad
	{
		get
		{
			return _003CzeroPad_003Ek__BackingField;
		}
		set
		{
			_003CzeroPad_003Ek__BackingField = value;
		}
	}

	public string suffix
	{
		get
		{
			return _003Csuffix_003Ek__BackingField;
		}
		set
		{
			_003Csuffix_003Ek__BackingField = value;
		}
	}

	public int? frameRate
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

	public SineBonusData sineSpeed
	{
		get
		{
			return _003CsineSpeed_003Ek__BackingField;
		}
		set
		{
			_003CsineSpeed_003Ek__BackingField = value;
		}
	}

	public SineBonusData sineCooldown
	{
		get
		{
			return _003CsineCooldown_003Ek__BackingField;
		}
		set
		{
			_003CsineCooldown_003Ek__BackingField = value;
		}
	}

	public SineBonusData sineArea
	{
		get
		{
			return _003CsineArea_003Ek__BackingField;
		}
		set
		{
			_003CsineArea_003Ek__BackingField = value;
		}
	}

	public SineBonusData sineDuration
	{
		get
		{
			return _003CsineDuration_003Ek__BackingField;
		}
		set
		{
			_003CsineDuration_003Ek__BackingField = value;
		}
	}

	public SineBonusData sineMight
	{
		get
		{
			return _003CsineMight_003Ek__BackingField;
		}
		set
		{
			_003CsineMight_003Ek__BackingField = value;
		}
	}

	public bool noHurt
	{
		get
		{
			return _003CnoHurt_003Ek__BackingField;
		}
		set
		{
			_003CnoHurt_003Ek__BackingField = value;
		}
	}

	public int exLevels
	{
		get
		{
			return _003CexLevels_003Ek__BackingField;
		}
		set
		{
			_003CexLevels_003Ek__BackingField = value;
		}
	}

	public List<string> exWeapons
	{
		get
		{
			return _003CexWeapons_003Ek__BackingField;
		}
		set
		{
			_003CexWeapons_003Ek__BackingField = value;
		}
	}

	public List<string> hiddenWeapons
	{
		get
		{
			return _003ChiddenWeapons_003Ek__BackingField;
		}
		set
		{
			_003ChiddenWeapons_003Ek__BackingField = value;
		}
	}

	public ModifierStats onEveryLevelUp
	{
		get
		{
			return _003ConEveryLevelUp_003Ek__BackingField;
		}
		set
		{
			_003ConEveryLevelUp_003Ek__BackingField = value;
		}
	}

	public Vector2? bodyOffset
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+170]");
			CharacterData characterData = (CharacterData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+178]");
			_ = 0;
			return (Vector2?)this;
		}
		set
		{
			_003CbodyOffset_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
			_ = 0;
		}
	}

	public int? nameIndex
	{
		get
		{
			return _003CnameIndex_003Ek__BackingField;
		}
		set
		{
			_003CnameIndex_003Ek__BackingField = value;
		}
	}

	public SkinType currentSkin
	{
		get
		{
			return _003CcurrentSkin_003Ek__BackingField;
		}
		set
		{
			_003CcurrentSkin_003Ek__BackingField = value;
		}
	}

	public List<RacingOffsetData> racingOffsets
	{
		get
		{
			return _003CracingOffsets_003Ek__BackingField;
		}
		set
		{
			_003CracingOffsets_003Ek__BackingField = value;
		}
	}

	public ItemType? requiresRelic
	{
		get
		{
			return _003CrequiresRelic_003Ek__BackingField;
		}
		set
		{
			_003CrequiresRelic_003Ek__BackingField = value;
		}
	}

	public unsafe string GetFirstNameLocKey(CharacterType t)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "characterLang/{" + text + "}charName";
	}

	public string GetSkinPrefix()
	{
		string currentSkinData = (string)(object)GetCurrentSkinData();
		if (currentSkinData == null)
		{
			return currentSkinData;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		string result = default(string);
		return result;
	}

	public string GetSkinSuffix()
	{
		string currentSkinData = (string)(object)GetCurrentSkinData();
		if (currentSkinData == null)
		{
			return currentSkinData;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		string result = default(string);
		return result;
	}

	public string GetCharPrefix(CharacterType t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		string result = default(string);
		return result;
	}

	public string GetCharFirstName(CharacterType t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		string result = default(string);
		return result;
	}

	public string GetCharSurname(CharacterType t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		string result = default(string);
		return result;
	}

	public unsafe string GetTextWithFallback<T>(T t, string sheet, string term, string fallback)
	{
		//IL_00b3: Expected O, but got Ref
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Ref, but got Unknown
		//IL_01f6: Expected I8, but got I4
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		string[] array = new string[5];
		string result;
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text2 = string.Concat(array);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(text2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if (translation == null || translation._stringLength <= 0 || (object)translation == text2)
			{
				goto IL_023a;
			}
			bool flag = text2 == null;
			result = translation;
			if (!flag)
			{
				bool flag2 = translation._stringLength != text2._stringLength;
				result = translation;
				if (!flag2)
				{
					ref byte second = ref *(byte*)(text2 + 20);
					ulong length = (ulong)(translation._stringLength + translation._stringLength);
					bool flag3 = System.SpanHelpers.SequenceEqual(ref *(byte*)(translation + 20), ref second, length);
					bool flag4 = !flag3;
					result = translation;
					if (!flag4)
					{
						goto IL_023a;
					}
				}
			}
			goto IL_027b;
		}
		return (string)(object)new NullReferenceException();
		IL_023a:
		string text3 = default(string);
		bool flag5 = text3 == null;
		result = "";
		if (!flag5)
		{
			result = text3;
		}
		goto IL_027b;
		IL_027b:
		return result;
	}

	public string GetFirstNameWithPrefix(CharacterType t)
	{
		//IL_01b0: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_008c: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C91]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		string skinPrefix = GetSkinPrefix();
		string charPrefix = GetCharPrefix(t);
		string charFirstName = GetCharFirstName(t);
		object obj3 = ((skinPrefix == null || skinPrefix._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj4 = ((charPrefix == null || charPrefix._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj5 = ((charFirstName == null || charFirstName._stringLength <= 0) ? ((object)0) : ((object)1));
		if (obj3 != null)
		{
			string text2 = text + skinPrefix;
			text = text2;
		}
		object obj6 = obj4 & obj3;
		if (obj6 != null)
		{
			string text3 = text + " ";
			text = text3;
		}
		if (obj4 != null)
		{
			string text4 = text + charPrefix;
			text = text4;
		}
		bool flag = obj5 == null;
		if (!flag)
		{
			if (!flag)
			{
				string text5 = text + " ";
				text = text5;
			}
			return text + charFirstName;
		}
		return text;
	}

	public string GetSurnameWithSuffix(CharacterType t)
	{
		//IL_013a: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_0078: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_00e3: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C92]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		string skinSuffix = GetSkinSuffix();
		string charSurname = GetCharSurname(t);
		object obj3;
		object obj4;
		if (skinSuffix != null && skinSuffix._stringLength > 0)
		{
			obj3 = 1;
			obj4 = 1;
		}
		else
		{
			obj3 = 0;
			obj4 = 0;
		}
		object obj5;
		if (charSurname != null && charSurname._stringLength > 0)
		{
			string text2 = text + charSurname;
			text = text2;
			obj5 = 1;
		}
		else
		{
			obj4 = obj3;
			obj5 = 0;
		}
		object obj6 = obj5 & obj4;
		if (obj6 != null)
		{
			string text3 = text + " ";
			text = text3;
		}
		if (obj4 != null)
		{
			return text + skinSuffix;
		}
		return text;
	}

	public unsafe string GetFullName(CharacterType t, bool ignoreSkinPrefixSuffix = false, bool splitDualCharacterNames = true)
	{
		//IL_05f6: Expected O, but got I
		//IL_0606: Expected O, but got I
		//IL_0180: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_0202: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_0284: Expected O, but got I4
		//IL_0235: Expected O, but got I4
		//IL_0276: Expected O, but got I4
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected Ref, but got Unknown
		//IL_046f: Expected I8, but got I4
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C93]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !splitDualCharacterNames;
		CharacterType characterType = t;
		if (!flag)
		{
			switch (t)
			{
			default:
			{
				bool flag2 = t != CharacterType.TP_STELLA_AND_LORETTA;
				characterType = t;
				if (!flag2)
				{
					characterType = CharacterType.TP_STELLA;
				}
				break;
			}
			case CharacterType.TP_LORETTA_AND_STELLA:
				characterType = CharacterType.TP_LORETTA;
				break;
			case CharacterType.TP_CHARLOTTE_AND_JONATHAN:
				characterType = CharacterType.TP_CHARLOTTE;
				break;
			case CharacterType.TP_JONATHAN_AND_CHARLOTTE:
				characterType = CharacterType.TP_JONATHAN;
				break;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		string text2;
		string text3;
		if (ignoreSkinPrefixSuffix)
		{
			text2 = null;
			text3 = null;
		}
		else
		{
			string skinPrefix = GetSkinPrefix();
			string skinSuffix = GetSkinSuffix();
			text2 = skinPrefix;
			text3 = skinSuffix;
		}
		string charPrefix = GetCharPrefix(characterType);
		string charFirstName = GetCharFirstName(characterType);
		string charSurname = GetCharSurname(characterType);
		object obj3 = ((text2 == null || text2._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj4 = ((text3 == null || text3._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj5 = ((charPrefix == null || charPrefix._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj6 = ((charFirstName == null || charFirstName._stringLength <= 0) ? ((object)0) : ((object)1));
		object obj7 = ((charSurname == null || charSurname._stringLength <= 0) ? ((object)0) : ((object)1));
		if (obj3 != null)
		{
			string text4 = text + text2;
			text = text4;
		}
		object obj8 = obj5 & obj3;
		if (obj8 != null)
		{
			string text5 = text + " ";
			text = text5;
		}
		if (obj5 != null)
		{
			string text6 = text + charPrefix;
			text = text6;
		}
		bool flag3 = obj6 == null;
		if (!flag3)
		{
			if (!flag3)
			{
				string text7 = text + " ";
				text = text7;
			}
			string text8 = text + charFirstName;
			text = text8;
		}
		bool flag4 = obj7 == null;
		if (!flag4)
		{
			if (!flag4)
			{
				string text9 = text + " ";
				text = text9;
			}
			string text10 = text + charSurname;
			text = text10;
		}
		bool flag5 = obj4 == null;
		if (!flag5)
		{
			if (!flag5)
			{
				string text11 = text + " ";
				text = text11;
			}
			string text12 = text + text3;
			text = text12;
		}
		LocalizationManager.InitializeIfNeeded();
		CultureInfo cultureInfo = new CultureInfo(LocalizationManager.mCurrentLanguage, true, false);
		if (cultureInfo != null)
		{
			string displayName = cultureInfo.DisplayName;
			object obj9 = "Japanese";
			if ((object)displayName == "Japanese")
			{
				goto IL_04ac;
			}
			if (displayName != null && "Japanese" != null)
			{
				int stringLength = displayName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdx_v14+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(displayName + 20);
					ulong length = (ulong)(displayName._stringLength + displayName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Japanese" + 20), length))
					{
						goto IL_04ac;
					}
				}
			}
			goto IL_0785;
		}
		return (string)(object)new NullReferenceException();
		IL_05aa:
		string text13;
		text = text13;
		goto IL_0785;
		IL_0785:
		return text;
		IL_04ac:
		string text14;
		string text15;
		if (characterType != CharacterType.TP_SOMA && characterType != CharacterType.TP_MINA)
		{
			if (characterType != CharacterType.TP_OLROX)
			{
				if (characterType == CharacterType.EME_RAPIERDUAL)
				{
					text13 = GetCharFirstName(characterType);
					goto IL_05aa;
				}
				goto IL_0785;
			}
			string charFirstName2 = GetCharFirstName(CharacterType.TP_OLROX);
			text14 = GetCharPrefix(CharacterType.TP_OLROX);
			text15 = charFirstName2;
		}
		else
		{
			string charSurname2 = GetCharSurname(characterType);
			text14 = GetCharFirstName(characterType);
			text15 = charSurname2;
		}
		text13 = text15 + " " + text14;
		goto IL_05aa;
	}

	public string GetFullNameUntranslated()
	{
		//IL_0103: Expected O, but got I
		//IL_0113: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C94]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2 + _003Cprefix_003Ek__BackingField;
		if (text != null && text._stringLength > 0)
		{
			text += " ";
		}
		string text2 = text + _003CcharName_003Ek__BackingField;
		if (text2 != null && text2._stringLength > 0)
		{
			text2 += " ";
		}
		return text2 + _003Csurname_003Ek__BackingField;
	}

	public unsafe string GetSurNameLocKey(CharacterType t)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "characterLang/{" + text + "}surname";
	}

	public unsafe string GetDescriptionLocKey(CharacterType t)
	{
		//IL_001d: Expected O, but got Ref
		Skin currentSkinData = GetCurrentSkinData();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "characterLang/{" + text + "}description";
	}

	public string GetDescription(CharacterType t)
	{
		Skin currentSkinData = GetCurrentSkinData();
		string text = default(string);
		if (currentSkinData != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
			if (text != null && text._stringLength > 0)
			{
				goto IL_005d;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F55C80");
		goto IL_005d;
		IL_005d:
		return text;
	}

	public RacingOffsetData GetRacingOffsetData(CharacterVehicleType characterVehicleType)
	{
		if (_003CracingOffsets_003Ek__BackingField != null)
		{
			List<RacingOffsetData> list = _003CracingOffsets_003Ek__BackingField;
			if (list._size > 0)
			{
				List<RacingOffsetData>.Enumerator enumerator = default(List<RacingOffsetData>.Enumerator);
				while (enumerator.MoveNext())
				{
					RacingOffsetData racingOffsetData = null;
				}
			}
		}
		return null;
	}

	public Skin GetCurrentSkinData()
	{
		List<Skin>.Enumerator enumerator = default(List<Skin>.Enumerator);
		if (_003Cskins_003Ek__BackingField != null && enumerator.MoveNext())
		{
			Skin skin = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public Skin GetSkinData(SkinType skinType)
	{
		List<Skin>.Enumerator enumerator = default(List<Skin>.Enumerator);
		if (_003Cskins_003Ek__BackingField != null && enumerator.MoveNext())
		{
			Skin skin = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public CharacterData()
	{
		//IL_002e: Expected O, but got I4
		_003CallowCoopOutline_003Ek__BackingField = true;
		_003Cluck_003Ek__BackingField = 1f;
		List<string> list = new List<string>();
		_003CexWeapons_003Ek__BackingField = list;
		List<string> list2 = new List<string>();
		_003ChiddenWeapons_003Ek__BackingField = list2;
		_003CnameIndex_003Ek__BackingField = (int?)(object)1;
	}
}
