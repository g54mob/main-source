using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace DistantLands.Cozy
{
	public class CozyParticles : MonoBehaviour
	{
		[Serializable]
		public class ParticleType
		{
			public ParticleSystem particleSystem;

			public float emissionAmount;
		}

		private CozyWeather weatherSphere;

		[SerializeField]
		private VisualEffect[] m_VisualEffects;

		[SerializeField]
		private ParticleSystem[] m_ParticleSystems;

		[HideInInspector]
		public List<ParticleType> m_ParticleTypes;

		private void Awake()
		{
			weatherSphere = CozyWeather.instance;
			if (m_ParticleSystems.Length == 0)
			{
				m_ParticleSystems = GetComponentsInChildren<ParticleSystem>();
			}
			if (m_VisualEffects.Length == 0)
			{
				m_VisualEffects = GetComponentsInChildren<VisualEffect>();
			}
			ParticleSystem[] particleSystems = m_ParticleSystems;
			foreach (ParticleSystem particleSystem in particleSystems)
			{
				if (!(particleSystem == null))
				{
					ParticleType item = new ParticleType
					{
						particleSystem = particleSystem,
						emissionAmount = particleSystem.emission.rateOverTime.constant
					};
					m_ParticleTypes.Add(item);
				}
			}
			foreach (ParticleType particleType in m_ParticleTypes)
			{
				ParticleSystem.EmissionModule emission = particleType.particleSystem.emission;
				ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
				rateOverTime.constant = 0f;
				emission.rateOverTime = rateOverTime;
			}
			VisualEffect[] visualEffects = m_VisualEffects;
			for (int i = 0; i < visualEffects.Length; i++)
			{
				visualEffects[i].Stop();
			}
		}

		public void SetupTriggers()
		{
			foreach (ParticleType particleType in m_ParticleTypes)
			{
				ParticleSystem.TriggerModule trigger = particleType.particleSystem.trigger;
				trigger.enter = ParticleSystemOverlapAction.Kill;
				trigger.inside = ParticleSystemOverlapAction.Kill;
				for (int i = 0; i < weatherSphere.cozyTriggers.Count; i++)
				{
					trigger.SetCollider(i, weatherSphere.cozyTriggers[i]);
				}
			}
		}

		public void Play()
		{
			if (this == null)
			{
				return;
			}
			foreach (ParticleType particleType in m_ParticleTypes)
			{
				ParticleSystem.EmissionModule emission = particleType.particleSystem.emission;
				ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
				emission.rateOverTime = rateOverTime;
				if (particleType.particleSystem.isStopped)
				{
					particleType.particleSystem.Play();
				}
			}
			VisualEffect[] visualEffects = m_VisualEffects;
			for (int i = 0; i < visualEffects.Length; i++)
			{
				visualEffects[i].Play();
			}
		}

		public void Stop()
		{
			if (m_ParticleTypes != null)
			{
				foreach (ParticleType particleType in m_ParticleTypes)
				{
					if (particleType.particleSystem != null && particleType.particleSystem.isPlaying)
					{
						particleType.particleSystem.Stop();
					}
				}
			}
			VisualEffect[] visualEffects = m_VisualEffects;
			for (int i = 0; i < visualEffects.Length; i++)
			{
				visualEffects[i].Stop();
			}
		}

		public void Play(float weight)
		{
			if (this == null)
			{
				return;
			}
			foreach (ParticleType particleType in m_ParticleTypes)
			{
				ParticleSystem.EmissionModule emission = particleType.particleSystem.emission;
				ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
				rateOverTime.constant = Mathf.Lerp(0f, particleType.emissionAmount, weight);
				emission.rateOverTime = rateOverTime;
				if (particleType.particleSystem.isStopped)
				{
					particleType.particleSystem.Play();
				}
			}
			VisualEffect[] visualEffects = m_VisualEffects;
			foreach (VisualEffect visualEffect in visualEffects)
			{
				if (weight > 0.5f)
				{
					visualEffect.Play();
				}
				else
				{
					visualEffect.Stop();
				}
			}
		}
	}
}
