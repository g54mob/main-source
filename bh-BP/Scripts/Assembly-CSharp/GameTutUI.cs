using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using UnityEngine;

public class GameTutUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_MoveToSide_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTutUI _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchors_003E5__3;

		private Vector2 _003CstartPivot_003E5__4;

		private Vector2 _003CstartAnchoredPos_003E5__5;

		private Vector2 _003CstartTxtAnchoredPos_003E5__6;

		private Vector2 _003CstartXfmSize_003E5__7;

		private Vector2 _003CtgtAnchors_003E5__8;

		private Vector2 _003CtgtPivot_003E5__9;

		private Vector2 _003CtgtAnchoredPos_003E5__10;

		private Vector2 _003CtgtTxtAnchoredPos_003E5__11;

		private Vector2 _003CtgtXfmSize_003E5__12;

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
		public _003C_MoveToSide_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003C_UpdateLeftStick_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTutUI _003C_003E4__this;

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
		public _003C_UpdateLeftStick_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003C_UpdateRightStick_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTutUI _003C_003E4__this;

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
		public _003C_UpdateRightStick_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndResize_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTutUI _003C_003E4__this;

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
		public _003C_WaitAndResize_003Ed__21(int _003C_003E1__state)
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

	public static GameTutUI I;

	public static readonly string[] kTutStrController;

	public static readonly string[] kTutStrKeyboard;

	public static readonly string[] kTutStrMobile;

	public TextSizeRectFitter TxtFitter;

	public Localize Loc;

	public LocalizationParamsManager ParamsLoc;

	private string _curKbTerm;

	private string _curControllerTerm;

	private string _curTouchTerm;

	public bool IsBtnPressed;

	public CoolButton BtnClose;

	private CoroutineHandle _curStickAnim;

	private static string[] kLeftStickSeq;

	private static string[] kRightStickSeq;

	private void Awake()
	{
	}

	private void InitInternal()
	{
	}

	public void Activate(GameTutType t)
	{
	}

	public void ActivateOnSide(GameTutType t)
	{
	}

	public void ActivateBase(string kbTxt, string controllerTxt)
	{
	}

	public override void Deactivate()
	{
	}

	public string GetLocTerm(GameTutType t)
	{
		return null;
	}

	public void RefreshText()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndResize_003Ed__21))]
	private IEnumerator<float> _WaitAndResize()
	{
		return null;
	}

	public void OnCloseClicked()
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToSide_003Ed__23))]
	private IEnumerator<float> _MoveToSide()
	{
		return null;
	}

	public bool ShouldBlockInput()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_UpdateLeftStick_003Ed__26))]
	private IEnumerator<float> _UpdateLeftStick()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_UpdateRightStick_003Ed__28))]
	private IEnumerator<float> _UpdateRightStick()
	{
		return null;
	}
}
