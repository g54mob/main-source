using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class StationTeleporterManager : NetworkAggroManagerBase<StationTeleporterManager>
{
	public enum State : byte
	{
		Waiting = 0,
		Teleporting = 1
	}

	[Min(0f)]
	public float teleportDuration = 3f;

	private List<StationTeleporter> _warehouseTeleporters = new List<StationTeleporter>();

	private List<StationTeleporter> _breakroomTeleporters = new List<StationTeleporter>();

	[SyncVar]
	private float _syncNormalizedTeleportTime;

	[SyncVar]
	private State _syncState;

	private Timer _serverTimer;

	private static List<Entity> _entities = new List<Entity>();

	public float normalizedTeleportTime => _syncNormalizedTeleportTime;

	public State state => _syncState;

	public float Network_syncNormalizedTeleportTime
	{
		get
		{
			return _syncNormalizedTeleportTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedTeleportTime, 1uL, null);
		}
	}

	public State Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 2uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			if (GameUtil.GetCurrentRoomType() == RoomType.BreakRoom)
			{
				ServerProcessTeleportation(_breakroomTeleporters);
			}
			else
			{
				ServerProcessTeleportation(_warehouseTeleporters);
			}
		}
	}

	private void ServerProcessTeleportation(List<StationTeleporter> teleporters)
	{
		switch (_syncState)
		{
		case State.Waiting:
		{
			if (teleporters.Count < 2)
			{
				break;
			}
			for (int m = 0; m < teleporters.Count; m++)
			{
				if (teleporters[m].HasBoxes())
				{
					Network_syncState = State.Teleporting;
					_serverTimer.SetTimer(teleportDuration);
					break;
				}
			}
			break;
		}
		case State.Teleporting:
		{
			bool flag = true;
			if (teleporters.Count >= 2)
			{
				for (int i = 0; i < teleporters.Count; i++)
				{
					if (teleporters[i].HasBoxes())
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Network_syncState = State.Waiting;
				break;
			}
			_serverTimer.DecrementTimer();
			if (!_serverTimer.IsFinished())
			{
				break;
			}
			_entities.Clear();
			for (int j = 0; j < teleporters.Count; j++)
			{
				if (teleporters[j].entity.TryGetObject<GrabbableHolder>(out var obj) && obj.isHoldingAnItem)
				{
					_entities.Add(obj.serverHeldEntity);
				}
				else
				{
					_entities.Add(Entity.invalid);
				}
			}
			bool flag2 = true;
			for (int k = 0; k < teleporters.Count; k++)
			{
				GrabbableHolder grabbableHolder = teleporters[k].entity.GetObject<GrabbableHolder>();
				int num = k - 1;
				if (num < 0)
				{
					num = teleporters.Count - 1;
				}
				if (_entities[num].TryGetObject<Grabbable>(out var obj2) && !grabbableHolder.CanSetItem(obj2, fromPlayer: false))
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				for (int l = 0; l < teleporters.Count; l++)
				{
					teleporters[l].RpcOnTeleport();
					GrabbableHolder grabbableHolder2 = teleporters[l].entity.GetObject<GrabbableHolder>();
					int num2 = l - 1;
					if (num2 < 0)
					{
						num2 = teleporters.Count - 1;
					}
					if (_entities[num2].TryGetObject<Grabbable>(out var obj3))
					{
						if (grabbableHolder2.ServerTrySetItem(obj3, fromPlayer: false))
						{
							obj3.ServerPlaceInHolder(grabbableHolder2);
						}
					}
					else
					{
						grabbableHolder2.ServerRemoveItem();
					}
				}
			}
			else
			{
				Debug.LogWarning("Teleportation will fail! Not teleporting");
			}
			_serverTimer.SetTimer(teleportDuration);
			break;
		}
		default:
			throw new InvalidEnumException();
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isServer)
		{
			switch (_syncState)
			{
			case State.Waiting:
				Network_syncNormalizedTeleportTime = 0f;
				break;
			case State.Teleporting:
				Network_syncNormalizedTeleportTime = math.saturate(1f - _serverTimer.GetSecondsRemaining() / teleportDuration);
				break;
			default:
				throw new InvalidEnumException();
			}
		}
	}

	[Server]
	public void ServerAddStation(StationTeleporter teleporter)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationTeleporterManager::ServerAddStation(StationTeleporter)' called when server was not active");
		}
		else if (GameUtil.GetCurrentRoomType() == RoomType.BreakRoom)
		{
			_breakroomTeleporters.Add(teleporter);
		}
		else
		{
			_warehouseTeleporters.Add(teleporter);
		}
	}

	[Server]
	public void ServerRemoveStation(StationTeleporter teleporter)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationTeleporterManager::ServerRemoveStation(StationTeleporter)' called when server was not active");
		}
		else if (GameUtil.GetCurrentRoomType() == RoomType.BreakRoom)
		{
			_breakroomTeleporters.Remove(teleporter);
		}
		else
		{
			_warehouseTeleporters.Remove(teleporter);
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
			writer.WriteFloat(_syncNormalizedTeleportTime);
			GeneratedNetworkCode._Write_StationTeleporterManager_002FState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedTeleportTime);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_StationTeleporterManager_002FState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedTeleportTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationTeleporterManager_002FState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedTeleportTime, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_StationTeleporterManager_002FState(reader));
		}
	}
}
