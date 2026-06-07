using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using MEC;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OverlayUI : CoolSelectable
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public OverlayUI _003C_003E4__this;

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
		public _003C_AnimateEntry_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003C_AnimateExit_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public OverlayUI _003C_003E4__this;

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
		public _003C_AnimateExit_003Ed__30(int _003C_003E1__state)
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

	public static List<OverlayUI> sOverlayStack;

	[Header("Refs")]
	public Image ShadowUnderlay;

	public CoolButton BtnUnderlay;

	public SlidingPanel Panel;

	public CanvasGroup CvsGrp;

	[Header("Props")]
	public CardinalDir EntryDir;

	public CardinalDir ExitDir;

	public float AnimLen;

	protected const float kDefaultUnderlayAlpha = 0.6f;

	protected const float kDefaultOverlayAlpha = 1f;

	protected Color _underlayColor;

	protected bool _isInitialized;

	protected CoroutineHandle _curAnim;

	protected bool _isAnimating;

	public EventReference SFXOnEnter;

	[Header("Selection")]
	public CoolSelectable DefaultFocus;

	[NonSerialized]
	public CoolSelectable SelectOnDeactivate;

	private CoroutineHandle _updateAnim;

	public bool IsStackable;

	protected virtual void Init()
	{
	}

	[RuntimeInitializeOnLoadMethod]
	public static void InitializeOnLoad()
	{
	}

	public virtual void Activate()
	{
	}

	public virtual void Deactivate()
	{
	}

	public virtual void OnUnderlayClicked()
	{
	}

	protected virtual float GetEntryPct(float pct)
	{
		return 0f;
	}

	protected void SetUnderlayAlpha(float a)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__26))]
	protected virtual IEnumerator<float> _AnimateEntry()
	{
		return null;
	}

	protected virtual void OnEntryPct(float pct)
	{
	}

	protected virtual void OnEntryComplete()
	{
	}

	protected virtual float GetExitPct(float pct)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_AnimateExit_003Ed__30))]
	protected virtual IEnumerator<float> _AnimateExit()
	{
		return null;
	}

	public virtual void OnExitPct(float pct)
	{
	}

	public virtual void OnExitComplete()
	{
	}

	public virtual bool IsAnimating()
	{
		return false;
	}

	public virtual void Shake(float amt, float len)
	{
	}

	public override void Select(MoveDirection entryDir = MoveDirection.None)
	{
	}

	public override void OnChildMove(AxisEventData evData, CoolSelectable child)
	{
	}

	public virtual bool OnBPressed()
	{
		return false;
	}

	protected virtual void MyUpdate()
	{
	}

	public bool IsActiveOverlay()
	{
		return false;
	}

	public float GetAnimLen()
	{
		return 0f;
	}
}
