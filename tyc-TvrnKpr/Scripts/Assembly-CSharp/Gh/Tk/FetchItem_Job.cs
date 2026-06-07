using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class FetchItem_Job : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__21 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FetchItem_Job _003C_003E4__this;

			private int _003CcurrentAmount_003E5__2;

			private IEnumerator<Activity> _003C_003E7__wrap2;

			private GameItem _003Citem_003E5__4;

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
			public _003CGetActivities_003Ed__21(int _003C_003E1__state)
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

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItemTemplate _template;

		[PersistenceOptIn]
		private int _amount;

		[PersistenceOptIn]
		private int _minAmount;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private ItemServiceSource _itemServiceSource;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Inventory _inventory;

		[PersistenceOptIn]
		private bool _pickup;

		[PersistenceOptIn]
		private int _pickupPosition;

		[PersistenceOptIn]
		private bool _restrictToContainer;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isForCraftProcess;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Patron TargetPatron { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX ItemFetched { get; set; }

		private FetchItem_Job()
		{
		}

		public FetchItem_Job(GameObjectX source, GameItemTemplate template, int amount, int? minAmount = null, bool restrictToContainer = false, bool isForCraftProcess = false)
		{
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		public override void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__21))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void OwnerOnSpawnedItemAdded(object sender, EventArgs<GameObjectX.SpawnedItem> e)
		{
		}

		private void PostPickup(GameItem item)
		{
		}

		private void ResetTargets()
		{
		}

		private void SetIsOrderOnTheWay(bool onTheWay)
		{
		}

		public void ResetItemToNotCrafting()
		{
		}

		protected override void OnErrorInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
