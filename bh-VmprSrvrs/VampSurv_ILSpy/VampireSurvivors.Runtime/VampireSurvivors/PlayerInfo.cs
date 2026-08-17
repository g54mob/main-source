using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public class PlayerInfo : MonoBehaviour
{
	private bool _003CIsReadyToStartCharacterSelect_003Ek__BackingField;

	private int _003CUiPageId_003Ek__BackingField;

	private string _003CUserName_003Ek__BackingField;

	public Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> OnLevelUpSuggestedCallback;

	private bool _003CUpdateAverageLatency_003Ek__BackingField;

	public Action<CharacterType> OnCharacterSelectionChanged;

	public Action<SkinType> OnSkinSelectionChanged;

	private CharacterType _selectedCharacter;

	private SkinType _skinType;

	private bool _isReadyToPlay;

	private bool _sceneLoaded;

	private bool _gameplayLoaded;

	private bool _stageInitialized;

	private CoherenceSync _characterEntity;

	private VampireSurvivors.Objects.Characters.CharacterController _characterController;

	private CoherenceSync _coherenceSync;

	private int _averageLatencyMs;

	private int _suggestedLevelUp;

	private List<byte[]> _powerUpChunks;

	private Dictionary<PowerUpType, PlayerStat> _hostPowerUps;

	private bool _isInBanishMode;

	private bool _hasGameplayUiActive;

	public bool IsReadyToStartCharacterSelect
	{
		get
		{
			return _003CIsReadyToStartCharacterSelect_003Ek__BackingField;
		}
		set
		{
			_003CIsReadyToStartCharacterSelect_003Ek__BackingField = value;
		}
	}

	public int SelectedCharacter
	{
		get
		{
			return (int)_selectedCharacter;
		}
		set
		{
			_selectedCharacter = (CharacterType)value;
		}
	}

	public int SelectedSkin
	{
		get
		{
			return (int)_skinType;
		}
		set
		{
			_skinType = (SkinType)value;
		}
	}

	public bool IsReadyToPlay
	{
		get
		{
			return _isReadyToPlay;
		}
		set
		{
			_isReadyToPlay = value;
		}
	}

	public bool SceneLoaded
	{
		get
		{
			return _sceneLoaded;
		}
		set
		{
			_sceneLoaded = value;
		}
	}

	public bool GameplayLoaded
	{
		get
		{
			return _gameplayLoaded;
		}
		set
		{
			_gameplayLoaded = value;
		}
	}

	public bool StageInitialized
	{
		get
		{
			return _stageInitialized;
		}
		set
		{
			_stageInitialized = value;
		}
	}

	public CoherenceSync CharacterEntity
	{
		get
		{
			return _characterEntity;
		}
		set
		{
			_characterEntity = value;
		}
	}

	public int AverageLatencyMs
	{
		get
		{
			return _averageLatencyMs;
		}
		set
		{
			_averageLatencyMs = value;
		}
	}

	public int SuggestedLevelUp
	{
		get
		{
			return _suggestedLevelUp;
		}
		set
		{
			_suggestedLevelUp = value;
		}
	}

	public bool IsInBanishMode
	{
		get
		{
			return _isInBanishMode;
		}
		set
		{
			_isInBanishMode = value;
		}
	}

	public bool HasGameplayUiActive
	{
		get
		{
			return _hasGameplayUiActive;
		}
		set
		{
			_hasGameplayUiActive = value;
		}
	}

	public int UiPageId
	{
		get
		{
			return _003CUiPageId_003Ek__BackingField;
		}
		set
		{
			_003CUiPageId_003Ek__BackingField = value;
		}
	}

	public string UserName
	{
		get
		{
			return _003CUserName_003Ek__BackingField;
		}
		set
		{
			_003CUserName_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController CharacterController
	{
		get
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
			if ((object)_characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
			{
				CoherenceSync characterEntity = _characterEntity;
				if ((object)_characterEntity != null && ((UnityEngine.Object)characterEntity).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_characterEntity == null)
					{
						return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
					}
					VampireSurvivors.Objects.Characters.CharacterController component = _characterEntity.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
					_characterController = component;
				}
			}
			return _characterController;
		}
	}

	public bool UpdateAverageLatency
	{
		get
		{
			return _003CUpdateAverageLatency_003Ek__BackingField;
		}
		set
		{
			_003CUpdateAverageLatency_003Ek__BackingField = value;
		}
	}

	public bool HasStateAuthority
	{
		get
		{
			//IL_00c0: Expected I4, but got O
			//IL_0098: Expected O, but got I
			CoherenceSync coherenceSync = _coherenceSync;
			if ((object)_coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_00b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v4 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v4 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						return obj == null;
					}
				}
				return true;
			}
			goto IL_00b2;
			IL_00b2:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public void OnCharacterUpdate(int oldCharacter, int newCharacter)
	{
		Action<CharacterType> onCharacterSelectionChanged = OnCharacterSelectionChanged;
		if (OnCharacterSelectionChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Data.CharacterType>)+18] (should have been resolved before IL gen)");
		}
	}

	public void OnSkinUpdate(int oldSkin, int newSkin)
	{
		Action<SkinType> onSkinSelectionChanged = OnSkinSelectionChanged;
		if (OnSkinSelectionChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Data.SkinType>)+18] (should have been resolved before IL gen)");
		}
	}

	public void OnLevelUpSuggested(int old, int newSuggestion)
	{
		Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> onLevelUpSuggestedCallback = OnLevelUpSuggestedCallback;
		if (OnLevelUpSuggestedCallback != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = CharacterController;
			int seatNumberForCharacter = OnlineStageManager._instance.GetSeatNumberForCharacter(characterController);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = CharacterController;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6 @ rsi_v1 (System.Action`3<System.Int32, System.Int32, VampireSurvivors.Objects.Characters.CharacterController>)+18] (should have been resolved before IL gen)");
		}
	}

	public void ResetGameSession()
	{
		Debug.Log("Resetting Player Info Session Variables");
		_sceneLoaded = false;
		_stageInitialized = false;
	}

	private void Awake()
	{
		CoherenceSync component = GetComponent<CoherenceSync>();
		_coherenceSync = component;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IBaseAccount currentSystem = sInstance.m_CurrentSystem;
		_003CUserName_003Ek__BackingField = currentSystem.m_Name;
	}

	private void Update()
	{
		//IL_0174: Expected I4, but got O
		//IL_00a0: Expected O, but got I
		//IL_0106: Expected I, but got O
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_011e: Unsupported input type for neg.
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_01f6: Expected I4, but got O
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800045A0");
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v16 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v16 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v16 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (!_003CUpdateAverageLatency_003Ek__BackingField)
		{
			return;
		}
		object obj2 = default(object);
		object obj4 = default(object);
		int averageLatencyMs;
		if (obj2 != null)
		{
			nint num = (nint)typeof(Math);
			object obj3 = _averageLatencyMs - obj4;
			object obj5 = 0 - obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				obj5 = obj3;
			}
			bool flag3 = (nint)obj5 > 10;
			averageLatencyMs = (int)obj4;
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			bool flag4 = (nint)obj4 <= _averageLatencyMs;
			averageLatencyMs = (int)obj4;
			if (flag4)
			{
				return;
			}
		}
		_averageLatencyMs = averageLatencyMs;
	}

	public PlayerInfo()
	{
		//IL_000f: Expected I4, but got I8
		//IL_002f: Expected I, but got O
		_003CUiPageId_003Ek__BackingField = -1;
		_003CUpdateAverageLatency_003Ek__BackingField = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
