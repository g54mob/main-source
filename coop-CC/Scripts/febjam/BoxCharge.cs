using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class BoxCharge : NetworkEntityBehaviourBase, IBoxActivated, IBoxStackedOn
{
	public enum ChargeState : byte
	{
		Waiting = 0,
		Rotating = 1,
		PrepareForCharge = 2,
		Charging = 3,
		Dizzy = 4
	}

	[Min(0f)]
	public float speed = 15f;

	[Min(0f)]
	public float acceleration = 40f;

	[Min(0f)]
	public float icyAcceleration = 4f;

	[Min(0f)]
	public float rotateSpeedDegrees = 90f;

	[Min(1f)]
	public int maxNumberOfRaycasts = 8;

	[Min(0f)]
	public float minimumDegreesToRotate = 45f;

	[Space]
	public Vector2 startRotatingMinMaxDuration = new Vector2(3f, 10f);

	[Min(0f)]
	public float preferredMinDistance = 5f;

	[Min(0f)]
	public float startChargingDuration = 1f;

	[Min(0f)]
	public float dizzyDuration = 5f;

	[Min(0f)]
	public float activatedRotationSpeed = 180f;

	[Space]
	public float collisionSpeedThreshold = 8f;

	[Min(0f)]
	public float collisionAheadOffset = 0.75f;

	[Min(0f)]
	public float collisionRadius = 0.75f;

	[Space]
	[Min(0f)]
	public float kickForce = 20f;

	[Min(0f)]
	public float kickUpwardsModifier = 15f;

	[Space]
	[Min(0f)]
	public float playerForce = 10f;

	[Space]
	[Min(0f)]
	public float stackedOnSpeedMultiplier = 0.5f;

	[SyncVar]
	private Vector3 _syncDir;

	[SyncVar]
	private ChargeState _syncState;

	private Timer _serverTimer;

	private Vector3 _serverStuckPos;

	private HashSet<Entity> _serverCollidedWith = new HashSet<Entity>();

	private Vector3 _debugFromPos;

	private Vector3 _debugTargetPos;

	private Vector3 _debugTargetDir;

	private static List<Vector3> _dirs1 = new List<Vector3>();

	private static List<Vector3> _dirs2 = new List<Vector3>();

	private static Collider[] _colliders = new Collider[32];

	private const float EPSILON = 0.05f;

	private const float EPSILON_SQR = 0.0025000002f;

	private const float VERTICAL_LIMIT_FOR_CHARGE = 0.75f;

	private const float STUCK_DURATION = 1f;

	private const float STUCK_DISTANCE = 0.25f;

	public ParticleSystem chargingParticles;

	public Animator animator;

	public StudioEventEmitter chargeLoopEmitter;

	private static readonly int IDLE = Animator.StringToHash("idle");

	private static readonly int READY = Animator.StringToHash("ready");

	private static readonly int RUNNING = Animator.StringToHash("running");

	private static readonly int DIZZY = Animator.StringToHash("dizzy");

	public ChargeState state => _syncState;

	public Vector3 Network_syncDir
	{
		get
		{
			return _syncDir;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncDir, 1uL, null);
		}
	}

	public ChargeState Network_syncState
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
		Unity.Mathematics.Random random = GetRandom();
		_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
	}

	protected override void OnUpdatePresentation()
	{
		if (chargingParticles != null)
		{
			ParticleSystem.EmissionModule emission = chargingParticles.emission;
			emission.enabled = _syncState == ChargeState.Charging;
		}
		animator.SetBool(IDLE, value: false);
		animator.SetBool(READY, value: false);
		animator.SetBool(RUNNING, value: false);
		animator.SetBool(DIZZY, value: false);
		switch (_syncState)
		{
		case ChargeState.Waiting:
			animator.SetBool(IDLE, value: true);
			chargeLoopEmitter.Stop();
			break;
		case ChargeState.Rotating:
			animator.SetBool(READY, value: true);
			chargeLoopEmitter.Stop();
			break;
		case ChargeState.Dizzy:
			animator.SetBool(DIZZY, value: true);
			chargeLoopEmitter.Stop();
			break;
		case ChargeState.PrepareForCharge:
			animator.SetBool(READY, value: true);
			chargeLoopEmitter.Stop();
			break;
		case ChargeState.Charging:
			animator.SetBool(RUNNING, value: true);
			if (!chargeLoopEmitter.IsPlaying())
			{
				chargeLoopEmitter.Play();
			}
			break;
		}
	}

	protected override void OnUpdateSimulation()
	{
		Rigidbody rigidbody = base.entity.rigidbody;
		Vector3 movingSideWalkVelocity = BeltUtil.GetMovingSideWalkVelocity(rigidbody.position);
		try
		{
			if (base.entity.TryGetStruct<EntityContextComp>(out var comp) && comp.roomType != GameUtil.GetCurrentRoomType())
			{
				return;
			}
			switch (_syncState)
			{
			case ChargeState.Rotating:
			{
				Quaternion to = Quaternion.LookRotation(_syncDir);
				Quaternion rotation = PhysicsUtil.ConstrainUpRight(Quaternion.RotateTowards(rigidbody.rotation, to, rotateSpeedDegrees * (1f / 60f)));
				base.entity.rigidbody.rotation = rotation;
				break;
			}
			case ChargeState.Charging:
				if (!rigidbody.isKinematic)
				{
					Vector3 vector = rigidbody.rotation * Vector3.forward;
					if (vector.y != 0f)
					{
						vector.y = 0f;
						vector = vector.normalized;
					}
					Vector3 target = vector * speed;
					rigidbody.velocity = Vector3.MoveTowards(maxDistanceDelta: ((!NetworkAggroManagerBase<ModifierManager>.ManagerExists() || !NetworkAggroManagerBase<ModifierManager>.instance.HasFlags(ModifierFlags.Icy)) ? acceleration : icyAcceleration) * (1f / 60f), current: rigidbody.velocity, target: target);
					if (movingSideWalkVelocity.sqrMagnitude > 0f)
					{
						rigidbody.MovePosition(rigidbody.position + movingSideWalkVelocity * Time.fixedDeltaTime);
					}
				}
				break;
			default:
				throw new InvalidEnumException();
			case ChargeState.Waiting:
			case ChargeState.PrepareForCharge:
			case ChargeState.Dizzy:
				break;
			}
			if (!base.isServer)
			{
				return;
			}
			Unity.Mathematics.Random random = GetRandom();
			switch (_syncState)
			{
			case ChargeState.Waiting:
			{
				if (ServerShouldGoBackToWaiting(movingSideWalkVelocity.magnitude))
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
					break;
				}
				_serverTimer.DecrementTimer();
				if (!_serverTimer.IsFinished())
				{
					break;
				}
				float2 float5 = random.NextFloat2Direction();
				Vector3 vector4 = new Vector3(float5.x, 0f, float5.y);
				float num2 = math.cos(math.radians(minimumDegreesToRotate));
				Vector3 rhs = base.entity.rigidbody.rotation * Vector3.forward;
				_dirs1.Clear();
				_dirs2.Clear();
				for (int l = 0; l < maxNumberOfRaycasts; l++)
				{
					Vector3 vector5 = Quaternion.AngleAxis((float)l / (float)maxNumberOfRaycasts * 360f, Vector3.up) * vector4;
					if (!(Vector3.Dot(vector5, rhs) >= num2))
					{
						_dirs1.Add(vector5);
						if (Physics.OverlapCapsuleNonAlloc(base.entity.rigidbody.position, base.entity.rigidbody.position + vector5 * preferredMinDistance, 0.45f, _colliders, 1075841024) == 0)
						{
							_dirs2.Add(vector5);
						}
					}
				}
				if (_dirs2.Count == 0)
				{
					_dirs2.AddRangeNoGarbage(_dirs1);
				}
				if (_dirs2.Count > 0)
				{
					Network_syncDir = _dirs2[random.NextInt(0, _dirs2.Count)];
					Network_syncState = ChargeState.Rotating;
				}
				else
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
				}
				break;
			}
			case ChargeState.Rotating:
				if (ServerShouldGoBackToWaiting(movingSideWalkVelocity.magnitude))
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
					Network_syncState = ChargeState.Waiting;
				}
				else if (Vector3.Dot(base.entity.rigidbody.rotation * Vector3.forward, _syncDir) >= 0.95f)
				{
					Network_syncState = ChargeState.PrepareForCharge;
					_serverTimer.SetTimer(startChargingDuration);
				}
				break;
			case ChargeState.PrepareForCharge:
				if (ServerShouldGoBackToWaiting(movingSideWalkVelocity.magnitude))
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
					Network_syncState = ChargeState.Waiting;
					break;
				}
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					_serverCollidedWith.Clear();
					Network_syncState = ChargeState.Charging;
					_serverTimer.SetTimer(1f);
					_serverStuckPos = base.entity.rigidbody.position;
				}
				break;
			case ChargeState.Charging:
			{
				if (base.entity.rigidbody.position.y >= 0.75f)
				{
					Network_syncState = ChargeState.Dizzy;
					_serverTimer.SetTimer(dizzyDuration);
					break;
				}
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					Network_syncState = ChargeState.Dizzy;
					_serverTimer.SetTimer(dizzyDuration);
					break;
				}
				if (math.distancesq(_serverStuckPos, base.entity.rigidbody.position) >= 0.0625f)
				{
					_serverTimer.SetTimer(1f);
					_serverStuckPos = base.entity.rigidbody.position;
				}
				Grabbable grabbable = base.entity.GetObject<Grabbable>();
				if (!grabbable.isBase || grabbable.isKinematic)
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
					Network_syncState = ChargeState.Waiting;
					break;
				}
				Vector3 vector2 = base.entity.rigidbody.rotation * Vector3.forward;
				Vector3 vector3 = base.entity.rigidbody.position + vector2 * collisionAheadOffset;
				int num;
				if (base.entity.rigidbody.velocity.sqrMagnitude >= collisionSpeedThreshold * collisionSpeedThreshold)
				{
					num = Physics.OverlapSphereNonAlloc(vector3, collisionRadius, _colliders, 16384);
					for (int i = 0; i < num; i++)
					{
						Collider collider = _colliders[i];
						Entity entity = collider.GetEntity();
						if (!(entity == base.entity) && !_serverCollidedWith.Contains(entity))
						{
							_serverCollidedWith.Add(entity);
							Vector3 normalized = (entity.rigidbody.position - vector3).normalized;
							normalized = Quaternion.AngleAxis(kickUpwardsModifier, MathUtil.GetOrtho(normalized, Vector3.up)) * normalized;
							normalized *= kickForce;
							entity.rigidbody.velocity = Vector3.zero;
							entity.rigidbody.angularVelocity = Vector3.zero;
							entity.rigidbody.AddForceAtPosition(normalized, collider.ClosestPoint(vector3), ForceMode.Impulse);
							if (entity.TryGetObject<BoxActivator>(out var obj))
							{
								ActivationContext context = new ActivationContext
								{
									type = ActivationContextType.Kicked,
									causer = base.entity
								};
								obj.RequestActivate(context);
							}
						}
					}
					num = Physics.OverlapSphereNonAlloc(vector3, collisionRadius, _colliders, 256);
					for (int j = 0; j < num; j++)
					{
						Collider collider2 = _colliders[j];
						Entity item = collider2.GetEntity();
						if (!_serverCollidedWith.Contains(item))
						{
							_serverCollidedWith.Add(item);
							if (!item.HasObject<PlayerStress>())
							{
								UnityEngine.Debug.LogWarning("Charged player collider does not have player stress? (" + item.name + ")", collider2);
								continue;
							}
							item.GetObject<PlayerStress>().RequestBumpStress();
							item.GetObject<VehicleController>().RpcTakeForce((item.transform.position - vector3).normalized * playerForce);
							item.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
							item.GetObject<PlayerAnimation>().RpcPlayBonk();
							item.GetObject<PlayerColorManagerNetwork>().RpcPlayFlash();
						}
					}
				}
				num = Physics.OverlapSphereNonAlloc(vector3, 0.45f, _colliders, 2049);
				if (num > 0)
				{
					for (int k = 0; k < num; k++)
					{
						Entity item2 = _colliders[k].GetEntity();
						_serverCollidedWith.Add(item2);
						if (item2.TryGetObject<Bonkable>(out var obj2))
						{
							obj2.RequestBonk();
						}
					}
					Network_syncState = ChargeState.Dizzy;
					_serverTimer.SetTimer(dizzyDuration);
				}
				if (!Physics.Raycast(base.entity.rigidbody.position, Vector3.down, 1.5f, 65536))
				{
					ServerStopCharging();
				}
				break;
			}
			case ChargeState.Dizzy:
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					_serverTimer.SetTimer(random.NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
					Network_syncState = ChargeState.Waiting;
				}
				break;
			default:
				throw new InvalidEnumException();
			}
		}
		finally
		{
		}
	}

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	private void DebugCheckRot(string label)
	{
		if (!base.entity.rigidbody.isKinematic && math.dot(base.entity.rigidbody.rotation * Vector3.up, Vector3.up) < 0.9f)
		{
			UnityEngine.Debug.LogWarning($"Bad Rot! {label} {base.entity.rigidbody.rotation.eulerAngles}");
		}
	}

	[Server]
	public void ServerStopCharging()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void BoxCharge::ServerStopCharging()' called when server was not active");
			return;
		}
		Network_syncState = ChargeState.Dizzy;
		_serverTimer.SetTimer(dizzyDuration);
	}

	[Server]
	private bool ServerShouldGoBackToWaiting(float beltSpeed)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean BoxCharge::ServerShouldGoBackToWaiting(System.Single)' called when server was not active");
			return default(bool);
		}
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		if (grabbable.isBase && !grabbable.isKinematic && !(base.entity.rigidbody.velocity.sqrMagnitude > (beltSpeed + 0.05f) * (beltSpeed + 0.05f)) && !(base.entity.rigidbody.position.y >= 0.75f))
		{
			return base.entity.GetObject<BoxProps>().serverIsSafe;
		}
		return true;
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (_syncState == ChargeState.Charging)
		{
			if (context.type == ActivationContextType.Kicked)
			{
				if (context.causer.HasObject<VehicleController>())
				{
					return;
				}
			}
			else if (context.type != ActivationContextType.Explosion)
			{
				return;
			}
		}
		Unity.Mathematics.Random random = GetRandom();
		base.entity.rigidbody.angularVelocity = new Vector3(0f, math.sign(random.NextFloat(-1f, 1f)) * random.NextFloat(0.5f, 1f) * activatedRotationSpeed * (MathF.PI / 180f), 0f);
		Network_syncState = ChargeState.Dizzy;
		_serverTimer.SetTimer(dizzyDuration);
	}

	public void ServerBoxStackedOn()
	{
		Network_syncState = ChargeState.Waiting;
		_serverTimer.SetTimer(GetRandom().NextFloat(startRotatingMinMaxDuration.x, startRotatingMinMaxDuration.y));
		base.entity.rigidbody.velocity *= stackedOnSpeedMultiplier;
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
			writer.WriteVector3(_syncDir);
			GeneratedNetworkCode._Write_BoxCharge_002FChargeState(writer, _syncState);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVector3(_syncDir);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_BoxCharge_002FChargeState(writer, _syncState);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncDir, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_BoxCharge_002FChargeState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncDir, null, reader.ReadVector3());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_BoxCharge_002FChargeState(reader));
		}
	}
}
