using System;
using DV.DopplerEffects;
using UnityEngine;
using UnityEngine.Audio;

public class LayeredAudio : MonoBehaviour
{
	public enum Type
	{
		Continuous = 0,
		OneTime = 1
	}

	[Serializable]
	public class Layer
	{
		public string name;

		public AnimationCurve volumeCurve;

		public bool usePitchCurve;

		public AnimationCurve pitchCurve;

		public float inertia;

		public bool inertialPitch;

		[NonSerialized]
		public Doppler doppler;

		[NonSerialized]
		public bool useDoppler;

		[NonSerialized]
		public bool randomizeStartTime;

		[Tooltip("For Continuous: AudioSource to play and set values to.\nFor One Time: This source will be used as a template for automatically created individual sources")]
		public AudioSource source;

		[Tooltip("If assigned, these will be used randomly on the source. Used only for one time effects (for now)")]
		public AudioClip[] clips;

		[Tooltip("Pitch variation for each clip play")]
		public Vector2 pitchRange = new Vector2(1f, 1f);

		[NonSerialized]
		public float refVelo;

		[NonSerialized]
		public float startPitch;

		public void SetVolume(float level, float masterVolume)
		{
			float num = volumeCurve.Evaluate(level) * masterVolume;
			source.volume = ((inertia == 0f) ? num : Mathf.SmoothDamp(source.volume, num, ref refVelo, inertia));
			bool isPlaying = source.isPlaying;
			if (isPlaying && source.volume < 0.01f)
			{
				source.Stop();
				source.enabled = false;
				if (useDoppler)
				{
					doppler.Disable();
				}
			}
			else if (!isPlaying && source.volume >= 0.01f)
			{
				source.enabled = true;
				if (useDoppler)
				{
					doppler.Enable();
				}
				if (randomizeStartTime)
				{
					source.PlayRandomTime();
				}
				else
				{
					source.Play();
				}
			}
		}

		public void SetPitch(float value, bool linearPitchLerp = false, float minPitch = 1f, float maxPitch = 1f)
		{
			float num = (usePitchCurve ? (startPitch * pitchCurve.Evaluate(value)) : ((!linearPitchLerp) ? startPitch : (startPitch * Mathf.Lerp(minPitch, maxPitch, value))));
			if (useDoppler)
			{
				doppler.SetDesiredPitch(num);
			}
			else
			{
				source.pitch = num;
			}
		}
	}

	private const float DEFAULT_MIN_DISTANCE = 1f;

	private const float DEFAULT_MAX_DISTANCE = 500f;

	private const float DEFAULT_SPREAD = 0f;

	private const float ONE_TIME_VOLUME_THRESHOLD = 0.01f;

	private const float STOP_VOLUME_THRESHOLD = 0.01f;

	[SerializeField]
	private float masterVolume = 1f;

	public Type type;

	public bool linearPitchLerp = true;

	public float minPitch = 1f;

	public float maxPitch = 1f;

	public AudioMixerGroup audioMixerGroup;

	public bool randomizeStartTime = true;

	private float lastVolumeInput = float.PositiveInfinity;

	private float lastPitchInput = float.PositiveInfinity;

	private bool isDirty;

	private bool hasInertia;

	public Layer[] layers;

	private bool isInited;

	public float MasterVolume
	{
		get
		{
			return masterVolume;
		}
		set
		{
			isDirty = masterVolume != value;
			masterVolume = value;
		}
	}

	public void PlayOnce(Vector3 position, float value, Transform parent = null)
	{
		float num = GetPitch(value);
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			float num2 = layer.volumeCurve.Evaluate(value);
			if (!(num2 <= 0.01f))
			{
				float minDistance = (layer.source ? layer.source.minDistance : 1f);
				float maxDistance = (layer.source ? layer.source.maxDistance : 500f);
				float spread = (layer.source ? layer.source.spread : 0f);
				if (layer.pitchRange.x != 1f || layer.pitchRange.y != 1f)
				{
					num *= UnityEngine.Random.Range(layer.pitchRange.x, layer.pitchRange.y);
				}
				NAudio.Play(curves: new AudioSourceCurves(layer.source.GetCustomCurve(AudioSourceCurveType.CustomRolloff), layer.source.GetCustomCurve(AudioSourceCurveType.ReverbZoneMix), layer.source.GetCustomCurve(AudioSourceCurveType.SpatialBlend), layer.source.GetCustomCurve(AudioSourceCurveType.Spread)), clips: layer.clips, position: position, volume: num2, pitch: layer.startPitch + num, spread: spread, minDistance: minDistance, maxDistance: maxDistance, mixerGroup: audioMixerGroup, parent: parent, randomizeStart: randomizeStartTime);
			}
		}
	}

	private float GetPitch(float value)
	{
		return Mathf.Lerp(minPitch, maxPitch, value);
	}

	public void Reset()
	{
		if (type == Type.OneTime || layers == null || layers.Length == 0)
		{
			return;
		}
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			layer.source.volume = 0f;
			if (!isInited)
			{
				layer.startPitch = layer.source.pitch;
				layer.randomizeStartTime = randomizeStartTime;
			}
		}
		lastVolumeInput = float.PositiveInfinity;
		lastPitchInput = float.PositiveInfinity;
		isInited = true;
	}

	private void Awake()
	{
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			layer.doppler = layer.source.GetComponent<Doppler>();
			layer.useDoppler = layer.doppler;
			if (layer.source == null)
			{
				Debug.LogError("LayeredAudio has Layer with source set to null!", base.gameObject);
				continue;
			}
			layer.source.outputAudioMixerGroup = audioMixerGroup;
			if (layer.inertia != 0f)
			{
				hasInertia = true;
			}
			if (layer.source.volume < 0.01f)
			{
				layer.source.enabled = false;
			}
		}
	}

	public void Play()
	{
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			layer.source.enabled = true;
			if (randomizeStartTime)
			{
				layer.source.PlayRandomTime();
			}
			else
			{
				layer.source.Play();
			}
		}
	}

	public void PitchMultiply(float pitch)
	{
		Layer[] array = layers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].startPitch *= pitch;
		}
	}

	public void Stop()
	{
		Layer[] array = layers;
		foreach (Layer obj in array)
		{
			obj.source.Stop();
			obj.source.enabled = false;
		}
	}

	public void Set(float level)
	{
		if (!isInited)
		{
			Reset();
			isInited = true;
		}
		if (hasInertia || isDirty || lastVolumeInput != level || lastPitchInput != level)
		{
			Layer[] array = layers;
			foreach (Layer layer in array)
			{
				layer.SetVolume(level, masterVolume);
				float value = (layer.inertialPitch ? layer.source.volume : Mathf.Abs(level));
				layer.SetPitch(value, linearPitchLerp, minPitch, maxPitch);
			}
			lastVolumeInput = level;
			lastPitchInput = level;
			isDirty = false;
		}
	}

	public void SetVolume(float level)
	{
		if (!isInited)
		{
			Reset();
			isInited = true;
		}
		if (hasInertia || isDirty || lastVolumeInput != level)
		{
			Layer[] array = layers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetVolume(level, masterVolume);
			}
			lastVolumeInput = level;
			isDirty = false;
		}
	}

	public void SetPitch(float level)
	{
		if (!isInited)
		{
			Reset();
			isInited = true;
		}
		if (lastPitchInput != level)
		{
			Layer[] array = layers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetPitch(level, linearPitchLerp, minPitch, maxPitch);
			}
			lastPitchInput = level;
		}
	}

	public void RefreshVolumeAndPitch()
	{
		if (lastVolumeInput != float.PositiveInfinity)
		{
			SetVolume(lastVolumeInput);
		}
		if (lastPitchInput != float.PositiveInfinity)
		{
			SetPitch(lastPitchInput);
		}
	}

	public float GetLowestVolume()
	{
		float num = float.PositiveInfinity;
		Layer[] array = layers;
		foreach (Layer layer in array)
		{
			if (layer.source.volume < num)
			{
				num = layer.source.volume;
			}
		}
		return num;
	}

	public bool IsPlaying()
	{
		Layer[] array = layers;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].source.isPlaying)
			{
				return true;
			}
		}
		return false;
	}
}
