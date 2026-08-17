using System;
using System.Collections.Generic;
using Coherence.Toolkit.Relay;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace VampireSurvivors;

public class SteamRelayConnection : IRelayConnection
{
	private Connection steamConnection;

	private readonly Queue<ArraySegment<byte>> messagesFromSteamToServer;

	public SteamRelayConnection(Connection steamConnection)
	{
		Queue<ArraySegment<byte>> queue = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A963C0");
		messagesFromSteamToServer = queue;
		Connection connection = default(Connection);
		string connectionName = connection.ConnectionName;
		string message = "SteamRelayConnection opening relayed client for Steam user #" + connectionName;
		Debug.Log(message);
		this.steamConnection = steamConnection;
	}

	public void OnConnectionOpened()
	{
	}

	public unsafe void OnConnectionClosed()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		Connection connection = (Connection)(this + 16);
		string connectionName = ((Connection*)connection)->ConnectionName;
		string message = "SteamRelayConnection closing relayed client for Steam user #" + connectionName;
		Debug.Log(message);
		Connection connection2 = (Connection)(this + 16);
		bool flag = ((Connection*)connection2)->Close();
		bool flag2 = false;
		if (!flag)
		{
			Debug.LogError("SteamRelayConnection failed to close Steam relay connection");
			flag2 = false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96440");
	}

	public void EnqueueMessageFromSteam(ArraySegment<byte> packetData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A964B0");
	}

	public unsafe void ReceiveMessagesFromClient(List<ArraySegment<byte>> packetBuffer)
	{
		//IL_0019: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_038d: Expected O, but got I4
		//IL_038d: Expected O, but got I
		//IL_039a: Expected O, but got I
		//IL_0073: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_0129: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_0167: Expected O, but got I
		//IL_01a8: Expected O, but got I4
		//IL_01e6: Expected O, but got I
		//IL_0270: Expected O, but got I
		//IL_0247: Expected O, but got Ref
		//IL_02c7: Expected O, but got I
		Queue<ArraySegment<byte>> queue = messagesFromSteamToServer;
		bool flag = messagesFromSteamToServer == null;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		SteamRelayConnection steamRelayConnection = this;
		if (!flag)
		{
			steamRelayConnection = this;
			object obj7 = default(object);
			ArraySegment<byte> item = default(ArraySegment<byte>);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10 (System.Collections.Generic.Queue`1<System.ArraySegment`1<System.Byte>>)+20]");
				if ((nint)0 <= (nint)0)
				{
					return;
				}
				num = (nint)messagesFromSteamToServer;
				if (messagesFromSteamToServer == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+20]");
				bool flag2 = (nint)0 == 0;
				steamRelayConnection = (SteamRelayConnection)0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
					steamRelayConnection = (SteamRelayConnection)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
					if (0 < (nint)steamRelayConnection.messagesFromSteamToServer)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
						object obj = (nint)0 + (nint)2;
						object obj2 = obj + obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
						if (0 < (nint)steamRelayConnection.messagesFromSteamToServer)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
							object obj3 = (nint)0 + (nint)2;
							object obj4 = obj3 + obj3;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
							steamRelayConnection = (SteamRelayConnection)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
							object obj5 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							bool flag3 = obj5 == steamRelayConnection.messagesFromSteamToServer;
							object obj6 = 0;
							if (!flag3)
							{
								obj6 = obj5;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+20]");
							_ = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+24]");
							_ = (nint)0 + (nint)1;
							if (packetBuffer == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+10]");
							steamRelayConnection = (SteamRelayConnection)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+10]");
							bool flag4 = (nint)0 == 0;
							num = 0;
							if (flag4)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
							if (0 >= (nint)steamRelayConnection.messagesFromSteamToServer)
							{
								packetBuffer.AddWithResize((ArraySegment<byte>)(&obj7));
								num = 0;
								steamRelayConnection = (SteamRelayConnection)(object)packetBuffer;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								object obj8 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								bool flag5 = 0 >= (nint)steamRelayConnection.messagesFromSteamToServer;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								num = 0;
								if (flag5)
								{
									goto IL_039b;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								object obj9 = (nint)0 + (nint)2;
								object obj10 = obj9 + obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v3 (VampireSurvivors.SteamRelayConnection)+v200 @ rax_v12*8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								num = 0;
							}
							queue = messagesFromSteamToServer;
							if (messagesFromSteamToServer == null)
							{
								break;
							}
							continue;
						}
					}
					goto IL_039b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v3 (VampireSurvivors.SteamRelayConnection)+20]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v4+C0]");
				((List<ArraySegment<byte>>)0).Add((ArraySegment<byte>)13);
				((List<ArraySegment<byte>>)num).Add(item);
				return;
				IL_039b:
				throw new IndexOutOfRangeException();
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SendMessageToClient(ReadOnlySpan<byte> packetData)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_0044: Expected O, but got I
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_011a: Expected I4, but got O
		//IL_00bd: Expected O, but got I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0148: Expected O, but got Ref
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected I, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497C60");
		object obj = default(object);
		if (obj == null)
		{
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.array);
			goto IL_01a1;
		}
		nint num2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
			object obj2 = num ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
			object obj3 = 0 & obj2;
			bool flag = (nint)obj3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
			bool flag3 = (nint)0 == 0;
			if (!flag3)
			{
				bool flag4 = flag2 == flag;
				object obj4 = !flag4;
				object obj5 = obj4 | flag3;
				if (obj5 != null)
				{
					goto IL_01a1;
				}
				num2 = (nint)(obj + 32);
				goto IL_01a8;
			}
		}
		num2 = 0;
		goto IL_01a8;
		IL_01a8:
		Connection connection = (Connection)(this + 16);
		nint ptr = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2+18]");
		ushort laneIndex = default(ushort);
		Result result = ((Connection*)connection)->SendMessage(ptr, 0, SendType.NoNagle, laneIndex);
		if (result != Result.OK)
		{
			Connection connection2 = (Connection)(this + 16);
			string connectionName = ((Connection*)connection2)->ConnectionName;
			object obj6 = default(object);
			object arg = (Result)obj6;
			System.ParamsArray paramsArray = new System.ParamsArray("SteamRelayConnection", connectionName, arg);
			object obj7 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "{0} sending message to {1} failed with result: {2}", (System.ParamsArray)(&obj7));
			Debug.LogError(message);
		}
		return;
		IL_01a1:
		throw new IndexOutOfRangeException();
	}
}
