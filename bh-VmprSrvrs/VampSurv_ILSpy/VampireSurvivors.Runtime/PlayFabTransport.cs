using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Coherence.Brook;
using Coherence.Brook.Octet;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;
using Cpp2ILInjected;
using PlayFab.Party;

public class PlayFabTransport : ITransport
{
	private Action m_OnOpen;

	private Action<ConnectionException> m_OnError;

	private TransportState _003CState_003Ek__BackingField;

	private readonly int _003CHeaderSize_003Ek__BackingField;

	private PlayFabMultiplayerManager _playFabMultiplayerManager;

	private List<PlayFabPlayer> host;

	private string hostId;

	private Logger _logger;

	private IStats _stats;

	private bool isClosing;

	private readonly Queue<byte[]> incomingPackets;

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

	public int HeaderSize => _003CHeaderSize_003Ek__BackingField;

	public string Description
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1B8]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "PlayFab";
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

	public PlayFabTransport(Logger logger, IStats stats, string host, PlayFabMultiplayerManager manager)
	{
		Queue<byte[]> queue = new Queue<byte[]>();
		incomingPackets = queue;
		PlayFabMultiplayerManager playFabMultiplayerManager = default(PlayFabMultiplayerManager);
		_playFabMultiplayerManager = playFabMultiplayerManager;
		hostId = host;
		_stats = stats;
		_logger = logger;
	}

	public unsafe void Open(EndpointData _, ConnectionSettings __)
	{
		//IL_001c: Expected O, but got Ref
		//IL_0101: Expected O, but got Ref
		//IL_016e: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_01bf: Expected O, but got Ref
		//IL_01eb: Expected I, but got O
		//IL_01fb: Expected O, but got I
		//IL_0277: Expected O, but got Ref
		//IL_0306: Expected O, but got I
		//IL_0340: Expected I8, but got I
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected Ref, but got Unknown
		//IL_043a: Expected I8, but got I
		//IL_0463: Expected O, but got I4
		//IL_046c: Expected O, but got I4
		Logger logger = _logger;
		(string, object)[] array = new(string, object)[4];
		TransportState transportState = default(TransportState);
		object item = transportState;
		(string, object) tuple = ("State", item);
		bool flag = array == null;
		(string, object) tuple2 = ((string, object))(&tuple);
		if (!flag)
		{
			(string, object) tuple3 = ("HostId", hostId);
			bool flag2 = (object)_playFabMultiplayerManager == null;
			tuple2 = ((string, object))_playFabMultiplayerManager;
			if (!flag2)
			{
				IList<PlayFabPlayer> remotePlayers = _playFabMultiplayerManager.RemotePlayers;
				bool flag3 = remotePlayers == null;
				tuple2 = ((string, object))_playFabMultiplayerManager;
				if (!flag3)
				{
					System.Runtime.CompilerServices.Unsafe.Write(null, (ValueTuple<string, object>)((string)(object)typeof(ICollection<PlayFabPlayer>), remotePlayers));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object item2 = default(object);
					(string, object) tuple4 = ("RemotePlayers", item2);
					tuple2 = ((string, object))(&tuple4);
					PlayFabMultiplayerManager playFabMultiplayerManager = _playFabMultiplayerManager;
					if ((object)_playFabMultiplayerManager != null)
					{
						tuple2 = ((string, object))playFabMultiplayerManager._localPlayer;
						if (playFabMultiplayerManager._localPlayer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14 (System.ValueTuple`2<System.String, System.Object>)+50]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14 (System.ValueTuple`2<System.String, System.Object>)+50]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v17+10]");
								(string, object) tuple5 = ("My Id", 0);
								tuple2 = ((string, object))(&tuple5);
								if (_logger != null)
								{
									nint num = (nint)logger;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1000 @ r9_v14 (Il2CppClass<Coherence.Log.Logger>)+1F0]");
									object obj2 = 0;
									_logger.Info("Trying to open PlayFab Transport", array);
									_003CState_003Ek__BackingField = TransportState.Opening;
									if ((object)_playFabMultiplayerManager != null)
									{
										IList<PlayFabPlayer> remotePlayers2 = _playFabMultiplayerManager.RemotePlayers;
										if (remotePlayers2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
											object obj4 = default(object);
											object obj3 = (object)(&obj4);
											List<PlayFabPlayer> list = null;
											object obj5 = default(object);
											object obj6 = default(object);
											while (true)
											{
												if (obj4 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
													if (obj5 != null)
													{
														bool flag4 = obj4 == null;
														list = null;
														if (!flag4)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A967C0");
															bool flag5 = obj6 == null;
															list = null;
															if (!flag5)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v53+50]");
																object obj7 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v53+50]");
																bool flag6 = (nint)0 == 0;
																list = null;
																if (!flag6)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v34+10]");
																	ulong num2 = 0uL;
																	string text = hostId;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v34+10]");
																	bool flag7 = (nint)0 == 0;
																	list = null;
																	if (!flag7)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v34+10]");
																		bool flag8 = 0 == (nint)hostId;
																		object obj8 = obj2;
																		if (!flag8)
																		{
																			bool flag9 = hostId == null;
																			list = null;
																			if (flag9)
																			{
																				continue;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v36 (System.UInt64)+10]");
																			bool flag10 = (nint)0 != text._stringLength;
																			list = null;
																			if (flag10)
																			{
																				continue;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v34+10]");
																			ref byte first = ref *(byte*)((nint)0 + (nint)20);
																			ref byte second = ref *(byte*)(hostId + 20);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v36 (System.UInt64)+10]");
																			nint num3 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v36 (System.UInt64)+10]");
																			num2 = (ulong)(num3 + 0);
																			bool flag11 = System.SpanHelpers.SequenceEqual(ref first, ref second, num2);
																			bool flag12 = !flag11;
																			obj8 = 0;
																			obj2 = 0;
																			if (flag12)
																			{
																				continue;
																			}
																		}
																		List<PlayFabPlayer> list2 = new List<PlayFabPlayer>();
																		if (list2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B56C0");
																			host = list2;
																			OpenNetwork();
																			if (obj3 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
																			}
																			break;
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													if (obj3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
													}
													break;
												}
												throw new NullReferenceException();
											}
											PlayFabMultiplayerManager.OnRemotePlayerLeftHandler value = OnRemotePlayerLeft;
											_playFabMultiplayerManager.OnRemotePlayerLeft += value;
											PlayFabMultiplayerManager.OnDataMessageReceivedNoCopyHandler value2 = OnDataMessageNoCopyReceived;
											_playFabMultiplayerManager.OnDataMessageNoCopyReceived += value2;
											PlayFabMultiplayerManager.OnErrorEventHandler value3 = OnPlayFabError;
											_playFabMultiplayerManager.OnError += value3;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void GameCoreOnResuming()
	{
		//IL_000d: Expected I, but got O
		Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		nint num = (nint)logger;
		logger.Error("PlayFab does not support Xbox GameCore resuming from suspend. Closing connection.", args);
		Action<ConnectionException> onError = this.m_OnError;
		if (this.m_OnError != null)
		{
			ConnectionException ex = (ConnectionException)new Exception("PlayFab does not support Xbox GameCore resuming from suspend. Closing connection.");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ rbx_v2 (System.Action`1<Coherence.Connection.ConnectionException>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
		//IL_00b4: Expected I, but got O
		if (host != null)
		{
			List<PlayFabPlayer> list = host;
			if (list._size != 1)
			{
				return;
			}
			if (list._size <= 0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			PlayFabPlayer[] items = list._items;
			if (player != items[0])
			{
				return;
			}
		}
		Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		nint num = (nint)logger;
		logger.Error("Host has left the game. Disconnecting", args);
		Action<ConnectionException> onError = this.m_OnError;
		if (this.m_OnError != null)
		{
			ConnectionException ex = new ConnectionException("Host has left the game. Disconnecting");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v128 @ rdi_v8 (System.Action`1<Coherence.Connection.ConnectionException>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OpenNetwork()
	{
		//IL_00b2: Expected I4, but got O
		//IL_003c: Expected I, but got O
		Logger logger = _logger;
		(string, object)[] args = new(string, object)[2];
		object obj = default(object);
		object item = (TransportState)(int)obj;
		(string, object) tuple = ("State", item);
		_ = 0;
		(string, object) tuple2 = ("HostId", hostId);
		_ = 0;
		nint num = (nint)logger;
		logger.Info("Opening PlayFab Transport", args);
		Action onOpen = this.m_OnOpen;
		_003CState_003Ek__BackingField = TransportState.Open;
		if (this.m_OnOpen != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v343.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void OnPlayFabError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
		//IL_0034: Expected I, but got O
		Logger logger = _logger;
		(string, object)[] args2 = new(string, object)[1];
		(string, object) tuple = ("Message", args._003CMessage_003Ek__BackingField);
		_ = 0;
		nint num = (nint)logger;
		logger.Error("PlayFab Error", args2);
		if (!isClosing)
		{
			Action<ConnectionException> onError = this.m_OnError;
			if (this.m_OnError != null)
			{
				ConnectionException ex = new ConnectionException(args._003CMessage_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v268 @ rsi_v4 (System.Action`1<Coherence.Connection.ConnectionException>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint buffersize)
	{
		int num = default(int);
		byte[] array = new byte[num];
		Marshal.Copy(buffer, array, 0, num);
		((Queue<object>)(object)incomingPackets).Enqueue((object)array);
	}

	public void Close()
	{
		_003CState_003Ek__BackingField = TransportState.Closed;
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Leaving PlayFab network", args);
		_playFabMultiplayerManager.LeaveNetworkImpl(true);
		PlayFabMultiplayerManager.OnRemotePlayerLeftHandler value = OnRemotePlayerLeft;
		_playFabMultiplayerManager.OnRemotePlayerLeft -= value;
		PlayFabMultiplayerManager.OnDataMessageReceivedNoCopyHandler value2 = OnDataMessageNoCopyReceived;
		_playFabMultiplayerManager.OnDataMessageNoCopyReceived -= value2;
		PlayFabMultiplayerManager.OnErrorEventHandler value3 = OnPlayFabError;
		_playFabMultiplayerManager.OnError -= value3;
	}

	public void Send(IOutOctetStream data)
	{
		bool flag = !isClosing;
		bool deliveryOption = !flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
		ArraySegment<byte> arraySegment = default(ArraySegment<byte>);
		byte[] buffer = arraySegment.ToArray();
		if (_playFabMultiplayerManager._SendDataMessage(buffer, (IEnumerable<PlayFabPlayer>)host, deliveryOption ? DeliveryOption.Guaranteed : DeliveryOption.BestEffort))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
		}
		else
		{
			(string, object)[] args = Array.Empty<(string, object)>();
			_logger.Error("PlayFabTransport failed to send PlayFab Party packet.", args);
		}
	}

	public unsafe void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
	{
		//IL_0039: Expected O, but got Ref
		//IL_0074: Expected I4, but got I8
		Queue<byte[]> queue = incomingPackets;
		InOctetStream inOctetStream2 = default(InOctetStream);
		while (queue._size > 0)
		{
			object data = ((Queue<object>)(object)incomingPackets).Dequeue();
			InOctetStream inOctetStream = new InOctetStream((byte[])data);
			buffer.Add(((IInOctetStream, IPEndPoint))(&inOctetStream2));
			long length = inOctetStream.stream.Length;
			long position = inOctetStream.stream.Position;
			uint octetCount = (uint)(length - position);
			_stats.TrackIncomingPacket(octetCount);
			queue = incomingPackets;
			inOctetStream2 = inOctetStream;
		}
	}

	public void PrepareDisconnect()
	{
		isClosing = true;
	}
}
