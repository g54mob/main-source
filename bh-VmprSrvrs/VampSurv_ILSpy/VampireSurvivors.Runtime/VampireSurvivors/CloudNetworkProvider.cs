using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Entities;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Transport;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace VampireSurvivors;

public class CloudNetworkProvider : INetworkProvider
{
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public CloudNetworkProvider _003C_003E4__this;

		public Action<bool, string, Dictionary<string, string>> onGameReady;

		internal unsafe void _003CPrepareGame_003Eb__0(RequestResponse<RoomData> req)
		{
			//IL_0016: Expected O, but got Ref
			object obj = default(object);
			_003C_003E4__this.OnCreatedRoom((RequestResponse<RoomData>)(&obj), onGameReady);
		}
	}

	private bool _003CIsReady_003Ek__BackingField;

	private string _003CInitializationError_003Ek__BackingField;

	private Action _003COnJoinError_003Ek__BackingField;

	private Action _003COnP2PSessionReady_003Ek__BackingField;

	private Action<string> _003COnP2PSessionError_003Ek__BackingField;

	private IRoomsService _roomsService;

	private Logger _logger;

	private RoomData? _roomData;

	public NetworkProviders Provider => NetworkProviders.Coherence;

	public NetworkType NetworkType => NetworkType.Cloud;

	public bool UsesRsl => false;

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
			//IL_0095: Expected I4, but got O
			CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
			if ((object)CoherenceBridgeStore.masterBridge != null)
			{
				CoherenceClientConnectionManager coherenceClientConnectionManager = masterBridge._003CClientConnections_003Ek__BackingField;
				if (masterBridge._003CClientConnections_003Ek__BackingField != null)
				{
					Dictionary<Entity, CoherenceClientConnection> connectionsByEntityId = coherenceClientConnectionManager.connectionsByEntityId;
					if (coherenceClientConnectionManager.connectionsByEntityId != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.Dictionary`2<Coherence.Entities.Entity, Coherence.Toolkit.CoherenceClientConnection>)+20]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.Dictionary`2<Coherence.Entities.Entity, Coherence.Toolkit.CoherenceClientConnection>)+28]");
						return (int)(num - 0);
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public CloudNetworkProvider(Logger logger)
	{
		_003CIsReady_003Ek__BackingField = true;
		_logger = logger;
	}

	public void JoinP2P(LobbySession lobbySession)
	{
	}

	public unsafe bool JoinGame(LobbySession lobbySession)
	{
		//IL_019a: Expected I4, but got O
		//IL_000d: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		//IL_0093: Expected O, but got I
		//IL_01c4: Expected O, but got Ref
		//IL_0140: Expected I, but got O
		//IL_00fb: Expected O, but got Ref
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
			LobbyData lobbyData = default(LobbyData);
			CloudAttribute? attribute = lobbyData.GetAttribute((string)(&obj2));
			if (attribute != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
				string stringValue = ((CloudAttribute*)(&lobbyData))->GetStringValue();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA13A0");
				object obj4 = default(object);
				JoinRoom((RoomData)(&obj4));
				return true;
			}
			Logger logger = _logger;
			(string, object)[] args = Array.Empty<(string, object)>();
			if (_logger != null)
			{
				nint num = (nint)logger;
				_logger.Error("Room Data is missing. Cannot join game.", args);
				Action action = _003COnJoinError_003Ek__BackingField;
				if (_003COnJoinError_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v265.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
	{
		//IL_004c: Expected O, but got Ref
		//IL_00c1: Expected O, but got I
		//IL_012a: Expected O, but got I4
		_003C_003Ec__DisplayClass34_0 obj = new _003C_003Ec__DisplayClass34_0();
		obj._003C_003E4__this = this;
		obj.onGameReady = onGameReady;
		PlayerAccount main = PlayerAccount.main;
		CloudService services = main.services;
		object obj3 = default(object);
		object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 128));
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
		obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbySession @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		string region = default(string);
		CloudRoomsService roomServiceForRegion = services._003CRooms_003Ek__BackingField.GetRoomServiceForRegion(region);
		_roomsService = roomServiceForRegion;
		_roomData = (RoomData?)(object)0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Action<RequestResponse<RoomData>> onRequestFinished = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807BC320");
		RoomCreationOptions roomCreationOptions = new RoomCreationOptions();
		roomCreationOptions.FindOrCreate = false;
		roomCreationOptions.MaxClients = 4;
		_roomsService.CreateRoom(onRequestFinished, roomCreationOptions);
	}

	public unsafe void HostGame()
	{
		//IL_0078: Expected O, but got Ref
		//IL_0025: Expected I, but got O
		if (_roomData == null)
		{
			Logger logger = _logger;
			(string, object)[] args = Array.Empty<(string, object)>();
			nint num = (nint)logger;
			logger.Error("Trying to host game without preparing first.", args);
			Action action = _003COnJoinError_003Ek__BackingField;
			if (_003COnJoinError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v121.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			if (_roomData == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new NullReferenceException();
			}
		}
		object obj = default(object);
		JoinRoom((RoomData)(&obj));
	}

	public void Update()
	{
	}

	private unsafe void OnCreatedRoom(RequestResponse<RoomData> request, Action<bool, string, Dictionary<string, string>> onGameReady)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0237: Expected O, but got I
		//IL_01a9: Expected I, but got O
		//IL_0286: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_017a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+50]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+60]");
		_ = 0;
		if ((object)request != null)
		{
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
			_roomData = (RoomData?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+50]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [request @ rdx (Coherence.Cloud.RequestResponse`1<Coherence.Cloud.RoomData>)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
			_ = 0;
			object obj3 = default(object);
			object value = (RoomData)obj3;
			string value2 = JsonConvert.SerializeObject(value);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)LobbyAttributeKeys.RoomData, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Action<bool, string, Dictionary<string, string>> action = default(Action<bool, string, Dictionary<string, string>>);
			if (action != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v25+B8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v116 @ r8_v4 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			Logger logger = _logger;
			(string, object)[] args = Array.Empty<(string, object)>();
			nint num = (nint)logger;
			logger.Error("Failed to create room.", args);
			Action action2 = _003COnJoinError_003Ek__BackingField;
			if (_003COnJoinError_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v258.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private unsafe static void JoinRoom(RoomData room)
	{
		//IL_0041: Expected O, but got Ref
		CoherenceBridgeStore.masterBridge.SetRelay(null);
		CoherenceBridgeStore.masterBridge.SetTransportType(TransportType.UDPWithTCPFallback, TransportConfiguration.Default);
		object obj = default(object);
		CoherenceBridgeStore.masterBridge.JoinRoom((RoomData)(&obj));
	}

	public Task ShutDown()
	{
		return Task._003CCompletedTask_003Ek__BackingField;
	}
}
