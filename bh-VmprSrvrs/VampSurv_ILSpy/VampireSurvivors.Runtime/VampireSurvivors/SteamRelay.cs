using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Connection;
using Coherence.Toolkit.Relay;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace VampireSurvivors;

public class SteamRelay : IRelay
{
	private Action<ConnectionException> m_OnError;

	private readonly Dictionary<Connection, SteamRelayConnection> _connectionMap;

	private SteamSocketManager _steamSocketManager;

	private CoherenceRelayManager _003CRelayManager_003Ek__BackingField;

	public CoherenceRelayManager RelayManager
	{
		get
		{
			return _003CRelayManager_003Ek__BackingField;
		}
		set
		{
			_003CRelayManager_003Ek__BackingField = value;
		}
	}

	public event Action<ConnectionException> OnError
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 16;
			Delegate obj2 = this.m_OnError;
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
			Delegate obj2 = this.m_OnError;
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

	public SteamRelay(SteamSocketManager socketManager)
	{
		Dictionary<Connection, SteamRelayConnection> connectionMap = null;
		EqualityComparer<Connection> equalityComparer = EqualityComparer<Connection>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		_connectionMap = connectionMap;
		_steamSocketManager = socketManager;
	}

	public void Open()
	{
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0013: Expected O, but got I4
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_00f6: Expected O, but got I4
		CreateRelayConnections();
		SteamSocketManager steamSocketManager = _steamSocketManager;
		Action<Connection, ConnectionInfo> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6AD0");
		Delegate obj = steamSocketManager.OnPeerDisconnected;
		object obj2 = steamSocketManager + 24;
		object obj5 = default(object);
		object obj12 = default(object);
		while (true)
		{
			Delegate obj3 = Delegate.Combine(obj, b);
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
			bool flag2 = obj == obj2;
			Delegate obj6;
			if (obj == obj2)
			{
				obj2 = obj4;
				obj6 = obj;
			}
			else
			{
				obj6 = (Delegate)obj2;
			}
			Delegate obj7 = obj;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 != obj;
			obj = obj7;
			if (flag3)
			{
				continue;
			}
			SteamSocketManager steamSocketManager2 = _steamSocketManager;
			Action<Connection, IntPtr, int> b2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6BB0");
			Delegate obj8 = steamSocketManager2.OnMessageReceived;
			object obj9 = steamSocketManager2 + 32;
			while (true)
			{
				Delegate obj10 = Delegate.Combine(obj8, b2);
				object obj11;
				if ((object)obj10 == null)
				{
					obj11 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag4 = obj12 == null;
					obj11 = obj12;
					if (flag4)
					{
						break;
					}
				}
				bool flag5 = obj8 == obj9;
				Delegate obj13;
				if (obj8 == obj9)
				{
					obj9 = obj11;
					obj13 = obj8;
				}
				else
				{
					obj13 = (Delegate)obj9;
				}
				Delegate obj14 = obj8;
				if (!flag5)
				{
					obj14 = obj13;
				}
				bool flag6 = (object)obj14 != obj8;
				obj8 = obj14;
				if (!flag6)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public void Update()
	{
		SteamSocketManager steamSocketManager = _steamSocketManager;
		if (SteamServer.IsValid)
		{
			int num = steamSocketManager._steamSocketManager.Receive();
			SteamServer.RunCallbacks();
			return;
		}
		Exception ex = new Exception("SteamServer is not valid");
		ex._002Ector("SteamServer is not valid");
		throw ex;
	}

	public void Close()
	{
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0031: Expected O, but got I4
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_0114: Expected O, but got I4
		if (_steamSocketManager == null)
		{
			return;
		}
		SteamSocketManager steamSocketManager = _steamSocketManager;
		Action<Connection, ConnectionInfo> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6AD0");
		Delegate obj = steamSocketManager.OnPeerDisconnected;
		object obj2 = steamSocketManager + 24;
		object obj5 = default(object);
		object obj12 = default(object);
		while (true)
		{
			Delegate obj3 = Delegate.Remove(obj, value);
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
			bool flag2 = obj == obj2;
			Delegate obj6;
			if (obj == obj2)
			{
				obj2 = obj4;
				obj6 = obj;
			}
			else
			{
				obj6 = (Delegate)obj2;
			}
			Delegate obj7 = obj;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 != obj;
			obj = obj7;
			if (flag3)
			{
				continue;
			}
			SteamSocketManager steamSocketManager2 = _steamSocketManager;
			Action<Connection, IntPtr, int> value2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6BB0");
			Delegate obj8 = steamSocketManager2.OnMessageReceived;
			object obj9 = steamSocketManager2 + 32;
			while (true)
			{
				Delegate obj10 = Delegate.Remove(obj8, value2);
				object obj11;
				if ((object)obj10 == null)
				{
					obj11 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag4 = obj12 == null;
					obj11 = obj12;
					if (flag4)
					{
						break;
					}
				}
				bool flag5 = obj8 == obj9;
				Delegate obj13;
				if (obj8 == obj9)
				{
					obj9 = obj11;
					obj13 = obj8;
				}
				else
				{
					obj13 = (Delegate)obj9;
				}
				Delegate obj14 = obj8;
				if (!flag5)
				{
					obj14 = obj13;
				}
				bool flag6 = (object)obj14 != obj8;
				obj8 = obj14;
				if (!flag6)
				{
					_steamSocketManager.Close();
					_steamSocketManager = null;
					return;
				}
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void CreateRelayConnections()
	{
		//IL_005e: Expected O, but got I4
		//IL_00e9: Expected O, but got I4
		//IL_0135: Expected O, but got I4
		SteamSocketManager steamSocketManager = _steamSocketManager;
		SocketManager steamSocketManager2 = steamSocketManager._steamSocketManager;
		HashSet<Connection>.Enumerator enumerator = default(HashSet<Connection>.Enumerator);
		Connection connection = default(Connection);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Steamworks.ISteamNetworkingSockets steamNetworkingSockets = SteamNetworkingSockets.Internal;
				bool flag = steamNetworkingSockets == null;
				CoherenceRelayManager coherenceRelayManager = null;
				if (!flag)
				{
					bool connectionName = steamNetworkingSockets.GetConnectionName((Connection)0, out string pszName);
					bool flag2 = !connectionName;
					string text = "ERROR";
					if (!flag2)
					{
						text = pszName;
					}
					string message = "SteamRelay Opening Steam Relay Connection for " + text;
					Debug.Log(message);
					SteamRelayConnection steamRelayConnection = null;
					Queue<ArraySegment<byte>> messagesFromSteamToServer = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A963C0");
					steamRelayConnection.messagesFromSteamToServer = messagesFromSteamToServer;
					string connectionName2 = connection.ConnectionName;
					string message2 = "SteamRelayConnection opening relayed client for Steam user #" + connectionName2;
					Debug.Log(message2);
					steamRelayConnection.steamConnection = (Connection)0;
					if (_003CRelayManager_003Ek__BackingField == null)
					{
						break;
					}
					_003CRelayManager_003Ek__BackingField.OpenRelayConnection(steamRelayConnection);
					bool flag3 = ((Dictionary<Connection, object>)(object)_connectionMap).TryInsert((Connection)0, (object)steamRelayConnection, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					continue;
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void OnDisconnected(Connection steamConnection, ConnectionInfo info)
	{
		//IL_00d9: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		ConnectionState connectionState = default(ConnectionState);
		object arg = connectionState;
		System.ParamsArray paramsArray = new System.ParamsArray("SteamRelay", arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string message = string.FormatHelper((IFormatProvider)null, "{0} OnDisconnected: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.Log(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6C90");
		object obj = default(object);
		if (obj != null)
		{
			IRelayConnection connection = default(IRelayConnection);
			_003CRelayManager_003Ek__BackingField.CloseAndRemoveRelayConnection(connection);
			bool flag = ((Dictionary<Connection, object>)(object)_connectionMap).Remove(steamConnection);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		paramsArray = new System.ParamsArray("SteamRelay", arg2);
		string message2 = string.FormatHelper((IFormatProvider)null, "{0} Failed to find client for connection with Id: {1}", (System.ParamsArray)(&paramsArray2));
		Debug.LogError(message2);
	}

	public unsafe void OnMessage(Connection steamConnection, IntPtr data, int size)
	{
		//IL_00c6: Expected O, but got Ref
		int num = size + -4;
		byte[] array = new byte[num];
		nint source = (nint)data + 4;
		Marshal.Copy(source, array, 0, num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6C90");
		object obj = default(object);
		if (obj != null)
		{
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A964B0");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.array);
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray("SteamRelay", arg);
			byte[] array2 = default(byte[]);
			string message = string.FormatHelper((IFormatProvider)null, "{0} Failed to find client for connection with Id: {1}", (System.ParamsArray)(&array2));
			Debug.LogError(message);
		}
	}
}
