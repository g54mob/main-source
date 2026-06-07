using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Well : CraftingProp
	{
		[CompilerGenerated]
		private sealed class _003CGetPreparationActivities_003Ed__9 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private CraftRecipe_Job job;

			public CraftRecipe_Job _003C_003E3__job;

			public Well _003C_003E4__this;

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
			public _003CGetPreparationActivities_003Ed__9(int _003C_003E1__state)
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

		private static string _preparationActivities;

		private static string _placeBucket;

		private static string _turnArmIn;

		private static string _crankIn;

		private static string _crank;

		private static string _turnArmOut;

		private static string _getBucket;

		public override void Start()
		{
		}

		public override string GetOutputTemplateId()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetPreparationActivities_003Ed__9))]
		public override IEnumerable<Activity> GetPreparationActivities(CraftRecipe_Job job)
		{
			return null;
		}
	}
}
