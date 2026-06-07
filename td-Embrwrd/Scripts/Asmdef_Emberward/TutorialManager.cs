using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public class EventToTutorialDic : SerializableDictionary<eGameEvents, eTutorialType>
	{
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public bool isFinished;

		internal void _003CCR_PlayQueuedTutorial_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlayQueuedTutorial_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialManager _003C_003E4__this;

		public Action finishCallback;

		private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

		private List<eTutorialType>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_PlayQueuedTutorial_003Ed__9(int _003C_003E1__state)
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
	private sealed class _003CCR_TutorialProc_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public Action finishCallback;

		public eTutorialType tutorialType;

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
		public _003CCR_TutorialProc_003Ed__12(int _003C_003E1__state)
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

	[SerializeField]
	private List<eTutorialType> list_QueuedTutorialForGameStart;

	[SerializeField]
	private EventToTutorialDic dic_EventToTutorial;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnQueueTutorialForEvent(eGameEvents eventType, eTutorialType tutorialType)
	{
	}

	private void OnRequestTutorial(eTutorialType tutorialType, float delay, Action finishCallback)
	{
	}

	private void OnRequestStartQueuedTutorial(Action finishCallback)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlayQueuedTutorial_003Ed__9))]
	private IEnumerator CR_PlayQueuedTutorial(Action finishCallback)
	{
		return null;
	}

	private void OnQueueTutorialForGameStart(eTutorialType type)
	{
	}

	private Coroutine PlayTutorial(eTutorialType tutorialType, float delay, Action finishCallback)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_TutorialProc_003Ed__12))]
	private IEnumerator CR_TutorialProc(eTutorialType tutorialType, float delay, Action finishCallback)
	{
		return null;
	}
}
