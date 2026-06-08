using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
	public enum VariationMode
	{
		Sequential = 0,
		Randomize = 1
	}

	public string id;

	public VariationMode mode;

	[Range(0.1f, 3f)]
	public float rndPitchMin = 1f;

	[Range(0.1f, 3f)]
	public float rndPitchMax = 1f;

	public AudioSource[] sfxSourceVariations;

	public float startTime;

	private float[] defaultVolumes;

	private float currentDefaultVolume;

	public static Dictionary<string, int> sequentialIndexes = new Dictionary<string, int>();

	public AudioSource currentSfx { get; private set; }

	public bool isPaused { get; private set; }

	private void Update()
	{
		if (currentSfx != null && !currentSfx.isPlaying && !isPaused)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Play(float delay = 0f, float volume = -1f)
	{
		if (sfxSourceVariations.Length != 0)
		{
			int num = 0;
			if (mode == VariationMode.Randomize)
			{
				num = Random.Range(0, sfxSourceVariations.Length);
			}
			else if (mode == VariationMode.Sequential)
			{
				num = GetNextSequentialIndex();
			}
			currentSfx = sfxSourceVariations[num];
			float pitch = Random.Range(rndPitchMin, rndPitchMax);
			currentSfx.pitch = pitch;
			currentDefaultVolume = defaultVolumes[num];
			currentSfx.volume = currentDefaultVolume * volume;
			if (startTime > 0f)
			{
				currentSfx.time = startTime;
			}
			if (delay > 0f)
			{
				currentSfx.PlayDelayed(delay);
			}
			else
			{
				currentSfx.Play();
			}
		}
		else
		{
			Utils.LogWarning("No clips to play for Sfx " + this);
			Object.Destroy(base.gameObject);
		}
	}

	public void Stop()
	{
		if (currentSfx != null)
		{
			currentSfx.Stop();
		}
	}

	public void Pause()
	{
		isPaused = true;
		if (currentSfx != null)
		{
			currentSfx.Pause();
		}
	}

	public void UnPause()
	{
		isPaused = false;
		if (currentSfx != null)
		{
			currentSfx.UnPause();
		}
	}

	public void SetPitch(float pitch)
	{
		if (currentSfx != null)
		{
			currentSfx.pitch = pitch;
		}
	}

	public void SetVolume(float volume)
	{
		currentSfx.volume = currentDefaultVolume * volume;
	}

	private int GetNextSequentialIndex()
	{
		if (sfxSourceVariations.Length == 0)
		{
			return 0;
		}
		if (!sequentialIndexes.ContainsKey(id))
		{
			sequentialIndexes.Add(id, -1);
		}
		int num = sequentialIndexes[id] + 1;
		sequentialIndexes[id] = num;
		return num % sfxSourceVariations.Length;
	}

	private void Awake()
	{
		if (sfxSourceVariations.Length == 0)
		{
			sfxSourceVariations = GetComponents<AudioSource>();
		}
		defaultVolumes = new float[sfxSourceVariations.Length];
		for (int i = 0; i < sfxSourceVariations.Length; i++)
		{
			defaultVolumes[i] = sfxSourceVariations[i].volume;
		}
	}
}
