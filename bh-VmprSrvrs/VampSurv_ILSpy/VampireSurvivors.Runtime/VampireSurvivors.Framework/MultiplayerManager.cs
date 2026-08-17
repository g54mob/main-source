using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using Rewired;
using Rewired.Integration.UnityUI;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Framework;

public class MultiplayerManager : IInitializable, IDisposable, ITickable
{
	public delegate void OnPlayerStateChange(Player p);

	public delegate void OnControllerStateChange(Player p);

	public delegate void OnRefresh();

	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public ControllerAssignmentChangedEventArgs args;

		internal bool _003COnPlayerControllerRemoved_003Eb__0(Joystick j)
		{
			//IL_0068: Expected I4, but got O
			if (args != null)
			{
				Controller controller = args.controller;
				object obj = (object)j - (object)controller;
				bool flag = obj == null;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private CoopConfig _coopConfig;

	public int? PartySize;

	public bool PartyModeEnabled;

	private const string POPUP_ID_PREFIX = "ControllerDisconnect-";

	private OnControllerStateChange m_ControllerDisconnected;

	private OnRefresh m_RefreshUI;

	private List<Player> _rewiredPlayersToRemove;

	private Player _previousUIControllingPlayer;

	private static MultiplayerManager s_instance;

	private List<CoopSlotData> _slotsSelections;

	private List<Player> _rewiredPlayersWithSlotsCache;

	private List<Player> _disconnectedPlayers;

	public bool AllowPlayerJoining;

	public bool AllowPlayerRemoval;

	public bool AllowP1Reassign;

	private bool _hasForcedPauseForDisconnect;

	private bool _backButtonListening;

	private RewiredStandaloneInputModule _inputModule;

	private int _selectedPlayerIndex;

	private List<Player> _freeRewiredPlayers;

	public List<Player> RewiredPlayersWithSlots
	{
		get
		{
			List<Player> rewiredPlayersWithSlotsCache = _rewiredPlayersWithSlotsCache;
			int num = rewiredPlayersWithSlotsCache._size;
			int version = rewiredPlayersWithSlotsCache._version + 1;
			rewiredPlayersWithSlotsCache._version = version;
			rewiredPlayersWithSlotsCache._size = 0;
			if (rewiredPlayersWithSlotsCache._size > 0)
			{
				Array.Clear(rewiredPlayersWithSlotsCache._items, 0, rewiredPlayersWithSlotsCache._size);
			}
			List<CoopSlotData> slotsSelections = _slotsSelections;
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				if (num3 < slotsSelections._size)
				{
					List<CoopSlotData> slotsSelections2 = _slotsSelections;
					if (num2 >= slotsSelections2._size)
					{
						break;
					}
					CoopSlotData[] items = slotsSelections2._items;
					CoopSlotData coopSlotData = items[num2];
					if (coopSlotData.RewiredPlayer != null)
					{
						List<Player> rewiredPlayersWithSlotsCache2 = _rewiredPlayersWithSlotsCache;
						bool flag = rewiredPlayersWithSlotsCache2._size == 0;
						int num4 = num;
						if (!flag)
						{
							int num5 = rewiredPlayersWithSlotsCache2.IndexOf(coopSlotData.RewiredPlayer);
							bool flag2 = num5 != -1;
							num4 = 0;
							num = 0;
							if (flag2)
							{
								goto IL_01db;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C53E0");
						num = num4;
					}
					goto IL_01db;
				}
				return _rewiredPlayersWithSlotsCache;
				IL_01db:
				slotsSelections = _slotsSelections;
				num2++;
				num3 = num2;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			List<Player> result = default(List<Player>);
			return result;
		}
	}

	public static MultiplayerManager Instance => s_instance;

	public bool IsMultiplayer
	{
		get
		{
			bool playerCount = (byte)GetPlayerCount() != 0;
			if ((playerCount ? 1 : 0) > (true ? 1 : 0))
			{
				return true;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x1877EB030\"");
			return playerCount;
		}
	}

	public bool IsLocalMultiplayer
	{
		get
		{
			//IL_0018: Expected O, but got I4
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected I4, but got Unknown
			int localPlayerCount = GetLocalPlayerCount();
			object obj = localPlayerCount - 1;
			int num = localPlayerCount ^ 1;
			int num2 = localPlayerCount ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	public bool IsOnlineMultiplayer
	{
		get
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public CoopConfig CoopConfig => _coopConfig;

	public bool IsAwaitingControllerReconnect
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<Player> disconnectedPlayers = _disconnectedPlayers;
			if (_disconnectedPlayers != null)
			{
				int num = disconnectedPlayers._size ^ disconnectedPlayers._size;
				int num2 = disconnectedPlayers._size & num;
				bool flag = num2 < 0;
				bool flag2 = disconnectedPlayers._size < 0;
				bool flag3 = disconnectedPlayers._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private RewiredStandaloneInputModule InputModule
	{
		get
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_015f: Expected O, but got I4
			RewiredStandaloneInputModule inputModule = _inputModule;
			RewiredStandaloneInputModule rewiredStandaloneInputModule;
			if ((object)_inputModule == null || ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0)
			{
				rewiredStandaloneInputModule = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_inputModule = rewiredStandaloneInputModule;
				if (flag)
				{
					goto IL_012d;
				}
				object obj = this + 120;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			rewiredStandaloneInputModule = _inputModule;
			goto IL_012d;
			IL_012d:
			return rewiredStandaloneInputModule;
		}
	}

	public bool IsUIBeingBlocked
	{
		get
		{
			//IL_0049: Expected O, but got I4
			RewiredStandaloneInputModule inputModule = InputModule;
			bool flag = ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0;
			object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)inputModule).m_CachedPtr);
			return obj == null;
		}
	}

	public List<FollowerData> AICharacters
	{
		get
		{
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Expected O, but got Unknown
			List<FollowerData> list = new List<FollowerData>();
			List<CoopSlotData> slotsSelections = _slotsSelections;
			FollowerData followerData = null;
			FollowerData followerData2 = null;
			while (true)
			{
				if ((nint)followerData2 < slotsSelections._size)
				{
					List<CoopSlotData> slotsSelections2 = _slotsSelections;
					if ((nint)followerData >= slotsSelections2._size)
					{
						break;
					}
					CoopSlotData[] items = slotsSelections2._items;
					CoopSlotData coopSlotData = items[(object)followerData];
					if (coopSlotData.AIType != AIType.None)
					{
						FollowerData followerData3 = new FollowerData();
						followerData3._003CEveryXLevels_003Ek__BackingField = 3;
						followerData3._003CShouldSharePassives_003Ek__BackingField = true;
						followerData3._003CAllowDuplicates_003Ek__BackingField = true;
						followerData3._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = true;
						((List<FollowerData>)(object)_slotsSelections).Add(followerData);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v10+14]");
						followerData3._003CFollowerAI_003Ek__BackingField = AIType.None;
						((List<FollowerData>)(object)_slotsSelections).Add(followerData);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v12+10]");
						followerData3._003CFollowerCharacter_003Ek__BackingField = CharacterType.VOID;
						followerData3._003CManualLevelUps_003Ek__BackingField = true;
						followerData3._003CShouldFollowMainPlayer_003Ek__BackingField = true;
						followerData3._003CShouldSharePassives_003Ek__BackingField = true;
						((List<object>)(object)list).Add((object)followerData3);
					}
					slotsSelections = _slotsSelections;
					followerData = (FollowerData)(followerData + 1);
					followerData2 = followerData;
					continue;
				}
				return list;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			List<FollowerData> result = default(List<FollowerData>);
			return result;
		}
	}

	public event OnControllerStateChange ControllerDisconnected
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 56;
			Delegate obj2 = this.m_ControllerDisconnected;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnControllerStateChange);
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
			object obj = this + 56;
			Delegate obj2 = this.m_ControllerDisconnected;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnControllerStateChange);
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

	public event OnRefresh RefreshUI
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 64;
			Delegate obj2 = this.m_RefreshUI;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnRefresh);
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
			object obj = this + 64;
			Delegate obj2 = this.m_RefreshUI;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnRefresh);
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

	public bool DoesRewiredPlayerHaveASlot(Player player)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		List<CoopSlotData> slotsSelections = _slotsSelections;
		List<CoopSlotData> slotsSelections2 = _slotsSelections;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < slotsSelections._size)
			{
				if ((nint)obj >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[obj];
				if (coopSlotData.RewiredPlayer != player)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				return true;
			}
			return false;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public unsafe void Initialize()
	{
		//IL_00b5: Expected O, but got Ref
		//IL_00be: Expected O, but got I4
		//IL_0119: Expected I, but got O
		//IL_01ac: Expected O, but got I4
		//IL_0151: Expected O, but got I
		//IL_015a: Expected O, but got I4
		//IL_01c1: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_03c0: Expected O, but got I
		//IL_021e: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_03e9: Expected O, but got I
		//IL_028b: Expected O, but got I
		//IL_0294: Expected O, but got I4
		s_instance = this;
		ResetSlotSelections();
		PlayerOptions.OnInitialized value = SetInitialPlayers;
		_playerOptions.PlayerOptionsInitialized += value;
		UnityAction<Scene> unityAction = null;
		((MultiplayerManager)(object)unityAction).StopVibrationOnSceneUnload((Scene)this);
		SceneManager.sceneUnloaded += unityAction;
		UnityAction<Scene, LoadSceneMode> value2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B140");
		SceneManager.sceneLoaded += value2;
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> players2 = players.GetPlayers();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>> safeDelegate = default(Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>);
		object obj = (object)(&safeDelegate);
		object obj2 = 0;
		Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>> safeDelegate2 = null;
		object obj3 = default(object);
		object obj12 = default(object);
		object obj13 = default(object);
		while (true)
		{
			object obj11;
			object obj4;
			if (safeDelegate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = safeDelegate == null;
					safeDelegate2 = null;
					if (!flag)
					{
						nint num = (nint)safeDelegate;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v5 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0191;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v5 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+B0]");
						obj4 = 0;
						object obj5 = 0;
						while (true)
						{
							object obj6 = obj5 + obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ r8_v16+v503 @ rax_v57*8]");
							if (0 == (nint)typeof(IEnumerator<Player>))
							{
								break;
							}
							obj5++;
							object obj7 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ r10_v5 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+12E]");
							if ((nint)obj7 < 0)
							{
								continue;
							}
							goto IL_0191;
						}
						object obj8 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ r8_v16+8+v559 @ rcx_v47*8]");
						object obj9 = (nint)0 << 4;
						object obj10 = obj9 + 312;
						obj11 = obj10 + num;
						goto IL_040b;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_0191:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj11 = obj12;
			obj4 = 0;
			goto IL_040b;
			IL_040b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v564 @ rdx_v19] (should have been resolved before IL gen)");
			bool flag2 = obj13 == null;
			safeDelegate2 = safeDelegate;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v33+50]");
				object obj14 = 0;
				Action<ControllerAssignmentChangedEventArgs> action = OnPlayerControllerAdded;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v33+50]");
				bool flag3 = (nint)0 == 0;
				safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)(object)action;
				if (flag3)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rsi_v7+30]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rsi_v7+30]");
				safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rsi_v7+30]");
					((Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0).AddDelegate(action);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v33+50]");
					object obj15 = 0;
					Action<ControllerAssignmentChangedEventArgs> action2 = OnPlayerControllerRemoved;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v33+50]");
					bool flag5 = (nint)0 == 0;
					safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)(object)action2;
					if (flag5)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdi_v12+38]");
					safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdi_v12+38]");
					((Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0).AddDelegate(action2);
					obj2 = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private void ResetSlotSelections()
	{
		List<CoopSlotData> slotsSelections = new List<CoopSlotData>();
		CoopSlotData coopSlotData = new CoopSlotData();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4AA0");
		CoopSlotData coopSlotData2 = new CoopSlotData();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4AA0");
		CoopSlotData coopSlotData3 = new CoopSlotData();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4AA0");
		CoopSlotData coopSlotData4 = new CoopSlotData();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4AA0");
		_slotsSelections = slotsSelections;
	}

	public unsafe void Dispose()
	{
		//IL_00c4: Expected O, but got Ref
		//IL_00cd: Expected O, but got I4
		//IL_0128: Expected I, but got O
		//IL_01bb: Expected O, but got I4
		//IL_0160: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_01d0: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_03fd: Expected O, but got I
		//IL_022d: Expected O, but got I
		//IL_023d: Expected O, but got I
		//IL_0426: Expected O, but got I
		//IL_029a: Expected O, but got I
		//IL_02a3: Expected O, but got I4
		PlayerOptions.OnInitialized value = SetInitialPlayers;
		_playerOptions.PlayerOptionsInitialized -= value;
		UnityAction<Scene> unityAction = null;
		((MultiplayerManager)(object)unityAction).StopVibrationOnSceneUnload((Scene)this);
		SceneManager.sceneUnloaded -= unityAction;
		UnityAction<Scene, LoadSceneMode> value2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B140");
		SceneManager.sceneLoaded -= value2;
		if (!ReInput.duJfbUTYdcFkwpKAQGPArkFHzFnu)
		{
			return;
		}
		ReInput.PlayerHelper players = ReInput.players;
		if (players == null)
		{
			return;
		}
		ReInput.PlayerHelper players2 = ReInput.players;
		IList<Player> players3 = players2.GetPlayers();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>> safeDelegate = default(Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>);
		object obj = (object)(&safeDelegate);
		object obj2 = 0;
		Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>> safeDelegate2 = null;
		object obj3 = default(object);
		object obj12 = default(object);
		object obj13 = default(object);
		while (true)
		{
			object obj11;
			object obj4;
			if (safeDelegate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = safeDelegate == null;
					safeDelegate2 = null;
					if (!flag)
					{
						nint num = (nint)safeDelegate;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v6 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_01a0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v6 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+B0]");
						obj4 = 0;
						object obj5 = 0;
						while (true)
						{
							object obj6 = obj5 + obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v15+v539 @ rax_v60*8]");
							if (0 == (nint)typeof(IEnumerator<Player>))
							{
								break;
							}
							obj5++;
							object obj7 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ r10_v6 (Il2CppClass<Rewired.Utils.SafeDelegate`1<System.Action`1<Rewired.ControllerAssignmentChangedEventArgs>>>)+12E]");
							if ((nint)obj7 < 0)
							{
								continue;
							}
							goto IL_01a0;
						}
						object obj8 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v15+8+v595 @ rcx_v50*8]");
						object obj9 = (nint)0 << 4;
						object obj10 = obj9 + 312;
						obj11 = obj10 + num;
						goto IL_0448;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_01a0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj11 = obj12;
			obj4 = 0;
			goto IL_0448;
			IL_0448:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v600 @ rdx_v18] (should have been resolved before IL gen)");
			bool flag2 = obj13 == null;
			safeDelegate2 = safeDelegate;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v36+50]");
				object obj14 = 0;
				Action<ControllerAssignmentChangedEventArgs> action = OnPlayerControllerAdded;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v36+50]");
				bool flag3 = (nint)0 == 0;
				safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)(object)action;
				if (flag3)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rsi_v8+30]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rsi_v8+30]");
				safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rsi_v8+30]");
					((Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0).RemoveDelegate(action);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v36+50]");
					object obj15 = 0;
					Action<ControllerAssignmentChangedEventArgs> action2 = OnPlayerControllerRemoved;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v36+50]");
					bool flag5 = (nint)0 == 0;
					safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)(object)action2;
					if (flag5)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rdi_v13+38]");
					safeDelegate2 = (Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rdi_v13+38]");
					((Rewired.Utils.SafeDelegate<Action<ControllerAssignmentChangedEventArgs>>)0).RemoveDelegate(action2);
					obj2 = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe void Tick()
	{
		//IL_0046: Expected O, but got I4
		//IL_0499: Expected O, but got Ref
		//IL_008b: Expected O, but got Ref
		//IL_0094: Expected O, but got I4
		//IL_04f4: Expected I, but got O
		//IL_057f: Expected O, but got I4
		//IL_052c: Expected O, but got I
		//IL_0a3f: Expected O, but got I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0134: Invalid comparison between O and F4
		//IL_0714: Expected O, but got I4
		//IL_072a: Expected O, but got I
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected O, but got Unknown
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_05ed: Expected I4, but got O
		//IL_0684: Expected I4, but got O
		//IL_06b2: Expected I4, but got O
		//IL_06dc: Expected I4, but got O
		//IL_0702: Expected I4, but got O
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> players2 = players.Players;
		bool flag = !AllowP1Reassign;
		object obj = 0;
		if (!flag)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			IList<Joystick> joysticks = controllers.Joysticks;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj3 = default(object);
			object obj2 = (object)(&obj3);
			obj = 0;
			object obj4 = default(object);
			ControllerWithAxes controllerWithAxes2 = default(ControllerWithAxes);
			while (true)
			{
				bool flag2 = obj3 == null;
				ControllerWithAxes controllerWithAxes = null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C6E70");
						int num = 0;
						while (true)
						{
							int axisCount = controllerWithAxes2.axisCount;
							if (num >= axisCount)
							{
								break;
							}
							float axis = controllerWithAxes2.GetAxis(num);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							obj = axis & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
							{
								num++;
								continue;
							}
							goto IL_015b;
						}
						continue;
					}
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					break;
				}
				throw new NullReferenceException();
				IL_015b:
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			ReInput.ControllerHelper controllers2 = ReInput.controllers;
			bool flag3 = ReInput.CheckInitialized();
			bool flag4 = !flag3;
			if (!flag4)
			{
				global::YdgUOjdefzAWTMpEeriKxkUxlwEt ksJXpDsMixBwMhOpfXJXqgrTCMir = ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998D3DD]");
				flag4 = (nint)0 == 0;
				bool flag5 = ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir.dcfKVWQibRXNUCnwoVdQAOAJcFEb<Joystick>((IList<Joystick>)ksJXpDsMixBwMhOpfXJXqgrTCMir.PXpWeTbtLsfbtNqrXzdbhsmbZcrF);
			}
			if (!flag4)
			{
				ReInput.ControllerHelper controllers3 = ReInput.controllers;
				Controller controller2;
				if (ReInput.CheckInitialized())
				{
					Controller controller = ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir.lbfbTrwMRKbrjGYZEWdToelyaqfOA(ControllerType.Joystick);
					controller2 = controller;
				}
				else
				{
					controller2 = null;
				}
				ReInput.PlayerHelper players3 = ReInput.players;
				Player player = players3.GetPlayer(0);
				Player.ControllerHelper controllers4 = player.controllers;
				if (ReInput._id == controllers4.NXMSqkaKORQseqlEBJKNAUMjfIzz)
				{
					controllers4.EssBduekKYBCvGHcxoEMkJnloZfAA();
				}
				else
				{
					bool flag6 = ReInput.CheckInitialized(controllers4.NXMSqkaKORQseqlEBJKNAUMjfIzz);
				}
				player.controllers.AddController(ControllerType.Joystick, controller2.id, removeFromOtherPlayers: true);
				AllowP1Reassign = false;
				ReInput.ControllerHelper controllers5 = ReInput.controllers;
				controllers5.AutoAssignJoysticks();
				List<CoopSlotData> slotsSelections = _slotsSelections;
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					bool flag7 = num3 >= slotsSelections._size;
					bool flag8 = true;
					if (flag7)
					{
						break;
					}
					List<CoopSlotData> slotsSelections2 = _slotsSelections;
					if (num2 < slotsSelections2._size)
					{
						CoopSlotData[] items = slotsSelections2._items;
						CoopSlotData coopSlotData = items[num2];
						Player rewiredPlayer = coopSlotData.RewiredPlayer;
						if (coopSlotData.RewiredPlayer != null)
						{
							int id = coopSlotData.RewiredPlayer.id;
							if (id > 0 && rewiredPlayer.controllers.joystickCount == 0)
							{
								RemoveRewiredPlayer(coopSlotData.RewiredPlayer);
							}
						}
						num2++;
						slotsSelections = _slotsSelections;
						num3 = num2;
						continue;
					}
					goto IL_09cb;
				}
			}
		}
		Player.ControllerHelper controllerHelper2;
		if (AllowPlayerJoining)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Player.ControllerHelper controllerHelper = default(Player.ControllerHelper);
			object obj5 = (object)(&controllerHelper);
			controllerHelper2 = null;
			object obj6 = default(object);
			Player player2 = default(Player);
			object obj13 = default(object);
			while (true)
			{
				object obj7;
				object obj12;
				if (controllerHelper != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj6 == null)
					{
						break;
					}
					bool flag9 = controllerHelper == null;
					controllerHelper2 = null;
					if (!flag9)
					{
						nint num4 = (nint)controllerHelper;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r10_v20 (Il2CppClass<Rewired.Player+ControllerHelper>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_056c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r10_v20 (Il2CppClass<Rewired.Player+ControllerHelper>)+B0]");
						obj7 = 0;
						int num5 = 0;
						while (true)
						{
							object obj8 = num5 + num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ r8_v31+v1652 @ rax_v78*8]");
							if (0 == (nint)typeof(IEnumerator<Player>))
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r10_v20 (Il2CppClass<Rewired.Player+ControllerHelper>)+12E]");
							if ((nint)num6 < (nint)0)
							{
								continue;
							}
							goto IL_056c;
						}
						object obj9 = num5 + num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ r8_v31+8+v1844 @ rcx_v58*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + num4;
						goto IL_0a91;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0a91:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1849 @ rdx_v35] (should have been resolved before IL gen)");
				if (player2 != null)
				{
					controllerHelper2 = player2.controllers;
					if (player2.controllers != null)
					{
						int joystickCount = player2.controllers.joystickCount;
						bool flag10 = joystickCount <= 0;
						bool flag8 = (byte)(int)typeof(IEnumerator<Player>) != 0;
						if (flag10)
						{
							continue;
						}
						if (player2.controllers != null)
						{
							IList<Joystick> joysticks2 = player2.controllers.Joysticks;
							Joystick joystick = Enumerable.First(joysticks2);
							if (joystick != null)
							{
								bool anyButtonDown = joystick.GetAnyButtonDown();
								bool flag11 = !anyButtonDown;
								flag8 = (byte)(int)typeof(IEnumerator<Player>) != 0;
								if (flag11)
								{
									continue;
								}
								bool button = player2.GetButton(10);
								flag8 = (byte)(int)typeof(IEnumerator<Player>) != 0;
								if (!button)
								{
									bool flag12 = DoesRewiredPlayerHaveASlot(player2);
									flag8 = (byte)(int)typeof(IEnumerator<Player>) != 0;
									if (!flag12)
									{
										AddRewiredPlayer(player2);
										flag8 = (byte)(int)typeof(IEnumerator<Player>) != 0;
									}
								}
								continue;
							}
							goto IL_0a86;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_056c:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj7 = 0;
				obj12 = obj13;
				goto IL_0a91;
			}
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}
		if (!AllowPlayerRemoval)
		{
			return;
		}
		List<Player>.Enumerator enumerator = default(List<Player>.Enumerator);
		while (enumerator.MoveNext())
		{
			int num7 = 0;
			while (true)
			{
				List<CoopSlotData> slotsSelections3 = _slotsSelections;
				if (_slotsSelections != null)
				{
					if (num7 >= slotsSelections3._size)
					{
						break;
					}
					if (num7 < slotsSelections3._size)
					{
						CoopSlotData[] items2 = slotsSelections3._items;
						CoopSlotData coopSlotData2 = items2[num7];
						if (coopSlotData2.RewiredPlayer != null)
						{
							num7++;
							continue;
						}
						RemoveRewiredPlayer(null);
						break;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					slotsSelections3 = null;
				}
				throw new NullReferenceException();
			}
		}
		List<Player> rewiredPlayersToRemove = _rewiredPlayersToRemove;
		int version = rewiredPlayersToRemove._version + 1;
		rewiredPlayersToRemove._version = version;
		rewiredPlayersToRemove._size = 0;
		if (rewiredPlayersToRemove._size > 0)
		{
			Array.Clear(rewiredPlayersToRemove._items, 0, rewiredPlayersToRemove._size);
		}
		return;
		IL_09cb:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		controllerHelper2 = null;
		goto IL_0a86;
		IL_0a86:
		throw new NullReferenceException();
	}

	private void ResetToSinglePlayerMode()
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I
		Debug.Log("ResetToSinglePlayerMode");
		List<CoopSlotData> slotsSelections = _slotsSelections;
		object obj = 1;
		object obj2 = 1;
		while (true)
		{
			if ((nint)obj2 < slotsSelections._size)
			{
				List<CoopSlotData> slotsSelections2 = _slotsSelections;
				if ((nint)obj >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[obj];
				if (coopSlotData.RewiredPlayer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v25+18]");
					AddPlayerForRemoval((Player)0);
				}
				slotsSelections = _slotsSelections;
				obj++;
				obj2 = obj;
				continue;
			}
			ReInput.PlayerHelper players = ReInput.players;
			if (ReInput.CheckInitialized())
			{
				Player player = ReInput.JXooPWXQeUgTsYenpLNaUJAXxNJf.KKZPJsCvQOmddGUmKUKZThZdfXrk(0);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void OnPlayerControllerAdded(ControllerAssignmentChangedEventArgs args)
	{
		//IL_0058: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_0152: Expected I, but got O
		//IL_020c: Expected O, but got Ref
		//IL_01ba: Expected I, but got O
		//IL_0282: Expected O, but got Ref
		//IL_0315: Expected O, but got Ref
		//IL_0371: Expected O, but got Ref
		//IL_03be: Expected O, but got Ref
		//IL_03c7: Expected O, but got I4
		//IL_03d0: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		//IL_04c5: Expected O, but got I4
		//IL_0473: Expected O, but got I
		//IL_056e: Expected O, but got I
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_051f: Expected I, but got O
		//IL_0857: Expected O, but got Ref
		//IL_05d8: Expected I, but got O
		//IL_0648: Expected I, but got O
		//IL_06d8: Expected I, but got O
		//IL_0754: Expected O, but got Ref
		//IL_0774: Expected O, but got I4
		//IL_077d: Expected O, but got I4
		//IL_0786: Expected O, but got I4
		object[] array = new object[4];
		Player player = args.player;
		int id = player.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj = default(object);
		if (obj != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller = args.controller;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller2 = args.controller;
		ControllerType type = controller2.type;
		ControllerType controllerType = default(ControllerType);
		object obj5 = controllerType;
		if (obj5 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller3 = args.controller;
		if (controller3 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "Controller connected for player {0} : {1} | {2} | {3}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		Controller controller4 = args.controller;
		ControllerIdentifier controllerIdentifier = default(ControllerIdentifier);
		object arg = controllerIdentifier;
		Controller controller5 = args.controller;
		string name = controller5.name;
		paramsArray = new System.ParamsArray(arg, name);
		string message2 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerAdded] Extra Controller Info - Identifier: {0} | Name: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message2);
		Player player2 = args.player;
		int id2 = player2.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Player player3 = args.player;
		int joystickCount = player3.controllers.joystickCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		object arg3 = default(object);
		paramsArray = new System.ParamsArray(arg2, arg3);
		string message3 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerAdded] Player {0} controller count: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message3);
		Player player4 = args.player;
		int id3 = player4.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg4 = default(object);
		paramsArray = new System.ParamsArray(arg4);
		string message4 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerAdded] Player {0} current joystick info:", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message4);
		Player player5 = args.player;
		IList<Joystick> joysticks = player5.controllers.Joysticks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj9 = default(object);
		object obj8 = (object)(&obj9);
		object obj10 = 0;
		object obj11 = 0;
		object obj12 = 0;
		System.ParamsArray paramsArray3 = paramsArray;
		ArrayTypeMismatchException ex5 = null;
		object obj13 = default(object);
		object obj25 = default(object);
		Controller controller6 = default(Controller);
		object obj26 = default(object);
		object obj27 = default(object);
		object obj29 = default(object);
		object obj30 = default(object);
		ControllerType controllerType2 = default(ControllerType);
		object obj31 = default(object);
		System.ParamsArray paramsArray4 = default(System.ParamsArray);
		while (true)
		{
			object obj16;
			object obj23;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj13 != null)
				{
					bool flag = obj9 == null;
					ex5 = null;
					if (!flag)
					{
						object obj14 = obj9;
						object obj15 = obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+12E]");
						if ((nint)obj15 >= 0)
						{
							goto IL_04b2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+B0]");
						obj16 = 0;
						object obj17 = obj10;
						while (true)
						{
							object obj18 = obj17 + obj17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ r8_v43+v1676 @ rax_v178*8]");
							if (0 == (nint)typeof(IEnumerator<Joystick>))
							{
								break;
							}
							obj17++;
							object obj19 = obj17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19+12E]");
							if ((nint)obj19 < 0)
							{
								continue;
							}
							goto IL_04b2;
						}
						object obj20 = obj17 + obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ r8_v43+8+v1746 @ rcx_v142*8]");
						object obj21 = (nint)0 << 4;
						object obj22 = obj21 + 312;
						obj23 = obj22 + obj14;
						goto IL_0a3f;
					}
					throw new NullReferenceException();
				}
				bool flag2 = obj8 == null;
				object obj24 = obj9;
				if (!flag2)
				{
					obj24 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_04b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj16 = 0;
			obj23 = obj25;
			goto IL_0a3f;
			IL_0a3f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1751 @ rdx_v87] (should have been resolved before IL gen)");
			object[] array2 = new object[4];
			bool flag3 = controller6 == null;
			ex5 = (ArrayTypeMismatchException)(object)typeof(object[]);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				if (array2 != null)
				{
					if (obj26 != null)
					{
						nint num5 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj27 == null)
						{
							ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
							throw ex6;
						}
					}
					array2[0] = obj26;
					object obj28 = controllerIdentifier;
					if (obj28 != null)
					{
						nint num6 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj29 == null)
						{
							ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
							throw ex7;
						}
					}
					array2[1] = obj28;
					string name2 = controller6.name;
					if (name2 != null)
					{
						nint num7 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj30 == null)
						{
							ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
							throw ex8;
						}
					}
					array2[2] = name2;
					ControllerType type2 = controller6.type;
					ArrayTypeMismatchException ex9 = (ArrayTypeMismatchException)(object)controllerType2;
					bool flag4 = ex9 == null;
					ex5 = (ArrayTypeMismatchException)(object)typeof(ControllerType);
					if (!flag4)
					{
						nint num8 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj31 == null)
						{
							ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
							throw ex10;
						}
					}
					if (array2.Length > 3)
					{
						array2[3] = ex9;
						paramsArray2 = new System.ParamsArray(array2);
						string message5 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerAdded] Joystick - ID: {0} | Identifier: {1} | Name: {2} | Type: {3}", (System.ParamsArray)(&paramsArray4));
						Debug.Log(message5);
						obj10 = 0;
						obj11 = 0;
						obj12 = 0;
						paramsArray3 = paramsArray2;
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		List<Player> disconnectedPlayers = _disconnectedPlayers;
		if (disconnectedPlayers._size <= 0)
		{
			return;
		}
		Player player6 = args.player;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4A30");
		object obj32 = default(object);
		if (obj32 != null)
		{
			int id4 = player6.id;
			string text = System.Number.FormatInt32(id4, (ReadOnlySpan<char>)(&paramsArray), null);
			string id5 = "ControllerDisconnect-" + text;
			PopupManager.ClosePopup(id5);
			bool flag5 = ((List<object>)(object)_disconnectedPlayers).Remove((object)player6);
		}
		List<Player> disconnectedPlayers2 = _disconnectedPlayers;
		if (disconnectedPlayers2._size == 0)
		{
			if (_hasForcedPauseForDisconnect)
			{
				_hasForcedPauseForDisconnect = false;
			}
			EnableAllUIInteraction();
		}
	}

	private unsafe void OnPlayerControllerRemoved(ControllerAssignmentChangedEventArgs args)
	{
		//IL_0139: Expected I, but got O
		//IL_01b6: Expected I, but got O
		//IL_0247: Expected I, but got O
		//IL_0306: Expected O, but got Ref
		//IL_02b4: Expected I, but got O
		//IL_0390: Expected O, but got Ref
		//IL_042d: Expected O, but got Ref
		//IL_0493: Expected O, but got Ref
		//IL_04ea: Expected O, but got Ref
		//IL_04f3: Expected O, but got I4
		//IL_04fc: Expected O, but got I4
		//IL_08d9: Expected I4, but got O
		//IL_05ef: Expected O, but got I4
		//IL_0f18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1d: Expected I4, but got Unknown
		//IL_094b: Expected O, but got I4
		//IL_0598: Expected O, but got I
		//IL_0f5c: Expected O, but got Ref
		//IL_0690: Expected O, but got I
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected O, but got Unknown
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_0998: Expected O, but got I4
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_0641: Expected I, but got O
		//IL_09e0: Expected O, but got I4
		//IL_06fa: Expected I, but got O
		//IL_076a: Expected I, but got O
		//IL_0ea7: Expected O, but got Ref
		//IL_07fa: Expected I, but got O
		//IL_0da4: Expected O, but got I4
		//IL_0876: Expected O, but got Ref
		//IL_0896: Expected O, but got I4
		//IL_089f: Expected O, but got I4
		//IL_0ae6: Expected O, but got I4
		//IL_0b1c: Expected O, but got I4
		//IL_0b87: Expected I, but got O
		//IL_0b9c: Expected O, but got I
		//IL_0bfb: Expected I, but got O
		//IL_0c63: Expected I, but got O
		//IL_0d2a: Expected O, but got Ref
		//IL_0cd8: Expected I, but got O
		//IL_0d73: Expected O, but got I4
		//IL_0d7c: Expected O, but got I4
		//IL_0d8d: Expected O, but got I4
		_003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass55_0();
		CS_0024_003C_003E8__locals21.args = args;
		Player player = CS_0024_003C_003E8__locals21.args.player;
		if (player.id == 0)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			if (!sInstance.m_CurrentSystem.DoesPlayer1NeedController())
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (!config._003CAssignControllerToPlayer1_003Ek__BackingField)
				{
					Debug.Log("[OnPlayerControllerRemoved] We do not need to worry about controllers being removed for the first player...");
					return;
				}
			}
		}
		object[] array = new object[4];
		Player player2 = CS_0024_003C_003E8__locals21.args.player;
		int id = player2.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj = default(object);
		if (obj != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller = CS_0024_003C_003E8__locals21.args.controller;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj3 = default(object);
		if (obj3 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller2 = CS_0024_003C_003E8__locals21.args.controller;
		ControllerType type = controller2.type;
		ControllerType controllerType = default(ControllerType);
		object obj5 = controllerType;
		if (obj5 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Controller controller3 = CS_0024_003C_003E8__locals21.args.controller;
		if (controller3 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "Controller disconnected for player {0} : Controller ID {1} | {2} | {3}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		Controller controller4 = CS_0024_003C_003E8__locals21.args.controller;
		ControllerIdentifier controllerIdentifier = default(ControllerIdentifier);
		object arg = controllerIdentifier;
		Controller controller5 = CS_0024_003C_003E8__locals21.args.controller;
		string name = controller5.name;
		paramsArray = new System.ParamsArray(arg, name);
		string message2 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Extra Controller Info - Identifier: {0} | Name: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message2);
		Player player3 = CS_0024_003C_003E8__locals21.args.player;
		int id2 = player3.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Player player4 = CS_0024_003C_003E8__locals21.args.player;
		int joystickCount = player4.controllers.joystickCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		object arg3 = default(object);
		paramsArray = new System.ParamsArray(arg2, arg3);
		string message3 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Player {0} controller count: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message3);
		Player player5 = CS_0024_003C_003E8__locals21.args.player;
		int id3 = player5.id;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg4 = default(object);
		paramsArray = new System.ParamsArray(arg4);
		string message4 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Player {0} current joystick info:", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message4);
		Player player6 = CS_0024_003C_003E8__locals21.args.player;
		IList<Joystick> joysticks = player6.controllers.Joysticks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		bool flag = default(bool);
		object obj8 = (object)(&flag);
		object obj9 = 0;
		object obj10 = 0;
		System.ParamsArray paramsArray3 = paramsArray;
		ArrayTypeMismatchException ex5 = null;
		object obj11 = default(object);
		List<Joystick> list2 = default(List<Joystick>);
		List<Joystick> list3 = default(List<Joystick>);
		List<Joystick> list4 = default(List<Joystick>);
		object obj20 = default(object);
		object obj21 = default(object);
		ControllerType controllerType2 = default(ControllerType);
		object obj23 = default(object);
		System.ParamsArray paramsArray4 = default(System.ParamsArray);
		IntPtr intPtr = default(IntPtr);
		object obj24 = default(object);
		object arg5 = default(object);
		System.ParamsArray paramsArray5 = default(System.ParamsArray);
		Controller controller9 = default(Controller);
		object obj25 = default(object);
		object obj26 = default(object);
		object obj28 = default(object);
		object obj29 = default(object);
		ControllerType controllerType3 = default(ControllerType);
		object obj30 = default(object);
		System.ParamsArray paramsArray6 = default(System.ParamsArray);
		while (true)
		{
			object obj18;
			object obj17;
			object obj12;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj11 != null)
				{
					bool flag2 = !flag;
					ex5 = null;
					if (!flag2)
					{
						bool value = ((bool*)(flag ? 1 : 0))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ r10_v24 (System.Boolean)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_05d4;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ r10_v24 (System.Boolean)+B0]");
						obj12 = 0;
						Player player7 = null;
						while (true)
						{
							object obj13 = (object)player7 + (object)player7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1883 @ r8_v64+v2643 @ rax_v261*8]");
							if (0 == (nint)typeof(IEnumerator<Joystick>))
							{
								break;
							}
							player7 = (Player)(player7 + 1);
							Player player8 = player7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ r10_v24 (System.Boolean)+12E]");
							if ((nint)player8 < 0)
							{
								continue;
							}
							goto IL_05d4;
						}
						object obj14 = (object)player7 + (object)player7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1883 @ r8_v64+8+v2699 @ rcx_v222*8]");
						object obj15 = (nint)0 << 4;
						object obj16 = obj15 + 312;
						obj17 = obj16 + value;
						goto IL_10e5;
					}
					throw new NullReferenceException();
				}
				bool flag3 = obj8 == null;
				bool flag4 = flag;
				if (!flag3)
				{
					flag4 = (byte)(int)obj8 != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Controller controller6 = CS_0024_003C_003E8__locals21.args.controller;
				ControllerType type2 = controller6.type;
				if (type2 == ControllerType.Joystick)
				{
					bool flag5 = !AllowPlayerRemoval;
					obj18 = 0;
					if (!flag5)
					{
						Player player9 = CS_0024_003C_003E8__locals21.args.player;
						int id4 = player9.id;
						bool flag6 = id4 != 0;
						obj18 = 0;
						if (!flag6)
						{
							Debug.Log("[OnPlayerControllerRemoved] Player one was disconnected");
							SystemPlatform sInstance2 = SystemPlatform.sInstance;
							bool flag7 = sInstance2.m_CurrentSystem.DoesPlayer1NeedController();
							bool flag8 = !flag7;
							obj18 = 0;
							if (!flag8)
							{
								Debug.Log("[OnPlayerControllerRemoved] Player one was disconnected, trying to grab another controller");
								ReInput.ControllerHelper controllers = ReInput.controllers;
								int joystickCount2 = controllers.joystickCount;
								if (joystickCount2 > 0)
								{
									ReInput.ControllerHelper controllers2 = ReInput.controllers;
									IList<Joystick> joysticks2 = controllers2.Joysticks;
									Func<Joystick, bool> predicate = delegate(Joystick j)
									{
										//IL_0068: Expected I4, but got O
										if (CS_0024_003C_003E8__locals21.args == null)
										{
											NullReferenceException ex16 = new NullReferenceException();
											return (byte)(int)ex16 != 0;
										}
										Controller controller10 = CS_0024_003C_003E8__locals21.args.controller;
										object obj31 = (object)j - (object)controller10;
										bool flag15 = obj31 == null;
										return !flag15;
									};
									IEnumerable<Joystick> enumerable = Enumerable.Where(joysticks2, predicate);
									if (enumerable == null)
									{
										Exception ex6 = System.Linq.Error.ArgumentNull("source");
										throw ex6;
									}
									List<object> list = new List<object>(enumerable);
									bool flag9 = list._size <= 0;
									obj9 = 0;
									flag4 = false;
									if (!flag9)
									{
										((List<Joystick>)(object)list)._002Ector((IEnumerable<Joystick>)null);
										bool flag10 = list2 == null;
										obj9 = 0;
										flag4 = false;
										if (!flag10)
										{
											Debug.Log("[OnPlayerControllerRemoved] Player one found another controller to steal");
											object[] array2 = new object[4];
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											if (list3 != null)
											{
												nint num5 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3484 @ rcx_v175 (Il2CppClass<System.Object[]>)+40]");
												list3._002Ector((IEnumerable<Joystick>)0);
												if (list4 == null)
												{
													ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
													throw ex7;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											object obj19 = controllerIdentifier;
											if (obj19 != null)
											{
												nint num6 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												if (obj20 == null)
												{
													ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
													throw ex8;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											string name2 = ((Controller)(object)list2).name;
											if (name2 != null)
											{
												nint num7 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												if (obj21 == null)
												{
													ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
													throw ex9;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											ControllerType type3 = ((Controller)(object)list2).type;
											object obj22 = controllerType2;
											if (obj22 != null)
											{
												nint num8 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												if (obj23 == null)
												{
													break;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											paramsArray2 = new System.ParamsArray(array2);
											string message5 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Stealing - ID: {0} | Identifier: {1} | Name: {2} | Type: {3}", (System.ParamsArray)(&paramsArray4));
											Debug.Log(message5);
											Player player10 = CS_0024_003C_003E8__locals21.args.player;
											player10.controllers.AddController((Controller)(object)list2, removeFromOtherPlayers: true);
											obj9 = 0;
											obj10 = 0;
											paramsArray3 = paramsArray2;
											obj18 = 0;
											flag4 = true;
											goto IL_1141;
										}
									}
								}
								obj18 = 1;
							}
						}
					}
					goto IL_1141;
				}
				Controller controller7 = CS_0024_003C_003E8__locals21.args.controller;
				int num9 = controller7 + 16;
				string text = ((int*)num9)->ToString();
				Controller controller8 = CS_0024_003C_003E8__locals21.args.controller;
				ControllerType type4 = controller8.type;
				string text2 = ((Enum)(&intPtr)).ToString();
				string message6 = "Controller with id " + text + " disconnected but not a joystick but a " + text2;
				Debug.LogWarning(message6);
				return;
			}
			throw new NullReferenceException();
			IL_05d4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj17 = obj24;
			obj12 = 0;
			goto IL_10e5;
			IL_1141:
			if (AllowPlayerRemoval && obj18 == null)
			{
				Player player11 = CS_0024_003C_003E8__locals21.args.player;
				int id5 = player11.id;
				bool flag11 = id5 == 0;
				Player player12 = null;
				if (!flag11)
				{
					int joystickCount3 = player11.controllers.joystickCount;
					bool flag12 = joystickCount3 != 0;
					player12 = null;
					if (!flag12)
					{
						player12 = player11;
					}
				}
				OnControllerStateChange controllerDisconnected = this.m_ControllerDisconnected;
				if (this.m_ControllerDisconnected != null)
				{
					bool flag4 = (byte)(nint)((Delegate)controllerDisconnected).method != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3065.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				if (player12 != null)
				{
					int id6 = player12.id;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					paramsArray2 = new System.ParamsArray(arg5);
					string message7 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Adding player to remove due to no joysticks - Player ID: {0}", (System.ParamsArray)(&paramsArray5));
					Debug.Log(message7);
					AddPlayerForRemoval(player12);
				}
			}
			else
			{
				Player player13 = CS_0024_003C_003E8__locals21.args.player;
				AddDisconnectedPlayer(player13);
			}
			return;
			IL_10e5:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2704 @ rdx_v153] (should have been resolved before IL gen)");
			object[] array3 = new object[4];
			bool flag13 = controller9 == null;
			ex5 = (ArrayTypeMismatchException)(object)typeof(object[]);
			if (!flag13)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				if (array3 != null)
				{
					if (obj25 != null)
					{
						nint num10 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj26 == null)
						{
							ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
							throw ex10;
						}
					}
					array3[0] = obj25;
					object obj27 = controllerIdentifier;
					if (obj27 != null)
					{
						nint num11 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj28 == null)
						{
							ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
							throw ex11;
						}
					}
					array3[1] = obj27;
					string name3 = controller9.name;
					if (name3 != null)
					{
						nint num12 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj29 == null)
						{
							ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
							throw ex12;
						}
					}
					array3[2] = name3;
					ControllerType type5 = controller9.type;
					ArrayTypeMismatchException ex13 = (ArrayTypeMismatchException)(object)controllerType3;
					bool flag14 = ex13 == null;
					ex5 = (ArrayTypeMismatchException)(object)typeof(ControllerType);
					if (!flag14)
					{
						nint num13 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (obj30 == null)
						{
							ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
							throw ex14;
						}
					}
					if (array3.Length > 3)
					{
						array3[3] = ex13;
						paramsArray2 = new System.ParamsArray(array3);
						string message8 = string.FormatHelper((IFormatProvider)null, "[OnPlayerControllerRemoved] Joystick - ID: {0} | Identifier: {1} | Name: {2} | Type: {3}", (System.ParamsArray)(&paramsArray6));
						Debug.Log(message8);
						obj9 = 0;
						obj10 = 0;
						paramsArray3 = paramsArray2;
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex15 = new ArrayTypeMismatchException();
		throw ex15;
	}

	public void StartPartyMode(int partySize)
	{
		//IL_00ca: Expected O, but got I4
		PartySize = (int?)(object)1;
		List<CoopSlotData> slotsSelections = _slotsSelections;
		if (slotsSelections._size > 0)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[0];
			float vibrationMS = default(float);
			SelectPlayerToControlUI(coopSlotData.RewiredPlayer, exclusiveUIControl: true, vibrate: false, vibrationMS);
			int num = FindSlotIndexContainingRewiredPlayer(coopSlotData.RewiredPlayer);
			if (num >= 0)
			{
				Color slotColor = GetSlotColor(num);
			}
			Refresh();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void AddDisconnectedPlayer(Player player)
	{
		//IL_0154: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4A30");
		object obj = default(object);
		if (obj != null || AllowP1Reassign)
		{
			return;
		}
		int num = FindSlotIndexContainingRewiredPlayer(player);
		if (num == -1)
		{
			return;
		}
		bool flag = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/controllerDisconnect_title", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		int num2 = default(int);
		string newValue = num2.ToString();
		string title = translation.Replace("%0", newValue);
		string translation2 = LocalizationManager.GetTranslation("lang/controllerDisconnect_desc", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		int id = player.id;
		string text = num2.ToString();
		string id2 = "ControllerDisconnect-" + text;
		PopupManager.CreateBlockingPopup(id2, title, translation2, textisLocalizationTerm: false, (Action)flag);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C53E0");
		List<Player> disconnectedPlayers = _disconnectedPlayers;
		if (disconnectedPlayers._size == 1)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				if (!core2._isPaused)
				{
					_hasForcedPauseForDisconnect = true;
					VampireSurvivors.Objects.Characters.CharacterController characterFromRewiredPlayer = GM.Core.GetCharacterFromRewiredPlayer(player);
					if ((object)characterFromRewiredPlayer != null && ((UnityEngine.Object)characterFromRewiredPlayer).m_CachedPtr != (IntPtr)0)
					{
						GameManager core3 = GM.Core;
						if (!core3._multiplayer.IsOnlineMultiplayer)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B4A0");
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
							OnlineStageManager onlineStageManager = default(OnlineStageManager);
							onlineStageManager.SendPauseRequest(characterFromRewiredPlayer);
						}
					}
					else
					{
						string text2 = player.ToString();
						string message = "Player " + text2 + " disconnected their controller, but they don't seem to be controlling a character, so let's ignore it";
						Debug.LogError(message);
					}
				}
			}
			DisableAllUIInteraction();
		}
		int id3 = player.id;
		string text3 = num2.ToString();
		string message2 = "Adding popup for player " + text3;
		Debug.Log(message2);
	}

	public unsafe void AddPlayerForRemoval(Player p)
	{
		//IL_002a: Expected O, but got Ref
		int id = p.id;
		object obj = default(object);
		string text = System.Number.FormatInt32(id, (ReadOnlySpan<char>)(&obj), null);
		string message = "<MultiplayerManager.AddPlayerForRemoval> player id = " + text;
		Debug.Log(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4A30");
		object obj2 = default(object);
		if (obj2 == null && DoesRewiredPlayerHaveASlot(p))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C53E0");
		}
	}

	public void ClearAllExtraPlayers()
	{
		//IL_00e6: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I
		List<CoopSlotData> slotsSelections = _slotsSelections;
		object obj = 1;
		object obj2 = 1;
		while (true)
		{
			if ((nint)obj2 < slotsSelections._size)
			{
				List<CoopSlotData> slotsSelections2 = _slotsSelections;
				if ((nint)obj >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[obj];
				if (coopSlotData.RewiredPlayer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v8+18]");
					RemoveRewiredPlayer((Player)0);
				}
				slotsSelections = _slotsSelections;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void RemoveDisconnectedPlayer(Player player)
	{
		//IL_0051: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4A30");
		object obj = default(object);
		if (obj != null)
		{
			int id = player.id;
			object obj2 = default(object);
			string text = System.Number.FormatInt32(id, (ReadOnlySpan<char>)(&obj2), null);
			string id2 = "ControllerDisconnect-" + text;
			PopupManager.ClosePopup(id2);
			bool flag = ((List<object>)(object)_disconnectedPlayers).Remove((object)player);
		}
		List<Player> disconnectedPlayers = _disconnectedPlayers;
		if (disconnectedPlayers._size == 0)
		{
			if (_hasForcedPauseForDisconnect)
			{
				_hasForcedPauseForDisconnect = false;
			}
			EnableAllUIInteraction();
		}
	}

	private void SetInitialPlayers()
	{
		//IL_0091: Expected O, but got I
		//IL_0443: Expected I, but got O
		//IL_0474: Expected O, but got I
		//IL_02c1: Expected I, but got O
		List<CoopSlotData> slotsSelections = _slotsSelections;
		bool flag = _slotsSelections == null;
		ReInput.PlayerHelper playerHelper = (ReInput.PlayerHelper)(object)this;
		if (!flag)
		{
			if (slotsSelections._size <= 0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			playerHelper = (ReInput.PlayerHelper)(object)slotsSelections._items;
			if (slotsSelections._items != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v7 (Rewired.ReInput+PlayerHelper)+18]");
				if ((nint)0 <= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v7 (Rewired.ReInput+PlayerHelper)+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v7 (Rewired.ReInput+PlayerHelper)+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v16+18]");
					if ((nint)0 != 0)
					{
						return;
					}
					ReInput.PlayerHelper players = ReInput.players;
					bool flag2 = players == null;
					playerHelper = null;
					if (!flag2)
					{
						IList<Player> players2 = players.Players;
						bool flag3 = players2 == null;
						playerHelper = players;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							object obj2 = default(object);
							bool flag4 = obj2 == null;
							playerHelper = null;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								object obj3 = default(object);
								object obj4;
								if (obj3 != null)
								{
									bool flag5 = obj2 == null;
									playerHelper = null;
									if (flag5)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C6DE0");
									Player player = default(Player);
									bool flag6 = player == null;
									playerHelper = null;
									if (flag6)
									{
										throw new NullReferenceException();
									}
									if (player.id == 0)
									{
										AddRewiredPlayer(player);
										if (obj2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
										}
										obj4 = obj2;
										goto IL_0425;
									}
								}
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								obj4 = obj2;
								goto IL_0425;
							}
							throw new NullReferenceException();
						}
					}
				}
			}
		}
		goto IL_03ad;
		IL_03ad:
		throw new NullReferenceException();
		IL_0425:
		_selectedPlayerIndex = 0;
		nint num = (nint)typeof(SystemPlatform);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v26 (Il2CppClass<VampireSurvivors.SystemPlatform>)+B8]");
		nint num2 = 0;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		bool flag7 = SystemPlatform.sInstance == null;
		playerHelper = (ReInput.PlayerHelper)num2;
		if (!flag7)
		{
			playerHelper = (ReInput.PlayerHelper)(object)sInstance.m_CurrentSystem;
			if (sInstance.m_CurrentSystem != null)
			{
				nint num3 = (nint)playerHelper;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v573 @ rdx_v12 (Il2CppClass<Rewired.ReInput+PlayerHelper>)+298] (should have been resolved before IL gen)");
				object obj5 = default(object);
				if (obj5 != null)
				{
					AllowP1Reassign = true;
					return;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						AllowP1Reassign = config._003CAssignControllerToPlayer1_003Ek__BackingField;
						if (_playerOptions != null)
						{
							PlayerOptionsData config2 = _playerOptions.Config;
							if (config2 != null)
							{
								SetControllerAssignedToPlayer1(config2._003CAssignControllerToPlayer1_003Ek__BackingField);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_03ad;
	}

	private void StopVibrationOnSceneUnload(Scene s)
	{
		List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
		List<Player>.Enumerator enumerator = default(List<Player>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	private void StopVibrationOnSceneLoad(Scene s, LoadSceneMode mode)
	{
		List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
		List<Player>.Enumerator enumerator = default(List<Player>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public void SetControllerAssignedToPlayer1(bool value)
	{
		//IL_01f7: Expected O, but got I4
		//IL_0201: Expected O, but got I4
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(0);
		bool excludeFromControllerAutoAssignment = (byte)((value ? 1u : 0u) ^ 1u) != 0;
		player.controllers.excludeFromControllerAutoAssignment = excludeFromControllerAutoAssignment;
		if (!value)
		{
			int joystickCount = player.controllers.joystickCount;
			if (joystickCount <= 0)
			{
				return;
			}
			Player.ControllerHelper controllers = player.controllers;
			if (ReInput._id == controllers.NXMSqkaKORQseqlEBJKNAUMjfIzz)
			{
				controllers.EssBduekKYBCvGHcxoEMkJnloZfAA();
			}
			else
			{
				bool flag = ReInput.CheckInitialized(controllers.NXMSqkaKORQseqlEBJKNAUMjfIzz);
			}
		}
		else
		{
			if (player.controllers.joystickCount != 0)
			{
				return;
			}
			ReInput.ControllerHelper controllers2 = ReInput.controllers;
			int joystickCount2 = controllers2.joystickCount;
			if (joystickCount2 > 0)
			{
				ReInput.PlayerHelper players2 = ReInput.players;
				Player player2 = players2.GetPlayer(0);
				ReInput.ControllerHelper controllers3 = ReInput.controllers;
				IList<Joystick> joysticks = controllers3.Joysticks;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507250");
				Player.ControllerHelper controllers4 = player2.controllers;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v35+10]");
				controllers4.AddController(ControllerType.Joystick, 0, removeFromOtherPlayers: true);
				AllowP1Reassign = true;
			}
		}
		ReInput.ControllerHelper controllers5 = ReInput.controllers;
		controllers5.AutoAssignJoysticks();
		List<CoopSlotData> slotsSelections = _slotsSelections;
		object obj = 1;
		object obj2 = 1;
		while (true)
		{
			if ((nint)obj2 < slotsSelections._size)
			{
				List<CoopSlotData> slotsSelections2 = _slotsSelections;
				if ((nint)obj >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[obj];
				Player rewiredPlayer = coopSlotData.RewiredPlayer;
				if (coopSlotData.RewiredPlayer != null && rewiredPlayer.controllers.joystickCount == 0)
				{
					RemoveRewiredPlayer(coopSlotData.RewiredPlayer);
				}
				slotsSelections = _slotsSelections;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void AddRewiredPlayer(Player p)
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		int num = FindSlotIndexContainingRewiredPlayer(p);
		if (num >= 0)
		{
			return;
		}
		List<CoopSlotData> slotsSelections = _slotsSelections;
		List<CoopSlotData> slotsSelections2 = _slotsSelections;
		object obj = 0;
		object obj2 = 0;
		int num2 = default(int);
		float vibrationMS = default(float);
		while (true)
		{
			if ((nint)obj2 < slotsSelections._size)
			{
				if ((nint)obj < slotsSelections2._size)
				{
					CoopSlotData[] items = slotsSelections2._items;
					CoopSlotData coopSlotData = items[obj];
					if (coopSlotData.RewiredPlayer != null)
					{
						obj++;
						obj2 = obj;
						continue;
					}
					if ((nint)obj < 0)
					{
						goto IL_025f;
					}
					int id = p.id;
					string text = num2.ToString();
					string message = "MP : Adding player" + text;
					Debug.Log(message);
					List<CoopSlotData> slotsSelections3 = _slotsSelections;
					if ((nint)obj < slotsSelections3._size)
					{
						CoopSlotData[] items2 = slotsSelections3._items;
						CoopSlotData coopSlotData2 = items2[obj];
						coopSlotData2.RewiredPlayer = p;
						if (p.id != 0)
						{
							List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
							if (rewiredPlayersWithSlots._size == 1)
							{
								SelectPlayerToControlUI(p, exclusiveUIControl: true, vibrate: true, vibrationMS);
							}
						}
						List<Player> rewiredPlayersWithSlots2 = RewiredPlayersWithSlots;
						if (rewiredPlayersWithSlots2._size == 1)
						{
							_selectedPlayerIndex = 0;
						}
						break;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			goto IL_025f;
			IL_025f:
			Debug.Log("No free slot to add another player");
			return;
		}
		int num3 = FindSlotIndexContainingRewiredPlayer(p);
		if (num3 >= 0)
		{
			Color slotColor = GetSlotColor(num3);
		}
		Refresh();
	}

	public int FindSlotIndexContainingRewiredPlayer(Player p)
	{
		//IL_00bd: Expected I4, but got I8
		List<CoopSlotData> slotsSelections = _slotsSelections;
		List<CoopSlotData> slotsSelections2 = _slotsSelections;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < slotsSelections._size)
			{
				if (num >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[num];
				if (coopSlotData.RewiredPlayer != p)
				{
					num++;
					num2 = num;
					continue;
				}
				return num;
			}
			return -1;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	private int FindNextFreeSlotForARewiredPlayer()
	{
		//IL_00be: Expected I4, but got I8
		List<CoopSlotData> slotsSelections = _slotsSelections;
		List<CoopSlotData> slotsSelections2 = _slotsSelections;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < slotsSelections._size)
			{
				if (num >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[num];
				if (coopSlotData.RewiredPlayer != null)
				{
					num++;
					num2 = num;
					continue;
				}
				return num;
			}
			return -1;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	public void UpdatePlayerControllerColour(Player player, Color color)
	{
	}

	public void ResetPlayerControllerColor(Player player)
	{
	}

	public unsafe void RemoveRewiredPlayer(Player p)
	{
		//IL_0018: Expected O, but got I4
		//IL_0201: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_033f: Expected I4, but got I8
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected I4, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_0357: Expected O, but got Ref
		List<CoopSlotData> slotsSelections = _slotsSelections;
		object obj = slotsSelections._size - 1;
		bool flag = (nint)obj < 1;
		bool flag2 = false;
		bool flag3 = false;
		if (flag)
		{
			goto IL_01ee;
		}
		while (true)
		{
			List<CoopSlotData> slotsSelections2 = _slotsSelections;
			if ((nint)obj >= slotsSelections2._size)
			{
				break;
			}
			CoopSlotData[] items = slotsSelections2._items;
			CoopSlotData coopSlotData = items[obj];
			if (coopSlotData.RewiredPlayer == p)
			{
				int selectedPlayerIndex = obj - 1;
				_selectedPlayerIndex = selectedPlayerIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				_ = 0;
				flag3 = true;
			}
			obj--;
			if ((nint)obj >= 1)
			{
				continue;
			}
			goto IL_0111;
		}
		goto IL_0390;
		IL_01ee:
		List<CoopSlotData> slotsSelections3 = _slotsSelections;
		object obj2 = 0;
		object obj3 = 0;
		CoopSlotData coopSlotData3 = default(CoopSlotData);
		object obj4 = default(object);
		while (true)
		{
			if ((nint)obj3 < slotsSelections3._size)
			{
				List<CoopSlotData> slotsSelections4 = _slotsSelections;
				if ((nint)obj2 >= slotsSelections4._size)
				{
					break;
				}
				CoopSlotData[] items2 = slotsSelections4._items;
				CoopSlotData coopSlotData2 = items2[obj2];
				if (coopSlotData2.RewiredPlayer == p)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					coopSlotData3.Reset();
				}
				slotsSelections3 = _slotsSelections;
				obj2++;
				obj3 = obj2;
				continue;
			}
			Refresh();
			int value;
			if (ReInput._id == p.VvvurTWFFtscXQGFVxBLDPOrYmWG)
			{
				value = p.bQuSsvmohoafHeVLwJLxvHbRXXOo;
			}
			else
			{
				bool flag4 = ReInput.CheckInitialized(p.VvvurTWFFtscXQGFVxBLDPOrYmWG);
				value = -1;
			}
			string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj4), null);
			string message = "MP : Removing player " + text;
			Debug.Log(message);
			return;
		}
		goto IL_0390;
		IL_0390:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0111:
		bool flag5 = !flag3;
		flag2 = flag3;
		if (!flag5)
		{
			List<CoopSlotData> slotsSelections5 = _slotsSelections;
			int selectedPlayerIndex2 = _selectedPlayerIndex;
			if (_selectedPlayerIndex >= slotsSelections5._size)
			{
				goto IL_0390;
			}
			CoopSlotData[] items3 = slotsSelections5._items;
			CoopSlotData coopSlotData4 = items3[selectedPlayerIndex2];
			bool flag6 = coopSlotData4.RewiredPlayer == null;
			flag2 = flag3;
			if (!flag6)
			{
				float vibrationMS = default(float);
				SelectPlayerToControlUI(coopSlotData4.RewiredPlayer, exclusiveUIControl: true, vibrate: true, vibrationMS);
				flag2 = true;
			}
		}
		goto IL_01ee;
	}

	public void DebugResetSystem()
	{
		Debug.Log("Resetting MultiplayerManager system");
		_selectedPlayerIndex = 0;
		ResetSlotSelections();
		_previousUIControllingPlayer = null;
		this.m_RefreshUI = null;
		SetInitialPlayers();
	}

	public void ResetMultiplayerSelections()
	{
		//IL_001a: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_0140: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		Debug.Log("Resetting MP selections");
		PartySize = (int?)(object)0;
		List<CoopSlotData> slotsSelections = _slotsSelections;
		object obj = 1;
		object obj2 = 1;
		object obj4 = default(object);
		Controller controller = default(Controller);
		while (true)
		{
			List<CoopSlotData> slotsSelections2 = _slotsSelections;
			if ((nint)obj2 < slotsSelections._size)
			{
				if ((nint)obj >= slotsSelections2._size)
				{
					break;
				}
				CoopSlotData[] items = slotsSelections2._items;
				CoopSlotData coopSlotData = items[obj];
				if (coopSlotData.RewiredPlayer != null)
				{
					Player rewiredPlayer = coopSlotData.RewiredPlayer;
					int joystickCount = rewiredPlayer.controllers.joystickCount;
					bool flag = joystickCount == 0;
					object obj3 = obj4;
					if (!flag)
					{
						Player rewiredPlayer2 = coopSlotData.RewiredPlayer;
						IList<Joystick> joysticks = rewiredPlayer2.controllers.Joysticks;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507250");
						bool isConnected = controller.isConnected;
						obj3 = 0;
						obj4 = 0;
						if (isConnected)
						{
							goto IL_0174;
						}
					}
					RemoveRewiredPlayer(coopSlotData.RewiredPlayer);
					obj4 = obj3;
				}
				goto IL_0174;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num < slotsSelections2._size)
				{
					List<CoopSlotData> slotsSelections3 = _slotsSelections;
					if (num2 >= slotsSelections3._size)
					{
						break;
					}
					CoopSlotData[] items2 = slotsSelections3._items;
					CoopSlotData coopSlotData2 = items2[num2];
					coopSlotData2.SelectedCharacter = CharacterType.VOID;
					List<CoopSlotData> slotsSelections4 = _slotsSelections;
					if (num2 >= slotsSelections4._size)
					{
						break;
					}
					CoopSlotData[] items3 = slotsSelections4._items;
					CoopSlotData coopSlotData3 = items3[num2];
					num2++;
					coopSlotData3.AIType = AIType.None;
					slotsSelections2 = _slotsSelections;
					bool flag2 = _slotsSelections != null;
					num = num2;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				_selectedPlayerIndex = 0;
				SelectPlayerOneToControlUI(exclusiveUIControl: true, vibrate: false);
				Refresh();
				return;
			}
			break;
			IL_0174:
			slotsSelections = _slotsSelections;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe Color GetSlotColor(int playerSlot)
	{
		//IL_004f: Expected native int or pointer, but got O
		PlayerOptionsData config = _playerOptions.Config;
		uint[] array = config._003CPlayerColours_003Ek__BackingField;
		if (playerSlot < array.Length)
		{
			Color color = default(Color);
			float r = default(float);
			((Color*)(nint)color)->r = r;
			return color;
		}
		return (Color)new IndexOutOfRangeException();
	}

	public unsafe bool IsCharacterTypeInGame(CharacterType t)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public int GetPlayerCount()
	{
		//IL_00bf: Expected I4, but got O
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 179 Invalid \"Jump target not found in method: 0x1877F10C0\"");
		}
		else if ((object)OnlineStageManager._instance != null)
		{
			return OnlineStageManager._instance.NumberOfConnectedPlayers;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetLocalPlayerCount()
	{
		//IL_01a2: Expected I4, but got O
		if ((object)PartySize == null)
		{
			List<CoopSlotData> slotsSelections = _slotsSelections;
			if (_slotsSelections != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					if (num2 < slotsSelections._size)
					{
						if (num3 < slotsSelections._size)
						{
							CoopSlotData[] items = slotsSelections._items;
							if (slotsSelections._items == null)
							{
								break;
							}
							CoopSlotData coopSlotData = items[num3];
							if (items[num3] == null)
							{
								break;
							}
							num3++;
							if (coopSlotData.RewiredPlayer != null)
							{
								num++;
								num2 = num3;
								continue;
							}
							int num4 = num + 1;
							if (coopSlotData.AIType <= AIType.None)
							{
								num4 = num;
							}
							num = num4;
							num2 = num3;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						break;
					}
					return num;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.MultiplayerManager)+2C]");
		return 0;
	}

	public List<CoopSlotData> GetLocalPlayerSlots()
	{
		return _slotsSelections;
	}

	public CoopSlotData GetSlotInfo(int index)
	{
		if (index >= 0)
		{
			List<CoopSlotData> slotsSelections = _slotsSelections;
			if (_slotsSelections != null)
			{
				if (index >= slotsSelections._size)
				{
					goto IL_00b3;
				}
				if (index < slotsSelections._size)
				{
					CoopSlotData[] items = slotsSelections._items;
					if (slotsSelections._items != null)
					{
						return items[index];
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
			return (CoopSlotData)(object)new NullReferenceException();
		}
		goto IL_00b3;
		IL_00b3:
		int num = default(int);
		string text = num.ToString();
		string message = "No slot info for index " + text;
		Debug.LogError(message);
		return null;
	}

	public Player GetPotentialRewiredPlayer(int slotIndex)
	{
		//IL_00c2: Expected I, but got O
		//IL_00fa: Expected O, but got I
		//IL_04e9: Expected O, but got I4
		//IL_0272: Expected I, but got O
		//IL_0390: Expected O, but got I4
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_0416: Expected I, but got O
		ReInput.PlayerHelper players = ReInput.players;
		IList<Player> players2 = players.Players;
		List<Player> freeRewiredPlayers = _freeRewiredPlayers;
		int version = freeRewiredPlayers._version + 1;
		freeRewiredPlayers._version = version;
		freeRewiredPlayers._size = 0;
		if (freeRewiredPlayers._size > 0)
		{
			Array.Clear(freeRewiredPlayers._items, 0, freeRewiredPlayers._size);
		}
		int num = 0;
		int num2 = 0;
		while (true)
		{
			nint num3 = (nint)players2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_013a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+B0]");
			object obj = 0;
			int num4 = 0;
			while (true)
			{
				object obj2 = num4 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ r8_v26+v492 @ rax_v53*8]");
				if (0 != (nint)typeof(ICollection<Player>))
				{
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<Rewired.Player>>)+12E]");
					if ((nint)num5 < (nint)0)
					{
						continue;
					}
					goto IL_013a;
				}
				break;
			}
			goto IL_0149;
			IL_013a:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_0149;
			IL_0149:
			int count = players2.Count;
			if (num >= count)
			{
				break;
			}
			Player player = players2.get_Item(num2);
			int joystickCount = player.controllers.joystickCount;
			if (joystickCount > 0 && !DoesRewiredPlayerHaveASlot(player))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809BC2D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C53E0");
			}
			num2++;
			num = num2;
		}
		List<Player> freeRewiredPlayers2 = _freeRewiredPlayers;
		if (freeRewiredPlayers2._size == 0)
		{
			goto IL_04cd;
		}
		bool flag = slotIndex <= 0;
		nint num6 = (nint)typeof(ICollection<Player>);
		int num7 = 0;
		if (flag)
		{
			goto IL_044b;
		}
		int length = default(int);
		while (true)
		{
			List<CoopSlotData> slotsSelections = _slotsSelections;
			if (num7 >= slotsSelections._size)
			{
				break;
			}
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[num7];
			if (coopSlotData.RewiredPlayer == null)
			{
				List<Player> freeRewiredPlayers3 = _freeRewiredPlayers;
				int num8 = freeRewiredPlayers3._size ^ freeRewiredPlayers3._size;
				int num9 = freeRewiredPlayers3._size & num8;
				bool flag2 = num9 < 0;
				bool flag3 = freeRewiredPlayers3._size < 0;
				bool flag4 = freeRewiredPlayers3._size == 0;
				if (flag4)
				{
					goto IL_04cd;
				}
				bool flag5 = flag3 == flag2;
				object obj3 = !flag5;
				object obj4 = obj3 | flag4;
				if (obj4 != null)
				{
					break;
				}
				if (--freeRewiredPlayers3._size > 0)
				{
					Array.Copy(freeRewiredPlayers3._items, 1, freeRewiredPlayers3._items, 0, length);
					num6 = unchecked((nint)null);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int version2 = freeRewiredPlayers3._version + 1;
				freeRewiredPlayers3._version = version2;
			}
			num7++;
			if (num7 < slotIndex)
			{
				continue;
			}
			goto IL_044b;
		}
		goto IL_0513;
		IL_0513:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Player result = default(Player);
		return result;
		IL_044b:
		List<Player> freeRewiredPlayers4 = _freeRewiredPlayers;
		if (freeRewiredPlayers4._size <= 0)
		{
			goto IL_04cd;
		}
		if (freeRewiredPlayers4._size > 0)
		{
			Player[] items2 = freeRewiredPlayers4._items;
			return items2[0];
		}
		goto IL_0513;
		IL_04cd:
		return null;
	}

	public Player GetCurrentUIPlayer()
	{
		List<CoopSlotData> slotsSelections = _slotsSelections;
		int selectedPlayerIndex = _selectedPlayerIndex;
		if (_selectedPlayerIndex < slotsSelections._size)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[selectedPlayerIndex];
			if (coopSlotData.RewiredPlayer == null)
			{
				return GetRewiredPlayerOne();
			}
			return coopSlotData.RewiredPlayer;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Player result = default(Player);
		return result;
	}

	public void PlayerControlOverride(Player p)
	{
		RewiredStandaloneInputModule inputModule = InputModule;
		int[] array = new int[1];
		int id = p.id;
		array[0] = id;
		inputModule.RewiredPlayerIds = array;
	}

	public void DisableAllUIInteraction()
	{
		BackButtonController instance = BackButtonController.Instance;
		if ((object)BackButtonController.Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			BackButtonController instance2 = BackButtonController.Instance;
			_backButtonListening = instance2.ListenForControllerInput;
			BackButtonController instance3 = BackButtonController.Instance;
			instance3.ListenForControllerInput = false;
		}
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = false;
		Debug.Log("Disabling all UI interaction");
	}

	public void EnableAllUIInteraction()
	{
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = true;
		BackButtonController instance = BackButtonController.Instance;
		if ((object)BackButtonController.Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			BackButtonController instance2 = BackButtonController.Instance;
			instance2.ListenForControllerInput = _backButtonListening;
		}
		Debug.Log("Re-enabling all UI interaction");
	}

	public void SelectPlayerOneToControlUI(bool exclusiveUIControl = false, bool vibrate = true)
	{
		List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
		if (rewiredPlayersWithSlots._size > 0)
		{
			List<Player> rewiredPlayersWithSlots2 = RewiredPlayersWithSlots;
			if (rewiredPlayersWithSlots2._size > 0)
			{
				Player[] items = rewiredPlayersWithSlots2._items;
				float vibrationMS = default(float);
				SelectPlayerToControlUI(items[0], exclusiveUIControl, vibrate, vibrationMS);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	public void AllowAllPlayersToUseUI()
	{
		//IL_00ad: Expected I4, but got I8
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
		int[] array = new int[rewiredPlayersWithSlots._size];
		int[] array2 = null;
		int[] array3 = null;
		object obj = default(object);
		int[] array5 = default(int[]);
		while (true)
		{
			if ((nint)array3 < rewiredPlayersWithSlots._size)
			{
				if ((nint)array2 < rewiredPlayersWithSlots._size)
				{
					Player[] items = rewiredPlayersWithSlots._items;
					Player player = items[(object)array2];
					int num;
					if (ReInput._id == player.VvvurTWFFtscXQGFVxBLDPOrYmWG)
					{
						num = player.bQuSsvmohoafHeVLwJLxvHbRXXOo;
					}
					else
					{
						bool flag = ReInput.CheckInitialized(player.VvvurTWFFtscXQGFVxBLDPOrYmWG);
						num = -1;
					}
					int[] array4 = (int[])(array2 + 1);
					array[(object)array2] = num;
					array2 = array4;
					array3 = array4;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
			RewiredStandaloneInputModule inputModule = InputModule;
			int[] rewiredPlayerIds;
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02A60");
				bool flag2 = obj == null;
				rewiredPlayerIds = null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (array5 == null)
					{
						break;
					}
					rewiredPlayerIds = array5;
				}
			}
			else
			{
				int[] array6 = new int[0];
				rewiredPlayerIds = array6;
			}
			inputModule.rewiredPlayerIds = rewiredPlayerIds;
			inputModule.SetupRewiredVars();
			return;
		}
		throw new InvalidCastException();
	}

	public void AddPlayerToUIControl(Player player)
	{
		//IL_007b: Expected O, but got I4
		RewiredStandaloneInputModule inputModule = InputModule;
		int[] rewiredPlayerIds = inputModule.RewiredPlayerIds;
		Array rewiredPlayerIds2;
		if (rewiredPlayerIds != null)
		{
			int id = player.id;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805079A0");
			object obj = default(object);
			if ((nint)obj >= 0)
			{
				return;
			}
			object obj2 = rewiredPlayerIds.Length + 1;
			int[] array = new int[obj2];
			int length = default(int);
			Array.Copy(rewiredPlayerIds, 0, array, 1, length);
			int id2 = player.id;
			rewiredPlayerIds2 = array;
		}
		else
		{
			int[] array2 = new int[1];
			int id2 = player.id;
			rewiredPlayerIds2 = array2;
		}
		RewiredStandaloneInputModule inputModule2 = InputModule;
		inputModule2.RewiredPlayerIds = (int[])rewiredPlayerIds2;
	}

	public Player GetRewiredPlayerOne()
	{
		List<CoopSlotData> slotsSelections = _slotsSelections;
		if (slotsSelections._size > 0)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[0];
			return coopSlotData.RewiredPlayer;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Player result = default(Player);
		return result;
	}

	public unsafe List<CharacterType> GetCharacterSelections()
	{
		//IL_0072: Expected O, but got I4
		//IL_007a: Expected O, but got Ref
		List<CharacterType> list = new List<CharacterType>();
		int playerCount = GetPlayerCount();
		if (playerCount > 1 || IsOnlineMultiplayer)
		{
			if (_slotsSelections != null)
			{
				List<CoopSlotData>.Enumerator enumerator = default(List<CoopSlotData>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<CoopSlotData>.Enumerator enumerator2 = (List<CoopSlotData>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				goto IL_0135;
			}
		}
		else
		{
			bool flag = _playerOptions == null;
			MultiplayerManager playerOptions = (MultiplayerManager)(object)_playerOptions;
			if (!flag)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
					goto IL_0135;
				}
			}
		}
		throw new NullReferenceException();
		IL_0135:
		return list;
	}

	public void SelectSlot(int slot)
	{
		List<CoopSlotData> slotsSelections = _slotsSelections;
		_selectedPlayerIndex = slot;
		if (slot < slotsSelections._size)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[slot];
			if (coopSlotData.RewiredPlayer == null)
			{
				SelectPlayerOneToControlUI(exclusiveUIControl: true);
			}
			else
			{
				float vibrationMS = default(float);
				SelectPlayerToControlUI(coopSlotData.RewiredPlayer, exclusiveUIControl: true, vibrate: true, vibrationMS);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void SelectPlayerToControlUI(Player p, bool exclusiveUIControl = false, bool vibrate = true, float vibrationMS = 200f)
	{
		//IL_0259: Expected O, but got I4
		if (p.id != 0)
		{
			RewiredStandaloneInputModule inputModule = InputModule;
			inputModule.m_allowMouseInput = false;
		}
		else
		{
			RewiredStandaloneInputModule inputModule2 = InputModule;
			inputModule2.m_allowMouseInput = true;
		}
		if (exclusiveUIControl)
		{
			PlayerControlOverride(p);
			bool flag = _previousUIControllingPlayer == p;
			bool flag2 = false;
			if (!flag)
			{
				flag2 = vibrate;
			}
			object obj = default(object);
			if (!flag2 || (nint)obj <= 0)
			{
				GameManager core = GM.Core;
				bool flag4;
				if ((object)GM.Core != null)
				{
					bool flag3 = ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0;
					flag4 = !flag3;
				}
				else
				{
					flag4 = false;
				}
				object obj2 = vibrate & flag4;
				if (obj2 == null || (nint)obj <= 0)
				{
					goto IL_01e7;
				}
			}
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CControllerVibrationEnabled_003Ek__BackingField)
			{
				float duration = (float)obj * 0.001f;
				bool stopOtherMotors = default(bool);
				p.SetVibration(0, 1f, duration, stopOtherMotors);
				int id = p.id;
				int num = default(int);
				string text = num.ToString();
				string message = "MP : Sending vibration to player : " + text;
				Debug.Log(message);
			}
		}
		goto IL_01e7;
		IL_01e7:
		_previousUIControllingPlayer = p;
	}

	public void Refresh()
	{
		OnRefresh refreshUI = this.m_RefreshUI;
		if (this.m_RefreshUI != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v32.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		List<Player> rewiredPlayersWithSlots = RewiredPlayersWithSlots;
		List<Player>.Enumerator enumerator = default(List<Player>.Enumerator);
		while (enumerator.MoveNext())
		{
			int num = FindSlotIndexContainingRewiredPlayer(null);
			if (num >= 0)
			{
				Color slotColor = GetSlotColor(num);
			}
		}
	}

	public void PreviousPlayer(bool exclusiveUIControl = true, bool vibrate = true)
	{
		int selectedPlayerIndex = _selectedPlayerIndex - 1;
		_selectedPlayerIndex = selectedPlayerIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6676]");
		if ((nint)0 < (nint)0)
		{
			_selectedPlayerIndex = 0;
		}
		List<CoopSlotData> slotsSelections = _slotsSelections;
		int selectedPlayerIndex2 = _selectedPlayerIndex;
		if (_selectedPlayerIndex < slotsSelections._size)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[selectedPlayerIndex2];
			if (coopSlotData.RewiredPlayer != null)
			{
				float vibrationMS = default(float);
				SelectPlayerToControlUI(coopSlotData.RewiredPlayer, exclusiveUIControl, vibrate, vibrationMS);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public Player GetSelectedPlayer()
	{
		List<CoopSlotData> slotsSelections = _slotsSelections;
		int selectedPlayerIndex = _selectedPlayerIndex;
		if (_selectedPlayerIndex < slotsSelections._size)
		{
			CoopSlotData[] items = slotsSelections._items;
			CoopSlotData coopSlotData = items[selectedPlayerIndex];
			if (coopSlotData.RewiredPlayer == null)
			{
				return GetRewiredPlayerOne();
			}
			return coopSlotData.RewiredPlayer;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Player result = default(Player);
		return result;
	}

	public int GetSelectedPlayerIndex()
	{
		return _selectedPlayerIndex;
	}

	public List<VampireSurvivors.Objects.Characters.CharacterController> GetAllCharacters()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			return core._mainCharacters;
		}
		return (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)new NullReferenceException();
	}

	public unsafe Color GetRewiredPlayerColour(Player player)
	{
		//IL_0015: Expected F4, but got I
		//IL_0010: Expected native int or pointer, but got O
		//IL_005b: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		Color color = default(Color);
		((Color*)(nint)color)->r = 0f;
		int num = FindSlotIndexContainingRewiredPlayer(player);
		if (num >= 0)
		{
			((Color*)(nint)color)->r = GetSlotColor(num).r;
		}
		return color;
	}

	public unsafe Color GetUIControlColour()
	{
		//IL_0152: Expected F4, but got I
		//IL_014d: Expected native int or pointer, but got O
		//IL_00d2: Expected F4, but got I
		//IL_017c: Expected native int or pointer, but got O
		RewiredStandaloneInputModule inputModule = InputModule;
		int[] rewiredPlayerIds = inputModule.RewiredPlayerIds;
		Color color = default(Color);
		if (rewiredPlayerIds.Length >= 1)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CTintUISelection_003Ek__BackingField)
			{
				RewiredStandaloneInputModule inputModule2 = InputModule;
				int[] rewiredPlayerIds2 = inputModule2.RewiredPlayerIds;
				if (rewiredPlayerIds2.Length > 0)
				{
					ReInput.PlayerHelper players = ReInput.players;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					float r = 0f;
					Player player = players.GetPlayer(rewiredPlayerIds2[0]);
					int num = FindSlotIndexContainingRewiredPlayer(player);
					if (num >= 0)
					{
						r = GetSlotColor(num).r;
					}
					((Color*)(nint)color)->r = r;
					return color;
				}
				return (Color)new IndexOutOfRangeException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		((Color*)(nint)color)->r = 0f;
		return color;
	}

	public void EnsurePlayableCharacters()
	{
		//IL_012f: Expected O, but got I
		//IL_01df: Expected O, but got I
		if (Stage.HasAllNonVoidCharacters())
		{
			return;
		}
		List<CharacterType> validAnyStageCharacters = Stage.GetValidAnyStageCharacters();
		PlayerOptionsData config = _playerOptions.Config;
		if (config._selectedChar != CharacterType.VOID)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			CharacterType item = default(CharacterType);
			validAnyStageCharacters.Insert((int)config2._selectedChar, item);
			object obj = default(object);
			if (obj != null)
			{
				bool flag = ((List<System.Int32Enum>)(object)validAnyStageCharacters).Remove((System.Int32Enum)config2._selectedChar);
				((List<System.Int32Enum>)(object)validAnyStageCharacters).Insert(0, (System.Int32Enum)config2._selectedChar);
			}
		}
		else
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_032b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v20+20]");
			config3.SelectedCharacter = CharacterType.VOID;
		}
		int playerCount = GetPlayerCount();
		if (playerCount <= 1 && !IsOnlineMultiplayer)
		{
			return;
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rdx_v11+20]");
			config4.SelectedCharacter = CharacterType.VOID;
			List<CoopSlotData> slotsSelections = _slotsSelections;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < slotsSelections._size)
				{
					List<CoopSlotData> slotsSelections2 = _slotsSelections;
					if (num >= slotsSelections2._size)
					{
						break;
					}
					CoopSlotData[] items = slotsSelections2._items;
					CoopSlotData coopSlotData = items[num];
					if (coopSlotData.RewiredPlayer != null || coopSlotData.AIType > AIType.None)
					{
						((List<CharacterType>)(object)_slotsSelections).Insert(num, CharacterType.VOID);
						validAnyStageCharacters.Insert(num, CharacterType.VOID);
					}
					slotsSelections = _slotsSelections;
					num++;
					num2 = num;
					continue;
				}
				return;
			}
		}
		goto IL_032b;
		IL_032b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public MultiplayerManager()
	{
		List<Player> rewiredPlayersToRemove = new List<Player>();
		_rewiredPlayersToRemove = rewiredPlayersToRemove;
		List<Player> rewiredPlayersWithSlotsCache = new List<Player>();
		_rewiredPlayersWithSlotsCache = rewiredPlayersWithSlotsCache;
		List<Player> disconnectedPlayers = new List<Player>();
		_disconnectedPlayers = disconnectedPlayers;
		List<Player> freeRewiredPlayers = new List<Player>();
		_freeRewiredPlayers = freeRewiredPlayers;
	}
}
