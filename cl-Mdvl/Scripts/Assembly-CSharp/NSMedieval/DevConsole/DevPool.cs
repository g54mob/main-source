using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public static class DevPool
	{
		private class Pool
		{
			private int nextId = 1;

			private Stack<GameObject> inactive;

			private GameObject prefab;

			public Pool(GameObject prefab, int initialQty = 1)
			{
				this.prefab = prefab;
				inactive = new Stack<GameObject>(initialQty);
			}

			public GameObject Spawn()
			{
				GameObject gameObject;
				if (inactive.Count == 0)
				{
					gameObject = Object.Instantiate(prefab);
					gameObject.name = prefab.name + " (" + nextId++ + ")";
					gameObject.AddComponent<PoolMember>().MyPool = this;
				}
				else
				{
					gameObject = inactive.Pop();
					if (gameObject == null)
					{
						return Spawn();
					}
				}
				gameObject.SetActive(value: true);
				return gameObject;
			}

			public void Destroy(GameObject obj)
			{
				obj.SetActive(value: false);
				inactive.Push(obj);
			}
		}

		private class PoolMember : MonoBehaviour
		{
			private Pool pool;

			public Pool MyPool
			{
				get
				{
					return pool;
				}
				set
				{
					pool = value;
				}
			}
		}

		private static Dictionary<GameObject, Pool> pools;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			pools = null;
		}

		public static GameObject Spawn(GameObject prefab)
		{
			Init(prefab);
			return pools[prefab].Spawn();
		}

		public static void DeSpawn(GameObject obj)
		{
			PoolMember component = obj.GetComponent<PoolMember>();
			if (component == null)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DevPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Object '");
					messageBuilder.AppendFormatted(obj.name);
					messageBuilder.AppendLiteral("' wasn't spawned from a pool. Destroying it instead.");
				}
				Log.Debug(messageBuilder);
				Object.Destroy(obj);
			}
			else
			{
				component.MyPool.Destroy(obj);
			}
		}

		public static void Preload(GameObject prefab, int qty = 1)
		{
			Init(prefab, qty);
			GameObject[] array = new GameObject[qty];
			for (int i = 0; i < qty; i++)
			{
				array[i] = Spawn(prefab);
			}
			for (int j = 0; j < qty; j++)
			{
				DeSpawn(array[j]);
			}
		}

		private static void Init(GameObject prefab = null, int qty = 1)
		{
			if (pools == null)
			{
				pools = new Dictionary<GameObject, Pool>();
			}
			if (prefab != null && !pools.ContainsKey(prefab))
			{
				pools[prefab] = new Pool(prefab, qty);
			}
		}
	}
}
