using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public enum MusicMode
	{
		MainMenu = 0,
		InGame = 1
	}

	public enum ButtonSoundType
	{
		Positive = 0,
		Negative = 1
	}

	[Header("Music Audio")]
	[SerializeField]
	private AudioSource musicSource;

	[Header("Music Clips")]
	[SerializeField]
	private AudioClip mainMenuMusic;

	[SerializeField]
	private List<AudioClip> inGameMusics = new List<AudioClip>();

	[Header("Music Volumes (Inspector Only)")]
	[Range(0f, 1f)]
	[SerializeField]
	private float mainMenuVolume = 0.8f;

	[Range(0f, 1f)]
	[SerializeField]
	private float inGameVolume = 0.8f;

	[Header("Fade (Seconds)")]
	[SerializeField]
	private float fadeOutDuration = 1f;

	[SerializeField]
	private float fadeInDuration = 1f;

	[Header("Button SFX (Independent)")]
	[SerializeField]
	private AudioSource buttonSource;

	[SerializeField]
	private AudioClip buttonPositiveClip;

	[SerializeField]
	private AudioClip buttonNegativeClip;

	[Range(0f, 1f)]
	[SerializeField]
	private float buttonSfxVolume = 1f;

	[Header("Debug")]
	[SerializeField]
	private MusicMode currentMode;

	[SerializeField]
	private int currentIndex = -1;

	private readonly List<AudioClip> playlist = new List<AudioClip>();

	private Coroutine musicTransitionRoutine;

	private Coroutine playlistRoutine;

	private bool userPaused;

	public static MusicManager Instance { get; private set; }

	public MusicMode CurrentMode => currentMode;

	public bool IsInGameMode => currentMode == MusicMode.InGame;

	public AudioClip CurrentClip
	{
		get
		{
			if (!(musicSource != null))
			{
				return null;
			}
			return musicSource.clip;
		}
	}

	public float CurrentTime
	{
		get
		{
			if (!(musicSource != null) || !(musicSource.clip != null))
			{
				return 0f;
			}
			return musicSource.time;
		}
	}

	public float TotalTime
	{
		get
		{
			if (!(musicSource != null) || !(musicSource.clip != null))
			{
				return 0f;
			}
			return musicSource.clip.length;
		}
	}

	public bool IsPaused
	{
		get
		{
			if (userPaused && musicSource != null)
			{
				return musicSource.clip != null;
			}
			return false;
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		EnsureAudioSources();
	}

	private void EnsureAudioSources()
	{
		if (musicSource == null)
		{
			musicSource = GetComponent<AudioSource>();
		}
		if (musicSource == null)
		{
			musicSource = base.gameObject.AddComponent<AudioSource>();
		}
		musicSource.playOnAwake = false;
		musicSource.loop = false;
		musicSource.spatialBlend = 0f;
		if (buttonSource == null || buttonSource == musicSource)
		{
			buttonSource = base.gameObject.AddComponent<AudioSource>();
		}
		buttonSource.playOnAwake = false;
		buttonSource.loop = false;
		buttonSource.spatialBlend = 0f;
	}

	private void Start()
	{
		if (mainMenuMusic != null)
		{
			ChangeMusic(MusicMode.MainMenu);
		}
	}

	public void ChangeMusic(MusicMode mode)
	{
		if (!(musicSource == null))
		{
			if (musicTransitionRoutine != null)
			{
				StopCoroutine(musicTransitionRoutine);
			}
			musicTransitionRoutine = StartCoroutine(ChangeMusicRoutine(mode));
		}
	}

	public void NextTrack()
	{
		if (IsInGameMode && playlist.Count != 0)
		{
			int num = currentIndex + 1;
			if (num >= playlist.Count)
			{
				num = 0;
			}
			SwitchToInGameIndexImmediate(num);
		}
	}

	public void PreviousTrack()
	{
		if (IsInGameMode && playlist.Count != 0)
		{
			int num = currentIndex - 1;
			if (num < 0)
			{
				num = playlist.Count - 1;
			}
			SwitchToInGameIndexImmediate(num);
		}
	}

	public void PauseMusic()
	{
		if (!(musicSource == null) && !(musicSource.clip == null))
		{
			userPaused = true;
			musicSource.Pause();
		}
	}

	public void ResumeMusic()
	{
		if (!(musicSource == null) && !(musicSource.clip == null))
		{
			userPaused = false;
			musicSource.UnPause();
		}
	}

	public void PlayButtonSound(ButtonSoundType type)
	{
		if (!(buttonSource == null))
		{
			AudioClip audioClip = ((type == ButtonSoundType.Positive) ? buttonPositiveClip : buttonNegativeClip);
			if (!(audioClip == null))
			{
				buttonSource.volume = Mathf.Clamp01(buttonSfxVolume);
				buttonSource.PlayOneShot(audioClip);
			}
		}
	}

	private IEnumerator ChangeMusicRoutine(MusicMode mode)
	{
		StopPlaylistRoutine();
		userPaused = false;
		musicSource.UnPause();
		yield return Fade(musicSource, 0f, fadeOutDuration);
		currentMode = mode;
		if (mode == MusicMode.MainMenu)
		{
			currentIndex = -1;
			playlist.Clear();
			if (mainMenuMusic == null)
			{
				musicSource.Stop();
				musicSource.clip = null;
				yield break;
			}
			musicSource.loop = true;
			musicSource.clip = mainMenuMusic;
			musicSource.time = 0f;
			musicSource.volume = 0f;
			musicSource.Play();
			yield return Fade(musicSource, GetTargetMusicVolume(), fadeInDuration);
			yield break;
		}
		BuildShuffledPlaylist();
		if (playlist.Count == 0)
		{
			musicSource.Stop();
			musicSource.clip = null;
			yield break;
		}
		musicSource.loop = false;
		currentIndex = 0;
		musicSource.clip = playlist[currentIndex];
		musicSource.time = 0f;
		musicSource.volume = 0f;
		musicSource.Play();
		yield return Fade(musicSource, GetTargetMusicVolume(), fadeInDuration);
		StartPlaylistRoutine();
	}

	private void BuildShuffledPlaylist()
	{
		playlist.Clear();
		if (inGameMusics == null)
		{
			return;
		}
		for (int i = 0; i < inGameMusics.Count; i++)
		{
			AudioClip audioClip = inGameMusics[i];
			if (audioClip != null)
			{
				playlist.Add(audioClip);
			}
		}
		for (int num = playlist.Count - 1; num > 0; num--)
		{
			int index = Random.Range(0, num + 1);
			AudioClip value = playlist[num];
			playlist[num] = playlist[index];
			playlist[index] = value;
		}
	}

	private void SwitchToInGameIndexImmediate(int index)
	{
		if (IsInGameMode && playlist.Count != 0)
		{
			index = Mathf.Clamp(index, 0, playlist.Count - 1);
			if (musicTransitionRoutine != null)
			{
				StopCoroutine(musicTransitionRoutine);
				musicTransitionRoutine = null;
			}
			StopPlaylistRoutine();
			userPaused = false;
			musicSource.UnPause();
			currentIndex = index;
			musicSource.loop = false;
			musicSource.clip = playlist[currentIndex];
			musicSource.time = 0f;
			musicSource.volume = GetTargetMusicVolume();
			musicSource.Play();
			StartPlaylistRoutine();
		}
	}

	private void StartPlaylistRoutine()
	{
		if (playlistRoutine != null)
		{
			StopCoroutine(playlistRoutine);
		}
		playlistRoutine = StartCoroutine(PlaylistWatcher());
	}

	private void StopPlaylistRoutine()
	{
		if (playlistRoutine != null)
		{
			StopCoroutine(playlistRoutine);
			playlistRoutine = null;
		}
	}

	private IEnumerator PlaylistWatcher()
	{
		while (IsInGameMode && !(musicSource == null) && !(musicSource.clip == null) && playlist.Count != 0)
		{
			if (userPaused)
			{
				yield return null;
				continue;
			}
			while (IsInGameMode && !userPaused && musicSource.isPlaying)
			{
				yield return null;
			}
			if (!IsInGameMode || musicSource.clip == null || playlist.Count == 0)
			{
				break;
			}
			if (userPaused)
			{
				yield return null;
				continue;
			}
			int num = currentIndex + 1;
			if (num >= playlist.Count)
			{
				num = 0;
			}
			currentIndex = num;
			musicSource.clip = playlist[currentIndex];
			musicSource.time = 0f;
			musicSource.volume = GetTargetMusicVolume();
			musicSource.Play();
		}
	}

	private float GetTargetMusicVolume()
	{
		if (currentMode != MusicMode.MainMenu)
		{
			return Mathf.Clamp01(inGameVolume);
		}
		return Mathf.Clamp01(mainMenuVolume);
	}

	private IEnumerator Fade(AudioSource src, float target, float duration)
	{
		if (src == null)
		{
			yield break;
		}
		float start = src.volume;
		if (duration <= 0f)
		{
			src.volume = target;
			yield break;
		}
		float t = 0f;
		while (t < duration)
		{
			t += Time.unscaledDeltaTime;
			float t2 = Mathf.Clamp01(t / duration);
			src.volume = Mathf.Lerp(start, target, t2);
			yield return null;
		}
		src.volume = target;
	}
}
