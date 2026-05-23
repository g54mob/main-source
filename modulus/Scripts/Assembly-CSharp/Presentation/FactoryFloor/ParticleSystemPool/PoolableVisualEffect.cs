using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
using Utils;

namespace Presentation.FactoryFloor.ParticleSystemPool
{
	public class PoolableVisualEffect : MonoBehaviour, IPoolableComponent
	{
		[SerializeField]
		private ParticleSystemPoolLocator _locator;

		[SerializeField]
		private VisualEffect _visualEffect;

		[SerializeField]
		private float _effectDuration;

		private ComponentPool<PoolableVisualEffect> _pool;

		public void Init(ComponentPool<PoolableVisualEffect> pool)
		{
			_visualEffect.Play();
			StartCoroutine(ReturnToPool());
			_pool = pool;
		}

		private IEnumerator ReturnToPool()
		{
			WaitForSeconds waitSeconds = new WaitForSeconds(_effectDuration);
			do
			{
				yield return waitSeconds;
			}
			while (_visualEffect.HasAnySystemAwake());
			_locator.Pool.ReturnToPool(this, _pool);
		}

		public void OnReturnToPool()
		{
			_visualEffect.Stop();
		}

		public void OnRetrieveFromPool()
		{
		}

		public void Clear()
		{
		}
	}
}
