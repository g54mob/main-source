using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class RefillFireExtinguisher_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass8_0
		{
			public RefillFireExtinguisher_Job _003C_003E4__this;

			public FireExtinguisher fireExtinguisherGox;

			public Func<Inventory, bool> _003C_003E9__9;

			public Func<RefillFireExtinguisher_Job, bool> _003C_003E9__12;

			internal bool _003CGetActivities_003Eb__1(GameItemTemplate x)
			{
				return false;
			}

			internal IEnumerable<GameItem> _003CGetActivities_003Eb__7(GameItemTemplate x)
			{
				return null;
			}

			internal bool _003CGetActivities_003Eb__9(Inventory y)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__2()
			{
			}

			internal bool _003CGetActivities_003Eb__3(GameItem x)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__4()
			{
			}

			internal bool _003CGetActivities_003Eb__12(RefillFireExtinguisher_Job x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__8 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public RefillFireExtinguisher_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

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
		public FireExtinguisherGameItem FireExtinguisher;

		private string _itemType;

		[PersistenceOptIn]
		private GameItem _gameItem;

		private RefillFireExtinguisher_Job()
		{
		}

		public RefillFireExtinguisher_Job(FireExtinguisher source, int priority = 100)
		{
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		protected override bool EnableValidityCheck()
		{
			return false;
		}

		protected override bool CheckIsValidInternal()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__8))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
