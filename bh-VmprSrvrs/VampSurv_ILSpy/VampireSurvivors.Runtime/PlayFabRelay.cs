using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit.Relay;
using Cpp2ILInjected;
using PartyCSharpSDK;
using PlayFab.ClientModels;
using PlayFab.Party;
using UnityEngine;

public class PlayFabRelay : IRelay
{
	private Action<ConnectionException> m_OnError;

	private PlayFabMultiplayerManager _playFabMultiplayerManager;

	private Dictionary<PlayFabPlayer, PlayFabRelayConnection> _connectionMap;

	private PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS _connectivityOptions;

	private Coherence.Log.Logger _logger;

	private string _caughtError;

	private bool _errorOccurred;

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

	public PlayFabRelay(PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS connectivityOptions)
	{
		Dictionary<PlayFabPlayer, PlayFabRelayConnection> connectionMap = new Dictionary<PlayFabPlayer, PlayFabRelayConnection>();
		_connectionMap = connectionMap;
		Coherence.Log.Logger logger = Log.GetLogger<PlayFabRelay>();
		_logger = logger;
		_connectivityOptions = connectivityOptions;
	}

	public unsafe void Open()
	{
		//IL_005a: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0107: Expected O, but got I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_01a5: Expected O, but got Ref
		//IL_0293: Expected O, but got I4
		//IL_0238: Expected O, but got I
		//IL_0241: Expected O, but got I4
		//IL_0314: Expected O, but got I
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
		_playFabMultiplayerManager = playFabMultiplayerManager;
		PlayFabMultiplayerManager playFabMultiplayerManager2 = _playFabMultiplayerManager;
		if ((object)_playFabMultiplayerManager != null)
		{
			object obj = playFabMultiplayerManager2._playFabMultiplayerManagerState - 2;
			object obj2 = playFabMultiplayerManager2._playFabMultiplayerManagerState ^ PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.Initialized;
			object obj3 = playFabMultiplayerManager2._playFabMultiplayerManagerState ^ obj;
			object obj4 = obj2 & obj3;
			bool flag = (nint)obj4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = playFabMultiplayerManager2._playFabMultiplayerManagerState == PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.Initialized;
			if (playFabMultiplayerManager2._playFabMultiplayerManagerState >= PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.Initialized && !flag3)
			{
				bool flag4 = flag2 == flag;
				object obj5 = !flag4;
				object obj6 = obj5 | flag3;
				if ((obj6 != null || playFabMultiplayerManager2._playFabMultiplayerManagerState >= PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.ConnectedToNetwork) && playFabMultiplayerManager2._playFabMultiplayerManagerState >= PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.ConnectedToNetwork)
				{
					IList<PlayFabPlayer> remotePlayers = _playFabMultiplayerManager.RemotePlayers;
					if (remotePlayers != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj8 = default(object);
						object obj7 = (object)(&obj8);
						Dictionary<object, object> dictionary = null;
						object obj9 = default(object);
						object obj19 = default(object);
						PlayFabPlayer playFabPlayer = default(PlayFabPlayer);
						while (true)
						{
							object obj18;
							object obj11;
							if (obj8 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj9 == null)
								{
									break;
								}
								bool flag5 = obj8 == null;
								dictionary = null;
								if (!flag5)
								{
									object obj10 = obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r10_v9+12E]");
									if ((nint)0 >= (nint)0)
									{
										goto IL_0278;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r10_v9+B0]");
									obj11 = 0;
									object obj12 = 0;
									while (true)
									{
										object obj13 = obj12 + obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ r8_v20+v665 @ rax_v48*8]");
										if (0 == (nint)typeof(IEnumerator<PlayFabPlayer>))
										{
											break;
										}
										obj12++;
										object obj14 = obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r10_v9+12E]");
										if ((nint)obj14 < 0)
										{
											continue;
										}
										goto IL_0278;
									}
									object obj15 = obj12 + obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ r8_v20+8+v723 @ rcx_v39*8]");
									object obj16 = (nint)0 << 4;
									object obj17 = obj16 + 312;
									obj18 = obj17 + obj10;
									goto IL_04da;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
							IL_0278:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
							obj18 = obj19;
							obj11 = 0;
							goto IL_04da;
							IL_04da:
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v728 @ rdx_v22] (should have been resolved before IL gen)");
							PlayFabRelayConnection playFabRelayConnection = new PlayFabRelayConnection(playFabPlayer, _playFabMultiplayerManager);
							if (_connectionMap != null)
							{
								bool flag6 = ((Dictionary<object, object>)(object)_connectionMap).TryInsert((object)playFabPlayer, (object)playFabRelayConnection, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								if (_003CRelayManager_003Ek__BackingField != null)
								{
									_003CRelayManager_003Ek__BackingField.OpenRelayConnection(playFabRelayConnection);
									dictionary = (Dictionary<object, object>)(object)_003CRelayManager_003Ek__BackingField;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						if (obj7 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						PlayFabMultiplayerManager.OnRemotePlayerLeftHandler value = OnRemotePlayerLeft;
						if ((object)_playFabMultiplayerManager != null)
						{
							_playFabMultiplayerManager.OnRemotePlayerLeft += value;
							PlayFabMultiplayerManager.OnDataMessageReceivedNoCopyHandler value2 = OnDataMessageNoCopyReceived;
							if ((object)_playFabMultiplayerManager != null)
							{
								_playFabMultiplayerManager.OnDataMessageNoCopyReceived += value2;
								PlayFabMultiplayerManager.OnErrorEventHandler value3 = OnNetworkError;
								if ((object)_playFabMultiplayerManager != null)
								{
									_playFabMultiplayerManager.OnError += value3;
									return;
								}
							}
						}
					}
					goto IL_0444;
				}
			}
			(string, object)[] args = Array.Empty<(string, object)>();
			if (_logger != null)
			{
				_logger.Error("Must be connected to a PlayFab Network to open relay.", args);
				return;
			}
		}
		goto IL_0444;
		IL_0444:
		throw new NullReferenceException();
	}

	private void GameCoreOnResuming()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F1AA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string caughtError = _caughtError;
		if (_caughtError == null || caughtError._stringLength <= 0)
		{
			_caughtError = "PlayFab does not support Xbox GameCore resuming from suspend. Closing connection.";
		}
	}

	private unsafe void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint buffersize)
	{
		//IL_0090: Expected O, but got Ref
		//IL_0090: Expected O, but got I
		int num = default(int);
		byte[] array = new byte[num];
		Marshal.Copy(buffer, array, 0, num);
		if (((Dictionary<object, object>)(object)_connectionMap).TryGetValue((object)from, out object value))
		{
			if (array == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.array);
				throw new IndexOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_8_v6 (System.Object)+20]");
			byte[] array2 = default(byte[]);
			bool flag = ((Dictionary<PlayFabPlayer, PlayFabRelayConnection>)0).TryGetValue((PlayFabPlayer)(&array2), out *(PlayFabRelayConnection*)(&value));
		}
		else
		{
			(string, object)[] args = new(string, object)[1];
			EntityKey entityKey = from._003CEntityKey_003Ek__BackingField;
			(string, object) tuple = ("Connection Id", entityKey.Id);
			_ = 0;
			_logger.Error("PlayFabRelay Failed to find client for connection.", args);
		}
	}

	private unsafe void OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
		//IL_00de: Expected O, but got Ref
		if (((Dictionary<object, object>)(object)_connectionMap).TryGetValue((object)player, out object value))
		{
			_003CRelayManager_003Ek__BackingField.CloseAndRemoveRelayConnection((IRelayConnection)value);
			bool flag = ((Dictionary<object, object>)(object)_connectionMap).Remove((object)player);
			return;
		}
		(string, object)[] args = new(string, object)[1];
		EntityKey entityKey = player._003CEntityKey_003Ek__BackingField;
		(string, object) tuple = ("Connection Id", entityKey.Id);
		_ = 0;
		_logger.Error("Missing Relay Connection", args);
		System.ParamsArray paramsArray = new System.ParamsArray(player._003CEntityKey_003Ek__BackingField);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Missing relay connection for {0}", (System.ParamsArray)(&obj));
		Debug.LogError(message);
	}

	public void Close()
	{
		//IL_012a: Expected O, but got I
		//IL_013a: Expected O, but got I
		PlayFabMultiplayerManager.OnRemotePlayerLeftHandler value = OnRemotePlayerLeft;
		_playFabMultiplayerManager.OnRemotePlayerLeft -= value;
		PlayFabMultiplayerManager.OnDataMessageReceivedNoCopyHandler value2 = OnDataMessageNoCopyReceived;
		_playFabMultiplayerManager.OnDataMessageNoCopyReceived -= value2;
		PlayFabMultiplayerManager.OnErrorEventHandler value3 = OnNetworkError;
		_playFabMultiplayerManager.OnError -= value3;
		(string, object)[] args = new(string, object)[1];
		PlayFabMultiplayerManager playFabMultiplayerManager = _playFabMultiplayerManager;
		PlayFabLocalPlayer localPlayer = playFabMultiplayerManager._localPlayer;
		object item;
		if (playFabMultiplayerManager._localPlayer != null)
		{
			EntityKey entityKey = ((PlayFabPlayer)localPlayer)._003CEntityKey_003Ek__BackingField;
			if (((PlayFabPlayer)localPlayer)._003CEntityKey_003Ek__BackingField != null)
			{
				item = entityKey.Id;
				if (entityKey.Id != null)
				{
					goto IL_0192;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v32+B8]");
		object obj2 = 0;
		item = obj2;
		goto IL_0192;
		IL_0192:
		(string, object) tuple = ("My Id", item);
		_ = 0;
		_logger.Info("Leaving PlayFab Network", args);
		_playFabMultiplayerManager.LeaveNetworkImpl(true);
	}

	public void Update()
	{
	}

	public void Flush()
	{
		//IL_0077: Expected I, but got O
		string caughtError = _caughtError;
		if (_caughtError != null && caughtError._stringLength > 0 && !_errorOccurred)
		{
			Coherence.Log.Logger logger = _logger;
			_errorOccurred = true;
			(string, object)[] args = Array.Empty<(string, object)>();
			nint num = (nint)logger;
			logger.Error(_caughtError, args);
			Action<ConnectionException> onError = this.m_OnError;
			if (this.m_OnError != null)
			{
				ConnectionException ex = new ConnectionException(_caughtError);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ rsi_v3 (System.Action`1<Coherence.Connection.ConnectionException>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnNetworkError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
		string caughtError = _caughtError;
		if (_caughtError == null || caughtError._stringLength <= 0)
		{
			_caughtError = args._003CMessage_003Ek__BackingField;
		}
	}

	private void ProcessError(string error)
	{
		string caughtError = _caughtError;
		if (_caughtError == null || caughtError._stringLength <= 0)
		{
			_caughtError = error;
		}
	}
}
