using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Audio Particles")]
	[RequireComponent(typeof(ParticleSystem))]
	public class AudioParticles : BaseAudioFeedback<SoundFileObject>
	{
		private enum ParticleEvent
		{
			ParticleEmitted = 0,
			ParticleDeath = 1
		}

		[Header("Particle Settings")]
		[SerializeField]
		private ParticleEvent playSoundOn;

		private ParticleSystem partSys;

		private ParticleSystem.Particle[] particles;

		private float lowestLifetime = 99f;

		private void Awake()
		{
			partSys = GetComponent<ParticleSystem>();
			particles = new ParticleSystem.Particle[partSys.main.maxParticles];
		}

		public void PlaySound()
		{
			switch (playSoundOn)
			{
			case ParticleEvent.ParticleEmitted:
				AudioManager.PlaySound(audio, base.transform);
				break;
			case ParticleEvent.ParticleDeath:
				AudioManager.PlaySound(audio, base.transform);
				break;
			}
		}

		private void LateUpdate()
		{
			if (partSys.particleCount != 0)
			{
				int numPartAlive = partSys.GetParticles(particles);
				GetYoungestParticle(numPartAlive, particles, out var lifetime);
				if (lowestLifetime > lifetime)
				{
					PlaySound();
				}
				lowestLifetime = lifetime;
			}
		}

		private int GetYoungestParticle(int numPartAlive, ParticleSystem.Particle[] particles, out float lifetime)
		{
			int num = 0;
			for (int i = 0; i < numPartAlive; i++)
			{
				if (i == 0)
				{
					num = 0;
				}
				else if (particles[i].remainingLifetime > particles[num].remainingLifetime)
				{
					num = i;
				}
			}
			lifetime = particles[num].startLifetime - particles[num].remainingLifetime;
			return num;
		}
	}
}
