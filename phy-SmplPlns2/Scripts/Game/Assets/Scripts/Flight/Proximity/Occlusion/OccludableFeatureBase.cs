using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public abstract class OccludableFeatureBase : MonoBehaviour
	{
		private bool _registered;

		public abstract IEnumerable<IOccludableFeature> GetOccludableFeaturesForBaking();

		protected void OnDestroy()
		{
			if (_registered)
			{
				_registered = false;
				if (OcclusionManager.Instance != null)
				{
					Unregister(OcclusionManager.Instance);
				}
			}
		}

		protected abstract void Register(OcclusionManager manager);

		protected void Start()
		{
			StartCoroutine(RegisterFeatureCoroutine());
		}

		protected abstract void Unregister(OcclusionManager manager);

		private IEnumerator RegisterFeatureCoroutine()
		{
			while (!_registered)
			{
				yield return new WaitForEndOfFrame();
				if (OcclusionManager.Instance != null)
				{
					Register(OcclusionManager.Instance);
					_registered = true;
				}
			}
		}
	}
}
