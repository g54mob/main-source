using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class BreadOven : CraftingProp
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass9_0
		{
			public BreadOven _003C_003E4__this;

			public CraftRecipe_Job job;

			internal void _003CGetPreparationActivities_003Eb__0(string x)
			{
			}

			internal bool _003CGetPreparationActivities_003Eb__1(CraftProcess x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetPostCraftingActivities_003Ed__10 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private CraftRecipe_Job job;

			public CraftRecipe_Job _003C_003E3__job;

			public BreadOven _003C_003E4__this;

			private GameItem _003Citem_003E5__2;

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
			public _003CGetPostCraftingActivities_003Ed__10(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CGetPreparationActivities_003Ed__9 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public BreadOven _003C_003E4__this;

			private CraftRecipe_Job job;

			public CraftRecipe_Job _003C_003E3__job;

			private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

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

		private static string _breadDough;

		private static string _rationDough;

		private static string _fancyCakeDough;

		private static string _fancyLavaDough;

		private static string[] _allDough;

		private static string _preparationActivities;

		private static string _postCraftingActivities;

		public override void Start()
		{
		}

		private void AmountsChanged(object sender, EventArgs e)
		{
		}

		[IteratorStateMachine(typeof(_003CGetPreparationActivities_003Ed__9))]
		public override IEnumerable<Activity> GetPreparationActivities(CraftRecipe_Job job)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetPostCraftingActivities_003Ed__10))]
		public override IEnumerable<Activity> GetPostCraftingActivities(CraftRecipe_Job job)
		{
			return null;
		}
	}
}
