using System;
using System.Collections;
using System.Linq;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public abstract class StorageAccessPointBase : MonoBehaviour
{
	private const float ACTIVATION_DISTANCE = 2500f;

	private const float DEACTIVATION_DISTANCE = 4900f;

	private const float DISTANCE_CHECK_DELAY = 1.5f;

	public Transform distanceReferenceTransform;

	[NonSerialized]
	public StorageBase storage;

	public bool shouldCheckForActivation = true;

	private Coroutine DistanceCheckerCoro;

	private bool initialized;

	public abstract StorageType AccessPointStorageType { get; }

	public event Action<StorageAccessPointBase> PlayerInActivationRange;

	public event Action<StorageAccessPointBase> PlayerInDeactivationRange;

	private void OnEnable()
	{
		StartCoroutine(Init());
		SingletonBehaviour<StorageController>.Instance.RegisterStorageAccessPoint(this);
	}

	protected virtual void Start()
	{
		storage = SingletonBehaviour<StorageController>.Instance.allStorages.FirstOrDefault((StorageBase s) => s.storageType == AccessPointStorageType);
		if (storage == null)
		{
			Debug.LogError("Storage not found for storage access point " + base.transform.name + ". Disabling self.", this);
			base.enabled = false;
		}
		else if (distanceReferenceTransform == null)
		{
			distanceReferenceTransform = base.transform;
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			DistanceCheckerCoro = null;
			SingletonBehaviour<StorageController>.Instance.UnregisterStorageAccessPoint(this);
		}
	}

	private IEnumerator Init()
	{
		if (AccessPointStorageType == StorageType.Inventory)
		{
			yield break;
		}
		if (!initialized)
		{
			while (PlayerManager.PlayerTransform == null || !SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
			{
				yield return null;
			}
			initialized = true;
		}
		if (DistanceCheckerCoro != null)
		{
			StopCoroutine(DistanceCheckerCoro);
		}
		DistanceCheckerCoro = StartCoroutine(DistanceChecker());
	}

	private IEnumerator DistanceChecker()
	{
		while (true)
		{
			yield return WaitFor.Seconds(1.5f);
			float sqrMagnitude = (PlayerManager.PlayerTransform.position - base.transform.position).sqrMagnitude;
			if (!shouldCheckForActivation && sqrMagnitude > 4900f)
			{
				yield return WaitFor.Seconds(0.3f);
				this.PlayerInDeactivationRange?.Invoke(this);
				shouldCheckForActivation = true;
			}
			else if (shouldCheckForActivation && sqrMagnitude < 2500f)
			{
				this.PlayerInActivationRange?.Invoke(this);
				shouldCheckForActivation = false;
			}
		}
	}
}
