using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.App.Objects.Spells;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Spells;

public class SpellsManager : IInitializable, IDisposable
{
	private List<SpellModifier> _enabledSpells;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private static StageType? _003CCachedStageType_003Ek__BackingField;

	private static CharacterType? _003CCachedCharacterType_003Ek__BackingField;

	private static BgmType? _003CCachedBgm_003Ek__BackingField;

	private static BgmModType? _003CCachedBgmMod_003Ek__BackingField;

	public static StageType? CachedStageType
	{
		get
		{
			return _003CCachedStageType_003Ek__BackingField;
		}
		set
		{
			_003CCachedStageType_003Ek__BackingField = value;
		}
	}

	public static CharacterType? CachedCharacterType
	{
		get
		{
			return _003CCachedCharacterType_003Ek__BackingField;
		}
		set
		{
			_003CCachedCharacterType_003Ek__BackingField = value;
		}
	}

	public static BgmType? CachedBgm
	{
		get
		{
			return _003CCachedBgm_003Ek__BackingField;
		}
		set
		{
			_003CCachedBgm_003Ek__BackingField = value;
		}
	}

	public static BgmModType? CachedBgmMod
	{
		get
		{
			return _003CCachedBgmMod_003Ek__BackingField;
		}
		set
		{
			_003CCachedBgmMod_003Ek__BackingField = value;
		}
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public void StartSpell(SecretType secretType)
	{
		//IL_0013: Expected O, but got I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		Spell_Kamiki spell_Kamiki;
		if (secretType > SecretType.IWantToSeeItAgain)
		{
			object obj = secretType - 93;
			bool flag = secretType == SecretType.Festival;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						object obj4 = obj3 - 1;
						if (flag)
						{
							return;
						}
						if ((nint)obj4 != 1)
						{
							switch (secretType)
							{
							case SecretType.ForbiddenBox:
							{
								Spell_ForbiddenBox spell_ForbiddenBox = null;
								spell_ForbiddenBox._signalBus = _signalBus;
								((Spell_Kamiki)(object)spell_ForbiddenBox)._spellsManager = (SpellsManager)(object)_dataManager;
								((Spell_Kamiki)(object)spell_ForbiddenBox)._playerOptions = _playerOptions;
								spell_Kamiki = (Spell_Kamiki)(object)spell_ForbiddenBox;
								break;
							}
							case SecretType.SkipOneDay:
							{
								Spell_SkipOneDay spell_SkipOneDay = null;
								spell_SkipOneDay._playerOptions = _playerOptions;
								((Spell_Kamiki)(object)spell_SkipOneDay)._signalBus = _signalBus;
								((Spell_Kamiki)(object)spell_SkipOneDay)._spellsManager = this;
								_ = _dataManager;
								spell_Kamiki = (Spell_Kamiki)(object)spell_SkipOneDay;
								break;
							}
							default:
								return;
							}
						}
						else
						{
							Spell_Halloween spell_Halloween = null;
							spell_Halloween._signalBus = _signalBus;
							((Spell_Kamiki)(object)spell_Halloween)._signalBus = (SignalBus)(object)this;
							((Spell_Kamiki)(object)spell_Halloween)._spellsManager = (SpellsManager)(object)_dataManager;
							_ = _playerOptions;
							spell_Kamiki = (Spell_Kamiki)(object)spell_Halloween;
						}
					}
					else
					{
						Spell_Mars spell_Mars = null;
						spell_Mars._signalBus = _signalBus;
						spell_Mars._spellsManager = this;
						spell_Kamiki = (Spell_Kamiki)(object)spell_Mars;
					}
				}
				else
				{
					Spell_Jupiter spell_Jupiter = null;
					spell_Jupiter._signalBus = _signalBus;
					spell_Jupiter._spellsManager = this;
					spell_Kamiki = (Spell_Kamiki)(object)spell_Jupiter;
				}
			}
			else
			{
				Spell_Kamiki spell_Kamiki2 = null;
				spell_Kamiki2._playerOptions = _playerOptions;
				spell_Kamiki2._signalBus = _signalBus;
				spell_Kamiki2._spellsManager = this;
				spell_Kamiki = spell_Kamiki2;
			}
		}
		else
		{
			switch (secretType)
			{
			case SecretType.PopTheCorn:
			{
				Spell_PopTheCorn spell_PopTheCorn = null;
				spell_PopTheCorn._playerOptions = _playerOptions;
				spell_PopTheCorn._signalBus = _signalBus;
				spell_PopTheCorn._spellsManager = this;
				spell_PopTheCorn._dataManager = _dataManager;
				spell_Kamiki = (Spell_Kamiki)(object)spell_PopTheCorn;
				break;
			}
			case SecretType.IWantToSeeItAgain:
			{
				Spell_SeeItAgain spell_SeeItAgain = null;
				spell_SeeItAgain._playerOptions = _playerOptions;
				spell_SeeItAgain._signalBus = _signalBus;
				spell_SeeItAgain._spellsManager = this;
				spell_Kamiki = (Spell_Kamiki)(object)spell_SeeItAgain;
				break;
			}
			default:
				return;
			}
		}
		if (spell_Kamiki != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
	}

	public unsafe void ActivateSpells()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0170: Expected I4, but got O
		bool flag = _enabledSpells == null;
		SpellsManager spellsManager = this;
		if (!flag)
		{
			List<SpellModifier>.Enumerator enumerator = default(List<SpellModifier>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<SpellModifier>.Enumerator enumerator2 = (List<SpellModifier>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			spellsManager = (SpellsManager)(object)_enabledSpells;
			if (_enabledSpells != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v3 (VampireSurvivors.Spells.SpellsManager)+1C]");
				_ = (nint)0 + (nint)1;
				spellsManager._playerOptions = null;
				if ((nint)spellsManager._playerOptions > 0)
				{
					Array.Clear((Array)(object)spellsManager._enabledSpells, 0, (int)spellsManager._playerOptions);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void AddSpell(SpellModifier spellModifier)
	{
		List<object> enabledSpells = (List<object>)(object)_enabledSpells;
		int version = enabledSpells._version + 1;
		enabledSpells._version = version;
		object[] items = enabledSpells._items;
		if (enabledSpells._size >= items.Length)
		{
			enabledSpells.AddWithResize((object)spellModifier);
			return;
		}
		int size = enabledSpells._size + 1;
		enabledSpells._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void ResetCachedValues()
	{
		//IL_000f: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		_003CCachedStageType_003Ek__BackingField = (StageType?)(object)0;
		_003CCachedBgm_003Ek__BackingField = (BgmType?)(object)0;
		_003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)0;
	}

	public void RestoreCachedPlayerSettings()
	{
		//IL_0028: Expected I4, but got O
		//IL_010b: Expected O, but got I4
		//IL_005d: Expected I4, but got O
		//IL_013d: Expected O, but got I4
		//IL_0092: Expected I4, but got O
		//IL_016f: Expected O, but got I4
		//IL_00c7: Expected I4, but got O
		//IL_019d: Expected O, but got I4
		if ((object)_003CCachedStageType_003Ek__BackingField != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if ((object)_003CCachedStageType_003Ek__BackingField == null)
			{
				goto IL_01de;
			}
			StageType stageType = (StageType)((object?)_003CCachedStageType_003Ek__BackingField >> 32);
			config._003CSelectedStage_003Ek__BackingField = stageType;
			_003CCachedStageType_003Ek__BackingField = (StageType?)(object)0;
		}
		if ((object)_003CCachedCharacterType_003Ek__BackingField != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if ((object)_003CCachedCharacterType_003Ek__BackingField == null)
			{
				goto IL_01de;
			}
			CharacterType selectedCharacter = (CharacterType)((object?)_003CCachedCharacterType_003Ek__BackingField >> 32);
			config2.SelectedCharacter = selectedCharacter;
			_003CCachedCharacterType_003Ek__BackingField = (CharacterType?)(object)0;
		}
		if ((object)_003CCachedBgm_003Ek__BackingField != null)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			if ((object)_003CCachedBgm_003Ek__BackingField == null)
			{
				goto IL_01de;
			}
			BgmType bgmType = (BgmType)((object?)_003CCachedBgm_003Ek__BackingField >> 32);
			config3._003CSelectedBGM_003Ek__BackingField = bgmType;
			_003CCachedBgm_003Ek__BackingField = (BgmType?)(object)0;
		}
		if ((object)_003CCachedBgmMod_003Ek__BackingField != null)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			if ((object)_003CCachedBgmMod_003Ek__BackingField != null)
			{
				BgmModType bgmModType = (BgmModType)((object?)_003CCachedBgmMod_003Ek__BackingField >> 32);
				config4._003CSelectedBGMMod_003Ek__BackingField = bgmModType;
				_003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)0;
				return;
			}
			goto IL_01de;
		}
		return;
		IL_01de:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	public SpellsManager()
	{
		List<SpellModifier> enabledSpells = new List<SpellModifier>();
		_enabledSpells = enabledSpells;
	}
}
