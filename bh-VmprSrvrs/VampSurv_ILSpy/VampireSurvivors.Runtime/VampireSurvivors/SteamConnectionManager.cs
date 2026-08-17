using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace VampireSurvivors;

public class SteamConnectionManager : IConnectionManager
{
	private Action<ConnectionInfo> m_OnHostDisconnected;

	private Action<IntPtr, int> m_OnMessageReceived;

	private Action<string> m_P2PActivationFailed;

	private bool _isConnectionReady;

	private SteamId _hostSteamId;

	private ConnectionManager _steamRelayConnection;

	public Connection Connection
	{
		get
		{
			ConnectionManager steamRelayConnection = _steamRelayConnection;
			if (_steamRelayConnection != null)
			{
				return steamRelayConnection.Connection;
			}
			return (Connection)new NullReferenceException();
		}
	}

	public event Action<ConnectionInfo> OnHostDisconnected
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 16;
			Delegate obj2 = this.m_OnHostDisconnected;
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
			object obj = this + 16;
			Delegate obj2 = this.m_OnHostDisconnected;
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

	public event Action<IntPtr, int> OnMessageReceived
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 24;
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
			object obj = this + 24;
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

	public event Action<string> P2PActivationFailed
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 32;
			Delegate obj2 = this.m_P2PActivationFailed;
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
			Delegate obj2 = this.m_P2PActivationFailed;
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

	public SteamConnectionManager(SteamId hostSteamId)
	{
		_hostSteamId = hostSteamId;
	}

	public unsafe void Open()
	{
		//IL_00b3: Expected O, but got Ref
		//IL_0031: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray("SteamConnectionManager", arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string text = string.FormatHelper((IFormatProvider)null, "{0} opening outgoing Steam connection Host Steam Id: {1}. ", (System.ParamsArray)(&paramsArray2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		paramsArray2 = new System.ParamsArray(arg2);
		System.ParamsArray paramsArray3 = default(System.ParamsArray);
		string text2 = string.FormatHelper((IFormatProvider)null, "Host Account Id: {0}", (System.ParamsArray)(&paramsArray3));
		string message = text + text2;
		Debug.Log(message);
		ConnectionManager steamRelayConnection = SteamNetworkingSockets.ConnectRelay(_hostSteamId, 0, this);
		_steamRelayConnection = steamRelayConnection;
	}

	public unsafe void Close()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4240]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_steamRelayConnection != null)
		{
			Connection connection = (Connection)(_steamRelayConnection + 24);
			bool flag = ((Connection*)connection)->Close(linger: true);
		}
	}

	public void Receive()
	{
		int num = _steamRelayConnection.Receive();
	}

	public unsafe void OnConnecting(ConnectionInfo info)
	{
		//IL_001d: Expected I4, but got O
		//IL_0042: Expected O, but got Ref
		object obj = default(object);
		object arg = (ConnectionState)obj;
		System.ParamsArray paramsArray = new System.ParamsArray("SteamConnectionManager", arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "{0} OnConnecting: {1}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
	}

	public unsafe void OnConnected(ConnectionInfo info)
	{
		//IL_0028: Expected I4, but got O
		//IL_004d: Expected O, but got Ref
		object obj = default(object);
		object arg = (ConnectionState)obj;
		System.ParamsArray paramsArray = new System.ParamsArray("SteamConnectionManager", arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "{0} OnConnected: {1}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		_isConnectionReady = true;
	}

	public unsafe void OnDisconnected(ConnectionInfo info)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0065: Expected O, but got Ref
		//IL_0078: Expected I4, but got O
		//IL_0119: Expected O, but got Ref
		//IL_009d: Expected O, but got Ref
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_0315: Expected O, but got I4
		//IL_0156: Expected O, but got I
		//IL_016b: Expected O, but got I
		//IL_0180: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+70]");
		_ = 0;
		NetIdentity netIdentity = default(NetIdentity);
		SteamId steamId = netIdentity.SteamId;
		SteamId steamId2 = SteamClient.SteamId;
		if ((object)steamId == (object)steamId2 && !_isConnectionReady)
		{
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 568));
			_ = info.state;
			object arg = (ConnectionState)obj3;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj4 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Failed to connect to host using Steam Relay: {0}", (System.ParamsArray)(&obj4));
			Debug.LogError(message);
			Action<string> p2PActivationFailed = this.m_P2PActivationFailed;
			if (this.m_P2PActivationFailed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ r9_v5 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [info @ rdx (Steamworks.Data.ConnectionInfo)+70]");
		_ = 0;
		SteamId steamId3 = netIdentity.SteamId;
		if ((object)steamId3 != (object)_hostSteamId)
		{
			return;
		}
		Action<ConnectionInfo> onHostDisconnected = this.m_OnHostDisconnected;
		bool flag = this.m_OnHostDisconnected == null;
		if (!flag)
		{
			SteamConnectionManager steamConnectionManager = (SteamConnectionManager)(&netIdentity);
			ConnectionInfo connectionInfo = info;
			steamConnectionManager = this;
			ConnectionInfo connectionInfo2 = default(ConnectionInfo);
			connectionInfo = connectionInfo2;
			object obj5;
			do
			{
				steamConnectionManager = (SteamConnectionManager)(steamConnectionManager + 128);
				connectionInfo = (ConnectionInfo)(connectionInfo + 128);
				_ = connectionInfo.identity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)-10]");
				_ = 0;
				obj5 = !flag;
			}
			while (obj5 != null);
			steamConnectionManager = (SteamConnectionManager)connectionInfo.identity;
			SteamConnectionManager steamConnectionManager2 = steamConnectionManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)+10]");
			steamConnectionManager2.m_OnHostDisconnected = (Action<ConnectionInfo>)0;
			SteamConnectionManager steamConnectionManager3 = steamConnectionManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)+20]");
			steamConnectionManager3.m_P2PActivationFailed = (Action<string>)0;
			SteamConnectionManager steamConnectionManager4 = steamConnectionManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v4 (Steamworks.Data.ConnectionInfo)+30]");
			steamConnectionManager4._hostSteamId = (SteamId)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ r9_v3 (System.Action`1<Steamworks.Data.ConnectionInfo>)+18] (should have been resolved before IL gen)");
		}
	}

	public void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
	{
		Action<IntPtr, int> onMessageReceived = this.m_OnMessageReceived;
		if (this.m_OnMessageReceived != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`2<System.IntPtr, System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}
}
