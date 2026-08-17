using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class SkinItem
{
	private PlayerOptions _playerOptions;

	private CharacterType _characterType;

	private CharacterData _characterData;

	private SkinType _skinType;

	private Skin _skinData;

	private UIUnlockStates _unlockState;

	public UIUnlockStates UnlockState => _unlockState;

	public CharacterType CharacterType => _characterType;

	public CharacterData CharacterData => _characterData;

	public SkinType SkinType => _skinType;

	public Skin SkinData => _skinData;

	public SkinItem(PlayerOptions playerOptions, CharacterType characterType, CharacterData characterData, SkinType skinType, Skin skinData)
	{
		_playerOptions = playerOptions;
		_characterType = characterType;
		_characterData = characterData;
		SkinType skinType2 = default(SkinType);
		_skinType = skinType2;
		Skin skinData2 = default(Skin);
		_skinData = skinData2;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 152 Invalid \"Jump target not found in method: 0x186D9D3B0\"");
	}

	public void RefreshUnlockState()
	{
		Skin skinData = _skinData;
		if (!skinData._003CalwaysHidden_003Ek__BackingField)
		{
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					goto IL_0108;
				}
			}
			Skin skinData2 = _skinData;
			if (!skinData2._003Csecret_003Ek__BackingField || IsSkinUnlocked() || IsSkinBought())
			{
				goto IL_0108;
			}
		}
		goto IL_0237;
		IL_0108:
		Skin skinData3 = _skinData;
		if (skinData3._003Chidden_003Ek__BackingField || IsSkinUnlocked() || IsSkinBought())
		{
			Skin skinData4 = _skinData;
			if (skinData4._003Chidden_003Ek__BackingField && !IsSkinUnlocked() && !IsSkinBought())
			{
				_unlockState = UIUnlockStates.UNLOCKABLE;
			}
			else if (IsSkinUnlocked() && !IsSkinBought())
			{
				_unlockState = UIUnlockStates.PURCHASABLE;
			}
			else
			{
				_unlockState = UIUnlockStates.AVAILABLE;
			}
			return;
		}
		goto IL_0237;
		IL_0237:
		_unlockState = UIUnlockStates.UNAVAILABLE;
	}

	public bool CanSeeSecrets()
	{
		//IL_00c3: Expected I4, but got O
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 == 0)
					{
						return false;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj2 = default(object);
					object obj = obj2 - -1;
					bool flag = obj == null;
					return !flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinAlwaysHidden()
	{
		//IL_0041: Expected I4, but got O
		Skin skinData = _skinData;
		if (_skinData != null)
		{
			return skinData._003CalwaysHidden_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinSecret()
	{
		//IL_0041: Expected I4, but got O
		Skin skinData = _skinData;
		if (_skinData != null)
		{
			return skinData._003Csecret_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinHidden()
	{
		//IL_0041: Expected I4, but got O
		Skin skinData = _skinData;
		if (_skinData != null)
		{
			return skinData._003Chidden_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinBought()
	{
		//IL_0070: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CBoughtSkins_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinCoffinOpen()
	{
		//IL_0070: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003COpenedCoffins_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsSkinUnlocked()
	{
		//IL_0156: Expected I4, but got O
		//IL_013d: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CUnlockedSkinsV2_003Ek__BackingField != null)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CUnlockedSkinsV2_003Ek__BackingField).FindEntry((System.Int32Enum)_characterType);
				if (num < 0)
				{
					return false;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config2._003CUnlockedSkinsV2_003Ek__BackingField != null)
					{
						object obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CUnlockedSkinsV2_003Ek__BackingField).get_Item((System.Int32Enum)_characterType);
						if (obj != null)
						{
							return (byte)(int)((Dictionary<CharacterType, List<SkinType>>)obj).get_Item((CharacterType)_skinType) != 0;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
