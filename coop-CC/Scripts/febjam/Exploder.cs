using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class Exploder : NetworkEntityBehaviourBase, IBoxActivated, IFlammable
{
	public enum ExplodeState : byte
	{
		Inert = 0,
		Warning = 1,
		Exploded = 2
	}

	public bool startInWarningState;

	public bool destroyOnShiftChange;

	public bool canBePutOut;

	[Min(0f)]
	public float warningDuration = 5f;

	[Min(0f)]
	public float explosionRadius = 5f;

	[Min(0f)]
	public float explosionBoxForce = 30f;

	[Min(0f)]
	public float explosionBoxForceRadius;

	[Range(0f, 90f)]
	public float explosionBoxForceUpwardsModifier = 25f;

	[Min(0f)]
	public float explosionPlayerForce = 20f;

	public ActivationContextSubType activationSubType;

	[Space]
	public GameObject vfxPrefab;

	[SyncVar]
	private ExplodeState _state;

	[SyncVar]
	private float _warningSecondsRemaining;

	private Timer _timer;

	private static Collider[] _colliders = new Collider[128];

	[Header("Visuals")]
	public GameObject intactObject;

	public MeshRenderer flashingMeshRenderer;

	private static readonly int WARNING = Animator.StringToHash("warning");

	private static readonly int SPEED = Animator.StringToHash("speed");

	private static readonly int FLASHING = Shader.PropertyToID("_flashing");

	public ExplodeState explodeState => _state;

	public float warningSecondsRemaining => _warningSecondsRemaining;

	public ExplodeState Network_state
	{
		get
		{
			return _state;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _state, 1uL, null);
		}
	}

	public float Network_warningSecondsRemaining
	{
		get
		{
			return _warningSecondsRemaining;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _warningSecondsRemaining, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_timer = default(Timer);
		Network_warningSecondsRemaining = 0f;
		if (startInWarningState)
		{
			Network_state = ExplodeState.Warning;
			_timer.SetTimer(warningDuration);
		}
		else
		{
			Network_state = ExplodeState.Inert;
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		switch (_state)
		{
		case ExplodeState.Warning:
			if (destroyOnShiftChange && NetworkAggroManagerBase<ShiftManager>.ManagerExists() && NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() != ShiftPhase.Shift)
			{
				Network_state = ExplodeState.Exploded;
				EntityUtil.Destroy(base.entity);
			}
			else
			{
				if (base.entity.TryGetObject<Grabbable>(out var obj) && obj.serverIsOutbounding)
				{
					break;
				}
				_timer.DecrementTimer();
				if (!_timer.IsFinished())
				{
					break;
				}
				Network_state = ExplodeState.Exploded;
				Vector3 position = base.entity.transform.position;
				int num = Physics.OverlapSphereNonAlloc(position, explosionRadius, _colliders, 256);
				for (int i = 0; i < num; i++)
				{
					Entity entity = _colliders[i].GetComponent<EntityCollider>().entity;
					PlayerUpgrades playerUpgrades = entity.GetObject<PlayerUpgrades>();
					PlayerStress playerStress = entity.GetObject<PlayerStress>();
					if (playerUpgrades.HasUpgrade(PlayerUpgrade.BlastProtection))
					{
						playerStress.RequestAddStress(playerUpgrades.blastProtectedStressAddAmount, sendEvent: true);
					}
					else
					{
						playerStress.RequestAddStress(1f, sendEvent: true);
					}
					if (!playerUpgrades.HasUpgrade(PlayerUpgrade.StrongGrabbers))
					{
						Entity serverGrabbed = entity.GetObject<PlayerGrabber>().serverGrabbed;
						entity.GetObject<PlayerGrabber>().ServerDropBoxesSimple();
						if (serverGrabbed != Entity.invalid && serverGrabbed.TryGetObject<Grabbable>(out var obj2))
						{
							obj2.ServerBreakStackAtMe();
						}
					}
					if (entity.TryGetObject<VehicleController>(out var obj3))
					{
						Vector3 normalized = (obj3.entity.transform.position - position).normalized;
						obj3.RpcTakeForce(normalized * explosionPlayerForce);
					}
				}
				num = Physics.OverlapSphereNonAlloc(position, explosionRadius, _colliders, 2048);
				for (int j = 0; j < num; j++)
				{
					if (_colliders[j].TryGetEntity(out var entity2) && entity2.TryGetObject<Bonkable>(out var obj4))
					{
						obj4.RequestBonk();
					}
				}
				num = Physics.OverlapSphereNonAlloc(position, explosionRadius, _colliders, 16384);
				for (int k = 0; k < num; k++)
				{
					Entity entity3 = _colliders[k].GetComponent<EntityCollider>().entity;
					if (entity3 == base.entity)
					{
						continue;
					}
					Grabbable grabbable = entity3.GetObject<Grabbable>();
					if (!grabbable.isBase)
					{
						grabbable = grabbable.baseEntity.GetObject<Grabbable>();
					}
					if ((!grabbable.serverPlayerEntity.TryGetObject<PlayerUpgrades>(out var obj5) || !obj5.HasUpgrade(PlayerUpgrade.StrongGrabbers)) && (!(grabbable.serverHolderEntity != Entity.invalid) || grabbable.serverHolderEntity.HasObject<Bonkable>()))
					{
						grabbable = entity3.GetObject<Grabbable>();
						grabbable.ServerBreakStackAtMe();
						if (entity3.TryGetObject<BoxHealth>(out var obj6))
						{
							obj6.RequestTakeDamage(DamageType.Damaged);
						}
						if (entity3.TryGetObject<BoxActivator>(out var obj7))
						{
							obj7.RequestActivate(new ActivationContext(ActivationContextType.Explosion, activationSubType));
						}
						if (!entity3.rigidbody.isKinematic)
						{
							entity3.rigidbody.AddExplosionForce(explosionBoxForce, position, explosionBoxForceRadius, explosionBoxForceUpwardsModifier, ForceMode.Impulse);
						}
					}
				}
				num = Physics.OverlapSphereNonAlloc(position, explosionRadius, _colliders, 8);
				for (int l = 0; l < num; l++)
				{
					Entity entity4 = _colliders[l].GetComponent<EntityCollider>().entity;
					if (!(entity4 == base.entity) && entity4.TryGetObject<IMiscObject>(out var obj8))
					{
						obj8.ServerDestroyedImmediate();
					}
				}
				NetworkAggroManagerBase<VFXManager>.instance.Play(vfxPrefab, position);
				EntityUtil.Destroy(base.entity);
			}
			break;
		default:
			throw new InvalidEnumException();
		case ExplodeState.Inert:
		case ExplodeState.Exploded:
			break;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.isServer)
		{
			switch (_state)
			{
			case ExplodeState.Warning:
				Network_warningSecondsRemaining = _timer.GetSecondsRemaining();
				break;
			default:
				throw new InvalidEnumException();
			case ExplodeState.Inert:
			case ExplodeState.Exploded:
				break;
			}
		}
		if (!(intactObject != null))
		{
			return;
		}
		switch (_state)
		{
		case ExplodeState.Inert:
		{
			intactObject.SetActive(value: true);
			flashingMeshRenderer.materials[0].SetFloat(FLASHING, 0f);
			if (base.entity.TryGetObject<Animator>(out var obj2))
			{
				obj2.SetBool(WARNING, value: false);
			}
			break;
		}
		case ExplodeState.Warning:
		{
			intactObject.SetActive(value: true);
			if (base.entity.TryGetObject<Animator>(out var obj))
			{
				obj.SetBool(WARNING, value: true);
				obj.SetFloat(SPEED, 1f / warningDuration);
			}
			flashingMeshRenderer.materials[0].SetFloat(FLASHING, 1f);
			break;
		}
		case ExplodeState.Exploded:
			intactObject.SetActive(value: false);
			flashingMeshRenderer.materials[0].SetFloat(FLASHING, 0f);
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (_state == ExplodeState.Inert)
		{
			Network_state = ExplodeState.Warning;
			_timer.SetTimer(warningDuration);
		}
	}

	[Server]
	public bool ServerFlammableCanBePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean Exploder::ServerFlammableCanBePutOut()' called when server was not active");
			return default(bool);
		}
		if (canBePutOut)
		{
			return _state == ExplodeState.Warning;
		}
		return false;
	}

	[Server]
	public void ServerFlammablePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Exploder::ServerFlammablePutOut()' called when server was not active");
		}
		else if (_state == ExplodeState.Warning)
		{
			Network_state = ExplodeState.Inert;
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
			GeneratedNetworkCode._Write_Exploder_002FExplodeState(writer, _state);
			writer.WriteFloat(_warningSecondsRemaining);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_Exploder_002FExplodeState(writer, _state);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_warningSecondsRemaining);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _state, null, GeneratedNetworkCode._Read_Exploder_002FExplodeState(reader));
			GeneratedSyncVarDeserialize(ref _warningSecondsRemaining, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _state, null, GeneratedNetworkCode._Read_Exploder_002FExplodeState(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _warningSecondsRemaining, null, reader.ReadFloat());
		}
	}
}
