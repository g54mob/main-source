using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class FullfillOrder_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__18 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FullfillOrder_Job _003C_003E4__this;

			private Patron _003Cpatron_003E5__2;

			private ActivityFindObject<GameObjectXMatchInfo> _003CfindWindow_003E5__3;

			private IDisposable _003C_003E7__wrap3;

			private IEnumerator<Activity> _003C_003E7__wrap4;

			private FoodWindow _003CfoodOrderWindow_003E5__6;

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
			public _003CGetActivities_003Ed__18(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CHandlePlacingTicket_003Ed__20 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FullfillOrder_Job _003C_003E4__this;

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
			public _003CHandlePlacingTicket_003Ed__20(int _003C_003E1__state)
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
		public FoodOrder _foodOrder;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private IngredientTemplate _mainItemOrdered;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private IngredientTemplate _sideItemOrdered;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _itemToPickUp;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _itemToSetDown;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _idleTransitionInProgress;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _ticketPlaced;

		[PersistenceOptIn]
		private int? _placeTicketPosition;

		[PersistenceOptIn]
		private string _idlePlaceTicketAnimation;

		public bool HasDeliveredOrderToFoodWindow => false;

		public FoodOrder FoodOrder => null;

		private FullfillOrder_Job()
		{
		}

		public FullfillOrder_Job(GameObjectX source, IngredientTemplate mainItemOrdered, IngredientTemplate sideItemOrdered = null)
		{
		}

		public bool IsFoodOrder()
		{
			return false;
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__18))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private Activity ServingSetDownActivity(Ingredient mainItem)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHandlePlacingTicket_003Ed__20))]
		private IEnumerable<Activity> HandlePlacingTicket()
		{
			return null;
		}

		private ActivityFindObject<GameObjectXMatchInfo> CreateFindWindowActivity(IngredientTemplate mainItem)
		{
			return null;
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected override void OnErrorInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		private void SetIdleBoolToFalse()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void CleanUpInternal()
		{
		}
	}
}
