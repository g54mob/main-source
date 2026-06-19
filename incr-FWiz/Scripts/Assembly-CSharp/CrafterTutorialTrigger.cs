using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class CrafterTutorialTrigger : StoryTrigger
{
	[CompilerGenerated]
	private sealed class _003CTriggerTutorial_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CrafterTutorialTrigger _003C_003E4__this;

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
		public _003CTriggerTutorial_003Ed__6(int _003C_003E1__state)
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

	public BuildingAsset TargetAsset;

	public float BufferStartTime;

	public override void StartListening()
	{
	}

	public override void StopListening()
	{
	}

	public void OnBuildingPlaced(Building building)
	{
	}

	[IteratorStateMachine(typeof(_003CTriggerTutorial_003Ed__6))]
	public IEnumerator TriggerTutorial()
	{
		return null;
	}
}
