using UnityEngine;

namespace CTS
{
	public class BloodDistillerAnimationVFX : MonoBehaviour
	{
		[SerializeField]
		private BloodDistiller _bloodDistiller;

		[SerializeField]
		private ParticleSystem _bloodBagsParticleSystem;

		private void OnEnable()
		{
			BloodDistiller.ABloodDistiller += OnBloodHarvested;
		}

		private void OnDisable()
		{
			BloodDistiller.ABloodDistiller -= OnBloodHarvested;
		}

		private void OnBloodHarvested(BloodDistiller value)
		{
			if (!(value != _bloodDistiller))
			{
				int num = (value ? 1 : 5);
				ParticleSystem.Burst burst = ((_bloodBagsParticleSystem.emission.burstCount <= 0) ? new ParticleSystem.Burst
				{
					count = 1f,
					time = 0f,
					probability = 1f
				} : _bloodBagsParticleSystem.emission.GetBurst(0));
				burst.repeatInterval = _bloodBagsParticleSystem.main.duration / (float)num;
				burst.cycleCount = num;
				_bloodBagsParticleSystem.emission.SetBurst(0, burst);
				_bloodBagsParticleSystem.Play();
			}
		}
	}
}
