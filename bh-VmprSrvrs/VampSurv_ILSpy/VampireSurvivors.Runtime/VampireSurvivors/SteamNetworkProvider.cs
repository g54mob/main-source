using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Transport;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class SteamNetworkProvider : INetworkProvider
{
	[StructLayout((LayoutKind)3)]
	private struct _003CShutDown_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SteamNetworkProvider _003C_003E4__this;

		private unsafe void MoveNext()
		{
			//IL_0095: Expected O, but got Ref
			//IL_0286: Expected I4, but got I8
			//IL_0281: Expected native int or pointer, but got O
			//IL_003b: Expected O, but got I
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Expected O, but got Unknown
			//IL_00b3: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_012d: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_02c0: Expected O, but got I
			//IL_02c9: Expected O, but got I4
			//IL_0154: Expected O, but got I4
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_0210: Expected O, but got I8
			//IL_0236: Expected O, but got Ref
			object obj = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+38]");
				((SteamSocketManager)0).Close();
				Action value = ((SteamNetworkProvider)obj).OnP2PSessionBecomeReady;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+38]");
				((SteamSocketManager)0).OnSessionReady -= value;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+40]");
			bool flag = (nint)0 == 0;
			_003CShutDown_003Ed__39 obj2 = (_003CShutDown_003Ed__39)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+40]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4240]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v7+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v7+38]");
					Connection connection = (Connection)((nint)0 + (nint)24);
					bool flag2 = ((Connection*)connection)->Close(linger: true);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r14_v1 (System.Object)+40]");
				object obj4 = 0;
				Action<string> value2 = ((SteamNetworkProvider)obj).OnP2PActivationFailed;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r13_v6+20]");
				Delegate obj5 = (Delegate)0;
				object obj6 = 0;
				object obj9 = default(object);
				bool flag5;
				do
				{
					Delegate obj7 = Delegate.Remove(obj5, value2);
					object obj8;
					if ((object)obj7 == null)
					{
						obj8 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag3 = obj9 == null;
						obj8 = obj9;
						if (flag3)
						{
							throw new InvalidCastException();
						}
					}
					object obj10 = obj4 + 32;
					bool flag4 = obj5 == obj10;
					Delegate obj11;
					if (obj5 == obj10)
					{
						obj10 = obj8;
						obj11 = obj5;
					}
					else
					{
						obj11 = (Delegate)obj10;
					}
					Delegate obj12 = obj5;
					if (!flag4)
					{
						obj12 = obj11;
					}
					flag5 = (object)obj12 != obj5;
					obj6 = 6603577472L;
					obj5 = obj12;
				}
				while (flag5);
				_ = 0;
				obj2 = (_003CShutDown_003Ed__39)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}
			((_003CShutDown_003Ed__39*)(nint)obj2)->_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)(obj2 + 8);
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private string _003CInitializationError_003Ek__BackingField;

	private Action _003COnJoinError_003Ek__BackingField;

	private Action _003COnP2PSessionReady_003Ek__BackingField;

	private Action<string> _003COnP2PSessionError_003Ek__BackingField;

	private Coherence.Log.Logger _logger;

	private SteamSocketManager _steamSocketManager;

	private SteamConnectionManager _steamConnectionManager;

	private float _currentTimeout;

	private bool _hostingSession;

	private const float _expectedPeersTimeout = 12f;

	public NetworkProviders Provider => NetworkProviders.Steam;

	public NetworkType NetworkType => NetworkType.P2P;

	public bool UsesRsl => true;

	public bool IsReady
	{
		get
		{
			//IL_0095: Expected I4, but got O
			//IL_004b: Expected O, but got I
			if (!SteamClient.initialized)
			{
				return false;
			}
			Steamworks.ISteamUser steamUser = SteamUser.Internal;
			if (steamUser != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982BF0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982BF0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v227 @ rax_v12 (should have been resolved before IL gen)");
				object obj2 = default(object);
				bool flag = obj2 == null;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public string InitializationError
	{
		get
		{
			return _003CInitializationError_003Ek__BackingField;
		}
		private set
		{
			_003CInitializationError_003Ek__BackingField = value;
		}
	}

	public Action OnJoinError
	{
		get
		{
			return _003COnJoinError_003Ek__BackingField;
		}
		set
		{
			_003COnJoinError_003Ek__BackingField = value;
		}
	}

	public Action OnP2PSessionReady
	{
		get
		{
			return _003COnP2PSessionReady_003Ek__BackingField;
		}
		set
		{
			_003COnP2PSessionReady_003Ek__BackingField = value;
		}
	}

	public Action<string> OnP2PSessionError
	{
		get
		{
			return _003COnP2PSessionError_003Ek__BackingField;
		}
		set
		{
			_003COnP2PSessionError_003Ek__BackingField = value;
		}
	}

	public int HostConnectedPlayers
	{
		get
		{
			//IL_00a9: Expected I4, but got O
			//IL_0091: Expected I4, but got O
			//IL_009f: Expected I4, but got O
			//IL_003a: Expected O, but got I
			//IL_004a: Expected O, but got I
			int num = (int)_steamSocketManager;
			if (_steamSocketManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Int32)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Int32)+28]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v5+20]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v5+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6+20]");
						return (int)((nint)0 + (nint)1);
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return (int)_steamSocketManager;
		}
	}

	public SteamNetworkProvider(Coherence.Log.Logger logger)
	{
		_logger = logger;
		bool flag = CheckLoginStatus();
	}

	public unsafe void JoinP2P(LobbySession lobbySession)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		//IL_0093: Expected O, but got I
		//IL_02f2: Expected O, but got Ref
		//IL_029f: Expected I, but got O
		//IL_00ff: Expected O, but got Ref
		//IL_016b: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		obj = lobbySession.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		LobbyData lobbyData = default(LobbyData);
		CloudAttribute? attribute = lobbyData.GetAttribute((string)(&obj2));
		if (attribute != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
			string stringValue = ((CloudAttribute*)(&lobbyData))->GetStringValue();
			if (stringValue != null)
			{
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj4 = default(object);
				ulong num = System.Number.ParseUInt64((ReadOnlySpan<char>)(&obj4), NumberStyles.Integer, currentInfo);
				(string, object)[] args = new(string, object)[1];
				ulong num2 = default(ulong);
				string item = num2.ToString();
				(string, object) tuple = ("Host Id", item);
				_ = 0;
				_logger.Info("Joining P2P Steam Session", args);
				SteamConnectionManager steamConnectionManager = null;
				steamConnectionManager._hostSteamId = (SteamId)num;
				_steamConnectionManager = steamConnectionManager;
				SteamConnectionManager steamConnectionManager2 = _steamConnectionManager;
				Action<string> b = OnP2PActivationFailed;
				Delegate obj5 = steamConnectionManager2.P2PActivationFailed;
				Action<string> action = default(Action<string>);
				while (true)
				{
					Delegate obj6 = Delegate.Combine(obj5, b);
					Action<string> p2PActivationFailed;
					if ((object)obj6 == null)
					{
						p2PActivationFailed = null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag = action == null;
						p2PActivationFailed = action;
						if (flag)
						{
							break;
						}
					}
					bool flag2 = (object)obj5 == steamConnectionManager2.P2PActivationFailed;
					Delegate obj7;
					if ((object)obj5 == steamConnectionManager2.P2PActivationFailed)
					{
						steamConnectionManager2.P2PActivationFailed = p2PActivationFailed;
						obj7 = obj5;
					}
					else
					{
						obj7 = steamConnectionManager2.P2PActivationFailed;
					}
					Delegate obj8 = obj5;
					if (!flag2)
					{
						obj8 = obj7;
					}
					bool flag3 = (object)obj8 != obj5;
					obj5 = obj8;
					if (!flag3)
					{
						_steamConnectionManager.Open();
						return;
					}
				}
				throw new InvalidCastException();
			}
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.s);
		}
		else
		{
			Coherence.Log.Logger logger = _logger;
			(string, object)[] args2 = Array.Empty<(string, object)>();
			nint num3 = (nint)logger;
			logger.Error("Host Id attribute not found. Aborting join game.", args2);
			Action<string> action2 = _003COnP2PSessionError_003Ek__BackingField;
			if (_003COnP2PSessionError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v366 @ rax_v21 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnP2PActivationFailed(string errorMessage)
	{
		Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
		if (_003COnP2PSessionError_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe bool JoinGame(LobbySession lobbySession)
	{
		//IL_010f: Expected I4, but got O
		//IL_00f0: Expected O, but got Ref
		if (CheckLoginStatus())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			CoherenceBridge coherenceBridge = default(CoherenceBridge);
			if ((object)coherenceBridge != null)
			{
				coherenceBridge.SetRelay(null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				SteamTransportFactory steamTransportFactory = null;
				steamTransportFactory._steamConnectionManager = _steamConnectionManager;
				CoherenceBridge coherenceBridge2 = default(CoherenceBridge);
				if ((object)coherenceBridge2 != null)
				{
					coherenceBridge2.SetTransportFactory(steamTransportFactory);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
					EndpointData localEndpoint = RoomSelectionPage.GetLocalEndpoint();
					CoherenceBridge coherenceBridge3 = default(CoherenceBridge);
					if ((object)coherenceBridge3 != null)
					{
						bool isSimulator = SimulatorUtility.IsSimulator;
						string text = default(string);
						ConnectionSettings connectionSettings = default(ConnectionSettings);
						coherenceBridge3.Connect((EndpointData)(&text), isSimulator ? ConnectionType.Simulator : ConnectionType.Client, false, connectionSettings);
						return true;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public unsafe void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
	{
		//IL_003f: Expected I, but got O
		//IL_0078: Expected O, but got Ref
		//IL_00e1: Expected O, but got Ref
		//IL_00fe: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected I4, but got Unknown
		//IL_0430: Expected O, but got Ref
		if (!CheckLoginStatus())
		{
			return;
		}
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		if (_logger != null)
		{
			nint num = (nint)logger;
			_logger.Info("Starting Steam P2P Session", args);
			if (lobbySession != null)
			{
				object obj2 = default(object);
				object obj = (object)(&obj2);
				obj = lobbySession.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+98]");
				obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				object obj4 = default(object);
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj5 = default(object);
					int expectedPeers = obj5 - 1;
					SteamSocketManager steamSocketManager = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					object obj6 = default(object);
					string message = string.FormatHelper((IFormatProvider)null, "Created SteamSocketManager. Expected Peers: {0}", (System.ParamsArray)(&obj6));
					Debug.Log(message);
					steamSocketManager._expectedPeers = expectedPeers;
					_steamSocketManager = steamSocketManager;
					SteamSocketManager steamSocketManager2 = _steamSocketManager;
					Action b = OnP2PSessionBecomeReady;
					if (_steamSocketManager != null)
					{
						Delegate obj7 = steamSocketManager2.OnSessionReady;
						while (true)
						{
							Delegate obj8 = Delegate.Combine(obj7, b);
							bool flag = (object)obj8 == null;
							Delegate obj9 = null;
							if (!flag)
							{
								bool flag2 = (object)obj8.GetType() != typeof(Action);
								obj9 = null;
								if (!flag2)
								{
									obj9 = obj8;
								}
								if ((object)obj9 == null)
								{
									break;
								}
							}
							bool flag3 = (object)obj7 == steamSocketManager2.OnSessionReady;
							Delegate obj10;
							if ((object)obj7 == steamSocketManager2.OnSessionReady)
							{
								steamSocketManager2.OnSessionReady = (Action)obj9;
								obj10 = obj7;
							}
							else
							{
								obj10 = steamSocketManager2.OnSessionReady;
							}
							Delegate obj11 = obj7;
							if (!flag3)
							{
								obj11 = obj10;
							}
							bool flag4 = (object)obj11 != obj7;
							obj7 = obj11;
							if (flag4)
							{
								continue;
							}
							goto IL_02b7;
						}
						goto IL_04c5;
					}
				}
			}
		}
		goto IL_03d7;
		IL_02b7:
		if (_steamSocketManager != null)
		{
			string text = _steamSocketManager.Open();
			bool hostingSession = ((text == null || text._stringLength <= 0) ? true : false);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			SteamId steamId = SteamClient.SteamId;
			ulong num2 = default(ulong);
			string value = num2.ToString();
			if (dictionary != null)
			{
				bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.P2PHostId, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				_hostingSession = hostingSession;
				_currentTimeout = 12f;
				if (onGameReady != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onGameReady @ r8 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
		}
		goto IL_03d7;
		IL_03d7:
		NullReferenceException ex = new NullReferenceException();
		goto IL_04c5;
		IL_04c5:
		throw new InvalidCastException();
	}

	private void OnP2PSessionBecomeReady()
	{
		Action action = _003COnP2PSessionReady_003Ek__BackingField;
		if (_003COnP2PSessionReady_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe void HostGame()
	{
		//IL_00bd: Expected O, but got Ref
		Action value = OnP2PSessionBecomeReady;
		_steamSocketManager.OnSessionReady -= value;
		SteamRelay steamRelay = null;
		Dictionary<Connection, SteamRelayConnection> connectionMap = null;
		EqualityComparer<Connection> equalityComparer = EqualityComparer<Connection>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		steamRelay._connectionMap = connectionMap;
		steamRelay._steamSocketManager = _steamSocketManager;
		CoherenceBridgeStore.masterBridge.SetRelay(steamRelay);
		CoherenceBridgeStore.masterBridge.SetTransportType(TransportType.UDPWithTCPFallback, TransportConfiguration.Default);
		EndpointData localEndpoint = RoomSelectionPage.GetLocalEndpoint();
		bool isSimulator = SimulatorUtility.IsSimulator;
		string text = default(string);
		ConnectionSettings connectionSettings = default(ConnectionSettings);
		CoherenceBridgeStore.masterBridge.Connect((EndpointData)(&text), isSimulator ? ConnectionType.Simulator : ConnectionType.Client, false, connectionSettings);
	}

	public unsafe Task ShutDown()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CShutDown_003Ed__39 stateMachine = default(_003CShutDown_003Ed__39);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	public void Update()
	{
		//IL_0129: Invalid comparison between I4 and F4
		//IL_00d6: Invalid comparison between I4 and F4
		if (!_hostingSession || _steamSocketManager == null)
		{
			return;
		}
		SteamSocketManager steamSocketManager = _steamSocketManager;
		if (steamSocketManager._steamSocketManager == null)
		{
			return;
		}
		SocketManager steamSocketManager2 = steamSocketManager._steamSocketManager;
		if (steamSocketManager2.Connected == null)
		{
			return;
		}
		SteamSocketManager steamSocketManager3 = _steamSocketManager;
		SocketManager steamSocketManager4 = steamSocketManager3._steamSocketManager;
		HashSet<Connection> connected = steamSocketManager4.Connected;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3 (System.Collections.Generic.HashSet`1<Steamworks.Data.Connection>)+20]");
		if ((nint)0 > (nint)1)
		{
			if (!(0f < _currentTimeout))
			{
				Action action = _003COnP2PSessionReady_003Ek__BackingField;
				if (_003COnP2PSessionReady_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v76.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				return;
			}
		}
		else if (!(0f < _currentTimeout))
		{
			Action value = OnP2PSessionBecomeReady;
			_steamSocketManager.OnSessionReady -= value;
			Action<string> action2 = _003COnP2PSessionError_003Ek__BackingField;
			_hostingSession = false;
			if (_003COnP2PSessionError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ rax_v12 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
		object obj = default(object);
		float currentTimeout = _currentTimeout - (float)obj;
		_currentTimeout = currentTimeout;
	}

	private void OnP2PHostSessionFailInvoke()
	{
		Action value = OnP2PSessionBecomeReady;
		_steamSocketManager.OnSessionReady -= value;
		Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
		_hostingSession = false;
		if (_003COnP2PSessionError_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rax_v6 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	private bool CheckLoginStatus()
	{
		if (!SteamClient.initialized)
		{
			_003CInitializationError_003Ek__BackingField = "Steam Not Initialized";
			Action action = _003COnJoinError_003Ek__BackingField;
			if (_003COnJoinError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v141.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return false;
		}
		return true;
	}
}
