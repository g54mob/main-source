using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class ReactToEntertainer_Job : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__5 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ReactToEntertainer_Job _003C_003E4__this;

			private IEnumerable<string> _003Canims_003E5__2;

			private IDisposable _003C_003E7__wrap2;

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
			public _003CGetActivities_003Ed__5(int _003C_003E1__state)
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

		private int _reaction;

		private ReactToEntertainer_Job()
		{
		}

		public ReactToEntertainer_Job(GameObjectX source, Entertainer target)
		{
		}

		public override void Start()
		{
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__5))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
