using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class StatsPanelUI : MonoBehaviour
{
	private StatItemUI _StatPrefab;

	private RectTransform _Container;

	private List<StatItemUI> _StatObjects;

	private bool _hasLoaded;

	private PlayerStats _stats;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private EggManager _eggManager;

	private MultiplayerManager _multiplayer;

	private AdventureManager _adventureManager;

	private Dictionary<PowerUpType, PlayerStat> _playerStats;

	private Dictionary<PowerUpType, List<PowerUpData>> _powerUps;

	private CharacterData _currentCharacter;

	private CharacterType _currentCharacterType;

	private VampireSurvivors.Objects.Characters.CharacterController _inGameCharacter;

	private List<TextMeshProUGUI> _statTextLines;

	private bool _isInGame;

	private bool _useEggs;

	private void Construct(PlayerStats stats, DataManager data, PlayerOptions playerOptions, EggManager egg, MultiplayerManager multi, AdventureManager adventureManager)
	{
		_stats = stats;
		_dataManager = data;
		_playerOptions = playerOptions;
		EggManager eggManager = default(EggManager);
		_eggManager = eggManager;
		MultiplayerManager multiplayer = default(MultiplayerManager);
		_multiplayer = multiplayer;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	public void Initialize()
	{
		//IL_0046: Expected I4, but got I8
		if (!_hasLoaded)
		{
			Populate();
		}
		TextAutoSizeHelper.UpdateTextSizes(_statTextLines, -1);
	}

	public void SetCharacter(CharacterData character, CharacterType type, VampireSurvivors.Objects.Characters.CharacterController ingameCharacter = null)
	{
		_currentCharacter = character;
		_currentCharacterType = type;
		_inGameCharacter = ingameCharacter;
		VampireSurvivors.Objects.Characters.CharacterController inGameCharacter = _inGameCharacter;
		if ((object)_inGameCharacter == null || ((UnityEngine.Object)inGameCharacter).m_CachedPtr == (IntPtr)0)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				GameSessionData gameSessionData = core2._gameSessionData;
				_inGameCharacter = gameSessionData._activeCharacter;
			}
		}
		SetValues();
	}

	public void Refresh()
	{
		SetValues();
	}

	public void EggsToggled()
	{
		SetValues();
	}

	private void Populate()
	{
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		_powerUps = convertedPowerUpData;
		List<TextMeshProUGUI> statTextLines = _statTextLines;
		int version = statTextLines._version + 1;
		statTextLines._version = version;
		statTextLines._size = 0;
		if (statTextLines._size > 0)
		{
			Array.Clear(statTextLines._items, 0, statTextLines._size);
		}
		List<StatItemUI>.Enumerator enumerator = default(List<StatItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			StatItemUI statItemUI = null;
			throw new NullReferenceException();
		}
		_hasLoaded = true;
	}

	private void AddStat(PowerUpType type, PowerUpData data, float val)
	{
		GameObject original = _StatPrefab.gameObject;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, _Container);
		StatItemUI component = gameObject.GetComponent<StatItemUI>();
		component.SetData(data, type);
	}

	private unsafe void SetValues()
	{
		//IL_019a: Expected F4, but got I4
		//IL_01ac: Expected O, but got Ref
		Dictionary<PowerUpType, PlayerStat> ownedPowerUps = _stats.GetOwnedPowerUps();
		_playerStats = ownedPowerUps;
		_useEggs = false;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			bool flag = config2._003CCharacterEggInfo_003Ek__BackingField == null;
			int num = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)_currentCharacterType);
			if (!flag)
			{
				int playerCount = _multiplayer.GetPlayerCount();
				if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
				{
					if (((Dictionary<CharacterType, Dictionary<string, float>>)(object)_multiplayer).FindEntry(CharacterType.VOID) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ rax_v170 (System.Int32)+10]");
						if ((nint)0 != 0)
						{
							goto IL_0ab2;
						}
					}
					_useEggs = true;
				}
			}
		}
		goto IL_0ab2;
		IL_0ab2:
		List<StatItemUI> statObjects = _StatObjects;
		int num2 = 0;
		float num3 = 0f;
		List<StatItemUI>.Enumerator enumerator = default(List<StatItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			StatItemUI statItemUI = null;
			List<StatItemUI>.Enumerator enumerator2 = (List<StatItemUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private float GetPowerUpStatValue(PlayerStat playerStat)
	{
		//IL_0262: Expected F4, but got I4
		//IL_0054: Expected O, but got I8
		//IL_005d: Expected O, but got I4
		//IL_0254: Expected F4, but got I4
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_019d: Expected I, but got O
		//IL_0237: Expected O, but got I8
		DataManager dataManager = _dataManager;
		bool flag = dataManager._003CAllPowerUps_003Ek__BackingField == null;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllPowerUps_003Ek__BackingField).FindEntry((System.Int32Enum)playerStat._Type);
		if (!flag)
		{
			object obj = 6442450944L;
			object obj2 = 0;
			JToken jToken = default(JToken);
			while (true)
			{
				if ((nint)obj2 < playerStat._Level)
				{
					DataManager dataManager2 = _dataManager;
					if (_dataManager != null)
					{
						if (dataManager2._003CAllPowerUps_003Ek__BackingField != null)
						{
							object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllPowerUps_003Ek__BackingField).get_Item((System.Int32Enum)playerStat._Type);
							if (obj3 != null)
							{
								int count = ((JContainer)obj3).Count;
								if ((nint)obj2 < count)
								{
									DataManager dataManager3 = _dataManager;
									if (_dataManager == null)
									{
										throw new NullReferenceException();
									}
									if (dataManager3._003CAllPowerUps_003Ek__BackingField == null)
									{
										throw new NullReferenceException();
									}
									object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllPowerUps_003Ek__BackingField).get_Item((System.Int32Enum)playerStat._Type);
									if (obj4 == null)
									{
										throw new NullReferenceException();
									}
									nint num2 = (nint)obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ r8_v16 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
									if (jToken == null)
									{
										break;
									}
									object obj5 = jToken.ToObject<object>();
									if (obj5 != null)
									{
										PowerUpType type = playerStat._Type;
										if (playerStat._Type <= PowerUpType.BANISH)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r14_v10+6DB1364+v398 @ rcx_v19 (VampireSurvivors.Data.PowerUpType)*4]");
											object obj6 = 0 + 6442450944L;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v390 @ rdx_v18 (should have been resolved before IL gen)");
										}
									}
								}
								obj2++;
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				return 0f;
			}
			throw new NullReferenceException();
		}
		return 0f;
	}

	private float CheckForOmni(Dictionary<PowerUpType, PlayerStat> playerStat, PowerUpType type)
	{
		//IL_00e6: Expected I, but got O
		DataManager dataManager = _dataManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 61 Invalid \"Jump target not found in method: 0x186DB173E\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 73 Invalid \"Jump target not found in method: 0x186DB173E\"");
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllPowerUps_003Ek__BackingField).FindEntry((System.Int32Enum)23);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 82 Invalid \"Jump target not found in method: 0x186DB1739\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 94 Invalid \"Jump target not found in method: 0x186DB173E\"");
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 107 Invalid \"Jump target not found in method: 0x186DB173E\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 119 Invalid \"Jump target not found in method: 0x186DB173E\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 133 Invalid \"Jump target not found in method: 0x186DB1739\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 148 Invalid \"Jump target not found in method: 0x186DB173E\"");
		object obj = ((Dictionary<System.Int32Enum, object>)(object)playerStat).get_Item((System.Int32Enum)23);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 164 Invalid \"Jump target not found in method: 0x186DB173E\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x186DB1720\"");
		DataManager dataManager2 = _dataManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 188 Invalid \"Jump target not found in method: 0x186DB1763\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 200 Invalid \"Jump target not found in method: 0x186DB175E\"");
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllPowerUps_003Ek__BackingField).get_Item((System.Int32Enum)23);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 214 Invalid \"Jump target not found in method: 0x186DB1759\"");
		int count = ((JContainer)obj2).Count;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 229 Invalid \"Jump target not found in method: 0x186DB16AC\"");
		DataManager dataManager3 = _dataManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 241 Invalid \"Jump target not found in method: 0x186DB1754\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 253 Invalid \"Jump target not found in method: 0x186DB174F\"");
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllPowerUps_003Ek__BackingField).get_Item((System.Int32Enum)23);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 268 Invalid \"Jump target not found in method: 0x186DB174A\"");
		nint num2 = (nint)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v263 @ r8_v6 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 284 Invalid \"Jump target not found in method: 0x186DB1744\"");
		JToken jToken = default(JToken);
		object obj4 = jToken.ToObject<object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 298 Invalid \"Jump target not found in method: 0x186DB16AA\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 312 Invalid \"Jump target not found in method: 0x186DB169B\"");
		float result = default(float);
		return result;
	}

	private float GetPowerUpStatValueByType(PowerUpType powerUpType, ModifierStats modifierStats)
	{
		//IL_0054: Expected F4, but got I4
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (powerUpType <= PowerUpType.BANISH)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+6DB197C+powerUpType @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 0f;
	}

	private float GetCharacterValueFromPowerUpType(PowerUpType type)
	{
		//IL_00ae: Expected O, but got I8
		//IL_00c8: Expected O, but got I8
		//IL_0060: Expected O, but got I8
		//IL_007a: Expected O, but got I8
		while (true)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
			{
				if (type > PowerUpType.BANISH)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rcx_v11+6DB23C4+type @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v201 @ rax_v13 (should have been resolved before IL gen)");
			}
			if (type > PowerUpType.BANISH)
			{
				break;
			}
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v9+6DB2420+type @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v167 @ rax_v10 (should have been resolved before IL gen)");
		}
		return -1f;
	}

	private float GetSkinStat(PowerUpType type)
	{
		//IL_009f: Expected F4, but got I4
		//IL_0075: Expected O, but got I8
		//IL_008f: Expected O, but got I8
		if (_currentCharacter != null)
		{
			Skin currentSkinData = _currentCharacter.GetCurrentSkinData();
			if (currentSkinData != null && type <= PowerUpType.BANISH)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v1+6DB25EC+type @ rdx (VampireSurvivors.Data.PowerUpType)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ rdx_v4 (should have been resolved before IL gen)");
			}
		}
		return 0f;
	}

	public StatsPanelUI()
	{
		List<StatItemUI> statObjects = new List<StatItemUI>();
		_StatObjects = statObjects;
		List<TextMeshProUGUI> statTextLines = new List<TextMeshProUGUI>();
		_statTextLines = statTextLines;
	}
}
