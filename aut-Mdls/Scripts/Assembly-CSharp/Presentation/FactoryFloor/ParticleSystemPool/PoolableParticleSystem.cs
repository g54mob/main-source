using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor.ParticleSystemPool
{
	public class PoolableParticleSystem : MonoBehaviour, IPoolableComponent
	{
		[SerializeField]
		private ParticleSystemPoolLocator _locator;

		[SerializeField]
		private ParticleSystem _particleSystem;

		private ParticleSystemRenderer _renderer;

		private ComponentPool<PoolableParticleSystem> _pool;

		public void Awake()
		{
			_renderer = _particleSystem.GetComponent<ParticleSystemRenderer>();
		}

		public void Init(ComponentPool<PoolableParticleSystem> pool)
		{
			_renderer.forceRenderingOff = false;
			_particleSystem.Play();
			_pool = pool;
		}

		public void Clear()
		{
			_particleSystem.Clear(withChildren: true);
		}

		private void OnParticleSystemStopped()
		{
			if (_pool != null)
			{
				_locator.Pool.ReturnToPool(this, _pool);
			}
		}

		public void OnReturnToPool()
		{
			_renderer.forceRenderingOff = true;
		}

		public void OnRetrieveFromPool()
		{
			_renderer.forceRenderingOff = false;
		}
	}
}
