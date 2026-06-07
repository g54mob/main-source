using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class PlayLoopingAnimationJob : Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__5 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PlayLoopingAnimationJob _003C_003E4__this;

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
		private string _usageKey;

		[PersistenceOptIn]
		private float _duration;

		private PlayLoopingAnimationJob()
		{
		}

		public PlayLoopingAnimationJob(GameObjectX source, GameObjectX target, string usageKey, float duration)
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

		protected override void OnCleanupInternal()
		{
		}
	}
}
