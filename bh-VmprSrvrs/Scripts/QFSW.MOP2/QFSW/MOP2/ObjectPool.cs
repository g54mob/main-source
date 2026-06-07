using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QFSW.MOP2
{
	[CreateAssetMenu(fileName = "Untitled Pool", menuName = "Master Object Pooler 2/Object Pool", order = 0)]
	public class ObjectPool : ScriptableObject
	{
		[Tooltip("The name of the pool. Used for identification and as the key when using a MasterObjectPooler.")]
		[SerializeField]
		private string _name;

		[Tooltip("The template object to center the pool on. All objects in the pool will be a copy of this object.")]
		[SerializeField]
		private GameObject _template;

		[Tooltip("The default number of objects to create in this pool when initializing it.")]
		[SerializeField]
		private int _defaultSize;

		[Tooltip("The maximum number of objects that can be kept in this pool. If it is exceeded, objects will be destroyed instead of pooled when returned. Set to -1 for no limit.")]
		[SerializeField]
		private int _maxSize;

		[Tooltip("If enabled, object instances will be renamed to ObjectName#XXX where XXX is the instance number. This is useful if you want them all to be uniquely named.")]
		[SerializeField]
		private bool _incrementalInstanceNames;

		[Tooltip("Repopulate the pool with objects when the scene changes to replace objects that were unloaded/destroyed.")]
		[SerializeField]
		private bool _repopulateOnSceneChange;

		private int _instanceCounter;

		private readonly Regex _poolRegex;

		private readonly List<GameObject> _pooledObjects;

		private readonly Dictionary<int, GameObject> _aliveObjects;

		private readonly List<GameObject> _releaseAllBuffer;

		private readonly Dictionary<(int id, Type type), object> _componentCache;

		private static ProfilerMarker _markerGetObject;

		private static readonly ProfilerMarker MarkerRelease;

		private static readonly ProfilerMarker MarkerReleaseAll;

		public bool IncrementalInstanceNames
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string PoolName => null;

		private bool HasMaxSize => false;

		private bool HasPooledObjects => false;

		public bool Initialized { get; private set; }

		public GameObject Template => null;

		public List<GameObject> PooledObjects => null;

		private ObjectPool()
		{
		}

		public static ObjectPool Create(GameObject template, int defaultSize = 0, int maxSize = -1)
		{
			return null;
		}

		public static ObjectPool Create(GameObject template, string name, int defaultSize = 0, int maxSize = -1)
		{
			return null;
		}

		public static ObjectPool CreateAndInitialize(GameObject template, int defaultSize = 0, int maxSize = -1)
		{
			return null;
		}

		public static ObjectPool CreateAndInitialize(GameObject template, string name, int defaultSize = 0, int maxSize = -1)
		{
			return null;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Initialize(bool forceReinitialization = false)
		{
		}

		internal void AutoFillName()
		{
		}

		private void InitializeIPoolable(GameObject go)
		{
		}

		private GameObject CreateNewObject()
		{
			return null;
		}

		private GameObject CreateNewObject(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		private void SwitchNetworking(GameObject obj, bool enable)
		{
		}

		private void CleanseInternal()
		{
		}

		public GameObject GetObject()
		{
			return null;
		}

		public GameObject GetObject(Vector3 position)
		{
			return null;
		}

		public GameObject GetObject(Vector3 position, Quaternion rotation, bool onlineSynchronization = true)
		{
			return null;
		}

		public T GetObjectComponent<T>() where T : class
		{
			return null;
		}

		public T GetObjectComponent<T>(Vector3 position, bool onlineSynchronization = true) where T : class
		{
			return null;
		}

		public T GetObjectComponent<T>(Vector3 position, Quaternion rotation, bool onlineSynchronization = true) where T : class
		{
			return null;
		}

		public T GetObjectComponent<T>(GameObject obj) where T : class
		{
			return null;
		}

		public void Release(GameObject obj)
		{
		}

		public void Release(IEnumerable<GameObject> objs)
		{
		}

		public void ReleaseAll()
		{
		}

		public void Destroy(GameObject obj)
		{
		}

		public void Destroy(IEnumerable<GameObject> objs)
		{
		}

		public void Populate(int quantity, PopulateMethod method = PopulateMethod.Set)
		{
		}

		public void Purge()
		{
		}

		public IEnumerable<GameObject> GetAllActiveObjects()
		{
			return null;
		}

		public Dictionary<int, GameObject> AliveObjects()
		{
			return null;
		}

		public Dictionary<int, GameObject>.Enumerator GetAllActiveObjectsEnumerator()
		{
			return default(Dictionary<int, GameObject>.Enumerator);
		}

		public int GetAliveObjectsCount()
		{
			return 0;
		}

		private void Awake()
		{
		}

		private void OnSceneUnload(Scene scene)
		{
		}
	}
}
