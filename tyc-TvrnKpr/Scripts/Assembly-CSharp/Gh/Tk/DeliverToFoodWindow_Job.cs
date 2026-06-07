using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class DeliverToFoodWindow_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public DeliverToFoodWindow_Job _003C_003E4__this;

			public GameItem meal;

			internal bool _003CGetActivities_003Eb__0(GameItem x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__1(GameItem x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__2(GameItem x)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__3()
			{
			}

			internal void _003CGetActivities_003Eb__4()
			{
			}

			internal bool _003CGetActivities_003Eb__5(GameItem x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__6(GameItem x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__7(GameItem x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public DeliverToFoodWindow_Job _003C_003E4__this;

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

		[PersistenceObjectReference]
		[PersistenceOptIn]
		public FoodOrder _foodOrder;

		[PersistenceObjectReference]
		[PersistenceOptIn]
		private GameItem _createdPlate;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _sideDishFound;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Patron _patron;

		[PersistenceOptIn]
		private bool _handlingSideDish;

		private DeliverToFoodWindow_Job()
		{
		}

		public DeliverToFoodWindow_Job(GameObjectX source, FoodOrder foodOrder, Patron patron)
		{
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		protected override string GetHighLevelTaskDescriptionKeyInternal()
		{
			return null;
		}

		public override bool IsPaused()
		{
			return false;
		}

		public override bool ShouldDropInventoryOnStart()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__11))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnErrorInternal()
		{
		}

		public override void Start()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void OwnerOnSpawnedItemAdded(object sender, EventArgs<GameObjectX.SpawnedItem> e)
		{
		}

		public void ChangeSource(FoodWindow source)
		{
		}
	}
}
