using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : EntityMonoBehaviour
{
	[Serializable]
	public class FireFlyColor
	{
		public ObjectID fireFlyID;

		public Color particleColor;

		public Color lightColor;
	}

	public List<FireFlyColor> fireFlyColors;

	public ParticleSystem particles;

	private ParticleSystem.Particle[] m_particles;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		m_particles = new ParticleSystem.Particle[particles.main.maxParticles];
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		ParticleSystem.NoiseModule noise = particles.noise;
		noise.strength = 0.5f;
		noise.frequency = 0.5f;
		ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime = particles.limitVelocityOverLifetime;
		limitVelocityOverLifetime.enabled = true;
		particles.Play();
	}

	public override void OnFree()
	{
		particles.Stop();
		base.OnFree();
	}

	protected override void OnHide()
	{
		base.OnHide();
		StartCoroutine(HideAfterDelay());
	}

	private IEnumerator HideAfterDelay()
	{
		yield return new WaitForSeconds(0.1f);
		if (lastAnim != -414722770)
		{
			XScaler.gameObject.SetActive(value: false);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		particles.Stop();
		ParticleSystem.NoiseModule noise = particles.noise;
		noise.strength = 2f;
		noise.frequency = 1f;
		ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime = particles.limitVelocityOverLifetime;
		limitVelocityOverLifetime.enabled = false;
		particles.GetParticles(m_particles);
		for (int i = 0; i < m_particles.Length; i++)
		{
			ParticleSystem.Particle particle = m_particles[i];
			particle.remainingLifetime = Mathf.Min(particle.remainingLifetime, 0.5f);
			m_particles[i] = particle;
		}
		particles.SetParticles(m_particles);
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		int index = 0;
		for (int i = 0; i < fireFlyColors.Count; i++)
		{
			if (fireFlyColors[i].fireFlyID == info.objectID)
			{
				index = i;
				break;
			}
		}
		FireFlyColor fireFlyColor = fireFlyColors[index];
		ParticleSystem.MainModule main = particles.main;
		main.startColor = fireFlyColor.particleColor;
		base.UpdateGraphicsFromObjectInfo(info);
	}
}
