using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Multiplayer;

public class MusicPlayerManager : NoktaSingleton<MusicPlayerManager>
{
	[CompilerGenerated]
	private sealed class _003CFadeIn_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicPlayerManager _003C_003E4__this;

		public float fadeTime;

		private float _003CelapsedTime_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CFadeIn_003Ed__45(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CFadeOut_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicPlayerManager _003C_003E4__this;

		public float fadeTime;

		private AudioSource[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private AudioSource _003CmusicPlayerAudioSource_003E5__4;

		private float _003CstartVolume_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CFadeOut_003Ed__44(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSkipTrack_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicPlayerManager _003C_003E4__this;

		public int direction;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CSkipTrack_003Ed__28(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitFinish_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MusicPlayerManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitFinish_003Ed__37(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("List of Tracks")]
	[SerializeField]
	private TrackSO[] audioTracks;

	[SerializeField]
	private Image m_MusicArt;

	[SerializeField]
	private Image m_pauseImage;

	[SerializeField]
	private Image m_playImage;

	public int trackIndex;

	public bool isTrackPlay;

	public float audioVolume;

	public float playBackTime;

	public Slider volumeSlider;

	public Slider timerSlider;

	[Header("Text UI")]
	[SerializeField]
	private TextMeshProUGUI trackTextUI;

	[SerializeField]
	private NetworkMusicPlayerManager m_NetworkMusicPlayerManager;

	private Coroutine m_cachedFinishNumerator;

	private AudioSource[] childAudioSources;

	public Action onMusicPlayed;

	private void Start()
	{
	}

	public void SyncData(int index, float volume, float playbackTime, bool trackPlay)
	{
	}

	private void Update()
	{
	}

	private void OnApplicationQuit()
	{
	}

	public void OnVolumeChange(float value)
	{
	}

	public void OnVolumeChangeOrder(float value)
	{
	}

	public void OnTimerChange(float value)
	{
	}

	public void SkipForwardButton()
	{
	}

	public void SkipForwardButtonOrder()
	{
	}

	public void SkipBackwardButton()
	{
	}

	public void SkipBackwardButtonOrder()
	{
	}

	public void SetPlayBackTime()
	{
	}

	public void CleanEmptyAudioSources(AudioSource[] audioSources)
	{
	}

	[IteratorStateMachine(typeof(_003CSkipTrack_003Ed__28))]
	private IEnumerator SkipTrack(int direction)
	{
		return null;
	}

	private void UpdateTrack(int index)
	{
	}

	public void SyncSpeaker()
	{
	}

	public void AudioVolume(float volume)
	{
	}

	public void AudioTime(float time)
	{
	}

	public void GamepadAudioTime(bool isDec)
	{
	}

	public void GamepadAudioVolume(bool isDec)
	{
	}

	public void PlayAudio()
	{
	}

	public void PlayAudioOrder()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitFinish_003Ed__37))]
	private IEnumerator WaitFinish()
	{
		return null;
	}

	private void CheckFinish()
	{
	}

	public void PauseAudio()
	{
	}

	public void PauseAudioOrder()
	{
	}

	public void GamepadSwitchPlay()
	{
	}

	public void StopAudio()
	{
	}

	public void StopAudioOrder()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeOut_003Ed__44))]
	public IEnumerator FadeOut(float fadeTime)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CFadeIn_003Ed__45))]
	public IEnumerator FadeIn(float fadeTime)
	{
		return null;
	}
}
