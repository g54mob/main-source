using DG.Tweening;
using Factory.FieldObject;
using Libs;
using UnityEngine;
using UnityEngine.Pool;

namespace Factory
{
	public class BillboardTextEffectManager : SingletonMonoBehaviour<BillboardTextEffectManager>
	{
		public enum PoolType
		{
			Stack = 0,
			LinkedList = 1
		}

		public BillboardTextEffectCtrl pointUpEffect;

		public float pointUpDuration;

		public Ease pointUpEase;

		public PoolType poolType;

		public bool collectionChecks;

		public int maxPoolSize;

		private IObjectPool<BillboardTextEffectCtrl> m_Pool;

		public IObjectPool<BillboardTextEffectCtrl> Pool => null;

		private void Awake()
		{
		}

		private BillboardTextEffectCtrl CreatePooledItem()
		{
			return null;
		}

		private void OnReturnedToPool(BillboardTextEffectCtrl system)
		{
		}

		private void OnTakeFromPool(BillboardTextEffectCtrl system)
		{
		}

		private void OnDestroyPoolObject(BillboardTextEffectCtrl system)
		{
		}

		private static BillboardTextEffectCtrl Get(Vector3 luggagePos, bool worldPositionStays)
		{
			return null;
		}

		public static void PlayExpPointUp(Vector3 luggagePos, bool worldPositionStays, int exp)
		{
		}

		public static void PlayManaPointUp(Vector3 luggagePos, bool worldPositionStays, int mana, float effectScale = 1f, float effectCharacterSpacing = 0f, string upColor = "white", string downColor = "white")
		{
		}

		public static void PlayLostHuman(Vector3 luggagePos, bool worldPositionStays, float effectScale = 1f, float effectCharacterSpacing = 0f, string downColor = "white")
		{
		}

		public static void PlaySpiritPointUp(Vector3 luggagePos, bool worldPositionStays, int spirit)
		{
		}

		public static void PlayProductNumberPointUp(Vector3 luggagePos, bool worldPositionStays, int up)
		{
		}

		public static void PlayGetItem(Vector3 luggagePos, bool worldPositionStays, int itemNum)
		{
		}
	}
}
