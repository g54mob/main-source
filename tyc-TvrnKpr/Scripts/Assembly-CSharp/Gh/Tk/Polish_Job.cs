using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Polish_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public Polish_Job _003C_003E4__this;

			public Room room;

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
		private sealed class _003CGetActivities_003Ed__15 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Polish_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

			private bool _003CdoneLocal_003E5__2;

			private string _003CsubKey_003E5__3;

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
			public _003CGetActivities_003Ed__15(int _003C_003E1__state)
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
		[PersistenceObjectReference]
		public CleaningMop CleaningMop;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IgnoreSchedule;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public DirtBase CurrentDirt;

		[PersistenceOptIn]
		private float _durationLeft;

		[PersistenceOptIn]
		private float _increasePercentagePerSecond;

		[PersistenceOptIn]
		private float _decreaseFilthValuePerSecond;

		[PersistenceOptIn]
		private Vector3? _targetPosition;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _done;

		[PersistenceOptIn]
		private bool _cleanStartReceived;

		[PersistenceOptIn]
		private bool _attachedToListener;

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

		private Polish_Job()
		{
		}

		private void TimeControllerOnHourChanged(object sender, EventArgs e)
		{
		}

		public Polish_Job(CleaningMop source, Room target, bool ignoreSchedule = false, int priority = -80)
		{
		}

		private void SetCurrentTargetRoom()
		{
		}

		public void ChangeTarget(GameObjectX gox)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__15))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private DirtBase GetBestNextDirt(Room room)
		{
			return null;
		}

		private void SetBlockingDirt(bool value)
		{
		}

		protected override void OnFinishInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void RemoveListener()
		{
		}

		private void UpdatePriority()
		{
		}
	}
}
