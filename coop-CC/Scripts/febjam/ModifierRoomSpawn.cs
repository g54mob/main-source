using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class ModifierRoomSpawn : ModifierBase, IShiftChanged
{
	public enum State
	{
		Waiting = 0,
		Spawning = 1,
		Done = 2
	}

	public GameObject spawnPrefab;

	[Min(0f)]
	public float delayAfterShiftStart = 5f;

	[Space]
	public Vector2 spawnTimeRange = new Vector2(5f, 10f);

	public Vector2 spawnDensityRange = new Vector2(0.05f, 0.1f);

	[Min(0f)]
	public float spawnInDuration = 1f;

	[Min(0f)]
	public float spawnCheckRadius = 1f;

	public bool continuousSpawn = true;

	[Min(0f)]
	public float exclusionCheckRadius = 4f;

	[Min(0f)]
	public float shrinkGridSpaceDistance = 3f;

	[Min(0f)]
	public float positionNoise = 0.5f;

	[Space]
	public bool trackSpawnedInstances;

	[Range(0f, 1f)]
	public float maxInstancesDensity = 0.2f;

	public bool destroyInstancesOnBreakRoom = true;

	public bool destroyInstancesOnModifierDestroyed = true;

	[SyncVar]
	private int _syncSecondsUntilNextSpawn;

	[SyncVar]
	private State _syncState;

	private Timer _serverTimer;

	private List<Vector3> _serverSpawnLocs = new List<Vector3>();

	private List<Entity> _serverInstances = new List<Entity>();

	private int _serverSpawnCount;

	private int _serverNextSpawnIndex;

	private int _serverSpawned;

	public int secondsUntilNextSpawn => _syncSecondsUntilNextSpawn;

	public State state => _syncState;

	public int Network_syncSecondsUntilNextSpawn
	{
		get
		{
			return _syncSecondsUntilNextSpawn;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncSecondsUntilNextSpawn, 1uL, null);
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

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			_serverTimer.SetTimer(delayAfterShiftStart);
			Network_syncState = State.Waiting;
			_serverSpawnLocs.AddRangeNoGarbage(RoomPositionsUtil.GeneratePositions(shrinkGridSpaceDistance, positionNoise, exclusionCheckRadius, GetSeed()));
			_serverNextSpawnIndex = 0;
			if (_serverSpawnLocs.Count == 0)
			{
				Debug.LogError("Did not find any valid spawn loations for Room Spawning!");
				base.enabled = false;
			}
		}
	}

	protected override void OnEntityDestroyed()
	{
		if (!base.isServer || !trackSpawnedInstances || !destroyInstancesOnModifierDestroyed)
		{
			return;
		}
		for (int i = 0; i < _serverInstances.Count; i++)
		{
			Entity entity = _serverInstances[i];
			if (entity.Exists())
			{
				EntityUtil.Destroy(entity);
			}
		}
		_serverInstances.Clear();
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		if (trackSpawnedInstances)
		{
			for (int i = 0; i < _serverInstances.Count; i++)
			{
				if (!_serverInstances[i].Exists())
				{
					_serverInstances.RemoveAtSwapBack(i);
					i--;
				}
			}
		}
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Shift)
		{
			switch (_syncState)
			{
			case State.Waiting:
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					Network_syncState = State.Spawning;
					_serverTimer.SetTimer(spawnInDuration);
					float num4 = GetRandom().NextFloat(spawnDensityRange.x, spawnDensityRange.y);
					_serverSpawnCount = Mathf.CeilToInt(num4 * (float)_serverSpawnLocs.Count * GameUtil.GetDifficultyMultiplier());
					_serverSpawned = 0;
				}
				break;
			case State.Spawning:
			{
				_serverTimer.DecrementTimer();
				int num = Mathf.RoundToInt(math.lerp(0f, _serverSpawnCount, math.saturate(1f - _serverTimer.GetSecondsRemaining() / spawnInDuration)));
				if (trackSpawnedInstances)
				{
					int num2 = Mathf.CeilToInt((float)_serverSpawnLocs.Count * maxInstancesDensity);
					num = math.min(num, num2 - _serverInstances.Count);
				}
				while (_serverSpawned < num)
				{
					Vector3 vector = default(Vector3);
					bool flag = false;
					int count = _serverSpawnLocs.Count;
					int num3 = 0;
					while (num3++ < count && !flag)
					{
						vector = _serverSpawnLocs[_serverNextSpawnIndex % _serverSpawnLocs.Count];
						if (NavMesh.Raycast(vector + Vector3.up, Vector3.down, out var _, -1) && !Physics.SphereCast(new Ray(vector + Vector3.up * 100f, Vector3.down), spawnCheckRadius, 200f, 2048))
						{
							flag = true;
						}
						_serverNextSpawnIndex++;
					}
					if (flag)
					{
						Entity item = EntityUtil.Instantiate(spawnPrefab, vector);
						if (trackSpawnedInstances)
						{
							_serverInstances.Add(item);
						}
					}
					else
					{
						Debug.LogWarning("Couldn't find a valid spawn location for room modifier!");
					}
					_serverSpawned++;
				}
				if (_serverTimer.IsFinished())
				{
					if (continuousSpawn)
					{
						Network_syncState = State.Waiting;
						_serverTimer.SetTimer(GetRandom().NextFloat(spawnTimeRange.x, spawnTimeRange.y));
					}
					else
					{
						Network_syncState = State.Done;
					}
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			case State.Done:
				break;
			}
		}
		else
		{
			_serverTimer.SetTimer(delayAfterShiftStart);
			Network_syncState = State.Waiting;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isServer)
		{
			Network_syncSecondsUntilNextSpawn = Mathf.CeilToInt(_serverTimer.GetSecondsRemaining());
		}
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying && GameUtil.isReady && NetworkServer.active)
		{
			Gizmos.color = Color.cyan;
			for (int i = 0; i < _serverSpawnLocs.Count; i++)
			{
				Gizmos.DrawSphere(_serverSpawnLocs[i], 0.2f);
			}
			Color cyan = Color.cyan;
			cyan.a = 0.5f;
			Gizmos.color = cyan;
			Gizmos.matrix = Matrix4x4.Scale(new Vector3(1f, 0f, 1f));
			for (int j = 0; j < _serverSpawnLocs.Count; j++)
			{
				Gizmos.DrawWireSphere(_serverSpawnLocs[j], exclusionCheckRadius);
			}
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (base.isServer && phase == ShiftPhase.BreakRoom && trackSpawnedInstances && destroyInstancesOnBreakRoom)
		{
			for (int i = 0; i < _serverInstances.Count; i++)
			{
				Entity entity = _serverInstances[i];
				if (entity.Exists())
				{
					EntityUtil.Destroy(entity);
				}
			}
			_serverInstances.Clear();
		}
		_serverSpawnLocs.Randomize(GetSeed());
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
			writer.WriteVarInt(_syncSecondsUntilNextSpawn);
			GeneratedNetworkCode._Write_ModifierRoomSpawn_002FState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncSecondsUntilNextSpawn);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_ModifierRoomSpawn_002FState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncSecondsUntilNextSpawn, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ModifierRoomSpawn_002FState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncSecondsUntilNextSpawn, null, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ModifierRoomSpawn_002FState(reader));
		}
	}
}
