using System;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects;

public class PlayerOptions : IInitializable, IDisposable
{
	public delegate void OnValueChanged();

	public delegate void OnInitialized();

	private static OnValueChanged m_GoldUpdated;

	private OnValueChanged m_RunGoldUpdated;

	private OnValueChanged m_PowerUpPurchased;

	private OnValueChanged m_PowerUpsRefunded;

	private static OnValueChanged m_AdventureStarsUpdated;

	private SignalBus _signalBus;

	private GameSessionData _gameSessionData;

	private DataManager _dataManager;

	private PlayerStats _playerStats;

	private AdventureManager _adventureManager;

	private PlayerOptionsData _mainGameConfig;

	private PlayerOptionsData _hostGameConfig;

	private PlayerOptionsData _hostGameConfigAtRunStart;

	private PlayerOptionsData _onlineClientWithRunDataConfig;

	private OnInitialized m_PlayerOptionsInitialized;

	public const string USER_OPTIONS = "USER_OPTIONS";

	private static readonly ProfilerMarker MarkerSave;

	private PlayerOptionsData _currentAdventureSaveData;

	private bool _003CJustGotTrumpet_003Ek__BackingField;

	private bool _003CJustGotMirror_003Ek__BackingField;

	private bool _003CJustGotJubilee_003Ek__BackingField;

	private bool _003CIsInitialized_003Ek__BackingField;

	private List<DlcType> XanthiaDLCList;

	public DataManager dataManager => _dataManager;

	public PlayerOptionsData MainGameConfig => _mainGameConfig;

	public bool IsConfigReady
	{
		get
		{
			if (_currentAdventureSaveData != null)
			{
				PlayerOptionsData currentAdventureSaveData = _currentAdventureSaveData;
				if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
				{
					return true;
				}
			}
			bool flag = (nint)_mainGameConfig < 0;
			bool flag2 = _mainGameConfig == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	public PlayerOptionsData ConfigDuringRun
	{
		get
		{
			PlayerOptionsData playerOptionsData;
			if (_hostGameConfig == null)
			{
				if (_currentAdventureSaveData != null)
				{
					playerOptionsData = _currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_008b;
					}
				}
				return _mainGameConfig;
			}
			playerOptionsData = _hostGameConfig;
			goto IL_008b;
			IL_008b:
			return playerOptionsData;
		}
	}

	public PlayerOptionsData Config
	{
		get
		{
			PlayerOptionsData playerOptionsData;
			if (_onlineClientWithRunDataConfig == null)
			{
				if (_hostGameConfig == null)
				{
					if (_currentAdventureSaveData != null)
					{
						playerOptionsData = _currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_00b4;
						}
					}
					return _mainGameConfig;
				}
				return _hostGameConfig;
			}
			playerOptionsData = _onlineClientWithRunDataConfig;
			goto IL_00b4;
			IL_00b4:
			return playerOptionsData;
		}
	}

	public PlayerStats PlayerStats => _playerStats;

	public bool JustGotTrumpet
	{
		get
		{
			return _003CJustGotTrumpet_003Ek__BackingField;
		}
		set
		{
			_003CJustGotTrumpet_003Ek__BackingField = value;
		}
	}

	public bool JustGotMirror
	{
		get
		{
			return _003CJustGotMirror_003Ek__BackingField;
		}
		set
		{
			_003CJustGotMirror_003Ek__BackingField = value;
		}
	}

	public bool JustGotJubilee
	{
		get
		{
			return _003CJustGotJubilee_003Ek__BackingField;
		}
		set
		{
			_003CJustGotJubilee_003Ek__BackingField = value;
		}
	}

	public bool IsInitialized
	{
		get
		{
			return _003CIsInitialized_003Ek__BackingField;
		}
		set
		{
			_003CIsInitialized_003Ek__BackingField = value;
		}
	}

	public bool IsInvertedWithVisuals
	{
		get
		{
			//IL_0091: Expected I4, but got O
			PlayerOptionsData config = Config;
			if (config != null)
			{
				if (!config._003CSelectedInverse_003Ek__BackingField)
				{
					return false;
				}
				PlayerOptionsData config2 = Config;
				if (config2 != null)
				{
					return config2._003CVisuallyInvertStages_003Ek__BackingField;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public PlayerOptionsData CurrentAdventureSaveData
	{
		get
		{
			return _currentAdventureSaveData;
		}
		set
		{
			_currentAdventureSaveData = value;
			OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
			if (PlayerOptions.m_GoldUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v116.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public static event OnValueChanged GoldUpdated
	{
		add
		{
			Delegate obj = PlayerOptions.m_GoldUpdated;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnValueChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == PlayerOptions.m_GoldUpdated;
				Delegate obj4;
				if ((object)obj == PlayerOptions.m_GoldUpdated)
				{
					PlayerOptions.m_GoldUpdated = (OnValueChanged)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = PlayerOptions.m_GoldUpdated;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = PlayerOptions.m_GoldUpdated;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnValueChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == PlayerOptions.m_GoldUpdated;
				Delegate obj4;
				if ((object)obj == PlayerOptions.m_GoldUpdated)
				{
					PlayerOptions.m_GoldUpdated = (OnValueChanged)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = PlayerOptions.m_GoldUpdated;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnValueChanged RunGoldUpdated
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_RunGoldUpdated;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_RunGoldUpdated;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnValueChanged PowerUpPurchased
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 24;
			Delegate obj2 = this.m_PowerUpPurchased;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 24;
			Delegate obj2 = this.m_PowerUpPurchased;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnValueChanged PowerUpsRefunded
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 32;
			Delegate obj2 = this.m_PowerUpsRefunded;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 32;
			Delegate obj2 = this.m_PowerUpsRefunded;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event OnValueChanged AdventureStarsUpdated
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_00ea: Expected O, but got I
			Delegate obj = PlayerOptions.m_AdventureStarsUpdated;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnValueChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(PlayerOptions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_00ea: Expected O, but got I
			Delegate obj = PlayerOptions.m_AdventureStarsUpdated;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnValueChanged);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(PlayerOptions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnInitialized PlayerOptionsInitialized
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 112;
			Delegate obj2 = this.m_PlayerOptionsInitialized;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnInitialized);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 112;
			Delegate obj2 = this.m_PlayerOptionsInitialized;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnInitialized);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public void Initialize()
	{
		//IL_0099: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_01d5: Expected O, but got I
		//IL_01f9: Expected O, but got I
		//IL_02ed: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_0414: Expected O, but got I4
		//IL_0414: Expected O, but got I
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_12db: Expected O, but got I
		//IL_052a: Expected O, but got I4
		//IL_052a: Expected O, but got I
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_1314: Expected O, but got I
		//IL_0640: Expected O, but got I4
		//IL_0640: Expected O, but got I
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected O, but got Unknown
		//IL_134d: Expected O, but got I
		//IL_0756: Expected O, but got I4
		//IL_0756: Expected O, but got I
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Expected O, but got Unknown
		//IL_1386: Expected O, but got I
		//IL_07e0: Expected O, but got I
		//IL_0843: Expected O, but got I
		//IL_0890: Expected O, but got I4
		//IL_0890: Expected O, but got I
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Expected O, but got Unknown
		//IL_13bf: Expected O, but got I
		//IL_09a6: Expected O, but got I4
		//IL_09a6: Expected O, but got I
		//IL_09af: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		//IL_13f8: Expected O, but got I
		//IL_0abc: Expected O, but got I4
		//IL_0abc: Expected O, but got I
		//IL_0ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Expected O, but got Unknown
		//IL_1431: Expected O, but got I
		//IL_0bc3: Expected O, but got I
		//IL_0be7: Expected O, but got I
		//IL_0cdb: Expected O, but got I
		//IL_0cff: Expected O, but got I
		//IL_0df3: Expected O, but got I
		//IL_0e17: Expected O, but got I
		//IL_0f0b: Expected O, but got I
		//IL_0f2f: Expected O, but got I
		//IL_1023: Expected O, but got I
		//IL_1047: Expected O, but got I
		//IL_113b: Expected O, but got I
		//IL_115f: Expected O, but got I
		//IL_1253: Expected O, but got I
		//IL_1277: Expected O, but got I
		Action action = InitSession;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2530");
		Action<UISignals.ConfirmCharacterSignal> action2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA26B0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v5 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ConfirmCharacterSignal>)obj)._003CSubscribeId_003Eb__0;
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v17 (System.Object)+10]");
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(typeFromHandle, (object)null, (object)0, callback);
		Action<UISignals.ConfirmStageSelectionSignal> action4 = null;
		((PlayerOptions)(object)action4).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		((PlayerOptions)(object)_signalBus).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)action4);
		Action<UISignals.SetDamageNumbersSignal> action5 = null;
		((PlayerOptions)(object)action5).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ rbx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v10 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((PlayerOptions)0).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
			}
		}
		object obj2 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetDamageNumbersSignal>)obj2)._003CSubscribeId_003Eb__0;
		Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v35 (System.Object)+10]");
		signalBus2.SubscribeInternal(typeFromHandle2, (object)null, (object)0, callback);
		Action<UISignals.SetGlimmerCarouselSignal> action7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2870");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rbx_v13 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rbx_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj3 = null;
		Action<object> action8 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetGlimmerCarouselSignal>)obj3)._003CSubscribeId_003Eb__0;
		Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v50 (System.Object)+10]");
		signalBus3.SubscribeInternal(typeFromHandle3, (object)null, (object)0, callback);
		Action<UISignals.SetSFXVolumeSignal> action9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2950");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ rbx_v17 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v18 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj4 = null;
		Action<object> action10 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetSFXVolumeSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetSFXVolumeSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v65 (System.Object)+10]");
		Type signalType = default(Type);
		signalBus4.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<UISignals.SetMusicVolumeSignal> action11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2A30");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ rbx_v21 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v22 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj7 = null;
		Action<object> action12 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetMusicVolumeSignal>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetMusicVolumeSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus5 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v80 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus5.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action<UISignals.SetFlashingVFXSignal> action13 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2B10");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1752 @ rbx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rbx_v26 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj10 = null;
		Action<object> action14 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetFlashingVFXSignal>)obj10)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetFlashingVFXSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus6 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v95 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus6.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		Action<UISignals.SetStreamerSafeMusicSignal> action15 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2BF0");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rbx_v29 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rbx_v30 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rbx_v30 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj13 = null;
		Action<object> action16 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetStreamerSafeMusicSignal>)obj13)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetStreamerSafeMusicSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj15 = default(object);
		object obj14 = obj15 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus7 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v110 (System.Object)+10]");
		Type signalType4 = default(Type);
		signalBus7.SubscribeInternal(signalType4, (object)null, (object)0, callback);
		Action<UISignals.SetVisibleJoysticksSignal> action17 = null;
		((PlayerOptions)(object)action17).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		((PlayerOptions)(object)_signalBus).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)action17);
		Action<UISignals.CharacterUnlockedSignal> action18 = null;
		((PlayerOptions)(object)action18).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2176 @ rbx_v34 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		}
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v35 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v35 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((PlayerOptions)0).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
			}
		}
		object obj16 = null;
		Action<object> action19 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterUnlockedSignal>)obj16)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterUnlockedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus8 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v128 (System.Object)+10]");
		Type signalType5 = default(Type);
		signalBus8.SubscribeInternal(signalType5, (object)null, (object)0, callback);
		Action<UISignals.CharacterBoughtSignal> action20 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2F30");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2385 @ rbx_v38 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v39 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rbx_v39 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj19 = null;
		Action<object> action21 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterBoughtSignal>)obj19)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.CharacterBoughtSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj21 = default(object);
		object obj20 = obj21 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus9 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v143 (System.Object)+10]");
		Type signalType6 = default(Type);
		signalBus9.SubscribeInternal(signalType6, (object)null, (object)0, callback);
		Action<UISignals.SkinBoughtSignal> action22 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3010");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2594 @ rbx_v42 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v43 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v43 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj22 = null;
		Action<object> action23 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SkinBoughtSignal>)obj22)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SkinBoughtSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj24 = default(object);
		object obj23 = obj24 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus10 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v158 (System.Object)+10]");
		Type signalType7 = default(Type);
		signalBus10.SubscribeInternal(signalType7, (object)null, (object)0, callback);
		Action<UISignals.StageUnlockedSignal> action24 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA30F0");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2803 @ rbx_v46 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rbx_v47 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rbx_v47 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj25 = null;
		Action<object> action25 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.StageUnlockedSignal>)obj25)._003CSubscribeId_003Eb__0;
		Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus11 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v173 (System.Object)+10]");
		signalBus11.SubscribeInternal(typeFromHandle4, (object)null, (object)0, callback);
		Action<UISignals.WeaponUnlockedSignal> action26 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA31D0");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2906 @ rbx_v50 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rbx_v51 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rbx_v51 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj26 = null;
		Action<object> action27 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.WeaponUnlockedSignal>)obj26)._003CSubscribeId_003Eb__0;
		Type typeFromHandle5 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus12 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v188 (System.Object)+10]");
		signalBus12.SubscribeInternal(typeFromHandle5, (object)null, (object)0, callback);
		Action<UISignals.BuyPowerUpSignal> action28 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA32B0");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3009 @ rbx_v54 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v55 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v55 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj27 = null;
		Action<object> action29 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.BuyPowerUpSignal>)obj27)._003CSubscribeId_003Eb__0;
		Type typeFromHandle6 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus13 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v203 (System.Object)+10]");
		signalBus13.SubscribeInternal(typeFromHandle6, (object)null, (object)0, callback);
		Action<UISignals.RefundPowerUpsSignal> action30 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3390");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3112 @ rbx_v58 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rbx_v59 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rbx_v59 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj28 = null;
		Action<object> action31 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.RefundPowerUpsSignal>)obj28)._003CSubscribeId_003Eb__0;
		Type typeFromHandle7 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus14 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v218 (System.Object)+10]");
		signalBus14.SubscribeInternal(typeFromHandle7, (object)null, (object)0, callback);
		Action<UISignals.LanguageSelectedSignal> action32 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3470");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3215 @ rbx_v62 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rbx_v63 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rbx_v63 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj29 = null;
		Action<object> action33 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.LanguageSelectedSignal>)obj29)._003CSubscribeId_003Eb__0;
		Type typeFromHandle8 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus15 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v233 (System.Object)+10]");
		signalBus15.SubscribeInternal(typeFromHandle8, (object)null, (object)0, callback);
		Action<UISignals.SetFullscreenSignal> action34 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3550");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3318 @ rbx_v66 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rbx_v67 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rbx_v67 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj30 = null;
		Action<object> action35 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetFullscreenSignal>)obj30)._003CSubscribeId_003Eb__0;
		Type typeFromHandle9 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus16 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ rax_v248 (System.Object)+10]");
		signalBus16.SubscribeInternal(typeFromHandle9, (object)null, (object)0, callback);
		Action<UISignals.ToggleStageProgressionSignal> action36 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3630");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3421 @ rbx_v70 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rbx_v71 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rbx_v71 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj31 = null;
		Action<object> action37 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleStageProgressionSignal>)obj31)._003CSubscribeId_003Eb__0;
		Type typeFromHandle10 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus17 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v263 (System.Object)+10]");
		signalBus17.SubscribeInternal(typeFromHandle10, (object)null, (object)0, callback);
		Action<UISignals.ToggleMovingBackgroundSignal> action38 = null;
		((PlayerOptions)(object)action38).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)this);
		((PlayerOptions)(object)_signalBus).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)action38);
	}

	public void Dispose()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_013f: Expected O, but got I
		//IL_018b: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_0301: Expected O, but got I
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_067c: Expected O, but got I
		//IL_06b7: Expected O, but got I
		//IL_06d2: Expected O, but got I4
		//IL_06d2: Expected O, but got I
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Expected O, but got Unknown
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Expected O, but got Unknown
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Expected O, but got Unknown
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c8: Expected O, but got Unknown
		//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Expected O, but got Unknown
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf6: Expected O, but got Unknown
		//IL_0cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Expected O, but got Unknown
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6a: Expected O, but got Unknown
		Action token = InitSession;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<UISignals.ConfirmCharacterSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA26B0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action<UISignals.ConfirmStageSelectionSignal> action = null;
		((PlayerOptions)(object)action).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).OnStageSelectionChanged((UISignals.ConfirmStageSelectionSignal)this);
		}
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		_signalBus.UnsubscribeInternal(typeFromHandle, (object)null, (object)action, throwIfMissing);
		Action<UISignals.SetDamageNumbersSignal> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2790");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		_signalBus.UnsubscribeInternal(typeFromHandle2, (object)null, (object)token3, throwIfMissing);
		Action<UISignals.SetGlimmerCarouselSignal> token4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2870");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		_signalBus.UnsubscribeInternal(typeFromHandle3, (object)null, (object)token4, throwIfMissing);
		Action<UISignals.SetSFXVolumeSignal> token5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2950");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1039 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token5, throwIfMissing);
		Action<UISignals.SetMusicVolumeSignal> token6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2A30");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token6, throwIfMissing);
		Action<UISignals.SetFlashingVFXSignal> token7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2B10");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1260 @ rbx_v30 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1277 @ rbx_v31 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType5 = default(Type);
		_signalBus.UnsubscribeInternal(signalType5, (object)null, (object)token7, throwIfMissing);
		Action<UISignals.SetStreamerSafeMusicSignal> token8 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2BF0");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1356 @ rbx_v34 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1373 @ rbx_v35 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType6 = default(Type);
		_signalBus.UnsubscribeInternal(signalType6, (object)null, (object)token8, throwIfMissing);
		Action<UISignals.SetVisibleJoysticksSignal> action2 = null;
		((PlayerOptions)(object)action2).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		((PlayerOptions)(object)_signalBus).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)action2);
		Action<UISignals.CharacterUnlockedSignal> action3 = null;
		((PlayerOptions)(object)action3).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rbx_v39 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		}
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rbx_v40 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((PlayerOptions)0).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)this);
		}
		((PlayerOptions)0).ApplyVisibleJoysticks((UISignals.SetVisibleJoysticksSignal)1);
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType7 = default(Type);
		_signalBus.UnsubscribeInternal(signalType7, (object)null, (object)action3, throwIfMissing);
		Action<UISignals.CharacterBoughtSignal> token9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2F30");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1555 @ rbx_v43 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rbx_v44 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj16 = default(object);
		object obj15 = obj16 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType8 = default(Type);
		_signalBus.UnsubscribeInternal(signalType8, (object)null, (object)token9, throwIfMissing);
		Action<UISignals.SkinBoughtSignal> token10 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3010");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rbx_v47 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1668 @ rbx_v48 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType9 = default(Type);
		_signalBus.UnsubscribeInternal(signalType9, (object)null, (object)token10, throwIfMissing);
		Action<UISignals.StageUnlockedSignal> token11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA30F0");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1747 @ rbx_v51 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1764 @ rbx_v52 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj20 = default(object);
		object obj19 = obj20 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType10 = default(Type);
		_signalBus.UnsubscribeInternal(signalType10, (object)null, (object)token11, throwIfMissing);
		Action<UISignals.WeaponUnlockedSignal> token12 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA31D0");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rbx_v55 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1860 @ rbx_v56 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj22 = default(object);
		object obj21 = obj22 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType11 = default(Type);
		_signalBus.UnsubscribeInternal(signalType11, (object)null, (object)token12, throwIfMissing);
		Action<UISignals.BuyPowerUpSignal> token13 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA32B0");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1939 @ rbx_v59 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1956 @ rbx_v60 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj24 = default(object);
		object obj23 = obj24 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType12 = default(Type);
		_signalBus.UnsubscribeInternal(signalType12, (object)null, (object)token13, throwIfMissing);
		Action<UISignals.RefundPowerUpsSignal> token14 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3390");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2035 @ rbx_v63 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2052 @ rbx_v64 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj26 = default(object);
		object obj25 = obj26 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType13 = default(Type);
		_signalBus.UnsubscribeInternal(signalType13, (object)null, (object)token14, throwIfMissing);
		Action<UISignals.LanguageSelectedSignal> token15 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3470");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2131 @ rbx_v67 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2148 @ rbx_v68 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj28 = default(object);
		object obj27 = obj28 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType14 = default(Type);
		_signalBus.UnsubscribeInternal(signalType14, (object)null, (object)token15, throwIfMissing);
		Action<UISignals.SetFullscreenSignal> token16 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3550");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2227 @ rbx_v71 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2244 @ rbx_v72 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj30 = default(object);
		object obj29 = obj30 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType15 = default(Type);
		_signalBus.UnsubscribeInternal(signalType15, (object)null, (object)token16, throwIfMissing);
		Action<UISignals.ToggleStageProgressionSignal> token17 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3630");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2323 @ rbx_v75 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2340 @ rbx_v76 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj32 = default(object);
		object obj31 = obj32 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType16 = default(Type);
		_signalBus.UnsubscribeInternal(signalType16, (object)null, (object)token17, throwIfMissing);
		Action<UISignals.ToggleMovingBackgroundSignal> action4 = null;
		((PlayerOptions)(object)action4).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)this);
		((PlayerOptions)(object)_signalBus).ToggleMovingBackground((UISignals.ToggleMovingBackgroundSignal)action4);
	}

	public void AutoSelectStage()
	{
		PlayerOptionsData config = Config;
		if (config._003CNextAutoSelectStage_003Ek__BackingField != StageType.FOREST)
		{
			PlayerOptionsData config2 = Config;
			PlayerOptionsData config3 = Config;
			config2._003CSelectedStage_003Ek__BackingField = config3._003CNextAutoSelectStage_003Ek__BackingField;
			PlayerOptionsData config4 = Config;
			config4._003CNextAutoSelectStage_003Ek__BackingField = StageType.FOREST;
		}
	}

	public void ClearSaveData(bool deleteAdventureData = false)
	{
		//IL_0083: Expected O, but got I
		_dataManager.ReloadAllData();
		Dictionary<AdventureType, PlayerOptionsData> dictionary = null;
		if (!deleteAdventureData)
		{
			PlayerOptionsData mainGameConfig = _mainGameConfig;
			bool flag = mainGameConfig._003CAdventuresSaveData_003Ek__BackingField == null;
			dictionary = null;
			if (!flag)
			{
				Dictionary<AdventureType, PlayerOptionsData> dictionary2 = mainGameConfig._003CAdventuresSaveData_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v23 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.Data.PlayerOptionsData>)+20]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v23 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AdventureType, VampireSurvivors.Data.PlayerOptionsData>)+28]");
				object obj = num - 0;
				bool flag2 = (nint)obj <= 0;
				dictionary = null;
				if (!flag2)
				{
					PlayerOptionsData mainGameConfig2 = _mainGameConfig;
					dictionary = mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField;
				}
			}
		}
		PlayerOptionsData data = new PlayerOptionsData();
		SaveSystem.Save(data);
		PlayerOptionsData config = new PlayerOptionsData();
		bool onlineClientWithRunData = default(bool);
		ApplyConfig(config, adventureMode: false, hostConfig: false, onlineClientWithRunData);
		if (dictionary != null)
		{
			PlayerOptionsData mainGameConfig3 = _mainGameConfig;
			mainGameConfig3._003CAdventuresSaveData_003Ek__BackingField = dictionary;
			Save();
		}
	}

	public void ApplyClientConfigWithRunProgress()
	{
		if (_onlineClientWithRunDataConfig != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj = default(object);
			if (obj == null)
			{
				_mainGameConfig = _onlineClientWithRunDataConfig;
			}
			else
			{
				_currentAdventureSaveData = _onlineClientWithRunDataConfig;
			}
		}
	}

	public void ApplyConfig(PlayerOptionsData config, bool adventureMode = false, bool hostConfig = false, bool onlineClientWithRunData = false)
	{
		//IL_007a: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		Debug.LogWarning("***ADVENTURES*** If you are in adventure mode please make sure this method has been updated to support the correct config assignment!");
		bool flag = _mainGameConfig == null;
		if (_mainGameConfig == null)
		{
		}
		if (!flag)
		{
			flag = _dataManager == null;
			_dataManager.ReloadAllData();
		}
		object obj = adventureMode | hostConfig;
		object obj2 = !flag;
		if (obj2 == null)
		{
			object obj3 = default(object);
			if (obj3 == obj)
			{
				_mainGameConfig = config;
			}
			else
			{
				_onlineClientWithRunDataConfig = config;
			}
		}
		else
		{
			if (adventureMode)
			{
				_currentAdventureSaveData = config;
			}
			if (hostConfig)
			{
				_hostGameConfig = config;
				PlayerOptionsData hostGameConfigAtRunStart = _hostGameConfig.Clone();
				_hostGameConfigAtRunStart = hostGameConfigAtRunStart;
			}
		}
		TouchPlatform();
		ApplyLoadedOptions();
		FixPlayerOptionsData();
		if (!hostConfig)
		{
			_dataManager.AddDefaultUnlocksToSaveData();
		}
		ApplyUnlocksToData();
		_playerStats.InitStats();
		PlayerOptionsData config2 = Config;
		string text = config2._003CsaveDate_003Ek__BackingField;
		if (config2._003CsaveDate_003Ek__BackingField == null || text._stringLength <= 0)
		{
			PlayerOptionsData config3 = Config;
			config3._003CPixelFont_003Ek__BackingField = false;
		}
		_003CIsInitialized_003Ek__BackingField = true;
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v313.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		PlayerOptionsData config4 = Config;
		string platformAsString = BackendFacade.GetPlatformAsString();
		config4._003CPlatform_003Ek__BackingField = platformAsString;
		if (!adventureMode && !hostConfig)
		{
			Debug.Log("Player options initialising");
			OnInitialized playerOptionsInitialized = this.m_PlayerOptionsInitialized;
			if (this.m_PlayerOptionsInitialized != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v806.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void FixCoinOverflow()
	{
		//IL_0034: Invalid comparison between F4 and I4
		//IL_073e: Invalid comparison between I4 and F4
		//IL_01bb: Expected F4, but got I4
		//IL_0064: Invalid comparison between I4 and F4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0117: Expected F4, but got I4
		//IL_0201: Invalid comparison between F4 and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_075b: Invalid comparison between I4 and F4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0388: Expected F4, but got I4
		//IL_0231: Invalid comparison between I4 and F4
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_02e4: Expected F4, but got I4
		//IL_03ce: Invalid comparison between F4 and I4
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0778: Invalid comparison between I4 and F4
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0555: Expected F4, but got I4
		//IL_03fe: Invalid comparison between I4 and F4
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_04b1: Expected F4, but got I4
		//IL_059b: Invalid comparison between F4 and I4
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0795: Invalid comparison between I4 and F4
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0722: Expected F4, but got I4
		//IL_05cb: Invalid comparison between I4 and F4
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected O, but got Unknown
		//IL_067e: Expected F4, but got I4
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		PlayerOptionsData config = Config;
		PlayerOptionsData config2 = Config;
		float num = config2._003CCoins_003Ek__BackingField;
		if (config2._003CCoins_003Ek__BackingField < 0f)
		{
			num *= -1f;
			if (!(0f > num))
			{
				object obj = num & -2147483649L;
				if ((nint)obj != 2139095040)
				{
					object obj2 = num & -2147483649L;
					if ((nint)obj2 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E38862h\"");
						if (num != -1f / 0f)
						{
							goto IL_0735;
						}
					}
				}
				num = 3.4028235E+38f;
			}
			else
			{
				num = 0f;
			}
		}
		goto IL_0735;
		IL_038d:
		PlayerOptionsData config3;
		float num2;
		config3._003CLifetimeCoins_003Ek__BackingField = num2;
		PlayerOptionsData config4 = Config;
		PlayerOptionsData config5 = Config;
		float num3 = config5._003CRunCoins_003Ek__BackingField;
		if (config5._003CRunCoins_003Ek__BackingField < 0f)
		{
			num3 *= -1f;
			if (!(0f > num3))
			{
				object obj3 = num3 & -2147483649L;
				if ((nint)obj3 != 2139095040)
				{
					object obj4 = num3 & -2147483649L;
					if ((nint)obj4 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E389B4h\"");
						if (num3 != -1f / 0f)
						{
							goto IL_076f;
						}
					}
				}
				num3 = 3.4028235E+38f;
			}
			else
			{
				num3 = 0f;
			}
		}
		goto IL_076f;
		IL_055a:
		config4._003CRunCoins_003Ek__BackingField = num3;
		PlayerOptionsData config6 = Config;
		PlayerOptionsData config7 = Config;
		float num4 = config7._003CTotalCoins_003Ek__BackingField;
		if (config7._003CTotalCoins_003Ek__BackingField < 0f)
		{
			num4 *= -1f;
			if (!(0f > num4))
			{
				object obj5 = num4 & -2147483649L;
				if ((nint)obj5 != 2139095040)
				{
					object obj6 = num4 & -2147483649L;
					if ((nint)obj6 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E38A5Dh\"");
						if (num4 != -1f / 0f)
						{
							goto IL_078c;
						}
					}
				}
				num4 = 3.4028235E+38f;
			}
			else
			{
				num4 = 0f;
			}
		}
		goto IL_078c;
		IL_076f:
		if (!(0f > num3))
		{
			object obj7 = num3 & -2147483649L;
			if ((nint)obj7 != 2139095040)
			{
				object obj8 = num3 & -2147483649L;
				if ((nint)obj8 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E389E7h\"");
					if (num3 != -1f / 0f)
					{
						goto IL_055a;
					}
				}
			}
			num3 = 3.4028235E+38f;
		}
		else
		{
			num3 = 0f;
		}
		goto IL_055a;
		IL_01c0:
		config._003CCoins_003Ek__BackingField = num;
		config3 = Config;
		PlayerOptionsData config8 = Config;
		num2 = config8._003CLifetimeCoins_003Ek__BackingField;
		if (config8._003CLifetimeCoins_003Ek__BackingField < 0f)
		{
			num2 *= -1f;
			if (!(0f > num2))
			{
				object obj9 = num2 & -2147483649L;
				if ((nint)obj9 != 2139095040)
				{
					object obj10 = num2 & -2147483649L;
					if ((nint)obj10 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E3890Bh\"");
						if (num2 != -1f / 0f)
						{
							goto IL_0752;
						}
					}
				}
				num2 = 3.4028235E+38f;
			}
			else
			{
				num2 = 0f;
			}
		}
		goto IL_0752;
		IL_0752:
		if (!(0f > num2))
		{
			object obj11 = num2 & -2147483649L;
			if ((nint)obj11 != 2139095040)
			{
				object obj12 = num2 & -2147483649L;
				if ((nint)obj12 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E3893Eh\"");
					if (num2 != -1f / 0f)
					{
						goto IL_038d;
					}
				}
			}
			num2 = 3.4028235E+38f;
		}
		else
		{
			num2 = 0f;
		}
		goto IL_038d;
		IL_0727:
		config6._003CTotalCoins_003Ek__BackingField = num4;
		return;
		IL_0735:
		if (!(0f > num))
		{
			object obj13 = num & -2147483649L;
			if ((nint)obj13 != 2139095040)
			{
				object obj14 = num & -2147483649L;
				if ((nint)obj14 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E38895h\"");
					if (num != -1f / 0f)
					{
						goto IL_01c0;
					}
				}
			}
			num = 3.4028235E+38f;
		}
		else
		{
			num = 0f;
		}
		goto IL_01c0;
		IL_078c:
		if (!(0f > num4))
		{
			object obj15 = num4 & -2147483649L;
			if ((nint)obj15 != 2139095040)
			{
				object obj16 = num4 & -2147483649L;
				if ((nint)obj16 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E38A90h\"");
					if (num4 != -1f / 0f)
					{
						goto IL_0727;
					}
				}
			}
			num4 = 3.4028235E+38f;
		}
		else
		{
			num4 = 0f;
		}
		goto IL_0727;
	}

	public unsafe void FixPlayerOptionsData()
	{
		//IL_071f: Expected O, but got Ref
		//IL_094d: Expected O, but got I
		//IL_08a8: Expected O, but got I4
		//IL_0765: Expected O, but got I
		//IL_0864: Expected I, but got O
		//IL_07d4: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A37ED]");
		bool flag = (nint)0 != 0;
		FixCoinOverflow();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			List<WeaponType> list = null;
		}
		PlayerOptionsData config = Config;
		bool flag2 = config._003CSelectedSkinsV2_003Ek__BackingField == null;
		int num = config._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(CharacterType.FB_BRADFANG);
		if (!flag2)
		{
			PlayerOptionsData config2 = Config;
			SkinType skinType = config2._003CSelectedSkinsV2_003Ek__BackingField.get_Item(CharacterType.FB_BRADFANG);
			if (skinType == SkinType.LEGACY)
			{
				PlayerOptionsData config3 = Config;
				bool flag3 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config3._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)122, (System.Int32Enum)0, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			}
		}
		PlayerOptionsData config4 = Config;
		if (!config4._003CHasFixedSkinIds_003Ek__BackingField)
		{
			Dictionary<CharacterType, List<SkinType>> dictionary = new Dictionary<CharacterType, List<SkinType>>();
			PlayerOptionsData config5 = Config;
			Dictionary<CharacterType, List<SkinType>>.Enumerator enumerator2 = default(Dictionary<CharacterType, List<SkinType>>.Enumerator);
			while (enumerator2.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				List<SkinType> list2 = null;
				nint num2 = 0;
				bool flag4 = 0 == 0;
				int num3 = 0;
				PlayerOptions playerOptions = (PlayerOptions)0;
				if (!flag4)
				{
					while (true)
					{
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rbx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						if ((nint)num4 < (nint)0)
						{
							SkinType id = ((List<SkinType>)null).get_Item(num3);
							SkinType skinType2 = FixSkinMapping(CharacterType.VOID, id);
							int num5 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rbx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
							if ((nint)num5 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rbx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+10]");
								num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rbx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+1C]");
								_ = (nint)0 + (nint)1;
								num3++;
								continue;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							num2 = unchecked((nint)null);
						}
						else if (dictionary != null)
						{
							break;
						}
						throw new NullReferenceException();
					}
					bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)null, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					continue;
				}
				throw new NullReferenceException();
			}
			Dictionary<CharacterType, SkinType> dictionary2 = new Dictionary<CharacterType, SkinType>();
			PlayerOptionsData config6 = Config;
			Dictionary<CharacterType, int>.Enumerator enumerator3 = default(Dictionary<CharacterType, int>.Enumerator);
			while (enumerator3.MoveNext())
			{
				SkinType value = FixSkinMapping(CharacterType.VOID, SkinType.DEFAULT);
				bool flag6 = dictionary2 == null;
				PlayerOptions playerOptions = this;
				if (!flag6)
				{
					bool flag7 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary2).TryInsert((System.Int32Enum)0, (System.Int32Enum)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					continue;
				}
				throw new NullReferenceException();
			}
			PlayerOptionsData config7 = Config;
			config7._003CUnlockedSkinsV2_003Ek__BackingField = dictionary;
			PlayerOptionsData config8 = Config;
			config8._003CSelectedSkinsV2_003Ek__BackingField = dictionary2;
			PlayerOptionsData config9 = Config;
			config9._003CHasFixedSkinIds_003Ek__BackingField = true;
		}
		PlayerOptionsData config10 = Config;
		bool flag8 = config10._003CSelectedSkinsV2_003Ek__BackingField == null;
		int num6 = config10._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(CharacterType.ELEANOR);
		if (!flag8)
		{
			PlayerOptionsData config11 = Config;
			bool flag9 = config11._003CUnlockedSkinsV2_003Ek__BackingField == null;
			int num7 = ((Dictionary<System.Int32Enum, object>)(object)config11._003CUnlockedSkinsV2_003Ek__BackingField).FindEntry((System.Int32Enum)75);
			List<SkinType> list3;
			if (!flag9)
			{
				PlayerOptionsData config12 = Config;
				object obj = ((Dictionary<System.Int32Enum, object>)(object)config12._003CUnlockedSkinsV2_003Ek__BackingField).get_Item((System.Int32Enum)75);
				list3 = (List<SkinType>)obj;
			}
			else
			{
				List<SkinType> list4 = new List<SkinType>();
				list3 = list4;
			}
			PlayerOptionsData config13 = Config;
			SkinType skinType3 = config13._003CSelectedSkinsV2_003Ek__BackingField.get_Item(CharacterType.ELEANOR);
			if (skinType3 == SkinType.SKIN_ELEANOR_AREA)
			{
				if (((Dictionary<CharacterType, SkinType>)(object)list3).get_Item((CharacterType)skinType3) == SkinType.DEFAULT)
				{
					goto IL_0628;
				}
			}
			else if (skinType3 == SkinType.SKIN_ELEANOR_MIGHT)
			{
				bool flag10 = list3 == null;
				SkinType skinType4 = ((Dictionary<CharacterType, SkinType>)(object)list3).get_Item((CharacterType)skinType3);
				if (!flag10)
				{
					goto IL_0628;
				}
			}
		}
		goto IL_0655;
		IL_0628:
		UnlockSkin(CharacterType.ELEANOR, SkinType.SKIN_ELEANOR_AREA);
		UnlockSkin(CharacterType.ELEANOR, SkinType.SKIN_ELEANOR_MIGHT);
		goto IL_0655;
		IL_0655:
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		bool flag11 = loadedDlc == null;
		int num8 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)5);
		if (!flag11)
		{
			PlayerOptionsData config14 = Config;
			if (((Dictionary<DlcType, BundleManifestData>)(object)config14._003CAchievements_003Ek__BackingField).FindEntry((DlcType)315) != 0)
			{
				UnlockSkin(CharacterType.TP_REINHARDT, SkinType.SKIN_TP_REINHARDT_4MS);
			}
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator4 = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
		object obj2 = default(object);
		List<Skin>.Enumerator enumerator6 = default(List<Skin>.Enumerator);
		while (true)
		{
			if (!enumerator4.MoveNext())
			{
				return;
			}
			bool flag12 = obj2 == null;
			Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator5 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)(&enumerator4);
			if (!flag12)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ stack_-F8+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ stack_-F8+10]");
					PlayerOptions playerOptions = (PlayerOptions)0;
					if ((nint)playerOptions.m_PowerUpPurchased <= 0)
					{
						break;
					}
					OnValueChanged powerUpsRefunded = playerOptions.m_PowerUpsRefunded;
					if (((MulticastDelegate)powerUpsRefunded).delegates != null && enumerator6.MoveNext())
					{
						SkinType skinType5 = SkinType.DEFAULT;
						List<Skin>.Enumerator enumerator7 = (List<Skin>.Enumerator)(&enumerator6);
						throw new NullReferenceException();
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				enumerator5 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)0;
			}
			throw new NullReferenceException();
		}
		throw new IndexOutOfRangeException();
	}

	private SkinType FixSkinMapping(CharacterType characterType, SkinType id)
	{
		SkinType skinType = default(SkinType);
		if (characterType > CharacterType.PUGNALA)
		{
			if (characterType != CharacterType.CONCETTA)
			{
				switch (characterType)
				{
				case CharacterType.FINO:
					switch (skinType)
					{
					case SkinType.DEFAULT2:
						skinType = SkinType.FINO_EYE;
						break;
					case SkinType.LEGACY:
						return SkinType.FINO_DARK;
					}
					break;
				case CharacterType.C1_HORSE:
					switch (skinType)
					{
					case SkinType.FINO_DARK:
						skinType = SkinType.C1_HORSE_RAINBOW;
						break;
					case SkinType.CROCI_NOCROSS:
						return SkinType.C1_HORSE_RED;
					case SkinType.ADVENTURE1:
						return SkinType.C1_HORSE_ORANGE;
					case SkinType.XMAS:
						return SkinType.C1_HORSE_YELLOW;
					case SkinType.HALLOWS:
						return SkinType.C1_HORSE_GREEN;
					case SkinType.EMPTY:
						return SkinType.C1_HORSE_BLUE;
					case SkinType.DEFAULT2:
						return SkinType.C1_HORSE_PURPLE;
					case SkinType.LEGACY:
						return SkinType.C1_HORSE_PINK;
					}
					return skinType;
				}
				goto IL_0372;
			}
			if (skinType != SkinType.DEFAULT)
			{
				if (skinType != SkinType.LEGACY)
				{
					return skinType;
				}
				goto IL_0290;
			}
		}
		else if (characterType == CharacterType.CRISTINA)
		{
			if (skinType != SkinType.DEFAULT)
			{
				if (skinType == SkinType.LEGACY)
				{
					goto IL_0290;
				}
				goto IL_0372;
			}
		}
		else if (characterType == CharacterType.CROCI)
		{
			if (skinType != SkinType.LEGACY)
			{
				if (skinType == SkinType.DEFAULT2)
				{
					skinType = SkinType.CROCI_NOCROSS;
				}
				return skinType;
			}
		}
		else
		{
			if (characterType != CharacterType.PUGNALA)
			{
				goto IL_0372;
			}
			if (skinType != SkinType.DEFAULT)
			{
				if (skinType == SkinType.LEGACY)
				{
					skinType = SkinType.DEFAULT;
				}
				return skinType;
			}
		}
		return SkinType.LEGACY;
		IL_0290:
		return SkinType.DEFAULT;
		IL_0372:
		return skinType;
	}

	private void TouchPlatform()
	{
		//IL_0047: Expected O, but got I4
		//IL_00f1: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_0158: Expected O, but got I
		PlayerOptionsData config = Config;
		if ((object)config._003CSaveOriginalPlatform_003Ek__BackingField == null)
		{
			PlayerOptionsData config2 = Config;
			config2._003CSaveOriginalPlatform_003Ek__BackingField = (SystemPlatformTypes?)(object)1;
		}
		PlayerOptionsData config3 = Config;
		List<SystemPlatformTypes> list = config3._003CSaveTouchedPlatforms_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		PlayerOptionsData config4 = Config;
		List<SystemPlatformTypes> list2 = config4._003CSaveTouchedPlatforms_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v4 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v4 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v4 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+18]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v4 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)SystemPlatform.Platform);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v4 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+18]");
		object obj4 = (nint)0 + (nint)1;
		_ = SystemPlatform.Platform;
	}

	public unsafe void ApplyUnlocksToData()
	{
		//IL_007b: Expected O, but got Ref
		//IL_017e: Expected O, but got Ref
		//IL_028a: Expected O, but got Ref
		//IL_12fb: Expected O, but got I
		//IL_02ed: Expected O, but got I
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0491: Expected O, but got I
		//IL_100b: Expected I, but got O
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_0635: Expected O, but got I
		//IL_1061: Expected I, but got O
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Expected O, but got Unknown
		//IL_071c: Expected O, but got I
		//IL_080b: Expected O, but got I
		//IL_10b7: Expected I, but got O
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected O, but got Unknown
		//IL_08f2: Expected O, but got I
		//IL_09e1: Expected O, but got I
		//IL_110d: Expected I, but got O
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f4: Expected O, but got Unknown
		//IL_0b7a: Expected O, but got I
		//IL_11b0: Expected I, but got O
		//IL_0b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0d63: Expected O, but got I
		//IL_0e52: Expected O, but got I
		//IL_1211: Expected I, but got O
		//IL_0e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e65: Expected O, but got Unknown
		//IL_0d09: Expected O, but got I
		//IL_0ef4: Expected O, but got I
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		DataManager dataManager = _dataManager;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		DataManager dataManager2 = _dataManager;
		PlayerOptionsData config = Config;
		List<WeaponType>.Enumerator enumerator = default(List<WeaponType>.Enumerator);
		while (enumerator.MoveNext())
		{
			bool flag = convertedWeapons == null;
			List<WeaponType>.Enumerator enumerator2 = (List<WeaponType>.Enumerator)(&enumerator);
			if (!flag)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
				if (!flag)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj).get_Item(WeaponType.VOID);
					if (list == null)
					{
						throw new NullReferenceException();
					}
					_ = 1;
					object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					if (obj2 == null)
					{
						throw new NullReferenceException();
					}
					List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj2).get_Item(WeaponType.VOID);
					list2._items = null;
				}
				continue;
			}
			throw new NullReferenceException();
		}
		PlayerOptionsData config2 = Config;
		List<WeaponType>.Enumerator enumerator3 = default(List<WeaponType>.Enumerator);
		while (enumerator3.MoveNext())
		{
			bool flag2 = convertedWeapons == null;
			Dictionary<WeaponType, List<WeaponData>> dictionary = (Dictionary<WeaponType, List<WeaponData>>)(&enumerator3);
			if (!flag2)
			{
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
				if (!flag2)
				{
					object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					if (obj3 == null)
					{
						throw new NullReferenceException();
					}
					List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)obj3).get_Item(WeaponType.VOID);
					if (list3 == null)
					{
						throw new NullReferenceException();
					}
					_ = 1;
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					if (obj4 == null)
					{
						throw new NullReferenceException();
					}
					List<WeaponData> list4 = ((Dictionary<WeaponType, List<WeaponData>>)obj4).get_Item(WeaponType.VOID);
					if (list4 == null)
					{
						throw new NullReferenceException();
					}
					list4._items = null;
				}
				continue;
			}
			throw new NullReferenceException();
		}
		PlayerOptionsData config3 = Config;
		object obj5 = default(object);
		Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&obj5);
		object obj6 = default(object);
		object obj7 = default(object);
		object obj9 = default(object);
		while (true)
		{
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-E8_v66+1C]");
				if (obj7 == null)
				{
					object obj8 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-E8_v66+18]");
					if ((nint)obj8 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-E8_v66+10]");
						object obj10 = 0;
						object obj11 = obj9 + 1;
						bool flag3 = dataManager._003CAllItems_003Ek__BackingField == null;
						Dictionary<ItemType, ItemData> dictionary3 = dataManager._003CAllItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1112 @ rdx_v138+20+v1095 @ stack_-E0_v64*4]");
						int num3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary3).FindEntry((System.Int32Enum)0);
						obj9 = obj11;
						if (!flag3)
						{
							Dictionary<ItemType, ItemData> dictionary4 = dataManager._003CAllItems_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1112 @ rdx_v138+20+v1216 @ rcx_v187*4]");
							object obj12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary4).get_Item((System.Int32Enum)0);
							_ = 1;
							obj9 = obj11;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag4 = obj6 == null;
		dictionary2 = (Dictionary<System.Int32Enum, object>)0;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-E8_v66+1C]");
			if (obj7 == null)
			{
				if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = _currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
					}
				}
				object obj13 = default(object);
				object obj14 = default(object);
				object obj16 = default(object);
				while (true)
				{
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-D0_v59+1C]");
						if (obj14 == null)
						{
							object obj15 = obj16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-D0_v59+18]");
							if ((nint)obj15 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-D0_v59+10]");
								object obj17 = 0;
								object obj18 = obj16 + 1;
								bool flag5 = dataManager2._003CAllArcanas_003Ek__BackingField == null;
								Dictionary<ArcanaType, ArcanaData> dictionary5 = dataManager2._003CAllArcanas_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1519 @ rdx_v133+20+v1499 @ stack_-C8_v57*4]");
								int num4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary5).FindEntry((System.Int32Enum)0);
								obj16 = obj18;
								if (!flag5)
								{
									Dictionary<ArcanaType, ArcanaData> dictionary6 = dataManager2._003CAllArcanas_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1519 @ rdx_v133+20+v1628 @ rcx_v178*4]");
									object obj19 = ((Dictionary<System.Int32Enum, object>)(object)dictionary6).get_Item((System.Int32Enum)0);
									_ = 1;
									obj16 = obj18;
								}
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag6 = obj13 == null;
				nint num5 = 0;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-D0_v59+1C]");
					if (obj14 == null)
					{
						if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
						{
							PlayerOptionsData currentAdventureSaveData2 = _currentAdventureSaveData;
							if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
							}
						}
						object obj20 = default(object);
						object obj21 = default(object);
						object obj23 = default(object);
						while (true)
						{
							if (obj20 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-120_v52+1C]");
								if (obj21 == null)
								{
									object obj22 = obj23;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-120_v52+18]");
									if ((nint)obj22 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-120_v52+10]");
										object obj24 = 0;
										object obj25 = obj23 + 1;
										bool flag7 = convertedCharacterData == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1953 @ rdx_v128+20+v1930 @ stack_-118_v50*4]");
										int num6 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)0);
										obj23 = obj25;
										if (!flag7)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1953 @ rdx_v128+20+v2202 @ rcx_v168*4]");
											object obj26 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1953 @ rdx_v128+20+v2202 @ rcx_v168*4]");
											List<CharacterData> list5 = ((Dictionary<CharacterType, List<CharacterData>>)obj26).get_Item(CharacterType.VOID);
											_ = 0;
											obj23 = obj25;
										}
										continue;
									}
									break;
								}
								break;
							}
							throw new NullReferenceException();
						}
						bool flag8 = obj20 == null;
						nint num7 = 0;
						if (!flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-120_v52+1C]");
							if (obj21 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-120_v52+18]");
								object obj27 = (nint)0 + (nint)1;
								if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
								{
									PlayerOptionsData currentAdventureSaveData3 = _currentAdventureSaveData;
									if ((object)currentAdventureSaveData3._003CSelectedAdventureType_003Ek__BackingField != null)
									{
									}
								}
								object obj28 = obj27;
								object obj29 = default(object);
								while (true)
								{
									if (obj29 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-120_v54+1C]");
										if (obj21 == null)
										{
											object obj30 = obj28;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-120_v54+18]");
											if ((nint)obj30 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-120_v54+10]");
												object obj31 = 0;
												object obj32 = obj28 + 1;
												bool flag9 = convertedCharacterData == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ rdx_v123+20+v2489 @ stack_-118_v52*4]");
												int num8 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)0);
												obj28 = obj32;
												if (!flag9)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ rdx_v123+20+v2742 @ rcx_v158*4]");
													object obj33 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ rdx_v123+20+v2742 @ rcx_v158*4]");
													List<CharacterData> list6 = ((Dictionary<CharacterType, List<CharacterData>>)obj33).get_Item(CharacterType.VOID);
													_ = 0;
													obj28 = obj32;
												}
												continue;
											}
											break;
										}
										break;
									}
									throw new NullReferenceException();
								}
								bool flag10 = obj29 == null;
								nint num9 = 0;
								if (!flag10)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-120_v54+1C]");
									if (obj21 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_-120_v54+18]");
										object obj34 = (nint)0 + (nint)1;
										if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
										{
											PlayerOptionsData currentAdventureSaveData4 = _currentAdventureSaveData;
											if ((object)currentAdventureSaveData4._003CSelectedAdventureType_003Ek__BackingField != null)
											{
											}
										}
										object obj35 = obj34;
										object obj36 = default(object);
										while (true)
										{
											if (obj36 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-120_v56+1C]");
												if (obj21 == null)
												{
													object obj37 = obj35;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-120_v56+18]");
													if ((nint)obj37 < 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-120_v56+10]");
														object obj38 = 0;
														object obj39 = obj35 + 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3125 @ rdx_v119+20+v3102 @ stack_-118_v54*4]");
														bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).TryGetValue((System.Int32Enum)0, out object value);
														bool flag12 = !flag11;
														obj35 = obj39;
														if (!flag12)
														{
															object obj40 = value;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3125 @ rdx_v119+20+v3291 @ rcx_v150*4]");
															bool flag13 = ((Dictionary<CharacterType, List<CharacterData>>)obj40).TryGetValue(CharacterType.VOID, out *(List<CharacterData>*)(&value));
															_ = 0;
															obj35 = obj39;
														}
														continue;
													}
													break;
												}
												break;
											}
											throw new NullReferenceException();
										}
										bool flag14 = obj36 == null;
										nint num10 = 0;
										if (!flag14)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-120_v56+1C]");
											if (obj21 == null)
											{
												if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
												{
													PlayerOptionsData currentAdventureSaveData5 = _currentAdventureSaveData;
													if ((object)currentAdventureSaveData5._003CSelectedAdventureType_003Ek__BackingField != null)
													{
													}
												}
												object obj41 = default(object);
												object obj42 = default(object);
												object obj44 = default(object);
												while (true)
												{
													if (obj41 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-108_v28+1C]");
														if (obj42 != null)
														{
															break;
														}
														object obj43 = obj44;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-108_v28+18]");
														if ((nint)obj43 >= 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-108_v28+10]");
														object obj45 = 0;
														object obj46 = obj44 + 1;
														bool flag15 = convertedStages == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v3619 @ stack_-100_v26*4]");
														int num11 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)0);
														obj44 = obj46;
														if (!flag15)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															object obj47 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															List<StageData> list7 = ((Dictionary<StageType, List<StageData>>)obj47).get_Item(StageType.FOREST);
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															object obj48 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															List<StageData> list8 = ((Dictionary<StageType, List<StageData>>)obj48).get_Item(StageType.FOREST);
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															object obj49 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
															List<StageData> list9 = ((Dictionary<StageType, List<StageData>>)obj49).get_Item(StageType.FOREST);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3991 @ rax_v279 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+A8]");
															bool flag16 = (nint)0 == 0;
															obj44 = obj46;
															if (!flag16)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
																object obj50 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3645 @ rdi_v71+20+v4363 @ rcx_v134*4]");
																List<StageData> list10 = ((Dictionary<StageType, List<StageData>>)obj50).get_Item(StageType.FOREST);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3841 @ rax_v281 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+A8]");
																object obj51 = 0;
																_ = 1;
																obj44 = obj46;
															}
														}
														continue;
													}
													throw new NullReferenceException();
												}
												bool flag17 = obj41 == null;
												nint num12 = 0;
												if (!flag17)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-108_v28+1C]");
													if (obj42 == null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-108_v28+18]");
														object obj52 = (nint)0 + (nint)1;
														if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
														{
															PlayerOptionsData currentAdventureSaveData6 = _currentAdventureSaveData;
															if ((object)currentAdventureSaveData6._003CSelectedAdventureType_003Ek__BackingField != null)
															{
															}
														}
														object obj53 = obj52;
														object obj54 = default(object);
														while (true)
														{
															if (obj54 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ stack_-108_v30+1C]");
																if (obj42 == null)
																{
																	object obj55 = obj53;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ stack_-108_v30+18]");
																	if ((nint)obj55 < 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ stack_-108_v30+10]");
																		object obj56 = 0;
																		object obj57 = obj53 + 1;
																		bool flag18 = convertedStages == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4786 @ rdx_v107+20+v4759 @ stack_-100_v28*4]");
																		int num13 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)0);
																		obj53 = obj57;
																		if (!flag18)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4786 @ rdx_v107+20+v5048 @ rcx_v124*4]");
																			object obj58 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4786 @ rdx_v107+20+v5048 @ rcx_v124*4]");
																			List<StageData> list11 = ((Dictionary<StageType, List<StageData>>)obj58).get_Item(StageType.FOREST);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4937 @ rax_v254 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+A0]");
																			object obj59 = 0;
																			_ = 1;
																			obj53 = obj57;
																		}
																		continue;
																	}
																	break;
																}
																break;
															}
															throw new NullReferenceException();
														}
														bool flag19 = obj54 == null;
														nint num14 = 0;
														if (!flag19)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ stack_-108_v30+1C]");
															if (obj42 == null)
															{
																return;
															}
															System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
															num14 = unchecked((nint)null);
														}
														throw new NullReferenceException();
													}
													System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
													num12 = unchecked((nint)null);
												}
												throw new NullReferenceException();
											}
											System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
											num10 = unchecked((nint)null);
										}
										throw new NullReferenceException();
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									num9 = unchecked((nint)null);
								}
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							num7 = unchecked((nint)null);
						}
						throw new NullReferenceException();
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num5 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary2 = null;
		}
		throw new NullReferenceException();
	}

	public unsafe void ApplyLoadedOptions()
	{
		//IL_00e7: Expected O, but got Ref
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		MasterAudio.MasterVolumeLevel = mainGameConfig._003CSoundsVolume_003Ek__BackingField;
		PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
		PlayerOptionsData mainGameConfig2 = _mainGameConfig;
		onlyPlaylistController._playlistVolume = mainGameConfig2._003CMusicVolume_003Ek__BackingField;
		onlyPlaylistController.UpdateMasterVolume();
		PlayerOptionsData mainGameConfig3 = _mainGameConfig;
		LocalizationManager.CurrentLanguageCode = mainGameConfig3._003CLanguage_003Ek__BackingField;
		PlayerOptionsData config = Config;
		string message = "LANGUAGE FROM PLAYER OPTIONS : " + config._003CLanguage_003Ek__BackingField;
		Debug.Log(message);
		PlayerOptionsData config2 = Config;
		List<PowerUpType> list = config2._003CUnlockedPowerUpRanks_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		object obj = default(object);
		string text = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj), null);
		string message2 = "Unlocked Power Ups : " + text;
		Debug.Log(message2);
		PlayerOptionsData config3 = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = (byte)(~(config3._003CJoystickVisible_003Ek__BackingField ? 1u : 0u)) != 0;
		string text2 = "False";
		if (!flag)
		{
			text2 = "True";
		}
		string message3 = "Visible joystick : " + text2;
		Debug.Log(message3);
	}

	public void AddRunHunger(int amount)
	{
		PlayerOptionsData config = Config;
		int num = config._003CRunHunger_003Ek__BackingField + amount;
		config._003CRunHunger_003Ek__BackingField = num;
	}

	public void SetShowGuides(bool b)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_009e: Expected I, but got O
		//IL_00ba: Expected O, but got I
		PlayerOptionsData config = Config;
		config._003CShowPickups_003Ek__BackingField = b;
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		mainGameConfig._003CShowPickups_003Ek__BackingField = b;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void SetShowPickups(bool b)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0082: Expected I, but got O
		//IL_009e: Expected O, but got I
		PlayerOptionsData config = Config;
		config._003CShowSmallMapIcons_003Ek__BackingField = b;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public unsafe int GetMaxSeals()
	{
		//IL_050d: Expected I4, but got O
		//IL_006a: Expected O, but got I4
		//IL_0072: Expected O, but got Ref
		PlayerOptionsData config = Config;
		PlayerOptionsData playerOptionsData;
		if (config != null)
		{
			config._003CSeals_003Ek__BackingField = 0;
			PlayerOptionsData config2 = Config;
			if (config2 != null && config2._003CBoughtPowerups_003Ek__BackingField != null)
			{
				List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				if (_onlineClientWithRunDataConfig == null)
				{
					if (_hostGameConfig == null)
					{
						if (_currentAdventureSaveData != null)
						{
							playerOptionsData = _currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0560;
							}
						}
						playerOptionsData = _mainGameConfig;
						if (_mainGameConfig == null)
						{
							goto IL_04ff;
						}
					}
					else
					{
						playerOptionsData = _hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = _onlineClientWithRunDataConfig;
				}
				goto IL_0560;
			}
		}
		goto IL_04ff;
		IL_0560:
		PlayerOptionsData playerOptionsData2;
		if (playerOptionsData._003CSeals_003Ek__BackingField >= 100)
		{
			if (_onlineClientWithRunDataConfig == null)
			{
				if (_hostGameConfig == null)
				{
					if (_currentAdventureSaveData != null)
					{
						playerOptionsData2 = _currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_05a4;
						}
					}
					playerOptionsData2 = _mainGameConfig;
					if (_mainGameConfig == null)
					{
						goto IL_04ff;
					}
				}
				else
				{
					playerOptionsData2 = _hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = _onlineClientWithRunDataConfig;
			}
			goto IL_05a4;
		}
		goto IL_0610;
		IL_05b7:
		PlayerOptionsData playerOptionsData3;
		return playerOptionsData3._003CSeals_003Ek__BackingField;
		IL_05a4:
		playerOptionsData2._003CSeals_003Ek__BackingField = 65535;
		goto IL_0610;
		IL_0610:
		if (_onlineClientWithRunDataConfig == null)
		{
			if (_hostGameConfig == null)
			{
				if (_currentAdventureSaveData != null)
				{
					playerOptionsData3 = _currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_05b7;
					}
				}
				PlayerOptionsData mainGameConfig = _mainGameConfig;
				if (_mainGameConfig != null)
				{
					return mainGameConfig._003CSeals_003Ek__BackingField;
				}
				goto IL_04ff;
			}
			PlayerOptionsData hostGameConfig = _hostGameConfig;
			return hostGameConfig._003CSeals_003Ek__BackingField;
		}
		playerOptionsData3 = _onlineClientWithRunDataConfig;
		goto IL_05b7;
		IL_04ff:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetUsedSeals()
	{
		//IL_00ba: Expected I4, but got O
		PlayerOptionsData config = Config;
		if (config != null)
		{
			List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
			if (config._003CSealedItems_003Ek__BackingField != null)
			{
				PlayerOptionsData config2 = Config;
				if (config2 != null)
				{
					List<WeaponType> list2 = config2._003CSealedWeapons_003Ek__BackingField;
					if (config2._003CSealedWeapons_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						return (int)(num + 0);
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetPowerUpMaxRank(PowerUpType type)
	{
		//IL_00cd: Expected O, but got I4
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		//IL_0098: Expected O, but got I
		//IL_00ad: Expected O, but got I
		object obj = type - 20;
		if ((nint)obj <= 10)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v6+6E3C5B4+v38 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rcx_v9 (should have been resolved before IL gen)");
		}
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v10 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v10 (System.Object)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v11+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v12+48]");
			return 0;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	public void AddHeal(float value)
	{
		PlayerOptionsData config = Config;
		float num = value + config._003CLifetimeHeal_003Ek__BackingField;
		config._003CLifetimeHeal_003Ek__BackingField = num;
	}

	public void TrackEnemyKill(EnemyType enemyType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x186E3C650\"");
	}

	public void TrackEnemyKill(EnemyType enemyType, PlayerOptionsData config)
	{
		int num = config._003CKillCount_003Ek__BackingField.FindEntry(enemyType);
		int value;
		System.Collections.Generic.InsertionBehavior behavior;
		if (num >= 0)
		{
			int num2 = config._003CKillCount_003Ek__BackingField.get_Item(enemyType);
			value = num2 + 1;
			behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		else
		{
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value = 1;
		}
		bool flag = ((Dictionary<System.Int32Enum, int>)(object)config._003CKillCount_003Ek__BackingField).TryInsert((System.Int32Enum)enemyType, value, behavior);
		int num3 = config._003CRunKillCount_003Ek__BackingField.FindEntry(enemyType);
		int value2;
		System.Collections.Generic.InsertionBehavior behavior2;
		if (num3 >= 0)
		{
			int num4 = config._003CRunKillCount_003Ek__BackingField.get_Item(enemyType);
			value2 = num4 + 1;
			behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		else
		{
			behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value2 = 1;
		}
		bool flag2 = ((Dictionary<System.Int32Enum, int>)(object)config._003CRunKillCount_003Ek__BackingField).TryInsert((System.Int32Enum)enemyType, value2, behavior2);
	}

	public void TrackItemPickup(ItemType itemType, PlayerOptionsData config, bool trackRunPickup = true)
	{
		int num = config._003CPickupCount_003Ek__BackingField.FindEntry(itemType);
		int value;
		System.Collections.Generic.InsertionBehavior behavior;
		if (num >= 0)
		{
			int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(itemType);
			value = num2 + 1;
			behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		else
		{
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value = 1;
		}
		bool flag = ((Dictionary<System.Int32Enum, int>)(object)config._003CPickupCount_003Ek__BackingField).TryInsert((System.Int32Enum)itemType, value, behavior);
		if (trackRunPickup)
		{
			int num3 = config._003CRunItemsPickupCount_003Ek__BackingField.FindEntry(itemType);
			int value2;
			System.Collections.Generic.InsertionBehavior behavior2;
			if (num3 >= 0)
			{
				int num4 = config._003CRunItemsPickupCount_003Ek__BackingField.get_Item(itemType);
				value2 = num4 + 1;
				behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			else
			{
				behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				value2 = 1;
			}
			bool flag2 = ((Dictionary<System.Int32Enum, int>)(object)config._003CRunItemsPickupCount_003Ek__BackingField).TryInsert((System.Int32Enum)itemType, value2, behavior2);
		}
	}

	public void TrackItemPickup(ItemType itemType, bool trackRunPickup = true)
	{
		PlayerOptionsData config = Config;
		TrackItemPickup(itemType, config, trackRunPickup);
	}

	public void IncreaseDestroyedPropCount(PropType propType)
	{
		PlayerOptionsData config = Config;
		int num = config._003CDestroyedCount_003Ek__BackingField.FindEntry(propType);
		Dictionary<PropType, int> dictionary;
		System.Collections.Generic.InsertionBehavior behavior;
		int value;
		if (num < 0)
		{
			PlayerOptionsData config2 = Config;
			dictionary = config2._003CDestroyedCount_003Ek__BackingField;
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value = 1;
		}
		else
		{
			PlayerOptionsData config3 = Config;
			dictionary = config3._003CDestroyedCount_003Ek__BackingField;
			int num2 = config3._003CDestroyedCount_003Ek__BackingField.get_Item(propType);
			value = num2 + 1;
			behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		bool flag = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)propType, value, behavior);
		PlayerOptionsData config4 = Config;
		int num3 = config4._003CRunDestroyedProps_003Ek__BackingField.FindEntry(propType);
		System.Collections.Generic.InsertionBehavior behavior2;
		int value2;
		System.Int32Enum key;
		Dictionary<System.Int32Enum, int> dictionary2;
		if (num3 < 0)
		{
			PlayerOptionsData config5 = Config;
			behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value2 = 1;
			key = (System.Int32Enum)propType;
			dictionary2 = (Dictionary<System.Int32Enum, int>)(object)config5._003CRunDestroyedProps_003Ek__BackingField;
		}
		else
		{
			PlayerOptionsData config6 = Config;
			int num4 = config6._003CRunDestroyedProps_003Ek__BackingField.get_Item(propType);
			value2 = num4 + 1;
			behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			key = (System.Int32Enum)propType;
			dictionary2 = (Dictionary<System.Int32Enum, int>)(object)config6._003CRunDestroyedProps_003Ek__BackingField;
		}
		bool flag2 = dictionary2.TryInsert(key, value2, behavior2);
	}

	public void ResetDestroyedPropCount(PropType propType)
	{
		PlayerOptionsData config = Config;
		int num = config._003CDestroyedCount_003Ek__BackingField.FindEntry(propType);
		if (num >= 0)
		{
			PlayerOptionsData config2 = Config;
			bool flag = config2._003CDestroyedCount_003Ek__BackingField.Remove(propType);
		}
		PlayerOptionsData config3 = Config;
		int num2 = config3._003CRunDestroyedProps_003Ek__BackingField.FindEntry(propType);
		if (num2 >= 0)
		{
			PlayerOptionsData config4 = Config;
			bool flag2 = config4._003CRunDestroyedProps_003Ek__BackingField.Remove(propType);
		}
	}

	public void UnlockArcana(ArcanaType arcanaType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
		}
	}

	public void UnlockArcana(ArcanaType arcanaType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
		}
	}

	public unsafe void UnlockSkin(CharacterType c, SkinType t, PlayerOptionsData config = null)
	{
		//IL_01af: Expected O, but got I
		//IL_01c4: Expected O, but got I
		//IL_01fd: Expected O, but got I4
		//IL_0205: Expected O, but got Ref
		bool flag = config != null;
		PlayerOptionsData playerOptionsData = config;
		if (!flag)
		{
			PlayerOptionsData config2 = Config;
			playerOptionsData = config2;
		}
		bool flag2 = playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField == null;
		int num = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField).FindEntry((System.Int32Enum)c);
		if (!flag2)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField).get_Item((System.Int32Enum)c);
			List<SkinType> list = ((Dictionary<CharacterType, List<SkinType>>)obj).get_Item((CharacterType)t);
			if (list == null)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField).get_Item((System.Int32Enum)c);
				List<SkinType> list2 = ((Dictionary<CharacterType, List<SkinType>>)obj2).get_Item((CharacterType)t);
			}
		}
		else
		{
			List<SkinType> list3 = new List<SkinType>();
			int num2 = ((Dictionary<CharacterType, List<SkinType>>)(object)list3).FindEntry((CharacterType)t);
			bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)c, (object)list3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		bool flag4 = convertedCharacterData == null;
		int num3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)c);
		if (!flag4)
		{
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)c);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v15 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v15 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v18+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v17+78]");
			List<Skin>.Enumerator enumerator = default(List<Skin>.Enumerator);
			if ((nint)0 != 0 && enumerator.MoveNext())
			{
				object obj6 = 0;
				List<Skin>.Enumerator enumerator2 = (List<Skin>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	public void ClearRunData()
	{
		PlayerOptionsData config = Config;
		config._003CRunDestroyedProps_003Ek__BackingField.Clear();
		PlayerOptionsData config2 = Config;
		config2._003CRunItemsPickupCount_003Ek__BackingField.Clear();
		PlayerOptionsData config3 = Config;
		config3._003CRunKillCount_003Ek__BackingField.Clear();
		PlayerOptionsData config4 = Config;
		List<EnemyType> list = config4._003CRunBossesTypes_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config5 = Config;
		List<ItemType> list2 = config5._003CRunPickups_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config6 = Config;
		List<WeaponType> list3 = config6._003CRunWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config7 = Config;
		List<CharacterType> list4 = config7._003CRunCoffins_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config8 = Config;
		config8._003CRunCoins_003Ek__BackingField = 0f;
		PlayerOptionsData config9 = Config;
		config9._003CRunPickups_Coins_003Ek__BackingField = 0;
		PlayerOptionsData config10 = Config;
		config10._003CRunEnemies_003Ek__BackingField = 0;
		PlayerOptionsData config11 = Config;
		config11._003CRunBossesCount_003Ek__BackingField = 0;
		PlayerOptionsData config12 = Config;
		config12._003CRunHunger_003Ek__BackingField = 0;
		PlayerOptionsData config13 = Config;
		config13._003CRunFoundSurvarots_003Ek__BackingField = 0;
		PlayerOptionsData config14 = Config;
		config14._003CForcedSurvarots_003Ek__BackingField = false;
		PlayerOptionsData config15 = Config;
		config15._003CRunStarryHeavnes_003Ek__BackingField = 0;
		PlayerOptionsData config16 = Config;
		config16._003CRunWeirdSoulsPurifier_003Ek__BackingField = 0;
	}

	public HashSet<AchievementType> GetUnlockedAchievements()
	{
		//IL_0149: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		HashSet<AchievementType> hashSet = (HashSet<AchievementType>)(object)new HashSet<System.Int32Enum>();
		HashSet<System.Int32Enum> hashSet2 = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-28_v8+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-28_v8+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-28_v8+10]");
						object obj5 = 0;
						obj4++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v13+20+v223 @ rcx_v17*4]");
						bool flag = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)0);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		hashSet2 = (HashSet<System.Int32Enum>)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-28_v8+1C]");
			if (obj2 == null)
			{
				return hashSet;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			hashSet2 = null;
		}
		throw new NullReferenceException();
	}

	public unsafe Dictionary<PowerUpType, PowerUpLevel> GetBoughtPowerUps()
	{
		//IL_001d: Expected O, but got Ref
		Dictionary<PowerUpType, PowerUpLevel> result = new Dictionary<PowerUpType, PowerUpLevel>();
		PlayerOptionsData config = Config;
		List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = null;
			List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe void Save(bool commitImmediately = true, bool createBackup = false)
	{
		//IL_02a1: Expected I, but got O
		//IL_0051: Expected O, but got Ref
		//IL_0051: Expected I8, but got O
		//IL_02cb->IL01fe: Incompatible stack heights: 5 vs 1
		if ((object)MarkerSave != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerSave);
		}
		DateTime utcNow = DateTime.UtcNow;
		TimeSpan timeSpan = utcNow - DateTime.UnixEpoch;
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		object obj = default(object);
		string text = System.Number.FormatInt64((long)timeSpan, (ReadOnlySpan<char>)(&obj), null);
		bool flag = _mainGameConfig == null;
		mainGameConfig._003CsaveDate_003Ek__BackingField = text;
		System.Int32Enum key = default(System.Int32Enum);
		System.Collections.Generic.InsertionBehavior behavior;
		Dictionary<System.Int32Enum, object> dictionary2;
		if (_currentAdventureSaveData != null)
		{
			PlayerOptionsData currentAdventureSaveData = _currentAdventureSaveData;
			if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
			{
				PlayerOptionsData mainGameConfig2 = _mainGameConfig;
				bool flag2 = _mainGameConfig == null;
				if (mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField == null)
				{
					Dictionary<AdventureType, PlayerOptionsData> dictionary = new Dictionary<AdventureType, PlayerOptionsData>();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC7820");
				}
				PlayerOptionsData mainGameConfig3 = _mainGameConfig;
				bool flag3 = _mainGameConfig == null;
				bool flag4 = mainGameConfig3._003CAdventuresSaveData_003Ek__BackingField == null;
				bool num2;
				bool num3;
				if (!flag4)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig3._003CAdventuresSaveData_003Ek__BackingField).FindEntry(key);
					if (!flag4)
					{
						PlayerOptionsData mainGameConfig4 = _mainGameConfig;
						bool flag5 = _mainGameConfig == null;
						num2 = flag5;
						bool flag6 = mainGameConfig4._003CAdventuresSaveData_003Ek__BackingField == null;
						num3 = flag6;
						behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
						dictionary2 = (Dictionary<System.Int32Enum, object>)(object)mainGameConfig4._003CAdventuresSaveData_003Ek__BackingField;
						goto IL_02ab;
					}
				}
				PlayerOptionsData mainGameConfig5 = _mainGameConfig;
				bool flag7 = _mainGameConfig == null;
				num2 = flag7;
				bool flag8 = mainGameConfig5._003CAdventuresSaveData_003Ek__BackingField == null;
				num3 = flag8;
				behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				dictionary2 = (Dictionary<System.Int32Enum, object>)(object)mainGameConfig5._003CAdventuresSaveData_003Ek__BackingField;
				goto IL_02ab;
			}
		}
		goto IL_0203;
		IL_02ab:
		bool flag9 = dictionary2.TryInsert(key, (object)_currentAdventureSaveData, behavior);
		goto IL_0203;
		IL_0203:
		SaveSystem.Save(_mainGameConfig, commitImmediately, createBackup);
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	public void BuildHostPlayerConfig(HostPlayerOptions hostPlayerOptions)
	{
		//IL_00c0: Expected I, but got O
		//IL_0223: Expected I, but got O
		//IL_023b: Expected I, but got O
		//IL_051e: Expected O, but got I4
		//IL_0510: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3800]");
		bool flag = (nint)0 != 0;
		bool flag2 = (object)hostPlayerOptions == null;
		HostPlayerOptions hostPlayerOptions2 = (HostPlayerOptions)(object)this;
		if (!flag2)
		{
			int currentAdventureType = hostPlayerOptions.CurrentAdventureType;
			nint num = default(nint);
			if (currentAdventureType != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
				object obj = default(object);
				flag = obj != null;
				if (!flag)
				{
					int currentAdventureType2 = hostPlayerOptions.CurrentAdventureType;
					bool flag3 = _adventureManager == null;
					hostPlayerOptions2 = hostPlayerOptions;
					if (flag3)
					{
						goto IL_0564;
					}
					_adventureManager.InitAdventure((AdventureType)currentAdventureType2);
					num = unchecked((nint)null);
				}
			}
			PlayerOptionsData config = Config;
			bool flag4 = config == null;
			hostPlayerOptions2 = (HostPlayerOptions)(object)this;
			if (!flag4)
			{
				PlayerOptionsData playerOptionsData = config.Clone();
				bool flag5 = playerOptionsData == null;
				hostPlayerOptions2 = (HostPlayerOptions)(object)config;
				if (!flag5)
				{
					playerOptionsData._003CSelectedStage_003Ek__BackingField = (StageType)hostPlayerOptions._003CSelectedStage_003Ek__BackingField;
					List<CharacterType> list = SerializationUtils.DeserializeEnum<CharacterType>(hostPlayerOptions._openedCoffins);
					bool flag6 = list == null;
					hostPlayerOptions2 = (HostPlayerOptions)(object)hostPlayerOptions._openedCoffins;
					if (!flag6)
					{
						List<CharacterType> list2 = list;
						List<CharacterType>.Enumerator enumerator = default(List<CharacterType>.Enumerator);
						nint num3 = default(nint);
						object obj2 = default(object);
						while (enumerator.MoveNext())
						{
							hostPlayerOptions2 = (HostPlayerOptions)(object)playerOptionsData._003COpenedCoffins_003Ek__BackingField;
							if (playerOptionsData._003COpenedCoffins_003Ek__BackingField != null)
							{
								bool flag7 = ((MonoBehaviour)hostPlayerOptions2).m_CancellationTokenSource == null;
								nint num2 = num3;
								List<CharacterType> list3 = list2;
								nint num4 = num;
								bool flag8 = flag;
								if (!flag7)
								{
									list3 = (List<CharacterType>)(object)((MonoBehaviour)hostPlayerOptions2).m_CancellationTokenSource;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
									flag8 = (nint)obj2 != -1;
									num2 = 0;
									num4 = unchecked((nint)null);
									num3 = 0;
									list2 = (List<CharacterType>)(object)((MonoBehaviour)hostPlayerOptions2).m_CancellationTokenSource;
									num = unchecked((nint)null);
									flag = flag8;
									if (flag8)
									{
										continue;
									}
								}
								hostPlayerOptions2 = (HostPlayerOptions)(object)playerOptionsData._003COpenedCoffins_003Ek__BackingField;
								if (playerOptionsData._003COpenedCoffins_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
									num3 = num2;
									list2 = list3;
									num = num4;
									flag = flag8;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Dictionary<PowerUpType, int> dictionary = SerializationUtils.DeserializeAscensionData(hostPlayerOptions._ascensionData);
						playerOptionsData._003CAscensionPointsAllocation_003Ek__BackingField = dictionary;
						List<ArcanaType> list4 = SerializationUtils.DeserializeEnum<ArcanaType>(hostPlayerOptions._unlockedArcanas);
						playerOptionsData._003CUnlockedArcanas_003Ek__BackingField = list4;
						List<ItemType> list5 = SerializationUtils.DeserializeEnum<ItemType>(hostPlayerOptions._collectedItems);
						playerOptionsData._003CCollectedItems_003Ek__BackingField = list5;
						List<PowerUpLevel> list6 = SerializationUtils.DeserializePowerUps(hostPlayerOptions._boughtPowerUps);
						playerOptionsData._003CBoughtPowerups_003Ek__BackingField = list6;
						List<PowerUpType> list7 = SerializationUtils.DeserializeEnum<PowerUpType>(hostPlayerOptions._disabledPowerUps);
						playerOptionsData._003CDisabledPowerups_003Ek__BackingField = list7;
						byte[] buffer = SerializationUtils.JoinByteArrays(hostPlayerOptions._unlockedWeaponsChunks);
						List<WeaponType> list8 = SerializationUtils.DeserializeEnum<WeaponType>(buffer);
						playerOptionsData._003CUnlockedWeapons_003Ek__BackingField = list8;
						byte[] buffer2 = SerializationUtils.JoinByteArrays(hostPlayerOptions._collectedWeaponsChunks);
						List<WeaponType> list9 = SerializationUtils.DeserializeEnum<WeaponType>(buffer2);
						playerOptionsData._003CCollectedWeapons_003Ek__BackingField = list9;
						byte[] buffer3 = SerializationUtils.JoinByteArrays(hostPlayerOptions._sealedWeaponsChunks);
						List<WeaponType> list10 = SerializationUtils.DeserializeEnum<WeaponType>(buffer3);
						playerOptionsData._003CSealedWeapons_003Ek__BackingField = list10;
						List<ItemType> list11 = SerializationUtils.DeserializeEnum<ItemType>(hostPlayerOptions._sealedItems);
						playerOptionsData._003CSealedItems_003Ek__BackingField = list11;
						List<StageType> list12 = SerializationUtils.DeserializeEnum<StageType>(hostPlayerOptions._unlockedStages);
						playerOptionsData._003CUnlockedStages_003Ek__BackingField = list12;
						byte[] buffer4 = SerializationUtils.JoinByteArrays(hostPlayerOptions._hostPickupCountChunks);
						Dictionary<ItemType, int> dictionary2 = SerializationUtils.DeserializePickupCount(buffer4);
						playerOptionsData._003CPickupCount_003Ek__BackingField = dictionary2;
						byte[] buffer5 = SerializationUtils.JoinByteArrays(hostPlayerOptions._hostAchievementsChunks);
						List<AchievementType> list13 = SerializationUtils.DeserializeEnum<AchievementType>(buffer5);
						playerOptionsData._003CAchievements_003Ek__BackingField = list13;
						byte[] buffer6 = SerializationUtils.JoinByteArrays(hostPlayerOptions._onlineMultiplayerSelectionsChunks);
						List<CharacterType> onlineMultiplayerSelections = SerializationUtils.DeserializeEnum<CharacterType>(buffer6);
						playerOptionsData.OnlineMultiplayerSelections = onlineMultiplayerSelections;
						int currentAdventureType3 = hostPlayerOptions.CurrentAdventureType;
						AdventureType? adventureType;
						if (currentAdventureType3 != -1)
						{
							int currentAdventureType4 = hostPlayerOptions.CurrentAdventureType;
							adventureType = (AdventureType?)(object)1;
						}
						else
						{
							adventureType = (AdventureType?)(object)0;
						}
						playerOptionsData._003CSelectedAdventureType_003Ek__BackingField = adventureType;
						bool onlineClientWithRunData = default(bool);
						ApplyConfig(playerOptionsData, adventureMode: false, hostConfig: true, onlineClientWithRunData);
						int currentAdventureType5 = hostPlayerOptions.CurrentAdventureType;
						if (currentAdventureType5 == -1)
						{
							return;
						}
						int currentAdventureType6 = hostPlayerOptions.CurrentAdventureType;
						if (_adventureManager != null)
						{
							_adventureManager.InitDataManagerForAdventure((AdventureType)currentAdventureType6);
							return;
						}
					}
				}
			}
		}
		goto IL_0564;
		IL_0564:
		throw new NullReferenceException();
	}

	public unsafe PlayerOptionsData GetClientPlayerOptionsWithRunDataApplied()
	{
		//IL_02fa: Expected O, but got I4
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected I4, but got Unknown
		//IL_0467: Expected I, but got O
		//IL_04ca: Expected O, but got I
		//IL_0f1e: Expected I, but got O
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_10c7: Expected I, but got O
		//IL_05ae: Expected I, but got O
		//IL_052a: Expected O, but got I
		//IL_0551: Expected I, but got O
		//IL_0567: Expected O, but got I
		//IL_056c: Expected I, but got O
		//IL_0677: Expected I, but got O
		//IL_0602: Expected I, but got O
		//IL_06f9: Expected O, but got I
		//IL_0716: Expected I, but got O
		//IL_0731: Expected I, but got O
		//IL_10d9: Expected I, but got O
		//IL_0754: Expected I, but got O
		//IL_0868: Expected I, but got O
		//IL_092b: Expected O, but got I
		//IL_0f9a: Expected I, but got O
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Expected O, but got Unknown
		//IL_0993: Expected O, but got I
		//IL_09e6: Expected I, but got O
		//IL_1156: Expected I, but got O
		//IL_0aa1: Expected O, but got I
		//IL_0fe5: Expected I, but got O
		//IL_0aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Expected O, but got Unknown
		//IL_0b09: Expected O, but got I
		//IL_0b5c: Expected I, but got O
		//IL_11c5: Expected I, but got O
		//IL_0bbb: Expected I, but got O
		//IL_0bff: Expected O, but got I4
		//IL_0cd7: Expected I, but got O
		//IL_0c1a: Expected I, but got O
		//IL_0d1b: Expected O, but got I4
		//IL_0eb1: Expected O, but got I
		//IL_1050: Expected I, but got O
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec4: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj = default(object);
		PlayerOptionsData playerOptionsData = ((obj != null) ? _currentAdventureSaveData : _mainGameConfig);
		PlayerOptionsData playerOptionsData2 = playerOptionsData.Clone();
		PlayerOptionsData config = Config;
		playerOptionsData2._003CRunCoins_003Ek__BackingField = config._003CRunCoins_003Ek__BackingField;
		PlayerOptionsData config2 = Config;
		playerOptionsData2._003CRunPickups_Coins_003Ek__BackingField = config2._003CRunPickups_Coins_003Ek__BackingField;
		PlayerOptionsData config3 = Config;
		playerOptionsData2._003CRunBossesCount_003Ek__BackingField = config3._003CRunBossesCount_003Ek__BackingField;
		PlayerOptionsData config4 = Config;
		playerOptionsData2._003CRunPickups_003Ek__BackingField = config4._003CRunPickups_003Ek__BackingField;
		PlayerOptionsData config5 = Config;
		playerOptionsData2._003CRunEnemies_003Ek__BackingField = config5._003CRunEnemies_003Ek__BackingField;
		PlayerOptionsData config6 = Config;
		playerOptionsData2._003CRunHunger_003Ek__BackingField = config6._003CRunHunger_003Ek__BackingField;
		PlayerOptionsData config7 = Config;
		playerOptionsData2._003CRunFever_003Ek__BackingField = config7._003CRunFever_003Ek__BackingField;
		PlayerOptionsData config8 = Config;
		playerOptionsData2._003CRunStarryHeavnes_003Ek__BackingField = config8._003CRunStarryHeavnes_003Ek__BackingField;
		PlayerOptionsData config9 = Config;
		playerOptionsData2._003CRunDestroyedProps_003Ek__BackingField = config9._003CRunDestroyedProps_003Ek__BackingField;
		PlayerOptionsData config10 = Config;
		playerOptionsData2._003CRunWeirdSoulsPurifier_003Ek__BackingField = config10._003CRunWeirdSoulsPurifier_003Ek__BackingField;
		PlayerOptionsData config11 = Config;
		playerOptionsData2._003CRawRunHeal_003Ek__BackingField = config11._003CRawRunHeal_003Ek__BackingField;
		PlayerOptionsData config12 = Config;
		playerOptionsData2._003CRunBossesTypes_003Ek__BackingField = config12._003CRunBossesTypes_003Ek__BackingField;
		PlayerOptionsData config13 = Config;
		playerOptionsData2._003CBoughtCharacters_003Ek__BackingField = config13._003CBoughtCharacters_003Ek__BackingField;
		PlayerOptionsData config14 = Config;
		playerOptionsData2._003CUnlockedCharacters_003Ek__BackingField = config14._003CUnlockedCharacters_003Ek__BackingField;
		PlayerOptionsData config15 = Config;
		playerOptionsData2._003CRunCoffins_003Ek__BackingField = config15._003CRunCoffins_003Ek__BackingField;
		PlayerOptionsData config16 = Config;
		playerOptionsData2._003CRunKillCount_003Ek__BackingField = config16._003CRunKillCount_003Ek__BackingField;
		PlayerOptionsData config17 = Config;
		playerOptionsData2._003CRunItemsPickupCount_003Ek__BackingField = config17._003CRunItemsPickupCount_003Ek__BackingField;
		PlayerOptionsData config18 = Config;
		playerOptionsData2._003CRunWeapons_003Ek__BackingField = config18._003CRunWeapons_003Ek__BackingField;
		PlayerOptionsData config19 = Config;
		PlayerOptionsData hostGameConfigAtRunStart = _hostGameConfigAtRunStart;
		object obj2 = config19._003CPlayedRNJ_003Ek__BackingField - hostGameConfigAtRunStart._003CPlayedRNJ_003Ek__BackingField;
		int num = obj2 + playerOptionsData2._003CPlayedRNJ_003Ek__BackingField;
		playerOptionsData2._003CPlayedRNJ_003Ek__BackingField = num;
		PlayerOptionsData config20 = Config;
		PlayerOptionsData hostGameConfigAtRunStart2 = _hostGameConfigAtRunStart;
		float num2 = config20._003CLifetimeSurvived_003Ek__BackingField - hostGameConfigAtRunStart2._003CLifetimeSurvived_003Ek__BackingField;
		float num3 = num2 + playerOptionsData2._003CLifetimeSurvived_003Ek__BackingField;
		playerOptionsData2._003CLifetimeSurvived_003Ek__BackingField = num3;
		PlayerOptionsData config21 = Config;
		PlayerOptionsData hostGameConfigAtRunStart3 = _hostGameConfigAtRunStart;
		float num4 = config21._003CLifetimeHeal_003Ek__BackingField - hostGameConfigAtRunStart3._003CLifetimeHeal_003Ek__BackingField;
		float num5 = num4 + playerOptionsData2._003CLifetimeHeal_003Ek__BackingField;
		playerOptionsData2._003CLifetimeHeal_003Ek__BackingField = num5;
		PlayerOptionsData config22 = Config;
		PlayerOptionsData hostGameConfigAtRunStart4 = _hostGameConfigAtRunStart;
		float num6 = config22._003CTrainHazardEnemiesHit_003Ek__BackingField - hostGameConfigAtRunStart4._003CTrainHazardEnemiesHit_003Ek__BackingField;
		float num7 = num6 + playerOptionsData2._003CTrainHazardEnemiesHit_003Ek__BackingField;
		playerOptionsData2._003CTrainHazardEnemiesHit_003Ek__BackingField = num7;
		PlayerOptionsData config23 = Config;
		AddCoinsFlat(config23._003CRunCoins_003Ek__BackingField, playerOptionsData2);
		List<CharacterType> list = playerOptionsData2._003CRunCoffins_003Ek__BackingField;
		nint num8 = (nint)typeof(PlayerOptions);
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		object obj9 = default(object);
		object obj10 = default(object);
		nint num10 = default(nint);
		while (true)
		{
			object obj8;
			nint num11;
			List<CharacterType> list3;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ stack_-100_v42+1C]");
				if (obj4 != null)
				{
					break;
				}
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ stack_-100_v42+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ stack_-100_v42+10]");
				object obj7 = 0;
				obj8 = obj6 + 1;
				List<CharacterType> list2 = playerOptionsData2._003COpenedCoffins_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rcx_v161 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				bool flag = (nint)0 == 0;
				nint num9 = 0;
				nint num12;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rcx_v161 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					list = (List<CharacterType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj9 != -1;
					num10 = 0;
					num9 = unchecked((nint)null);
					num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ rcx_v161 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					list3 = (List<CharacterType>)0;
					num12 = unchecked((nint)null);
					if (flag2)
					{
						goto IL_05a1;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
				num11 = num10;
				list3 = list;
				num12 = num9;
				goto IL_05a1;
			}
			throw new NullReferenceException();
			IL_05a1:
			num8 = (nint)playerOptionsData2._003CUnlockedCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool flag3 = obj10 != null;
			num10 = num11;
			obj6 = obj8;
			list = list3;
			if (!flag3)
			{
				num8 = (nint)playerOptionsData2._003CUnlockedCharacters_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
				num10 = num11;
				obj6 = obj8;
				list = list3;
			}
		}
		bool flag4 = obj3 == null;
		num8 = 0;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ stack_-100_v42+1C]");
			if (obj4 == null)
			{
				nint num13 = (nint)playerOptionsData2._003CRunItemsPickupCount_003Ek__BackingField;
				nint num14 = 0;
				Dictionary<ItemType, int>.Enumerator enumerator = default(Dictionary<ItemType, int>.Enumerator);
				object obj11 = default(object);
				object obj12 = default(object);
				nint num20 = default(nint);
				while (enumerator.MoveNext())
				{
					num8 = (nint)playerOptionsData2._003CCollectedItems_003Ek__BackingField;
					nint num16;
					nint num17;
					PlayerOptionsData playerOptionsData3;
					if (playerOptionsData2._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1706 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+18]");
						nint num15;
						if ((nint)0 == 0)
						{
							num15 = num10;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1706 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+18]");
							num13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1706 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+10]");
							((Dictionary<ItemType, int>)0).set_Item(ItemType.VOID, 0);
							bool flag5 = (nint)obj11 != -1;
							num15 = 0;
							num14 = unchecked((nint)null);
							num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1706 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+18]");
							num16 = 0;
							num17 = unchecked((nint)null);
							playerOptionsData3 = playerOptionsData2;
							if (flag5)
							{
								goto IL_10cc;
							}
						}
						num8 = (nint)playerOptionsData2._003CCollectedItems_003Ek__BackingField;
						if (playerOptionsData2._003CCollectedItems_003Ek__BackingField != null)
						{
							((Dictionary<ItemType, int>)(object)playerOptionsData2._003CCollectedItems_003Ek__BackingField).set_Item(ItemType.VOID, (int)num14);
							num10 = num15;
							num16 = num13;
							num17 = num14;
							playerOptionsData3 = playerOptionsData2;
							goto IL_10cc;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_10cc:
					num8 = (nint)playerOptionsData3._003CPickupCount_003Ek__BackingField;
					if (playerOptionsData3._003CPickupCount_003Ek__BackingField != null)
					{
						playerOptionsData3._003CPickupCount_003Ek__BackingField.set_Item(ItemType.VOID, (int)num17);
						if (obj12 != null)
						{
							if (playerOptionsData2._003CPickupCount_003Ek__BackingField == null)
							{
								throw new NullReferenceException();
							}
							int num18 = playerOptionsData2._003CPickupCount_003Ek__BackingField.get_Item(ItemType.VOID);
							int num19 = (int)(num20 + num18);
							playerOptionsData2._003CPickupCount_003Ek__BackingField.set_Item(ItemType.VOID, num19);
							num13 = 0;
							num14 = num19;
						}
						else
						{
							num8 = (nint)playerOptionsData2._003CPickupCount_003Ek__BackingField;
							if (playerOptionsData2._003CPickupCount_003Ek__BackingField == null)
							{
								throw new NullReferenceException();
							}
							playerOptionsData2._003CPickupCount_003Ek__BackingField.set_Item(ItemType.VOID, (int)num20);
							num13 = num16;
							num14 = num20;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				List<ItemType> list4 = playerOptionsData2._003CRunPickups_003Ek__BackingField;
				nint num21 = (nint)(&enumerator);
				object obj13 = default(object);
				object obj14 = default(object);
				object obj16 = default(object);
				object obj19 = default(object);
				while (true)
				{
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ stack_-148_v43+1C]");
						if (obj14 != null)
						{
							break;
						}
						object obj15 = obj16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ stack_-148_v43+18]");
						if ((nint)obj15 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ stack_-148_v43+10]");
						object obj17 = 0;
						object obj18 = obj16 + 1;
						List<ItemType> list5 = playerOptionsData2._003CCollectedItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rcx_v140 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 == 0)
						{
							nint num22 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rcx_v140 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							list4 = (List<ItemType>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rcx_v140 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
							num21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							bool flag6 = (nint)obj19 != -1;
							obj16 = obj18;
							num10 = 0;
							if (flag6)
							{
								continue;
							}
							num10 = 0;
							nint num22 = unchecked((nint)null);
						}
						num21 = (nint)playerOptionsData2._003CCollectedItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						obj16 = obj18;
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag7 = obj13 == null;
				num21 = 0;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ stack_-148_v43+1C]");
					if (obj14 == null)
					{
						List<WeaponType> list6 = playerOptionsData2._003CRunWeapons_003Ek__BackingField;
						nint num23 = 0;
						object obj20 = default(object);
						object obj21 = default(object);
						object obj23 = default(object);
						object obj26 = default(object);
						while (true)
						{
							if (obj20 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-130_v43+1C]");
								if (obj21 != null)
								{
									break;
								}
								object obj22 = obj23;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-130_v43+18]");
								if ((nint)obj22 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-130_v43+10]");
								object obj24 = 0;
								object obj25 = obj23 + 1;
								List<WeaponType> list7 = playerOptionsData2._003CCollectedWeapons_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2463 @ rcx_v131 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if ((nint)0 == 0)
								{
									nint num24 = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2463 @ rcx_v131 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									list6 = (List<WeaponType>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2463 @ rcx_v131 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									num23 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
									bool flag8 = (nint)obj26 != -1;
									obj23 = obj25;
									num10 = 0;
									if (flag8)
									{
										continue;
									}
									num10 = 0;
									nint num24 = unchecked((nint)null);
								}
								num23 = (nint)playerOptionsData2._003CCollectedWeapons_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
								obj23 = obj25;
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag9 = obj20 == null;
						num23 = 0;
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-130_v43+1C]");
							if (obj21 == null)
							{
								Dictionary<EnemyType, int>.Enumerator enumerator2 = default(Dictionary<EnemyType, int>.Enumerator);
								while (enumerator2.MoveNext())
								{
									num23 = (nint)playerOptionsData2._003CKillCount_003Ek__BackingField;
									bool flag10 = playerOptionsData2._003CKillCount_003Ek__BackingField == null;
									if (!flag10)
									{
										int num25 = playerOptionsData2._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.BAT1);
										object obj27 = !flag10;
										if (obj27 == null)
										{
											num23 = (nint)playerOptionsData2._003CKillCount_003Ek__BackingField;
											if (playerOptionsData2._003CKillCount_003Ek__BackingField != null)
											{
												playerOptionsData2._003CKillCount_003Ek__BackingField.set_Item(EnemyType.BAT1, (int)num20);
												continue;
											}
											throw new NullReferenceException();
										}
										if (playerOptionsData2._003CKillCount_003Ek__BackingField != null)
										{
											int num26 = playerOptionsData2._003CKillCount_003Ek__BackingField.get_Item(EnemyType.BAT1);
											int value = (int)(num20 + num26);
											playerOptionsData2._003CKillCount_003Ek__BackingField.set_Item(EnemyType.BAT1, value);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								Dictionary<PropType, int>.Enumerator enumerator3 = default(Dictionary<PropType, int>.Enumerator);
								while (enumerator3.MoveNext())
								{
									num23 = (nint)playerOptionsData2._003CDestroyedCount_003Ek__BackingField;
									bool flag11 = playerOptionsData2._003CDestroyedCount_003Ek__BackingField == null;
									if (!flag11)
									{
										int num27 = playerOptionsData2._003CDestroyedCount_003Ek__BackingField.FindEntry(PropType.CANDLE);
										object obj28 = !flag11;
										if (obj28 == null)
										{
											if (playerOptionsData2._003CDestroyedCount_003Ek__BackingField != null)
											{
												playerOptionsData2._003CDestroyedCount_003Ek__BackingField.set_Item(PropType.CANDLE, (int)num20);
												continue;
											}
											throw new NullReferenceException();
										}
										if (playerOptionsData2._003CDestroyedCount_003Ek__BackingField != null)
										{
											int num28 = playerOptionsData2._003CDestroyedCount_003Ek__BackingField.get_Item(PropType.CANDLE);
											int value2 = (int)(num20 + num28);
											playerOptionsData2._003CDestroyedCount_003Ek__BackingField.set_Item(PropType.CANDLE, value2);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (_onlineClientWithRunDataConfig == null && _hostGameConfig == null && _currentAdventureSaveData != null)
								{
									PlayerOptionsData currentAdventureSaveData = _currentAdventureSaveData;
									if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
									{
									}
								}
								object obj29 = default(object);
								object obj30 = default(object);
								object obj32 = default(object);
								object obj34 = default(object);
								while (true)
								{
									if (obj29 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3430 @ stack_-118_v8+1C]");
										if (obj30 == null)
										{
											object obj31 = obj32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3430 @ stack_-118_v8+18]");
											if ((nint)obj31 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3430 @ stack_-118_v8+10]");
												object obj33 = 0;
												obj32 = obj34 + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3475 @ rdx_v97+20+v3425 @ stack_-110_v6*4]");
												bool flag12 = UnlockSecret(SecretType.CastThiefSpell, playerOptionsData2);
												continue;
											}
											break;
										}
										break;
									}
									throw new NullReferenceException();
								}
								bool flag13 = obj29 == null;
								nint num29 = 0;
								if (!flag13)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3430 @ stack_-118_v8+1C]");
									if (obj30 == null)
									{
										return playerOptionsData2;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									num29 = unchecked((nint)null);
								}
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							num23 = unchecked((nint)null);
						}
						throw new NullReferenceException();
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num21 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num8 = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	public void RemoveOnlineClientRunDataConfig()
	{
		_onlineClientWithRunDataConfig = null;
	}

	public void DestroyOnlineConfigs()
	{
		if (_hostGameConfig != null || _onlineClientWithRunDataConfig != null)
		{
			Debug.Log("Reverting back to MainGameConfig");
			_hostGameConfig = null;
			_hostGameConfigAtRunStart = null;
			_onlineClientWithRunDataConfig = null;
			if (AdventureManager._003CShouldExitAdventureModeOnDisconnect_003Ek__BackingField)
			{
				_adventureManager.ExitAdventureMode();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E45000");
			}
			bool onlineClientWithRunData = default(bool);
			ApplyConfig(_mainGameConfig, adventureMode: false, hostConfig: false, onlineClientWithRunData);
		}
	}

	public bool IsBought(CharacterType characterType, bool ignoreSkins, PlayerOptionsData config)
	{
		//IL_020c: Expected I4, but got O
		//IL_0193: Invalid comparison between F4 and I4
		//IL_01ef: Expected I4, but got O
		bool flag = default(bool);
		if (config != null && config._003CBoughtCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			if (!flag || ignoreSkins)
			{
				goto IL_01f4;
			}
			if (_dataManager != null)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
				if (convertedCharacterData != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
					if (obj != null)
					{
						List<CharacterData> list = ((Dictionary<CharacterType, List<CharacterData>>)obj).get_Item(characterType);
						if (list != null)
						{
							object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
							if (obj2 != null)
							{
								List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)obj2).get_Item(characterType);
								if (list2 != null)
								{
									Skin currentSkinData = ((CharacterData)(object)list2).GetCurrentSkinData();
									if (currentSkinData == null || !(currentSkinData._003Cprice_003Ek__BackingField > 0f))
									{
										goto IL_01f4;
									}
									if (config._003CBoughtSkins_003Ek__BackingField != null)
									{
										List<CharacterData> list3 = ((Dictionary<CharacterType, List<CharacterData>>)(object)config._003CBoughtSkins_003Ek__BackingField).get_Item((CharacterType)currentSkinData.skinType);
										return (byte)(int)list3 != 0;
									}
								}
							}
							goto IL_01fe;
						}
					}
					goto IL_01f4;
				}
			}
		}
		goto IL_01fe;
		IL_01fe:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01f4:
		return flag;
	}

	public bool IsBought(CharacterType characterType, bool ignoreSkins = false)
	{
		//IL_020c: Expected I4, but got O
		//IL_0185: Invalid comparison between F4 and I4
		PlayerOptionsData config = Config;
		bool flag = default(bool);
		if (config != null && config._003CBoughtCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			if (!flag || ignoreSkins)
			{
				goto IL_01f4;
			}
			if (_dataManager != null)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
				if (convertedCharacterData != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
						object obj2 = default(object);
						if (obj2 != null)
						{
							object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
								CharacterData characterData = default(CharacterData);
								if (characterData != null)
								{
									Skin currentSkinData = characterData.GetCurrentSkinData();
									if (currentSkinData != null && currentSkinData._003Cprice_003Ek__BackingField > 0f)
									{
										PlayerOptionsData config2 = Config;
										if (config2 == null || config2._003CBoughtSkins_003Ek__BackingField == null)
										{
											goto IL_01fe;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
									}
									goto IL_01f4;
								}
							}
							goto IL_01fe;
						}
					}
					goto IL_01f4;
				}
			}
		}
		goto IL_01fe;
		IL_01f4:
		return flag;
		IL_01fe:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsUnlocked(CharacterType characterType, PlayerOptionsData config)
	{
		//IL_0044: Expected I4, but got O
		if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsUnlocked(CharacterType characterType)
	{
		//IL_0044: Expected I4, but got O
		PlayerOptionsData config = Config;
		if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void UnlockCharacter(CharacterType characterType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void UnlockCharacter(CharacterType characterType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void RegisterCoffinOpen(CharacterType characterType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
		PlayerOptionsData config3 = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			PlayerOptionsData config4 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void BuyCharacter(CharacterType characterType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void BuyCharacter(CharacterType characterType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public unsafe void BuySkin(SkinType skinType, PlayerOptionsData config)
	{
		//IL_0038: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "Skin Bought, adding to BoughtSkins: " + text;
			Debug.Log(message);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3A70");
		}
	}

	public unsafe void BuySkin(SkinType skinType)
	{
		//IL_0038: Expected O, but got Ref
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "Skin Bought, adding to BoughtSkins: " + text;
			Debug.Log(message);
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3A70");
		}
	}

	public void RevealCharacter(CharacterType characterType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void RevealCharacter(CharacterType characterType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
	}

	public void AddGoldenEggToCharacter(CharacterType character, string attribute, float value)
	{
		//IL_02df: Expected O, but got I
		//IL_033a: Expected O, but got I
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)character);
		float num4 = default(float);
		if (num < 0)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			bool flag = ((Dictionary<object, float>)(object)dictionary).TryInsert((object)attribute, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			PlayerOptionsData mainGameConfig2 = _mainGameConfig;
			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CCharacterEggInfo_003Ek__BackingField).TryInsert((System.Int32Enum)character, (object)dictionary, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		else
		{
			PlayerOptionsData mainGameConfig3 = _mainGameConfig;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)character);
			int num2 = ((Dictionary<string, float>)obj).FindEntry(attribute);
			PlayerOptionsData mainGameConfig4 = _mainGameConfig;
			float value2;
			System.Collections.Generic.InsertionBehavior behavior;
			Dictionary<object, float> dictionary2;
			if (num2 < 0)
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig4._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)character);
				value2 = value;
				behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				dictionary2 = (Dictionary<object, float>)obj2;
			}
			else
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig4._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)character);
				float num3 = ((Dictionary<object, float>)obj3).get_Item((object)attribute);
				num4 = num3 + value;
				value2 = num4;
				behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
				dictionary2 = (Dictionary<object, float>)obj3;
			}
			bool flag3 = dictionary2.TryInsert((object)attribute, value2, behavior);
		}
		PlayerOptionsData mainGameConfig5 = _mainGameConfig;
		int num5 = mainGameConfig5._003CCharacterEggCount_003Ek__BackingField.FindEntry(character);
		PlayerOptionsData mainGameConfig6 = _mainGameConfig;
		Dictionary<System.Int32Enum, float> dictionary3;
		float value3;
		System.Collections.Generic.InsertionBehavior behavior2;
		if (num5 < 0)
		{
			dictionary3 = (Dictionary<System.Int32Enum, float>)(object)mainGameConfig6._003CCharacterEggCount_003Ek__BackingField;
			value3 = 1f;
			behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		else
		{
			int num6 = mainGameConfig6._003CCharacterEggCount_003Ek__BackingField.FindEntry(character);
			value3 = num4 + 1f;
			behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			dictionary3 = (Dictionary<System.Int32Enum, float>)(object)mainGameConfig6._003CCharacterEggCount_003Ek__BackingField;
		}
		bool flag4 = dictionary3.TryInsert((System.Int32Enum)character, value3, behavior2);
		PlayerOptionsData mainGameConfig7 = _mainGameConfig;
		List<ItemType> list = mainGameConfig7._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				return;
			}
		}
		PlayerOptionsData mainGameConfig8 = _mainGameConfig;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)mainGameConfig8._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v7+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((System.Int32Enum)27);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj6 = (nint)0 + (nint)1;
		_ = 27;
	}

	public SkinType GetSkinTypeForCharacter(CharacterType characterType)
	{
		//IL_0088: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_011e: Expected O, but got I
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
		bool flag = obj == null;
		System.Int32Enum int32Enum = (System.Int32Enum)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v9 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_01ea;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v9 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v23+20]");
			bool flag2 = (nint)0 == 0;
			int32Enum = (System.Int32Enum)0;
			if (!flag2)
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v24 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_01ea;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v24 (System.Object)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v25+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rbx_v9+184]");
				int32Enum = (System.Int32Enum)0;
			}
		}
		PlayerOptionsData config = Config;
		int num = config._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(characterType);
		if (num < 0)
		{
			PlayerOptionsData config2 = Config;
			bool flag3 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)config2._003CSelectedSkinsV2_003Ek__BackingField).TryInsert((System.Int32Enum)characterType, int32Enum, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			return (SkinType)int32Enum;
		}
		PlayerOptionsData config3 = Config;
		return config3._003CSelectedSkinsV2_003Ek__BackingField.get_Item(characterType);
		IL_01ea:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		SkinType result = default(SkinType);
		return result;
	}

	public Skin GetSkinForCharacter(CharacterType characterType)
	{
		//IL_000e: Expected O, but got I4
		Skin result = (Skin)GetSkinTypeForCharacter(characterType);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x186E41550\"");
		return result;
	}

	public unsafe Skin GetSkinForCharacter(CharacterType characterType, SkinType id)
	{
		//IL_009f: Expected O, but got I
		//IL_00dc: Expected O, but got I
		//IL_01e6: Expected O, but got I
		//IL_054c: Expected O, but got I
		//IL_0223: Expected O, but got I
		//IL_0581: Expected O, but got I
		//IL_0260: Expected O, but got I
		//IL_05bb: Expected O, but got I
		//IL_02c5: Expected O, but got I
		//IL_0626: Expected O, but got I
		//IL_065b: Expected O, but got I
		//IL_0695: Expected O, but got I
		//IL_03ba: Expected O, but got I
		//IL_0700: Expected O, but got I
		//IL_03f7: Expected O, but got I
		//IL_0735: Expected O, but got I
		//IL_0450: Expected O, but got Ref
		DataManager dataManager = _dataManager;
		Skin result;
		if (_dataManager != null)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			if (convertedCharacterData != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
				bool flag = obj == null;
				dataManager = (DataManager)(object)convertedCharacterData;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_07b6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					dataManager = (DataManager)(object)convertedCharacterData;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v13+20]");
						dataManager = (DataManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v13+20]");
						if ((nint)0 != 0)
						{
							if (dataManager._dlcMusicData != null)
							{
								dataManager = _dataManager;
								if (_dataManager != null)
								{
									Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
									if (convertedCharacterData2 != null)
									{
										object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)characterType);
										bool flag3 = obj3 == null;
										dataManager = (DataManager)(object)convertedCharacterData2;
										if (!flag3)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v75 (System.Object)+18]");
											if ((nint)0 <= (nint)0)
											{
												goto IL_07b6;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v75 (System.Object)+10]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v75 (System.Object)+10]");
											bool flag4 = (nint)0 == 0;
											dataManager = (DataManager)(object)convertedCharacterData2;
											if (!flag4)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v76+20]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v76+20]");
												bool flag5 = (nint)0 == 0;
												dataManager = (DataManager)(object)convertedCharacterData2;
												if (!flag5)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v77+78]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v77+78]");
													bool flag6 = (nint)0 == 0;
													dataManager = (DataManager)(object)convertedCharacterData2;
													if (!flag6)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v78+18]");
														if ((nint)0 <= (nint)0)
														{
															goto IL_07b6;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v78+10]");
														dataManager = (DataManager)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v78+10]");
														if ((nint)0 != 0)
														{
															result = (Skin)(object)dataManager._characterData;
															dataManager = _dataManager;
															if (_dataManager != null)
															{
																Dictionary<CharacterType, List<CharacterData>> convertedCharacterData3 = _dataManager.GetConvertedCharacterData();
																if (convertedCharacterData3 != null)
																{
																	object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData3).get_Item((System.Int32Enum)characterType);
																	bool flag7 = obj7 == null;
																	dataManager = (DataManager)(object)convertedCharacterData3;
																	if (!flag7)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v80 (System.Object)+18]");
																		if ((nint)0 <= (nint)0)
																		{
																			goto IL_07b6;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v80 (System.Object)+10]");
																		object obj8 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v80 (System.Object)+10]");
																		bool flag8 = (nint)0 == 0;
																		dataManager = (DataManager)(object)convertedCharacterData3;
																		if (!flag8)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v81+20]");
																			dataManager = (DataManager)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v81+20]");
																			if ((nint)0 != 0 && dataManager._dlcMusicData != null)
																			{
																				List<Skin>.Enumerator enumerator = default(List<Skin>.Enumerator);
																				if (enumerator.MoveNext())
																				{
																					Skin skin = null;
																					List<Skin>.Enumerator enumerator2 = (List<Skin>.Enumerator)(&enumerator);
																					throw new NullReferenceException();
																				}
																				goto IL_0807;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
							else
							{
								Skin skin2 = new Skin();
								List<string> list = new List<string>();
								skin2._003CexWeapons_003Ek__BackingField = list;
								List<string> list2 = new List<string>();
								skin2._003CexAccessories_003Ek__BackingField = list2;
								List<string> list3 = new List<string>();
								skin2._003ChiddenWeapons_003Ek__BackingField = list3;
								skin2.skinType = SkinType.DEFAULT;
								object obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
								if (obj9 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v28 (System.Object)+18]");
									if ((nint)0 <= (nint)0)
									{
										goto IL_07b6;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v28 (System.Object)+10]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v28 (System.Object)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v29+20]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v29+20]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v30+48]");
											skin2._003CspriteName_003Ek__BackingField = (string)0;
											object obj12 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
											if (obj12 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v33 (System.Object)+18]");
												if ((nint)0 <= (nint)0)
												{
													goto IL_07b6;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v33 (System.Object)+10]");
												object obj13 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v33 (System.Object)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v34+20]");
													object obj14 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v34+20]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v35+40]");
														skin2._003CtextureName_003Ek__BackingField = (string)0;
														object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
														if (obj15 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v38 (System.Object)+18]");
															if ((nint)0 <= (nint)0)
															{
																goto IL_07b6;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v38 (System.Object)+10]");
															object obj16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v38 (System.Object)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v39+20]");
																object obj17 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v39+20]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v40+68]");
																	skin2._003CwalkingFrames_003Ek__BackingField = 0;
																	result = skin2;
																	goto IL_0807;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_07b6:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Skin result2 = default(Skin);
		return result2;
		IL_0807:
		return result;
	}

	public bool HasUnlockedSkin(CharacterType characterType, SkinType skinType)
	{
		//IL_00fc: Expected I4, but got O
		PlayerOptionsData config = Config;
		if (config != null && config._003CUnlockedSkinsV2_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CUnlockedSkinsV2_003Ek__BackingField).FindEntry((System.Int32Enum)characterType);
			if (num < 0)
			{
				return false;
			}
			PlayerOptionsData config2 = Config;
			if (config2 != null && config2._003CUnlockedSkinsV2_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CUnlockedSkinsV2_003Ek__BackingField).get_Item((System.Int32Enum)characterType);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
					bool result = default(bool);
					return result;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ClearEggsOnSigma()
	{
		PlayerOptionsData config = Config;
		if (config._003CCharacterEggInfo_003Ek__BackingField != null)
		{
			PlayerOptionsData config2 = Config;
			int num = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)48);
			if (num >= 0)
			{
				PlayerOptionsData config3 = Config;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).Remove((System.Int32Enum)48);
			}
		}
		PlayerOptionsData config4 = Config;
		if (config4._003CCharacterEggCount_003Ek__BackingField != null)
		{
			PlayerOptionsData config5 = Config;
			int num2 = config5._003CCharacterEggCount_003Ek__BackingField.FindEntry(CharacterType.SIGMA);
			if (num2 >= 0)
			{
				PlayerOptionsData config6 = Config;
				bool flag2 = config6._003CCharacterEggCount_003Ek__BackingField.Remove(CharacterType.SIGMA);
			}
		}
	}

	public List<CharacterType> GetCustomMerchantCharacters()
	{
		//IL_0433: Expected O, but got I4
		List<CharacterType> list = new List<CharacterType>();
		PlayerOptionsData config = Config;
		if (config != null)
		{
			List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
			if (config._003CCollectedItems_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj = default(object);
					if ((nint)obj != -1)
					{
						goto IL_00ee;
					}
				}
				PlayerOptionsData config2 = Config;
				if (config2 != null)
				{
					List<ItemType> list3 = config2._003CCollectedItems_003Ek__BackingField;
					if (config2._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj2 = default(object);
							if ((nint)obj2 != -1)
							{
								goto IL_00ee;
							}
						}
						goto IL_029d;
					}
				}
			}
		}
		goto IL_0441;
		IL_043c:
		return list;
		IL_029d:
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				if (stage._stageType != StageType.SINKING)
				{
					goto IL_043c;
				}
				Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
				if (loadedDlc != null)
				{
					Dictionary<DlcType, BundleManifestData>.KeyCollection keys = loadedDlc.Keys;
					IEnumerable<DlcType> enumerable = Enumerable.Intersect(keys, XanthiaDLCList);
					if (!Enumerable.Any(enumerable))
					{
						goto IL_043c;
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._multiplayer != null)
					{
						if (core2._multiplayer.IsOnlineMultiplayer)
						{
							IEnumerable<DlcType> source = Enumerable.Except(enumerable, DlcSystem.OnlineAvaliableDlcTypes);
							if (Enumerable.Any(source))
							{
								goto IL_043c;
							}
						}
						if (list != null)
						{
							IEnumerable<DlcType> enumerable2 = Enumerable.Except((IEnumerable<DlcType>)list, (IEnumerable<DlcType>)42);
							goto IL_043c;
						}
					}
				}
			}
		}
		goto IL_0441;
		IL_00ee:
		GameManager core3 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage2 = core3._stage;
			if ((object)core3._stage != null)
			{
				if (stage2._stageType == StageType.ADV_BAZAAR)
				{
					goto IL_029d;
				}
				Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
				if (loadedDlc2 != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)5);
					if (num < 0)
					{
						goto IL_029d;
					}
					GameManager core4 = GM.Core;
					if ((object)GM.Core != null && core4._multiplayer != null)
					{
						if (core4._multiplayer.IsOnlineMultiplayer)
						{
							if (DlcSystem.OnlineAvaliableDlcTypes == null)
							{
								goto IL_0441;
							}
							if (((Dictionary<DlcType, BundleManifestData>)(object)DlcSystem.OnlineAvaliableDlcTypes).FindEntry(DlcType.ThosePeople) == 0)
							{
								goto IL_029d;
							}
						}
						if (list != null)
						{
							int num2 = ((Dictionary<DlcType, BundleManifestData>)(object)list).FindEntry((DlcType)256);
							goto IL_029d;
						}
					}
				}
			}
		}
		goto IL_0441;
		IL_0441:
		return (List<CharacterType>)(object)new NullReferenceException();
	}

	public void UnlockWeapon(WeaponType weaponType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
	}

	public void UnlockWeapon(WeaponType weaponType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
	}

	public void UnlockStage(StageType stageType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
		}
	}

	public void UnlockStage(StageType stageType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
		}
	}

	public void UnlockHyper(StageType stageType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
		}
	}

	public void UnlockHyper(StageType stageType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
		}
	}

	public void UnlockItem(ItemType itemType, PlayerOptionsData config)
	{
		PlayerOptionsData config2 = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
		}
	}

	public void UnlockItem(ItemType itemType)
	{
		PlayerOptionsData config = Config;
		UnlockItem(itemType, config);
	}

	public void UnlockPowerUp(PowerUpType powerUpType, PlayerOptionsData config)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
		}
	}

	public void UnlockPowerUp(PowerUpType powerUpType)
	{
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
		}
	}

	public unsafe void AddDisabledPowerUp(PowerUpType type)
	{
		//IL_0051: Expected O, but got Ref
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "Disabling " + text;
			Debug.Log(message);
		}
	}

	public unsafe void RemoveDisabledPowerup(PowerUpType type)
	{
		//IL_005a: Expected O, but got Ref
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A980C0");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config2 = Config;
			bool flag = ((List<System.Int32Enum>)(object)config2._003CDisabledPowerups_003Ek__BackingField).Remove((System.Int32Enum)type);
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "Enabling " + text;
			Debug.Log(message);
		}
	}

	public void RestoreUnlockablePowerups()
	{
	}

	public unsafe bool UnlockSecret(SecretType secretType, PlayerOptionsData config)
	{
		//IL_0087: Expected O, but got Ref
		//IL_062a: Expected O, but got I4
		//IL_0423: Expected O, but got I
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_0365: Expected F4, but got I
		//IL_053c: Expected O, but got I4
		//IL_0544: Expected O, but got Ref
		DataManager dataManager = _dataManager;
		List<VampireSurvivors.Achievements.SkinToUnlock>.Enumerator enumerator2;
		if (((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllSecrets_003Ek__BackingField).TryGetValue((System.Int32Enum)secretType, out object value) && !((Dictionary<SecretType, SecretData>)(object)config._003CSecrets_003Ek__BackingField).TryGetValue(secretType, out *(SecretData*)(&value)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-68_v5 (System.Object)+20]");
			bool flag = (nint)0 == 0;
			object obj = value;
			PlayerOptionsData playerOptionsData = (PlayerOptionsData)(&value);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-68_v5 (System.Object)+20]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-68_v5 (System.Object)+20]");
				WeaponType weaponType = (WeaponType)((nint)0 >> 32);
				UnlockWeapon(weaponType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+18]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+18]");
				CharacterType characterType = (CharacterType)((nint)0 >> 32);
				UnlockCharacter(characterType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+28]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+28]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+28]");
				StageType stageType = (StageType)((nint)0 >> 32);
				UnlockStage(stageType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+30]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+30]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+30]");
				StageType stageType2 = (StageType)((nint)0 >> 32);
				UnlockHyper(stageType2, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+38]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+38]");
				ItemType itemType = (ItemType)((nint)0 >> 32);
				UnlockItem(itemType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+6C]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+6C]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+6C]");
				float value2 = (nint)0 >> 32;
				AddCoinsFlat(value2, config);
				obj = value;
				playerOptionsData = null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+48]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+48]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+48]");
				PowerUpType powerUpType = (PowerUpType)((nint)0 >> 32);
				UnlockPowerUp(powerUpType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+40]");
			object obj2 = (nint)0 >> 32;
			object obj3 = ~obj2;
			object obj4 = obj3 >> 31;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+40]");
			object obj5 = 0 & obj4;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+40]");
				if ((nint)0 == 0)
				{
					goto IL_061c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+40]");
				ArcanaType arcanaType = (ArcanaType)((nint)0 >> 32);
				UnlockArcana(arcanaType, config);
				obj = value;
				playerOptionsData = config;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+78]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v16 (System.Object)+78]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ rax_v33 (Il2CppMethodInfo)+18]");
				List<VampireSurvivors.Achievements.SkinToUnlock>.Enumerator enumerator = default(List<VampireSurvivors.Achievements.SkinToUnlock>.Enumerator);
				if ((nint)0 > (nint)0 && enumerator.MoveNext())
				{
					object obj6 = 0;
					enumerator2 = (List<VampireSurvivors.Achievements.SkinToUnlock>.Enumerator)(&enumerator);
					goto IL_063e;
				}
			}
			PlayerOptionsData config2 = Config;
			if (!((Dictionary<SecretType, SecretData>)(object)config2._003CSecrets_003Ek__BackingField).TryGetValue(secretType, out *(SecretData*)playerOptionsData))
			{
				PlayerOptionsData config3 = Config;
				bool flag2 = ((Dictionary<SecretType, SecretData>)(object)config3._003CSecrets_003Ek__BackingField).TryGetValue(secretType, out *(SecretData*)playerOptionsData);
			}
			Save();
			return true;
		}
		return false;
		IL_063e:
		throw new NullReferenceException();
		IL_061c:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		enumerator2 = (List<VampireSurvivors.Achievements.SkinToUnlock>.Enumerator)0;
		goto IL_063e;
	}

	public bool UnlockSecret(SecretType secretType)
	{
		PlayerOptionsData config = Config;
		return UnlockSecret(secretType, config);
	}

	public bool UnlockSecretInBaseGame(SecretType secretType)
	{
		return UnlockSecret(secretType, _mainGameConfig);
	}

	public static void AddCoinsFlat(float value, PlayerOptionsData config)
	{
		//IL_0022: Invalid comparison between I4 and F4
		//IL_00d5: Expected F4, but got I4
		//IL_025b: Invalid comparison between I4 and F4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0179: Expected F4, but got I4
		//IL_0299: Invalid comparison between I4 and F4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_021d: Expected F4, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		float num = value + config._003CCoins_003Ek__BackingField;
		if (!(0f > num))
		{
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E4314Bh\"");
					if (num != -1f / 0f)
					{
						goto IL_0231;
					}
				}
			}
			num = 3.4028235E+38f;
		}
		else
		{
			num = 0f;
		}
		goto IL_0231;
		IL_0231:
		config._003CCoins_003Ek__BackingField = num;
		float num2 = value + config._003CLifetimeCoins_003Ek__BackingField;
		if (!(0f > num2))
		{
			object obj3 = num2 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num2 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E43190h\"");
					if (num2 != -1f / 0f)
					{
						goto IL_026f;
					}
				}
			}
			num2 = 3.4028235E+38f;
		}
		else
		{
			num2 = 0f;
		}
		goto IL_026f;
		IL_026f:
		float num3 = value + config._003CTotalCoins_003Ek__BackingField;
		config._003CLifetimeCoins_003Ek__BackingField = num2;
		if (!(0f > num3))
		{
			object obj5 = num3 & -2147483649L;
			if ((nint)obj5 != 2139095040)
			{
				object obj6 = num3 & -2147483649L;
				if ((nint)obj6 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E431D2h\"");
					if (num3 != -1f / 0f)
					{
						goto IL_02ad;
					}
				}
			}
			num3 = 3.4028235E+38f;
		}
		else
		{
			num3 = 0f;
		}
		goto IL_02ad;
		IL_02ad:
		config._003CTotalCoins_003Ek__BackingField = num3;
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v151.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void AddCoinsFlat(float value)
	{
		PlayerOptionsData config = Config;
		AddCoinsFlat(value, config);
	}

	public void AddCoinsNoRun(float value, VampireSurvivors.Objects.Characters.CharacterController player = null)
	{
		//IL_00d1: Invalid comparison between I4 and F4
		//IL_0184: Expected F4, but got I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_01cc: Invalid comparison between I4 and F4
		//IL_027f: Expected F4, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_02c7: Invalid comparison between I4 and F4
		//IL_037a: Expected F4, but got I4
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		float num = value * GameManager.GoldMultiplier;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)player != null)
		{
			bool flag = ((UnityEngine.Object)player).m_CachedPtr != (IntPtr)0;
			characterController = player;
			if (flag)
			{
				goto IL_03be;
			}
		}
		GameSessionData gameSessionData = _gameSessionData;
		characterController = gameSessionData._activeCharacter;
		goto IL_03be;
		IL_0189:
		PlayerOptionsData config;
		float num2;
		config._003CCoins_003Ek__BackingField = num2;
		PlayerOptionsData config2 = Config;
		PlayerOptionsData config3 = Config;
		float num3 = num + config3._003CLifetimeCoins_003Ek__BackingField;
		if (!(0f > num3))
		{
			object obj = num3 & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num3 & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E4353Fh\"");
					if (num3 != -1f / 0f)
					{
						goto IL_0284;
					}
				}
			}
			num3 = 3.4028235E+38f;
		}
		else
		{
			num3 = 0f;
		}
		goto IL_0284;
		IL_037f:
		PlayerOptionsData config4;
		float num4;
		config4._003CTotalCoins_003Ek__BackingField = num4;
		return;
		IL_03be:
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			float num5 = characterController.PGreed();
			object obj3 = default(object);
			num *= (float)obj3;
		}
		config = Config;
		PlayerOptionsData config5 = Config;
		num2 = num + config5._003CCoins_003Ek__BackingField;
		if (!(0f > num2))
		{
			object obj4 = num2 & -2147483649L;
			if ((nint)obj4 != 2139095040)
			{
				object obj5 = num2 & -2147483649L;
				if ((nint)obj5 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E434C8h\"");
					if (num2 != -1f / 0f)
					{
						goto IL_0189;
					}
				}
			}
			num2 = 3.4028235E+38f;
		}
		else
		{
			num2 = 0f;
		}
		goto IL_0189;
		IL_0284:
		config2._003CLifetimeCoins_003Ek__BackingField = num3;
		config4 = Config;
		PlayerOptionsData config6 = Config;
		num4 = num + config6._003CTotalCoins_003Ek__BackingField;
		if (!(0f > num4))
		{
			object obj6 = num4 & -2147483649L;
			if ((nint)obj6 != 2139095040)
			{
				object obj7 = num4 & -2147483649L;
				if ((nint)obj7 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E435AFh\"");
					if (num4 != -1f / 0f)
					{
						goto IL_037f;
					}
				}
			}
			num4 = 3.4028235E+38f;
		}
		else
		{
			num4 = 0f;
		}
		goto IL_037f;
	}

	public float RemoveCoinsFlat(float value)
	{
		PlayerOptionsData config = Config;
		PlayerOptionsData config2 = Config;
		if (config2 != null && config != null)
		{
			float num = MathUtils.SubtractValueCapped(config2._003CCoins_003Ek__BackingField, value);
			config._003CCoins_003Ek__BackingField = num;
			PlayerOptionsData config3 = Config;
			PlayerOptionsData config4 = Config;
			if (config4 != null && config3 != null)
			{
				num = MathUtils.SubtractValueCapped(config4._003CRunCoins_003Ek__BackingField, value);
				config3._003CRunCoins_003Ek__BackingField = num;
				PlayerOptionsData config5 = Config;
				PlayerOptionsData config6 = Config;
				if (config6 != null && config5 != null)
				{
					num = MathUtils.SubtractValueCapped(config6._003CLifetimeCoins_003Ek__BackingField, value);
					config5._003CLifetimeCoins_003Ek__BackingField = num;
					PlayerOptionsData config7 = Config;
					PlayerOptionsData config8 = Config;
					if (config8 != null && config7 != null)
					{
						float num2 = MathUtils.SubtractValueCapped(config8._003CTotalCoins_003Ek__BackingField, value);
						config7._003CTotalCoins_003Ek__BackingField = num2;
						OnValueChanged runGoldUpdated = this.m_RunGoldUpdated;
						if (this.m_RunGoldUpdated != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
						OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
						if (PlayerOptions.m_GoldUpdated != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v162.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
						return value;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public float AddCoins(float value, VampireSurvivors.Objects.Characters.CharacterController player = null)
	{
		//IL_00eb: Invalid comparison between I4 and F4
		//IL_019e: Expected F4, but got I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0203: Invalid comparison between I4 and F4
		//IL_02b6: Expected F4, but got I4
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_031b: Invalid comparison between I4 and F4
		//IL_03ce: Expected F4, but got I4
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0433: Invalid comparison between I4 and F4
		//IL_04e6: Expected F4, but got I4
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_06f9: Expected I, but got O
		//IL_0715: Expected O, but got I
		float num = value * GameManager.GoldMultiplier;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)player != null)
		{
			bool flag = ((UnityEngine.Object)player).m_CachedPtr != (IntPtr)0;
			characterController = player;
			if (flag)
			{
				goto IL_05c3;
			}
		}
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData == null)
		{
			goto IL_0587;
		}
		characterController = gameSessionData._activeCharacter;
		goto IL_05c3;
		IL_064b:
		PlayerOptionsData config;
		PlayerOptionsData config2;
		float num2 = default(float);
		if (config != null)
		{
			config._003CLifetimeCoins_003Ek__BackingField = num2;
			config2 = Config;
			PlayerOptionsData config3 = Config;
			if (config3 != null)
			{
				num2 = num + config3._003CTotalCoins_003Ek__BackingField;
				if (!(0f > num2))
				{
					object obj = num2 & -2147483649L;
					if ((nint)obj != 2139095040)
					{
						object obj2 = num2 & -2147483649L;
						if ((nint)obj2 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E43B39h\"");
							if (num2 != -1f / 0f)
							{
								goto IL_0668;
							}
						}
					}
					num2 = 3.4028235E+38f;
				}
				else
				{
					num2 = 0f;
				}
				goto IL_0668;
			}
		}
		goto IL_0587;
		IL_0611:
		PlayerOptionsData config4;
		PlayerOptionsData config5;
		if (config4 != null)
		{
			config4._003CCoins_003Ek__BackingField = num2;
			config5 = Config;
			PlayerOptionsData config6 = Config;
			if (config6 != null)
			{
				num2 = num + config6._003CRunCoins_003Ek__BackingField;
				if (!(0f > num2))
				{
					object obj3 = num2 & -2147483649L;
					if ((nint)obj3 != 2139095040)
					{
						object obj4 = num2 & -2147483649L;
						if ((nint)obj4 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E43A59h\"");
							if (num2 != -1f / 0f)
							{
								goto IL_062e;
							}
						}
					}
					num2 = 3.4028235E+38f;
				}
				else
				{
					num2 = 0f;
				}
				goto IL_062e;
			}
		}
		goto IL_0587;
		IL_0587:
		throw new NullReferenceException();
		IL_05c3:
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			float num3 = characterController.PGreed();
			num *= num2;
		}
		config4 = Config;
		PlayerOptionsData config7 = Config;
		if (config7 == null)
		{
			goto IL_0587;
		}
		num2 = num + config7._003CCoins_003Ek__BackingField;
		if (!(0f > num2))
		{
			object obj5 = num2 & -2147483649L;
			if ((nint)obj5 != 2139095040)
			{
				object obj6 = num2 & -2147483649L;
				if ((nint)obj6 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E439E9h\"");
					if (num2 != -1f / 0f)
					{
						goto IL_0611;
					}
				}
			}
			num2 = 3.4028235E+38f;
		}
		else
		{
			num2 = 0f;
		}
		goto IL_0611;
		IL_062e:
		if (config5 != null)
		{
			config5._003CRunCoins_003Ek__BackingField = num2;
			config = Config;
			PlayerOptionsData config8 = Config;
			if (config8 != null)
			{
				num2 = num + config8._003CLifetimeCoins_003Ek__BackingField;
				if (!(0f > num2))
				{
					object obj7 = num2 & -2147483649L;
					if ((nint)obj7 != 2139095040)
					{
						object obj8 = num2 & -2147483649L;
						if ((nint)obj8 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E43AC9h\"");
							if (num2 != -1f / 0f)
							{
								goto IL_064b;
							}
						}
					}
					num2 = 3.4028235E+38f;
				}
				else
				{
					num2 = 0f;
				}
				goto IL_064b;
			}
		}
		goto IL_0587;
		IL_0668:
		if (config2 != null)
		{
			config2._003CTotalCoins_003Ek__BackingField = num2;
			OnValueChanged runGoldUpdated = this.m_RunGoldUpdated;
			if (this.m_RunGoldUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v885.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
			if (PlayerOptions.m_GoldUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v196.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			if (_signalBus != null)
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj10 = default(object);
				object obj9 = obj10 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num4 = intPtr;
				object obj11 = default(object);
				object signal = (IntPtr)obj11;
				bool requireDeclaration = default(bool);
				_signalBus.InternalFire((Type)num4, signal, (object)null, requireDeclaration);
				return num;
			}
		}
		goto IL_0587;
	}

	public void RemoveCoins(int value, bool removeFromLifetime, PlayerOptionsData config)
	{
		//IL_0017: Expected F4, but got I4
		//IL_003b: Expected F4, but got I4
		//IL_005b: Expected F4, but got I4
		//IL_0074: Expected F4, but got I4
		float num = MathUtils.SubtractValueCapped(config._003CCoins_003Ek__BackingField, value);
		config._003CCoins_003Ek__BackingField = num;
		bool flag = !removeFromLifetime;
		float num2 = value;
		if (!flag)
		{
			num = MathUtils.SubtractValueCapped(config._003CLifetimeCoins_003Ek__BackingField, value);
			config._003CLifetimeCoins_003Ek__BackingField = num;
			num2 = value;
		}
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v128.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Save();
	}

	public void RemoveCoins(int value, bool removeFromLifetime = false)
	{
		//IL_0017: Expected F4, but got I4
		//IL_003b: Expected F4, but got I4
		//IL_0074: Expected F4, but got I4
		//IL_008d: Expected F4, but got I4
		PlayerOptionsData config = Config;
		PlayerOptionsData config2 = Config;
		float num = MathUtils.SubtractValueCapped(config2._003CCoins_003Ek__BackingField, value);
		config._003CCoins_003Ek__BackingField = num;
		bool flag = !removeFromLifetime;
		float num2 = value;
		if (!flag)
		{
			PlayerOptionsData config3 = Config;
			PlayerOptionsData config4 = Config;
			num = MathUtils.SubtractValueCapped(config4._003CLifetimeCoins_003Ek__BackingField, value);
			config3._003CLifetimeCoins_003Ek__BackingField = num;
			num2 = value;
		}
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Save();
	}

	public void RemoveCoins(float value, bool removeFromLifetime = false)
	{
		PlayerOptionsData config = Config;
		PlayerOptionsData config2 = Config;
		float valueToSubtract = default(float);
		float num = MathUtils.SubtractValueCapped(config2._003CCoins_003Ek__BackingField, valueToSubtract);
		config._003CCoins_003Ek__BackingField = num;
		if (removeFromLifetime)
		{
			PlayerOptionsData config3 = Config;
			PlayerOptionsData config4 = Config;
			num = MathUtils.SubtractValueCapped(config4._003CLifetimeCoins_003Ek__BackingField, valueToSubtract);
			config3._003CLifetimeCoins_003Ek__BackingField = num;
		}
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v198.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Save();
	}

	public void AwardAdventureStar()
	{
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		float num = mainGameConfig._003CAdventureStars_003Ek__BackingField + 1f;
		mainGameConfig._003CAdventureStars_003Ek__BackingField = num;
		OnValueChanged adventureStarsUpdated = PlayerOptions.m_AdventureStarsUpdated;
		if (PlayerOptions.m_AdventureStarsUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v61.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Save();
	}

	private void InitSession()
	{
		PlayerOptionsData config = Config;
		config._003CRunCoins_003Ek__BackingField = 0f;
	}

	private void UnlockCharacter(UISignals.CharacterUnlockedSignal sig)
	{
		//IL_000a: Expected I4, but got O
		UnlockCharacter((CharacterType)sig);
	}

	private void BuyCharacter(UISignals.CharacterBoughtSignal sig)
	{
		//IL_000a: Expected I4, but got O
		BuyCharacter((CharacterType)sig);
	}

	private unsafe void BuySkin(UISignals.SkinBoughtSignal sig)
	{
		//IL_0038: Expected O, but got Ref
		PlayerOptionsData config = Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0D40");
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "Skin Bought, adding to BoughtSkins: " + text;
			Debug.Log(message);
			PlayerOptionsData config2 = Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3A70");
		}
	}

	private void UnlockStage(UISignals.StageUnlockedSignal sig)
	{
		//IL_003a: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_0078: Expected I4, but got O
		PlayerOptionsData config = Config;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)sig);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private void UnlockWeapon(UISignals.WeaponUnlockedSignal sig)
	{
		//IL_003a: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_0078: Expected I4, but got O
		PlayerOptionsData config = Config;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)sig);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private void LanguageSelected(UISignals.LanguageSelectedSignal sig)
	{
		string message = "Setting language : " + (string)sig;
		Debug.Log(message);
		PlayerOptionsData config = Config;
		config._003CLanguage_003Ek__BackingField = (string)sig;
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		mainGameConfig._003CLanguage_003Ek__BackingField = (string)sig;
	}

	private void FullScreenChanged(UISignals.SetFullscreenSignal sig)
	{
		//IL_001c: Expected I4, but got O
		//IL_0022: Expected O, but got I
		PlayerOptionsData config = Config;
		config._003CFullscreen_003Ek__BackingField = (byte)(int)sig != 0;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v59 @ rax_v7 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	private void BuyPowerUp(UISignals.BuyPowerUpSignal sig)
	{
		//IL_0089: Expected I4, but got O
		PlayerOptionsData config = Config;
		if (config != null && config._003CBoughtPowerups_003Ek__BackingField != null)
		{
			List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
			PlayerOptions playerOptions2;
			if (enumerator.MoveNext())
			{
				PlayerOptions playerOptions = null;
				playerOptions2 = null;
				throw new NullReferenceException();
			}
			PowerUpLevel powerUpLevel = new PowerUpLevel();
			bool flag = powerUpLevel == null;
			playerOptions2 = (PlayerOptions)(object)typeof(PowerUpLevel);
			if (!flag)
			{
				powerUpLevel.PowerUp = (PowerUpType)sig;
				powerUpLevel.Level = 1;
				PlayerOptionsData config2 = Config;
				if (config2 != null && config2._003CBoughtPowerups_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98190");
					OnValueChanged powerUpPurchased = this.m_PowerUpPurchased;
					if (this.m_PowerUpPurchased != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v378.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnCharacterSelectionUpdated(UISignals.ConfirmCharacterSignal signal)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config.SelectedCharacter = (CharacterType)signal;
	}

	private void OnStageSelectionChanged(UISignals.ConfirmStageSelectionSignal signal)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CSelectedStage_003Ek__BackingField = (StageType)signal;
	}

	private void ApplySoundsVolume(UISignals.SetSFXVolumeSignal sig)
	{
		//IL_0012: Expected F4, but got O
		//IL_002e: Expected F4, but got O
		PlayerOptionsData config = Config;
		config._003CSoundsVolume_003Ek__BackingField = (float)sig;
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		mainGameConfig._003CSoundsVolume_003Ek__BackingField = (float)sig;
		PlayerOptionsData mainGameConfig2 = _mainGameConfig;
		MasterAudio.MasterVolumeLevel = mainGameConfig2._003CSoundsVolume_003Ek__BackingField;
	}

	private void ApplyMusicVolume(UISignals.SetMusicVolumeSignal sig)
	{
		//IL_0012: Expected F4, but got O
		//IL_002e: Expected F4, but got O
		PlayerOptionsData config = Config;
		config._003CMusicVolume_003Ek__BackingField = (float)sig;
		PlayerOptionsData mainGameConfig = _mainGameConfig;
		mainGameConfig._003CMusicVolume_003Ek__BackingField = (float)sig;
		PlayerOptionsData mainGameConfig2 = _mainGameConfig;
		if (SoundManager._003CCurrentMusicSoundConfig_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v15+14]");
			if ((nint)0 != 0)
			{
				PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
				float playlistVolume = mainGameConfig2._003CMusicVolume_003Ek__BackingField * SoundManager._currentVolume;
				onlyPlaylistController._playlistVolume = playlistVolume;
				onlyPlaylistController.UpdateMasterVolume();
			}
		}
	}

	private void ApplyDamageNumbers(UISignals.SetDamageNumbersSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CDamageNumbersEnabled_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void ApplyGlimmerCarousel(UISignals.SetGlimmerCarouselSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CGlimmerCarouselEnabled_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void ApplyVisibleJoysticks(UISignals.SetVisibleJoysticksSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CJoystickVisible_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void RefundPowerups(UISignals.RefundPowerUpsSignal sig)
	{
		//IL_0054: Invalid comparison between I4 and F4
		//IL_0107: Expected F4, but got I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_03a9: Expected O, but got I
		//IL_03be: Expected O, but got I
		//IL_0322: Expected O, but got I
		//IL_0283: Expected O, but got I
		//IL_02d3: Expected O, but got I
		PlayerOptionsData config = Config;
		PlayerOptionsData config2 = Config;
		float totalPrice = _playerStats.GetTotalPrice();
		float totalMarkup = _playerStats.GetTotalMarkup();
		float num = totalMarkup + totalPrice;
		float num2 = num + config2._003CCoins_003Ek__BackingField;
		if (!(0f > num2))
		{
			object obj = num2 & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num2 & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E44AC7h\"");
					if (num2 != -1f / 0f)
					{
						goto IL_010c;
					}
				}
			}
			num2 = 3.4028235E+38f;
		}
		else
		{
			num2 = 0f;
		}
		goto IL_010c;
		IL_010c:
		config._003CCoins_003Ek__BackingField = num2;
		PlayerOptionsData config3 = Config;
		List<PowerUpLevel> list = config3._003CBoughtPowerups_003Ek__BackingField;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		PlayerOptionsData config4 = Config;
		List<ItemType> list2 = config4._003CSealedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptionsData config5 = Config;
		List<WeaponType> list3 = config5._003CSealedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		OnValueChanged goldUpdated = PlayerOptions.m_GoldUpdated;
		if (PlayerOptions.m_GoldUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v79.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		OnValueChanged powerUpsRefunded = this.m_PowerUpsRefunded;
		if (this.m_PowerUpsRefunded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v447.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (_hostGameConfig == null || _currentAdventureSaveData == null)
		{
			return;
		}
		object obj3 = HostPlayerOptions._003CInstance_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rbx_v5 (System.Object)+40]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v6+160]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v6+160]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v22+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v26+10]");
				object obj7 = -3;
				bool flag2 = obj7 == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		Action action = ((HostPlayerOptions)obj3).SendRefundPowerUps;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rbx_v5 (System.Object)+40]");
		bool flag3 = ((CoherenceSync)0).SendCommand(action, MessageTarget.Other);
	}

	private void ApplyFlashingVFX(UISignals.SetFlashingVFXSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CFlashingVFXEnabled_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void ApplyHideStageProgression(UISignals.ToggleStageProgressionSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CHideProgress_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void ToggleMovingBackground(UISignals.ToggleMovingBackgroundSignal sig)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CDisableMovingBackground_003Ek__BackingField = (byte)(int)sig != 0;
	}

	private void ApplyHideXpBar(UISignals.ToggleXPBarSignal sig)
	{
	}

	private void ApplyStreamerSafeMusic(UISignals.SetStreamerSafeMusicSignal signal)
	{
		//IL_001c: Expected I4, but got O
		PlayerOptionsData config = Config;
		config._003CStreamSafeEnabled_003Ek__BackingField = (byte)(int)signal != 0;
	}

	private void ApplyPixelFontDefault()
	{
		PlayerOptionsData config = Config;
		string text = config._003CsaveDate_003Ek__BackingField;
		if (config._003CsaveDate_003Ek__BackingField == null || text._stringLength <= 0)
		{
			PlayerOptionsData config2 = Config;
			config2._003CPixelFont_003Ek__BackingField = false;
		}
	}

	public PlayerOptions()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_00ec: Expected O, but got I
		List<DlcType> list = new List<DlcType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 6;
		}
		XanthiaDLCList = list;
	}

	static PlayerOptions()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("PlayerOptions.Save", 1, MarkerFlags.Default, 0);
		MarkerSave = (ProfilerMarker)(nint)intPtr;
	}
}
