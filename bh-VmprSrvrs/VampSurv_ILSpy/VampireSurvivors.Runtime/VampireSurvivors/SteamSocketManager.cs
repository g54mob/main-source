using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace VampireSurvivors;

public class SteamSocketManager : ISocketManager
{
	private Action m_OnSessionReady;

	private Action<Connection, ConnectionInfo> m_OnPeerDisconnected;

	private Action<Connection, IntPtr, int> m_OnMessageReceived;

	private SocketManager _steamSocketManager;

	private int _expectedPeers;

	private bool _isGameReady;

	public HashSet<Connection> Connected
	{
		get
		{
			if (_steamSocketManager != null)
			{
				SocketManager steamSocketManager = _steamSocketManager;
				return steamSocketManager.Connected;
			}
			return null;
		}
	}

	public event Action OnSessionReady
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_OnSessionReady;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
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
			Delegate obj2 = this.m_OnSessionReady;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
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

	public event Action<Connection, ConnectionInfo> OnPeerDisconnected
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 24;
			Delegate obj2 = this.m_OnPeerDisconnected;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 24;
			Delegate obj2 = this.m_OnPeerDisconnected;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event Action<Connection, IntPtr, int> OnMessageReceived
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 32;
			Delegate obj2 = this.m_OnMessageReceived;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 32;
			Delegate obj2 = this.m_OnMessageReceived;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public unsafe SteamSocketManager(int expectedPeers)
	{
		//IL_0044: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Created SteamSocketManager. Expected Peers: {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		_expectedPeers = expectedPeers;
	}

	public unsafe string Open()
	{
		//IL_0044: Expected O, but got I4
		//IL_0054: Expected I4, but got O
		//IL_005d: Expected O, but got I4
		//IL_01be: Expected O, but got Ref
		//IL_00a8: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_0160: Expected I4, but got O
		//IL_0184: Expected O, but got I
		//IL_0194: Expected O, but got I
		string productName = Application.productName;
		string productName2 = Application.productName;
		SteamServerInit steamServerInit = new SteamServerInit(productName, productName2);
		bool isValid = SteamServer.IsValid;
		SteamServerInit steamServerInit2 = (SteamServerInit)0;
		string text = productName;
		bool flag = (byte)(int)productName2 != 0;
		object obj = 0;
		if (!isValid)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182DA9150");
			steamServerInit2 = steamServerInit;
			AppId appid = default(AppId);
			SteamServerInit steamServerInit3 = default(SteamServerInit);
			SteamServer.Init(appid, (SteamServerInit)(&steamServerInit3), asyncCallbacks: false);
			Debug.Log("SteamSocketManager initialized");
			text = null;
			flag = false;
			obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2800");
		Steamworks.ISteamNetworkingSockets steamNetworkingSockets = SteamNetworkingSockets.Internal;
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899822B0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899822B0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			object obj4 = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v393 @ rax_v19 (should have been resolved before IL gen)");
			SocketManager socketManager = new SocketManager();
			Socket socket = default(Socket);
			socketManager._003CSocket_003Ek__BackingField = socket;
			socketManager._003CInterface_003Ek__BackingField = this;
			socketManager.Initialize();
			SteamNetworkingSockets.SetSocketManager((uint)(int)socketManager._003CSocket_003Ek__BackingField, socketManager);
			_steamSocketManager = socketManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v28+B8]");
			return (string)0;
		}
		return (string)(object)new NullReferenceException();
	}

	public void Update()
	{
		if (SteamServer.IsValid)
		{
			int num = _steamSocketManager.Receive();
			SteamServer.RunCallbacks();
			return;
		}
		Exception ex = new Exception("SteamServer is not valid");
		throw ex;
	}

	public unsafe void Close()
	{
		//IL_0050: Expected O, but got I
		//IL_0073: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_0098: Expected O, but got Ref
		//IL_00ff: Expected O, but got I
		if (SteamServer.IsValid)
		{
			Dispatch.ShutdownServer();
			SteamServer.ShutdownInterfaces();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981048]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981048]");
			bool flag = (nint)0 != 0;
			object obj2 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
				object obj3 = default(object);
				obj2 = (object)(&obj3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v445 @ rax_v39 (should have been resolved before IL gen)");
		}
		if (_steamSocketManager == null)
		{
			return;
		}
		SocketManager steamSocketManager = _steamSocketManager;
		Steamworks.ISteamNetworkingSockets steamNetworkingSockets = SteamNetworkingSockets.Internal;
		if (steamNetworkingSockets.Self != (IntPtr)0)
		{
			Steamworks.ISteamNetworkingSockets steamNetworkingSockets2 = SteamNetworkingSockets.Internal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982378]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982378]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v504 @ rax_v22 (should have been resolved before IL gen)");
			Socket socket = default(Socket);
			bool flag2 = socket.Close();
		}
		steamSocketManager._003CSocket_003Ek__BackingField = (Socket)0;
		_steamSocketManager = null;
	}

	public unsafe void OnConnecting(Connection connection, ConnectionInfo info)
	{
		//IL_0014: Expected O, but got Ref
		ConnectionState connectionState = default(ConnectionState);
		object arg = connectionState;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray("SteamSocketManager", arg, arg2);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "{0} OnConnecting: {1} ID: {2}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		Connection connection2 = default(Connection);
		Result result = connection2.Accept();
	}

	public unsafe void OnConnected(Connection connection, ConnectionInfo info)
	{
		//IL_00da: Expected I4, but got O
		//IL_00ff: Expected O, but got Ref
		object obj = default(object);
		object arg = (ConnectionState)obj;
		System.ParamsArray paramsArray = new System.ParamsArray("SteamSocketManager", arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "{0} OnConnected: {1}.", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		SocketManager steamSocketManager = _steamSocketManager;
		HashSet<Connection> connected = steamSocketManager.Connected;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v9 (System.Collections.Generic.HashSet`1<Steamworks.Data.Connection>)+20]");
		if ((nint)0 == _expectedPeers && !_isGameReady)
		{
			Debug.Log("SteamSocketManager All expected peers have connected. Game is ready.");
			Action onSessionReady = this.m_OnSessionReady;
			_isGameReady = true;
			if (this.m_OnSessionReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v152.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void OnDisconnected(Connection connection, ConnectionInfo info)
	{
		//IL_0030: Expected O, but got Ref
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0123: Expected O, but got I4
		bool flag = this.m_OnPeerDisconnected == null;
		if (!flag)
		{
			nint num = 5;
			object obj2 = default(object);
			object obj = (object)(&obj2);
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			obj = obj3;
			ConnectionInfo connectionInfo = default(ConnectionInfo);
			object obj4;
			do
			{
				obj += 128;
				connectionInfo = (ConnectionInfo)(connectionInfo + 128);
				_ = connectionInfo.identity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)-10]");
				_ = 0;
				num--;
				obj4 = !flag;
			}
			while (obj4 != null);
			obj = connectionInfo.identity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ r8_v2 (Steamworks.Data.ConnectionInfo)+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2740");
		}
	}

	public void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel)
	{
		Action<Connection, IntPtr, int> onMessageReceived = this.m_OnMessageReceived;
		if (this.m_OnMessageReceived != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ r10_v1 (System.Action`3<Steamworks.Data.Connection, System.IntPtr, System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}
}
