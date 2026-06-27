using UnityEngine;

namespace Restory.Audio
{
	public class MusicVfxPlayer : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem vfxParticleSystem;

		private void OnDisable()
		{
			Stop();
		}

		public void Play()
		{
			if (base.isActiveAndEnabled && (bool)vfxParticleSystem)
			{
				vfxParticleSystem.Play();
			}
		}

		public void Stop()
		{
			if ((bool)vfxParticleSystem)
			{
				vfxParticleSystem.Stop();
			}
		}
	}
}
