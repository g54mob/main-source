using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ObjectPoolingController : MonoBehaviour
{
	public enum ObjectLoadRange
	{
		veryClose = 0,
		close = 1,
		medium = 2,
		far = 3,
		veryFar = 4,
		maximum = 5
	}

	[Serializable]
	public class ObjectLoadRangeConfig
	{
		public ObjectLoadRange range;

		public float loadDistance;
	}

	[Tooltip("Spawn object gradually instead of all at once")]
	[Header("Settings")]
	public bool useGradualSpawning;

	[EnableIf("useGradualSpawning")]
	public int loadNewObjectPerFrame;

	[EnableIf("useGradualSpawning")]
	public int loadPooledObjectPerFrame;

	[Tooltip("Store uneeded objects in a list ready to be re-used")]
	public bool usePooling;

	[EnableIf("usePooling")]
	[Tooltip("The maximum number of unrendered but loaded interactables to keep in the object pool.")]
	public int maximumInteractablePoolCache;

	[Tooltip("Use range for loading in objects")]
	public bool useRange;

	[ReorderableList]
	public List<ObjectLoadRangeConfig> loadRangeConfig;

	[EnableIf("useRange")]
	public int maximumRangeCheckingPerFrame;

	[Tooltip("Enable room loading thresholds: When a certain number of rooms are loaded, unload uneeded ones down to a certain cached number")]
	[Header("Rooms")]
	public bool roomCacheLimit;

	[EnableIf("roomCacheLimit")]
	[Tooltip("Maximum number of rooms that are loaded at once before oldest is unloaded")]
	public int maxRoomCache;

	[Tooltip("Enables attempts to spread room loading across multiple frames; may not always be possible")]
	public bool allowGradualRoomLoading;

	[Tooltip("Rooms loaded per frame if they are not immeditaley needed")]
	[EnableIf("allowGradualRoomLoading")]
	public int roomsLoadedPerFrame;

	[Header("Stats")]
	[ReadOnly]
	public int interactablesLoaded;

	[ReadOnly]
	public int interactablesToLoadCount;

	[ReadOnly]
	public int interactablesRangeCount;

	[NonSerialized]
	public float updateObjectRangesTimer;

	[ReadOnly]
	[Space(7f)]
	public int furntiureCheckCount;

	[ReadOnly]
	public int furnitureToLoadCount;

	[ReadOnly]
	public int furnitureRangeCount;

	[ReadOnly]
	[Space(7f)]
	public int interactablesCurrentlyPooled;

	[ReadOnly]
	public int interactableInstancesSaved;

	[ReadOnly]
	public float interactableFullPercentage;

	[Space(7f)]
	[ReadOnly]
	public int roomsLoaded;

	[ReadOnly]
	public int roomStuffToLoad;

	public Dictionary<int, float> loadRanges;

	public List<Interactable> interactableRangeToLoadList;

	[NonSerialized]
	public List<Interactable> interactableRangeToEnableDisableList;

	public HashSet<Interactable> interactableLoadList;

	private List<FurnitureLocation> furnitureRangeToLoadList;

	[NonSerialized]
	public HashSet<FurnitureLocation> furnitureRangeToEnableDisableList;

	public Dictionary<InteractablePreset, HashSet<Interactable>> interactablePool;

	private HashSet<Interactable> entirePoolReference;

	private HashSet<FurnitureLocation> furnitureCheckingPool;

	public HashSet<NewRoom> roomStuffQueuedToLoad;

	private Action UpdateObjectRange;

	private static ObjectPoolingController _instance;

	public static ObjectPoolingController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void LateUpdate()
	{
	}

	private void ExecuteInteractableCheckingPool(int maxPooledLoops, int maxNewObjectLoops)
	{
	}

	private void ExecuteFurnitureCheckingPool(int maxLoops)
	{
	}

	public void MarkAsToLoad(Interactable interactable)
	{
	}

	public void MarkAsNotNeeded(Interactable interactable)
	{
	}

	public void MarkAsToLoad(FurnitureLocation furniture, bool forceSpawnImmediate = false)
	{
	}

	public void MarkAsNotNeeded(FurnitureLocation furniture)
	{
	}

	public void UpdateObjectRanges()
	{
	}

	public void ExecuteUpdateObjectRanges()
	{
	}

	public void ExecuteUpdateObjectRanges(bool forceImmediateSpawning = false)
	{
	}

	public bool SpawnRangeCheck(Interactable interactable, out float distance)
	{
		distance = default(float);
		return false;
	}

	public bool SpawnRangeCheck(FurnitureLocation furniture, out float distance)
	{
		distance = default(float);
		return false;
	}

	public GameObject GetInteractableObject(Interactable interactable, out bool wasPooled, out bool isSelf)
	{
		wasPooled = default(bool);
		isSelf = default(bool);
		return null;
	}

	public void RemoveFromPool(Interactable interactable)
	{
	}

	public void PoolInteractable(Interactable interactable)
	{
	}

	public void MarkRoomStuffToLoad(NewRoom room)
	{
	}

	public void MarkRoomStuffNotNeeded(NewRoom room)
	{
	}

	private void ExecuteRoomStuffPool(int maxPerFrame)
	{
	}
}
