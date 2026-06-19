using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pug.UnityExtensions;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MusicManager : ManagerBase
{
	[Serializable]
	public class MusicTrack
	{
		[Tooltip("Optional intro track.")]
		public AssetReferenceT<AudioClip> introAssetReference;

		public AssetReferenceT<AudioClip> trackAssetReference;
	}

	[Serializable]
	public class MusicRoster
	{
		public MusicRosterType rosterType;

		public MusicType musicType;

		public List<MusicTrack> tracks;
	}

	private const string OBFUSCATION_FADER_NAME = "lowpass";

	[Header("Musics FX Chain:")]
	public AudioMixer audioMixer;

	public AudioMixer outroCreditsAudioMixer;

	[ArrayElementTitle("rosterType")]
	public List<MusicRoster> musicRosters;

	[Header("Settings:")]
	public AudioSource musicAudioSource;

	public bool shuffle = true;

	public bool repeat = true;

	private bool isPaused = true;

	private Fader volumeFader;

	private Fader obfuscationFader;

	private float previousObfuscationValue = -1f;

	private int currentlyPlayingMusicIndex = -1;

	private AssetReference currentlyPlayingAssetRef;

	private AsyncOperationHandle<AudioClip> audioClipLoadOperation;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("MusicManager.Init");

	private float _previousMusicVolume = -1f;

	private float _previousOutroCreditsMusicVolume = -1f;

	public MusicRosterType currentMusicRosterType { get; set; }

	private MusicRoster currentMusicRoster { get; set; }

	private bool IsAudioClipBeingLoaded
	{
		get
		{
			if (audioClipLoadOperation.IsValid())
			{
				return audioClipLoadOperation.Status == AsyncOperationStatus.None;
			}
			return false;
		}
	}

	public bool IsMusicRosterOfType(MusicRosterType rosterType, MusicType musicType)
	{
		foreach (MusicRoster musicRoster in musicRosters)
		{
			if (rosterType == musicRoster.rosterType)
			{
				return musicRoster.musicType == musicType;
			}
		}
		return false;
	}

	public bool IsPlaying()
	{
		return musicAudioSource.isPlaying;
	}

	public bool IsPaused()
	{
		return isPaused;
	}

	private float GetFadeTime()
	{
		return Time.unscaledTime;
	}

	public bool VolumeIsFadingInOrHasFadedIn()
	{
		return volumeFader.IsFadingInOrHasFadedIn();
	}

	public bool VolumeIsFadingOutOrHasFadedOut()
	{
		return volumeFader.IsFadingOutOrHasFadedOut();
	}

	public float GetMusicFadeValue()
	{
		return volumeFader.UpdateFadeValue(GetFadeTime());
	}

	public float GetObfuscationFadeValue()
	{
		return obfuscationFader.UpdateFadeValue(GetFadeTime());
	}

	public Fader.FadeDirection GetObfuscationFadeDirection()
	{
		return obfuscationFader.GetFadeDirection();
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			musicAudioSource.outputAudioMixerGroup = Manager.audio.musicMixerGroup;
			volumeFader = new Fader(0f, Fader.FadeFunction.Sin, GetFadeTime());
			obfuscationFader = new Fader(0f, Fader.FadeFunction.Sin, GetFadeTime());
			return true;
		}
	}

	private void UpdateVolume()
	{
		float currentMusicVolume = GetCurrentMusicVolume();
		if (currentMusicVolume != _previousMusicVolume)
		{
			audioMixer.SetLinearVolume("volume", currentMusicVolume);
			_previousMusicVolume = currentMusicVolume;
		}
		float currentOutroCreditsMusicVolume = GetCurrentOutroCreditsMusicVolume();
		if (currentOutroCreditsMusicVolume != _previousOutroCreditsMusicVolume)
		{
			outroCreditsAudioMixer.SetLinearVolume("volume", currentOutroCreditsMusicVolume);
			_previousOutroCreditsMusicVolume = currentOutroCreditsMusicVolume;
		}
	}

	private float GetCurrentMusicVolume()
	{
		return GetMusicFadeValue() * (1f - 0.3f * GetObfuscationFadeValue()) * Manager.prefs.musicVolume * 0.7f;
	}

	private float GetCurrentOutroCreditsMusicVolume()
	{
		return Manager.prefs.musicVolume * 0.7f;
	}

	private void UpdateObfuscation()
	{
		float obfuscationFadeValue = GetObfuscationFadeValue();
		if (obfuscationFadeValue != previousObfuscationValue)
		{
			float num = 600f;
			float num2 = 22000f;
			float num3 = 1f - obfuscationFadeValue;
			float value = num + (num2 - num) * num3;
			audioMixer.SetFloat("lowpass", value);
			previousObfuscationValue = obfuscationFadeValue;
		}
	}

	public void PauseMusic()
	{
		if (!isPaused)
		{
			musicAudioSource.Pause();
			isPaused = true;
		}
	}

	public void ResumeMusic()
	{
		if (isPaused)
		{
			musicAudioSource.UnPause();
			isPaused = false;
		}
	}

	public void StopMusic(MusicRosterType newMusicRoster = MusicRosterType.DONT_PLAY_MUSIC)
	{
		currentMusicRosterType = newMusicRoster;
		musicAudioSource.Stop();
		ReleaseCurrentlyPlayingAsset();
		currentlyPlayingMusicIndex = -1;
		PauseMusic();
	}

	private void ReleaseCurrentlyPlayingAsset()
	{
		if (!(musicAudioSource.clip == null))
		{
			Addressables.Release(musicAudioSource.clip);
			currentlyPlayingAssetRef = null;
			musicAudioSource.clip = null;
		}
	}

	public void SetNewMusicPlaylist(MusicRosterType m)
	{
		if (m != currentMusicRosterType)
		{
			StopMusic();
		}
		currentMusicRosterType = m;
		if (currentMusicRosterType == MusicRosterType.DONT_PLAY_MUSIC)
		{
			SetNewMusicPlaylist(null);
			StopMusic();
			PauseMusic();
			return;
		}
		foreach (MusicRoster musicRoster in musicRosters)
		{
			if (musicRoster.rosterType == currentMusicRosterType)
			{
				ResumeMusic();
				SetNewMusicPlaylist(musicRoster);
				return;
			}
		}
		Debug.LogWarning(m.ToString() + " is an undefined music roster.");
	}

	private void SetNewMusicPlaylist(MusicRoster m)
	{
		if (m == null || m != currentMusicRoster)
		{
			currentlyPlayingMusicIndex = -1;
		}
		if (m != null)
		{
			currentMusicRoster = m;
		}
	}

	public void PlayRandomMusic(bool dontPlaySameTuneAgain = true, float fadeIn = 0f)
	{
		if (currentMusicRoster == null)
		{
			return;
		}
		if (!dontPlaySameTuneAgain || currentlyPlayingMusicIndex == -1 || currentMusicRoster.tracks.Count <= 1)
		{
			PlayMusic(PugRandom.GenerateUniform(0, currentMusicRoster.tracks.Count), fadeIn);
			return;
		}
		int num = UnityEngine.Random.Range(0, currentMusicRoster.tracks.Count - 1);
		if (num >= currentlyPlayingMusicIndex)
		{
			num++;
		}
		PlayMusic(num, fadeIn);
	}

	public void FadeOutVolume(float fadeTime)
	{
		volumeFader.FadeOut(fadeTime, GetFadeTime());
	}

	public void FadeInVolume(float fadeTime)
	{
		volumeFader.FadeIn(fadeTime, GetFadeTime());
	}

	public void FadeOutObfuscation(float fadeTime)
	{
		obfuscationFader.FadeOut(fadeTime, GetFadeTime());
	}

	public void FadeInObfuscation(float fadeTime)
	{
		obfuscationFader.FadeIn(fadeTime, GetFadeTime());
	}

	private void Update()
	{
		UpdateVolume();
		UpdateObfuscation();
		AudioClip clip = musicAudioSource.clip;
		bool flag = clip != null && currentlyPlayingMusicIndex >= 0 && currentlyPlayingMusicIndex < currentMusicRoster.tracks.Count && currentMusicRoster.tracks[currentlyPlayingMusicIndex].introAssetReference.Asset as AudioClip == clip;
		if ((repeat || flag) && !IsPlaying() && !IsPaused() && (Application.runInBackground || Application.isFocused))
		{
			if (flag)
			{
				PlayMusic(currentlyPlayingMusicIndex);
				return;
			}
			if (shuffle)
			{
				PlayRandomMusic();
				return;
			}
			int index = (currentlyPlayingMusicIndex + 1) % currentMusicRoster.tracks.Count;
			PlayMusic(index);
		}
	}

	public async Task PreloadMusicRoster()
	{
		List<AssetReference> list = new List<AssetReference>();
		foreach (MusicTrack track in currentMusicRoster.tracks)
		{
			if (track.introAssetReference.RuntimeKeyIsValid())
			{
				list.Add(track.trackAssetReference);
			}
			if (track.trackAssetReference.RuntimeKeyIsValid())
			{
				list.Add(track.trackAssetReference);
			}
		}
		if (list.Count > 0)
		{
			await Addressables.LoadAssetsAsync<AudioClip>(list, null).Task;
		}
	}

	public void PlayMusicWithRandomStartIndex(float fadeIn = 0f, bool forceLoad = false)
	{
		PlayMusic(UnityEngine.Random.Range(0, currentMusicRoster.tracks.Count - 1), fadeIn, forceLoad);
	}

	public void PlayMusic(int index = 0, float fadeIn = 0f, bool forceLoad = false)
	{
		bool isAudioClipBeingLoaded = IsAudioClipBeingLoaded;
		if (isAudioClipBeingLoaded && !forceLoad)
		{
			Debug.LogWarning(string.Format("{0}.{1}: load operation {2} is still ongoing. Aborting Play request for index {3}.", "MusicManager", "PlayMusic", audioClipLoadOperation.DebugName, index));
			return;
		}
		AssetReferenceT<AudioClip> introAssetReference = currentMusicRoster.tracks[index].introAssetReference;
		bool num = index != currentlyPlayingMusicIndex && introAssetReference != null && introAssetReference.RuntimeKeyIsValid();
		currentlyPlayingMusicIndex = index;
		FadeInVolume(fadeIn);
		musicAudioSource.volume = 1f;
		AssetReference assetReference = (num ? currentMusicRoster.tracks[index].introAssetReference : currentMusicRoster.tracks[index].trackAssetReference);
		if (assetReference.Equals(currentlyPlayingAssetRef))
		{
			Play();
		}
		else if (assetReference != null && assetReference.RuntimeKeyIsValid())
		{
			if (isAudioClipBeingLoaded)
			{
				musicAudioSource.clip = audioClipLoadOperation.WaitForCompletion();
			}
			ReleaseCurrentlyPlayingAsset();
			currentlyPlayingAssetRef = assetReference;
			audioClipLoadOperation = Addressables.LoadAssetAsync<AudioClip>(assetReference);
			if (forceLoad)
			{
				musicAudioSource.clip = audioClipLoadOperation.WaitForCompletion();
				Play();
				return;
			}
			audioClipLoadOperation.Completed += delegate(AsyncOperationHandle<AudioClip> opHandle)
			{
				musicAudioSource.clip = opHandle.Result;
				Play();
			};
		}
		else
		{
			Debug.LogError(string.Format("{0}.{1}: invalid asset reference for music track {2} - {3} - {4}. Check that asset references have been correctly set up.", "MusicManager", "PlayMusic", currentMusicRoster.musicType, currentMusicRoster.rosterType, index));
		}
		void Play()
		{
			musicAudioSource.Play();
			musicAudioSource.UnPause();
			isPaused = false;
		}
	}
}
