using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class Bed : Larder_Tile
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public Staff staff;

			public Bed _003C_003E4__this;

			public ButtonContextMenuItem button;

			internal void _003CGetAvailableManualJobs_003Eb__0()
			{
			}

			internal bool _003CGetAvailableManualJobs_003Eb__1()
			{
				return false;
			}

			internal void _003CGetAvailableManualJobs_003Eb__3()
			{
			}

			internal void _003CGetAvailableManualJobs_003Eb__4()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__20 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Staff staff;

			public Staff _003C_003E3__staff;

			public Bed _003C_003E4__this;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetAvailableManualJobs_003Ed__20(int _003C_003E1__state)
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
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static HashSet<Bed> AllBeds;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private RoomReservation _reservation;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _needsMakingBed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _linenDirtState;

		public int RoomRating => 0;

		public Actor ActorUsingBed => null;

		public RoomReservation Reservation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public GameItemTemplate CurrentLinenType { get; set; }

		public GameItemTemplate DesiredLinenType => null;

		public bool NeedsLinenChange => false;

		public bool NeedsMakingBed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool NeedsService => false;

		public float LastService { get; set; }

		public static event EventHandler<EventArgs> NeedsLinenChangeEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs> NeedsMakingEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Bed>> BedDestroyed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs> AllBedsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal void RaiseNeedsLinenChangeEvent()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__20))]
		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		public int GetLinenDirtState()
		{
			return 0;
		}

		public void OnBedUsed()
		{
		}

		private void InvalidateLinenState()
		{
		}

		public override int GetPrice()
		{
			return 0;
		}

		public override float? GetFilth()
		{
			return null;
		}

		internal void ChangeLinen(GameItemTemplate type)
		{
		}

		public string GetSleepUsageKey(bool unwell = false)
		{
			return null;
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public float? GetQuality()
		{
			return null;
		}

		public override void OnDemolish()
		{
		}

		public override void PostBuiltInit()
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public override bool CanUse(Actor actor, bool ignoreMaintenanceState = false, bool ignoreBrokenState = false)
		{
			return false;
		}

		public static IEnumerable<Bed> GetBedsForPatrons()
		{
			return null;
		}

		public static IEnumerable<Bed> GetFreeBedsForPatrons()
		{
			return null;
		}

		public static IEnumerable<Bed> GetFreeBedsForPatrons(int tier)
		{
			return null;
		}

		public void ReturnRoomKeys()
		{
		}
	}
}
