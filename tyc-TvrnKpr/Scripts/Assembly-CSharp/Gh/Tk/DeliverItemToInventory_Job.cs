using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class DeliverItemToInventory_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public DeliverItemToInventory_Job _003C_003E4__this;

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
		[PersistenceObjectReference]
		private GameItemTemplate _itemTemplate;

		[PersistenceOptIn]
		private int _amount;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isForCraftProcess;

		[PersistenceOptIn]
		private bool _restrictToContainer;

		[PersistenceOptIn]
		private int _minAmount;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _currentItem;

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		protected override bool CheckIsValidInternal()
		{
			return false;
		}

		private DeliverItemToInventory_Job()
		{
		}

		public DeliverItemToInventory_Job(GameObjectX source, GameObjectX target, GameItemTemplate itemTemplate, int amount, bool isForCraftProcess = false, bool restrictToContainer = false, int minAmount = 1)
		{
		}

		protected override bool EnableValidityCheck()
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
