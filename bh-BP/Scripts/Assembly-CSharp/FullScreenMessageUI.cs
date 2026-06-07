using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenMessageUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_RunLoading_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FullScreenMessageUI _003C_003E4__this;

		public float timeoutSecs;

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
		public _003C_RunLoading_003Ed__33(int _003C_003E1__state)
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

	public static FullScreenMessageUI I;

	public Image ImgVoidBackground;

	private float _bgTime;

	public FullScreenMessageType Type;

	public CoolButton BtnDemoWishlist;

	public Localize LocDemoWishlist;

	public CoolButton BtnDemoDiscord;

	public Localize LocDemoDiscord;

	public CoolButton BtnDemoContinue;

	public Localize LocDemoContinue;

	public Localize LocTitle;

	public Localize LocMessage;

	public CanvasGroup CvsGrpLoading;

	public RectTransform WrapperLoadingCircles;

	private CoroutineHandle _loadAnim;

	private bool _cancelLoading;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	public void ActivateOutOfTime()
	{
	}

	public void ActivateUnlockFullGame()
	{
	}

	public void ActivateUnlockFullGameInternal()
	{
	}

	public override void Deactivate()
	{
	}

	private void OnFullGameUnlocked()
	{
	}

	private void OnPurchaseFailed(int code)
	{
	}

	private void OnRestoreFailed()
	{
	}

	protected override void OnEntryPct(float pct)
	{
	}

	private void OnWishlistClicked()
	{
	}

	private void CheatUnlockFullGame()
	{
	}

	private void TryBuyFullGame()
	{
	}

	private void OnDiscordClicked()
	{
	}

	private void OnContinueClicked()
	{
	}

	private void RunLoading(float timeoutSecs = 10f)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLoading_003Ed__33))]
	private IEnumerator<float> _RunLoading(float timeoutSecs = 10f)
	{
		return null;
	}

	public void CancelLoading()
	{
	}
}
