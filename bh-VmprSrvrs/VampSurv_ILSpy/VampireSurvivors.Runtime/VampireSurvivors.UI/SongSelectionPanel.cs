using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class SongSelectionPanel : MonoBehaviour
{
	private Image _Icon;

	private TextMeshProUGUI _SongTitle;

	private TextMeshProUGUI _SpeedName;

	private TickBoxUI _LockSelectedBox;

	private SignalBus _signalBus;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private Dictionary<BgmType, MusicData> _musicData;

	private List<BgmModType> _speedList;

	private List<BgmType> _songList;

	private BgmType _selectedSong;

	private BgmModType _selectedSpeed;

	private BgmType _previousSong;

	private int _speedIndex;

	private int _songIndex;

	public static bool UserHasChangedSong;

	private bool _isInitialSet;

	private bool _forceCharacterSongUntilManuallyChanged;

	private float _crossFadeTime;

	private void Construct(SignalBus signalBus, DataManager data, PlayerOptions player, AdventureManager adventureManager)
	{
		_signalBus = signalBus;
		_data = data;
		_playerOptions = player;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	public unsafe void Initialize()
	{
		//IL_0156: Expected O, but got I
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_02b8: Expected O, but got Ref
		//IL_062f: Expected O, but got I
		//IL_0839: Expected O, but got I
		//IL_08b9: Expected O, but got I
		Debug.Log("Initializing");
		AddSpeed(BgmModType.Normal);
		AddSpeed(BgmModType.Hyper);
		AddSpeed(BgmModType.Forsaken);
		List<BgmType> songList = _songList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config = _playerOptions.Config;
		_LockSelectedBox.Initialize(config._003CSelectedBGMSave_003Ek__BackingField);
		PlayerOptionsData config2 = _playerOptions.Config;
		UserHasChangedSong = config2._003CSelectedBGMSave_003Ek__BackingField;
		_isInitialSet = true;
		PlayerOptionsData config3 = _playerOptions.Config;
		List<BgmModType> speedList = _speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		int num = default(int);
		_speedIndex = num;
		_previousSong = _selectedSong;
		List<BgmModType> speedList2 = _speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)num >= (nint)0)
		{
			goto IL_08db;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v65+20+v749 @ rax_v20 (System.Int32)*4]");
		_selectedSpeed = BgmModType.Normal;
		PlayerOptionsData config4 = _playerOptions.Config;
		config4._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
		SetSpeedName();
		PlayerOptionsData config5 = _playerOptions.Config;
		List<ItemType> list = config5._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool active;
		if ((nint)0 == 0)
		{
			active = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			object obj2 = obj3 - -1;
			bool flag = obj2 == null;
			active = !flag;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(active);
		DataManager data = _data;
		_musicData = data._003CAllMusicData_003Ek__BackingField;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			UnlockAllSongsForAdventure();
		}
		BgmType bgmType = BgmType.BGM_Library_Legacy;
		Dictionary<BgmType, MusicData>.Enumerator enumerator = default(Dictionary<BgmType, MusicData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			BgmType bgmType2 = BgmType.BGM_Forest;
			Dictionary<BgmType, MusicData>.Enumerator enumerator2 = (Dictionary<BgmType, MusicData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		PlayerOptions playerOptions = _playerOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A37E6]");
		object obj4 = 0;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0a7b;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0a7b;
		IL_08db:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_0a7b:
		if (playerOptionsData._003CSelectedBGMSave_003Ek__BackingField)
		{
			List<BgmType> songList2 = _songList;
			int num2 = 0;
			int num3 = 0;
			BgmType selectedSong = default(BgmType);
			while (true)
			{
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v94 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				PlayerOptions playerOptions2 = _playerOptions;
				PlayerOptionsData playerOptionsData2;
				if (playerOptions2._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions2._hostGameConfig == null)
					{
						if (playerOptions2._currentAdventureSaveData != null)
						{
							PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
							if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								playerOptionsData2 = currentAdventureSaveData;
								goto IL_0ac2;
							}
						}
						playerOptionsData2 = playerOptions2._mainGameConfig;
					}
					else
					{
						playerOptionsData2 = playerOptions2._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
				}
				goto IL_0ac2;
				IL_0ac2:
				List<BgmType> songList3 = _songList;
				int num5 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)num5 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
					object obj5 = 0;
					BgmType num6 = playerOptionsData2._003CSelectedBGM_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v68+20+v180 @ rsi_v27 (System.Int32)*4]");
					if ((nint)num6 == (nint)0)
					{
						_previousSong = BgmType.NONE;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
						_selectedSong = selectedSong;
						_songIndex = num2;
						SetIcon();
						SetName();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A37E6]");
						obj4 = 0;
					}
					num2++;
					songList2 = _songList;
					bool flag2 = _songList != null;
					num3 = num2;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				goto IL_08db;
			}
		}
		SetIcon();
		SetName();
		SetSpeedName();
	}

	public void Refresh()
	{
		//IL_00d2: Expected O, but got I
		Debug.Log("Refreshing");
		_previousSong = BgmType.NONE;
		PlayerOptionsData config = _playerOptions.Config;
		_selectedSpeed = config._003CSelectedBGMMod_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		_selectedSong = config2._003CSelectedBGM_003Ek__BackingField;
		List<BgmType> songList = _songList;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			if ((nint)num3 < (nint)0)
			{
				List<BgmType> songList2 = _songList;
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
				object obj = 0;
				BgmType selectedSong = _selectedSong;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v13+20+v72 @ rdi_v5 (System.Int32)*4]");
				if ((nint)selectedSong == (nint)0)
				{
					_songIndex = num;
					SetIcon();
					SetName();
				}
				songList = _songList;
				num++;
				num2 = num;
				continue;
			}
			SetSpeedName();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void MakeVisuallyDisabled()
	{
		//IL_000f: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0033: Expected O, but got Ref
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < componentsInChildren.Length)
		{
			componentsInChildren[obj2].color = (Color)(&obj3);
			obj2++;
			obj = obj2;
		}
	}

	public unsafe void MakeVisuallyEnabled()
	{
		//IL_000f: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0033: Expected O, but got Ref
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < componentsInChildren.Length)
		{
			componentsInChildren[obj2].color = (Color)(&obj3);
			obj2++;
			obj = obj2;
		}
	}

	private void UnlockAllSongsForAdventure()
	{
		//IL_0071: Expected O, but got I4
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			return;
		}
		DataManager data = _data;
		Dictionary<StageType, List<StageData>>.KeyCollection keys = data._adventureStageData.Keys;
		Dictionary<BgmType, MusicData>.Enumerator enumerator = default(Dictionary<BgmType, MusicData>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj = 0;
			if (0 == 0)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rbx_v13+28]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rbx_v13+28]");
				if ((nint)0 == 0)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rbx_v13+28]");
				System.Int32Enum value = (System.Int32Enum)((nint)0 >> 32);
				bool flag = Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)keys, value);
				bool flag2 = !flag;
				nint num = 0;
				if (!flag2)
				{
					_ = 1;
					num = 0;
				}
			}
		}
		Dictionary<StageType, List<StageData>>.Enumerator enumerator2 = default(Dictionary<StageType, List<StageData>>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Dictionary<System.Int32Enum, object> dictionary = null;
		}
	}

	private void OnDisable()
	{
		UserHasChangedSong = false;
		_isInitialSet = true;
		MasterAudio safeInstance = MasterAudio.SafeInstance;
		if ((object)safeInstance != null && ((UnityEngine.Object)safeInstance).m_CachedPtr != (IntPtr)0)
		{
			MasterAudio safeInstance2 = MasterAudio.SafeInstance;
			safeInstance2.crossFadeTime = _crossFadeTime;
		}
	}

	private void OnEnable()
	{
		MasterAudio instance = MasterAudio.Instance;
		_crossFadeTime = instance.crossFadeTime;
		MasterAudio instance2 = MasterAudio.Instance;
		instance2.crossFadeTime = 0f;
	}

	public void Stop()
	{
		SoundManager.StopMusic(_selectedSong);
	}

	public void Confirm()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _selectedSong;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
		HostPlayerOptions hostPlayerOptions = HostPlayerOptions._003CInstance_003Ek__BackingField;
		if ((object)HostPlayerOptions._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)hostPlayerOptions).m_CachedPtr != (IntPtr)0)
		{
			HostPlayerOptions hostPlayerOptions2 = HostPlayerOptions._003CInstance_003Ek__BackingField;
			hostPlayerOptions2._003CSelectedBGM_003Ek__BackingField = (int)_selectedSong;
		}
	}

	public void ToggleLockSelected(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGMSave_003Ek__BackingField = b;
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = (byte)(~(config2._003CSelectedBGMSave_003Ek__BackingField ? 1u : 0u)) != 0;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "LOCK SELECTED TRACK : " + text;
		Debug.Log(message);
	}

	public unsafe void SetStage(StageData s)
	{
		//IL_0152: Expected O, but got I
		//IL_0162: Expected O, but got I
		//IL_00ff: Expected I4, but got O
		//IL_02d7: Expected O, but got I
		//IL_01e5: Expected O, but got I
		//IL_022a: Expected O, but got Ref
		if (UserHasChangedSong || _forceCharacterSongUntilManuallyChanged)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedBGMSave_003Ek__BackingField)
		{
			return;
		}
		BgmType bgmType = s._003CBGM_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2._003CSelectedInverse_003Ek__BackingField && (object)s._003CsideBBGM_003Ek__BackingField != null)
		{
			if ((object)s._003CsideBBGM_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new IndexOutOfRangeException();
			}
			bgmType = (BgmType)((object?)s._003CsideBBGM_003Ek__BackingField >> 32);
		}
		if (_isInitialSet)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj = default(object);
			if (obj == null)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rcx_v22+B8]");
				object obj3 = 0;
				string text = (string)obj3;
				PlayerOptionsData config3 = _playerOptions.Config;
				if (((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).TryGetValue((System.Int32Enum)config3._selectedChar, out object value))
				{
					bool flag = ((Dictionary<CharacterType, List<CharacterData>>)value).TryGetValue(config3._selectedChar, out *(List<CharacterData>*)(&value));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v47 (System.Boolean)+100]");
					text = (string)0;
				}
				if (text != null && text._stringLength > 0)
				{
					BgmType bgmType2 = Enum.Parse<BgmType>(text);
					object obj4 = default(object);
					string text2 = ((Enum)(&obj4)).ToString();
					string message = "Found default track for character : " + text2;
					Debug.Log(message);
					_forceCharacterSongUntilManuallyChanged = true;
					_selectedSong = bgmType2;
					UserHasChangedSong = true;
					bgmType = bgmType2;
				}
			}
			_isInitialSet = false;
			BgmType bgmType3 = bgmType;
		}
		List<BgmType> songList = _songList;
		int num = 0;
		bool flag2 = false;
		while (true)
		{
			bool num2 = flag2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			bool flag3 = (nint)(num2 ? 1 : 0) >= (nint)0;
			BgmType bgmType3 = bgmType;
			if (!flag3)
			{
				int num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
				object obj5 = 0;
				BgmType num4 = bgmType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v18+20+v203 @ rdi_v10 (System.Int32)*4]");
				if ((nint)num4 == (nint)0)
				{
					flag2 = (byte)(num + 1) != 0;
					_songIndex = num;
					_selectedSong = bgmType;
					num = (flag2 ? 1 : 0);
				}
				else
				{
					num++;
					flag2 = (byte)num != 0;
				}
				continue;
			}
			SetName();
			SetIcon();
			PlayerOptions playerOptions = _playerOptions;
			PlayerOptionsData playerOptionsData;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig != null)
				{
					PlayerOptionsData hostGameConfig = playerOptions._hostGameConfig;
					hostGameConfig._003CSelectedBGM_003Ek__BackingField = bgmType3;
					return;
				}
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0526;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_0526;
			IL_0526:
			playerOptionsData._003CSelectedBGM_003Ek__BackingField = bgmType3;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public BgmType GetCurrentSelectedTrack()
	{
		return _selectedSong;
	}

	public void PreviousSong()
	{
		//IL_0072: Expected O, but got I
		int songIndex = _songIndex - 1;
		_songIndex = songIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3568]");
		if ((nint)0 < (nint)0)
		{
			List<BgmType> songList = _songList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			int songIndex2 = (int)(-1);
			_songIndex = songIndex2;
		}
		int songIndex3 = _songIndex;
		_previousSong = _selectedSong;
		List<BgmType> songList2 = _songList;
		int songIndex4 = _songIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		if ((nint)songIndex4 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v1+20+v60 @ rcx_v2 (System.Int32)*4]");
			_selectedSong = BgmType.BGM_Forest;
			SetIcon();
			SetName();
			UserHasChangedSong = true;
			PlayAtSpeed();
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = _selectedSong;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void NextSong()
	{
		//IL_0072: Expected O, but got I
		List<BgmType> songList = _songList;
		int num = ++_songIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		if ((nint)num >= (nint)0)
		{
			_songIndex = 0;
		}
		_previousSong = _selectedSong;
		int songIndex = _songIndex;
		int songIndex2 = _songIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		if ((nint)songIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v4+20+v69 @ rcx_v7 (System.Int32)*4]");
			_selectedSong = BgmType.BGM_Forest;
			SetIcon();
			SetName();
			PlayAtSpeed();
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = _selectedSong;
			UserHasChangedSong = true;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void PreviousSpeed()
	{
		//IL_0072: Expected O, but got I
		int speedIndex = _speedIndex - 1;
		_speedIndex = speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A356A]");
		if ((nint)0 < (nint)0)
		{
			List<BgmModType> speedList = _speedList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
			int speedIndex2 = (int)(-1);
			_speedIndex = speedIndex2;
		}
		int speedIndex3 = _speedIndex;
		_previousSong = _selectedSong;
		List<BgmModType> speedList2 = _speedList;
		int speedIndex4 = _speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)speedIndex4 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v1+20+v58 @ rcx_v2 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			SetSpeedName();
			PlayAtSpeed();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void NextSpeed()
	{
		//IL_0072: Expected O, but got I
		List<BgmModType> speedList = _speedList;
		int num = ++_speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)num >= (nint)0)
		{
			_speedIndex = 0;
		}
		_previousSong = _selectedSong;
		int speedIndex = _speedIndex;
		int speedIndex2 = _speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)speedIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v65 @ rcx_v7 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			SetSpeedName();
			PlayAtSpeed();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void SetSpeed(BgmModType speed)
	{
		//IL_006b: Expected O, but got I
		List<BgmModType> speedList = _speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		_previousSong = _selectedSong;
		List<BgmModType> speedList2 = _speedList;
		int num = default(int);
		_speedIndex = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v10+20+v56 @ rax_v10 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			SetSpeedName();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void AddSong(BgmType bgm)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> songList = (List<System.Int32Enum>)(object)_songList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			songList.AddWithResize((System.Int32Enum)bgm);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void AddSpeed(BgmModType bgmMod)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> speedList = (List<System.Int32Enum>)(object)_speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			speedList.AddWithResize((System.Int32Enum)bgmMod);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private unsafe bool GetMusicData(BgmType bgmType, out MusicData musicData)
	{
		//IL_011b: Expected I4, but got O
		ref MusicData reference = ref *(MusicData*)null;
		DataManager data = _data;
		if (_data != null && data._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)bgmType);
			if (num < 0)
			{
				return false;
			}
			DataManager data2 = _data;
			if (_data != null && data2._003CAllMusicData_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)bgmType);
				reference = ref *(MusicData*)obj;
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void PlayAtSpeed()
	{
		//IL_027d: Expected O, but got I4
		//IL_01ea: Expected O, but got I
		//IL_01ff: Expected F4, but got I
		//IL_0214: Expected O, but got I
		//IL_022e: Expected F4, but got I
		//IL_0169: Expected O, but got I
		//IL_017e: Expected F4, but got I
		//IL_0193: Expected O, but got I
		AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = null;
		DataManager data = _data;
		int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)_selectedSong);
		if (num >= 0)
		{
			DataManager data2 = _data;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)_selectedSong);
			obj = obj2;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Hyper)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Forsaken)
			{
				goto IL_0261;
			}
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+58]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v29+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+58]");
			object obj4 = 0;
		}
		else
		{
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+50]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+50]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v24+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_18_v4 (System.Object)+50]");
			object obj4 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v15+14]");
		soundConfig.Detune = 0f;
		goto IL_0261;
		IL_0261:
		soundConfig.Loop = true;
		soundConfig.Volume = (float?)(object)1;
		SoundManager.PlayMusic(_selectedSong, soundConfig);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2CC0");
	}

	private unsafe void SetSpeedName()
	{
		//IL_0093: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		//IL_00b7: Expected O, but got I
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+B8]");
		object newValue = 0;
		string text2 = text.Replace("BGM_", (string)newValue);
		string text3 = text2.ToLowerInvariant();
		string term = "lang/musicMod_" + text3;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_SpeedName.text = translation;
	}

	private void SetIcon()
	{
		//IL_0062: Expected O, but got I
		if (_musicData == null)
		{
			DataManager data = _data;
			_musicData = data._003CAllMusicData_003Ek__BackingField;
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_musicData).get_Item((System.Int32Enum)_selectedSong);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v5 (System.Object)+48]");
		Sprite sprite = SpriteManager.GetSprite((string)0, "UI");
		_Icon.sprite = sprite;
	}

	private unsafe void SetName()
	{
		//IL_00d2: Expected O, but got Ref
		//IL_008e: Expected O, but got I
		if (_musicData == null)
		{
			DataManager data = _data;
			_musicData = data._003CAllMusicData_003Ek__BackingField;
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_musicData).get_Item((System.Int32Enum)_selectedSong);
		object obj2 = default(object);
		string text = ((Enum)(&obj2)).ToString();
		string term = "musicLang/{" + text + "}title";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v5 (System.Object)+10]");
		string text2 = "\"" + (string)0 + "\"";
		_SongTitle.text = text2;
	}

	public SongSelectionPanel()
	{
		List<BgmModType> speedList = new List<BgmModType>();
		_speedList = speedList;
		List<BgmType> songList = new List<BgmType>();
		_songList = songList;
		_selectedSong = BgmType.BGM_Forest_B;
		_previousSong = BgmType.NONE;
		_isInitialSet = true;
	}
}
