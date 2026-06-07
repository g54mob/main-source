using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class SlidingPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public SlidingPanel _003C_003E4__this;

		public float len;

		public CardinalDir dir;

		public float slideAmt;

		private float _003CstartTime_003E5__2;

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
		public _003C_AnimateEntry_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003C_AnimateExit_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public SlidingPanel _003C_003E4__this;

		public float len;

		public CardinalDir dir;

		public float slideAmt;

		private float _003CstartTime_003E5__2;

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
		public _003C_AnimateExit_003Ed__18(int _003C_003E1__state)
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

	public ShakableRect Shaker;

	public CanvasGroup CvsGrp;

	[NonSerialized]
	public RectTransform Xfm;

	private Vector2 _defaultAnchorMin;

	private Vector2 _defaultAnchorMax;

	private bool _isAnimating;

	private CoroutineHandle _curAnim;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	private void Reset()
	{
	}

	public void ChangeAnchors(Vector2 anchorMin, Vector2 anchorMax)
	{
	}

	public void ResetPanel()
	{
	}

	public void SetEntryPct(CardinalDir dir, float pct, float slideAmt = 1f)
	{
	}

	public void SetEntryPct(Vector2 dir, float pct, float slideAmt = 1f)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__14))]
	public IEnumerator<float> _AnimateEntry(CardinalDir dir, float len = 0.2f, float slideAmt = 1f)
	{
		return null;
	}

	public void AnimateEntry(CardinalDir dir, float len = 0.2f, float slideAmt = 1f)
	{
	}

	public void SetExitPct(CardinalDir dir, float pct, float slideAmt = 1f)
	{
	}

	public void SetExitPct(Vector2 dir, float pct, float slideAmt = 1f)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateExit_003Ed__18))]
	public IEnumerator<float> _AnimateExit(CardinalDir dir, float len = 0.2f, float slideAmt = 1f)
	{
		return null;
	}

	public void AnimateExit(CardinalDir dir, float len = 0.2f, float slideAmt = 1f)
	{
	}

	public bool IsAnimating()
	{
		return false;
	}

	public Vector2 GetDefaultAnchorMin()
	{
		return default(Vector2);
	}

	public Vector2 GetDefaultAnchorMax()
	{
		return default(Vector2);
	}
}
