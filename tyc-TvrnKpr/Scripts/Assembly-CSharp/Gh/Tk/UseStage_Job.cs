using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class UseStage_Job : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public Entertainer entertainer;

			public UseStage_Job _003C_003E4__this;

			internal void _003CGetActivities_003Eb__0()
			{
			}

			internal void _003CGetActivities_003Eb__1()
			{
			}

			internal void _003CGetActivities_003Eb__2()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UseStage_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

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
			public _003CGetActivities_003Ed__6(int _003C_003E1__state)
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
		private string _useAnimation;

		[PersistenceOptIn]
		private string _currentAnimation;

		[PersistenceOptIn]
		private List<string> _usedAnimations;

		[PersistenceOptIn]
		private bool _onStage;

		private UseStage_Job()
		{
		}

		public UseStage_Job(GameObjectX source, Prop target, ActorBehaviour behaviour = null, string usageKeyOverride = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		private void ResetBardQualityState()
		{
		}

		private void PickAnimation()
		{
		}
	}
}
