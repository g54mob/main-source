using System;
using DV.Utils;
using UnityEngine;

[ExecuteBefore(typeof(TeleportPointerController))]
public class TrainCarInteriorPhysics : MonoBehaviour
{
	[NonSerialized]
	public Rigidbody interiorRb;

	[NonSerialized]
	public bool syncColliders;

	private Transform interior;

	private TrainCar car;

	public void OnCreated(TrainCar car, Transform interior)
	{
		this.interior = interior;
		this.car = car;
		base.enabled = false;
	}

	public void Inititalize()
	{
		if (!car.isStationary)
		{
			base.enabled = true;
		}
		else
		{
			base.enabled = false;
		}
		SetupListeners(on: true);
	}

	public void Deinititalize()
	{
		base.enabled = false;
		SetupListeners(on: false);
	}

	private void OnCarMovementStateChanged(bool isMoving)
	{
		base.enabled = isMoving;
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
			}
			car.MovementStateChanged += OnCarMovementStateChanged;
		}
		else
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
			}
			car.MovementStateChanged -= OnCarMovementStateChanged;
		}
	}

	private void OnWorldMoved(WorldMover _, Vector3 moveVector)
	{
		interior.position = base.transform.position;
	}

	public void SyncPosition()
	{
		interior.position = base.transform.position;
		interior.rotation = base.transform.rotation;
		if (syncColliders)
		{
			interiorRb.position = interior.position;
			interiorRb.rotation = interior.rotation;
		}
	}

	private void LateUpdate()
	{
		SyncPosition();
	}
}
