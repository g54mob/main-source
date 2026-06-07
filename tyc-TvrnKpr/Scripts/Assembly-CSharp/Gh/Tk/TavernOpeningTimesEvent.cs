using System;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public sealed class TavernOpeningTimesEvent : GameEvent
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void RoomZoneOrScheduleChanged(object sender, EventArgs e)
		{
		}

		private TavernOpeningTimesEvent()
		{
		}

		private TavernOpeningTimesEvent(bool isOpenEvent, float dueInDaysF = 0f)
		{
		}

		public override void Trigger()
		{
		}

		public static void RefreshTavernOpeningEvents()
		{
		}
	}
}
