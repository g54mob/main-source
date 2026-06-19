using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class RadiationCrystal : EntityMonoBehaviour
{
	public SpriteObject indirectLightSprite;

	public SpriteRenderer sheen;

	[ColorUsage(false, true)]
	public Color emissiveColor = Color.green;

	[ColorUsage(false, true)]
	public Color indirectLightColor = Color.green;

	public float damageRadius = 3f;

	public ParticleSystem particleSystem;

	[Min(0f)]
	public float particleAttraction = 1f;

	private bool m_active;

	private float m_currentIntensity;

	private ParticleSystem.Particle[] m_particles;

	private Color m_indirectLightColor;

	private float m_particleRateOverTime;

	private Vector3 m_indirectLightScale;

	private ParticleSystemHandle m_effectsHandle;

	private readonly List<AudioManager.RunningSfxReference> m_radiationAudioLoop = new List<AudioManager.RunningSfxReference>();

	private void OnValidate()
	{
		if (indirectLightSprite != null)
		{
			indirectLightSprite.emissiveColor = indirectLightColor;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		m_currentIntensity = 0f;
		m_indirectLightColor = indirectLightSprite.emissiveColor;
		m_indirectLightScale = indirectLightSprite.transform.localScale;
		m_effectsHandle = particleSystem.CreateHandle();
		m_particleRateOverTime = m_effectsHandle.emission.rateOverTimeMultiplier;
		m_particles = new ParticleSystem.Particle[m_effectsHandle.main.maxParticles];
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		List<PlayerController> allPlayers = Manager.main.allPlayers;
		if (allPlayers == null)
		{
			return;
		}
		PlayerController playerController = null;
		float num = float.MaxValue;
		Vector3 vector = Vector3.zero;
		foreach (PlayerController item in allPlayers)
		{
			if (!(item == null))
			{
				Vector3 position = item.transform.position;
				float magnitude = (position.XZ() - base.transform.position.XZ()).magnitude;
				if (magnitude < num)
				{
					playerController = item;
					num = magnitude;
					vector = position;
				}
			}
		}
		if (playerController == null)
		{
			return;
		}
		m_active = num < damageRadius;
		m_currentIntensity = Mathf.Clamp01(m_currentIntensity + (float)((m_active ? 1 : (-1)) * 2) * Time.deltaTime);
		m_effectsHandle.emission.rateOverTime = m_particleRateOverTime * m_currentIntensity;
		spriteObjects[0].emissiveColor = emissiveColor * (0.1f + m_currentIntensity);
		indirectLightSprite.emissiveColor = indirectLightColor * (1f + m_currentIntensity * 2f);
		sheen.color = indirectLightColor * m_currentIntensity;
		indirectLightSprite.transform.localScale = m_indirectLightScale * (0.5f + m_currentIntensity * 0.5f);
		particleSystem.transform.localScale = Vector3.one * damageRadius * Mathf.Max(0.01f, m_currentIntensity);
		if (particleAttraction > Mathf.Epsilon && particleSystem.IsAlive())
		{
			Vector3 position2 = m_effectsHandle.main.customSimulationSpace.position;
			int particles = particleSystem.GetParticles(m_particles);
			for (int i = 0; i < particles; i++)
			{
				ParticleSystem.Particle particle = m_particles[i];
				if (particle.remainingLifetime > Mathf.Epsilon)
				{
					Vector3 vector2 = vector - particle.position - position2;
					if (Vector3.Dot(particle.velocity.To2D(), vector2.To2D()) < 0f && Vector3.Dot(vector2, vector2) < 1f)
					{
						particle.remainingLifetime = -1f;
						continue;
					}
					particle.velocity += vector2 * particleAttraction * Time.deltaTime;
					m_particles[i] = particle;
				}
			}
			particleSystem.SetParticles(m_particles, particles);
		}
		if (m_radiationAudioLoop.Count == 0 && m_active && !base.isHidden)
		{
			AudioManager.SfxFollowTransform(SfxTableID.radiationCrystalLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, m_radiationAudioLoop);
		}
		if ((!m_active || base.isHidden) && m_radiationAudioLoop.Count > 0)
		{
			ReleaseAudioLoops();
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		ReleaseAudioLoops();
		if (m_active)
		{
			Manager.effects.PlayPuff(new PuffParams
			{
				puff = PuffID.RadiationCrystalBurstBig,
				particleCount = 100
			}, base.transform.position + new Vector3(0f, 1.5f, 0f));
		}
	}

	private void ReleaseAudioLoops()
	{
		foreach (AudioManager.RunningSfxReference item in m_radiationAudioLoop)
		{
			item.FadeOutAndStop();
		}
		m_radiationAudioLoop.Clear();
	}
}
