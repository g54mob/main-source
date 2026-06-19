using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using FMOD.Studio;
using UnityEngine;

public class CoreMusicPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlayNextTrack_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CoreMusicPlayer _003C_003E4__this;

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
		public _003CPlayNextTrack_003Ed__23(int _003C_003E1__state)
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

	public float FadeDuration;

	public List<PriorityMusicSupplier> suppliers;

	private PriorityMusicSupplier currentSupplier;

	private EventInstance currentInstance;

	private Coroutine fadeInRoutine;

	public float TransitionBuffer;

	private float _volume;

	private bool _transitioning;

	public Dictionary<string, float> VolumeModifiers;

	public Coroutine SongRoutine;

	public float FadeOutDurationOverride;

	public static CoreMusicPlayer Instance { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddSupplier(PriorityMusicSupplier supplier)
	{
	}

	public void RemoveSupplier(PriorityMusicSupplier supplier)
	{
	}

	private void SortSuppliers()
	{
	}

	private void EvaluateTopSupplier()
	{
	}

	public void PlayNextSong()
	{
	}

	public void SetDirty()
	{
	}

	[IteratorStateMachine(typeof(_003CPlayNextTrack_003Ed__23))]
	private IEnumerator PlayNextTrack()
	{
		return null;
	}

	public Tween DOFadeRelease(EventInstance eventInstance)
	{
		return null;
	}

	public void OnSongEnd()
	{
	}

	public void SetVolumeModifier(string id, float volume)
	{
	}
}
