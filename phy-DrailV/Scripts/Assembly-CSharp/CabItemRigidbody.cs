using System.Collections;
using DV;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.Utils;
using UnityEngine;

[DisallowMultipleComponent]
public class CabItemRigidbody : MonoBehaviour
{
	public bool receiveForces = true;

	public bool allowPlayerRotationXAxis = true;

	public bool allowPlayerRotationYAxis = true;

	protected Rigidbody rb;

	protected ItemBase item;

	protected Vector3 prevAppliedVelocity = Vector3.zero;

	private float COLLISION_DETECTION_CHANGE_THRESHOLD = 0.0625f;

	private bool allowCollisionDetectionChange;

	private bool alreadySubscribedToPause;

	protected bool assumeIsPaused;

	private Coroutine UnpauseCoro;

	public Rigidbody ReceiveForcesFrom { get; protected set; }

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		item = GetComponent<ItemBase>();
		allowCollisionDetectionChange = item != null;
		if (ShouldAddRespawnOnDrop())
		{
			Item specItem = item.SpecItem;
			RespawnOnDrop respawnOnDrop = base.gameObject.AddComponent<RespawnOnDrop>();
			respawnOnDrop.respawnOnDropThroughFloor = specItem.respawnOnDropThroughFloor;
			if (specItem.overrideDefaultRespawnRange)
			{
				respawnOnDrop.shouldSetDefaultRespawnDistance = false;
				respawnOnDrop.SetMaxDistance(specItem.respawnDistanceRange);
			}
		}
	}

	protected virtual void OnDestroy()
	{
		SetupPauseListeners(on: false);
	}

	private void SetupPauseListeners(bool on)
	{
		if (UnloadWatcher.isUnloading)
		{
			return;
		}
		if (on)
		{
			if (!alreadySubscribedToPause)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnPaused;
				alreadySubscribedToPause = true;
			}
		}
		else
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnGameUnPaused;
			alreadySubscribedToPause = false;
		}
	}

	private void OnGamePaused()
	{
		assumeIsPaused = true;
		if (UnpauseCoro != null)
		{
			StopCoroutine(UnpauseCoro);
			UnpauseCoro = null;
		}
	}

	private void OnGameUnPaused()
	{
		if (base.gameObject.activeInHierarchy)
		{
			if (UnpauseCoro != null)
			{
				StopCoroutine(UnpauseCoro);
			}
			UnpauseCoro = StartCoroutine(DelayedUnpause());
		}
		else
		{
			assumeIsPaused = false;
		}
	}

	private IEnumerator DelayedUnpause()
	{
		yield return null;
		assumeIsPaused = false;
		UnpauseCoro = null;
	}

	protected void Init()
	{
		ReceiveForcesFrom = TrainCar.Resolve(base.gameObject).GetComponent<Rigidbody>();
		SetupPauseListeners(ReceiveForcesFrom != null);
	}

	protected virtual bool ShouldAddRespawnOnDrop()
	{
		return true;
	}

	public void SetupTrainReceivingForces(Rigidbody receiveForcesFrom)
	{
		if (receiveForces && receiveForcesFrom != null)
		{
			prevAppliedVelocity = receiveForcesFrom.velocity;
			ReceiveForcesFrom = receiveForcesFrom;
			SetupPauseListeners(on: true);
		}
		else
		{
			prevAppliedVelocity = Vector3.zero;
			ReceiveForcesFrom = null;
			SetupPauseListeners(on: false);
		}
	}

	private void FixedUpdate()
	{
		if (!assumeIsPaused)
		{
			if (receiveForces && (bool)ReceiveForcesFrom)
			{
				rb.AddForce(prevAppliedVelocity - ReceiveForcesFrom.velocity, ForceMode.VelocityChange);
				prevAppliedVelocity = ReceiveForcesFrom.velocity;
			}
			if (allowCollisionDetectionChange)
			{
				TryChangeCollisionDetectionMode(rb.velocity);
			}
		}
	}

	private void TryChangeCollisionDetectionMode(Vector3 velocity)
	{
		if (item.IsGrabbedOrHoverScrolled())
		{
			CollisionDetectionMode collisionDetectionMode = (rb.isKinematic ? CollisionDetectionMode.ContinuousSpeculative : CollisionDetectionMode.ContinuousDynamic);
			if (rb.collisionDetectionMode != collisionDetectionMode)
			{
				rb.collisionDetectionMode = collisionDetectionMode;
			}
		}
		else
		{
			CollisionDetectionMode collisionDetectionMode2 = ((velocity.sqrMagnitude > COLLISION_DETECTION_CHANGE_THRESHOLD) ? CollisionDetectionMode.ContinuousSpeculative : CollisionDetectionMode.Discrete);
			if (rb.collisionDetectionMode != collisionDetectionMode2)
			{
				rb.collisionDetectionMode = collisionDetectionMode2;
			}
		}
	}

	public Rigidbody GetRigidbody()
	{
		return rb;
	}
}
