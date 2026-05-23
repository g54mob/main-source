using Factory.FieldObject;
using Libs;
using UnityEngine;
using UnityEngine.Pool;

namespace Factory
{
	public class LuggagePoolManager : SingletonMonoBehaviour<LuggagePoolManager>
	{
		public enum PoolType
		{
			Stack = 0,
			LinkedList = 1
		}

		public LuggageObjectCtrl luggageObject;

		public PoolType poolType;

		public bool collectionChecks;

		public int maxPoolSize;

		private IObjectPool<LuggageObjectCtrl> m_Pool;

		public IObjectPool<LuggageObjectCtrl> Pool => null;

		private void Awake()
		{
		}

		private LuggageObjectCtrl CreatePooledItem()
		{
			return null;
		}

		private void OnReturnedToPool(LuggageObjectCtrl system)
		{
		}

		private void OnTakeFromPoolLikeAwake(LuggageObjectCtrl system)
		{
		}

		private void OnDestroyPoolObject(LuggageObjectCtrl system)
		{
		}

		public static Luggage Create(Vector3 pos, eLuggage product, string name, LuggageFlag luggageFlag)
		{
			return null;
		}

		public static void Release(Luggage luggage)
		{
		}
	}
}
