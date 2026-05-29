using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LinesSequence : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlaySequence_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LinesSequence _003C_003E4__this;

		private List<GameObject>.Enumerator _003C_003E7__wrap1;

		private CanvasGroup _003Ccg_003E5__3;

		private float _003Ct_003E5__4;

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
		public _003CPlaySequence_003Ed__16(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitForSkip_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LinesSequence _003C_003E4__this;

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
		public _003CWaitForSkip_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CWaitingForSave_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LinesSequence _003C_003E4__this;

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
		public _003CWaitingForSave_003Ed__19(int _003C_003E1__state)
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

	public EndOfDayManager endOfDayManager;

	[SerializeField]
	private List<GameObject> lines;

	[SerializeField]
	private float delayBetween;

	[SerializeField]
	private float fadeDuration;

	public Coroutine playCoroutine;

	public Coroutine skipCoroutine;

	public Coroutine saveCoroutine;

	public Coroutine moveBoxCoroutine;

	private bool skipped;

	public GameObject enterText;

	public GameObject buttonView;

	public MoveBox moveBox;

	public TextMeshProUGUI saveText;

	private bool canSkipped;

	public UnityEvent actionAfterStopAnim;

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CPlaySequence_003Ed__16))]
	private IEnumerator PlaySequence()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWaitForSkip_003Ed__17))]
	private IEnumerator WaitForSkip()
	{
		return null;
	}

	public void GoSaveTheGame()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitingForSave_003Ed__19))]
	private IEnumerator WaitingForSave()
	{
		return null;
	}

	public void ShowMenu()
	{
	}
}
