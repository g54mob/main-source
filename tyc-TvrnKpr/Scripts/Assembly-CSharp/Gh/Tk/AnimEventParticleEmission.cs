using UnityEngine;

namespace Gh.Tk
{
	public class AnimEventParticleEmission : MonoBehaviour
	{
		public ParticleSystem ps;

		private ParticleSystem.EmissionModule _emission;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void ListenToCameraAnims()
		{
		}

		private void StopListeningToCameraAnims()
		{
		}

		private void ParticleEmissionEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
