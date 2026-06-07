using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_PlayClip_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public SpriteAnimator _003C_003E4__this;

		public SpriteAnimClip clip;

		public bool matchFrame;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_PlayClip_003Ed__15(int _003C_003E1__state)
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

	public SpriteRenderer Rend;

	public SpriteAnimClip CurClip;

	public int CurFrame;

	private float _lastFrameChangeTime;

	public bool PlayOnAwake;

	public int PlayDir;

	public float AnimSpeed;

	public bool IgnoreActiveState;

	public bool UseUnscaledTime;

	private CoroutineHandle _curAnim;

	public DelegateUtl.NoArgsEvent OnFrameChanged;

	private void OnEnable()
	{
	}

	public void PlayClip(SpriteAnimClip clip, bool force = false, bool matchFrame = false)
	{
	}

	public void SnapToEndOfClip(SpriteAnimClip clip)
	{
	}

	private float GetTime()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_PlayClip_003Ed__15))]
	private IEnumerator<float> _PlayClip(SpriteAnimClip clip, bool matchFrame)
	{
		return null;
	}

	public void Stop()
	{
	}

	public bool IsAtEndOfClip()
	{
		return false;
	}

	public void SetSorting(int sortLayer, int sortOrder)
	{
	}

	private void OnValidate()
	{
	}
}
