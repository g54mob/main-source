using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.NPCs
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/CurrentDayVisitsSettings", fileName = "CurrentDayVisitsSettings")]
	public class CurrentDayVisitsSettings : ScriptableObject
	{
		private static class Style
		{
			public const string TimeBetweenVisitsGroup = "Time Between Visits";

			public const string FirstVisitOfTheDayTimeGroup = "First Visit Of The Day Time";

			public const string DefaultNpcsGroup = "Default NPCs";

			public const string VisitsUnblockingDelaysGroup = "Delays Before Unblocking Visits";
		}

		[SerializeField]
		private StoryNpcInfo defaultCourierNPC;

		[SerializeField]
		private TimeOfDay minFirstVisitTimeAfterDayStarts = new TimeOfDay(0, 5, 0);

		[SerializeField]
		private TimeOfDay maxFirstVisitTimeAfterDayStarts = new TimeOfDay(0, 15, 0);

		[SerializeField]
		private TimeOfDay minDelayAfterImmediateVisit = new TimeOfDay(0, 5, 0);

		[SerializeField]
		private TimeOfDay delayBeforeCourierVisit = new TimeOfDay(0, 3, 0);

		[SerializeField]
		private float delayAfterWindowOpensBeforeUnblockingVisits = 3f;

		public TimeOfDay MinFirstVisitTimeAfterDayStarts => minFirstVisitTimeAfterDayStarts;

		public TimeOfDay MaxFirstVisitTimeAfterDayStarts => maxFirstVisitTimeAfterDayStarts;

		public StoryNpcInfo DefaultCourierNpc => defaultCourierNPC;

		public float DelayAfterWindowOpensBeforeUnblockingVisits => delayAfterWindowOpensBeforeUnblockingVisits;

		public TimeOfDay MinDelayAfterImmediateVisit => minDelayAfterImmediateVisit;

		public TimeOfDay DelayBeforeCourierVisit => delayBeforeCourierVisit;
	}
}
