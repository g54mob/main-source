using System.Collections.Generic;
using DV.DopplerEffects;
using UnityEngine;
using UnityEngine.Audio;

public static class NAudio
{
	private const float DEFAULT_MIN_DISTANCE = 1f;

	private const float DEFAULT_MAX_DISTANCE = 500f;

	private const float DEFAULT_SPREAD = 0f;

	private const float RANDOM_START_TIME_MAX_PERCENTAGE = 0.9f;

	public static AudioMixerGroup Default3DMixerGroup;

	public static AudioMixerGroup Default2DMixerGroup;

	private static AnimationCurve resetCurve = new AnimationCurve(new Keyframe(0f, 0f));

	private static List<AudioReferences> _audioReferencesPool;

	private static int audioPoolInitialSize = 128;

	private static AudioPoolReturnTimer audioTimer;

	private static Transform poolParent;

	private static List<AudioReferences> AudioReferencesPool
	{
		get
		{
			if (poolParent == null)
			{
				InititalizePlayOncePool();
			}
			return _audioReferencesPool;
		}
	}

	private static void InititalizePlayOncePool()
	{
		GameObject gameObject = new GameObject("AudioSourcePool");
		poolParent = gameObject.transform;
		audioTimer = gameObject.AddComponent<AudioPoolReturnTimer>();
		audioTimer.SourceStopped += ReturnAudioSourceToPool;
		_audioReferencesPool = new List<AudioReferences>(audioPoolInitialSize);
		for (int i = 0; i < audioPoolInitialSize; i++)
		{
			ReturnAudioSourceToPool(CreateSource());
		}
	}

	internal static void ClearPoolReferences()
	{
		poolParent = null;
		_audioReferencesPool = null;
		audioTimer = null;
	}

	private static AudioReferences RequestAudioReference()
	{
		AudioReferences audioReferences = null;
		List<AudioReferences> audioReferencesPool = AudioReferencesPool;
		int num = audioReferencesPool.Count - 1;
		while (num >= 0 && audioReferences == null)
		{
			audioReferences = audioReferencesPool[num];
			audioReferencesPool.RemoveAt(num);
			num--;
		}
		if (audioReferences == null)
		{
			audioReferences = CreateSource();
			audioReferences.source.transform.SetParent(poolParent.transform);
		}
		audioReferences.source.gameObject.SetActive(value: true);
		return audioReferences;
	}

	private static void ReturnAudioSourceToPool(AudioReferences audioReferences)
	{
		if (audioReferences != null && !(audioReferences.source == null))
		{
			AudioReferencesPool.Add(audioReferences);
			audioReferences.doppler.Disable();
			AudioSource source = audioReferences.source;
			source.Stop();
			source.rolloffMode = AudioRolloffMode.Logarithmic;
			source.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, resetCurve);
			source.SetCustomCurve(AudioSourceCurveType.SpatialBlend, resetCurve);
			source.SetCustomCurve(AudioSourceCurveType.Spread, resetCurve);
			source.minDistance = 1f;
			source.maxDistance = 500f;
			source.spread = 0f;
			source.pitch = 1f;
			source.volume = 1f;
			source.ignoreListenerPause = false;
			source.transform.SetParent(poolParent);
			source.gameObject.SetActive(value: false);
			source.enabled = true;
		}
	}

	public static AudioReferences Play(this AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f, float spread = 0f, float minDistance = 1f, float maxDistance = 500f, AudioSourceCurves curves = default(AudioSourceCurves), AudioMixerGroup mixerGroup = null, Transform parent = null, bool randomizeStart = false, float playFromTime = 0f, DopplerRequest? dopplerRequest = null)
	{
		if (volume == 0f)
		{
			return null;
		}
		if (pitch == 0f)
		{
			return null;
		}
		if (clip == null)
		{
			Debug.LogError("No AudioClip was passed");
			return null;
		}
		AudioReferences audioReferences = RequestAudioReference();
		AudioSource source = audioReferences.source;
		source.transform.position = position;
		if (curves.reverb != null)
		{
			source.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, curves.reverb);
		}
		if (curves.rolloff != null)
		{
			source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, curves.rolloff);
			source.rolloffMode = AudioRolloffMode.Custom;
		}
		if (curves.spread != null)
		{
			source.SetCustomCurve(AudioSourceCurveType.Spread, curves.spread);
		}
		else
		{
			source.spread = spread;
		}
		if (curves.spatial != null)
		{
			source.SetCustomCurve(AudioSourceCurveType.SpatialBlend, curves.spatial);
		}
		else
		{
			source.spatialBlend = 1f;
		}
		source.minDistance = minDistance;
		source.maxDistance = maxDistance;
		source.loop = false;
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.time = ((playFromTime > 0f) ? playFromTime : (randomizeStart ? clip.GetRandomTime() : 0f));
		source.dopplerLevel = 0f;
		if (mixerGroup == null)
		{
			mixerGroup = Default3DMixerGroup;
		}
		source.outputAudioMixerGroup = mixerGroup;
		if ((bool)parent)
		{
			source.transform.parent = parent;
		}
		if (playFromTime >= 0f)
		{
			source.Play();
		}
		else
		{
			source.PlayDelayed(0f - playFromTime);
		}
		if (dopplerRequest.HasValue)
		{
			Doppler doppler = audioReferences.doppler;
			doppler.SetDesiredPitch(pitch);
			doppler.Enable();
			DopplerRequest dEFAULT = DopplerRequest.DEFAULT;
			if (dopplerRequest.Value.useSpatialBlend.HasValue)
			{
				dEFAULT.useSpatialBlend = dopplerRequest.Value.useSpatialBlend.Value;
			}
			if (dopplerRequest.Value.updateMode.HasValue)
			{
				dEFAULT.updateMode = dopplerRequest.Value.updateMode.Value;
			}
			doppler.useSpatialBlend = dEFAULT.useSpatialBlend.Value;
			doppler.ChangeMode(dEFAULT.updateMode.Value);
		}
		float delay = Mathf.Ceil(clip.length - source.time) / pitch;
		audioTimer.RequestInformWhenSourceStopsPlaying(audioReferences, delay);
		return audioReferences;
	}

	public static AudioReferences Play(this AudioClip[] clips, Vector3 position, float volume = 1f, float pitch = 1f, float spread = 0f, float minDistance = 1f, float maxDistance = 500f, AudioSourceCurves curves = default(AudioSourceCurves), AudioMixerGroup mixerGroup = null, Transform parent = null, bool randomizeStart = false, float playFromTime = 0f, DopplerRequest? dopplerRequest = null)
	{
		return clips[Random.Range(0, clips.Length)].Play(position, volume, pitch, spread, minDistance, maxDistance, curves, mixerGroup, parent, randomizeStart, playFromTime, dopplerRequest);
	}

	public static AudioReferences Play2D(this AudioClip clip, float volume = 1f, bool playDuringPause = false, bool randomizeStart = false)
	{
		AudioReferences audioReferences = RequestAudioReference();
		AudioSource source = audioReferences.source;
		source.loop = false;
		source.outputAudioMixerGroup = Default2DMixerGroup;
		source.spatialBlend = 0f;
		source.ignoreListenerPause = playDuringPause;
		source.maxDistance = 1000000f;
		source.minDistance = 1000000f;
		source.time = (randomizeStart ? clip.GetRandomTime() : 0f);
		source.PlayOneShot(clip, volume);
		audioTimer.RequestInformWhenSourceStopsPlaying(audioReferences, Mathf.Ceil(clip.length), playDuringPause);
		return audioReferences;
	}

	public static AudioReferences Play2D(this AudioClip[] clips, float volume = 1f, bool playDuringPause = false, bool randomizeStart = false)
	{
		return clips[Random.Range(0, clips.Length)].Play2D(volume, playDuringPause, randomizeStart);
	}

	public static AudioReferences CreateSource(Transform at = null, AudioClip clip = null, float volume = 1f, float pitch = 1f, bool loop = true, bool playAtStart = false, float minDistance = 1f, float maxDistance = 500f, float spread = 0f, float spatialBlend = 1f, AudioMixerGroup mixerGroup = null)
	{
		GameObject gameObject = new GameObject("AudioSource");
		gameObject.transform.parent = at;
		gameObject.transform.localPosition = Vector3.zero;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.loop = loop;
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.spatialBlend = spatialBlend;
		audioSource.spread = spread;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.playOnAwake = playAtStart;
		if (!playAtStart)
		{
			audioSource.Stop();
		}
		if (mixerGroup == null)
		{
			mixerGroup = ((spatialBlend > 0f) ? Default3DMixerGroup : Default2DMixerGroup);
		}
		audioSource.outputAudioMixerGroup = mixerGroup;
		Doppler doppler = gameObject.AddComponent<Doppler>();
		return new AudioReferences(audioSource, doppler);
	}

	public static void PlayRandomTime(this AudioSource source)
	{
		if (!(source.clip == null))
		{
			if (!source.gameObject.activeInHierarchy)
			{
				Debug.LogWarning("Can not play a disabled audio source '" + source.clip.name + "' on " + source.gameObject.GetPath(), source);
				return;
			}
			source.time = source.clip.GetRandomTime();
			source.Play();
		}
	}

	public static float GetRandomTime(this AudioClip clip)
	{
		return Random.Range(0f, clip.length * 0.9f);
	}
}
