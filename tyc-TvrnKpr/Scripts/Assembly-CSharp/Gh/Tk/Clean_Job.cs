using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Clean_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public Clean_Job _003C_003E4__this;

			public Prop prop;

			public DirtBase dirt;

			internal bool _003CGetActivities_003Eb__0()
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__1()
			{
			}

			internal void _003CGetActivities_003Eb__2()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__14 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Clean_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

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
			public _003CGetActivities_003Ed__14(int _003C_003E1__state)
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
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _duration;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _decreaseFilthValuePerSecond;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _anim;

		[PersistenceOptIn]
		private bool _isPropOrDirt;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _cleanStartReceived;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _attachedToListener;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _durationLeft;

		private int _priorityModifier;

		public override int Priority
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private Clean_Job()
		{
		}

		private void TimeControllerOnHourChanged(object sender, EventArgs e)
		{
		}

		public Clean_Job(GameObjectX source, GameObjectX target, int priority = -110)
		{
		}

		public override bool IsValid()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__14))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void RemoveListener()
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void FinishedCleaning()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		private void UpdatePriority()
		{
		}
	}
}
