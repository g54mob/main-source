using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class PipelineTutorialTrigger : StoryTrigger
{
	[CompilerGenerated]
	private sealed class _003CTriggerTutorial_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PipelineTutorialTrigger _003C_003E4__this;

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
		public _003CTriggerTutorial_003Ed__7(int _003C_003E1__state)
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

	public DialogueStory TutorialStory;

	public float BufferStartTime;

	public int IntroLineIndex;

	public int ManualLineIndex;

	public override void StartListening()
	{
	}

	public override void StopListening()
	{
	}

	public void OnCreateConnectablePipe()
	{
	}

	[IteratorStateMachine(typeof(_003CTriggerTutorial_003Ed__7))]
	public IEnumerator TriggerTutorial()
	{
		return null;
	}
}
