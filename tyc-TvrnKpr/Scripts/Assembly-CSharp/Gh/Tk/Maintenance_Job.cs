using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Maintenance_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__20 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Maintenance_Job _003C_003E4__this;

			private Prop _003Cobject2Maintain_003E5__2;

			private ListPoolX.DisposablePooledList<string> _003Canims_003E5__3;

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
			public _003CGetActivities_003Ed__20(int _003C_003E1__state)
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
		public bool IsRepairJob;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _ignoreOnHoldChange;

		[PersistenceOptIn]
		private string _maintainUsage;

		[PersistenceOptIn]
		private string _animation;

		[PersistenceOptIn]
		private bool _waitingForLastFinishedEvent;

		[PersistenceOptIn]
		private bool _lastFinishedEventCaught;

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

		protected Maintenance_Job()
		{
		}

		public Maintenance_Job(GameObjectX source, Prop target, bool isToRepair = false)
		{
		}

		private void TimeControllerOnHourChanged(object sender, EventArgs e)
		{
		}

		private void PropOnScheduleChanged(object sender, EventArgs e)
		{
		}

		private void OnPropOnFireChanged(object sender, EventArgs<Prop> e)
		{
		}

		private void OnRepairAtDamagePercentageChanged(object sender, EventArgs<int> e)
		{
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		private void OnIsBrokenChanged(object sender, EventArgs<Prop> e)
		{
		}

		public override void InitPostLoad()
		{
		}

		private void OnDamageChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		protected override string GetHighLevelTaskDescriptionKeyInternal()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__20))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public override void SetOnHold(bool onHold)
		{
		}

		protected void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected void NotifyMaintenanceCompleted()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
