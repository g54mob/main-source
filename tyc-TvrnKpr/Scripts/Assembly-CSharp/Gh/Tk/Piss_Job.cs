using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Piss_Job : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass3_0
		{
			public Toilet toilet;

			public ToiletStat toiletStat;

			public Piss_Job _003C_003E4__this;

			internal void _003CGetActivities_003Eb__0()
			{
			}

			internal bool _003CGetActivities_003Eb__2(Wash_Basin x)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__3 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Piss_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

			private IDisposable _003C_003E7__wrap1;

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
			public _003CGetActivities_003Ed__3(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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

		[PersistenceOptIn]
		private GameObjectXMatchInfo _targetWashBasin;

		public const string WashAfterToiletUsage = "washAfterToilet";

		private Piss_Job()
		{
		}

		public Piss_Job(GameObjectX source, Toilet target, ActorBehaviour behaviour = null, string usageKeyOverride = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__3))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
