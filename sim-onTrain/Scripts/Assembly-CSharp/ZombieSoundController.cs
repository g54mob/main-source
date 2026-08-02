using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundController : MonoBehaviour
{
	[Header("Audio Sources")]
	[Tooltip("Ayak sesleri için")]
	public AudioSource footstepSource;

	[Tooltip("Homurdanma sesleri için")]
	public AudioSource vocalSource;

	[Header("Footstep Sounds")]
	[Tooltip("Yürüme ayak sesleri")]
	public List<ZombieSoundClip> walkFootstepSounds;

	[Tooltip("Koşma ayak sesleri")]
	public List<ZombieSoundClip> sprintFootstepSounds;

	[Tooltip("Yere iniş sesleri")]
	public List<ZombieSoundClip> landingSounds;

	[Header("Idle Vocals (Sakin durum)")]
	[Tooltip("Idle/Walk durumunda - kimseyi kovalamıyorken")]
	public ZombieVocalData idleVocals;

	[Header("Agro Vocals (Saldırı durumu)")]
	[Tooltip("Target bulduğunda, koşarken, saldırı anında")]
	public ZombieVocalData agroVocals;

	[Header("Settings")]
	[Tooltip("Pitch varyasyonu")]
	[Range(0f, 0.3f)]
	public float pitchVariation = 0.1f;

	private ZombieController zombieController;

	private float lastVocalTime;

	private float nextVocalInterval;

	private bool wasAgro;

	private void Start()
	{
		zombieController = GetComponentInParent<ZombieController>();
		if (footstepSource == null)
		{
			footstepSource = base.gameObject.AddComponent<AudioSource>();
		}
		ConfigureAudioSource(footstepSource);
		if (vocalSource == null)
		{
			vocalSource = base.gameObject.AddComponent<AudioSource>();
		}
		ConfigureAudioSource(vocalSource);
		ResetVocalTimer(isAgro: false);
	}

	private void ConfigureAudioSource(AudioSource source)
	{
		source.playOnAwake = false;
		source.spatialBlend = 1f;
		source.minDistance = 1f;
		source.maxDistance = 25f;
		source.rolloffMode = AudioRolloffMode.Linear;
	}

	private void Update()
	{
		if (!(zombieController == null) && !zombieController.isDeath)
		{
			UpdateVocals();
		}
	}

	private void UpdateVocals()
	{
		bool flag = IsZombieAgro();
		if (flag != wasAgro)
		{
			ResetVocalTimer(flag);
			wasAgro = flag;
		}
		if (Time.time >= lastVocalTime + nextVocalInterval)
		{
			PlayVocal(flag);
			ResetVocalTimer(flag);
		}
	}

	private bool IsZombieAgro()
	{
		if (zombieController == null)
		{
			return false;
		}
		if (!zombieController.isRunning)
		{
			return zombieController.isAttacking;
		}
		return true;
	}

	private void ResetVocalTimer(bool isAgro)
	{
		lastVocalTime = Time.time;
		if (isAgro && agroVocals != null && agroVocals.HasSounds())
		{
			nextVocalInterval = agroVocals.GetRandomInterval();
		}
		else if (idleVocals != null && idleVocals.HasSounds())
		{
			nextVocalInterval = idleVocals.GetRandomInterval();
		}
		else
		{
			nextVocalInterval = 10f;
		}
	}

	private void PlayVocal(bool isAgro)
	{
		ZombieVocalData zombieVocalData = (isAgro ? agroVocals : idleVocals);
		if (zombieVocalData != null && zombieVocalData.HasSounds())
		{
			ZombieSoundClip randomSound = zombieVocalData.GetRandomSound();
			PlaySound(vocalSource, randomSound);
		}
	}

	public void PlayWalkFootstep()
	{
		PlayRandomFootstep(walkFootstepSounds);
	}

	public void PlaySprintFootstep()
	{
		PlayRandomFootstep(sprintFootstepSounds);
	}

	public void PlayLandingSound()
	{
		PlayRandomFootstep(landingSounds);
	}

	private void PlayRandomFootstep(List<ZombieSoundClip> clips)
	{
		if (clips != null && clips.Count != 0)
		{
			ZombieSoundClip soundClip = clips[Random.Range(0, clips.Count)];
			PlaySound(footstepSource, soundClip);
		}
	}

	public void PlayAgroSound()
	{
		if (agroVocals != null && agroVocals.HasSounds())
		{
			ZombieSoundClip randomSound = agroVocals.GetRandomSound();
			PlaySound(vocalSource, randomSound);
		}
	}

	public void PlayIdleSound()
	{
		if (idleVocals != null && idleVocals.HasSounds())
		{
			ZombieSoundClip randomSound = idleVocals.GetRandomSound();
			PlaySound(vocalSource, randomSound);
		}
	}

	private void PlaySound(AudioSource source, ZombieSoundClip soundClip)
	{
		if (!(source == null) && soundClip != null && !(soundClip.clip == null))
		{
			source.pitch = 1f + Random.Range(0f - pitchVariation, pitchVariation);
			source.PlayOneShot(soundClip.clip, soundClip.volume);
		}
	}
}
