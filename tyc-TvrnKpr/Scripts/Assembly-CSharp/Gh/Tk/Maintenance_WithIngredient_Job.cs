using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Maintenance_WithIngredient_Job : Maintenance_Job, INeedsIngredients_Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Maintenance_WithIngredient_Job _003C_003E4__this;

			private Prop _003Cobject2Maintain_003E5__2;

			private IEnumerable<string> _003Canims_003E5__3;

			private int _003CcurrentAmount_003E5__4;

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
		private string _maintainUsage;

		[PersistenceOptIn]
		private int _amount;

		[PersistenceOptIn]
		private List<string> _issues;

		[PersistenceOptIn]
		private bool _ingredientSupplied;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public IngredientTemplate ItemTemplate { get; private set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Prop Target
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		private Maintenance_WithIngredient_Job()
		{
		}

		public Maintenance_WithIngredient_Job(GameObjectX source, Prop target, IngredientTemplate itemTemplate, int amount = 10)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__11))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		public bool IsCheckingInputsEnabled()
		{
			return false;
		}

		public IEnumerable<Tuple<GameItemTemplate, int>> GetNeededItemAmounts()
		{
			return null;
		}

		public virtual IEnumerable<string> GetIssues()
		{
			return null;
		}

		private string GetTextKeyForInputIssue(string inputName)
		{
			return null;
		}

		public void AddInputIssue(string inputNameKey)
		{
		}

		public void RemoveInputIssue(string inputNameKey)
		{
		}

		public void ClearInputIssues()
		{
		}
	}
}
