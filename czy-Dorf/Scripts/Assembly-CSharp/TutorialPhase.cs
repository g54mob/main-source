using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TutorialPhase : MonoBehaviour
{
	private sealed class _003CNextPhaseAfterDelay_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialPhase _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CNextPhaseAfterDelay_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TutorialPhase tutorialPhase = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(tutorialPhase.endDelay);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				tutorialPhase.tutorialManager.NextPhase();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private TutorialManager tutorialManager;

	protected TutorialEvent[] events;

	protected TutorialWatcher watcher;

	[SerializeField]
	private InteractionRestriction interactionRestriction;

	[SerializeField]
	private float endDelay = 0.5f;

	public virtual void Begin()
	{
		tutorialManager.SetInteractionRestriction(interactionRestriction);
		if ((bool)watcher)
		{
			watcher.OnConditionFulfilled += Finish;
			watcher.StartWatching();
		}
		TutorialEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Begin();
		}
	}

	protected virtual void Finish()
	{
		Finish(true);
	}

	public void Finish(bool startNextPhase = true)
	{
		if ((bool)watcher)
		{
			watcher.OnConditionFulfilled -= Finish;
		}
		TutorialEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Finish();
		}
		if (startNextPhase)
		{
			StartCoroutine(NextPhaseAfterDelay());
		}
	}

	private IEnumerator NextPhaseAfterDelay()
	{
		return new _003CNextPhaseAfterDelay_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	public void Setup(TutorialManager tutorialManager)
	{
		this.tutorialManager = tutorialManager;
		events = GetComponentsInChildren<TutorialEvent>();
		watcher = GetComponentInChildren<TutorialWatcher>();
		TutorialEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Setup(tutorialManager, this);
		}
		if ((bool)watcher)
		{
			watcher.Setup(tutorialManager, this);
		}
	}

	public void Skip()
	{
		TutorialEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Skip();
		}
	}

	private void OnDestroy()
	{
		if ((bool)watcher)
		{
			watcher.OnConditionFulfilled -= Finish;
		}
	}
}
