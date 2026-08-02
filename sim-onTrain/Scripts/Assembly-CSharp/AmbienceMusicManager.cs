using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class AmbienceMusicManager : Singleton<AmbienceMusicManager>
{
	[Header("Mixer Routing")]
	[Tooltip("Tüm ambiyans source'larının çıkışı bu gruba yönlenir. Boş bırakılırsa AudioManager.AmbienceGroup kullanılır. Settings'teki Ambience slider'ı bu grubu kontrol eder.")]
	[SerializeField]
	private AudioMixerGroup ambienceMixerGroup;

	[Header("Ambience Audio Sources")]
	[Tooltip("Ana ambiyans müzik source")]
	public AudioSource ambienceSource;

	[Tooltip("İkinci source (crossfade için)")]
	public AudioSource secondaryAmbienceSource;

	[Header("Effect Audio Source")]
	[Tooltip("Efekt sesleri source (kuş, rüzgar vs.)")]
	public AudioSource effectSource;

	[Header("Day Music")]
	[Tooltip("Gündüz müzikleri")]
	public AmbienceMusicData dayMusics;

	[Header("Night Music")]
	[Tooltip("Gece müzikleri")]
	public AmbienceMusicData nightMusics;

	[Header("Day Effect Sounds")]
	[Tooltip("Gündüz efekt sesleri (kuş, böcek vs.)")]
	public AmbienceEffectData dayEffectSounds;

	[Header("Night Effect Sounds")]
	[Tooltip("Gece efekt sesleri (baykuş, cırcır böceği vs.)")]
	public AmbienceEffectData nightEffectSounds;

	[Header("Time Settings")]
	[Tooltip("Gece müziğinin başlayacağı saat")]
	[Range(0f, 24f)]
	public float nightStartHour = 18f;

	[Tooltip("Gece müziğinin biteceği saat (sabah)")]
	[Range(0f, 24f)]
	public float nightEndHour = 6f;

	[Header("Settings")]
	[Tooltip("Müzikler arası geçiş süresi")]
	[Range(0.5f, 5f)]
	public float crossfadeDuration = 2f;

	[Header("Initial Delay")]
	[Tooltip("Oyun başladığında efekt sesleri için ilk bekleme süresi (min-max saniye)")]
	public Vector2 initialEffectDelay = new Vector2(10f, 30f);

	private AmbienceState currentAmbienceState;

	private AudioSource activeAmbienceSource;

	private AudioSource inactiveAmbienceSource;

	private bool isAmbienceTransitioning;

	private Coroutine effectLoopCoroutine;

	private TSPlayerController localPlayer;

	private Coroutine ambienceLoopCoroutine;

	private void Start()
	{
		InitializeAudioSources();
		StartCoroutine(WaitForLocalPlayer());
	}

	private void InitializeAudioSources()
	{
		if (ambienceMixerGroup == null && Singleton<AudioManager>.Instance != null)
		{
			ambienceMixerGroup = Singleton<AudioManager>.Instance.AmbienceGroup;
		}
		if (ambienceSource == null)
		{
			ambienceSource = base.gameObject.AddComponent<AudioSource>();
		}
		if (secondaryAmbienceSource == null)
		{
			secondaryAmbienceSource = base.gameObject.AddComponent<AudioSource>();
		}
		if (effectSource == null)
		{
			effectSource = base.gameObject.AddComponent<AudioSource>();
		}
		ConfigureAudioSource(ambienceSource);
		ConfigureAudioSource(secondaryAmbienceSource);
		ConfigureAudioSource(effectSource);
		activeAmbienceSource = ambienceSource;
		inactiveAmbienceSource = secondaryAmbienceSource;
	}

	private void ConfigureAudioSource(AudioSource source)
	{
		source.playOnAwake = false;
		source.loop = false;
		source.spatialBlend = 0f;
		source.volume = 0f;
		if (ambienceMixerGroup != null)
		{
			source.outputAudioMixerGroup = ambienceMixerGroup;
		}
	}

	private IEnumerator WaitForLocalPlayer()
	{
		while (localPlayer == null)
		{
			if (TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
			{
				localPlayer = TrainGameManager.Instance.mainPlayer.GetComponent<TSPlayerController>();
			}
			yield return new WaitForSeconds(0.5f);
		}
		StartMusicSystem();
	}

	private void StartMusicSystem()
	{
		UpdateAmbienceState();
		PlayAmbienceMusic();
		StartEffectLoop();
	}

	private void Update()
	{
		if (!(localPlayer == null))
		{
			UpdateAmbienceState();
		}
	}

	private void UpdateAmbienceState()
	{
		if (!(TrainGameManager.Instance == null))
		{
			float currentTime = TrainGameManager.Instance.currentTime;
			AmbienceState ambienceState = ((currentTime >= nightStartHour || currentTime < nightEndHour) ? AmbienceState.Night : AmbienceState.Day);
			if (ambienceState != currentAmbienceState && !isAmbienceTransitioning)
			{
				currentAmbienceState = ambienceState;
				TransitionAmbienceMusic();
			}
		}
	}

	private void PlayAmbienceMusic()
	{
		AmbienceSoundClip ambienceMusicClip = GetAmbienceMusicClip();
		if (ambienceMusicClip != null && !(ambienceMusicClip.clip == null))
		{
			float duration = GetCurrentAmbienceData()?.FadeDuration ?? 1f;
			activeAmbienceSource.DOKill();
			activeAmbienceSource.clip = ambienceMusicClip.clip;
			activeAmbienceSource.volume = 0f;
			activeAmbienceSource.Play();
			activeAmbienceSource.DOFade(ambienceMusicClip.volume, duration);
			if (ambienceLoopCoroutine != null)
			{
				StopCoroutine(ambienceLoopCoroutine);
			}
			ambienceLoopCoroutine = StartCoroutine(AmbienceLoopCoroutine(ambienceMusicClip));
		}
	}

	private IEnumerator AmbienceLoopCoroutine(AmbienceSoundClip currentClip)
	{
		AmbienceMusicData currentData;
		float fadeDuration;
		while (true)
		{
			if (activeAmbienceSource.clip != null && activeAmbienceSource.isPlaying)
			{
				currentData = GetCurrentAmbienceData();
				fadeDuration = currentData?.FadeDuration ?? 1f;
				float randomPlayTime = currentClip.GetRandomPlayTime();
				yield return new WaitForSeconds(randomPlayTime);
				if (!isAmbienceTransitioning)
				{
					break;
				}
			}
			else
			{
				yield return new WaitForSeconds(1f);
			}
		}
		activeAmbienceSource.DOKill();
		activeAmbienceSource.DOFade(0f, fadeDuration);
		yield return new WaitForSeconds(fadeDuration);
		activeAmbienceSource.Stop();
		float seconds = currentData?.GetRandomNonMusicTime() ?? 5f;
		yield return new WaitForSeconds(seconds);
		TransitionAmbienceMusic();
	}

	private void TransitionAmbienceMusic()
	{
		if (isAmbienceTransitioning)
		{
			return;
		}
		AmbienceSoundClip ambienceMusicClip = GetAmbienceMusicClip();
		if (ambienceMusicClip != null && !(ambienceMusicClip.clip == null))
		{
			float duration = GetCurrentAmbienceData()?.FadeDuration ?? 1f;
			activeAmbienceSource.DOKill();
			activeAmbienceSource.clip = ambienceMusicClip.clip;
			activeAmbienceSource.volume = 0f;
			activeAmbienceSource.Play();
			activeAmbienceSource.DOFade(ambienceMusicClip.volume, duration);
			if (ambienceLoopCoroutine != null)
			{
				StopCoroutine(ambienceLoopCoroutine);
			}
			ambienceLoopCoroutine = StartCoroutine(AmbienceLoopCoroutine(ambienceMusicClip));
		}
	}

	private AmbienceMusicData GetCurrentAmbienceData()
	{
		if (currentAmbienceState != AmbienceState.Night)
		{
			return dayMusics;
		}
		return nightMusics;
	}

	private AmbienceSoundClip GetAmbienceMusicClip()
	{
		return GetCurrentAmbienceData()?.GetRandomMusicClip();
	}

	private void StartEffectLoop()
	{
		if (effectLoopCoroutine != null)
		{
			StopCoroutine(effectLoopCoroutine);
		}
		effectLoopCoroutine = StartCoroutine(EffectLoopCoroutine());
	}

	private IEnumerator EffectLoopCoroutine()
	{
		float seconds = Random.Range(initialEffectDelay.x, initialEffectDelay.y);
		yield return new WaitForSeconds(seconds);
		while (true)
		{
			AmbienceEffectData currentEffectData = GetCurrentEffectData();
			if (currentEffectData != null && currentEffectData.HasEffects())
			{
				AmbienceSoundClip randomEffectClip = currentEffectData.GetRandomEffectClip();
				if (randomEffectClip != null && randomEffectClip.clip != null)
				{
					float randomPlayTime = randomEffectClip.GetRandomPlayTime();
					float fadeDuration = currentEffectData.FadeDuration;
					effectSource.DOKill();
					effectSource.clip = randomEffectClip.clip;
					effectSource.volume = 0f;
					effectSource.loop = true;
					effectSource.Play();
					effectSource.DOFade(randomEffectClip.volume, fadeDuration);
					yield return new WaitForSeconds(randomPlayTime);
					effectSource.DOKill();
					effectSource.DOFade(0f, fadeDuration);
					yield return new WaitForSeconds(fadeDuration);
					effectSource.Stop();
					effectSource.loop = false;
					float randomNonEffectTime = currentEffectData.GetRandomNonEffectTime();
					yield return new WaitForSeconds(randomNonEffectTime);
				}
				else
				{
					yield return new WaitForSeconds(5f);
				}
			}
			else
			{
				yield return new WaitForSeconds(5f);
			}
		}
	}

	private AmbienceEffectData GetCurrentEffectData()
	{
		if (currentAmbienceState != AmbienceState.Night)
		{
			return dayEffectSounds;
		}
		return nightEffectSounds;
	}

	private void StopEffectLoop()
	{
		if (effectLoopCoroutine != null)
		{
			StopCoroutine(effectLoopCoroutine);
			effectLoopCoroutine = null;
		}
		if (effectSource != null && effectSource.isPlaying)
		{
			effectSource.Stop();
		}
	}

	public AmbienceState GetCurrentAmbienceState()
	{
		return currentAmbienceState;
	}

	public void StopAllMusic()
	{
		if (ambienceLoopCoroutine != null)
		{
			StopCoroutine(ambienceLoopCoroutine);
			ambienceLoopCoroutine = null;
		}
		StopEffectLoop();
		if (activeAmbienceSource != null)
		{
			activeAmbienceSource.DOKill();
			activeAmbienceSource.DOFade(0f, 1f).OnComplete(delegate
			{
				activeAmbienceSource.Stop();
			});
		}
		if (inactiveAmbienceSource != null)
		{
			inactiveAmbienceSource.DOKill();
			inactiveAmbienceSource.DOFade(0f, 1f).OnComplete(delegate
			{
				inactiveAmbienceSource.Stop();
			});
		}
		if (effectSource != null)
		{
			effectSource.DOKill();
			effectSource.Stop();
		}
	}

	public void RestartMusic()
	{
		StopAllMusic();
		StartCoroutine(DelayedRestart());
	}

	private IEnumerator DelayedRestart()
	{
		yield return new WaitForSeconds(1.5f);
		StartMusicSystem();
	}
}
