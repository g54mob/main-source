using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeIn_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float finalVolume;

		public AudioSource audioSource;

		public float FadeTime;

		private float _003CstartVolume_003E5__2;

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
		public _003CFadeIn_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CFadeOut_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AudioSource audioSource;

		public float FadeTime;

		private float _003CstartVolume_003E5__2;

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
		public _003CFadeOut_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CFadeOut_FadeIn_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AudioManager _003C_003E4__this;

		public AudioSource audioSource;

		public float FadeTime;

		public AudioClip newAudioClip;

		public float finalVolume;

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
		public _003CFadeOut_FadeIn_003Ed__34(int _003C_003E1__state)
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

	public static AudioManager instance;

	[SerializeField]
	private AudioMixer masterMixer;

	public AudioSource musicAudioSource;

	[SerializeField]
	private AudioClip calmMusic;

	private float calmMusicDefaultVolume;

	[SerializeField]
	private AudioClip iddleMusic;

	private float iddleMusicDefaultVolume;

	[SerializeField]
	private AudioClip fastMusic;

	private float fastMusicDefaultVolume;

	private int currentMusic;

	public AudioSource effectsAudioSource;

	public AudioSource delayedAudioSource;

	public AudioClip coinUse;

	public AudioClip AudioClipButtonHover;

	public AudioClip AudioClipButtonClick;

	public AudioClip audioClipObjectiveStart;

	public AudioClip audioClipObjectiveEnd;

	public AudioClip audioClipDeviceInserted;

	public AudioClip audioClipOpeningBox;

	public AudioClip[] audioClipRJ45;

	public AudioClip[] audioClipImpacts;

	public AudioClip audioClipElectronicButton;

	public AudioClip audioClipDeviceStartup;

	public AudioClip audioClipSuccessfullyConnected;

	[SerializeField]
	private AudioClip audioClipRackDoorOpen;

	private void Awake()
	{
	}

	public void SetMusic(int _clipUID)
	{
	}

	public void PlayEffectAudioClip(AudioClip audioClip, float volume = 1f, float delayed = 0f)
	{
	}

	public void SetMasterVolume(float _volume)
	{
	}

	public void SetEffectsVolume(float _volume)
	{
	}

	public void SetMusicVolume(float _volume)
	{
	}

	public void SetRacksVolume(float _volume)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeOut_003Ed__32))]
	public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CFadeIn_003Ed__33))]
	public IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float finalVolume)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CFadeOut_FadeIn_003Ed__34))]
	public IEnumerator FadeOut_FadeIn(AudioSource audioSource, float FadeTime, float finalVolume, AudioClip newAudioClip)
	{
		return null;
	}

	public void PlayRandomRJ45Clip()
	{
	}

	public void PlayRandomImpactClip(float _volume = 0.5f)
	{
	}

	public void PlayRackDoorOpen()
	{
	}
}
