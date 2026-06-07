using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StaffServiceBedJob : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public StaffServiceBedJob _003C_003E4__this;

			public Bed bed;

			internal void _003CGetActivities_003Eb__0()
			{
			}

			internal void _003CGetActivities_003Eb__3()
			{
			}

			internal void _003CGetActivities_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StaffServiceBedJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

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
			public _003CGetActivities_003Ed__11(int _003C_003E1__state)
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
		private bool _hadLinen;

		[PersistenceOptIn]
		private GameItem _droppedSheet;

		[PersistenceOptIn]
		private bool _needsLinenChange;

		[PersistenceOptIn]
		private bool _needsMakingBed;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItemTemplate _desiredLinenType;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _carryingItem;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _linenFound;

		private StaffServiceBedJob()
		{
		}

		public StaffServiceBedJob(Bed source)
		{
		}

		protected override bool EnableValidityCheck()
		{
			return false;
		}

		protected override bool CheckIsValidInternal()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__11))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}
	}
}
