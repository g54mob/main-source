using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class CraftRecipe_Job : CraftIngredient_Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__18 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CraftRecipe_Job _003C_003E4__this;

			private IEnumerator<RecipeInput> _003C_003E7__wrap1;

			private CraftProcess _003CcraftProcess_003E5__3;

			private IEnumerator<Activity> _003Cenumerator_003E5__4;

			private ListPoolX.DisposablePooledList<GameItem> _003Cinventory_003E5__5;

			private IEnumerator<GameItem> _003C_003E7__wrap5;

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

			private void _003C_003Em__Finally3()
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
		private bool _ranOutOfIngredients;

		[PersistenceOptIn]
		private bool _startedAnimation;

		[PersistenceOptIn]
		private bool _propUsed;

		[PersistenceOptIn]
		private bool _needsPickup;

		[PersistenceOptIn]
		private bool _finished;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Maintainable _maintainable;

		private Recipe _recipe;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		protected FoodOrder _foodOrder;

		public Recipe Recipe => null;

		protected CraftRecipe_Job()
		{
		}

		public CraftRecipe_Job(GameObjectX source, IngredientTemplate template, GameObjectX preferredTarget = null)
		{
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		public IEnumerable<GameObjectX> GetPossibleTargets()
		{
			return null;
		}

		public bool IsEndProduct()
		{
			return false;
		}

		public override void Start()
		{
		}

		private void OwnerOnSpawnedItemAdded(object sender, EventArgs<GameObjectX.SpawnedItem> e)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__18))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void LogCraftingToTavernLog()
		{
		}

		public override bool IsCheckingInputsEnabled()
		{
			return false;
		}

		public void SpawnOutput(string bone, GameObjectX parent = null)
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
