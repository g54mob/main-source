using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class ShopCounterPatronJob : PatronJob, ICoordinatedJob<ShopCounterJobStages>
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__12 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ShopCounterPatronJob _003C_003E4__this;

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
			public _003CGetActivities_003Ed__12(int _003C_003E1__state)
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
		private readonly int _price;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private ShopCounterStaffJob _staffJob;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private ShopItem _item;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _itemToPickup;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public ShopItem PickupItem { get; set; }

		protected ShopBehaviour ShopBehaviour => null;

		[PersistenceOptIn]
		public ShopCounterJobStages CurrentStage { get; private set; }

		public ICoordinatedJob<ShopCounterJobStages> OtherJob => null;

		protected ShopCounterPatronJob()
		{
		}

		public ShopCounterPatronJob(Patron owner, ShopBehaviour behaviour, int price)
		{
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__12))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public void SetStage(ShopCounterJobStages stage)
		{
		}

		public void SetItemToPickup(GameItem item)
		{
		}
	}
}
