using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
	[SerializeField]
	private AudioMixer _baseMixer;

	[Header("BGM")]
	[SerializeField]
	private AudioMixerGroup _bgmMixerGroup;

	[SerializeField]
	private AudioSource _bgmSource;

	[SerializeField]
	private List<AudioClip> _bgmClipList;

	private Dictionary<BGMType, AudioClip> _bgmClipDict = new Dictionary<BGMType, AudioClip>();

	[Header("SFX")]
	[SerializeField]
	private AudioMixerGroup _sfxMixerGroup;

	[SerializeField]
	private AudioSource _sfxSource;

	[SerializeField]
	private List<AudioClip> _sfxClipList;

	[SerializeField]
	private Transform _sfxSourcePoolParent;

	[SerializeField]
	private int _poolCount = 20;

	private Queue<AudioSource> _sfxSourcePool = new Queue<AudioSource>();

	private Dictionary<SFXType, AudioClip> _sfxClipDict = new Dictionary<SFXType, AudioClip>();

	public float CurrentBGMVolume { get; private set; } = 1f;

	public float CurrentSFXVolume { get; private set; } = 1f;

	public void Init()
	{
		Set_BGMClipDict();
		Set_SFXClipDict();
		Fill_SFXSourcePool();
	}

	public void PlayBGM(BGMType bgmType)
	{
		if (_bgmClipDict.ContainsKey(bgmType))
		{
			_bgmSource.outputAudioMixerGroup = _bgmMixerGroup;
			_bgmSource.clip = _bgmClipDict[bgmType];
			_bgmSource.loop = true;
			_bgmSource.Play();
		}
	}

	public void SetBGMVolume(float volume)
	{
		float value = ((!(volume <= 0f)) ? (Mathf.Log10(volume) * 20f) : (-80f));
		_baseMixer.SetFloat("BGMVolume", value);
		CurrentBGMVolume = volume;
	}

	private void Set_BGMClipDict()
	{
		foreach (AudioClip bgmClip in _bgmClipList)
		{
			string text = bgmClip.name;
			if (Enum.TryParse<BGMType>(text, out var result))
			{
				_bgmClipDict[result] = bgmClip;
			}
			else
			{
				Debug.Log(text + " 오디오클립 딕셔너리로 변환실패!");
			}
		}
	}

	public void MuteBGM(bool mute)
	{
		if (mute)
		{
			_baseMixer.SetFloat("BGMVolume", -80f);
		}
		else
		{
			SetBGMVolume(CurrentBGMVolume);
		}
	}

	public void PlaySFX(SFXType sfxType)
	{
		if (_sfxClipDict.ContainsKey(sfxType))
		{
			AudioSource audioSource = ((_sfxSourcePool.Count > 0) ? _sfxSourcePool.Dequeue() : Fill_SFXSourcePool());
			audioSource.outputAudioMixerGroup = _sfxMixerGroup;
			audioSource.clip = _sfxClipDict[sfxType];
			audioSource.gameObject.SetActive(value: true);
			audioSource.Play();
			StartCoroutine(ReturnSFXAsync(audioSource));
		}
	}

	private AudioSource Fill_SFXSourcePool()
	{
		for (int i = 0; i < _poolCount; i++)
		{
			AudioSource audioSource = UnityEngine.Object.Instantiate(_sfxSource, _sfxSourcePoolParent);
			audioSource.outputAudioMixerGroup = _sfxMixerGroup;
			audioSource.gameObject.SetActive(value: false);
			_sfxSourcePool.Enqueue(audioSource);
		}
		return _sfxSourcePool.Dequeue();
	}

	private IEnumerator ReturnSFXAsync(AudioSource sfxSource)
	{
		yield return new WaitForSeconds(sfxSource.clip.length);
		sfxSource.gameObject.SetActive(value: false);
		_sfxSourcePool.Enqueue(sfxSource);
	}

	public void SetSFXVolume(float volume)
	{
		float value = ((!(volume <= 0f)) ? (Mathf.Log10(volume) * 20f) : (-80f));
		_baseMixer.SetFloat("SFXVolume", value);
		CurrentSFXVolume = volume;
	}

	private void Set_SFXClipDict()
	{
		foreach (AudioClip sfxClip in _sfxClipList)
		{
			string text = sfxClip.name;
			if (Enum.TryParse<SFXType>(text, out var result))
			{
				_sfxClipDict[result] = sfxClip;
			}
			else
			{
				Debug.Log(text + " 오디오클립 딕셔너리로 변환실패!");
			}
		}
	}

	public void MuteSFX(bool mute)
	{
		if (mute)
		{
			_baseMixer.SetFloat("SFXVolume", -80f);
		}
		else
		{
			SetSFXVolume(CurrentSFXVolume);
		}
	}
}
