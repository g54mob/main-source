using UnityEngine;
using UnityEngine.VFX;
using Utils;

namespace Presentation.FactoryFloor.ParticleSystemPool
{
	public class ParticleSystemPool : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystemPoolLocator _locator;

		[SerializeField]
		private ParticleSystem destroyBuildingParticle;

		[SerializeField]
		private ParticleSystem placeBuildingParticle;

		[SerializeField]
		private VisualEffect _buildingCompletionEffect;

		private ComponentPool<PoolableParticleSystem> _destroyBuildingParticlePool;

		private ComponentPool<PoolableParticleSystem> _placeBuildingParticlePool;

		private ComponentPool<PoolableVisualEffect> _buildingCompletionEffectPool;

		private void Awake()
		{
			_locator.Pool = this;
			_destroyBuildingParticlePool = new ComponentPool<PoolableParticleSystem>(20, destroyBuildingParticle.GetComponent<PoolableParticleSystem>(), base.transform);
			_placeBuildingParticlePool = new ComponentPool<PoolableParticleSystem>(20, placeBuildingParticle.GetComponent<PoolableParticleSystem>(), base.transform);
			_buildingCompletionEffectPool = new ComponentPool<PoolableVisualEffect>(20, _buildingCompletionEffect.GetComponent<PoolableVisualEffect>(), base.transform);
		}

		public void PlayBuildingCompletionVFX(Vector3 worldPosition, Transform parent)
		{
			PlayVFX(worldPosition, parent, _buildingCompletionEffectPool);
		}

		private void PlayVFX(Vector3 worldPosition, Transform parent, ComponentPool<PoolableVisualEffect> pool)
		{
			PoolableVisualEffect component = pool.GetComponent();
			component.transform.SetParent(parent);
			component.transform.SetPositionAndRotation(worldPosition, Quaternion.identity);
			component.Init(pool);
		}

		public void PlayPlaceBuildingVFX(Vector3 worldPosition, Transform parent)
		{
		}

		public void PlayDestroyBuildingVFX(Vector3 worldPosition, Transform parent)
		{
			PlayVFX(worldPosition, parent, _destroyBuildingParticlePool);
		}

		private void PlayVFX(Vector3 worldPosition, Transform parent, ComponentPool<PoolableParticleSystem> pool)
		{
			PoolableParticleSystem component = pool.GetComponent();
			component.transform.SetParent(parent);
			component.transform.SetPositionAndRotation(worldPosition, Quaternion.identity);
			component.Init(pool);
		}

		private void PlayVFX(Vector3 worldPosition, Vector3 direction, Transform parent, ComponentPool<PoolableParticleSystem> pool)
		{
			PoolableParticleSystem component = pool.GetComponent();
			component.transform.SetParent(parent);
			component.transform.SetPositionAndRotation(worldPosition, Quaternion.LookRotation(direction));
			component.Init(pool);
		}

		public void ReturnToPool(PoolableParticleSystem instance, ComponentPool<PoolableParticleSystem> pool)
		{
			instance.Clear();
			pool.ReturnMono(instance);
		}

		public void ReturnToPool(PoolableVisualEffect instance, ComponentPool<PoolableVisualEffect> pool)
		{
			instance.Clear();
			pool.ReturnMono(instance);
		}
	}
}
