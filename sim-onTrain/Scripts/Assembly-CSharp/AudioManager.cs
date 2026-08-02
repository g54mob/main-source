using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
	[Header("Mixer")]
	[SerializeField]
	private AudioMixer mixer;

	[SerializeField]
	private AudioMixerGroup musicGroup;

	[SerializeField]
	private AudioMixerGroup sfxGroup;

	[SerializeField]
	private AudioMixerGroup uiGroup;

	[SerializeField]
	private AudioMixerGroup ambienceGroup;

	[Header("Sources")]
	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private AudioSource uiSource;

	public AudioMixerGroup AmbienceGroup => ambienceGroup;

	private void Awake()
	{
		if (musicSource != null)
		{
			musicSource.outputAudioMixerGroup = musicGroup;
		}
		if (uiSource != null)
		{
			uiSource.outputAudioMixerGroup = uiGroup;
		}
	}

	public void PlayMusic(AudioClip clip, float volume = 1f, bool loop = true)
	{
		if ((bool)clip && !(musicSource == null))
		{
			musicSource.clip = clip;
			musicSource.loop = loop;
			musicSource.volume = Mathf.Clamp01(volume);
			musicSource.Play();
		}
	}

	public void StopMusic()
	{
		if ((bool)musicSource)
		{
			musicSource.Stop();
		}
	}

	public void PlaySFX(AudioClip clip, float volume = 1f)
	{
		if ((bool)clip)
		{
			AudioSource.PlayClipAtPoint(clip, Vector3.zero, Mathf.Clamp01(volume));
		}
	}

	public void PlayUI(AudioClip clip, float volume = 1f)
	{
		if ((bool)clip && !(uiSource == null))
		{
			uiSource.PlayOneShot(clip, Mathf.Clamp01(volume));
		}
	}

	public static float LinearToDb(float linear)
	{
		if (!(linear <= 0.0001f))
		{
			return Mathf.Log10(Mathf.Clamp(linear, 0.0001f, 1f)) * 20f;
		}
		return -80f;
	}

	public static float DbToLinear(float db)
	{
		return Mathf.Pow(10f, db / 20f);
	}

	public void SetMaster(float linear)
	{
		mixer.SetFloat("Master", LinearToDb(linear));
	}

	public void SetMusic(float linear)
	{
		mixer.SetFloat("Music", LinearToDb(linear));
	}

	public void SetSFX(float linear)
	{
		mixer.SetFloat("SFX", LinearToDb(linear));
	}

	public void SetUI(float linear)
	{
		mixer.SetFloat("UI", LinearToDb(linear));
	}

	public void SetAmbience(float linear)
	{
		mixer.SetFloat("Ambience", LinearToDb(linear));
	}

	public void SetMuted(bool muted)
	{
		mixer.SetFloat("Master", muted ? (-80f) : LinearToDb(1f));
	}
}
