using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class TempleGatesTutorialTrigger : StoryTrigger
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public bool finishedStory;

		internal void _003CDoTutorial_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDoTutorial_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TempleGatesTutorialTrigger _003C_003E4__this;

		private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

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
		public _003CDoTutorial_003Ed__7(int _003C_003E1__state)
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

	public ItemType TargetItem;

	public float BufferStartTime;

	public override void StartListening()
	{
	}

	public override void StopListening()
	{
	}

	public void OnItemUnlocked()
	{
	}

	public void StartTutorial()
	{
	}

	[IteratorStateMachine(typeof(_003CDoTutorial_003Ed__7))]
	public IEnumerator DoTutorial()
	{
		return null;
	}
}
