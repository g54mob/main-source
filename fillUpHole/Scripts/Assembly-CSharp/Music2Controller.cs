using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music2Controller : MonoBehaviour
{
	private SoundManager _manager;

	public AudioSource MainMusic;

	public AudioSource SubMusic;

	public AudioMixer Mixer;

	public static Music2Controller Instance;

	private SoundManager.SoundTypeEnum _playOnStart;

	private bool _playAndChange;

	private SoundManager.SoundTypeEnum _curMusic;

	private int _musicIndex;

	private List<SoundManager.SoundTypeEnum> _music = new List<SoundManager.SoundTypeEnum>
	{
		SoundManager.SoundTypeEnum.mu_v2_ingame1,
		SoundManager.SoundTypeEnum.mu_v2_ingame2,
		SoundManager.SoundTypeEnum.mu_v2_ingame3,
		SoundManager.SoundTypeEnum.mu_v2_ingame5,
		SoundManager.SoundTypeEnum.mu_v2_ingame7,
		SoundManager.SoundTypeEnum.mu_v2_ingame8
	};

	private void Awake()
	{
		Instance = this;
		_manager = GetComponent<SoundManager>();
	}

	private void Start()
	{
		if (_playOnStart != SoundManager.SoundTypeEnum.none)
		{
			_manager.PlayLoopWithFade(MainMusic, _playOnStart);
		}
	}

	private void Update()
	{
		if (_playAndChange && !MainMusic.isPlaying)
		{
			ChangeMusic();
		}
	}

	public void PlayBeginingMusic()
	{
		_playAndChange = false;
		_manager.PlayLoopWithFade(MainMusic, SoundManager.SoundTypeEnum.mu_beginning);
	}

	public void PlayEndingMusic()
	{
		_playAndChange = false;
		_manager.PlayLoopWithFade(MainMusic, SoundManager.SoundTypeEnum.mu_ending);
	}

	public void PlayMainMusic()
	{
		if (!_playAndChange)
		{
			_playAndChange = true;
			_curMusic = _music[_musicIndex];
			_manager.PlayWithFade(MainMusic, _curMusic);
		}
	}

	private void ChangeMusic()
	{
		if (_playAndChange)
		{
			_musicIndex++;
			if (_musicIndex >= _music.Count)
			{
				_musicIndex = 0;
			}
			_curMusic = _music[_musicIndex];
			_manager.PlayWithFade(MainMusic, _curMusic);
		}
	}

	public void PlayEarthquakeMusic()
	{
		_playAndChange = false;
		_musicIndex++;
		if (_musicIndex >= _music.Count)
		{
			_musicIndex = 0;
		}
		_manager.PlayLoopWithFade(MainMusic, SoundManager.SoundTypeEnum.mu_earthquake_ready);
	}

	public void PlayBeginingWind()
	{
		_playAndChange = false;
		_manager.PlayLoopWithFade(MainMusic, SoundManager.SoundTypeEnum.mu_intro);
	}

	public void PlaySubMenuMusic()
	{
		Mixer.SetFloat("OutsideMusicLowpass", 341f);
		Mixer.SetFloat("OutsideSfxLowpass", 341f);
		Mixer.SetFloat("OutsideMusicVolume", -5f);
		Mixer.SetFloat("OutsideMusicVolume", -5f);
		_manager.PlayLoop(SubMusic, SoundManager.SoundTypeEnum.mu_ingame_menu);
	}

	public void StopSubMenuMusic()
	{
		Mixer.SetFloat("OutsideMusicLowpass", 22000f);
		Mixer.SetFloat("OutsideSfxLowpass", 22000f);
		Mixer.SetFloat("OutsideMusicVolume", 0f);
		Mixer.SetFloat("OutsideMusicVolume", 0f);
		SubMusic.Stop();
	}
}
