using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class ProcessGameItem_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public ProcessGameItem_Job _003C_003E4__this;

			public GameItemProcess process;

			public Func<GameItem, bool> _003C_003E9__1;

			internal bool _003CGetActivities_003Eb__0(GameItemProcess x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__1(GameItem x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ProcessGameItem_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

			Activity IEnumerator<Activity>.Current
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
			public _003CGetActivities_003Ed__6(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<Activity> IEnumerable<Activity>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		public int Amount;

		[PersistenceOptIn]
		private string _processVerb;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _processingStarted;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _deliveringStarted;

		protected ProcessGameItem_Job()
		{
		}

		public ProcessGameItem_Job(GameObjectX source, GameObjectX target, GameItemProcess process, int amount)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
