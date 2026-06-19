using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class BuildTutorialTriggerer : StoryTrigger
{
	[CompilerGenerated]
	private sealed class _003CDoTutorial_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BuildTutorialTriggerer _003C_003E4__this;

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
		public _003CDoTutorial_003Ed__11(int _003C_003E1__state)
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

	public DialogueStory _tutorialStory;

	public int _selectWellLineIndex;

	public int _placeWellLineIndex;

	public int _endLineIndex;

	private int _questPhase;

	public UnlockShop Shop;

	public UpgradeDef UpgradeStartingQuest;

	public override void StartListening()
	{
	}

	public override void StopListening()
	{
	}

	public void StartQuest(int _)
	{
	}

	public void StartQuest()
	{
	}

	[IteratorStateMachine(typeof(_003CDoTutorial_003Ed__11))]
	public IEnumerator DoTutorial()
	{
		return null;
	}

	public void TryUpdateQuestPhase(int phase)
	{
	}
}
