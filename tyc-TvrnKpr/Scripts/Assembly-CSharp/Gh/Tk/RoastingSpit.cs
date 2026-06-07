using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class RoastingSpit : CraftingProp
	{
		[CompilerGenerated]
		private sealed class _003CGetPreparationActivities_003Ed__0 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private CraftRecipe_Job job;

			public CraftRecipe_Job _003C_003E3__job;

			public RoastingSpit _003C_003E4__this;

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
			public _003CGetPreparationActivities_003Ed__0(int _003C_003E1__state)
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
		private bool _cleanUpNeeded;

		public const string UsageKeyReturnSpike = "returnspike";

		[IteratorStateMachine(typeof(_003CGetPreparationActivities_003Ed__0))]
		public override IEnumerable<Activity> GetPreparationActivities(CraftRecipe_Job job)
		{
			return null;
		}

		public override int GetPositionFor(GameItemTemplate template, int amount, bool ignoreOverride = true)
		{
			return 0;
		}

		public override void Start()
		{
		}

		public override bool IsReadyToUse(bool ignoreWhenBroken = false)
		{
			return false;
		}

		public override void EndUse(string usageKey, Actor actor)
		{
		}

		private void OnItemRemoved(object sender, GameItemEventArgs e)
		{
		}
	}
}
