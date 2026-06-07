using System.Collections;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

[DisallowMultipleComponent]
public class RespawnOnDrop : MonoBehaviour
{
	public delegate void RespawnDelegate(RespawnOnDrop respawnOnDrop, ItemBase item);

	public const float STANDARD_ESSENTIAL_RESPAWN_DISTANCE = 200f;

	public const float STANDARD_NON_ESSENTIAL_RESPAWN_DISTANCE = 1000f;

	[Tooltip("Respawn/destroy if further than max distance from both PlayerManager.playerTransform and original localPosition.\nDon't make it smaller than arm's length.")]
	public float maxDistance = 4f;

	public float delayBeforeRespawnOrDestroy = 1f;

	[Tooltip("If disabled, it'll destroy the object when it gets further than max distance")]
	public bool respawnOnDropThroughFloor = true;

	public float localZeroVelocitySquaredThreshold = 0.0001f;

	public bool ignoreDistanceFromSpawnPosition;

	public bool shouldSetDefaultRespawnDistance = true;

	private Transform spawnParent;

	private Transform suggestedSpawnParent;

	private Transform originalSpawnParent;

	private Vector3 spawnLocalPosition;

	private Quaternion spawnLocalRotation;

	private Vector3 originalSpawnLocalPosition;

	private Quaternion originalSpawnLocalRotation;

	private float maxDistanceSquared;

	private bool wentOutOfRange;

	public const float INITIAL_CHECK_DELAY = 0.2f;

	private Collider[] overlaps = new Collider[32];

	private float overlapSphereRadius = 0.1f;

	private LayerMask spawnParentMask;

	private bool isTryingToChangeSpawnParent;

	private Vector3 previousLocalPosition = Vector3.positiveInfinity;

	private ItemBase item;

	private ItemReparentingBase itemReparenting;

	private Coroutine respawnDistanceCheckerCoro;

	private Coroutine respawnOrDestroyCoro;

	private bool checkWhileDisabled;

	private bool initialized;

	public bool OnValidRespawnParent { get; set; }

	public event RespawnDelegate Respawned;

	private void Start()
	{
		StartChecking();
	}

	private void Initialize()
	{
		if (!initialized)
		{
			itemReparenting = GetComponent<ItemReparentingBase>();
			item = GetComponent<ItemBase>();
			if (shouldSetDefaultRespawnDistance)
			{
				float num = (item.BelongsToPlayer() ? 200f : 1000f);
				SetMaxDistance(num);
			}
			spawnParentMask = LayerMask.GetMask("Train_Interior", "Default");
			RecalculateSpawnParent();
			spawnLocalPosition = ((spawnParent != null) ? spawnParent.transform.InverseTransformPoint(base.transform.position) : base.transform.position);
			spawnLocalRotation = ((spawnParent != null) ? (base.transform.rotation * Quaternion.Inverse(spawnParent.rotation)) : base.transform.rotation);
			originalSpawnParent = spawnParent;
			originalSpawnLocalPosition = spawnLocalPosition;
			originalSpawnLocalRotation = spawnLocalRotation;
			SetupListeners(on: true);
			initialized = true;
		}
	}

	private void OnEnable()
	{
		wentOutOfRange = false;
		if (respawnDistanceCheckerCoro == null && initialized)
		{
			StartChecking();
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			if (respawnDistanceCheckerCoro != null && !checkWhileDisabled)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnDistanceCheckerCoro);
				respawnDistanceCheckerCoro = null;
			}
			if (respawnOrDestroyCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnOrDestroyCoro);
				respawnOrDestroyCoro = null;
			}
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && initialized)
		{
			if (respawnDistanceCheckerCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnDistanceCheckerCoro);
				respawnDistanceCheckerCoro = null;
			}
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			item.Grabbed += OnGrabbed;
			itemReparenting.ItemParented += OnItemParented;
		}
		else
		{
			item.Grabbed -= OnGrabbed;
			itemReparenting.ItemParented -= OnItemParented;
		}
	}

	private void OnItemParented(Transform parentedTo)
	{
		TrainCar trainCar = TrainCar.Resolve(parentedTo);
		if ((bool)trainCar)
		{
			TryChangeRespawnParent(trainCar.interior);
		}
		else
		{
			TryChangeRespawnParent(parentedTo);
		}
	}

	private void OnGrabbed(ControlImplBase _)
	{
		if (item.BelongsToPlayer() && (bool)SingletonBehaviour<StorageController>.Instance && !SingletonBehaviour<StorageController>.Instance.IsInStorageWorld(item))
		{
			SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(item);
		}
	}

	private void RecalculateSpawnParent()
	{
		TrainCar trainCar = TrainCar.Resolve(base.gameObject);
		if (trainCar != null && !trainCar.derailed)
		{
			spawnParent = trainCar.interior;
			OnValidRespawnParent = true;
			return;
		}
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, overlapSphereRadius, overlaps, spawnParentMask, QueryTriggerInteraction.Collide);
		for (int i = 0; i < num; i++)
		{
			ItemStaticParent componentInParent = overlaps[i].GetComponentInParent<ItemStaticParent>();
			if ((bool)componentInParent)
			{
				spawnParent = componentInParent.transform;
				OnValidRespawnParent = true;
				return;
			}
		}
		spawnParent = WorldMover.OriginShiftParent;
	}

	public void SetMaxDistance(float desiredMaxDistance)
	{
		maxDistance = desiredMaxDistance;
		maxDistanceSquared = maxDistance * maxDistance;
	}

	public void StartChecking()
	{
		if (respawnDistanceCheckerCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnDistanceCheckerCoro);
		}
		respawnDistanceCheckerCoro = null;
		if (respawnOrDestroyCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnOrDestroyCoro);
		}
		if (!initialized)
		{
			Initialize();
		}
		UpdateSpawnParams();
		if (respawnDistanceCheckerCoro == null)
		{
			respawnDistanceCheckerCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Checker(0.2f));
		}
	}

	public void TryChangeRespawnParent(Transform potentialSpawnParent)
	{
		if (potentialSpawnParent != suggestedSpawnParent || potentialSpawnParent != spawnParent)
		{
			suggestedSpawnParent = potentialSpawnParent;
			isTryingToChangeSpawnParent = true;
			UpdateSpawnParams();
		}
	}

	private void Update()
	{
		if ((bool)item && isTryingToChangeSpawnParent && !item.IsGrabbed())
		{
			TryCalculateRespawnParameters();
		}
	}

	private void TryCalculateRespawnParameters()
	{
		if (previousLocalPosition == Vector3.positiveInfinity)
		{
			previousLocalPosition = base.transform.localPosition;
		}
		else if ((previousLocalPosition - base.transform.localPosition).sqrMagnitude < localZeroVelocitySquaredThreshold)
		{
			spawnParent = suggestedSpawnParent;
			suggestedSpawnParent = null;
			isTryingToChangeSpawnParent = false;
			previousLocalPosition = Vector3.positiveInfinity;
			StartChecking();
		}
		else
		{
			previousLocalPosition = base.transform.localPosition;
		}
	}

	public IEnumerator RespawnOrDestroy(float delay)
	{
		yield return WaitFor.Seconds(delay);
		wentOutOfRange = false;
		var (flag, flag2, _, _) = CheckDistances();
		if (!flag || !flag2)
		{
			respawnOrDestroyCoro = null;
			yield break;
		}
		TrainPhysicsLod trainPhysicsLod = TrainCar.Resolve(item.gameObject)?.GetComponent<TrainPhysicsLod>();
		if (trainPhysicsLod != null)
		{
			trainPhysicsLod.RemoveItem(item);
		}
		if (respawnOnDropThroughFloor)
		{
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody obj in componentsInChildren)
			{
				obj.velocity = Vector3.zero;
				obj.angularVelocity = Vector3.zero;
			}
			if (!item.BelongsToPlayer())
			{
				base.transform.SetParent(spawnParent);
				base.transform.localPosition = spawnLocalPosition;
				base.transform.localRotation = spawnLocalRotation;
				base.gameObject.SetActive(value: true);
				if ((bool)SingletonBehaviour<StorageController>.Instance && SingletonBehaviour<StorageController>.Instance.StorageWorld.ContainsItem(item))
				{
					SingletonBehaviour<StorageController>.Instance.RemoveItemFromWorldStorage(item);
				}
			}
			else
			{
				base.gameObject.SetActive(value: false);
				base.transform.SetParent(WorldMover.OriginShiftParent);
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
				Rigidbody itemRigidbody = item.ItemRigidbody;
				if (itemRigidbody != null)
				{
					itemRigidbody.velocity = Vector3.zero;
					itemRigidbody.angularVelocity = Vector3.zero;
				}
				if ((bool)SingletonBehaviour<StorageController>.Instance)
				{
					SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(item);
				}
			}
			this.Respawned?.Invoke(this, item);
		}
		else
		{
			DV_GameObjectDestructionHandler.RemoveGameObject(base.gameObject);
		}
		respawnOrDestroyCoro = null;
	}

	private IEnumerator Checker(float interval)
	{
		WaitForSeconds pause = WaitFor.Seconds(interval);
		while (true)
		{
			yield return pause;
			if (wentOutOfRange || PlayerManager.PlayerTransform == null)
			{
				continue;
			}
			var (flag, flag2, flag3, flag4) = CheckDistances();
			if (item.ItemRigidbody.isKinematic != flag3 && !item.CabItem.ReceiveForcesFrom && !item.IsSnapped && !flag4 && !LoadingScreenManager.IsLoading)
			{
				if (flag3)
				{
					item.ItemRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				}
				item.ItemRigidbody.isKinematic = flag3;
			}
			if (flag && flag2)
			{
				wentOutOfRange = true;
				if (respawnOrDestroyCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnOrDestroyCoro);
				}
				respawnOrDestroyCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(RespawnOrDestroy(delayBeforeRespawnOrDestroy));
			}
		}
	}

	private (bool farFromSpawn, bool farFromPlayer, bool farFromActiveCamera, bool boundToPlayer) CheckDistances()
	{
		Vector3 position = base.transform.position;
		Vector3 vector = ((spawnParent != null) ? spawnParent.TransformPoint(spawnLocalPosition) : spawnLocalPosition);
		bool flag = this.item.IsBoundToPlayer();
		float num = ((!this.item.IsSnapped) ? (ignoreDistanceFromSpawnPosition ? float.PositiveInfinity : (position - vector).sqrMagnitude) : 0f);
		float num2 = (flag ? 0f : (position - PlayerManager.PlayerTransform.position).sqrMagnitude);
		float num3 = (flag ? 0f : (position - PlayerManager.ActiveCamera.transform.position).sqrMagnitude);
		bool item = num > maxDistanceSquared;
		bool item2 = num2 > maxDistanceSquared;
		bool item3 = num3 > maxDistanceSquared;
		return (farFromSpawn: item, farFromPlayer: item2, farFromActiveCamera: item3, boundToPlayer: flag);
	}

	public void ResetToOriginalSpawnVariables()
	{
		if (initialized)
		{
			isTryingToChangeSpawnParent = false;
			UpdateSpawnParams();
		}
	}

	public void UpdateSpawnParams()
	{
		if (!initialized)
		{
			StartChecking();
			return;
		}
		Transform transform = ((itemReparenting != null) ? itemReparenting.CurrentParent : base.transform.parent);
		TrainCar trainCar = TrainCar.Resolve(transform);
		checkWhileDisabled = trainCar != null && trainCar.derailed && !SingletonBehaviour<StorageController>.Instance.StorageInstalledGadgets.ContainsItem(item);
		bool flag = trainCar != null && !trainCar.derailed;
		ItemStaticParent itemStaticParent = ((transform != null) ? transform.GetComponentInParent<ItemStaticParent>() : null);
		bool flag2 = itemStaticParent != null;
		OnValidRespawnParent = flag || flag2;
		if (OnValidRespawnParent)
		{
			spawnParent = (flag ? trainCar.interior : itemStaticParent.transform);
			spawnLocalPosition = spawnParent.InverseTransformPoint(base.transform.position);
			spawnLocalRotation = base.transform.rotation * Quaternion.Inverse(spawnParent.rotation);
		}
		else if (originalSpawnParent != null)
		{
			spawnParent = originalSpawnParent;
			spawnLocalRotation = originalSpawnLocalRotation;
			spawnLocalPosition = originalSpawnLocalPosition;
		}
		else
		{
			spawnParent = WorldMover.OriginShiftParent;
		}
		ignoreDistanceFromSpawnPosition = !OnValidRespawnParent && item.InventorySpecs.BelongsToPlayer;
		if (!base.gameObject.activeInHierarchy && checkWhileDisabled && respawnDistanceCheckerCoro == null)
		{
			if (respawnOrDestroyCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(respawnOrDestroyCoro);
			}
			respawnOrDestroyCoro = null;
			if (!initialized)
			{
				Initialize();
			}
			respawnDistanceCheckerCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Checker(0.2f));
		}
	}
}
