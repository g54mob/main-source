using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Replace_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__8 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Replace_Job _003C_003E4__this;

			private Replaceable _003Creplaceable_003E5__2;

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
			public _003CGetActivities_003Ed__8(int _003C_003E1__state)
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
		[PersistenceObjectReference]
		private GameItemTemplate _template;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX _oldItem;

		[PersistenceOptIn]
		private GameItem _gameItem;

		public GameItemTemplate ReplaceTemplate => null;

		private Replace_Job()
		{
		}

		public Replace_Job(GameObjectX source, GameObjectX target, GameItemTemplate template)
		{
		}

		protected override string GetHighLevelTaskDescriptionKeyInternal()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__8))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnErrorInternal()
		{
		}
	}
}
