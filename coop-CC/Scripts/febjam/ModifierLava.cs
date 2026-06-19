using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class ModifierLava : ModifierBase, IShiftChanged
{
	public enum State : byte
	{
		Waiting = 0,
		Warning = 1,
		Lava = 2,
		CoolingDown = 3
	}

	[Header("Lava")]
	[Min(0f)]
	public float lavaRadius = 3f;

	[Min(0f)]
	public float boxMinHeightThreshold = 0.2f;

	[Range(0f, 200f)]
	public int boxHeatUpSpeedPercentage = 100;

	[Min(0f)]
	public float stressValueRate = 0.5f;

	[Min(0f)]
	public float warningDuration;

	[Min(0f)]
	public float lavaDuration;

	[Min(0f)]
	public float cooldownDuration;

	[Header("Spawning")]
	[Min(0f)]
	public float delayAfterShiftStart = 5f;

	[Space]
	public Vector2 spawnTimeRange = new Vector2(10f, 15f);

	public Vector2 spawnDensityRange = new Vector2(0.05f, 0.1f);

	[Space]
	[Min(0f)]
	public float exclusionCheckRadius = 4f;

	[Min(0f)]
	public float shrinkGridSpaceDistance = 3f;

	[Min(0f)]
	public float positionNoise = 0.5f;

	[SyncVar]
	private State _syncState;

	private Timer _serverTimer;

	private Vector3[] _serverPositions;

	private int _serverNextPosIndex;

	private static Collider[] _colliders;

	private readonly SyncList<Vector2> _syncPositions = new SyncList<Vector2>();

	public ModifierLavaVisualManager modifierLavaVisualManager;

	public float warningHapticDuration;

	public float warningHapticLowFrequency;

	public float warningHapticHighFrequency;

	public State state => _syncState;

	public State Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			_serverTimer.SetTimer(delayAfterShiftStart);
			Network_syncState = State.Waiting;
			_serverPositions = RoomPositionsUtil.GeneratePositions(shrinkGridSpaceDistance, positionNoise, exclusionCheckRadius, GetSeed());
			_serverNextPosIndex = 0;
			if (_serverPositions.Length == 0)
			{
				Debug.LogError("Did not find any valid spawn locations for lava!");
				base.enabled = false;
			}
		}
	}

	public override void OnStartClient()
	{
		SyncList<Vector2> syncPositions = _syncPositions;
		syncPositions.OnAdd = (Action<int>)Delegate.Combine(syncPositions.OnAdd, new Action<int>(OnAddPosition));
		SyncList<Vector2> syncPositions2 = _syncPositions;
		syncPositions2.OnClear = (Action)Delegate.Combine(syncPositions2.OnClear, new Action(OnClearPositions));
	}

	private void OnAddPosition(int index)
	{
		Vector2 vector = _syncPositions[index];
		Vector3 lavaPosition = new Vector3(vector.x, 0f, vector.y);
		modifierLavaVisualManager.AddLavaVisual(lavaPosition);
	}

	private void OnClearPositions()
	{
		modifierLavaVisualManager.ClearLavaVisuals();
	}

	[ClientRpc]
	public void RpcAddShake()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ModifierLava::RpcAddShake()", -2069950634, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void TestRumble()
	{
		AggroInputManager.Vibrate(warningHapticLowFrequency, warningHapticHighFrequency, 5f);
	}

	protected override void OnUpdateSimulation()
	{
		modifierLavaVisualManager.state = _syncState;
		if (!base.isServer)
		{
			return;
		}
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() != ShiftPhase.Shift)
		{
			_serverTimer.SetTimer(delayAfterShiftStart);
			Network_syncState = State.Waiting;
			return;
		}
		Unity.Mathematics.Random random = GetRandom();
		switch (_syncState)
		{
		case State.Waiting:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				Network_syncState = State.Warning;
				_serverTimer.SetTimer(warningDuration);
				int x = Mathf.CeilToInt(random.NextFloat(spawnDensityRange.x, spawnDensityRange.y) * (float)_serverPositions.Length * GameUtil.GetDifficultyMultiplier());
				x = math.min(x, _serverPositions.Length);
				for (int m = 0; m < x; m++)
				{
					Vector3 vector3 = _serverPositions[_serverNextPosIndex++ % _serverPositions.Length];
					_syncPositions.Add(new Vector2(vector3.x, vector3.z));
				}
			}
			break;
		case State.Warning:
			_serverTimer.DecrementTimer();
			modifierLavaVisualManager.normalizedWarningTime = _serverTimer.GetSecondsRemaining() / _serverTimer.GetTotalSeconds();
			if (_serverTimer.IsFinished())
			{
				modifierLavaVisualManager.normalizedWarningTime = 1f;
				Network_syncState = State.Lava;
				RpcAddShake();
				_serverTimer.SetTimer(lavaDuration);
			}
			break;
		case State.Lava:
		{
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				Network_syncState = State.CoolingDown;
				_serverTimer.SetTimer(cooldownDuration);
				break;
			}
			for (int i = 0; i < _syncPositions.Count; i++)
			{
				Vector2 vector = _syncPositions[i];
				int num = Physics.OverlapSphereNonAlloc(new Vector3(vector.x, 0f, vector.y), lavaRadius, _colliders, 147464);
				for (int j = 0; j < num; j++)
				{
					Collider collider = _colliders[j];
					if (collider.TryGetEntity(out var entity) && collider.bounds.min.y <= boxMinHeightThreshold && entity.TryGetObject<Flammable>(out var obj))
					{
						obj.ServerIsBeingSpreadTo(boxHeatUpSpeedPercentage);
					}
				}
			}
			for (int k = 0; k < _syncPositions.Count; k++)
			{
				Vector2 vector2 = _syncPositions[k];
				int num2 = Physics.OverlapSphereNonAlloc(new Vector3(vector2.x, 0f, vector2.y), lavaRadius, _colliders, 131072);
				for (int l = 0; l < num2; l++)
				{
					if (_colliders[l].TryGetEntity(out var entity2))
					{
						Puddle puddle = entity2.GetObject<Puddle>();
						Flammable obj2;
						if (puddle.isDestroyedByLava)
						{
							puddle.DestroyPuddle(Puddle.PuddleDestroyStyle.Lava);
						}
						else if (entity2.TryGetObject<Flammable>(out obj2))
						{
							obj2.ServerIsBeingSpreadTo(boxHeatUpSpeedPercentage);
						}
					}
				}
			}
			break;
		}
		case State.CoolingDown:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				_syncPositions.Clear();
				Network_syncState = State.Waiting;
				_serverTimer.SetTimer(random.NextFloat(spawnTimeRange.x, spawnTimeRange.y));
			}
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	public void GetPositions(List<Vector3> positions)
	{
		for (int i = 0; i < _syncPositions.Count; i++)
		{
			Vector2 vector = _syncPositions[i];
			positions.Add(new Vector3(vector.x, 0f, vector.y));
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (base.isServer && phase == ShiftPhase.BreakRoom)
		{
			_serverPositions.Randomize(GetSeed());
		}
	}

	public ModifierLava()
	{
		InitSyncObject(_syncPositions);
	}

	static ModifierLava()
	{
		_colliders = new Collider[64];
		RemoteProcedureCalls.RegisterRpc(typeof(ModifierLava), "System.Void ModifierLava::RpcAddShake()", InvokeUserCode_RpcAddShake);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcAddShake()
	{
		AggroManagerBase<CameraShake>.instance.AddShake(1f, warningHapticDuration);
		AggroInputManager.Vibrate(warningHapticLowFrequency, warningHapticHighFrequency, warningHapticDuration);
	}

	protected static void InvokeUserCode_RpcAddShake(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddShake called on server.");
		}
		else
		{
			((ModifierLava)obj).UserCode_RpcAddShake();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_ModifierLava_002FState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_ModifierLava_002FState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ModifierLava_002FState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ModifierLava_002FState(reader));
		}
	}
}
