using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class ForceDialogueQuestPart : QuestPart
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public bool complete;

		internal void _003CStoryEnumerator_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CStoryEnumerator_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ForceDialogueQuestPart _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

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
		public _003CStoryEnumerator_003Ed__4(int _003C_003E1__state)
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

	public DialogueStory Story;

	public bool Cinematic;

	public Checkpoint SkipWithCheckpoint;

	public override void ActivateQuestPart()
	{
	}

	[IteratorStateMachine(typeof(_003CStoryEnumerator_003Ed__4))]
	public IEnumerator StoryEnumerator()
	{
		return null;
	}
}
