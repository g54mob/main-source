using System.Collections.Generic;
using Gh.Tk.Story;
using Gh.Tk.Story.Config;
using Gh.Tk.Story.GameModifiers;
using LitJson;

namespace Gh.Tk
{
	public class PatronSpawnModifierEvent : StoryNodeEvent
	{
		private bool _createdPawns;

		private int _durationInHours;

		[JsonIgnore]
		public int StartHour => 0;

		[JsonIgnore]
		public int HoursFromNow => 0;

		[JsonIgnore]
		public int DurationInHours => 0;

		[JsonIgnore]
		private int DurationFromStartHour => 0;

		protected PatronSpawnModifierEvent()
		{
		}

		public static PatronSpawnModifierEvent CreateRandomNeedIncreaseEvent(int startHour, int durationInHours, int offsetInDays, PatronNeedConfigNode need)
		{
			return null;
		}

		private static IEnumerable<PatronPopulationData> GetPotentiallyAffectedPawns(string needType, int minTier, int maxTier, int hourFromNowStart, int durationInHours)
		{
			return null;
		}

		public PatronSpawnModifierEvent(ActiveStory story)
		{
		}

		private void SetEventTiming(int startHour, int durationInHours, int offsetInDays, bool forceOnNextDay, out int startInHours)
		{
			startInHours = default(int);
		}

		private void SetTooltipTextBlockContent(PatronSpawnModifierNode node)
		{
		}

		private List<PatronPopulationData> GeneratePawns(PatronSpawnModifierNode node, int startInHours)
		{
			return null;
		}

		private int ModifySpawnPawns(int hoursFromNow, IEnumerable<IPatronPawnModifyingConfig> configData)
		{
			return 0;
		}

		private PatronPopulationData[] GetAffectedPawns(int hoursFromNow, SpawnPatron spawnPatron)
		{
			return null;
		}

		public override void Trigger()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
