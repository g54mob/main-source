using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameKit.Utilities.ObjectPooling
{
	public class ObjectPool : MonoBehaviour
	{
		private struct DelayedStoreData
		{
			public readonly float StoreTime;

			public readonly bool ParentPooler;

			public DelayedStoreData(float storeTime, bool parentPooler)
			{
				StoreTime = 0f;
				ParentPooler = false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C__CleanupChecks_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ObjectPool _003C_003E4__this;

			private int _003CpoolIndex_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C__CleanupChecks_003Ed__12(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C__Reset_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ObjectPool _003C_003E4__this;

			public bool destroyActive;

			private WaitForEndOfFrame _003CendOfFrame_003E5__2;

			private List<GameObject> _003Cobjects_003E5__3;

			private int _003Ci_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C__Reset_003Ed__13(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Tooltip("Time to wait before destroying object pools with no activity as well pool entries which haven't been used recently. Use -1f to disable this feature.")]
		[SerializeField]
		private float _dataExpirationDelay;

		private static ObjectPool _instance;

		private Transform _collector;

		private List<PoolData> _pools;

		private Dictionary<string, Transform> _categoryChildren;

		private Dictionary<GameObject, PoolData> _poolPrefabs;

		private Dictionary<GameObject, PoolData> _activeObjects;

		private Dictionary<GameObject, DelayedStoreData> _delayedStoreObjects;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003C__CleanupChecks_003Ed__12))]
		private IEnumerator __CleanupChecks()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C__Reset_003Ed__13))]
		public IEnumerator __Reset(bool destroyActive)
		{
			return null;
		}

		private void DestroyPool(PoolData poolData, bool removeFromList)
		{
		}

		private PoolData ReturnPoolData(GameObject prefab)
		{
			return null;
		}

		private void SetGameObjectPositionRotation(GameObject result, Vector3 position, Quaternion rotation)
		{
		}

		public static GameObject Retrieve(GameObject poolObject)
		{
			return null;
		}

		private GameObject RetrieveInternal(GameObject poolObject)
		{
			return null;
		}

		public static GameObject Retrieve(GameObject poolObject, Transform parent, bool instantiateInWorldSpace = true)
		{
			return null;
		}

		public GameObject RetrieveInternal(GameObject poolObject, Transform parent, bool instantiateInWorldSpace = true)
		{
			return null;
		}

		public static GameObject Retrieve(GameObject poolObject, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		private GameObject RetrieveInternal(GameObject poolObject, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public GameObject Retrieve(GameObject poolObject, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}

		public static T Retrieve<T>(GameObject prefab)
		{
			return default(T);
		}

		private T RetrieveInternal<T>(GameObject prefab)
		{
			return default(T);
		}

		public static T Retrieve<T>(GameObject prefab, Transform parent, bool instantiateInWorldSpace = true)
		{
			return default(T);
		}

		private T RetrieveInternal<T>(GameObject prefab, Transform parent, bool instantiateInWorldSpace = true)
		{
			return default(T);
		}

		public static T Retrieve<T>(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			return default(T);
		}

		private T RetrieveInternal<T>(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			return default(T);
		}

		public static T Retrieve<T>(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			return default(T);
		}

		private T RetrieveInternal<T>(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			return default(T);
		}

		private GameObject FinalizeRetrieve(GameObject result, PoolData pool)
		{
			return null;
		}

		public static void Store(GameObject instantiatedObject, float delay, bool parentPooler = true)
		{
		}

		private void StoreInternal(GameObject instantiatedObject, float delay, bool parentPooler = true)
		{
		}

		public static void Store(GameObject instantiatedObject, bool parentPooler = true)
		{
		}

		private void StoreInternal(GameObject instantiatedObject, bool parentPooler = true)
		{
		}

		private void MakeCollector()
		{
		}

		private GameObject ReturnPooledObject(GameObject prefab, out PoolData pool)
		{
			pool = null;
			return null;
		}

		private PoolData CreatePool(GameObject prefab)
		{
			return null;
		}

		private void AddToPool(GameObject instantiatedObject, PoolData pool, bool parentPooler = true)
		{
		}

		private void ParentPooler(GameObject poolObject, bool worldPositionStays)
		{
		}
	}
}
