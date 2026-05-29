using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Pool
{
	[ExecuteInEditMode]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPool#LeanGameObjectPool")]
	[AddComponentMenu("Lean/Pool/Lean GameObject Pool")]
	public class LeanGameObjectPool : MonoBehaviour, ISerializationCallbackReceiver
	{
		[Serializable]
		public class Delay
		{
			public GameObject Clone;

			public float Life;
		}

		public enum NotificationType
		{
			None = 0,
			SendMessage = 1,
			BroadcastMessage = 2,
			IPoolable = 3,
			BroadcastIPoolable = 4
		}

		public enum StrategyType
		{
			ActivateAndDeactivate = 0,
			DeactivateViaHierarchy = 1
		}

		public static LinkedList<LeanGameObjectPool> Instances;

		private LinkedListNode<LeanGameObjectPool> instancesNode;

		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private NotificationType notification;

		[SerializeField]
		private StrategyType strategy;

		[SerializeField]
		private int preload;

		[SerializeField]
		private int capacity;

		[SerializeField]
		private bool recycle;

		[SerializeField]
		private bool persist;

		[SerializeField]
		private bool stamp;

		[SerializeField]
		private bool warnings;

		[SerializeField]
		private List<GameObject> spawnedClonesList;

		private HashSet<GameObject> spawnedClonesHashSet;

		[SerializeField]
		private List<GameObject> despawnedClones;

		[SerializeField]
		private List<Delay> delays;

		[SerializeField]
		private Transform deactivatedChild;

		private static Dictionary<GameObject, LeanGameObjectPool> prefabMap;

		private static List<IPoolable> tempPoolables;

		public GameObject Prefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NotificationType Notification
		{
			get
			{
				return default(NotificationType);
			}
			set
			{
			}
		}

		public StrategyType Strategy
		{
			get
			{
				return default(StrategyType);
			}
			set
			{
			}
		}

		public int Preload
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Capacity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Recycle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Persist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Stamp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Warnings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Transform DeactivatedChild => null;

		public int Spawned => 0;

		public int Despawned => 0;

		public int Total => 0;

		public static bool TryFindPoolByPrefab(GameObject prefab, ref LeanGameObjectPool foundPool)
		{
			return false;
		}

		public static bool TryFindPoolByClone(GameObject clone, ref LeanGameObjectPool pool)
		{
			return false;
		}

		public void Spawn()
		{
		}

		public void Spawn(Vector3 position)
		{
		}

		public GameObject Spawn(Transform parent, bool worldPositionStays = false)
		{
			return null;
		}

		public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return null;
		}

		public bool TrySpawn(ref GameObject clone, Transform parent, bool worldPositionStays = false)
		{
			return false;
		}

		public bool TrySpawn(ref GameObject clone, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return false;
		}

		public bool TrySpawn(ref GameObject clone)
		{
			return false;
		}

		public bool TrySpawn(ref GameObject clone, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			return false;
		}

		[ContextMenu("Despawn Oldest")]
		public void DespawnOldest()
		{
		}

		private bool TryDespawnOldest(ref GameObject clone, bool registerDespawned)
		{
			return false;
		}

		[ContextMenu("Despawn All")]
		public void DespawnAll()
		{
		}

		public void DespawnAll(bool cleanLinks)
		{
		}

		public void Despawn(GameObject clone, float t = 0f)
		{
		}

		public void Detach(GameObject clone, bool cleanLinks = true)
		{
		}

		[ContextMenu("Preload One More")]
		public void PreloadOneMore()
		{
		}

		[ContextMenu("Preload All")]
		public void PreloadAll()
		{
		}

		[ContextMenu("Clean")]
		public void Clean()
		{
		}

		public void GetClones(List<GameObject> gameObjects, bool addSpawnedClones = true, bool addDespawnedClones = true)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		private void RegisterPrefab()
		{
		}

		private void UnregisterPrefab()
		{
		}

		private void DespawnWithDelay(GameObject clone, float t)
		{
		}

		private void TryDespawn(GameObject clone)
		{
		}

		private void DespawnNow(GameObject clone, bool register = true)
		{
		}

		private GameObject CreateClone(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			return null;
		}

		private GameObject DoInstantiate(GameObject prefab, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			return null;
		}

		private void SpawnClone(GameObject clone, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
		}

		private void InvokeOnSpawn(GameObject clone)
		{
		}

		private void InvokeOnDespawn(GameObject clone)
		{
		}

		private void MergeSpawnedClonesToList()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
