using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Booststrip : EntityBehaviourBase
{
	private struct BoxEntry
	{
		public Entity box;

		public int debounceUntilFrame;
	}

	[Header("Boxes")]
	[Min(0f)]
	public float boxForceAmount = 20f;

	[Min(0f)]
	public float boxForceUpwardsModifier = 30f;

	public BoxCollider boostBounds;

	private Transform _transform;

	private Bounds _bounds;

	private Timer _debouncePlayerTimer;

	private List<BoxEntry> _boxEntries = new List<BoxEntry>();

	private HashSet<Entity> _boxSet = new HashSet<Entity>();

	private static Collider[] _colliders = new Collider[16];

	private static List<Entity> _entities = new List<Entity>();

	private const float DEBOUNCE_DURATION = 1f;

	private const float VELOCITY_CHECK = 0.5f;

	private const float VELOCITY_CHECK_SQR = 0.25f;

	public bool tutorialBoostStripUsed { get; set; }

	protected override void OnEntityCreated()
	{
		_transform = boostBounds.transform;
		_bounds = new Bounds(boostBounds.center, boostBounds.size);
	}

	protected override void OnUpdateSimulation()
	{
		if (base.entity.HasStruct<MarkedForDeathComp>())
		{
			return;
		}
		Vector3 forward = _transform.forward;
		_debouncePlayerTimer.DecrementTimer();
		if (_debouncePlayerTimer.IsFinished() && GameUtil.TryGetLocalPlayer(out var player))
		{
			Vector3 point = _transform.InverseTransformPoint(player.transform.position);
			if (_bounds.Contains(point))
			{
				_debouncePlayerTimer.SetTimer(1f);
				player.GetObject<NitroController>().LocalPlayerActivateNitro();
				player.transform.rotation = Quaternion.LookRotation(base.transform.forward, Vector3.up);
				Rigidbody rigidbody = player.GetObject<Rigidbody>();
				rigidbody.velocity = base.transform.forward * rigidbody.velocity.magnitude;
				tutorialBoostStripUsed = true;
				if (GameUtil.isTutorial)
				{
					player.GetObject<PlayerStress>().RequestStopCrashOut();
				}
			}
		}
		for (int i = 0; i < _boxEntries.Count; i++)
		{
			BoxEntry boxEntry = _boxEntries[i];
			if (boxEntry.debounceUntilFrame < TimeUtil.frame)
			{
				_boxSet.Remove(boxEntry.box);
				_boxEntries.RemoveAtSwapBack(i--);
			}
		}
		Vector3 lossyScale = _transform.lossyScale;
		int num = Physics.OverlapBoxNonAlloc(_transform.TransformPoint(_bounds.center), new Vector3(lossyScale.x * _bounds.size.x / 2f, lossyScale.y * _bounds.size.y / 2f, lossyScale.z * _bounds.size.z / 2f), _colliders, _transform.rotation, 16384);
		if (num <= 0)
		{
			return;
		}
		Vector3 vector = forward;
		vector = Quaternion.AngleAxis(boxForceUpwardsModifier, MathUtil.GetOrtho(vector, Vector3.up)) * vector;
		Vector3 force = vector * boxForceAmount;
		for (int j = 0; j < num; j++)
		{
			if (!_colliders[j].TryGetEntity(out var e))
			{
				continue;
			}
			Vector3 velocity = e.rigidbody.velocity;
			if (!(velocity.sqrMagnitude < 0.25f) && !(math.dot(velocity, forward) < 0f))
			{
				continue;
			}
			if (e.TryGetObject<Grabbable>(out var obj))
			{
				if (!e.rigidbody.isKinematic)
				{
					_entities.Clear();
					obj.GetStack(_entities);
					for (int k = 0; k < _entities.Count; k++)
					{
						BoostNonPlayerEntity(_entities[k], force);
					}
					if (base.isServer)
					{
						obj.ServerBreakEntireStack();
					}
				}
			}
			else
			{
				BoostNonPlayerEntity(e, force);
			}
		}
	}

	private void BoostNonPlayerEntity(Entity e, Vector3 force)
	{
		if (!_boxSet.Contains(e))
		{
			e.rigidbody.velocity = Vector3.zero;
			e.rigidbody.AddForce(force, ForceMode.VelocityChange);
			BoxEntry item = new BoxEntry
			{
				box = e,
				debounceUntilFrame = TimeUtil.frame + TimeUtil.FramesForTime(1f)
			};
			_boxEntries.Add(item);
			_boxSet.Add(e);
		}
	}
}
