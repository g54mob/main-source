using System;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Radio : MonoBehaviour
{
	[SerializeField]
	private AudioSource music_AudioSource;

	[SerializeField]
	private AudioSource source_RadioStatic;

	private bool isNightTime;

	public Action Action_ButtonClicked_Center;

	public Action Action_ButtonClicked_Right;

	public Action Action_ButtonClicked_Left;

	private float staticPlayTime_Curr;

	private bool static_PlayMusicAfter;

	private float static_CrossfadeVal;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player feedback_UpButton;

	[SerializeField]
	private MMF_Player feedback_DownButton;

	[SerializeField]
	private MMF_Player feedback_PowerButton;

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnNightTime()
	{
		isNightTime = true;
	}

	private void Update()
	{
		if (music_AudioSource.isPlaying)
		{
			if (isNightTime)
			{
				music_AudioSource.volume = 0f;
			}
			else
			{
				music_AudioSource.volume = AudioManager.Singleton.musicVolume * 0.225f;
			}
		}
		HandleRadioStaticTimer();
	}

	public void ToggleRadio()
	{
		PlayerStats.Singleton.radio_IsTurnedOn = !PlayerStats.Singleton.radio_IsTurnedOn;
		AudioManager.Singleton.PlaySFX_MouseClick();
		if (PlayerStats.Singleton.radio_IsTurnedOn)
		{
			PlayRadioMusic();
		}
		else
		{
			StopRadioMusic();
		}
		Action_ButtonClicked_Center?.Invoke();
		feedback_PowerButton?.PlayFeedbacks();
	}

	public void SetRadioPower(bool _on)
	{
		PlayerStats.Singleton.radio_IsTurnedOn = _on;
		if (PlayerStats.Singleton.radio_IsTurnedOn)
		{
			PlayRadioMusic();
		}
		else
		{
			StopRadioMusic();
		}
	}

	public void ChangeRadioChannel_Up()
	{
		if (PlayerStats.Singleton.radio_ChannelIndex >= AudioManager.RADIO_CHANNEL_COUNT - 1)
		{
			PlayerStats.Singleton.radio_ChannelIndex = 0;
		}
		else
		{
			PlayerStats.Singleton.radio_ChannelIndex++;
		}
		SetRadioPower(_on: true);
		Action_ButtonClicked_Right?.Invoke();
		AudioManager.Singleton.PlaySFX_MouseClick();
		feedback_UpButton?.PlayFeedbacks();
	}

	public void ChangeRadioChannel_Down()
	{
		if (PlayerStats.Singleton.radio_ChannelIndex > 0)
		{
			PlayerStats.Singleton.radio_ChannelIndex--;
		}
		else
		{
			PlayerStats.Singleton.radio_ChannelIndex = AudioManager.RADIO_CHANNEL_COUNT - 1;
		}
		SetRadioPower(_on: true);
		Action_ButtonClicked_Left?.Invoke();
		AudioManager.Singleton.PlaySFX_MouseClick();
		feedback_DownButton?.PlayFeedbacks();
	}

	public void PlayRadioMusic()
	{
		try
		{
			if (music_AudioSource.isPlaying)
			{
				music_AudioSource.Stop();
			}
			List<AudioClip> list = AudioManager.Singleton.radioChannels_Master[PlayerStats.Singleton.radio_ChannelIndex];
			if (list.Count < 0)
			{
				StopRadioMusic();
				return;
			}
			music_AudioSource.clip = list[UnityEngine.Random.Range(0, list.Count)];
			music_AudioSource.Play();
		}
		catch
		{
			Debug.Log("Failed to play radio, Ignoring!");
		}
	}

	public void StopRadioMusic()
	{
		music_AudioSource.Stop();
	}

	public void OnRoundStart_CheckIfWeShouldPlayMusic()
	{
		if (PlayerStats.Singleton.radio_IsTurnedOn)
		{
			PlayRadioMusic();
		}
		else
		{
			StopRadioMusic();
		}
	}

	public void StartPlayingStatic(float _duration)
	{
		static_PlayMusicAfter = music_AudioSource.isPlaying || source_RadioStatic.isPlaying;
		if (music_AudioSource.isPlaying)
		{
			staticPlayTime_Curr = _duration;
			static_CrossfadeVal = 1f;
			music_AudioSource.Pause();
			source_RadioStatic.volume = AudioManager.Singleton.musicVolume;
			source_RadioStatic.time = UnityEngine.Random.Range(0f, source_RadioStatic.clip.length);
			source_RadioStatic.Play();
		}
	}

	private void HandleRadioStaticTimer()
	{
		if (staticPlayTime_Curr > 0f)
		{
			staticPlayTime_Curr -= Time.deltaTime;
			_ = staticPlayTime_Curr;
			_ = 0f;
			return;
		}
		staticPlayTime_Curr = 0f;
		if (static_PlayMusicAfter)
		{
			if (static_CrossfadeVal > 0f)
			{
				static_CrossfadeVal -= Time.deltaTime * 0.15f;
				music_AudioSource.volume = Mathf.Lerp(AudioManager.Singleton.musicVolume * 0.225f, 0f, static_CrossfadeVal);
				source_RadioStatic.volume = Mathf.Lerp(0f, AudioManager.Singleton.musicVolume, static_CrossfadeVal);
				if (!music_AudioSource.isPlaying)
				{
					music_AudioSource.Play();
				}
				if (static_CrossfadeVal <= 0f)
				{
					source_RadioStatic.Stop();
				}
			}
		}
		else
		{
			static_CrossfadeVal = 0f;
		}
	}

	public void PlaySpookyStaticIndefinitely()
	{
		music_AudioSource.Stop();
		source_RadioStatic.loop = true;
		source_RadioStatic.volume = AudioManager.Singleton.musicVolume * 2.5f;
		source_RadioStatic.Play();
	}
}
