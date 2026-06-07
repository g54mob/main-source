using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class PatronOrder_Job : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__15 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PatronOrder_Job _003C_003E4__this;

			private IDisposable _003C_003E7__wrap1;

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
		private Plate _plate;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Ingredient _mainItem;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Ingredient _sideItem;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _waitAnimation;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _checkedForFire;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasOnFire;

		[PersistenceOptIn]
		public bool ReadyToOrder { get; set; }

		private PatronOrder_Job()
		{
		}

		public PatronOrder_Job(GameObjectX source, GameObjectX target, ActorBehaviour behaviour, string usageKeyOverride = null)
		{
		}

		public void SetPlate(Plate plate)
		{
		}

		public void SetMainItem(Ingredient item)
		{
		}

		public override bool IsPaused()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__15))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void SetActualPriceToOrderedItems()
		{
		}

		public Activity HandOverToGetOrderJob()
		{
			return null;
		}

		private void CleanUp()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		private void DestroyConsumables()
		{
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
