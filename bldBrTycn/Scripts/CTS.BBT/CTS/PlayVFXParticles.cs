using UnityEngine;

namespace CTS
{
	public class PlayVFXParticles : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		public void PlayVFX()
		{
			_particleSystem.Play();
		}
	}
}
