using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndOfDayManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAutoEndDay_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EndOfDayManager _003C_003E4__this;

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
		public _003CAutoEndDay_003Ed__10(int _003C_003E1__state)
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
	private sealed class _003CCanvasGroupFadeAnimation_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public CanvasGroup canvasGroup;

		public float time;

		public TypeAnim animationType;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003Celapsed_003E5__3;

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
		public _003CCanvasGroupFadeAnimation_003Ed__17(int _003C_003E1__state)
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

	public static EndOfDayManager instance;

	[Header("Components")]
	public SaveManager saveManager;

	public EndingDay endingDay;

	[Header("View")]
	public GameObject summaryDayView;

	[Header("UI")]
	public CanvasGroup blackBackground;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private bool autoEndDay;

	public static bool isAutoDayEnd;

	public void Awake()
	{
	}

	public void StartEndDay()
	{
	}

	[IteratorStateMachine(typeof(_003CAutoEndDay_003Ed__10))]
	public IEnumerator AutoEndDay()
	{
		return null;
	}

	public void SummaryOfTheDay()
	{
	}

	public void SummarySaveDay()
	{
	}

	private void AddDay()
	{
	}

	public void ButtonContinue()
	{
	}

	public void StopGame()
	{
	}

	public void StartGame()
	{
	}

	[IteratorStateMachine(typeof(_003CCanvasGroupFadeAnimation_003Ed__17))]
	public IEnumerator CanvasGroupFadeAnimation(CanvasGroup canvasGroup, float targetAlpha, float time, float delay, TypeAnim animationType)
	{
		return null;
	}
}
