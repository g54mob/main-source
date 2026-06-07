using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class UseProp_Job : Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__11 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UseProp_Job _003C_003E4__this;

			private Prop _003Cprop_003E5__2;

			private Patron _003Cpatron_003E5__3;

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
		public string UsageKey;

		[PersistenceOptIn]
		private float _duration;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _gameItem;

		[PersistenceOptIn]
		private bool _idleIfEventGiver;

		[PersistenceOptIn]
		private bool _startedIdling;

		[PersistenceOptIn]
		internal bool _canAbort;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _propOnFireAnim;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public ActorBehaviour Behaviour;

		protected UseProp_Job()
		{
		}

		public UseProp_Job(GameObjectX source, Prop target, ActorBehaviour behaviour, GameItem item, int priority, float duration = -1f, bool idleIfEventGiver = false, string usageKeyOverride = null)
		{
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

		public void MarkBehaviourAsDone()
		{
		}
	}
}
