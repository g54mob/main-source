using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class DieJob : Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public DieJob _003C_003E4__this;

			private Prop _003Cprop_003E5__2;

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
		private string _animationKey;

		[PersistenceOptIn]
		private bool _wasCausedByRandomEvent;

		private static float _maxDamageOnExplode;

		private static float _explosionRadius;

		public DieJob()
		{
		}

		public DieJob(GameObjectX source, GameObjectX target = null, string animationKey = null, int priority = 0)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
