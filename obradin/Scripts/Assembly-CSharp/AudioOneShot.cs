using UnityEngine;

public class AudioOneShot : MonoBehaviour
{
	private AudioSource audioSource;

	private bool attachedToHost;

	private int numDoneFrames;

	private float fadingOutSpeed;

	private Clock clock;

	private float startTime;

	public float time
	{
		get
		{
			return (!(audioSource != null)) ? 0f : audioSource.time;
		}
	}

	public float volume
	{
		get
		{
			return (!(audioSource != null)) ? 0f : audioSource.volume;
		}
		set
		{
			if (audioSource != null && !fadingOut)
			{
				audioSource.volume = value;
			}
		}
	}

	public bool paused
	{
		get
		{
			return audioSource != null && audioSource.clip != null && !audioSource.isPlaying && audioSource.time > 0f && audioSource.time < audioSource.clip.length - 0.01f;
		}
		set
		{
			if (value != paused)
			{
				if (value)
				{
					audioSource.Pause();
				}
				else
				{
					audioSource.UnPause();
				}
			}
		}
	}

	public bool done
	{
		get
		{
			return audioSource == null || audioSource.clip == null || (!audioSource.isPlaying && !paused && clock.running);
		}
	}

	public bool fadingOut
	{
		get
		{
			return fadingOutSpeed > 0f;
		}
	}

	public float timeSinePlay
	{
		get
		{
			return clock.time - startTime;
		}
	}

	private void Update()
	{
		if (!done && fadingOutSpeed > 0f)
		{
			float num = audioSource.volume - fadingOutSpeed * Clock.active.deltaTime;
			if (num > 0f)
			{
				audioSource.volume = num;
			}
			else
			{
				audioSource.Stop();
			}
		}
		if (done)
		{
			numDoneFrames++;
			if (numDoneFrames > 1)
			{
				if (attachedToHost)
				{
					Object.Destroy(this);
				}
				else
				{
					Object.Destroy(base.gameObject);
				}
			}
		}
		else
		{
			numDoneFrames = 0;
		}
	}

	private void PlayInternal(AudioClip clip, bool loop)
	{
		audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.loop = loop;
		audioSource.Play();
		clock = Clock.active;
		fadingOutSpeed = 0f;
		startTime = clock.time;
	}

	public void Stop(float fadeTime = 0f)
	{
		if (audioSource == null || (!audioSource.isPlaying && !paused))
		{
			return;
		}
		if (fadeTime == 0f)
		{
			audioSource.Stop();
			return;
		}
		fadingOutSpeed = volume / fadeTime;
		if (fadingOutSpeed == 0f)
		{
			audioSource.Stop();
		}
	}

	public static AudioOneShot Play(AudioClip clip, bool loop = false, float volume = 1f)
	{
		AudioOneShot audioOneShot = PlayStatic(null, clip, loop);
		audioOneShot.volume = volume;
		return audioOneShot;
	}

	public static AudioOneShot Play(GameObject hostGo, AudioClip clip, bool loop = false)
	{
		return PlayStatic(hostGo, clip, loop);
	}

	public static AudioOneShot Play3D(GameObject hostGo, AudioClip clip, bool loop = false, float minDistance = -1f, float maxDistance = -1f)
	{
		AudioOneShot audioOneShot = PlayStatic(hostGo, clip, loop, true);
		if ((bool)audioOneShot)
		{
			audioOneShot.Make3D();
			if (minDistance >= 0f)
			{
				audioOneShot.audioSource.minDistance = minDistance;
			}
			if (maxDistance >= 0f)
			{
				audioOneShot.audioSource.maxDistance = maxDistance;
			}
		}
		return audioOneShot;
	}

	public static AudioOneShot Play3D(Vector3 position, AudioClip clip, bool loop = false)
	{
		AudioOneShot audioOneShot = PlayStatic(null, clip, loop, true);
		if ((bool)audioOneShot)
		{
			audioOneShot.transform.position = position;
			audioOneShot.Make3D();
		}
		return audioOneShot;
	}

	private static AudioOneShot PlayStatic(GameObject hostGo, AudioClip clip, bool loop = false, bool threed = false)
	{
		if (clip == null)
		{
			return null;
		}
		AudioOneShot audioOneShot = null;
		if (hostGo != null)
		{
			audioOneShot = hostGo.AddComponent<AudioOneShot>();
			audioOneShot.attachedToHost = true;
		}
		else
		{
			GameObject gameObject = new GameObject("AudioOneShot (" + clip.name + ")");
			audioOneShot = gameObject.AddComponent<AudioOneShot>();
			Object.DontDestroyOnLoad(gameObject);
		}
		audioOneShot.PlayInternal(clip, loop);
		return audioOneShot;
	}

	public static void StopAll(float fadeTime = 0f)
	{
		AudioOneShot[] array = Object.FindObjectsOfType<AudioOneShot>();
		AudioOneShot[] array2 = array;
		foreach (AudioOneShot audioOneShot in array2)
		{
			audioOneShot.Stop(fadeTime);
		}
	}

	private void Make3D()
	{
		audioSource.spatialBlend = 1f;
	}
}
