using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class MusicController : MonoBehaviour
{
	public float fadeOutDuration = 1f;

	public float fadeInDuration = 1f;

	public float crossFadeDuration = 1f;

	public Music[] musicList;

	public AssetFallbacks assetFallbacks;

	private Dictionary<string, Music> prefabDict = new Dictionary<string, Music>();

	private Music previousMusic;

	private float _volume;

	private List<string> pendingAsync = new List<string>();

	private Dictionary<string, float> volumeDict = new Dictionary<string, float>();

	private static MusicController _singleton;

	public Music currentMusic { get; private set; }

	public float volume
	{
		get
		{
			return _volume;
		}
		set
		{
			_volume = value;
			if (currentMusic != null)
			{
				currentMusic.targetVolume = currentMusic.defaultVolume * _volume;
			}
		}
	}

	public static MusicController singleton => _singleton;

	public void FadeToSilence(float fadeDuration = -1f)
	{
		if (currentMusic != null)
		{
			if (fadeDuration > 0f)
			{
				currentMusic.Stop(fadeDuration);
			}
			else
			{
				currentMusic.Stop(fadeOutDuration);
			}
		}
	}

	public void Play(string id, float delay = 0f, float overrideFadeDuration = -1f)
	{
		if (id == null)
		{
			return;
		}
		if (currentMusic != null && id == currentMusic.id)
		{
			if (currentMusic.currentState == Music.State.FadingOut || currentMusic.currentState == Music.State.Off)
			{
				currentMusic.Play(fadeInDuration);
			}
		}
		else if (prefabDict.ContainsKey(id))
		{
			float transitionDuration = GetTransitionDuration(overrideFadeDuration);
			if (previousMusic != null && id == previousMusic.id)
			{
				Music music = previousMusic;
				if (currentMusic != null)
				{
					currentMusic.Pause(transitionDuration);
					previousMusic = currentMusic;
				}
				currentMusic = music;
			}
			else
			{
				Music newInstance = Object.Instantiate(prefabDict[id]);
				ApplyDebugVolume(newInstance);
				if (previousMusic != null)
				{
					previousMusic.destroyOnStop = true;
					previousMusic.Stop(0f);
				}
				if (currentMusic != null)
				{
					currentMusic.Pause(transitionDuration);
					previousMusic = currentMusic;
				}
				currentMusic = newInstance;
			}
			currentMusic.targetVolume = currentMusic.defaultVolume * _volume;
			currentMusic.Play(transitionDuration, delay);
		}
		else
		{
			if (pendingAsync.Contains(id))
			{
				return;
			}
			pendingAsync.Add(id);
			string assetKey = "Music/" + id;
			AsyncOperationHandle<IList<IResourceLocation>> hasAssetHandle = Addressables.LoadResourceLocationsAsync(assetKey);
			hasAssetHandle.Completed += delegate(AsyncOperationHandle<IList<IResourceLocation>> resLocations)
			{
				bool num = resLocations.Result.Count > 0;
				Addressables.Release(hasAssetHandle);
				if (num)
				{
					AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>(assetKey);
					loadHandler.Completed += delegate
					{
						pendingAsync.Remove(id);
						if (loadHandler.Result != null)
						{
							Music component = loadHandler.Result.GetComponent<Music>();
							prefabDict.Add(id, component);
							Play(id, delay, overrideFadeDuration);
						}
					};
				}
				else
				{
					pendingAsync.Remove(id);
					string fallback = assetFallbacks.GetFallback(id);
					if (fallback != null)
					{
						Play(fallback, delay, overrideFadeDuration);
					}
					else
					{
						Debug.LogError("No music found with ID: " + id);
					}
				}
			};
		}
	}

	public void ResumePreviousMusic()
	{
		if (previousMusic == null)
		{
			Utils.LogWarning("Cannot resume previous music because there is none.");
			return;
		}
		float transitionDuration = GetTransitionDuration();
		if (currentMusic != null)
		{
			currentMusic.destroyOnStop = true;
			currentMusic.Stop(transitionDuration);
		}
		currentMusic = previousMusic;
		currentMusic.Play(transitionDuration);
		previousMusic = null;
	}

	private float GetTransitionDuration(float overrideDuration = -1f)
	{
		if (overrideDuration > 0f)
		{
			return overrideDuration;
		}
		if (currentMusic == null)
		{
			return fadeInDuration;
		}
		return crossFadeDuration;
	}

	public string GetActiveVolume()
	{
		if (currentMusic == null || currentMusic.audioSource == null)
		{
			return "nul";
		}
		return currentMusic.audioSource.volume.ToString("F2");
	}

	private void Update()
	{
	}

	private void ChangeVolume(float amount)
	{
		if (currentMusic != null && currentMusic.audioSource != null)
		{
			float num = currentMusic.audioSource.volume;
			num = Mathf.Clamp(num + amount, 0f, 1f);
			currentMusic.targetVolume = num;
			currentMusic.audioSource.volume = num;
			if (volumeDict == null)
			{
				volumeDict = new Dictionary<string, float>();
			}
			string id = currentMusic.id;
			if (volumeDict.ContainsKey(id))
			{
				volumeDict[id] = num;
			}
			else
			{
				volumeDict.Add(id, num);
			}
		}
	}

	private void ApplyDebugVolume(Music newInstance)
	{
	}

	private void InitDictionary()
	{
		for (int i = 0; i < musicList.Length; i++)
		{
			Music music = musicList[i];
			if (!(music == null))
			{
				string id = music.id;
				if (prefabDict.ContainsKey(id))
				{
					Utils.LogError("Multiple music entries with the same id '" + id + "', please fix.");
				}
				else
				{
					prefabDict.Add(id, music);
				}
			}
		}
		Addressables.InitializeAsync();
	}

	private void Awake()
	{
		_singleton = this;
		InitDictionary();
		assetFallbacks.Init();
	}
}
