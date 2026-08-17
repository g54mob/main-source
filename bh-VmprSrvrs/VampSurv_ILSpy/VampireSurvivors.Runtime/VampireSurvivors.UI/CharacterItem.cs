using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class CharacterItem
{
	private PlayerOptions _playerOptions;

	private CharacterType _characterType;

	private CharacterData _characterData;

	private UIUnlockStates _unlockState;

	private Dictionary<SkinType, SkinItem> _skinItems;

	public UIUnlockStates UnlockState => _unlockState;

	public CharacterType CharacterType => _characterType;

	public CharacterData CharacterData => _characterData;

	public unsafe CharacterItem(PlayerOptions playerOptions, CharacterType characterType, CharacterData characterData)
	{
		//IL_0050: Expected O, but got Ref
		Dictionary<SkinType, SkinItem> skinItems = new Dictionary<SkinType, SkinItem>();
		_skinItems = skinItems;
		_playerOptions = playerOptions;
		_characterType = characterType;
		_characterData = characterData;
		RefreshUnlockState();
		CharacterData characterData2 = _characterData;
		List<Skin>.Enumerator enumerator = default(List<Skin>.Enumerator);
		if (characterData2._003Cskins_003Ek__BackingField != null && enumerator.MoveNext())
		{
			Skin skin = null;
			List<Skin>.Enumerator enumerator2 = (List<Skin>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void RefreshUnlockState()
	{
		CharacterData characterData = _characterData;
		bool flag = _characterData == null;
		PlayerOptions playerOptions = (PlayerOptions)(object)this;
		if (!flag)
		{
			if (characterData._003CalwaysHidden_003Ek__BackingField)
			{
				goto IL_02dd;
			}
			playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					playerOptions = (PlayerOptions)(object)config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						if (playerOptions.PowerUpPurchased != null)
						{
							playerOptions = (PlayerOptions)(object)playerOptions.RunGoldUpdated;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj = default(object);
							if ((nint)obj != -1)
							{
								goto IL_017c;
							}
						}
						CharacterData characterData2 = _characterData;
						if (_characterData != null)
						{
							if (!characterData2._003Csecret_003Ek__BackingField || IsCharacterUnlocked() || IsCharacterBought() || IsCharacterCoffinOpen())
							{
								goto IL_017c;
							}
							goto IL_02dd;
						}
					}
				}
			}
		}
		goto IL_02e9;
		IL_02dd:
		_unlockState = UIUnlockStates.UNAVAILABLE;
		return;
		IL_02e9:
		throw new NullReferenceException();
		IL_017c:
		CharacterData characterData3 = _characterData;
		if (_characterData != null)
		{
			if (characterData3._003Chidden_003Ek__BackingField && !IsCharacterUnlocked() && !IsCharacterBought() && !IsCharacterCoffinOpen())
			{
				_unlockState = UIUnlockStates.UNLOCKABLE;
				return;
			}
			if (IsCharacterUnlocked() && !IsCharacterBought() && !IsCharacterCoffinOpen())
			{
				_unlockState = UIUnlockStates.PURCHASABLE;
				return;
			}
			_unlockState = UIUnlockStates.AVAILABLE;
			if (_skinItems != null)
			{
				Dictionary<SkinType, SkinItem>.Enumerator enumerator = default(Dictionary<SkinType, SkinItem>.Enumerator);
				SkinItem skinItem = default(SkinItem);
				while (true)
				{
					if (enumerator.MoveNext())
					{
						if (skinItem == null)
						{
							break;
						}
						skinItem.RefreshUnlockState();
						continue;
					}
					return;
				}
				throw new NullReferenceException();
			}
		}
		goto IL_02e9;
	}

	public SkinItem GetCurrentSkinItem()
	{
		CharacterData characterData = _characterData;
		if (_characterData != null && _skinItems != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_skinItems).FindEntry((System.Int32Enum)characterData._003CcurrentSkin_003Ek__BackingField);
			if (num < 0)
			{
				return null;
			}
			CharacterData characterData2 = _characterData;
			if (_characterData != null && _skinItems != null)
			{
				return (SkinItem)((Dictionary<System.Int32Enum, object>)(object)_skinItems).get_Item((System.Int32Enum)characterData2._003CcurrentSkin_003Ek__BackingField);
			}
		}
		return (SkinItem)(object)new NullReferenceException();
	}

	public Dictionary<SkinType, SkinItem> GetSkinItems()
	{
		return _skinItems;
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

	public bool IsCharacterAlwaysHidden()
	{
		//IL_0041: Expected I4, but got O
		CharacterData characterData = _characterData;
		if (_characterData != null)
		{
			return characterData._003CalwaysHidden_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharacterSecret()
	{
		//IL_0041: Expected I4, but got O
		CharacterData characterData = _characterData;
		if (_characterData != null)
		{
			return characterData._003Csecret_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharacterHidden()
	{
		//IL_0041: Expected I4, but got O
		CharacterData characterData = _characterData;
		if (_characterData != null)
		{
			return characterData._003Chidden_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharacterBought()
	{
		//IL_0156: Expected I4, but got O
		List<CharacterType> list;
		PlayerOptionsData playerOptionsData;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
				if (playerOptions._currentAdventureSaveData != null)
				{
					list = currentAdventureSaveData._003CBoughtCharacters_003Ek__BackingField;
					goto IL_01ae;
				}
			}
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerOptions playerOptions2;
			if ((object)OnlineStageManager._instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
				playerOptions2 = _playerOptions;
				if (!flag)
				{
					if (_playerOptions == null)
					{
						goto IL_0148;
					}
					playerOptionsData = playerOptions2._mainGameConfig;
					goto IL_01cb;
				}
			}
			else
			{
				playerOptions2 = _playerOptions;
			}
			if (playerOptions2 != null)
			{
				playerOptionsData = playerOptions2.Config;
				goto IL_01cb;
			}
		}
		goto IL_0148;
		IL_01cb:
		if (playerOptionsData == null)
		{
			goto IL_0148;
		}
		list = playerOptionsData._003CBoughtCharacters_003Ek__BackingField;
		goto IL_01ae;
		IL_01ae:
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool result = default(bool);
			return result;
		}
		goto IL_0148;
		IL_0148:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsCharacterCoffinOpen()
	{
		//IL_01e2: Expected I4, but got O
		OnlineStageManager instance = OnlineStageManager._instance;
		PlayerOptions playerOptions;
		PlayerOptionsData playerOptionsData;
		if ((object)OnlineStageManager._instance != null)
		{
			bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
			playerOptions = _playerOptions;
			if (!flag)
			{
				if (_playerOptions != null)
				{
					if (playerOptions._currentAdventureSaveData == null)
					{
						goto IL_014e;
					}
					if (_playerOptions != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if (playerOptions._currentAdventureSaveData != null)
						{
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField == null)
							{
								goto IL_014e;
							}
							if (_playerOptions != null)
							{
								goto IL_0110;
							}
						}
					}
				}
				goto IL_01d4;
			}
		}
		else
		{
			playerOptions = _playerOptions;
		}
		List<CharacterType> list;
		if (playerOptions != null)
		{
			PlayerOptionsData config = playerOptions.Config;
			if (config != null)
			{
				list = config._003COpenedCoffins_003Ek__BackingField;
				goto IL_0227;
			}
		}
		goto IL_01d4;
		IL_014e:
		PlayerOptions playerOptions2 = _playerOptions;
		if (_playerOptions != null)
		{
			playerOptionsData = playerOptions2._mainGameConfig;
			goto IL_0110;
		}
		goto IL_01d4;
		IL_0110:
		if (playerOptionsData == null)
		{
			goto IL_01d4;
		}
		list = playerOptionsData._003COpenedCoffins_003Ek__BackingField;
		goto IL_0227;
		IL_01d4:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0227:
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool result = default(bool);
			return result;
		}
		goto IL_01d4;
	}

	public bool IsCharacterUnlocked()
	{
		//IL_0156: Expected I4, but got O
		List<CharacterType> list;
		PlayerOptionsData playerOptionsData;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
				if (playerOptions._currentAdventureSaveData != null)
				{
					list = currentAdventureSaveData._003CUnlockedCharacters_003Ek__BackingField;
					goto IL_01ae;
				}
			}
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerOptions playerOptions2;
			if ((object)OnlineStageManager._instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
				playerOptions2 = _playerOptions;
				if (!flag)
				{
					if (_playerOptions == null)
					{
						goto IL_0148;
					}
					playerOptionsData = playerOptions2._mainGameConfig;
					goto IL_01cb;
				}
			}
			else
			{
				playerOptions2 = _playerOptions;
			}
			if (playerOptions2 != null)
			{
				playerOptionsData = playerOptions2.Config;
				goto IL_01cb;
			}
		}
		goto IL_0148;
		IL_01cb:
		if (playerOptionsData == null)
		{
			goto IL_0148;
		}
		list = playerOptionsData._003CUnlockedCharacters_003Ek__BackingField;
		goto IL_01ae;
		IL_01ae:
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool result = default(bool);
			return result;
		}
		goto IL_0148;
		IL_0148:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasCharacterRequirements()
	{
		//IL_009a: Expected I4, but got O
		CharacterData characterData = _characterData;
		if (_characterData != null)
		{
			if ((object)characterData._003CrequiresRelic_003Ek__BackingField == null)
			{
				return true;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					bool result = default(bool);
					return result;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasCharacterRequirementsOrUnlock()
	{
		//IL_00dc: Expected I4, but got O
		CharacterData characterData = _characterData;
		if (_characterData != null)
		{
			if ((object)characterData._003CrequiresRelic_003Ek__BackingField == null)
			{
				goto IL_00c8;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					object obj = default(object);
					if (obj == null && !IsCharacterUnlocked())
					{
						return IsCharacterBought();
					}
					goto IL_00c8;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00c8:
		return true;
	}
}
