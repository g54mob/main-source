using System.Collections.Generic;
using UnityEngine;

namespace QFSW.MOP2
{
	public class MasterObjectPooler : MonoBehaviour
	{
		[Tooltip("Forces the MOP into singleton mode. This means the MOP will be made scene persistent and will not be destroyed when new scenes are loaded.")]
		[SerializeField]
		private bool _singletonMode;

		[Tooltip("Whether release warnings should be logged")]
		[SerializeField]
		private bool _LogReleaseWarnings;

		[SerializeField]
		private ObjectPool[] _pools;

		private readonly Dictionary<string, ObjectPool> _poolTable;

		public static MasterObjectPooler Instance { get; private set; }

		public bool LogReleaseWarnings => false;

		public ObjectPool this[string poolName]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, ObjectPool> PoolTable => null;

		public List<ObjectPool> PoolTablePools => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void DestroyPoolInternal(ObjectPool pool)
		{
		}

		public void AddPool(ObjectPool pool)
		{
		}

		public void AddPool(string poolName, ObjectPool pool)
		{
		}

		public ObjectPool GetPool(string poolName)
		{
			return null;
		}

		public void RemoveAndDestroyPoolInstance(ObjectPool pool)
		{
		}

		public void DestroyAllPoolsAndRuntimeInstances()
		{
		}

		public void DestroyAllPools()
		{
		}

		public void DestroyPool(string poolName)
		{
		}

		public void ReinitStartingPools()
		{
		}

		public GameObject GetObject(string poolName)
		{
			return null;
		}

		public GameObject GetObject(string poolName, Vector3 position)
		{
			return null;
		}

		public GameObject GetObject(string poolName, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public T GetObjectComponent<T>(string poolName) where T : class
		{
			return null;
		}

		public T GetObjectComponent<T>(string poolName, Vector3 position) where T : class
		{
			return null;
		}

		public T GetObjectComponent<T>(string poolName, Vector3 position, Quaternion rotation) where T : class
		{
			return null;
		}

		public void Release(GameObject obj, string poolName)
		{
		}

		public void Release(IEnumerable<GameObject> objs, string poolName)
		{
		}

		public void ReleaseAll(string poolName)
		{
		}

		public void Destroy(GameObject obj)
		{
		}

		public void Destroy(GameObject obj, string poolName)
		{
		}

		public void Destroy(IEnumerable<GameObject> objs, string poolName)
		{
		}

		public void ReleaseAllInAllPools()
		{
		}

		public void Populate(string poolName, int quantity, PopulateMethod method = PopulateMethod.Set)
		{
		}

		public void Purge(string poolName)
		{
		}

		public void PurgeAll()
		{
		}

		public IEnumerable<GameObject> GetAllActiveObjects(string poolName)
		{
			return null;
		}
	}
}
