using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StaffGoToPoi_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass5_0
		{
			public List<Type> propTypes;

			public StaffGoToPoi_Job _003C_003E4__this;

			internal bool _003CGetActivities_003Eb__1(Prop x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__5 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StaffGoToPoi_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

			private IEnumerable<string> _003Canims_003E5__2;

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
			public _003CGetActivities_003Ed__5(int _003C_003E1__state)
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

		public static string IdleTaskDescriptionKey;

		[PersistenceOptIn]
		private int _thinkCount;

		private StaffGoToPoi_Job()
		{
		}

		public StaffGoToPoi_Job(GameObjectX source)
		{
		}

		private void CreateGotoRandomPositionWithinTavern()
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__5))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void CleanUp()
		{
		}
	}
}
