using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class RunwayLightParticlesScript : MonoBehaviour
	{
		[SerializeField]
		private float _minPixelSize = 1.5f;

		[SerializeField]
		private ParticleSystemRenderer _particleSystemRenderer;

		protected virtual void Start()
		{
			if (_particleSystemRenderer == null)
			{
				Debug.LogError("RunwayLightParticlesScript has no associated ParticleSystemRenderer");
				base.enabled = false;
			}
		}

		protected virtual void Update()
		{
			_particleSystemRenderer.minParticleSize = _minPixelSize / (float)Screen.height;
		}
	}
}
