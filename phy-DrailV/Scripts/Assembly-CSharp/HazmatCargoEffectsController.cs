using System.Collections.Generic;
using DV;
using UnityEngine;

public abstract class HazmatCargoEffectsController : MonoBehaviour
{
	[Range(0f, 1f)]
	public float flowIn;

	[Range(0f, 1f)]
	public float flowOut;

	public LayeredAudio leakAudio;

	public LayeredAudio burnAudio;

	public AudioClip ruptureSound;

	[Range(0f, 2f)]
	public float leakAudioModifier = 1f;

	public float leakAudioSilenceTime = 0.15f;

	public float burnAudioSilenceTime = 0.3f;

	protected const float MIN_VOLUME = 0.01f;

	protected bool effectsAllowed = true;

	protected bool specialEffectsAllowed;

	protected bool shouldSilenceLeakAudio;

	protected bool shouldSilenceBurnAudio;

	protected float leakAudioElapsedSilenceTime;

	protected float burnAudioElapsedSilenceTime;

	protected float leakAudioStopVolume;

	protected float burnAudioStopVolume;

	protected abstract void UpdateEffects();

	protected abstract void UpdateSpecialEffects();

	protected abstract Vector3 LeakParticleLocalPosition();

	protected abstract void InitializeAudio();

	protected virtual void Awake()
	{
		InitializeAudio();
	}

	protected virtual void Update()
	{
		if (!TimeUtil.IsFlowing)
		{
			return;
		}
		if (effectsAllowed)
		{
			UpdateEffects();
			if (specialEffectsAllowed)
			{
				UpdateSpecialEffects();
			}
		}
		TrySilenceLeakAndBurnAudio();
	}

	public Vector3 GetLeakParticleLocalPosition()
	{
		return LeakParticleLocalPosition();
	}

	public void ToggleEffects(bool on, bool forced = false)
	{
		if (on != effectsAllowed)
		{
			if (on)
			{
				effectsAllowed = true;
				return;
			}
			effectsAllowed = false;
			KillEffects(forced);
		}
	}

	public bool AllowSpecialEffects(bool allow)
	{
		return specialEffectsAllowed = allow;
	}

	protected virtual void KillEffects(bool forced = false)
	{
		effectsAllowed = false;
		flowIn = 0f;
		flowOut = 0f;
		shouldSilenceLeakAudio = false;
		shouldSilenceBurnAudio = false;
		leakAudioElapsedSilenceTime = 0f;
		burnAudioElapsedSilenceTime = 0f;
		leakAudioStopVolume = 0f;
		burnAudioStopVolume = 0f;
		if (leakAudio != null)
		{
			leakAudio.Set(0f);
		}
		if (burnAudio != null)
		{
			burnAudio.Set(0f);
		}
	}

	protected void ClearAllParticles(List<ParticleSystem> particles)
	{
		foreach (ParticleSystem particle in particles)
		{
			if (particle != null)
			{
				particle.Clear();
			}
		}
	}

	protected void StartParticleIfNotPlaying(ParticleSystem[] particles)
	{
		foreach (ParticleSystem particle in particles)
		{
			StartParticleIfNotPlaying(particle);
		}
	}

	protected void StartParticleIfNotPlaying(List<ParticleSystem> particles)
	{
		foreach (ParticleSystem particle in particles)
		{
			StartParticleIfNotPlaying(particle);
		}
	}

	protected void StopParticleIfPlaying(ParticleSystem[] particles)
	{
		foreach (ParticleSystem particle in particles)
		{
			StopParticleIfPlaying(particle);
		}
	}

	protected void StopParticleIfPlaying(List<ParticleSystem> particles)
	{
		foreach (ParticleSystem particle in particles)
		{
			StopParticleIfPlaying(particle);
		}
	}

	protected void StartParticleIfNotPlaying(ParticleSystem particle)
	{
		if (!particle.isPlaying)
		{
			particle.Play();
		}
	}

	protected void StopParticleIfPlaying(ParticleSystem particle)
	{
		if (particle.isPlaying)
		{
			particle.Stop();
		}
	}

	public virtual void PlayRuptureSound()
	{
		if (ruptureSound != null)
		{
			ruptureSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	protected virtual float SmoothSilenceAudio(LayeredAudio layeredAudio, float stopVolume, float elapsedTime, float silenceTime)
	{
		float num = Mathf.Lerp(stopVolume, 0f, elapsedTime / silenceTime);
		if (num <= 0.01f)
		{
			num = 0f;
		}
		layeredAudio.Set(num);
		return num;
	}

	protected virtual void TrySilenceLeakAndBurnAudio()
	{
		if (shouldSilenceLeakAudio)
		{
			leakAudioElapsedSilenceTime += Time.deltaTime;
			float num = SmoothSilenceAudio(leakAudio, leakAudioStopVolume, leakAudioElapsedSilenceTime, leakAudioSilenceTime);
			shouldSilenceLeakAudio = num != 0f;
		}
		if (shouldSilenceBurnAudio)
		{
			burnAudioElapsedSilenceTime += Time.deltaTime;
			float num2 = SmoothSilenceAudio(burnAudio, burnAudioStopVolume, burnAudioElapsedSilenceTime, burnAudioSilenceTime);
			shouldSilenceBurnAudio = num2 != 0f;
		}
	}
}
