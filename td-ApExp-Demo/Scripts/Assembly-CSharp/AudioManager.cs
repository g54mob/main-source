using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private AudioClip HubSong;

	[SerializeField]
	private AudioClip ShopSong;

	[SerializeField]
	private AudioClip CombatSong;

	[SerializeField]
	private AudioClip MenuMusic;

	[SerializeField]
	private float songVolume;

	[SerializeField]
	private float timeToFade;

	[SerializeField]
	private AudioSource track01;

	[SerializeField]
	private AudioSource track02;

	private bool isPlayingTrack01;

	private Coroutine currentFadeRoutine;

	private AudioClip lastClipRequested;

	[Header("World Songs")]
	[SerializeField]
	private List<AudioClip> combatSongs;

	[SerializeField]
	private List<AudioClip> hubSongs;

	[SerializeField]
	private List<AudioClip> shopSongs;

	public static AudioManager Instance { get; private set; }

	[field: SerializeField]
	public AudioMixerGroup MasterGroup { get; private set; }

	[field: SerializeField]
	public AudioMixerGroup MusicGroup { get; private set; }

	[field: SerializeField]
	public AudioMixerGroup SfxGroup { get; private set; }

	[field: SerializeField]
	public SfxHelper SfxHelper { get; private set; }

	public void PlayClipWithMixer(AudioClip clip, AMG grp, float volume = 1f)
	{
		AudioMixerGroup outputAudioMixerGroup = grp switch
		{
			AMG.Master => MasterGroup, 
			AMG.Music => MusicGroup, 
			AMG.SFX => SfxGroup, 
			_ => null, 
		};
		GameObject obj = new GameObject(clip.name);
		AudioSource audioSource = obj.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
		audioSource.volume = volume;
		audioSource.Play();
		Object.Destroy(obj, clip.length);
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		isPlayingTrack01 = true;
		LevelManager.Instance.LevelStarted += delegate
		{
			SwapTracks(CombatSong);
		};
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		ZoneManager.Instance.OnZoneLoaded += OnZoneLoaded;
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			return;
		}
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.audioSource.Stop();
		}
	}

	private void OnZoneLoaded(int i)
	{
		if (i < combatSongs.Count && i < hubSongs.Count && i < shopSongs.Count)
		{
			CombatSong = combatSongs[i];
			HubSong = hubSongs[i];
			ShopSong = shopSongs[i];
		}
	}

	private void HandleDestinationReached()
	{
		if (LevelManager.Instance.CurrentLevel.LootType == LootType.Shop)
		{
			SwapTracks(ShopSong);
		}
		else if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub)
		{
			SwapTracks(HubSong);
		}
		else
		{
			SwapTracks(HubSong);
		}
	}

	public void SwapTracks(AudioClip newClip)
	{
		if (!(newClip == null) && !(newClip == lastClipRequested))
		{
			lastClipRequested = newClip;
			if (currentFadeRoutine != null)
			{
				StopCoroutine(currentFadeRoutine);
			}
			currentFadeRoutine = StartCoroutine(FadeTrack(newClip));
			isPlayingTrack01 = !isPlayingTrack01;
		}
	}

	private IEnumerator FadeTrack(AudioClip newClip)
	{
		float startTime = Time.realtimeSinceStartup;
		AudioSource fadingOut = (isPlayingTrack01 ? track01 : track02);
		AudioSource fadingIn = (isPlayingTrack01 ? track02 : track01);
		if (!(fadingIn.clip == newClip) || !fadingIn.isPlaying || !(fadingIn.volume > 0.95f))
		{
			fadingIn.clip = newClip;
			fadingIn.volume = 0f;
			fadingIn.Play();
			while (Time.realtimeSinceStartup - startTime < timeToFade)
			{
				float t = (Time.realtimeSinceStartup - startTime) / timeToFade;
				fadingIn.volume = Mathf.Lerp(0f, songVolume, t);
				fadingOut.volume = Mathf.Lerp(songVolume, 0f, t);
				yield return null;
			}
			fadingIn.volume = songVolume;
			fadingOut.volume = 0f;
			fadingOut.Stop();
		}
	}
}
