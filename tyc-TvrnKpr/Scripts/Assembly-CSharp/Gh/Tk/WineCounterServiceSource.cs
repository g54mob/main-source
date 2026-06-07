using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class WineCounterServiceSource : ItemServiceSource
	{
		[CompilerGenerated]
		private sealed class _003CServe_003Ed__9 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private FetchItem_Job job;

			public FetchItem_Job _003C_003E3__job;

			public WineCounterServiceSource _003C_003E4__this;

			private GameItemTemplate template;

			public GameItemTemplate _003C_003E3__template;

			private Actor actor;

			public Actor _003C_003E3__actor;

			private Job _003CtempJob_003E5__2;

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
			public _003CServe_003Ed__9(int _003C_003E1__state)
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
		private int _servingsLeftInBottle;

		private FetchItem_Job _currentJob;

		private GameItemTemplate _currentTemplate;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX _currentBottle;

		private void OnInventoryChanged()
		{
		}

		protected override bool NeedsReplacing()
		{
			return false;
		}

		protected override Job CreateOrGetReplaceJob()
		{
			return null;
		}

		public override bool CanProvide(GameItemTemplate template, long amount, bool restrictToContainer)
		{
			return false;
		}

		public override float GetRating(GameItemTemplate template, int amount, bool includePlaceholderItems = false)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CServe_003Ed__9))]
		public override IEnumerable<Activity> Serve(FetchItem_Job job, GameItemTemplate template, Actor actor)
		{
			return null;
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void FetchItem(FetchItem_Job job, GameItemTemplate template)
		{
		}

		public override void Start()
		{
		}

		private void OnBeforeDemolishing(object sender, EventArgs e)
		{
		}

		public override void OnDestroy()
		{
		}

		private void RemoveBottle()
		{
		}

		private void OnIsDeadChanged(object sender, EventArgs<bool> e)
		{
		}
	}
}
