using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class Bees : NetworkEntityBehaviourBase, IShiftChanged, IMiscObject
{
	private enum State
	{
		Paused = 0,
		NeedTarget = 1,
		Chasing = 2,
		Damaging = 3,
		Done = 4
	}

	[Tooltip("The Bees will first find the closest box then pick a random box within this radius of that box")]
	[Min(0f)]
	public float initialSearchRadius = 10f;

	[Min(0f)]
	public float speed = 2f;

	[Min(0.15f)]
	public float damagingDistance = 0.25f;

	[Min(0f)]
	public float timeUntilDamaged = 2f;

	[Min(0f)]
	public float pauseDuration = 1f;

	[Min(0f)]
	public float giveUpDuration = 10f;

	[Min(0f)]
	public float blowBeesAwayDuration = 0.5f;

	[Header("Player")]
	[Min(0f)]
	public float playerStressValueRate = 0.2f;

	[Min(0f)]
	public float playerStressDistance = 0.5f;

	[Header("No Target")]
	[Min(0f)]
	public float noTargetSpeed = 0.5f;

	[Min(0f)]
	public float noTargetNoiseScale = 1f;

	[Header("Achievement")]
	[Min(0f)]
	public float achievementKeepAwayDuration = 5f;

	[SyncVar]
	private Entity _syncTargeting;

	private State _serverState;

	private Entity _serverTargeting;

	private Timer _serverTimer;

	private Timer _serverDestroyingTimer;

	private bool _serverIsDestroying;

	private Timer _serverKeepAwayTimer;

	private ObjectQuery<BoxHealth> _boxQueries;

	private ObjectQuery<PlayerEffects> _playerQueries;

	private static List<Entity> _candidates;

	private static Collider[] _colliders;

	public GameObject beeDisperseVFX;

	public StudioEventEmitter beeAttackSfx;

	public StudioEventEmitter beeAggroSfx;

	public StudioEventEmitter beeBuzzSfx;

	public Canvas aggroSymbolCanvas;

	public RectTransform aggroContainer;

	public GameObject aggroSymbol;

	public Entity targeting => _syncTargeting;

	public Entity Network_syncTargeting
	{
		get
		{
			return _syncTargeting;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncTargeting, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_boxQueries = base.entityManager.CreateObjectQuery<BoxHealth>();
		_playerQueries = base.entityManager.CreateObjectQuery<PlayerEffects>();
		aggroSymbolCanvas.worldCamera = GameUtil.uiCamera;
		aggroSymbolCanvas.renderMode = RenderMode.ScreenSpaceCamera;
		beeAggroSfx.Play();
		beeBuzzSfx.Play();
		_serverState = State.Paused;
		_serverTimer.SetTimer(pauseDuration);
	}

	protected override void OnEntityDestroyed()
	{
		if (!GameUtil.isUnloadingScene)
		{
			NetworkAggroManagerBase<VFXManager>.instance.Play(beeDisperseVFX, base.transform.position);
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		_serverIsDestroying = false;
	}

	[UpdateInGroup(5)]
	protected override void OnUpdateSimulation()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player == _syncTargeting && math.distancesq(base.entity.transform.position, player.transform.position) < playerStressDistance * playerStressDistance)
		{
			PlayerEffects playerEffects = player.GetObject<PlayerEffects>();
			playerEffects.AddStressChangeRateMinMax(playerStressValueRate);
			playerEffects.AddContext(PlayerEffectContext.Bees);
		}
		if (!base.isServer)
		{
			return;
		}
		if (_serverIsDestroying)
		{
			_serverDestroyingTimer.DecrementTimer();
			if (_serverDestroyingTimer.IsFinished())
			{
				_serverState = State.Done;
				EntityUtil.Destroy(base.entity);
				return;
			}
		}
		else
		{
			_serverDestroyingTimer.SetTimer(blowBeesAwayDuration);
		}
		switch (_serverState)
		{
		case State.Paused:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				_serverTimer.SetTimer(giveUpDuration);
				_serverState = State.NeedTarget;
			}
			break;
		case State.NeedTarget:
		{
			_serverTimer.DecrementTimer();
			_serverKeepAwayTimer.SetTimer(achievementKeepAwayDuration);
			if (_serverTimer.IsFinished())
			{
				_serverState = State.Done;
				EntityUtil.Destroy(base.entity);
				return;
			}
			Unity.Mathematics.Random random = GetRandom();
			_boxQueries.Run();
			Vector3 position4 = base.entity.transform.position;
			Entity entity = Entity.invalid;
			float num = float.MaxValue;
			_playerQueries.Run();
			for (int i = 0; i < _playerQueries.count; i++)
			{
				Entity entity2 = _playerQueries.GetEntity(i);
				float num2 = math.distancesq(position4, entity2.transform.position);
				if (num2 < num && num2 < initialSearchRadius * initialSearchRadius)
				{
					entity = entity2;
					num = num2;
				}
			}
			if (entity != Entity.invalid)
			{
				for (int j = 0; j < _playerQueries.count; j++)
				{
					Entity item = _playerQueries.GetEntity(j);
					if (math.distancesq(position4, item.transform.position) < initialSearchRadius * initialSearchRadius)
					{
						_candidates.Add(item);
					}
				}
				if (_candidates.Count == 0)
				{
					_candidates.Add(entity);
				}
				_serverTargeting = _candidates[random.NextInt(0, _candidates.Count)];
				_serverState = State.Chasing;
			}
			else
			{
				Vector3 vector3 = position4;
				vector3.y = 0f;
				float x = noise.cnoise(vector3 * noTargetNoiseScale);
				x = math.unlerp(-1f, 1f, x);
				Vector3 vector4 = Quaternion.AngleAxis(360f * x, Vector3.up) * Vector3.forward;
				base.entity.transform.position += vector4 * (1f / 60f * noTargetSpeed);
			}
			break;
		}
		case State.Chasing:
		{
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				_serverState = State.Done;
				EntityUtil.Destroy(base.entity);
				return;
			}
			if (_serverTargeting.Exists() && ((_serverTargeting.TryGetObject<Grabbable>(out var obj4) && !obj4.serverIsOutbounding) || _serverTargeting.HasObject<PlayerEffects>()))
			{
				Vector3 position2 = base.entity.transform.position;
				Vector3 position3 = _serverTargeting.transform.position;
				if (math.distancesq(position2, position3) <= damagingDistance * damagingDistance)
				{
					_serverState = State.Damaging;
					_serverTimer.SetTimer(timeUntilDamaged);
					break;
				}
				Vector3 vector = position3 - position2;
				vector.Normalize();
				Vector3 vector2 = position2 + vector * (1f / 60f * speed);
				if (Vector3.Dot(position3 - vector2, vector) > 0f)
				{
					base.entity.transform.position = vector2;
				}
				else
				{
					base.entity.transform.position = position3;
				}
				if (_serverTargeting.TryGetObject<Grabbable>(out var obj5) && obj5.serverPlayerEntity.Exists())
				{
					_serverKeepAwayTimer.DecrementTimer();
					if (_serverKeepAwayTimer.IsFinished())
					{
						NetworkAggroManagerBase<AchievementManager>.instance.ServerUnlockAchievement(obj5.serverPlayerEntity.netIdentity.connectionToClient, "ach_bee_keepaway");
					}
				}
				else
				{
					_serverKeepAwayTimer.SetTimer(achievementKeepAwayDuration);
				}
			}
			else
			{
				_serverState = State.NeedTarget;
				_serverKeepAwayTimer.SetTimer(achievementKeepAwayDuration);
			}
			break;
		}
		case State.Damaging:
		{
			_serverKeepAwayTimer.SetTimer(achievementKeepAwayDuration);
			if (_serverTargeting.Exists() && ((_serverTargeting.TryGetObject<Grabbable>(out var obj) && !obj.serverIsOutbounding) || _serverTargeting.HasObject<PlayerEffects>()))
			{
				Vector3 position = base.entity.transform.position;
				if (math.distancesq(y: _serverTargeting.transform.position, x: position) > damagingDistance * damagingDistance)
				{
					_serverState = State.Chasing;
					_serverTimer.SetTimer(giveUpDuration);
				}
				else
				{
					if (!_serverTargeting.TryGetObject<BoxHealth>(out var obj2))
					{
						break;
					}
					_serverTimer.DecrementTimer();
					if (_serverTimer.IsFinished())
					{
						RpcOnAttack();
						obj2.RequestTakeDamage(DamageType.Damaged);
						if (_serverTargeting.TryGetObject<BoxActivator>(out var obj3))
						{
							ActivationContext context = new ActivationContext
							{
								type = ActivationContextType.Bees,
								causer = base.entity
							};
							obj3.RequestActivate(context);
						}
						_serverState = State.NeedTarget;
						_serverTimer.SetTimer(giveUpDuration);
					}
				}
			}
			else
			{
				_serverState = State.NeedTarget;
				_serverTimer.SetTimer(giveUpDuration);
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		case State.Done:
			break;
		}
		Network_syncTargeting = _serverTargeting;
	}

	[ClientRpc]
	private void RpcOnAttack()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Bees::RpcOnAttack()", -1036856190, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdatePresentationLate()
	{
		if (targeting.Exists())
		{
			aggroSymbol.gameObject.SetActive(value: true);
			aggroSymbol.transform.localPosition = SetTargetPosition(targeting.transform.position);
		}
		else
		{
			aggroSymbol.gameObject.SetActive(value: false);
		}
	}

	private Vector2 SetTargetPosition(Vector3 worldPos)
	{
		Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(worldPos);
		vector *= math.sign(vector.z) / Options.renderScale;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(aggroContainer, vector, GameUtil.uiCamera, out var localPoint);
		return localPoint;
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (base.isServer)
		{
			_serverState = State.Done;
			EntityUtil.Destroy(base.entity);
		}
	}

	public void ServerIsBeingDestroyed()
	{
		_serverIsDestroying = true;
	}

	public void ServerDestroyedImmediate()
	{
		_serverState = State.Done;
		EntityUtil.Destroy(base.entity);
	}

	static Bees()
	{
		_candidates = new List<Entity>();
		_colliders = new Collider[64];
		RemoteProcedureCalls.RegisterRpc(typeof(Bees), "System.Void Bees::RpcOnAttack()", InvokeUserCode_RpcOnAttack);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOnAttack()
	{
		beeAttackSfx.Play();
	}

	protected static void InvokeUserCode_RpcOnAttack(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnAttack called on server.");
		}
		else
		{
			((Bees)obj).UserCode_RpcOnAttack();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteEntity(_syncTargeting);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteEntity(_syncTargeting);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncTargeting, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncTargeting, null, reader.ReadEntity());
		}
	}
}
