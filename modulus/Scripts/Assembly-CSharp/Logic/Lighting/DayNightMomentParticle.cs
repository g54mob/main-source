using UnityEngine;

namespace Logic.Lighting
{
	public class DayNightMomentParticle : ActivateDuringDayNightMoment
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		protected override void Activate(bool setActive)
		{
			if (setActive)
			{
				_particleSystem.Play();
			}
			else
			{
				_particleSystem.Stop();
			}
		}
	}
}
