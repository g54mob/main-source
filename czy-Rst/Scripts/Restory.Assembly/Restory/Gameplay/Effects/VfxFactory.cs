using Restory.Data.Effects;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Effects
{
	public class VfxFactory
	{
		private readonly VfxEffectsDatabase vfxEffectsDatabase;

		private UnityEngine.Pool.ObjectPool<ParticleSystem> placementEffectsPool;

		private UnityEngine.Pool.ObjectPool<ParticleSystem> sootCleaningEffectsPool;

		private UnityEngine.Pool.ObjectPool<ParticleSystem> solderingEffectsPool;

		private UnityEngine.Pool.ObjectPool<ParticleSystem> moneyEffectsPool;

		private UnityEngine.Pool.ObjectPool<CheckDeviceEffect> checkDeviceEffectsPool;

		public VfxFactory(VfxEffectsDatabase vfxEffectsDatabase)
		{
			this.vfxEffectsDatabase = vfxEffectsDatabase;
		}

		public void Init(Transform vfxParent)
		{
			InitPlacementEffects(vfxParent, 2, 5);
			InitSootCleaningEffects(vfxParent, 5, 20);
			InitSolderingEffects(vfxParent, 5, 20);
			InitCheckDeviceEffects(vfxParent, 2, 5);
			InitMoneyEffects(vfxParent, 2, 5);
		}

		public ParticleSystem GetPlacementEffect(Transform target)
		{
			ParticleSystem particleSystem = placementEffectsPool.Get();
			particleSystem.transform.SetPositionAndRotation(target.position, target.rotation);
			particleSystem.transform.localScale = target.localScale;
			return particleSystem;
		}

		public void ReleasePlacementEffect(ParticleSystem effect)
		{
			placementEffectsPool.Release(effect);
		}

		private void InitPlacementEffects(Transform vfxParent, int initialPoolSize, int maxPoolSize)
		{
			InitObjectPool(vfxEffectsDatabase.PlacementVfxPrefab, ref placementEffectsPool, vfxParent, initialPoolSize, maxPoolSize);
		}

		public ParticleSystem GetSootCleaningEffect(Transform target)
		{
			ParticleSystem particleSystem = sootCleaningEffectsPool.Get();
			particleSystem.transform.SetPositionAndRotation(target.position, target.rotation);
			return particleSystem;
		}

		public void ReleaseSootCleaningEffect(ParticleSystem effect)
		{
			sootCleaningEffectsPool.Release(effect);
		}

		private void InitSootCleaningEffects(Transform vfxParent, int initialPoolSize, int maxPoolSize)
		{
			InitObjectPool(vfxEffectsDatabase.SootCleaningVfxPrefab, ref sootCleaningEffectsPool, vfxParent, initialPoolSize, maxPoolSize);
		}

		public ParticleSystem GetSolderingEffect(Transform target)
		{
			ParticleSystem particleSystem = solderingEffectsPool.Get();
			particleSystem.transform.SetPositionAndRotation(target.position, target.rotation);
			return particleSystem;
		}

		public void ReleaseSolderingEffect(ParticleSystem effect)
		{
			solderingEffectsPool.Release(effect);
		}

		private void InitSolderingEffects(Transform vfxParent, int initialPoolSize, int maxPoolSize)
		{
			InitObjectPool(vfxEffectsDatabase.SolderingVfxPrefab, ref solderingEffectsPool, vfxParent, initialPoolSize, maxPoolSize);
		}

		public CheckDeviceEffect GetCheckDeviceEffect(Transform target)
		{
			CheckDeviceEffect checkDeviceEffect = checkDeviceEffectsPool.Get();
			checkDeviceEffect.transform.SetPositionAndRotation(target.position, target.rotation);
			checkDeviceEffect.transform.localScale = target.localScale;
			return checkDeviceEffect;
		}

		public void ReleaseCheckDeviceEffect(CheckDeviceEffect effect)
		{
			checkDeviceEffectsPool.Release(effect);
		}

		private void InitCheckDeviceEffects(Transform vfxParent, int initialPoolSize, int maxPoolSize)
		{
			InitObjectPool(vfxEffectsDatabase.CheckDeviceVfxPrefab, ref checkDeviceEffectsPool, vfxParent, initialPoolSize, maxPoolSize);
		}

		public ParticleSystem GetMoneyEffect(Transform target)
		{
			ParticleSystem particleSystem = moneyEffectsPool.Get();
			particleSystem.transform.SetPositionAndRotation(target.position, target.rotation);
			return particleSystem;
		}

		public void ReleaseMoneyEffect(ParticleSystem effect)
		{
			moneyEffectsPool.Release(effect);
		}

		private void InitMoneyEffects(Transform vfxParent, int initialPoolSize, int maxPoolSize)
		{
			InitObjectPool(vfxEffectsDatabase.MoneyVfxPrefab, ref moneyEffectsPool, vfxParent, initialPoolSize, maxPoolSize);
		}

		private void InitObjectPool<T>(T prefab, ref UnityEngine.Pool.ObjectPool<T> pool, Transform vfxParent, int initialPoolSize, int maxPoolSize) where T : Component
		{
			pool = new UnityEngine.Pool.ObjectPool<T>(delegate
			{
				T val = Object.Instantiate(prefab, vfxParent);
				val.gameObject.SetActive(value: false);
				return val;
			}, delegate(T ps)
			{
				ps.gameObject.SetActive(value: true);
			}, delegate(T ps)
			{
				ps.gameObject.SetActive(value: false);
			}, delegate(T ps)
			{
				Object.Destroy(ps.gameObject);
			}, collectionCheck: false, initialPoolSize, maxPoolSize);
		}

		private void InitObjectPool<T>(GameObject prefab, ref UnityEngine.Pool.ObjectPool<T> pool, Transform vfxParent, int initialPoolSize, int maxPoolSize) where T : Component
		{
			pool = new UnityEngine.Pool.ObjectPool<T>(delegate
			{
				GameObject gameObject = Object.Instantiate(prefab, vfxParent);
				gameObject.gameObject.SetActive(value: false);
				return gameObject.GetComponent<T>();
			}, delegate(T ps)
			{
				ps.gameObject.SetActive(value: true);
			}, delegate(T ps)
			{
				ps.gameObject.SetActive(value: false);
			}, delegate(T ps)
			{
				Object.Destroy(ps.gameObject);
			}, collectionCheck: false, initialPoolSize, maxPoolSize);
		}
	}
}
