using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_PlayClip_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ImageAnimator _003C_003E4__this;

		public SpriteAnimClip clip;

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
		public _003C_PlayClip_003Ed__11(int _003C_003E1__state)
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

	public Image Img;

	public SpriteAnimClip CurClip;

	public int CurFrame;

	private float _lastFrameChangeTime;

	public bool PlayOnAwake;

	private CoroutineHandle _curAnim;

	public DelegateUtl.NoArgsEvent OnFrameChanged;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void PlayClip(SpriteAnimClip clip, bool force = false)
	{
	}

	public void SnapToEndOfClip(SpriteAnimClip clip)
	{
	}

	[IteratorStateMachine(typeof(_003C_PlayClip_003Ed__11))]
	private IEnumerator<float> _PlayClip(SpriteAnimClip clip)
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
}
