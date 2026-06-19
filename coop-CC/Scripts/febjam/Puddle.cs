using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class Puddle : NetworkEntityBehaviourBase
{
	private struct PuddleData
	{
		public float radius;

		public Puddle puddle;
	}

	public enum PuddleDestroyStyle
	{
		Lava = 0,
		Scrubber = 1
	}

	public bool isWater;

	public float washUpRadius = 3f;

	public bool canBeWashedAway = true;

	[Min(0f)]
	public float minDistanceFromOtherPuddles = 2f;

	[Space]
	[Min(0f)]
	public float timeToScrubbedUp = 1f;

	[Space]
	public GameObject blobPrefab;

	public GameObject splashVfxPrefab;

	public bool isLiquid;

	public float animatedVisualScale = 1f;

	public bool isDestroyedByLava;

	[SyncVar]
	private byte _syncCleanCount;

	[SyncVar]
	private float _syncNormalizedCleanTime;

	private bool _hasTriedWash;

	private Timer _serverTimer;

	private int _puddleVersion;

	private float _cachedRadius;

	private HashSet<NetworkConnectionToClient> _connections = new HashSet<NetworkConnectionToClient>();

	private int _serverRobotCleanCount;

	private static Collider[] _colliders;

	private List<PuddleData> _puddleDatas = new List<PuddleData>();

	public MeshRenderer puddleMeshRenderer;

	private static readonly int AnimatedVisualScale;

	private static readonly int Active;

	public Animator puddleAnimator;

	public GameObject destroyedByLavaVFX;

	public GameObject cleanedVFX;

	public bool destroying;

	public bool isBeingCleaned => _syncCleanCount > 0;

	public float normalizedCleanTime => _syncNormalizedCleanTime;

	public byte Network_syncCleanCount
	{
		get
		{
			return _syncCleanCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncCleanCount, 1uL, null);
		}
	}

	public float Network_syncNormalizedCleanTime
	{
		get
		{
			return _syncNormalizedCleanTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedCleanTime, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_puddleVersion = -1;
		PuddleManager.BumpVersion();
		_cachedRadius = 0f;
		AoEEffects obj2;
		if (base.entity.TryGetObject<PuddleSlipOut>(out var obj))
		{
			_cachedRadius = obj.radius;
		}
		else if (base.entity.TryGetObject<AoEEffects>(out obj2))
		{
			_cachedRadius = obj2.radius;
		}
		destroying = false;
	}

	protected override void OnEntityDestroyed()
	{
		PuddleManager.BumpVersion();
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer || destroying)
		{
			return;
		}
		if (!_hasTriedWash)
		{
			_hasTriedWash = true;
			if (isWater)
			{
				int num = Physics.OverlapSphereNonAlloc(base.entity.transform.position, washUpRadius, _colliders, 131072);
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					if (_colliders[i].TryGetEntity(out var entity) && entity != base.entity && entity.TryGetObject<Puddle>(out var obj) && obj.canBeWashedAway)
					{
						obj.DestroyPuddle(PuddleDestroyStyle.Scrubber);
						num2++;
					}
				}
				if (num2 > 0)
				{
					NetworkAggroManagerBase<AchievementManager>.instance.ServerAddStat("stat_messes_cleaned", num2);
				}
			}
		}
		if (_syncCleanCount > 0)
		{
			_serverTimer.DecrementTimer(GetCleanSpeedPercentage());
			if (!_serverTimer.IsFinished())
			{
				return;
			}
			if (_serverRobotCleanCount > 0)
			{
				NetworkAggroManagerBase<AchievementManager>.instance.ServerAddStat("stat_messes_cleaned", 1);
			}
			else
			{
				foreach (NetworkConnectionToClient connection in _connections)
				{
					if (connection.isReady)
					{
						NetworkAggroManagerBase<AchievementManager>.instance.ServerAddStat(connection, "stat_messes_cleaned", 1);
					}
				}
			}
			DestroyPuddle(PuddleDestroyStyle.Scrubber);
		}
		else
		{
			_serverTimer.SetTimer(timeToScrubbedUp);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (isLiquid)
		{
			bool flag = false;
			if (_puddleVersion != PuddleManager.puddleVersion)
			{
				_puddleVersion = PuddleManager.puddleVersion;
				flag = true;
				_puddleDatas.Clear();
				int num = Physics.OverlapSphereNonAlloc(base.entity.transform.position, _cachedRadius, _colliders, 131072);
				for (int i = 0; i < num; i++)
				{
					if (_colliders[i].TryGetEntity(out var entity) && entity.TryGetObject<Puddle>(out var obj) && obj.isLiquid)
					{
						PuddleData item = new PuddleData
						{
							puddle = obj
						};
						_puddleDatas.Add(item);
					}
				}
			}
			for (int j = 0; j < _puddleDatas.Count; j++)
			{
				PuddleData value = _puddleDatas[j];
				float num2 = value.puddle._cachedRadius * value.puddle.animatedVisualScale;
				if (!MathUtil.Approximate(num2, value.radius))
				{
					value.radius = num2;
					_puddleDatas[j] = value;
					flag = true;
				}
			}
			if (flag)
			{
				PuddleCollidingChanged();
			}
		}
		if (base.isServer)
		{
			Network_syncNormalizedCleanTime = _serverTimer.GetSecondsRemaining(GetCleanSpeedPercentage()) / timeToScrubbedUp;
		}
	}

	public void DestroyPuddle(PuddleDestroyStyle destroyStyle)
	{
		if (!destroying)
		{
			destroying = true;
			NetworkAggroManagerBase<VFXManager>.instance.Play((destroyStyle == PuddleDestroyStyle.Lava) ? destroyedByLavaVFX : cleanedVFX, base.transform.position);
			RpcPlayDestroyAnim();
			StopAllCoroutines();
			StartCoroutine(DestroyPuddleCo());
		}
	}

	[ClientRpc]
	private void RpcPlayDestroyAnim()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Puddle::RpcPlayDestroyAnim()", 133764599, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator DestroyPuddleCo()
	{
		yield return new WaitForSeconds(1f);
		EntityUtil.Destroy(base.entity);
	}

	private void PuddleCollidingChanged()
	{
		if (isLiquid)
		{
			puddleMeshRenderer.SetPropertyBlockFloat(AnimatedVisualScale, animatedVisualScale);
		}
	}

	protected override void OnUpdatePresentationEarly()
	{
	}

	[Server]
	public void ServerIncrementCleaning(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Puddle::ServerIncrementCleaning(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		Network_syncCleanCount = (byte)(_syncCleanCount + 1);
		_connections.Add(conn);
	}

	[Server]
	public void ServerDecrementCleaning(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Puddle::ServerDecrementCleaning(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		Network_syncCleanCount = (byte)(_syncCleanCount - 1);
		_connections.Remove(conn);
	}

	[Server]
	public void ServerIncrementCleaningRobot()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Puddle::ServerIncrementCleaningRobot()' called when server was not active");
			return;
		}
		Network_syncCleanCount = (byte)(_syncCleanCount + 1);
		_serverRobotCleanCount++;
	}

	[Server]
	public void ServerDecrementCleaningRobot()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Puddle::ServerDecrementCleaningRobot()' called when server was not active");
			return;
		}
		Network_syncCleanCount = (byte)(_syncCleanCount - 1);
		_serverRobotCleanCount--;
	}

	private int GetCleanSpeedPercentage()
	{
		return math.max((_syncCleanCount - 1) * 100, 0);
	}

	static Puddle()
	{
		_colliders = new Collider[16];
		AnimatedVisualScale = Shader.PropertyToID("_animatedVisualScale");
		Active = Animator.StringToHash("active");
		RemoteProcedureCalls.RegisterRpc(typeof(Puddle), "System.Void Puddle::RpcPlayDestroyAnim()", InvokeUserCode_RpcPlayDestroyAnim);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlayDestroyAnim()
	{
		puddleAnimator.SetBool(Active, value: false);
	}

	protected static void InvokeUserCode_RpcPlayDestroyAnim(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayDestroyAnim called on server.");
		}
		else
		{
			((Puddle)obj).UserCode_RpcPlayDestroyAnim();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			NetworkWriterExtensions.WriteByte(writer, _syncCleanCount);
			writer.WriteFloat(_syncNormalizedCleanTime);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			NetworkWriterExtensions.WriteByte(writer, _syncCleanCount);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedCleanTime);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncCleanCount, null, NetworkReaderExtensions.ReadByte(reader));
			GeneratedSyncVarDeserialize(ref _syncNormalizedCleanTime, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncCleanCount, null, NetworkReaderExtensions.ReadByte(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedCleanTime, null, reader.ReadFloat());
		}
	}
}
