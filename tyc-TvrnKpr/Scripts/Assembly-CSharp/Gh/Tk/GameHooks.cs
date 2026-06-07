using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class GameHooks : MonoBehaviour
	{
		public static event EventHandler<EventArgs<GameObjectX>> GameObjectXDestroyed
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

		public static event EventHandler<EventArgs<StaffData>> BeforeGeneratingStaff
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

		public static event EventHandler<EventArgs<Staff>> StaffGenerated
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

		public static event EventHandler<EventArgs<(int old, int @new)>> SlotMachineProfitChanged
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

		public static event EventHandler<EventArgs<TavernLog.TransactionLogEntry>> TavernTransactionLogged
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

		public static event EventHandler<EventArgs<TavernLog.TavernEventLogEntry>> TavernLogEventLogged
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

		public static event EventHandler<EventArgs<(Staff staff, int wage)>> StaffPaid
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

		public static event EventHandler<EventArgs<Staff>> StaffFired
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

		public static event EventHandler<EventArgs<string>> PropDiscountChanged
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

		public static event EventHandler<EventArgs<StarRatingManager>> StarRatingChanged
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

		public static event EventHandler<EventArgs<(string key, int value)>> TavernCounterChanged
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

		public static event EventHandler<EventArgs<(Staff staff, Patron patron)>> StaffInteractedWithPatron
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

		public static event EventHandler LevelLoadingBegun
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

		public static event EventHandler<EventArgs<(EventCamera camera, EventCameraSettings settings)>> EventCameraClicked
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

		public static event EventHandler<EventArgs<Prop>> PropBuilt
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

		public static event EventHandler<EventArgs<Prop>> PropRemoved
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

		public static event EventHandler PendingGroupsChanged
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

		public static event EventHandler WeatherEffectChanged
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

		public static event EventHandler PatronAttractionClarityChanged
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

		public static void FireGameObjectXDestroyedEvent(GameObjectX gox)
		{
		}

		internal static void FireBeforeGeneratingStaff(StaffData data)
		{
		}

		internal static void FireStaffGeneratedEvent(Staff staff)
		{
		}

		internal static void FireSlotMachineProfitChanged(int old, int @new)
		{
		}

		internal static void FireTavernTransactionLogged(TavernLog.TransactionLogEntry entry)
		{
		}

		internal static void FireTavernEventLogged(TavernLog.TavernEventLogEntry entry)
		{
		}

		internal static void FireStaffPaidEvent(Staff staff, int wage)
		{
		}

		internal static void FireStaffFiredEvent(Staff staff)
		{
		}

		internal static void FirePropDiscountChangedEvent(string propId)
		{
		}

		internal static void FireStarRatingChangedEvent(StarRatingManager manager)
		{
		}

		internal static void FireTavernCounterChangedEvent(string key, int value)
		{
		}

		public static void FireStaffInteractedWithPatron(Staff owner, Patron patron)
		{
		}

		public static void FireLevelLoadingBegun()
		{
		}

		public static void FireEventCameraClicked(EventCamera eventCamera, EventCameraSettings eventCameraSettings)
		{
		}

		public static void FirePropBuiltEvent(Prop prop)
		{
		}

		public static void FirePropRemovedEvent(Prop prop)
		{
		}

		public static void FirePendingGroupsChanged()
		{
		}

		public static void FireWeatherEffectChanged()
		{
		}

		public static void FireAttractionClarityChangedEvent()
		{
		}
	}
}
