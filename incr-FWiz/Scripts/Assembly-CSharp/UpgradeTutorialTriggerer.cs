using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UpgradeTutorialTriggerer : StoryTrigger
{
	[CompilerGenerated]
	private sealed class _003CDoTutorial_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UpgradeTutorialTriggerer _003C_003E4__this;

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
		public _003CDoTutorial_003Ed__13(int _003C_003E1__state)
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

	public DialogueStory _upgradeTutorialStory;

	public int _findChoppingBlockLineIndex;

	public int _collectLumberLineIndex;

	public int _completeUpgradeLineIndex;

	public int _endLineIndex;

	private int _questPhase;

	public Transform ChoppingBlockPosition;

	public float ChoppingBlockActivateDistance;

	public int LumberRequired;

	public override void StartListening()
	{
	}

	public override void StopListening()
	{
	}

	public void StartQuest()
	{
	}

	public void StartQuest(UpgradeStation _, UpgradeAttempt __)
	{
	}

	[IteratorStateMachine(typeof(_003CDoTutorial_003Ed__13))]
	public IEnumerator DoTutorial()
	{
		return null;
	}
}
