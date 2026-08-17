using System;
using System.Collections.Generic;
using Coherence.Toolkit.Relay;
using Cpp2ILInjected;
using PlayFab.Party;

public class PlayFabRelayConnection : IRelayConnection
{
	private IEnumerable<PlayFabPlayer> player;

	private PlayFabMultiplayerManager manager;

	private readonly Queue<ArraySegment<byte>> messagesFromPlayFabToServer;

	public PlayFabRelayConnection(PlayFabPlayer player, PlayFabMultiplayerManager manager)
	{
		Queue<ArraySegment<byte>> queue = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A963C0");
		messagesFromPlayFabToServer = queue;
		List<PlayFabPlayer> list = new List<PlayFabPlayer>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B56C0");
		this.player = list;
		PlayFabMultiplayerManager playFabMultiplayerManager = default(PlayFabMultiplayerManager);
		this.manager = playFabMultiplayerManager;
	}

	public void OnConnectionOpened()
	{
	}

	public void OnConnectionClosed()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96440");
	}

	public unsafe void ReceiveMessagesFromClient(List<ArraySegment<byte>> packetBuffer)
	{
		//IL_0019: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_038a: Expected O, but got I4
		//IL_038a: Expected O, but got I
		//IL_0397: Expected O, but got I
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
		Queue<ArraySegment<byte>> queue = messagesFromPlayFabToServer;
		bool flag = messagesFromPlayFabToServer == null;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		PlayFabRelayConnection playFabRelayConnection = this;
		if (!flag)
		{
			playFabRelayConnection = this;
			object obj7 = default(object);
			ArraySegment<byte> item = default(ArraySegment<byte>);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10 (System.Collections.Generic.Queue`1<System.ArraySegment`1<System.Byte>>)+20]");
				if ((nint)0 <= (nint)0)
				{
					return;
				}
				num = (nint)messagesFromPlayFabToServer;
				if (messagesFromPlayFabToServer == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+20]");
				bool flag2 = (nint)0 == 0;
				playFabRelayConnection = (PlayFabRelayConnection)0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
					playFabRelayConnection = (PlayFabRelayConnection)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
					if (0 < (nint)playFabRelayConnection.manager)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
						object obj = (nint)0 + (nint)2;
						object obj2 = obj + obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
						if (0 < (nint)playFabRelayConnection.manager)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
							object obj3 = (nint)0 + (nint)2;
							object obj4 = obj3 + obj3;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
							playFabRelayConnection = (PlayFabRelayConnection)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+18]");
							object obj5 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v2 (Il2CppMethodInfo)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							bool flag3 = obj5 == playFabRelayConnection.manager;
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
							playFabRelayConnection = (PlayFabRelayConnection)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+10]");
							bool flag4 = (nint)0 == 0;
							num = 0;
							if (flag4)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
							if (0 >= (nint)playFabRelayConnection.manager)
							{
								packetBuffer.AddWithResize((ArraySegment<byte>)(&obj7));
								num = 0;
								playFabRelayConnection = (PlayFabRelayConnection)(object)packetBuffer;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								object obj8 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								bool flag5 = 0 >= (nint)playFabRelayConnection.manager;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								num = 0;
								if (flag5)
								{
									goto IL_0398;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								object obj9 = (nint)0 + (nint)2;
								object obj10 = obj9 + obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v3 (PlayFabRelayConnection)+v200 @ rax_v12*8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [packetBuffer @ rdx (System.Collections.Generic.List`1<System.ArraySegment`1<System.Byte>>)+18]");
								num = 0;
							}
							queue = messagesFromPlayFabToServer;
							if (messagesFromPlayFabToServer == null)
							{
								break;
							}
							continue;
						}
					}
					goto IL_0398;
				}
				Queue<ArraySegment<byte>> queue2 = playFabRelayConnection.messagesFromPlayFabToServer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v4 (System.Collections.Generic.Queue`1<System.ArraySegment`1<System.Byte>>)+C0]");
				((List<ArraySegment<byte>>)0).Add((ArraySegment<byte>)13);
				((List<ArraySegment<byte>>)num).Add(item);
				return;
				IL_0398:
				throw new IndexOutOfRangeException();
			}
		}
		throw new NullReferenceException();
	}

	public void SendMessageToClient(ReadOnlySpan<byte> packetData)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497C60");
		byte[] buffer = default(byte[]);
		bool flag = manager._SendDataMessage(buffer, player, DeliveryOption.BestEffort);
	}

	public void EnqueueMessageFromPlayFab(ArraySegment<byte> packet)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A964B0");
	}
}
