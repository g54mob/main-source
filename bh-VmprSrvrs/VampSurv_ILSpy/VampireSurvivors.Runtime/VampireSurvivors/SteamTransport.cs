using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using Coherence.Brook;
using Coherence.Brook.Octet;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;

namespace VampireSurvivors;

public class SteamTransport : ITransport
{
	internal const int HeaderSizeBytes = 4;

	private Action m_OnOpen;

	private Action<ConnectionException> m_OnError;

	private TransportState _003CState_003Ek__BackingField;

	private readonly IStats _stats;

	private readonly Logger _logger;

	private readonly SteamConnectionManager _steamConnectionManager;

	private readonly Queue<byte[]> _incomingPackets;

	private bool _isClosing;

	public TransportState State
	{
		get
		{
			return _003CState_003Ek__BackingField;
		}
		private set
		{
			_003CState_003Ek__BackingField = value;
		}
	}

	public bool IsReliable => false;

	public bool CanSend => true;

	public int HeaderSize => 4;

	public string Description
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A426D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Steam";
		}
	}

	public event Action OnOpen
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_OnOpen;
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
			Delegate obj2 = this.m_OnOpen;
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

	public event Action<ConnectionException> OnError
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 24;
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
			object obj = this + 24;
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

	public SteamTransport(IStats stats, Logger logger, SteamConnectionManager steamConnectionManager)
	{
		//IL_004c: Expected O, but got I
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I
		//IL_038a: Expected O, but got I4
		//IL_0393: Expected O, but got I4
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_00ac: Expected O, but got I8
		//IL_00e1: Expected O, but got I4
		//IL_01df: Expected O, but got I
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0261: Expected O, but got I
		//IL_023f: Expected O, but got I8
		//IL_028d: Expected I, but got O
		Queue<byte[]> incomingPackets = new Queue<byte[]>();
		_incomingPackets = incomingPackets;
		_stats = stats;
		_logger = logger;
		_steamConnectionManager = steamConnectionManager;
		SteamConnectionManager steamConnectionManager2 = _steamConnectionManager;
		Action<ConnectionInfo> b = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6451077536L;
				goto IL_0381;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v9 (System.Action`1<Steamworks.Data.ConnectionInfo>)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v9 (System.Action`1<Steamworks.Data.ConnectionInfo>)+10]");
		obj3 = 0;
		goto IL_0381;
		IL_0381:
		object obj4 = 24;
		object obj5 = 24;
		_ = 6451077296L;
		Delegate obj6 = steamConnectionManager2.OnHostDisconnected;
		object obj7 = steamConnectionManager2 + 16;
		object obj10 = default(object);
		Action<IntPtr, int> action = default(Action<IntPtr, int>);
		while (true)
		{
			Delegate obj8 = Delegate.Combine(obj6, b);
			object obj9;
			if ((object)obj8 == null)
			{
				obj9 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = obj10 == null;
				obj9 = obj10;
				if (flag)
				{
					break;
				}
			}
			bool flag2 = obj6 == obj7;
			Delegate obj11;
			if (obj6 == obj7)
			{
				obj7 = obj9;
				obj11 = obj6;
			}
			else
			{
				obj11 = (Delegate)obj7;
			}
			Delegate obj12 = obj6;
			if (!flag2)
			{
				obj12 = obj11;
			}
			bool flag3 = (object)obj12 != obj6;
			obj6 = obj12;
			if (flag3)
			{
				continue;
			}
			SteamConnectionManager steamConnectionManager3 = _steamConnectionManager;
			Action<IntPtr, int> b2 = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ r9_v5 (Il2CppMethodInfo)+8]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ r9_v5 (Il2CppMethodInfo)+4C]");
			object obj13 = (nint)0 >> 4;
			object obj14 = obj13 & 1;
			object obj15;
			if (obj14 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ r9_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 2)
				{
					obj15 = 6447765184L;
					goto IL_0415;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rax_v28 (System.Action`2<System.IntPtr, System.Int32>)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rax_v28 (System.Action`2<System.IntPtr, System.Int32>)+10]");
			obj15 = 0;
			goto IL_0415;
			IL_0415:
			_ = 6447765056L;
			Delegate obj16 = steamConnectionManager3.OnMessageReceived;
			while (true)
			{
				Delegate obj17 = Delegate.Combine(obj16, b2);
				Action<IntPtr, int> onMessageReceived;
				if ((object)obj17 == null)
				{
					onMessageReceived = null;
				}
				else
				{
					((SteamTransport)(object)obj17).OnMessage((IntPtr)typeof(Action<IntPtr, int>), 0);
					bool flag4 = action == null;
					onMessageReceived = action;
					if (flag4)
					{
						break;
					}
				}
				bool flag5 = (object)obj16 == steamConnectionManager3.OnMessageReceived;
				Delegate obj18;
				if ((object)obj16 == steamConnectionManager3.OnMessageReceived)
				{
					steamConnectionManager3.OnMessageReceived = onMessageReceived;
					obj18 = obj16;
				}
				else
				{
					obj18 = steamConnectionManager3.OnMessageReceived;
				}
				Delegate obj19 = obj16;
				if (!flag5)
				{
					obj19 = obj18;
				}
				bool flag6 = (object)obj19 != obj16;
				obj16 = obj19;
				if (!flag6)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public void Open(EndpointData _, ConnectionSettings __)
	{
		Action onOpen = this.m_OnOpen;
		_003CState_003Ek__BackingField = TransportState.Open;
		if (this.m_OnOpen != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void PrepareDisconnect()
	{
		_isClosing = true;
	}

	public unsafe void Close()
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		SteamConnectionManager steamConnectionManager = _steamConnectionManager;
		_003CState_003Ek__BackingField = TransportState.Closed;
		if (_steamConnectionManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4240]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (steamConnectionManager._steamRelayConnection != null)
			{
				Connection connection = (Connection)(steamConnectionManager._steamRelayConnection + 24);
				bool flag = ((Connection*)connection)->Close(linger: true);
			}
		}
	}

	public unsafe void Send(IOutOctetStream stream)
	{
		//IL_00f5: Expected O, but got I4
		//IL_0204: Expected I, but got O
		//IL_021d: Expected I4, but got O
		//IL_010d: Expected I4, but got O
		//IL_00be: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0137: Expected O, but got Ref
		//IL_0151: Expected I, but got O
		//IL_017b: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		bool flag = _isClosing;
		SendType sendType = (SendType)9;
		if (!flag)
		{
			sendType = SendType.NoNagle;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
		object obj = default(object);
		System.ParamsArray paramsArray = (System.ParamsArray)obj;
		object obj6;
		if (obj != null)
		{
			object obj2 = (object)paramsArray._args ^ (object)paramsArray._args;
			object obj3 = (object)paramsArray._args & obj2;
			bool flag2 = (nint)obj3 < 0;
			bool flag3 = (nint)paramsArray._args < 0;
			bool flag4 = paramsArray._args == null;
			if (!flag4)
			{
				bool flag5 = flag3 == flag2;
				object obj4 = !flag5;
				object obj5 = obj4 | flag4;
				if (obj5 == null)
				{
					obj6 = obj + 32;
					goto IL_01e3;
				}
				throw new IndexOutOfRangeException();
			}
		}
		obj6 = 0;
		goto IL_01e3;
		IL_01e3:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		nint ptr = (nint)((object)paramsArray + obj6);
		Connection connection = default(Connection);
		ushort laneIndex = default(ushort);
		Result result = connection.SendMessage(ptr, (int)paramsArray, sendType, laneIndex);
		bool flag6 = result == Result.OK;
		System.ParamsArray paramsArray2 = paramsArray;
		SendType sendType2 = sendType;
		if (!flag6)
		{
			Logger logger = _logger;
			object arg = (Result)connection;
			System.ParamsArray paramsArray3 = new System.ParamsArray("SteamTransport", arg);
			object obj7 = default(object);
			string log = string.FormatHelper((IFormatProvider)null, "{0} failed to send Steam packet to the host with result: {1}", (System.ParamsArray)(&obj7));
			(string, object)[] args = Array.Empty<(string, object)>();
			nint num = (nint)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r10_v4 (Il2CppClass<Coherence.Log.Logger>)+230]");
			sendType2 = SendType.Unreliable;
			logger.Error(log, args);
			paramsArray2 = (System.ParamsArray)0;
			paramsArray = (System.ParamsArray)0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
	}

	public unsafe void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
	{
		//IL_0153: Expected O, but got I
		//IL_0163: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_0096: Expected O, but got Ref
		//IL_00d1: Expected I4, but got I8
		InOctetStream inOctetStream2 = default(InOctetStream);
		while (true)
		{
			if (SteamClient.initialized)
			{
				SteamConnectionManager steamConnectionManager = _steamConnectionManager;
				int num = steamConnectionManager._steamRelayConnection.Receive();
				Queue<byte[]> incomingPackets = _incomingPackets;
				while (incomingPackets._size > 0)
				{
					object data = ((Queue<object>)(object)_incomingPackets).Dequeue();
					InOctetStream inOctetStream = new InOctetStream((byte[])data);
					buffer.Add(((IInOctetStream, IPEndPoint))(&inOctetStream2));
					long length = inOctetStream.stream.Length;
					long position = inOctetStream.stream.Position;
					uint octetCount = (uint)(length - position);
					_stats.TrackIncomingPacket(octetCount);
					incomingPackets = _incomingPackets;
					inOctetStream2 = inOctetStream;
				}
				break;
			}
			Action<ConnectionException> onError = this.m_OnError;
			if (this.m_OnError != null)
			{
				ConnectionException ex = new ConnectionException("SteamClient is not valid");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v3 (System.Action`1<Coherence.Connection.ConnectionException>)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v3 (System.Action`1<Coherence.Connection.ConnectionException>)+40]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v3 (System.Action`1<Coherence.Connection.ConnectionException>)+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v327 @ rax_v9 (should have been resolved before IL gen)");
				continue;
			}
			break;
		}
	}

	private void OnHostDisconnected(ConnectionInfo info)
	{
		Action<ConnectionException> onError = this.m_OnError;
		if (this.m_OnError != null)
		{
			ConnectionDeniedException ex = (ConnectionDeniedException)new ConnectionException("Host has left the game. Disconnecting", null);
			ex._003CCloseReason_003Ek__BackingField = ConnectionCloseReason.Unknown;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v32 @ rdi_v2 (System.Action`1<Coherence.Connection.ConnectionException>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnMessage(IntPtr data, int size)
	{
		byte[] array = new byte[size];
		Marshal.Copy(data, array, 0, size);
		((Queue<object>)(object)_incomingPackets).Enqueue((object)array);
	}
}
