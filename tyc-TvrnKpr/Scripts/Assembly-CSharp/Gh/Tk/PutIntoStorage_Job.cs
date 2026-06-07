using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class PutIntoStorage_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__15 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PutIntoStorage_Job _003C_003E4__this;

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
			public _003CGetActivities_003Ed__15(int _003C_003E1__state)
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
		private int _setdownPosition;

		[PersistenceOptIn]
		private bool _setdown;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasAvailableToStoreItem;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameItem TargetItem { get; internal set; }

		protected PutIntoStorage_Job()
		{
		}

		public PutIntoStorage_Job(GameItem item, Larder_Tile targetLarder_Tile = null)
		{
		}

		public void ReplaceTargetItem(GameItem newItem)
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

		public IEnumerable<Larder_Tile> GetStorageTargets()
		{
			return null;
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__15))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void UnreserveSpot()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		public void SetTarget(GameObjectX target)
		{
		}
	}
}
