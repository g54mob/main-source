using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleSoundPlayer : SimpleSoundPlayer
	{
		private ParticleSystem _ps;

		protected override void OnEnable()
		{
		}

		protected override bool ShouldSoundPlay()
		{
			return false;
		}
	}
}
