using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class AutoPlayManager : NetworkAggroManagerBase<AutoPlayManager>
{
	[Min(0f)]
	public float delayLobby = 5f;

	[Min(0f)]
	public float delayBreakRoom = 5f;

	[Min(0f)]
	public float delayOrganization = 5f;

	[Min(0f)]
	public float completeBaysSecondsRemaining = 5f;

	[Min(0f)]
	public float forceFailedSendEvery = 10f;

	private Timer _lobbyTimer;

	private Timer _serverTimer;

	[SyncVar]
	private bool _syncAutoPlaying;

	private int _contractIndex;

	private bool _lobbyRequested;

	private bool _breakRoomRequested;

	private bool _organizationRequested;

	private List<OutboundBay> _bays = new List<OutboundBay>();

	private List<GrabbableHolder> _holders = new List<GrabbableHolder>();

	private List<OutboundBay.Order> _orders = new List<OutboundBay.Order>();

	private List<NetworkConnectionToClient> _connections = new List<NetworkConnectionToClient>();

	private List<Entity> _grabbables = new List<Entity>();

	public bool autoPlaying => _syncAutoPlaying;

	public bool Network_syncAutoPlaying
	{
		get
		{
			return _syncAutoPlaying;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncAutoPlaying, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (!Debug.isDebugBuild)
		{
			base.enabled = false;
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!_syncAutoPlaying || !base.isServer)
		{
			return;
		}
		Unity.Mathematics.Random random = MathUtil.GetRandom(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		if (GameUtil.isLobby)
		{
			_lobbyTimer.DecrementTimer();
			if (_lobbyTimer.IsFinished() && !_lobbyRequested)
			{
				_lobbyRequested = true;
				_breakRoomRequested = false;
				_serverTimer.SetTimer(delayBreakRoom);
				NetworkAggroManagerBase<LobbyManager>.instance.ServerStartContract(_contractIndex++);
			}
		}
		else
		{
			if (!GameUtil.isRun)
			{
				return;
			}
			_lobbyTimer.SetTimer(delayLobby);
			_serverTimer.DecrementTimer();
			switch (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase())
			{
			case ShiftPhase.BreakRoom:
				if (_serverTimer.IsFinished() && !_breakRoomRequested)
				{
					_breakRoomRequested = true;
					_organizationRequested = false;
					_serverTimer.SetTimer(delayOrganization);
					NetworkAggroManagerBase<ShiftManager>.instance.ServerForceShiftForward();
				}
				break;
			case ShiftPhase.Organizational:
				if (_serverTimer.IsFinished() && !_organizationRequested)
				{
					_organizationRequested = true;
					_breakRoomRequested = false;
					_lobbyRequested = false;
					_serverTimer.SetTimer(forceFailedSendEvery);
					NetworkAggroManagerBase<ShiftManager>.instance.ServerForceShiftForward();
				}
				break;
			case ShiftPhase.Shift:
			{
				_bays.Clear();
				base.entityManager.GetAllObjects(_bays);
				for (int i = 0; i < _bays.Count; i++)
				{
					OutboundBay outboundBay = _bays[i];
					if (outboundBay.state != OutboundBay.BayState.Outbound || !(outboundBay.serverSecondsRemaining <= completeBaysSecondsRemaining))
					{
						continue;
					}
					_orders.Clear();
					outboundBay.GetOutboundOrder(_orders);
					_grabbables.Clear();
					base.entityManager.GetAllEntitiesWith<Grabbable>(_grabbables);
					List<Entity> list = new List<Entity>();
					HashSet<Entity> hashSet = new HashSet<Entity>();
					bool flag = false;
					foreach (OutboundBay.Order order3 in _orders)
					{
						if (!NetworkAggroManagerBase<WarehouseManager>.instance.TryGetOrderObject(order3.prefab, out var order))
						{
							continue;
						}
						for (int j = 0; j < order3.total; j++)
						{
							bool flag2 = false;
							for (int k = 0; k < _grabbables.Count; k++)
							{
								Entity item = _grabbables[k];
								if (!item.name.Contains("cone") && NetworkAggroManagerBase<WarehouseManager>.instance.TryGetOrderObject(item.gameObject, out var order2) && order2 == order && !item.GetObject<Grabbable>().ServerIsBeingHeldByHolder() && !hashSet.Contains(item))
								{
									hashSet.Add(item);
									list.Add(item);
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								flag = true;
								Debug.LogWarning("[AUTO PLAY] Could not find a box to ship, forcing the send!");
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					_connections.Clear();
					_connections.AddRange(NetworkServer.connections.Values);
					if (flag)
					{
						outboundBay.ServerRequestSendOutbound(_connections[random.NextInt(0, _connections.Count)], forceCompleted: true);
						continue;
					}
					_holders.Clear();
					outboundBay.entity.GetObjects(_holders);
					int num = 0;
					for (int l = 0; l < list.Count; l += 4)
					{
						Grabbable grabbable = list[l].GetObject<Grabbable>();
						int num2 = l + 1;
						int num3 = 1;
						while (num2 < list.Count && num3 < 4)
						{
							grabbable.ServerAddToStack(list[num2].GetObject<Grabbable>());
							num2++;
							num3++;
						}
						GrabbableHolder grabbableHolder = _holders[num++];
						grabbableHolder.ServerTrySetItem(grabbable, fromPlayer: true);
						grabbable.ServerPlaceInHolder(grabbableHolder);
					}
					outboundBay.ServerRequestSendOutbound(_connections[random.NextInt(0, _connections.Count)], forceCompleted: false);
				}
				if (!_serverTimer.IsFinished())
				{
					break;
				}
				_serverTimer.SetTimer(forceFailedSendEvery);
				_bays.Randomize(random.NextInt());
				for (int m = 0; m < _bays.Count; m++)
				{
					OutboundBay outboundBay2 = _bays[m];
					if (outboundBay2.state == OutboundBay.BayState.Outbound && outboundBay2.serverSecondsRemaining > outboundBay2.orderDeniedTimerReduction * 2f)
					{
						_connections.Clear();
						_connections.AddRange(NetworkServer.connections.Values);
						outboundBay2.ServerRequestSendOutbound(_connections[random.NextInt(0, _connections.Count)], forceCompleted: false);
						break;
					}
				}
				break;
			}
			}
		}
	}

	[Server]
	private void ServerEnableAutoPlay()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AutoPlayManager::ServerEnableAutoPlay()' called when server was not active");
			return;
		}
		Network_syncAutoPlaying = true;
		_lobbyRequested = false;
		_breakRoomRequested = false;
		_organizationRequested = false;
		SaveManager.data.DebugUnlock();
		if (GameUtil.isLobby)
		{
			_lobbyTimer.SetTimer(delayLobby);
		}
		else if (GameUtil.isRun)
		{
			switch (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase())
			{
			case ShiftPhase.BreakRoom:
				_serverTimer.SetTimer(delayBreakRoom);
				break;
			case ShiftPhase.Organizational:
				_serverTimer.SetTimer(delayOrganization);
				break;
			}
		}
	}

	[DevCmd("autoplay", "Enables auto play for stress testing.\r\n\r\nUsage:\r\n    autoplay", new string[] { })]
	[DevCmdVerify("^$")]
	private static void AutoPlayDevCmd(DevCmdArg[] args)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("Only the host can turn on auto play!");
		}
		else
		{
			NetworkAggroManagerBase<AutoPlayManager>.instance.ServerEnableAutoPlay();
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncAutoPlaying);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncAutoPlaying);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncAutoPlaying, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncAutoPlaying, null, reader.ReadBool());
		}
	}
}
