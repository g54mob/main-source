using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Transport;
using Cpp2ILInjected;
using PartyCSharpSDK;
using PlayFab.ClientModels;
using PlayFab.Party;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class PlayFabNetworkProvider : INetworkProvider
{
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public PlayFabNetworkProvider _003C_003E4__this;

		public Action<bool, string, Dictionary<string, string>> onGameReady;

		internal void _003CPrepareGame_003Eb__0(object sender, string networkId)
		{
			//IL_00ee: Expected O, but got I
			//IL_00fe: Expected O, but got I
			PlayFabNetworkProvider playFabNetworkProvider = _003C_003E4__this;
			(string, object)[] args = new(string, object)[1];
			(string, object) tuple = ("Id", networkId);
			_ = 0;
			playFabNetworkProvider._logger.Info("Joined Network Successfully", args);
			PlayFabNetworkProvider playFabNetworkProvider2 = _003C_003E4__this;
			playFabNetworkProvider2._playFabMultiplayerManager.OnNetworkJoined -= playFabNetworkProvider2._hostJoinedHandler;
			PlayFabNetworkProvider playFabNetworkProvider3 = _003C_003E4__this;
			playFabNetworkProvider3._playFabMultiplayerManager.OnError -= playFabNetworkProvider3._errorHandler;
			PlayFabNetworkProvider playFabNetworkProvider4 = _003C_003E4__this;
			playFabNetworkProvider4._hostingSession = true;
			Action<bool, string, Dictionary<string, string>> action = onGameReady;
			if (onGameReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v18+B8]");
				object obj2 = 0;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.PlayFabNetworkId, (object)networkId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				PlayFabNetworkProvider playFabNetworkProvider5 = _003C_003E4__this;
				PlayFabMultiplayerManager playFabMultiplayerManager = playFabNetworkProvider5._playFabMultiplayerManager;
				PlayFabLocalPlayer localPlayer = playFabMultiplayerManager._localPlayer;
				EntityKey entityKey = ((PlayFabPlayer)localPlayer)._003CEntityKey_003Ek__BackingField;
				bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.P2PHostId, (object)entityKey.Id, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ rsi_v5 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CPrepareGame_003Eb__1(object sender, PlayFabMultiplayerManagerErrorArgs args)
		{
			PlayFabNetworkProvider playFabNetworkProvider = _003C_003E4__this;
			(string, object)[] args2 = new(string, object)[1];
			(string, object) tuple = ("Message", args._003CMessage_003Ek__BackingField);
			_ = 0;
			playFabNetworkProvider._logger.Info("Error during P2P Game Creation", args2);
			PlayFabNetworkProvider playFabNetworkProvider2 = _003C_003E4__this;
			playFabNetworkProvider2._playFabMultiplayerManager.OnNetworkJoined -= playFabNetworkProvider2._hostJoinedHandler;
			PlayFabNetworkProvider playFabNetworkProvider3 = _003C_003E4__this;
			playFabNetworkProvider3._playFabMultiplayerManager.OnError -= playFabNetworkProvider3._errorHandler;
			PlayFabNetworkProvider playFabNetworkProvider4 = _003C_003E4__this;
			playFabNetworkProvider4._playFabMultiplayerManager.OnRemotePlayerJoined -= playFabNetworkProvider4._playerJoinedHandler;
			Action<bool, string, Dictionary<string, string>> action = onGameReady;
			if (onGameReady != null)
			{
				string text = "Error during P2P Game Creation: " + args._003CMessage_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v353 @ rbx_v2 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CPrepareGame_003Eb__2(object sender, PlayFabPlayer player)
		{
			PlayFabNetworkProvider playFabNetworkProvider = _003C_003E4__this;
			(string, object)[] args = new(string, object)[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item = default(object);
			(string, object) tuple = ("Expected Peers", item);
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item2 = default(object);
			(string, object) tuple2 = ("Timeout", item2);
			_ = 0;
			playFabNetworkProvider._logger.Info("Remote Player Joined The Network", args);
			PlayFabNetworkProvider playFabNetworkProvider2 = _003C_003E4__this;
			int expectedPeers = playFabNetworkProvider2._expectedPeers - 1;
			playFabNetworkProvider2._expectedPeers = expectedPeers;
			PlayFabNetworkProvider playFabNetworkProvider3 = _003C_003E4__this;
			if (playFabNetworkProvider3._expectedPeers == 0)
			{
				playFabNetworkProvider3.OnP2PSessionReadyInvoke();
			}
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLoginWithPlayFab_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public PlayFabNetworkProvider _003C_003E4__this;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0125: Expected O, but got I
			//IL_00af: Expected O, but got I4
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_0160: Expected I, but got O
			//IL_0170: Expected O, but got I
			//IL_02f1: Expected O, but got Ref
			//IL_026d: Expected I, but got O
			//IL_01ac: Expected O, but got I
			//IL_0344: Expected I4, but got I8
			//IL_034f: Expected O, but got Ref
			PlayFabNetworkProvider playFabNetworkProvider = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Debug.Log("Attempting to login with PlayFab...");
				Task<ILoginResult> task2 = BackendFacade.Login();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				object obj4 = obj3;
				nint num3 = (nint)typeof(PlayFabLoginSuccess);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdx_v22 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r8_v11+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdx_v22 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r8_v11+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v49+FFFFFFF8+v313 @ rax_v48*8]");
					if (0 == (nint)typeof(PlayFabLoginSuccess))
					{
						(string, object)[] args = Array.Empty<(string, object)>();
						playFabNetworkProvider._logger.Info("PlayFab Login Successful", args);
						playFabNetworkProvider._003CIsReady_003Ek__BackingField = true;
						goto IL_0335;
					}
				}
			}
			playFabNetworkProvider._003CInitializationError_003Ek__BackingField = "PlayFab Is Not Available";
			Coherence.Log.Logger logger = playFabNetworkProvider._logger;
			(string, object)[] args2 = new(string, object)[1];
			(string, object) tuple = ("Error", playFabNetworkProvider._003CInitializationError_003Ek__BackingField);
			nint num5 = (nint)logger;
			logger.Error("PlayFab Login Failed", args2);
			Action action = playFabNetworkProvider._003COnJoinError_003Ek__BackingField;
			if (playFabNetworkProvider._003COnJoinError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v724.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			goto IL_0335;
			IL_0335:
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private bool _003CIsReady_003Ek__BackingField;

	private string _003CInitializationError_003Ek__BackingField;

	private Action _003COnJoinError_003Ek__BackingField;

	private Action _003COnP2PSessionReady_003Ek__BackingField;

	private Action<string> _003COnP2PSessionError_003Ek__BackingField;

	private Coherence.Log.Logger _logger;

	private PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS _connectivityOptions;

	private PlayFabMultiplayerManager _playFabMultiplayerManager;

	private int _expectedPeers;

	private bool _hostingSession;

	private float _currentTimeout;

	private PlayFabMultiplayerManager.OnNetworkJoinedHandler _hostJoinedHandler;

	private PlayFabMultiplayerManager.OnErrorEventHandler _errorHandler;

	private PlayFabMultiplayerManager.OnRemotePlayerJoinedHandler _playerJoinedHandler;

	private const float _expectedPeersTimeout = 12f;

	public NetworkProviders Provider => NetworkProviders.PlayFab;

	public NetworkType NetworkType => NetworkType.P2P;

	public bool UsesRsl => true;

	public bool IsReady
	{
		get
		{
			return _003CIsReady_003Ek__BackingField;
		}
		private set
		{
			_003CIsReady_003Ek__BackingField = value;
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
			//IL_0062: Expected I4, but got O
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected I4, but got Unknown
			if ((object)_playFabMultiplayerManager != null)
			{
				IList<PlayFabPlayer> remotePlayers = _playFabMultiplayerManager.RemotePlayers;
				if (remotePlayers != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj = default(object);
					return obj + 1;
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return 0;
		}
	}

	public PlayFabNetworkProvider(Coherence.Log.Logger logger)
	{
		_logger = logger;
		PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
		_playFabMultiplayerManager = playFabMultiplayerManager;
		if (!BackendFacade.IsLoggedIn())
		{
			Debug.Log("<PlayFabNetworkProvider.PlayFabNetworkProvider> PlayFab is not logged in");
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003CLoginWithPlayFab_003Ed__50 stateMachine = default(_003CLoginWithPlayFab_003Ed__50);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
		else
		{
			Debug.Log("<PlayFabNetworkProvider.PlayFabNetworkProvider> PlayFab is already logged in");
			_003CIsReady_003Ek__BackingField = true;
		}
		_connectivityOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u;
	}

	public unsafe void JoinP2P(LobbySession lobbySession)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		//IL_0093: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01ed: Expected O, but got Ref
		//IL_0262: Expected O, but got I
		//IL_02a3: Expected O, but got Ref
		//IL_0184: Expected I, but got O
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
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = lobbySession.lobbyData;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		LobbyData lobbyData2 = default(LobbyData);
		CloudAttribute? attribute2 = lobbyData2.GetAttribute((string)(&obj2));
		if (attribute != null && attribute2 != null)
		{
			string stringValue = ((CloudAttribute*)(&lobbyData))->GetStringValue();
			PlayFabMultiplayerManager.OnErrorEventHandler value = OnJoinNetworkError;
			_playFabMultiplayerManager.OnError += value;
			PlayFabMultiplayerManager.OnNetworkJoinedHandler value2 = OnNetworkJoined;
			_playFabMultiplayerManager.OnNetworkJoined += value2;
			_playFabMultiplayerManager.JoinNetworkImplStart(stringValue);
			return;
		}
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		nint num = (nint)logger;
		logger.Error("Missing network id or host id from the Lobby attributes. Aborting join.", args);
		Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
		if (_003COnP2PSessionError_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v356 @ rax_v15 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnNetworkJoined(object sender, string networkid)
	{
		PlayFabMultiplayerManager.OnNetworkJoinedHandler value = OnNetworkJoined;
		_playFabMultiplayerManager.OnNetworkJoined -= value;
		PlayFabMultiplayerManager.OnErrorEventHandler value2 = OnJoinNetworkError;
		_playFabMultiplayerManager.OnError -= value2;
		(string, object)[] args = new(string, object)[1];
		(string, object) tuple = ("Id", networkid);
		_ = 0;
		_logger.Info("Joined Network Successfully", args);
	}

	private void OnJoinNetworkError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
		//IL_0060: Expected I, but got O
		PlayFabMultiplayerManager.OnErrorEventHandler value = OnJoinNetworkError;
		_playFabMultiplayerManager.OnError -= value;
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args2 = new(string, object)[1];
		(string, object) tuple = ("Message", args._003CMessage_003Ek__BackingField);
		_ = 0;
		nint num = (nint)logger;
		logger.Error("Failed to join network", args2);
		Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
		if (_003COnP2PSessionError_003Ek__BackingField != null)
		{
			string text = "Failed to join PlayFab Network: " + args._003CMessage_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ rbx_v5 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe bool JoinGame(LobbySession lobbySession)
	{
		//IL_000d: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		//IL_0093: Expected O, but got I
		//IL_017c: Expected O, but got Ref
		//IL_0164: Expected O, but got Ref
		string text = default(string);
		object obj = (object)(&text);
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
		object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref text, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		LobbyData lobbyData = default(LobbyData);
		CloudAttribute? attribute = lobbyData.GetAttribute((string)(&text));
		CoherenceBridgeStore.masterBridge.SetRelay(null);
		bool flag = attribute == null;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if (!flag)
		{
			string stringValue = ((CloudAttribute*)(&lobbyData))->GetStringValue();
			PlayFabMultiplayerManager manager = PlayFabMultiplayerManager.Get();
			PlayFabTransportFactory playFabTransportFactory = null;
			playFabTransportFactory.manager = manager;
			playFabTransportFactory.host = stringValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
			EndpointData localEndpoint = RoomSelectionPage.GetLocalEndpoint();
			bool isSimulator = SimulatorUtility.IsSimulator;
			ConnectionSettings connectionSettings = default(ConnectionSettings);
			CoherenceBridgeStore.masterBridge.Connect((EndpointData)(&text), isSimulator ? ConnectionType.Simulator : ConnectionType.Client, false, connectionSettings);
			return true;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		bool result = default(bool);
		return result;
	}

	public unsafe void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
	{
		//IL_0039: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		//IL_00bf: Expected O, but got I
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected I4, but got Unknown
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass43_0();
		if (CS_0024_003C_003E8__locals19 != null)
		{
			CS_0024_003C_003E8__locals19._003C_003E4__this = this;
			CS_0024_003C_003E8__locals19.onGameReady = onGameReady;
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
					_currentTimeout = 12f;
					_expectedPeers = expectedPeers;
					PlayFabMultiplayerManager.OnNetworkJoinedHandler hostJoinedHandler = delegate(object sender, string networkId)
					{
						//IL_00ee: Expected O, but got I
						//IL_00fe: Expected O, but got I
						PlayFabNetworkProvider playFabNetworkProvider = CS_0024_003C_003E8__locals19._003C_003E4__this;
						(string, object)[] args = new(string, object)[1];
						(string, object) tuple = ("Id", networkId);
						_ = 0;
						playFabNetworkProvider._logger.Info("Joined Network Successfully", args);
						PlayFabNetworkProvider playFabNetworkProvider2 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider2._playFabMultiplayerManager.OnNetworkJoined -= playFabNetworkProvider2._hostJoinedHandler;
						PlayFabNetworkProvider playFabNetworkProvider3 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider3._playFabMultiplayerManager.OnError -= playFabNetworkProvider3._errorHandler;
						PlayFabNetworkProvider playFabNetworkProvider4 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider4._hostingSession = true;
						Action<bool, string, Dictionary<string, string>> onGameReady2 = CS_0024_003C_003E8__locals19.onGameReady;
						if (CS_0024_003C_003E8__locals19.onGameReady != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v18+B8]");
							object obj12 = 0;
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.PlayFabNetworkId, (object)networkId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							PlayFabNetworkProvider playFabNetworkProvider5 = CS_0024_003C_003E8__locals19._003C_003E4__this;
							PlayFabMultiplayerManager playFabMultiplayerManager2 = playFabNetworkProvider5._playFabMultiplayerManager;
							PlayFabLocalPlayer localPlayer = playFabMultiplayerManager2._localPlayer;
							EntityKey entityKey = ((PlayFabPlayer)localPlayer)._003CEntityKey_003Ek__BackingField;
							bool flag6 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.P2PHostId, (object)entityKey.Id, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ rsi_v5 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
						}
					};
					_hostJoinedHandler = hostJoinedHandler;
					PlayFabMultiplayerManager.OnErrorEventHandler errorHandler = delegate(object sender, PlayFabMultiplayerManagerErrorArgs args)
					{
						PlayFabNetworkProvider playFabNetworkProvider = CS_0024_003C_003E8__locals19._003C_003E4__this;
						(string, object)[] args2 = new(string, object)[1];
						(string, object) tuple = ("Message", args._003CMessage_003Ek__BackingField);
						_ = 0;
						playFabNetworkProvider._logger.Info("Error during P2P Game Creation", args2);
						PlayFabNetworkProvider playFabNetworkProvider2 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider2._playFabMultiplayerManager.OnNetworkJoined -= playFabNetworkProvider2._hostJoinedHandler;
						PlayFabNetworkProvider playFabNetworkProvider3 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider3._playFabMultiplayerManager.OnError -= playFabNetworkProvider3._errorHandler;
						PlayFabNetworkProvider playFabNetworkProvider4 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						playFabNetworkProvider4._playFabMultiplayerManager.OnRemotePlayerJoined -= playFabNetworkProvider4._playerJoinedHandler;
						Action<bool, string, Dictionary<string, string>> onGameReady2 = CS_0024_003C_003E8__locals19.onGameReady;
						if (CS_0024_003C_003E8__locals19.onGameReady != null)
						{
							string text = "Error during P2P Game Creation: " + args._003CMessage_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v353 @ rbx_v2 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
						}
					};
					_errorHandler = errorHandler;
					PlayFabMultiplayerManager.OnRemotePlayerJoinedHandler playerJoinedHandler = delegate
					{
						PlayFabNetworkProvider playFabNetworkProvider = CS_0024_003C_003E8__locals19._003C_003E4__this;
						(string, object)[] args = new(string, object)[2];
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object item = default(object);
						(string, object) tuple = ("Expected Peers", item);
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object item2 = default(object);
						(string, object) tuple2 = ("Timeout", item2);
						_ = 0;
						playFabNetworkProvider._logger.Info("Remote Player Joined The Network", args);
						PlayFabNetworkProvider playFabNetworkProvider2 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						int expectedPeers2 = playFabNetworkProvider2._expectedPeers - 1;
						playFabNetworkProvider2._expectedPeers = expectedPeers2;
						PlayFabNetworkProvider playFabNetworkProvider3 = CS_0024_003C_003E8__locals19._003C_003E4__this;
						if (playFabNetworkProvider3._expectedPeers == 0)
						{
							playFabNetworkProvider3.OnP2PSessionReadyInvoke();
						}
					};
					_playerJoinedHandler = playerJoinedHandler;
					if ((object)_playFabMultiplayerManager != null)
					{
						_playFabMultiplayerManager.OnNetworkJoined += _hostJoinedHandler;
						if ((object)_playFabMultiplayerManager != null)
						{
							_playFabMultiplayerManager.OnError += _errorHandler;
							PlayFabMultiplayerManager playFabMultiplayerManager = _playFabMultiplayerManager;
							if ((object)_playFabMultiplayerManager != null)
							{
								Delegate obj6 = playFabMultiplayerManager.OnRemotePlayerJoined;
								while (true)
								{
									Delegate obj7 = Delegate.Combine(obj6, _playerJoinedHandler);
									bool flag = (object)obj7 == null;
									Delegate obj8 = null;
									if (!flag)
									{
										bool flag2 = (object)obj7.GetType() != typeof(PlayFabMultiplayerManager.OnRemotePlayerJoinedHandler);
										obj8 = null;
										if (!flag2)
										{
											obj8 = obj7;
										}
										if ((object)obj8 == null)
										{
											break;
										}
									}
									bool flag3 = (object)obj6 == playFabMultiplayerManager.OnRemotePlayerJoined;
									Delegate obj9;
									if ((object)obj6 == playFabMultiplayerManager.OnRemotePlayerJoined)
									{
										playFabMultiplayerManager.OnRemotePlayerJoined = (PlayFabMultiplayerManager.OnRemotePlayerJoinedHandler)obj8;
										obj9 = obj6;
									}
									else
									{
										obj9 = playFabMultiplayerManager.OnRemotePlayerJoined;
									}
									Delegate obj10 = obj6;
									if (!flag3)
									{
										obj10 = obj9;
									}
									bool flag4 = (object)obj10 != obj6;
									obj6 = obj10;
									if (flag4)
									{
										continue;
									}
									goto IL_0316;
								}
								goto IL_044d;
							}
						}
					}
				}
			}
		}
		goto IL_038c;
		IL_038c:
		NullReferenceException ex = new NullReferenceException();
		goto IL_044d;
		IL_0316:
		PlayFabNetworkConfiguration playFabNetworkConfiguration = new PlayFabNetworkConfiguration();
		playFabNetworkConfiguration._directPeerConnectivityOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u;
		playFabNetworkConfiguration._maxPlayerCount = 32u;
		playFabNetworkConfiguration._directPeerConnectivityOptions = _connectivityOptions;
		playFabNetworkConfiguration.MaxPlayerCount = 4u;
		if ((object)_playFabMultiplayerManager != null)
		{
			_playFabMultiplayerManager.CreateAndJoinNetworkImplStart(playFabNetworkConfiguration);
			return;
		}
		goto IL_038c;
		IL_044d:
		throw new InvalidCastException();
	}

	public unsafe void HostGame()
	{
		//IL_00a3: Expected O, but got Ref
		PlayFabRelay playFabRelay = null;
		Dictionary<PlayFabPlayer, PlayFabRelayConnection> connectionMap = new Dictionary<PlayFabPlayer, PlayFabRelayConnection>();
		playFabRelay._connectionMap = connectionMap;
		Coherence.Log.Logger logger = Log.GetLogger<PlayFabRelay>();
		playFabRelay._logger = logger;
		playFabRelay._connectivityOptions = _connectivityOptions;
		CoherenceBridgeStore.masterBridge.SetRelay(playFabRelay);
		CoherenceBridgeStore.masterBridge.SetTransportType(TransportType.UDPWithTCPFallback, TransportConfiguration.Default);
		EndpointData localEndpoint = RoomSelectionPage.GetLocalEndpoint();
		bool isSimulator = SimulatorUtility.IsSimulator;
		string text = default(string);
		ConnectionSettings connectionSettings = default(ConnectionSettings);
		CoherenceBridgeStore.masterBridge.Connect((EndpointData)(&text), isSimulator ? ConnectionType.Simulator : ConnectionType.Client, false, connectionSettings);
	}

	public Task ShutDown()
	{
		if ((object)_playFabMultiplayerManager != null)
		{
			_playFabMultiplayerManager.LeaveNetworkImpl(true);
			bool flag = _hostJoinedHandler == null;
			_hostingSession = false;
			_currentTimeout = 0f;
			if (!flag)
			{
				if ((object)_playFabMultiplayerManager == null)
				{
					goto IL_01bf;
				}
				_playFabMultiplayerManager.OnNetworkJoined -= _hostJoinedHandler;
			}
			if (_errorHandler != null)
			{
				if ((object)_playFabMultiplayerManager == null)
				{
					goto IL_01bf;
				}
				_playFabMultiplayerManager.OnError -= _errorHandler;
			}
			if (_playerJoinedHandler != null)
			{
				if ((object)_playFabMultiplayerManager == null)
				{
					goto IL_01bf;
				}
				_playFabMultiplayerManager.OnRemotePlayerJoined -= _playerJoinedHandler;
			}
			PlayFabMultiplayerManager.OnErrorEventHandler value = OnJoinNetworkError;
			if ((object)_playFabMultiplayerManager != null)
			{
				_playFabMultiplayerManager.OnError -= value;
				PlayFabMultiplayerManager.OnNetworkJoinedHandler value2 = OnNetworkJoined;
				if ((object)_playFabMultiplayerManager != null)
				{
					_playFabMultiplayerManager.OnNetworkJoined -= value2;
					return Task._003CCompletedTask_003Ek__BackingField;
				}
			}
		}
		goto IL_01bf;
		IL_01bf:
		return (Task)(object)new NullReferenceException();
	}

	public void Update()
	{
		//IL_0075: Invalid comparison between I4 and F4
		//IL_004e: Invalid comparison between I4 and F4
		if (!_hostingSession)
		{
			return;
		}
		IList<PlayFabPlayer> remotePlayers = _playFabMultiplayerManager.RemotePlayers;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if ((nint)obj > 0)
		{
			if (!(0f < _currentTimeout))
			{
				OnP2PSessionReadyInvoke();
				return;
			}
		}
		else if (!(0f < _currentTimeout))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4219]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_playFabMultiplayerManager.OnNetworkJoined -= _hostJoinedHandler;
			_playFabMultiplayerManager.OnError -= _errorHandler;
			_playFabMultiplayerManager.OnRemotePlayerJoined -= _playerJoinedHandler;
			Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
			_hostingSession = false;
			if (_003COnP2PSessionError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ rax_v11 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
		object obj2 = default(object);
		float currentTimeout = _currentTimeout - (float)obj2;
		_currentTimeout = currentTimeout;
	}

	private void OnP2PHostSessionFailInvoke()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4219]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_playFabMultiplayerManager.OnNetworkJoined -= _hostJoinedHandler;
		_playFabMultiplayerManager.OnError -= _errorHandler;
		_playFabMultiplayerManager.OnRemotePlayerJoined -= _playerJoinedHandler;
		Action<string> action = _003COnP2PSessionError_003Ek__BackingField;
		_hostingSession = false;
		if (_003COnP2PSessionError_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v92 @ rax_v7 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnP2PSessionReadyInvoke()
	{
		_playFabMultiplayerManager.OnNetworkJoined -= _hostJoinedHandler;
		_playFabMultiplayerManager.OnError -= _errorHandler;
		_playFabMultiplayerManager.OnRemotePlayerJoined -= _playerJoinedHandler;
		Action action = _003COnP2PSessionReady_003Ek__BackingField;
		_hostingSession = false;
		if (_003COnP2PSessionReady_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v68.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void OnLoggedIn(PlayFab.ClientModels.LoginResult obj)
	{
		string log = "Successful PlayFab Login: " + obj.PlayFabId;
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info(log, args);
		PlayFabMultiplayerManager playFabMultiplayerManager = _playFabMultiplayerManager;
		_003CIsReady_003Ek__BackingField = true;
		PlayFabLocalPlayer localPlayer = playFabMultiplayerManager._localPlayer;
		((PlayFabPlayer)localPlayer)._isMuted = true;
	}

	private void LoginWithPlayFab()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CLoginWithPlayFab_003Ed__50 stateMachine = default(_003CLoginWithPlayFab_003Ed__50);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}
}
