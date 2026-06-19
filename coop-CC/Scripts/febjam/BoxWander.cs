using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class BoxWander : NetworkEntityBehaviourBase, IBoxActivated, IBoxStackedOn
{
	[Min(0f)]
	public float speed = 1f;

	[Min(0f)]
	public float backUpSpeed = 1f;

	[Min(0f)]
	public float acceleration = 20f;

	[Min(0f)]
	public float icyAcceleration = 2f;

	public Vector2 startWanderingMinMaxDuration = new Vector2(5f, 20f);

	public float targetRadius;

	public float targetOffset;

	[Range(0f, 1f)]
	public float rotationSlerpAmount = 0.1f;

	[Space]
	public bool stopWhenStackedOn;

	[Min(0f)]
	public float stackedOnSpeedMultiplier = 0.5f;

	public bool disableWhenShiftOver;

	[Header("Look Ahead")]
	[Min(0f)]
	public float lookAheadDistance = 3f;

	[Range(0f, 90f)]
	public float avoidColliderDegrees = 45f;

	[Header("Noise")]
	public float noiseOffset = 100f;

	[Min(0f)]
	public float noiseScale = 1f;

	[SyncVar]
	private int _syncWanderingSeed;

	private Timer _serverTimer;

	private Vector3 _serverStuckPos;

	private float _speedMultiplier;

	private Vector3 _debugFromPos;

	private Vector3 _debugTargetPos;

	private Vector3 _debugTargetDir;

	private Vector3 _debugForward;

	private Vector3 _debugToInfoDir;

	private Vector3 _debugRandomPos;

	private const float VELOCITY_THRESHOLD = 0.1f;

	private const float STOP_WANDERING_THRESHOLD = 0.5f;

	private const float LOOK_AHEAD_RADIUS = 0.49f;

	private const float VERTICAL_LIMIT_FOR_WANDER = 0.75f;

	private const float STUCK_DURATION = 1f;

	private const float STUCK_DISTANCE_MULTIPLIER = 0.1f;

	private static Collider[] _colliders = new Collider[64];

	public bool isWandering => _syncWanderingSeed != 0;

	public int Network_syncWanderingSeed
	{
		get
		{
			return _syncWanderingSeed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncWanderingSeed, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		Unity.Mathematics.Random random = GetRandom();
		_serverTimer.SetTimer(random.NextFloat(startWanderingMinMaxDuration.x, startWanderingMinMaxDuration.y));
	}

	[UpdateInGroup(-10)]
	protected override void OnUpdateSimulationEarly()
	{
		_speedMultiplier = 1f;
	}

	[UpdateInGroup(10)]
	protected override void OnUpdateSimulation()
	{
		if (base.entity.TryGetStruct<EntityContextComp>(out var comp) && comp.roomType != GameUtil.GetCurrentRoomType())
		{
			return;
		}
		Rigidbody rigidbody = base.entity.rigidbody;
		_ = rigidbody.rotation;
		Vector3 movingSideWalkVelocity = BeltUtil.GetMovingSideWalkVelocity(rigidbody.position);
		float magnitude = movingSideWalkVelocity.magnitude;
		float num = speed + 0.5f + magnitude;
		bool flag = rigidbody.velocity.sqrMagnitude >= num * num;
		if (base.isServer)
		{
			if (disableWhenShiftOver && NetworkAggroManagerBase<ShiftManager>.instance.isTransitioning)
			{
				Network_syncWanderingSeed = 0;
				_serverTimer.SetTimer(startWanderingMinMaxDuration.y);
				return;
			}
			Unity.Mathematics.Random random = GetRandom();
			Grabbable grabbable = base.entity.GetObject<Grabbable>();
			float num2 = 0.1f + magnitude;
			num2 *= num2;
			if (!grabbable.isBase || grabbable.isKinematic || flag || (!isWandering && rigidbody.velocity.sqrMagnitude > num2) || rigidbody.position.y >= 0.75f || base.entity.GetObject<BoxProps>().serverIsSafe)
			{
				ServerStopWander();
			}
			else if (_syncWanderingSeed == 0 && !_serverTimer.IsFinished())
			{
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					Network_syncWanderingSeed = random.NextInt();
					_serverStuckPos = base.entity.rigidbody.position;
					_serverTimer.SetTimer(1f);
					Quaternion rotation = rigidbody.rotation;
					Vector3 fwd = rotation * Vector3.forward;
					if (fwd.y != 0f)
					{
						fwd.y = 0f;
						fwd = fwd.normalized;
					}
					GetInfo(rigidbody.position, fwd, checkForBoxes: true, out var localPos);
					Vector3 targetFwd = rotation * localPos.normalized;
					rigidbody.angularVelocity = Vector3.zero;
					rigidbody.velocity = Vector3.zero;
					UpdateVelocity(rigidbody, fwd, targetFwd);
				}
			}
		}
		if (isWandering && !flag)
		{
			Vector3 position = rigidbody.position;
			Vector3 velocity;
			Quaternion quaternion2;
			if (rigidbody.velocity.sqrMagnitude > 0f)
			{
				velocity = rigidbody.velocity;
				velocity.y = 0f;
				velocity = velocity.normalized;
				if (velocity.sqrMagnitude == 0f)
				{
					velocity = rigidbody.rotation * Vector3.forward;
				}
				quaternion2 = Quaternion.LookRotation(velocity, Vector3.up);
			}
			else
			{
				quaternion2 = rigidbody.rotation;
				velocity = quaternion2 * Vector3.forward;
				if (velocity.y != 0f)
				{
					velocity.y = 0f;
					velocity = velocity.normalized;
				}
			}
			GetInfo(position, velocity, checkForBoxes: false, out var localPos2);
			Unity.Mathematics.Random random2 = MathUtil.GetRandom(_syncWanderingSeed);
			float num3 = random2.NextFloat(0f - noiseOffset, noiseOffset);
			float num4 = random2.NextFloat(0f - noiseOffset, noiseOffset);
			float num5 = noise.cnoise(new float2((float)(int)position.x + num3, (float)(int)position.y + num4) / noiseScale);
			num5 = math.saturate((num5 + 1f) / 2f);
			Vector3 vector = Vector3.SlerpUnclamped(Vector3.forward, Vector3.back, num5 * 2f);
			Vector3 normalized = (localPos2 + new Vector3(vector.x, 0f, vector.y) * random2.NextFloat(0f, targetRadius)).normalized;
			Vector3 vector2 = quaternion2 * normalized;
			rigidbody.angularVelocity = Vector3.zero;
			Quaternion b = Quaternion.LookRotation(vector2, Vector3.up);
			rigidbody.rotation = PhysicsUtil.ConstrainUpRight(Quaternion.Slerp(rigidbody.rotation, b, rotationSlerpAmount));
			UpdateVelocity(rigidbody, velocity, vector2);
			if (magnitude > 0f)
			{
				rigidbody.MovePosition(rigidbody.position + movingSideWalkVelocity * Time.fixedDeltaTime);
			}
		}
		if (!base.isServer)
		{
			return;
		}
		if (math.dot(rigidbody.rotation * Vector3.up, Vector3.up) < 0.9f)
		{
			Vector3 forward = rigidbody.rotation * Vector3.forward;
			forward.y = 0f;
			forward.Normalize();
			rigidbody.rotation = Quaternion.LookRotation(forward, Vector3.up);
		}
		if (isWandering)
		{
			float num6 = speed * 0.1f;
			if (math.distancesq(_serverStuckPos, base.entity.rigidbody.position) >= num6 * num6)
			{
				_serverTimer.SetTimer(1f);
				_serverStuckPos = base.entity.rigidbody.position;
			}
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				ServerStopWander();
			}
			if (isWandering && !Physics.Raycast(rigidbody.position, Vector3.down, 1.5f, 65536))
			{
				ServerStopWander();
			}
		}
	}

	private void UpdateVelocity(Rigidbody rb, Vector3 fwd, Vector3 targetFwd)
	{
		float num = math.dot(fwd, targetFwd);
		num = (num + 1f) / 2f;
		float num2 = math.lerp(backUpSpeed, speed, num);
		num2 *= _speedMultiplier;
		float num3 = ((!NetworkAggroManagerBase<ModifierManager>.ManagerExists() || !NetworkAggroManagerBase<ModifierManager>.instance.HasFlags(ModifierFlags.Icy)) ? acceleration : icyAcceleration);
		num3 *= math.lerp(1f, 2.5f, (float)base.entity.GetObject<Grabbable>().GetStackCount() / 4f);
		rb.velocity = Vector3.MoveTowards(rb.velocity, targetFwd * num2, num3 * (1f / 60f));
	}

	public void MultiplySpeed(float multiplier)
	{
		_speedMultiplier *= multiplier;
	}

	[Server]
	public void ServerStopWander()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxWander::ServerStopWander()' called when server was not active");
			return;
		}
		_serverTimer.SetTimer(GetRandom().NextFloat(startWanderingMinMaxDuration.x, startWanderingMinMaxDuration.y));
		Network_syncWanderingSeed = 0;
	}

	protected override void OnUpdatePresentation()
	{
		if (base.entity.TryGetObject<Animator>(out var obj))
		{
			obj.SetBool("isWandering", isWandering);
		}
	}

	private void GetInfo(Vector3 pos, Vector3 fwd, bool checkForBoxes, out Vector3 localPos)
	{
		Vector3 dir = Quaternion.AngleAxis(0f - avoidColliderDegrees, Vector3.up) * fwd;
		Vector3 dir2 = Quaternion.AngleAxis(avoidColliderDegrees, Vector3.up) * fwd;
		if (!IsDirBlocked(pos, fwd, checkForBoxes))
		{
			localPos = Vector3.forward * targetOffset;
			return;
		}
		bool flag = IsDirBlocked(pos, dir, checkForBoxes);
		bool flag2 = IsDirBlocked(pos, dir2, checkForBoxes);
		if (flag && flag2)
		{
			localPos = Vector3.back * targetOffset;
		}
		else if (_syncWanderingSeed % 2 == 0)
		{
			if (flag)
			{
				localPos = Vector3.right * targetOffset;
			}
			else
			{
				localPos = Vector3.left * targetOffset;
			}
		}
		else if (flag2)
		{
			localPos = Vector3.left * targetOffset;
		}
		else
		{
			localPos = Vector3.right * targetOffset;
		}
	}

	private bool IsDirBlocked(Vector3 pos, Vector3 dir, bool checkForBoxes)
	{
		if (checkForBoxes)
		{
			int num = Physics.OverlapCapsuleNonAlloc(pos, pos + dir * lookAheadDistance, 0.49f, _colliders, 1075857408);
			for (int i = 0; i < num; i++)
			{
				Collider collider = _colliders[i];
				if (collider.gameObject.layer != 16384 || !collider.TryGetEntity(out var entity) || entity != base.entity)
				{
					return true;
				}
			}
			return false;
		}
		return Physics.OverlapCapsuleNonAlloc(pos, pos + dir * lookAheadDistance, 0.49f, _colliders, 1075841024) != 0;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.matrix = Matrix4x4.Scale(new Vector3(1f, 0f, 1f));
		if (GameUtil.isReady)
		{
			_debugFromPos.y = 0f;
			_debugRandomPos.y = 0f;
			Vector3 position = base.entity.rigidbody.position;
			position.y = 0f;
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(_debugTargetPos, targetRadius);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(position, _debugFromPos + _debugForward);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(position, _debugFromPos + _debugToInfoDir);
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(_debugFromPos, _debugFromPos + _debugTargetDir * 4f);
			Gizmos.DrawSphere(_debugRandomPos, 0.25f);
		}
		else
		{
			Vector3 position2 = base.transform.position;
			position2.y = 0f;
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			Gizmos.DrawWireSphere(position2 + forward * targetOffset, targetRadius);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(position2, position2 + forward * lookAheadDistance);
		}
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (context.type == ActivationContextType.Kicked || context.type == ActivationContextType.Explosion || context.type == ActivationContextType.Impact)
		{
			ServerStopWander();
		}
	}

	public void ServerBoxStackedOn()
	{
		if (stopWhenStackedOn)
		{
			ServerStopWander();
			base.entity.rigidbody.velocity *= stackedOnSpeedMultiplier;
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
			writer.WriteVarInt(_syncWanderingSeed);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncWanderingSeed);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncWanderingSeed, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncWanderingSeed, null, reader.ReadVarInt());
		}
	}
}
