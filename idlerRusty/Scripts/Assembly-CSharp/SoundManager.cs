using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager ins;

	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private AudioSource effectsSource;

	private void Awake()
	{
		if (ins != null && ins != this)
		{
			Object.Destroy(this);
			return;
		}
		ins = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		musicSource.Play();
	}

	public void PlaySound(AudioClip clip)
	{
		if (!(clip == null))
		{
			effectsSource.PlayOneShot(clip);
		}
	}

	public void PlaySound(AudioClip[] clips)
	{
		if (clips.Length != 0)
		{
			effectsSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
		}
	}

	public void ChangeEffectsVolume(float value)
	{
		SaveData.ins.soundFX = value;
		SetEffectsVolume(value);
	}

	public void SetEffectsVolume(float value)
	{
		effectsSource.volume = value * 0.1f;
	}

	public void ChangeMusicVolume(float value)
	{
		SaveData.ins.musicFX = value;
		SetMusicVolume(value);
	}

	public void SetMusicVolume(float value)
	{
		musicSource.volume = value * 0.1f;
	}
}
