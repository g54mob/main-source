using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
	public const float DefaultVolume = 0.5f;

	private float _baseSoundVolume;

	[SerializeField]
	private AudioSource _source;

	[SerializeField]
	private AudioClip _craftStep;

	[SerializeField]
	private AudioClip _craftFinished;

	[SerializeField]
	private AudioClip _windowOpen;

	[SerializeField]
	private AudioClip _windowClose;

	[SerializeField]
	private AudioClip _button;

	[SerializeField]
	private AudioClip _turnPage;

	private HashSet<AudioClip> _played = new HashSet<AudioClip>();

	private List<AudioSource> _sourceCache = new List<AudioSource>();

	public static UISounds Instance { get; private set; }

	public static float Volume
	{
		get
		{
			return PlayerPrefs.GetFloat("SoundVolume", 1f);
		}
		set
		{
			PlayerPrefs.SetFloat("SoundVolume", value);
			Instance._updateVolume();
		}
	}

	private void Awake()
	{
		Instance = this;
		_sourceCache.Add(_source);
		_updateVolume();
	}

	private void Update()
	{
		_played.Clear();
	}

	public void PlaySound(AudioClip clip)
	{
		PlaySound(clip, 0.5f);
	}

	public void PlaySound(AudioClip clip, float volume)
	{
		if (_played.Contains(clip))
		{
			return;
		}
		_played.Add(clip);
		AudioSource audioSource = null;
		foreach (AudioSource item in _sourceCache)
		{
			if (!item.isPlaying)
			{
				audioSource = item;
				break;
			}
		}
		if (audioSource == null)
		{
			audioSource = Object.Instantiate(_sourceCache[0], base.transform);
			_sourceCache.Add(audioSource);
		}
		audioSource.clip = clip;
		audioSource.volume = volume * _baseSoundVolume;
		audioSource.pitch = SeededRandom.Global.RandomRange(0.98f, 1.02f);
		audioSource.Play();
	}

	private void _updateVolume()
	{
		_baseSoundVolume = Volume;
	}

	public static void CraftStep()
	{
		Instance.PlaySound(Instance._craftStep, 0.2f);
	}

	public static void CraftFinished()
	{
		Instance.PlaySound(Instance._craftFinished);
	}

	public static void WindowOpen()
	{
		Instance.PlaySound(Instance._windowOpen);
	}

	public static void WindowClose()
	{
		Instance.PlaySound(Instance._windowClose);
	}

	public static void Button()
	{
		Instance.PlaySound(Instance._button);
	}

	public static void TurnPage()
	{
		Instance.PlaySound(Instance._turnPage, 0.35f);
	}

	public static void PreviewVolume(float vol)
	{
		if ((bool)Instance)
		{
			Instance._baseSoundVolume = vol;
		}
	}
}
