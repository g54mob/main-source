using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements;

[Serializable]
public class AchievementData
{
	private sealed class _003C_003Ec__DisplayClass107_0
	{
		public PowerUpType unlock;

		internal bool _003CFixUnlock_003Eb__0(PowerUpType x)
		{
			//IL_000f: Expected O, but got I4
			object obj = x - unlock;
			return obj == null;
		}
	}

	private string _003CforcedTexture_003Ek__BackingField;

	private string _003CforcedFrameName_003Ek__BackingField;

	private string _003CforcedUnlockTips_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private int _003CgoldPrize_003Ek__BackingField;

	private string _003CweaponIcon_003Ek__BackingField;

	private bool _003Cachieved_003Ek__BackingField;

	private string _003ChyperToUnlock_003Ek__BackingField;

	private string _003CstageToUnlock_003Ek__BackingField;

	private string _003CweaponToUnlock_003Ek__BackingField;

	private bool _003Cmistery_003Ek__BackingField;

	private string _003CrelicToUnlock_003Ek__BackingField;

	private string _003CarcanaToUnlock_003Ek__BackingField;

	private string _003CcharacterToUnlock_003Ek__BackingField;

	private List<CharacterType> _003CcharactersToUnlock_003Ek__BackingField;

	private string _003CpowerUpToUnlock_003Ek__BackingField;

	private AchievementType _003CType_003Ek__BackingField;

	private CharacterType _003CrequiresChar_003Ek__BackingField;

	private ItemType _003CrequiresItem_003Ek__BackingField;

	private StageType? _003CrequiresStage_003Ek__BackingField;

	private WeaponType? _003CrequiresWeapon_003Ek__BackingField;

	private List<SkinToUnlock> _003CskinsToUnlock_003Ek__BackingField;

	private AdventureProgressData _003CadventureUnlockData_003Ek__BackingField;

	private List<AchievementUnlockConditionData> _003CUnlockConditions_003Ek__BackingField;

	private AchievementPlatformData[] _003CPlatformsData_003Ek__BackingField;

	public string forcedTexture
	{
		get
		{
			return _003CforcedTexture_003Ek__BackingField;
		}
		set
		{
			_003CforcedTexture_003Ek__BackingField = value;
		}
	}

	public string forcedFrameName
	{
		get
		{
			return _003CforcedFrameName_003Ek__BackingField;
		}
		set
		{
			_003CforcedFrameName_003Ek__BackingField = value;
		}
	}

	public string forcedUnlockTips
	{
		get
		{
			return _003CforcedUnlockTips_003Ek__BackingField;
		}
		set
		{
			_003CforcedUnlockTips_003Ek__BackingField = value;
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

	public int goldPrize
	{
		get
		{
			return _003CgoldPrize_003Ek__BackingField;
		}
		set
		{
			_003CgoldPrize_003Ek__BackingField = value;
		}
	}

	public string weaponIcon
	{
		get
		{
			return _003CweaponIcon_003Ek__BackingField;
		}
		set
		{
			_003CweaponIcon_003Ek__BackingField = value;
		}
	}

	public bool achieved
	{
		get
		{
			return _003Cachieved_003Ek__BackingField;
		}
		set
		{
			_003Cachieved_003Ek__BackingField = value;
		}
	}

	public string hyperToUnlock
	{
		get
		{
			return _003ChyperToUnlock_003Ek__BackingField;
		}
		set
		{
			_003ChyperToUnlock_003Ek__BackingField = value;
		}
	}

	public string stageToUnlock
	{
		get
		{
			return _003CstageToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CstageToUnlock_003Ek__BackingField = value;
		}
	}

	public string weaponToUnlock
	{
		get
		{
			return _003CweaponToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CweaponToUnlock_003Ek__BackingField = value;
		}
	}

	public bool mistery
	{
		get
		{
			return _003Cmistery_003Ek__BackingField;
		}
		set
		{
			_003Cmistery_003Ek__BackingField = value;
		}
	}

	public string relicToUnlock
	{
		get
		{
			return _003CrelicToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CrelicToUnlock_003Ek__BackingField = value;
		}
	}

	public string arcanaToUnlock
	{
		get
		{
			return _003CarcanaToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CarcanaToUnlock_003Ek__BackingField = value;
		}
	}

	public string characterToUnlock
	{
		get
		{
			return _003CcharacterToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CcharacterToUnlock_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> charactersToUnlock
	{
		get
		{
			return _003CcharactersToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CcharactersToUnlock_003Ek__BackingField = value;
		}
	}

	public string powerUpToUnlock
	{
		get
		{
			return _003CpowerUpToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CpowerUpToUnlock_003Ek__BackingField = value;
		}
	}

	public AchievementType Type
	{
		get
		{
			return _003CType_003Ek__BackingField;
		}
		set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public CharacterType requiresChar
	{
		get
		{
			return _003CrequiresChar_003Ek__BackingField;
		}
		set
		{
			_003CrequiresChar_003Ek__BackingField = value;
		}
	}

	public ItemType requiresItem
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

	public StageType? requiresStage
	{
		get
		{
			return _003CrequiresStage_003Ek__BackingField;
		}
		set
		{
			_003CrequiresStage_003Ek__BackingField = value;
		}
	}

	public WeaponType? requiresWeapon
	{
		get
		{
			return _003CrequiresWeapon_003Ek__BackingField;
		}
		set
		{
			_003CrequiresWeapon_003Ek__BackingField = value;
		}
	}

	public List<SkinToUnlock> skinsToUnlock
	{
		get
		{
			return _003CskinsToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CskinsToUnlock_003Ek__BackingField = value;
		}
	}

	public AdventureProgressData adventureUnlockData
	{
		get
		{
			return _003CadventureUnlockData_003Ek__BackingField;
		}
		set
		{
			_003CadventureUnlockData_003Ek__BackingField = value;
		}
	}

	public List<AchievementUnlockConditionData> UnlockConditions
	{
		get
		{
			return _003CUnlockConditions_003Ek__BackingField;
		}
		set
		{
			_003CUnlockConditions_003Ek__BackingField = value;
		}
	}

	public AchievementPlatformData[] PlatformsData
	{
		get
		{
			return _003CPlatformsData_003Ek__BackingField;
		}
		set
		{
			_003CPlatformsData_003Ek__BackingField = value;
		}
	}

	public string CurrentPlatformData
	{
		get
		{
			//IL_00d6: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_0032: Expected O, but got I4
			//IL_0081: Expected O, but got I4
			//IL_009b: Expected O, but got I4
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			if (_003CPlatformsData_003Ek__BackingField != null)
			{
				AchievementPlatformData[] array = _003CPlatformsData_003Ek__BackingField;
				object obj = 0;
				while ((nint)obj < array.Length)
				{
					if ((nint)obj < array.Length)
					{
						AchievementPlatformData achievementPlatformData = array[obj];
						object obj2 = achievementPlatformData.Platfrom & AchievementPlatform.Steam;
						bool flag = obj2 == null;
						object obj3 = !flag;
						if (obj3 == null)
						{
							obj++;
							continue;
						}
						return achievementPlatformData.Data;
					}
					return (string)(object)new IndexOutOfRangeException();
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2+B8]");
			return (string)0;
		}
	}

	public unsafe virtual string GetLocalizedDescription(AchievementType type)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "achievementLang/{" + text + "}description";
	}

	public unsafe virtual string GetLocalizedDescription(AdventureAchievementType type)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "progressLang/{" + text + "}description";
	}

	public unsafe virtual string GetLocalizedUnlocks()
	{
		//IL_00cb: Expected O, but got Ref
		string text = _003ChyperToUnlock_003Ek__BackingField;
		if (_003ChyperToUnlock_003Ek__BackingField == null || text._stringLength <= 0)
		{
			text = _003CstageToUnlock_003Ek__BackingField;
			if (_003CstageToUnlock_003Ek__BackingField == null || text._stringLength <= 0)
			{
				if (_003CgoldPrize_003Ek__BackingField <= 0)
				{
					return _003CweaponToUnlock_003Ek__BackingField;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA86B0");
				if ("N0" != null)
				{
				}
				object obj = default(object);
				IFormatProvider provider = default(IFormatProvider);
				string text2 = System.Number.FormatInt32(_003CgoldPrize_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), provider);
				text = text2 + " gold coins";
			}
		}
		return text;
	}

	public virtual string GetLocalizedName()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2CA1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = this + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rdx_v1+1B8] (should have been resolved before IL gen)");
			string text = default(string);
			return "achievementLang/{" + text + "}name";
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetLocalizationKey()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_004a: Expected O, but got I
		//IL_005a: Expected O, but got I
		object obj = this + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+1B8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+1C0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ r8_v1 (should have been resolved before IL gen)");
		}
		return (string)(object)new NullReferenceException();
	}

	public virtual bool CheckForCompletion()
	{
		return false;
	}

	public unsafe virtual void Unlock(PlayerOptionsData config, PlayerOptions playerOptions)
	{
		//IL_0add: Expected F4, but got I4
		//IL_0ae2: Expected I, but got O
		//IL_0019: Expected F4, but got I4
		//IL_0028: Expected F4, but got I4
		//IL_0036: Expected I, but got O
		//IL_03f0: Expected O, but got I
		//IL_041d: Expected O, but got I
		//IL_0b2d: Expected O, but got I4
		//IL_00d1: Expected I, but got O
		//IL_020b: Expected I, but got O
		//IL_0329: Expected I, but got O
		//IL_073d: Expected I, but got O
		//IL_0137: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_038f: Expected I, but got O
		//IL_0a15: Expected O, but got I4
		//IL_0a1d: Expected O, but got Ref
		//IL_0b64: Expected O, but got I
		//IL_07a0: Expected O, but got I
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		//IL_08e6: Expected O, but got I4
		//IL_08ec: Expected O, but got I
		//IL_08f4: Expected F4, but got O
		//IL_0825: Expected O, but got I
		//IL_084c: Expected I, but got O
		bool flag = _003CgoldPrize_003Ek__BackingField <= 0;
		PlayerOptions playerOptions2 = playerOptions;
		float num = 0f;
		nint num2 = (nint)this;
		if (!flag)
		{
			PlayerOptions.AddCoinsFlat(_003CgoldPrize_003Ek__BackingField, config);
			playerOptions2 = null;
			num = _003CgoldPrize_003Ek__BackingField;
			num2 = (nint)typeof(PlayerOptions);
		}
		string text = _003ChyperToUnlock_003Ek__BackingField;
		if (_003ChyperToUnlock_003Ek__BackingField == null || text._stringLength <= 0)
		{
			goto IL_0175;
		}
		StageType stageType = Enum.Parse<StageType>(_003ChyperToUnlock_003Ek__BackingField);
		bool flag2 = config == null;
		string text2 = _003ChyperToUnlock_003Ek__BackingField;
		if (!flag2)
		{
			num2 = (nint)config._003CUnlockedHypers_003Ek__BackingField;
			bool flag3 = config._003CUnlockedHypers_003Ek__BackingField == null;
			text2 = (string)(object)config._003CUnlockedHypers_003Ek__BackingField;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
				object obj = default(object);
				if (obj == null)
				{
					num2 = (nint)config._003CUnlockedHypers_003Ek__BackingField;
					bool flag4 = config._003CUnlockedHypers_003Ek__BackingField == null;
					text2 = (string)(object)config._003CUnlockedHypers_003Ek__BackingField;
					if (flag4)
					{
						goto IL_0af0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
				}
				goto IL_0175;
			}
		}
		goto IL_0af0;
		IL_0b72:
		string text3 = _003CrelicToUnlock_003Ek__BackingField;
		if (_003CrelicToUnlock_003Ek__BackingField == null || text3._stringLength <= 0)
		{
			goto IL_09b9;
		}
		ItemType itemType = Enum.Parse<ItemType>(_003CrelicToUnlock_003Ek__BackingField);
		bool flag5 = config == null;
		text2 = _003CrelicToUnlock_003Ek__BackingField;
		if (!flag5)
		{
			text2 = (string)(object)config._003CCollectedItems_003Ek__BackingField;
			if (config._003CCollectedItems_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					if (config._003CCollectedItems_003Ek__BackingField == null)
					{
						goto IL_0af0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				}
				goto IL_09b9;
			}
		}
		goto IL_0af0;
		IL_09b9:
		if (_003CskinsToUnlock_003Ek__BackingField != null)
		{
			List<SkinToUnlock> list = _003CskinsToUnlock_003Ek__BackingField;
			List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
			if (list._size > 0 && enumerator.MoveNext())
			{
				object obj3 = 0;
				List<SkinToUnlock>.Enumerator enumerator2 = (List<SkinToUnlock>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
		return;
		IL_06df:
		object obj11;
		if (_003CcharactersToUnlock_003Ek__BackingField != null)
		{
			List<CharacterType> list2 = _003CcharactersToUnlock_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 > (nint)0)
			{
				nint num3 = (nint)list2;
				object obj4 = default(object);
				object obj5 = default(object);
				object obj7 = default(object);
				nint num5 = default(nint);
				object obj10 = default(object);
				while (true)
				{
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ stack_-80_v7+1C]");
						if (obj5 != null)
						{
							break;
						}
						object obj6 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ stack_-80_v7+18]");
						if ((nint)obj6 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ stack_-80_v7+10]");
						object obj8 = 0;
						object obj9 = obj7 + 1;
						List<CharacterType> list3 = config._003CUnlockedCharacters_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
						bool flag6 = (nint)0 == 0;
						nint num4 = num5;
						nint num6 = num3;
						nint num7 = 0;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							text2 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							bool flag7 = (nint)obj10 != -1;
							num4 = 0;
							num7 = unchecked((nint)null);
							num5 = 0;
							obj7 = obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							num3 = 0;
							if (flag7)
							{
								continue;
							}
						}
						text2 = (string)(object)config._003CUnlockedCharacters_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
						num5 = num4;
						obj7 = obj9;
						num3 = num6;
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag8 = obj4 == null;
				text2 = (string)0;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ stack_-80_v7+1C]");
					if (obj5 == null)
					{
						obj11 = 0;
						playerOptions2 = (PlayerOptions)0;
						num = (float)list2;
						goto IL_0b72;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					text2 = null;
				}
				throw new NullReferenceException();
			}
		}
		obj11 = 0;
		goto IL_0b72;
		IL_0af0:
		throw new NullReferenceException();
		IL_05bf:
		string text4 = _003CcharacterToUnlock_003Ek__BackingField;
		if (_003CcharacterToUnlock_003Ek__BackingField == null || text4._stringLength <= 0)
		{
			goto IL_06df;
		}
		CharacterType characterType = Enum.Parse<CharacterType>(_003CcharacterToUnlock_003Ek__BackingField);
		bool flag9 = config == null;
		text2 = _003CcharacterToUnlock_003Ek__BackingField;
		if (!flag9)
		{
			text2 = (string)(object)config._003CUnlockedCharacters_003Ek__BackingField;
			if (config._003CUnlockedCharacters_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				object obj12 = default(object);
				if (obj12 == null)
				{
					text2 = (string)(object)config._003CUnlockedCharacters_003Ek__BackingField;
					if (config._003CUnlockedCharacters_003Ek__BackingField == null)
					{
						goto IL_0af0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
				}
				goto IL_06df;
			}
		}
		goto IL_0af0;
		IL_03cd:
		string text5 = _003CarcanaToUnlock_003Ek__BackingField;
		bool flag10 = _003CarcanaToUnlock_003Ek__BackingField == null;
		text2 = (string)num2;
		if (!flag10)
		{
			bool flag11 = text5._stringLength <= 0;
			text2 = (string)num2;
			if (!flag11)
			{
				int num8 = int.Parse(_003CarcanaToUnlock_003Ek__BackingField);
				bool flag12 = config == null;
				text2 = _003CarcanaToUnlock_003Ek__BackingField;
				if (!flag12)
				{
					text2 = (string)(object)config._003CUnlockedArcanas_003Ek__BackingField;
					if (config._003CUnlockedArcanas_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
						object obj13 = default(object);
						if (obj13 == null)
						{
							text2 = (string)(object)config._003CUnlockedArcanas_003Ek__BackingField;
							if (config._003CUnlockedArcanas_003Ek__BackingField == null)
							{
								goto IL_0af0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
						}
						goto IL_04f8;
					}
				}
				goto IL_0af0;
			}
		}
		goto IL_04f8;
		IL_0afb:
		string text6 = _003CweaponToUnlock_003Ek__BackingField;
		if (_003CweaponToUnlock_003Ek__BackingField == null || text6._stringLength <= 0)
		{
			goto IL_03cd;
		}
		WeaponType weaponType = Enum.Parse<WeaponType>(_003CweaponToUnlock_003Ek__BackingField);
		bool flag13 = config == null;
		text2 = _003CweaponToUnlock_003Ek__BackingField;
		if (!flag13)
		{
			num2 = (nint)config._003CUnlockedWeapons_003Ek__BackingField;
			bool flag14 = config._003CUnlockedWeapons_003Ek__BackingField == null;
			text2 = (string)(object)config._003CUnlockedWeapons_003Ek__BackingField;
			if (!flag14)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj14 = default(object);
				if (obj14 == null)
				{
					num2 = (nint)config._003CUnlockedWeapons_003Ek__BackingField;
					bool flag15 = config._003CUnlockedWeapons_003Ek__BackingField == null;
					text2 = (string)(object)config._003CUnlockedWeapons_003Ek__BackingField;
					if (flag15)
					{
						goto IL_0af0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				}
				goto IL_03cd;
			}
		}
		goto IL_0af0;
		IL_04f8:
		string text7 = _003CpowerUpToUnlock_003Ek__BackingField;
		if (_003CpowerUpToUnlock_003Ek__BackingField == null || text7._stringLength <= 0)
		{
			goto IL_05bf;
		}
		if (config != null)
		{
			PowerUpType powerUpType = Enum.Parse<PowerUpType>(_003CpowerUpToUnlock_003Ek__BackingField);
			bool flag16 = config._003CUnlockedPowerUpRanks_003Ek__BackingField == null;
			text2 = _003CpowerUpToUnlock_003Ek__BackingField;
			if (!flag16)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
				text2 = (string)(object)config._003CUnlockedPowerUpRanks_003Ek__BackingField;
				goto IL_05bf;
			}
		}
		goto IL_0af0;
		IL_0175:
		string text8 = _003CstageToUnlock_003Ek__BackingField;
		if (_003CstageToUnlock_003Ek__BackingField != null && text8._stringLength > 0)
		{
			StageType stageType2 = Enum.Parse<StageType>(_003CstageToUnlock_003Ek__BackingField);
			bool flag17 = config == null;
			text2 = _003CstageToUnlock_003Ek__BackingField;
			if (!flag17)
			{
				num2 = (nint)config._003CUnlockedStages_003Ek__BackingField;
				bool flag18 = config._003CUnlockedStages_003Ek__BackingField == null;
				text2 = (string)(object)config._003CUnlockedStages_003Ek__BackingField;
				if (!flag18)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
					object obj15 = default(object);
					if (obj15 == null)
					{
						num2 = (nint)config._003CUnlockedStages_003Ek__BackingField;
						bool flag19 = config._003CUnlockedStages_003Ek__BackingField == null;
						text2 = (string)(object)config._003CUnlockedStages_003Ek__BackingField;
						if (flag19)
						{
							goto IL_0af0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
						config._003CNextAutoSelectStage_003Ek__BackingField = stageType2;
					}
					goto IL_0afb;
				}
			}
			goto IL_0af0;
		}
		goto IL_0afb;
	}

	public virtual void FixUnlock(PlayerOptions playerOptions, DataManager dataManager, AchievementType type, Dictionary<PowerUpType, int> powerUpCounts)
	{
		//IL_078a: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_05fe: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_015a: Expected O, but got I4
		//IL_0760: Expected F4, but got I4
		//IL_0648: Expected O, but got I4
		//IL_0655: Expected O, but got I4
		//IL_057e: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_06c1: Expected O, but got I4
		//IL_05c6: Expected O, but got I4
		//IL_05d3: Expected O, but got I4
		//IL_0709: Expected O, but got I4
		//IL_0509: Expected O, but got I4
		//IL_0517: Expected O, but got I4
		string text = _003ChyperToUnlock_003Ek__BackingField;
		bool flag = _003ChyperToUnlock_003Ek__BackingField == null;
		object obj = 0;
		if (!flag)
		{
			bool flag2 = text._stringLength <= 0;
			obj = 0;
			if (!flag2)
			{
				StageType stageType = Enum.Parse<StageType>(_003ChyperToUnlock_003Ek__BackingField);
				PlayerOptionsData config = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
				object obj2 = default(object);
				bool flag3 = obj2 != null;
				obj = 0;
				if (!flag3)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
					obj = 1;
				}
			}
		}
		string text2 = _003CstageToUnlock_003Ek__BackingField;
		if (_003CstageToUnlock_003Ek__BackingField != null && text2._stringLength > 0)
		{
			StageType stageType2 = Enum.Parse<StageType>(_003CstageToUnlock_003Ek__BackingField);
			PlayerOptionsData config3 = playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
			object obj3 = default(object);
			if (obj3 == null)
			{
				PlayerOptionsData config4 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
				obj = 1;
			}
		}
		string text3 = _003CweaponToUnlock_003Ek__BackingField;
		if (_003CweaponToUnlock_003Ek__BackingField != null && text3._stringLength > 0)
		{
			WeaponType weaponType = Enum.Parse<WeaponType>(_003CweaponToUnlock_003Ek__BackingField);
			PlayerOptionsData config5 = playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj4 = default(object);
			if (obj4 == null)
			{
				PlayerOptionsData config6 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				obj = 1;
			}
		}
		string text4 = _003CarcanaToUnlock_003Ek__BackingField;
		if (_003CarcanaToUnlock_003Ek__BackingField != null && text4._stringLength > 0)
		{
			int arcanaType = int.Parse(_003CarcanaToUnlock_003Ek__BackingField);
			PlayerOptionsData config7 = playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
			object obj5 = default(object);
			if (obj5 == null)
			{
				playerOptions.UnlockArcana((ArcanaType)arcanaType);
				obj = 1;
			}
		}
		string text5 = _003CpowerUpToUnlock_003Ek__BackingField;
		if (_003CpowerUpToUnlock_003Ek__BackingField != null && text5._stringLength > 0)
		{
			_003C_003Ec__DisplayClass107_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass107_0();
			PowerUpType unlock = Enum.Parse<PowerUpType>(_003CpowerUpToUnlock_003Ek__BackingField);
			CS_0024_003C_003E8__locals11.unlock = unlock;
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = dataManager.GetConvertedPowerUpData();
			Dictionary<PowerUpType, int> dictionary = default(Dictionary<PowerUpType, int>);
			int num = dictionary.FindEntry(CS_0024_003C_003E8__locals11.unlock);
			if (num >= 0)
			{
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals11.unlock);
				if (num2 >= 0)
				{
					int num3 = dictionary.get_Item(CS_0024_003C_003E8__locals11.unlock);
					object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals11.unlock);
					bool flag4 = CS_0024_003C_003E8__locals11.unlock == PowerUpType.SEAL;
					int num4 = 1;
					if (!flag4)
					{
						bool flag5 = CS_0024_003C_003E8__locals11.unlock == PowerUpType.SEAL2;
						num4 = 1;
						if (!flag5)
						{
							bool flag6 = CS_0024_003C_003E8__locals11.unlock == PowerUpType.SEAL3;
							num4 = 1;
							if (!flag6)
							{
								bool flag7 = CS_0024_003C_003E8__locals11.unlock != PowerUpType.SEAL4;
								int num5 = num3;
								if (!flag7)
								{
									num5 = 1;
								}
								num4 = num5;
							}
						}
					}
					PlayerOptionsData config8 = playerOptions.Config;
					Func<PowerUpType, bool> predicate = delegate(PowerUpType x)
					{
						//IL_000f: Expected O, but got I4
						object obj7 = x - CS_0024_003C_003E8__locals11.unlock;
						return obj7 == null;
					};
					int num6 = Enumerable.Count((IEnumerable<System.Int32Enum>)config8._003CUnlockedPowerUpRanks_003Ek__BackingField, (Func<System.Int32Enum, bool>)(object)predicate);
					if (num6 < num4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rax_v49 (System.Object)+18]");
						if ((nint)num6 < (nint)0)
						{
							PlayerOptionsData config9 = playerOptions.Config;
							int num7 = Enumerable.Count(config9._003CUnlockedPowerUpRanks_003Ek__BackingField, (Func<PowerUpType, bool>)CS_0024_003C_003E8__locals11.unlock);
							obj = 1;
						}
					}
				}
			}
		}
		string text6 = _003CcharacterToUnlock_003Ek__BackingField;
		if (_003CcharacterToUnlock_003Ek__BackingField != null && text6._stringLength > 0)
		{
			CharacterType characterType = Enum.Parse<CharacterType>(_003CcharacterToUnlock_003Ek__BackingField);
			PlayerOptionsData config10 = playerOptions.Config;
			if (Enumerable.Count((IEnumerable<PowerUpType>)config10._003CUnlockedCharacters_003Ek__BackingField, (Func<PowerUpType, bool>)characterType) == 0)
			{
				PlayerOptionsData config11 = playerOptions.Config;
				int num8 = Enumerable.Count((IEnumerable<PowerUpType>)config11._003CUnlockedCharacters_003Ek__BackingField, (Func<PowerUpType, bool>)characterType);
				obj = 1;
			}
		}
		if (_003CrequiresChar_003Ek__BackingField != CharacterType.VOID)
		{
			PlayerOptionsData config12 = playerOptions.Config;
			if (Enumerable.Count((IEnumerable<PowerUpType>)config12._003CUnlockedCharacters_003Ek__BackingField, (Func<PowerUpType, bool>)_003CrequiresChar_003Ek__BackingField) == 0)
			{
				PlayerOptionsData config13 = playerOptions.Config;
				int num9 = Enumerable.Count((IEnumerable<PowerUpType>)config13._003CUnlockedCharacters_003Ek__BackingField, (Func<PowerUpType, bool>)_003CrequiresChar_003Ek__BackingField);
				obj = 1;
			}
		}
		string text7 = _003CrelicToUnlock_003Ek__BackingField;
		if (_003CrelicToUnlock_003Ek__BackingField != null && text7._stringLength > 0)
		{
			ItemType itemType = Enum.Parse<ItemType>(_003CrelicToUnlock_003Ek__BackingField);
			PlayerOptionsData config14 = playerOptions.Config;
			if (Enumerable.Count((IEnumerable<PowerUpType>)config14._003CCollectedItems_003Ek__BackingField, (Func<PowerUpType, bool>)itemType) == 0)
			{
				PlayerOptionsData config15 = playerOptions.Config;
				int num10 = Enumerable.Count((IEnumerable<PowerUpType>)config15._003CCollectedItems_003Ek__BackingField, (Func<PowerUpType, bool>)itemType);
				goto IL_072f;
			}
		}
		if (obj != null)
		{
			goto IL_072f;
		}
		return;
		IL_072f:
		if (_003CgoldPrize_003Ek__BackingField > 0)
		{
			playerOptions.AddCoinsFlat(_003CgoldPrize_003Ek__BackingField);
		}
	}
}
